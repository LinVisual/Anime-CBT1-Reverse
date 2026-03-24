using System;
using System.Collections.Generic;
using UnityEngine;
using VerletEngine;

namespace DynamicBoneImprove
{
	[Serializable]
	public class DynamicBoneWindForce
	{
		[NonSerialized]

		public bool bNeedAdditiveWindForce;
		[NonSerialized]

		public Vector3 cachedAnchorTransformPosition;

		[NonSerialized]
		public Vector3 cachedAnchorPlaneNormal;

		[Header("[Multiple this factor to original windForce]")]
		[Range(0f, 100f)]
		[Tooltip("How much of wind zone force is applied in physics simulation. 0 means no windForce applied")]
		public float m_windForceMultiplier;

		[Header("[Multiplier changes along bone length]")]
		public AnimationCurve m_multiplierDistrib;

		[Header("[for debug info only, don't change]")]
		[HideInInspector]
		public bool m_isStationary;

		[Range(0f, 1f)]
		[Tooltip("How much the bones slowed down.")]
		public float m_overrideDamping = 0.1f;

		[Range(0f, 1f)]
		[Tooltip("How much the force applied to return each bone to original orientation.")]
		public float m_overrideElasticity = 0.1f;

		[Range(0f, 1f)]
		[Tooltip("How much bone's original orientation are preserved.")]
		public float m_overrideStiffness = 0.1f;

		[Header("[wind force up limit: Value will be adjusted based on the angle between wind direction and the anchor to boneLine direction]")]
		[Range(0f, 100f)]
		[Tooltip("wind Force Up Limit")]
		public float m_windForceUpLimit = 5f;

		[Header("[x=0.5 wind blows sideway]")]
		[Header("[uplimit adjust factor y should be 0, when x=0 wind blows from boneline to anchor]")]
		[Header("[uplimit adjust factor y should be 1, x=1 wind blows from anchor to boneline]")]
		public AnimationCurve m_uplimitDistrib;

		[Tooltip("Max Wind strength to Clamp 1 for windFrequencyDistrib")]
		public float m_maxWind = 10f;

		[Tooltip("How wind strength affect frequency and range")]
		public AnimationCurve m_windFrequencyDistrib;

		private float m_startTime;

		public float m_windChangeFrequency;

		public float m_frequencySwingRange;

		[Header("[for debug info only, don't change]")]
		[HideInInspector]
		public float m_weatherWindSource;

		[Header("[for debug info only, don't change]")]
		[HideInInspector]
		public float m_lastAppliedWindForce;

		[HideInInspector]
		public List<int> m_endBoneIndex = new List<int>();

		[HideInInspector]
		public List<Vector3> m_anchorToBoneDir = new List<Vector3>();

		public List<Vector3> computedAnchorToBoneDir = new List<Vector3>();

		[Header("[the center that each boneline can be blowed away from]")]
		public Transform m_anchor;

		[Header("[the plane that each boneline can be blowed away from, in root object space]")]
		public Vector3 m_anchorPlaneNormal;

		private Rigidbody m_rigidbody;

		private float m_speedUpLimit = 0.1f;

		private DynamicBoneArray m_dynamicBoneArray;

		//OK
		public void Init(DynamicBoneArray dba, bool bKeeyStartTime = false /* Metadata: 0x0092E210 */)
		{
			if (dba != null)
			{
				m_dynamicBoneArray = dba;
				Rigidbody[] rigidbodys = dba.GetComponentsInParent<Rigidbody>();
				if (rigidbodys.Length > 1)
				{
					Debug.LogErrorFormat("found {0} rigidbodys on:", rigidbodys.Length, dba.transform.name);
				}
				else if (rigidbodys.Length == 1)
				{
					m_rigidbody = rigidbodys[0];
				}
				m_isStationary = false;
				if (bKeeyStartTime)
				{
					m_startTime = Time.time;
				}
				computedAnchorToBoneDir = new List<Vector3>(m_anchorToBoneDir);
			}
		}

		#warning Alright, I gave it up, but it can run? Address: 181D18F50

		public Vector3 GetWindForceForParticle(Vector3 windForceSource, VerletParticle particle, ref float angleDiff, ref float curveValue)
		{
			float m_windForceMultiplier; // xmm6_4
			Vector3 windForce; // rax
			float m_windForceUpLimit; // xmm6_4
			float v59; // xmm12_4
			m_weatherWindSource = windForceSource.magnitude;
			if (particle == null)
			{
				return windForceSource;
			}
			m_windForceMultiplier = particle.m_windForceMultiplier;
			if (m_windForceMultiplier > 0f && m_isStationary)
			{
				windForce = windForceSource * (this.m_windForceMultiplier * m_windForceMultiplier);
				if (m_windChangeFrequency > 0f)
				{
					float frequencyFactor = m_windFrequencyDistrib != null ? m_windFrequencyDistrib.Evaluate(Mathf.Clamp01(m_weatherWindSource / m_maxWind)) : 1f;
					windForce *= (m_frequencySwingRange * frequencyFactor * Mathf.Sin(m_windChangeFrequency * frequencyFactor * (Time.time - m_startTime)) * particle.m_windForceMultiplier) + 1f;
				}
				m_windForceUpLimit = this.m_windForceUpLimit;
				if (m_anchor != null && particle.m_BoneTransform != null)
				{
					for (int i = 0; i < m_dynamicBoneArray.m_RootList.Length; i++)
					{
						if (m_dynamicBoneArray.m_RootList[i] != null)
						{
							if (particle.m_BoneTransform.IsChildOf(m_dynamicBoneArray.m_RootList[i]))
							{
								angleDiff = Vector3.Angle(m_anchor.TransformDirection(m_anchorToBoneDir[i]), windForceSource.normalized);
								goto LABEL_6666;
							}
						}
					}
				}
				else
				{
					if (m_anchorPlaneNormal != Vector3.zero)
					{
						angleDiff = Vector3.Angle(m_dynamicBoneArray.transform.TransformDirection(m_anchorPlaneNormal), windForceSource.normalized);
						goto LABEL_6666;
					}
				}
			LABEL_73:
				if (m_windForceUpLimit >= 0f)
				{
					goto LABEL_74;
				}
				m_lastAppliedWindForce = windForce.magnitude;
				return windForce;
			LABEL_74:
				if (windForce.magnitude > m_windForceUpLimit)
				{
					windForce = windForce.normalized * m_windForceUpLimit;
				}
				m_lastAppliedWindForce = windForce.magnitude;
				return windForce;
			LABEL_6666:
				v59 = 1f - (float)(angleDiff / 180f);
				if (m_uplimitDistrib != null)
				{
					curveValue = Mathf.Clamp01(m_uplimitDistrib.Evaluate(v59));
					m_windForceUpLimit = curveValue * m_windForceUpLimit;
					goto LABEL_73;
				}
				else
				{
					goto LABEL_80;
				}
			LABEL_80:
				if (v59 < 0.5f)
				{
					m_windForceUpLimit = 0.001f;
					goto LABEL_74;
				}
				goto LABEL_73;
			}
			return Vector3.zero;
		}

		//OK
		public bool OnUpdate()
		{
			if (m_windForceMultiplier > 0f)
			{
				if (m_isStationary)
				{
					if (m_rigidbody == null)
					{
						return false;
					}
					if (m_rigidbody.velocity.sqrMagnitude <= m_speedUpLimit * m_speedUpLimit)
					{
						return false;
					}	
				}
				else
				{
					if (m_rigidbody == null)
					{
						m_isStationary = true;
						return true;
					}
					if (m_speedUpLimit * m_speedUpLimit <= m_rigidbody.velocity.sqrMagnitude)
					{
						return false;
					}
				}
				m_isStationary = !m_isStationary;
				return true;
			}
			else
			{
				m_isStationary = true;
				return false;
			}
		}

		#region Multithreading is not supported now

		//public void CacheForComputeThread() {} // 0x0000000181D18720-0x0000000181D189B0
		//public Vector3 GetWindForceForParticle_ComputeThread(ref Vector3 windForceSource, VerletParticle particle, ref float angleDiff, ref float curveValue) => default; // 0x0000000181D189B0-0x0000000181D18F50

		#endregion
	}
}

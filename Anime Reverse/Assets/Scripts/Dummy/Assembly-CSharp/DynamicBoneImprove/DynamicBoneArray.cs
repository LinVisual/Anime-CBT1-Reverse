using MoleMole;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using VerletEngine;

namespace DynamicBoneImprove
{
	[AddComponentMenu("Dynamic Bone/Dynamic Bone Array")]
	public class DynamicBoneArray : MonoBehaviour
	{
		public enum UpdateMode
		{
			Normal = 0,
			AnimatePhysics = 1,
			UnscaledTime = 2,
			OncePerFrame = 3,
			OncePerFixedUpdate = 4
		}

		public enum FreezeAxis
		{
			None = 0,
			X = 1,
			Y = 2,
			Z = 3
		}

		public enum DebugDrawOption
		{
			None = 0,
			Selected = 1,
			Always = 2
		}
		
		[Tooltip("The root of the transform hierarchy to apply physics.")]
		public Transform[] m_RootList;

		[Header("[Time]")]
		[Tooltip("Internal physics simulation rate.")]
		public float m_UpdateRate = 30f;

		public UpdateMode m_UpdateMode = UpdateMode.OncePerFrame;

		[Header("[Verlet]")]
		[Range(0f, 1f)]
		[Tooltip("How much the bones slowed down.")]
		public float m_Damping = 0.1f;

		public AnimationCurve m_DampingDistrib;

		[Header("[Keep Shape]")]
		public bool m_KeepShape = true;

		public bool m_KeepLength;

		[Range(0f, 1f)]
		[Tooltip("How much the force applied to return each bone to original orientation.")]
		public float m_Elasticity = 0.1f;

		public AnimationCurve m_ElasticityDistrib;

		[Range(0f, 1f)]
		[Tooltip("How much bone's original orientation are preserved.")]
		public float m_Stiffness = 0.1f;

		public AnimationCurve m_StiffnessDistrib;

		[Header("[Object Move]")]
		[Range(0f, 1f)]
		[Tooltip("How much character's position change is ignored in physics simulation.")]
		public float m_Inert;
		public AnimationCurve m_InertDistrib;

		[Header("[Additional End Bone]")]
		[Tooltip("If End Length is not zero, an extra bone is generated at the end of transform hierarchy.")]
		public float m_EndLength;

		[Tooltip("If End Offset is not zero, an extra bone is generated at the end of transform hierarchy.")]
		public Vector3 m_EndOffset = Vector3.zero;

		[Header("[Forces]")]
		[Tooltip("The force apply to bones. Partial force apply to character's initial pose is cancelled out.")]
		public Vector3 m_Gravity = Vector3.zero;

		[Tooltip("The force apply to bones.")]
		public Vector3 m_Force = Vector3.zero;

		public DynamicBoneWindForce m_AdditiveWindForce = new DynamicBoneWindForce();

		[Header("[Collisions]")]
		[Tooltip("Each bone can be a sphere to collide with colliders. Radius describe sphere's size.")]
		public float m_Radius;

		public AnimationCurve m_RadiusDistrib;

		[Tooltip("Collider objects interact with the bones.")]
		public List<DynamicBoneColliderBaseMMD> m_Colliders;

		[Header("Exclude Bones")]
		[Tooltip("Bones exclude from physics simulation.")]
		public List<Transform> m_Exclusions;

		[Tooltip("Constrain bones to move on specified plane.")]
		public FreezeAxis m_FreezeAxis;

		[Tooltip("The specified plane of ref Transform")]
		public Transform m_FreezeTransformRef;

		private Vector3 m_FreezeTransformAxis;

		[Header("[Level Of Detail]")]
		[Tooltip("Disable physics simulation automatically if character is far from camera or player.")]
		public bool m_DistantDisable;

		public Transform m_ReferenceObject;

		public float m_DistanceToObject = 20f;

		[Header("[ForDebug]")]
		public DebugDrawOption m_DebugDraw = DebugDrawOption.Selected;

		[Header("[ForDebug]")]
		public string m_watchParticleName;

		[Header("[ForDebug]")]
		public bool m_useDebugWind;

		[Header("[ForDebug]")]
		public Vector4 m_debugWind;

		private float m_lastFrameRemainTime;

		private const int MaxDbUpdateCountOneFrame = 3;

		private float m_lastFrameDeltaTime = -1f;

		private Vector3 m_LocalGravity = Vector3.zero;

		private float m_ObjectScale = 1f;

		[NonSerialized]
		public Vector3 cachedLossyScale = Vector3.one;

		private Vector3 m_ObjectMove = Vector3.zero;

		private Vector3 m_ObjectPrevPosition = Vector3.zero;

		private List<float> m_BoneTotalLengthList = new List<float>();

		private float m_Weight = 1f;

		private bool m_DistantDisabled;

		private List<VerletParticle> m_Particles = new List<VerletParticle>();

		private Vector3 m_posOffset = Vector3.zero;

		#region Multithreading is not supported now

		//private KIDNICFLODF _threadTask;

		#endregion

		private bool bRootIsValid;

		[NonSerialized]
		public bool bMultiThread = true;

		public static bool bResetBoneInUpdate = true;

		#region Multithreading is not supported now

		//private int _enableFrameCount;

		#endregion

		private Transform _rootTransform;

		#region Multithreading is not supported now

		//private ABPJCCGNGKC _pendingChange = new ABPJCCGNGKC();

		#endregion

		//OK
		public List<VerletParticle> verletParticles
		{
			get
			{
				return m_Particles;
			}
		}

		//OK
		public Transform rootTransform
		{
			get
			{
				return _rootTransform;
			}
		}

		//OK
		private void Start()
		{
			m_UpdateRate = Mathf.Clamp(m_UpdateRate, 0f, 30f);
			if (m_KeepLength && !m_KeepShape && m_RootList.Length <= 2)
			{
				bMultiThread = false;
			}
			#region Multithreading is not supported now

			bMultiThread = false;

			#endregion
			Init(false);
		}

		//OK
		private void Init(bool bRestart)
		{
			if (bRestart)
			{
				ResetBindPose();
			}
			SetupParticles();
			if (m_AdditiveWindForce == null)
			{
				m_AdditiveWindForce = new DynamicBoneWindForce();
			}
			InitWindforceBones();
			m_AdditiveWindForce.Init(this, bRestart);
			if (bMultiThread)
			{
				#region Multithreading is not supported now

				//CreateComputeThreadTask();

				#endregion
			}
			bRootIsValid = m_RootList != null && m_RootList.Length > 0 && m_RootList[0] != null;
		}

		//OK
		private void FixedUpdate()
		{
			if (m_UpdateMode == UpdateMode.AnimatePhysics || m_UpdateMode == UpdateMode.OncePerFixedUpdate)
			{
				PreUpdate();
				if (m_UpdateMode == UpdateMode.OncePerFixedUpdate)
				{
					CheckDistance();
					if (NeedUpdateDynamicBone())
					{
						UpdateDynamicBones(Time.deltaTime);
					}
				}
			}
		}

		//OK
		private void Update()
		{
			if (m_UpdateMode != UpdateMode.AnimatePhysics && m_UpdateMode != UpdateMode.OncePerFixedUpdate)
			{
				PreUpdate();
			}
			UpdateWindForce();
		}

		//OK
		public void InternalLateUpdate_UnityThread()
		{
			if (m_UpdateMode != UpdateMode.OncePerFixedUpdate)
			{
				CheckDistance();
				if (NeedUpdateDynamicBone())
				{
					UpdateDynamicBones(Time.deltaTime);
				}
			}
		}

		//OK
		[ContextMenu("ToggleMultiThread")]
		private void ToggleMultiThread()
		{
			bMultiThread = !bMultiThread;
		}

		//OK
		[ContextMenu("ToggleResetBoneInUpdate")]
		private void ToggleResetBoneInUpdate()
		{
			bResetBoneInUpdate = !bResetBoneInUpdate;
		}

		//OK
		private void LateUpdate()
		{
			if (!bMultiThread)
			{
				InternalLateUpdate_UnityThread();
			}
		}

		//OK
		private void PreUpdate()
		{
			Vector3 offset = transform.position - m_posOffset;
			if (Mathf.Abs(offset.x) > 1024f || Mathf.Abs(offset.y) > 1024f || Mathf.Abs(offset.z) > 1024f)
			{
				ResetBoneTransforms();
				m_posOffset = transform.position;
				ResetParticlesPosition();
			}
		}

		//OK
		private void OnEnable()
		{
			#region Multithreading is not supported now

			//_enableFrameCount = 0;

			#endregion
			ResetParticlesPosition();
		}

		//OK
		private void OnDisable()
		{
			ResetBoneTransforms();
			m_posOffset = Vector3.zero;
		}

		private void OnDestroy() {} // 0x0000000181D08CA0-0x0000000181D08CC0

		[System.Diagnostics.DebuggerHidden]
		private IEnumerator DelayRestart() => default; // 0x0000000181D08C40-0x0000000181D08CA0

		//OK
		private void ResetBindPose()
		{
			transform.MFDHGDAOMFP();
		}

		//OK
		private void OnValidate()
		{
		}

		private void DrawDebugInfo() {} // 0x0000000181D08CC0-0x0000000181D097E0

		//OK
		private void DrawString(string text, Vector3 worldPos, Color? colour = default)
		{
		}

		//OK
		private bool NeedUpdateDynamicBone()
		{
			if (m_Weight > 0f)
			{
				return !m_DistantDisable || !m_DistantDisabled;
			}
			return false;
		}

		//OK
		private void CheckDistance()
		{
			if (m_DistantDisable)
			{
				if (m_ReferenceObject == null && Miscs.mainCamera != null)
				{
					m_ReferenceObject = Miscs.mainCamera.transform;
				}
				if (m_ReferenceObject != null)
				{
					float sqrDistance = (m_ReferenceObject.position - transform.position).sqrMagnitude;
					float sqrDistanceThreshold = m_DistanceToObject * m_DistanceToObject;
					bool isBeyondThreshold = sqrDistance > sqrDistanceThreshold;
					if (sqrDistance <= sqrDistanceThreshold && m_DistantDisabled != isBeyondThreshold)
					{
						ResetParticlesPosition();
					}
					m_DistantDisabled = isBeyondThreshold;
					return;
				}
			}
		}

		//OK
		private void SetupParticles()
		{
			m_Particles.Clear();
			m_BoneTotalLengthList.Clear(); ;
			m_ObjectScale = Mathf.Abs(transform.lossyScale.x);
			m_posOffset = transform.position;
			m_ObjectPrevPosition = transform.position;
			m_ObjectMove = Vector3.zero;
			cachedLossyScale = transform.lossyScale;
			for (int i = 0; i < m_RootList.Length; i++)
			{
				m_BoneTotalLengthList.Add(0f);
				RecursivelyAppendParticles(m_RootList[i], -1, 0f, i);
			}
			UpdateParticleParameters();
			for (int i = 0; i < m_Particles.Count; i++)
			{
				m_Particles[i].CacheDynamicBoneRootListIndex(m_RootList);
			}
		}

		[ContextMenu("InitWindforce")]
		private void InitWindforceBones() { } // 181D09AB0

		//OK
		private float AddNewParticle(int parentIndex, float parentBoneLength, int rootIndex, Transform boneTransform)
		{
			VerletParticle verletParticle = new VerletParticle();
			Transform bone = boneTransform;
			verletParticle.m_ParentIndex = parentIndex;
			verletParticle.m_RootIndex = rootIndex;
			verletParticle.m_posOffset = m_posOffset;
			if (boneTransform != null)
			{
				verletParticle.m_InitLocalPosition = boneTransform.localPosition;
				verletParticle.m_InitLocalRotation = boneTransform.localRotation;
				verletParticle.m_BoneTransform = boneTransform;
			}
			else
			{
				if (parentIndex < 0 || parentIndex >= m_Particles.Count || m_Particles[parentIndex] == null)
				{
					Debug.LogWarning("Invalid parent index!");
					return 0f;
				}
				bone = m_Particles[parentIndex].m_BoneTransform;
				if (bone == null)
				{
					Debug.LogWarning("parent transform is NULL!");
					return 0f;
				}
				if (m_EndLength > 0f)
				{
					Transform parentBone = bone.parent;
					if (parentBone == null)
					{
						verletParticle.m_EndOffset = new Vector3(m_EndLength, 0f, 0f);
					}
					else
					{
						verletParticle.m_EndOffset = bone.InverseTransformPoint((bone.position * 2f) - parentBone.position) * m_EndLength;
					}
				}
				else
				{
					verletParticle.m_EndOffset = bone.InverseTransformPoint(transform.TransformDirection(m_EndOffset) + bone.position);
				}
			}
			Vector3 worldPosition = bone.TransformPoint(verletParticle.m_EndOffset);
			verletParticle.m_PrevPosition = worldPosition;
			verletParticle.m_Position = worldPosition;
			m_Particles.Add(verletParticle);
			return UpdateBoneLength(ref verletParticle, parentBoneLength, rootIndex);
		}

		//OK
		private void AppendAdditionalEndParticle(int parentIndex, float parentBoneLength, int rootIndex)
		{
			AddNewParticle(parentIndex, parentBoneLength, rootIndex, null);
		}

		//OK
		private float UpdateBoneLength(ref VerletParticle p, float parentBoneLength, int rootIndex)
		{
			if (p.isRoot())
			{
				return parentBoneLength;
			}
			float boneLength = parentBoneLength + 1f;
			p.m_BoneLength = parentBoneLength + 1f;
			m_BoneTotalLengthList[rootIndex] = Mathf.Max(m_BoneTotalLengthList[rootIndex], boneLength);
			return boneLength;
		}

		#warning There are toooooo many labels for me. I'm not sure if this is correct. Address: 181D0AB90

		private void RecursivelyAppendParticles(Transform b, int parentIndex, float parentBoneLength, int rootIndex)
		{
			if (b == null)
			{
				AddNewParticle(parentIndex, parentBoneLength, rootIndex, b);
				return;
			}
			parentBoneLength = AddNewParticle(parentIndex, parentBoneLength, rootIndex, b);
			parentIndex = m_Particles.Count - 1;
			for (int i = 0; i < b.childCount; i++)
			{
				Transform child = b.GetChild(i);
				if (m_Exclusions != null)
				{
					for (int j = 0; j < m_Exclusions.Count ; ++j)
					{
						if (m_Exclusions[j] == child)
						{
							if (m_EndLength > 0f || m_EndOffset != Vector3.zero)
							{
								child = null;
							}
							break;
						}
					}
				}
				RecursivelyAppendParticles(child, parentIndex, parentBoneLength, rootIndex);
			}
			if (b.childCount == 0 && (m_EndLength > 0f || m_EndOffset != Vector3.zero))
			{
				AppendAdditionalEndParticle(parentIndex, parentBoneLength, rootIndex);
			}
		}

		//OK
		private void UpdateParticleParameters()
		{
			if (m_RootList != null)
			{
				for (int i = 0; i < m_Particles.Count; i++)
				{
					VerletParticle verletParticle = m_Particles[i];
					verletParticle.SetParams(m_Damping, m_Elasticity, m_Stiffness, m_Inert, m_Radius);
					if (m_AdditiveWindForce != null)
					{
						verletParticle.m_windForceMultiplier = 1f;
					}
					if (m_BoneTotalLengthList[verletParticle.m_RootIndex] > 0f)
					{
						float normalized = verletParticle.m_BoneLength / m_BoneTotalLengthList[verletParticle.m_RootIndex];
						if (m_DampingDistrib != null && m_DampingDistrib.keys.Length > 0)
						{
							verletParticle.m_Damping = m_DampingDistrib.Evaluate(normalized) * verletParticle.m_Damping;
						}
						if (m_ElasticityDistrib != null && m_ElasticityDistrib.keys.Length > 0)
						{
							verletParticle.m_Elasticity = m_ElasticityDistrib.Evaluate(normalized) * verletParticle.m_Elasticity;
						}
						if (m_StiffnessDistrib != null && m_StiffnessDistrib.keys.Length > 0)
						{
							verletParticle.m_Stiffness = m_StiffnessDistrib.Evaluate(normalized) * verletParticle.m_Stiffness;
						}
						if (m_InertDistrib != null && m_InertDistrib.keys.Length > 0)
						{
							verletParticle.m_Inert = m_InertDistrib.Evaluate(normalized) * verletParticle.m_Inert;
						}
						if (m_RadiusDistrib != null && m_RadiusDistrib.keys.Length > 0)
						{
							verletParticle.m_Radius = m_RadiusDistrib.Evaluate(normalized) * verletParticle.m_Radius;
						}
						if (m_AdditiveWindForce != null && m_AdditiveWindForce.m_multiplierDistrib != null && m_AdditiveWindForce.m_multiplierDistrib.keys.Length > 0)
						{
							verletParticle.m_windForceMultiplier = Mathf.Clamp01(m_AdditiveWindForce.m_multiplierDistrib.Evaluate(normalized));
						}
					}
					verletParticle.m_Damping = Mathf.Clamp01(verletParticle.m_Damping);
					verletParticle.m_Elasticity = Mathf.Clamp01(verletParticle.m_Elasticity);
					verletParticle.m_Stiffness = Mathf.Clamp01(verletParticle.m_Stiffness);
					verletParticle.m_Inert = Mathf.Clamp01(verletParticle.m_Inert);
					verletParticle.m_Radius = Mathf.Max(verletParticle.m_Radius, 0f);
				}
			}
		}

		//OK
		private void UpdateWindForce()
		{
			if (m_AdditiveWindForce != null && m_AdditiveWindForce.OnUpdate())
			{
				if (m_AdditiveWindForce.m_isStationary)
				{
					if (GetWindForceSource() == Vector3.zero)
					{
						UpdateParticleParameters(m_Damping, m_Elasticity, m_Stiffness);
					}
					else
					{
						UpdateParticleParameters(m_AdditiveWindForce.m_overrideDamping, m_AdditiveWindForce.m_overrideElasticity, m_AdditiveWindForce.m_overrideStiffness);
					}
				}
				else
				{
					UpdateParticleParameters(m_Damping, m_Elasticity, m_Stiffness);
				}
			}
		}

		//OK
		private void UpdateParticleParameters(float damping, float elasticity, float stiffness)
		{
			if (m_RootList != null)
			{
				for (int i = 0; i < m_Particles.Count; i++)
				{
					VerletParticle verletParticle = m_Particles[i];
					verletParticle.m_Damping = damping;
					verletParticle.m_Elasticity = elasticity;
					verletParticle.m_Stiffness = stiffness;
					if (m_BoneTotalLengthList[verletParticle.m_RootIndex] > 0f)
					{
						float normalized = verletParticle.m_BoneLength / m_BoneTotalLengthList[verletParticle.m_RootIndex];
						if (m_DampingDistrib != null && m_DampingDistrib.keys.Length > 0)
						{
							verletParticle.m_Damping = m_DampingDistrib.Evaluate(normalized) * verletParticle.m_Damping;
						}
						if (m_ElasticityDistrib != null && m_ElasticityDistrib.keys.Length > 0)
						{
							verletParticle.m_Elasticity = m_ElasticityDistrib.Evaluate(normalized) * verletParticle.m_Elasticity;
						}
						if (m_StiffnessDistrib != null && m_StiffnessDistrib.keys.Length > 0)
						{
							verletParticle.m_Stiffness = m_StiffnessDistrib.Evaluate(normalized) * verletParticle.m_Stiffness;
						}
					}
					verletParticle.m_Damping = Mathf.Clamp01(verletParticle.m_Damping);
					verletParticle.m_Elasticity = Mathf.Clamp01(verletParticle.m_Elasticity);
					verletParticle.m_Stiffness = Mathf.Clamp01(verletParticle.m_Stiffness);
				}
			}
		}

		//OK
		private void ResetBoneTransforms()
		{
			for (int i = 0; i < m_Particles.Count; i++)
			{
				VerletParticle verletParticle = m_Particles[i];
				if (verletParticle.m_BoneTransform != null)
				{
					verletParticle.m_BoneTransform.localPosition = verletParticle.m_InitLocalPosition;
					verletParticle.m_BoneTransform.localRotation = verletParticle.m_InitLocalRotation;
				}
			}
		}

		//OK
		private void ResetParticlesPosition()
		{
			for (int i = 0; i < m_Particles.Count; i++)
			{
				Vector3 position;
				VerletParticle verletParticle = m_Particles[i];
				if (verletParticle.m_BoneTransform != null)
				{
					position = verletParticle.m_BoneTransform.position;
				}
				else
				{
					position = m_Particles[verletParticle.m_ParentIndex].m_BoneTransform.TransformPoint(m_EndOffset);
				}
				Vector3 offset = position - m_posOffset;
				verletParticle.m_PrevPosition = offset;
				verletParticle.m_Position = offset;
				verletParticle.m_posOffset = m_posOffset;
			}
			m_ObjectPrevPosition = transform.position;
		}

		//OK
		private int CalDbUpdateCount(float dbTimeStep, float frameDeltaTime)
		{
			float delta = frameDeltaTime + m_lastFrameRemainTime;
			int updateCount = Mathf.FloorToInt(delta / dbTimeStep);
			m_lastFrameRemainTime = delta - (float)(updateCount * dbTimeStep);
			if (updateCount >= MaxDbUpdateCountOneFrame)
			{
				m_lastFrameRemainTime = 0f;
				return MaxDbUpdateCountOneFrame;
			}
			return updateCount;
		}

		//OK
		private void UpdateDynamicBones(float frameDeltaTime)
		{
			if (m_RootList != null)
			{
				m_ObjectScale = Mathf.Abs(transform.lossyScale.x);
				m_ObjectMove = transform.position - m_ObjectPrevPosition;
				m_ObjectPrevPosition = transform.position;
				if (m_UpdateMode == UpdateMode.OncePerFrame)
				{
					UpdateParticlesVerlet(frameDeltaTime, m_lastFrameDeltaTime);
					UpdateParticlesConstraints();
					m_ObjectMove = Vector3.zero;
					m_lastFrameDeltaTime = frameDeltaTime;
				}
				else
				{
					int updated = 1;
					float timeStep = frameDeltaTime;
					if (m_UpdateRate > 0)
					{
						timeStep = Time.timeScale / m_UpdateRate;
						updated = CalDbUpdateCount(timeStep, frameDeltaTime);
					}
					if (updated > 0)
					{
						for (int i = 0; i < updated; i++)
						{
							UpdateParticlesVerlet(timeStep, -1f);
							UpdateParticlesConstraints();
							m_ObjectMove = Vector3.zero;
						}
					}
				}
				ResetBoneTransforms();
				ApplyParticlesToTransforms();
			}
		}

		//OK
		private Vector3 GetWindForceSource()
		{
			Vector4 windForce = m_useDebugWind ? m_debugWind : JEINEHIGMIL.ACBENEJACCD();
			return new Vector3(windForce.x, 0f, windForce.z) * windForce.w;
		}

		//OK
		private void UpdateParticlesVerlet(float timeStep, float lastTimeStep = -1f)
		{
			if (m_RootList[0] == null)
			{
				Debug.LogWarning("m_RootList[0] is NULL!");
				return;
			}
			Vector3 normalized = m_Gravity.normalized;
			Vector3 force = (m_Gravity - (normalized * Mathf.Max(Vector3.Dot(m_RootList[0].TransformDirection(m_LocalGravity), normalized), 0f)) + m_Force) * m_ObjectScale;
			float dbtimeStep = timeStep;
			if (m_UpdateRate > 0f)
			{
				dbtimeStep = Time.timeScale / m_UpdateRate;
			}
			Vector3 windForceSource = GetWindForceSource();
			for (int i = 0; i < m_Particles.Count; i++)
			{
				Vector3 particleForce = force;
				VerletParticle verletParticle = m_Particles[i];
				if (m_AdditiveWindForce != null && m_AdditiveWindForce.m_windForceMultiplier > 0f)
				{
					float windAngleDiff = -1;
					float windCurveValue = -1;
					Vector3 windForce = m_AdditiveWindForce.GetWindForceForParticle(windForceSource, verletParticle, ref windAngleDiff, ref windCurveValue);
					if (windForce.magnitude > Mathf.Epsilon)
					{
						particleForce += windForce * m_ObjectScale;
					}
					if (verletParticle.m_BoneTransform != null && !string.IsNullOrEmpty(m_watchParticleName) && !string.IsNullOrEmpty(verletParticle.m_BoneName) && verletParticle.m_BoneName.Contains(m_watchParticleName))
					{
						verletParticle.m_angleDiff = windAngleDiff;
						verletParticle.m_appliedWindforce = particleForce;
						verletParticle.m_curveValue = windCurveValue;
					}
				}
				verletParticle.UpdateVerlet(m_ObjectMove, particleForce, timeStep, lastTimeStep, dbtimeStep);
			}
		}

		//OK
		private void UpdateFreezeTransformNormal()
		{
			m_FreezeTransformAxis = Vector3.zero;
			if (m_FreezeTransformRef != null)
			{
				switch (m_FreezeAxis)
				{
					case FreezeAxis.X:
						m_FreezeTransformAxis = m_FreezeTransformRef.right;
						break;
					case FreezeAxis.Y:
						m_FreezeTransformAxis = m_FreezeTransformRef.up;
						break;
					case FreezeAxis.Z:
						m_FreezeTransformAxis = m_FreezeTransformRef.forward;
						break;
				}
			}
		}

		//OK
		private void UpdateOldConstraint(ref Plane movePlane, bool keepShape)
		{
			for (int i = 0; i < m_Particles.Count; i++)
			{
				VerletParticle verletParticle = m_Particles[i];
				if (!verletParticle.isRoot())
				{
					VerletParticle parentVerletParticle = m_Particles[verletParticle.m_ParentIndex];
					Vector3 offset = (verletParticle.m_BoneTransform == null) ? parentVerletParticle.m_BoneTransform.localToWorldMatrix.MultiplyVector(verletParticle.m_EndOffset) : (parentVerletParticle.m_BoneTransform.position - verletParticle.m_BoneTransform.position);
					float boneLenToParent = offset.magnitude;
					Vector3 restPosition = Vector3.zero;
					if (keepShape)
					{
						restPosition = verletParticle.GetRestPos(parentVerletParticle);
						verletParticle.UpdateKeepShapeToParent(ref parentVerletParticle, m_Weight, boneLenToParent, restPosition);
					}
					if (m_FreezeAxis != FreezeAxis.None)
					{
						if (m_FreezeTransformRef != null)
						{
							UpdateFreezeTransformNormal();
							if (restPosition == Vector3.zero)
							{
								restPosition = verletParticle.GetRestPos(parentVerletParticle);
							}
							verletParticle.m_Position = verletParticle.m_Position - Vector3.Project(verletParticle.m_Position - restPosition, m_FreezeTransformAxis);
						}
						else
						{
							switch (m_FreezeAxis)
							{
								case FreezeAxis.X:
									movePlane.SetNormalAndPosition(parentVerletParticle.m_BoneTransform.right, parentVerletParticle.m_Position);
									break;
								case FreezeAxis.Y:
									movePlane.SetNormalAndPosition(parentVerletParticle.m_BoneTransform.up, parentVerletParticle.m_Position);
									break;
								case FreezeAxis.Z:
									movePlane.SetNormalAndPosition(parentVerletParticle.m_BoneTransform.forward, parentVerletParticle.m_Position);
									break;
							}
							verletParticle.m_Position = verletParticle.m_Position - movePlane.normal * movePlane.GetDistanceToPoint(verletParticle.m_Position);
						}
					}
					if (m_Colliders != null)
					{
						verletParticle.UpdateCollision(m_Colliders, m_ObjectScale, ref parentVerletParticle);
					}
					if (m_KeepLength)
					{
						verletParticle.UpdateKeepLengthToParent(ref parentVerletParticle, boneLenToParent);
					}
				}
			}
		}

		//OK
		private void UpdateParticlesConstraints()
		{
			Plane movePlane = new Plane();
			UpdateOldConstraint(ref movePlane, m_KeepShape);
		}

		private void SkipUpdateParticles() {} // 0x0000000181D0B780-0x0000000181D0BC70

		//OK
		private static Vector3 MirrorVector(Vector3 v, Vector3 axis)
		{
			return v - axis * (Vector3.Dot(v, axis) * 2f);
		}

		//OK
		private void ApplyParticlesToTransforms()
		{
			for (int i = 0; i < m_Particles.Count; i++)
			{
				VerletParticle verletParticle = m_Particles[i];
				if (!verletParticle.isRoot())
				{
					VerletParticle parentVerletParticle = m_Particles[verletParticle.m_ParentIndex];
					if (parentVerletParticle.m_BoneTransform.childCount <= 1)
					{
						Vector3 offset = verletParticle.m_BoneTransform != null ? verletParticle.m_BoneTransform.localPosition : verletParticle.m_EndOffset;
						parentVerletParticle.m_BoneTransform.rotation = Quaternion.FromToRotation(parentVerletParticle.m_BoneTransform.TransformDirection(offset), (verletParticle.m_Position - parentVerletParticle.m_Position).normalized) * parentVerletParticle.m_BoneTransform.rotation;
					}
					if (verletParticle.m_BoneTransform != null)
					{
						verletParticle.m_BoneTransform.position = verletParticle.m_Position + verletParticle.m_posOffset;
					}
				}
			}
		}

		//OK
		public void SetWeight(float w)
		{
			if (m_Weight != w)
			{
				if (w == 0f)
				{
					ResetBoneTransforms();
				}
				else if (m_Weight == 0f)
				{
					ResetParticlesPosition();
				}
				m_Weight = w;
			}
		}

		//OK
		public float GetWeight()
		{
			return m_Weight;
		}


		//OK
		private static Transform GetAttachPoint(Transform inRoot, string pointName)
		{
			while (inRoot != null)
			{
				MonoVisualEntityTool monoVisualEntityTool = inRoot.GetComponent<MonoVisualEntityTool>();
				if (monoVisualEntityTool != null)
				{
					return monoVisualEntityTool.GetTransformByName(pointName);
				}
				inRoot = inRoot.parent;
			}
			return null;
		}

		#region Multithreading is not supported now

		//private void UpdateOldConstraint_ComputeThread(ref Plane movePlane, bool keepShape) {} // 0x0000000181D0CA00-0x0000000181D0D110
		//private void UpdateParticlesConstraints_ComputeThread() {} // 0x0000000181D0E0B0-0x0000000181D0E130
		//private void UpdateDynamicBones_ComputeThread(float frameDeltaTime) {} // 0x0000000181D0C400-0x0000000181D0C5C0
		//private void SyncAnimatedBoneTransform_ComputeThread(ref MEJEPEFBEGP inComputeThreadBuff) {} // 0x0000000181D0BD20-0x0000000181D0C280
		////OK
		//public void InternalLateUpdate_ComputeThread(ref MEJEPEFBEGP inComputeThreadBuff, float dt)
		//{
		//	if (bMultiThread)
		//	{
		//		SyncAnimatedBoneTransform_ComputeThread(ref inComputeThreadBuff);
		//		if (m_UpdateMode != UpdateMode.OncePerFixedUpdate)
		//		{
		//			CheckDistance();
		//			if (NeedUpdateDynamicBone())
		//			{
		//				if (bRootIsValid)
		//				{
		//					if (m_UpdateMode == UpdateMode.OncePerFrame)
		//					{
		//						UpdateParticlesVerlet_ComputeThread(dt, m_lastFrameDeltaTime);
		//						UpdateParticlesConstraints_ComputeThread();
		//						m_ObjectMove = Vector3.zero;
		//						m_lastFrameDeltaTime = dt;
		//					}
		//					else
		//					{
		//						float dbTimeStep = dt;
		//						int updated = 1;
		//						if (m_UpdateRate > 0f)
		//						{
		//							dbTimeStep = Singleton<LPLJEHOHNJK>.Instance.HHPIFKPLFHF / m_UpdateRate;
		//							updated = CalDbUpdateCount(dbTimeStep, dt);
		//						}
		//						if (updated > 0)
		//						{
		//							for (int i = 0; i < updated; i++)
		//							{
		//								UpdateParticlesVerlet_ComputeThread(dbTimeStep, -1f);
		//								UpdateParticlesConstraints_ComputeThread();
		//								m_ObjectMove = Vector3.zero;
		//							}
		//						}
		//					}
		//				}
		//			}
		//		}
		//	}
		//}
		//private void UpdateParticlesVerlet_ComputeThread(float timeStep, float lastTimeStep = -1f) {} // 0x0000000181D0E1B0-0x0000000181D0E990
		//private void CreateComputeThreadTask() {} // 0x0000000181D089F0-0x0000000181D08C40
		//private void DestroyComputeThreadTask() {} // 0x0000000181D08CA0-0x0000000181D08CC0
		//private void IntitializeUnityThreadPendingChange() {} // 0x0000000181D0A690-0x0000000181D0A730
		//public ABPJCCGNGKC CollectBoneChangeInUnityThread() => default; // 0x0000000181D08740-0x0000000181D089F0
		//public ABPJCCGNGKC CollectBoneChangeInUnityThread(ABPJCCGNGKC inPendingChange) => default; // 0x0000000181D08440-0x0000000181D08740
		//public void ApplyParticlesToTransformsByComputeThreadResult(ref MEJEPEFBEGP inResult) {} // 0x0000000181D07630-0x0000000181D07C60

		#endregion
	}
}

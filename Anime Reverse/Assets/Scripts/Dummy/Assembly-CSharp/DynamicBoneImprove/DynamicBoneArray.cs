using Cinemachine.Utility;
using MoleMole;
using System;
using System.Collections;
using System.Collections.Generic;
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

		//2026.4.18 2:50 PM Fin.
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

        //2026.4.18 2:50 PM Fin.
        [ContextMenu("ToggleMultiThread")]
		private void ToggleMultiThread()
		{
			bMultiThread = !bMultiThread;
		}

        //2026.4.18 2:50 PM Fin.
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

		//2026.3.26 9:07 AM Fin.
		[ContextMenu("InitWindforce")]
		private void InitWindforceBones()
		{
			if (m_AdditiveWindForce.m_endBoneIndex != null)
			{
				m_AdditiveWindForce.m_endBoneIndex.Clear();
			}
			else
			{
				m_AdditiveWindForce.m_endBoneIndex = new List<int>();
			}
			if (m_AdditiveWindForce.m_anchorToBoneDir != null)
			{
				m_AdditiveWindForce.m_anchorToBoneDir.Clear();
			}
			else
			{
				m_AdditiveWindForce.m_anchorToBoneDir = new List<Vector3>();
			}
			for (int i = 0; i < m_RootList.Length; i++)
			{
				m_AdditiveWindForce.m_endBoneIndex.Add(-1);
				m_AdditiveWindForce.m_anchorToBoneDir.Add(Vector3.zero);
			}
			for (int i = 0; i < m_Particles.Count; i++)
			{
				Transform bone = m_Particles[i].m_BoneTransform;
				if (bone != null)
				{
					for (int j = 0; j < m_RootList.Length; j++)
					{
						if (m_RootList[j] != null && bone.IsChildOf(m_RootList[j]))
						{
							if (m_AdditiveWindForce.m_endBoneIndex[j] < 0 || m_Particles[i].m_BoneLength > m_Particles[m_AdditiveWindForce.m_endBoneIndex[j]].m_BoneLength)
							{
								m_AdditiveWindForce.m_endBoneIndex[j] = i;
							}
							break;
						}
					}
				}
			}
			Transform anchor = m_AdditiveWindForce.m_anchor;
			if (anchor != null)
			{
				for (int i = 0;  i < m_RootList.Length; i++)
				{
					if (m_AdditiveWindForce.m_endBoneIndex[i] >= 0 && m_RootList[i] != null)
					{
						m_AdditiveWindForce.m_anchorToBoneDir[i] = anchor.InverseTransformDirection(anchor.position.ProjectPointOnLineSegment(m_RootList[i].position, m_Particles[m_AdditiveWindForce.m_endBoneIndex[i]].m_BoneTransform.position) - anchor.position);
					}
				}
			}
		}

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

		//2026.3.26 9:31 AM Fin.
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

		//2026.3.26 9:29 AM Fin.
		private void RecursivelyAppendParticles(Transform b, int parentIndex, float parentBoneLength, int rootIndex)
		{
			if (b  == null)
			{
				AddNewParticle(parentIndex, parentBoneLength, rootIndex, null);
				return;
			}
			parentBoneLength = AddNewParticle(parentIndex, parentBoneLength, rootIndex, b);
			parentIndex = m_Particles.Count - 1;
			for (int i = 0; i < b.childCount; i++)
			{
				bool isExcluded = false;
				if (m_Exclusions != null)
				{
					for (int j = 0; j < m_Exclusions.Count ; ++j)
					{
						if (m_Exclusions[j] == b.GetChild(i))
						{
							isExcluded = true;
							break;
						}
					}
				}
				if (isExcluded)
				{
					if (m_EndLength > 0f || m_EndOffset != Vector3.zero)
					{
						RecursivelyAppendParticles(null, parentIndex, parentBoneLength, rootIndex);
					}
				}
				else
				{
					RecursivelyAppendParticles(b.GetChild(i), parentIndex, parentBoneLength, rootIndex);
				}
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

		//2026.4.04 9.03 PM Fin.
		private void UpdateWindForce()
		{
			if (m_AdditiveWindForce != null && m_AdditiveWindForce.OnUpdate())
			{
				if (m_AdditiveWindForce.m_isStationary && GetWindForceSource() != Vector3.zero)
				{
					UpdateParticleParameters(m_AdditiveWindForce.m_overrideDamping, m_AdditiveWindForce.m_overrideElasticity, m_AdditiveWindForce.m_overrideStiffness);
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

		//2026.4.04 8:26 PM Fin.
		private int CalDbUpdateCount(float dbTimeStep, float frameDeltaTime)
		{
			float delta = frameDeltaTime + m_lastFrameRemainTime;
			int updateCount = Mathf.FloorToInt(delta / dbTimeStep);
			m_lastFrameRemainTime = delta - (updateCount * dbTimeStep);
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

		#warning Incomplete... Address: 181D0E990
		private void UpdateParticlesVerlet(float timeStep, float lastTimeStep = -1f)
		{
			//if (m_RootList[0] == null)
			//{
			//	Debug.LogWarning("m_RootList[0] is NULL!");
			//	return;
			//}
			//Vector3 normalized = m_Gravity.normalized;
			//Vector3 force = (m_Gravity - (normalized * Mathf.Max(Vector3.Dot(m_RootList[0].TransformDirection(m_LocalGravity), normalized), 0f)) + m_Force) * m_ObjectScale;
			//float dbtimeStep = timeStep;
			//if (m_UpdateRate > 0f)
			//{
			//	dbtimeStep = Time.timeScale / m_UpdateRate;
			//}
			//Vector3 windForceSource = GetWindForceSource();
			//for (int i = 0; i < m_Particles.Count; i++)
			//{
			//	Vector3 particleForce = force;
			//	VerletParticle verletParticle = m_Particles[i];
			//	if (m_AdditiveWindForce != null && m_AdditiveWindForce.m_windForceMultiplier > 0f)
			//	{
			//		float windAngleDiff = -1;
			//		float windCurveValue = -1;
			//		Vector3 windForce = m_AdditiveWindForce.GetWindForceForParticle(windForceSource, verletParticle, ref windAngleDiff, ref windCurveValue);
			//		if (windForce.magnitude > Mathf.Epsilon)
			//		{
			//			particleForce += windForce * m_ObjectScale;
			//		}
			//		if (verletParticle.m_BoneTransform != null && !string.IsNullOrEmpty(m_watchParticleName) && !string.IsNullOrEmpty(verletParticle.m_BoneName) && verletParticle.m_BoneName.Contains(m_watchParticleName))
			//		{
			//			verletParticle.m_angleDiff = windAngleDiff;
			//			verletParticle.m_appliedWindforce = particleForce;
			//			verletParticle.m_curveValue = windCurveValue;
			//		}
			//	}
			//	verletParticle.UpdateVerlet(m_ObjectMove, particleForce, timeStep, lastTimeStep, dbtimeStep);
			//}

			Transform[] m_RootList; // rax
			UnityEngine.Object v6; // rdi
			__int64 v7; // xmm8_8
			float z; // r14d
			Vector3 v9; // rax
			__int64 v10; // xmm6_8
			float v11; // edi
			Transform[] v12; // rax
			Transform v13; // rdx
			float v14; // eax
			Vector3 v15; // rax
			__int64 v16; // xmm7_8
			float v17; // esi
			float v18; // xmm0_4
			float v19; // xmm0_4
			Vector3 v20; // rax
			__int64 v21; // xmm0_8
			Vector3 v22; // rax
			float v23; // ecx
			__int64 v24; // xmm0_8
			Vector3 v25; // rax
			float m_ObjectScale; // xmm3_4
			__int64 v27; // xmm0_8
			Vector3 v28; // rax
			float v29; // xmm9_4
			float v30; // r15d
			__int64 v31; // xmm8_8
			Vector3 WindForceSource; // rax
			int v33; // edi
			int v34; // esi
			__int64 v35; // xmm13_8
			float v36; // r12d
			List<VerletParticle> m_Particles; // rax
			DynamicBoneWindForce m_AdditiveWindForce; // rsi
			__int64 v39; // xmm6_8
			float v40; // r14d
			List<VerletParticle> v41; // rcx
			VerletParticle Item; // rax
			float magnitude_1; // xmm0_4
			__int64 v45; // xmm6_8
			float v46; // esi
			float v47; // xmm7_4
			Vector3 v48; // rax
			__int64 v49; // xmm0_8
			Vector3 v50; // rax
			List<VerletParticle> v51; // rcx
			VerletParticle v52; // rax
			string v53; // rsi
			String m_watchParticleName; // rsi
			List<VerletParticle> v55; // rcx
			VerletParticle v56; // rax
			String v57; // rsi
			List<VerletParticle> v58; // rcx
			VerletParticle v59; // rax
			String v60; // rax
			List<VerletParticle> v61; // rcx
			VerletParticle v62; // rax
			List<VerletParticle> v63; // rcx
			VerletParticle v64; // rax
			List<VerletParticle> v65; // rcx
			VerletParticle v66; // rax
			List<VerletParticle> v67; // rcx
			VerletParticle v68; // rax
			__int64 v69; // xmm0_8
			Vector3 v72; // [rsp+40h] [rbp-C0h] BYREF
			Vector3 v73; // [rsp+50h] [rbp-B0h] BYREF
			Vector3 v74; // [rsp+60h] [rbp-A0h] BYREF
			float v75; // [rsp+70h] [rbp-90h] BYREF
			Vector3 v76; // [rsp+78h] [rbp-88h] BYREF
			Vector3 v77; // [rsp+90h] [rbp-70h] BYREF
			Vector3 v78; // [rsp+A0h] [rbp-60h] BYREF
			Vector3 v79; // [rsp+B0h] [rbp-50h] BYREF
			float v83; // [rsp+1A0h] [rbp+A0h] BYREF

			v76.x = 0; v76.y = 0;
			v76.z = 0;
			m_RootList = this.m_RootList;
			v6 = m_RootList[0];
			if (v6 == null)
			{
				Debug.LogWarning("m_RootList[0] is NULL!");
				return;
			}
			v7.x = this.m_Gravity.x; v7.y = this.m_Gravity.y;
			z = this.m_Gravity.z;
			v9 = this.m_Gravity.normalized;
			v10.x = v9.x; v10.y = v9.y;
			v11 = v9.z;
			v12 = this.m_RootList;
			v13 = v12[0];
			v14 = this.m_LocalGravity.z;
			v73.x = this.m_LocalGravity.x; v73.y = this.m_LocalGravity.y;
			v73.z = v14;
			v15 = v13.TransformDirection(v73);
			v16.x = v15.x; v16.y = v15.y;
			v17 = v15.z;
			v73.x = v10.x; v73.y = v10.y;
			v73.z = v11;
			v72.x = v16.x; v72.y = v16.y;
			v72.z = v17;
			v18 = Vector3.Dot(v72, v73);
			v19 = Mathf.Max(v18, 0f);
			v72.x = v10.x; v72.y = v10.y;
			v72.z = v11;
			v20 = v72 * v19;
			v73.x = v7.x; v73.y = v7.y;
			v73.z = z;
			v21.x = v20.x; v21.y = v20.y;
			v20.x = v20.z;
			v72.x = v21.x; v72.y = v21.y;
			v72.z = v20.x;
			v22 = v73 - v72;
			v23 = this.m_Force.z;
			v72.x = this.m_Force.x; v72.y = this.m_Force.y;
			v24.x = v22.x; v24.y = v22.y;
			v22.x = v22.z;
			v72.z = v23;
			v73.x = v24.x; v73.y = v24.y;
			v73.z = v22.x;
			v25 = v73 + v72;
			m_ObjectScale = this.m_ObjectScale;
			v27.x = v25.x; v27.y = v25.y;
			v25.x = v25.z;
			v72.x = v27.x; v72.y = v27.y;
			v72.z = v25.x;
			v28 = v72 * m_ObjectScale;
			v29 = timeStep;
			v30 = v28.z;
			v31.x = v28.x; v31.y = v28.y;
			if (this.m_UpdateRate > 0f)
			{
				v29 = Time.timeScale / this.m_UpdateRate;
			}
			WindForceSource = GetWindForceSource();
			v33 = 0;
			v34 = 0;
			v35.x = WindForceSource.x; v35.y = WindForceSource.y;
			v36 = WindForceSource.z;
			m_Particles = this.m_Particles;
			while (v34 < m_Particles.Count)
			{
				m_AdditiveWindForce = (DynamicBoneWindForce)this.m_AdditiveWindForce;
				v39 = v31;
				v40 = v30;
				if (m_AdditiveWindForce != null && m_AdditiveWindForce.m_windForceMultiplier > 0f)
				{
					v41 = this.m_Particles;
					v83 = -1;
					v75 = -1;
					Item = v41[v33];
					v72.x = v35.x; v72.y = v35.y;
					v72.z = v36;
					v76 = m_AdditiveWindForce.GetWindForceForParticle(v72, (VerletParticle)Item, ref v83, ref v75);
					magnitude_1 = v76.magnitude;
					if (magnitude_1 > Mathf.Epsilon)
					{
						v45.x = v76.x; v45.y = v76.y;
						v46 = v76.z;
						v47 = this.m_ObjectScale;
						v73.x = v45.x; v73.y = v45.y;
						v73.z = v46;
						v48 = v73 * v47;
						v78.x = v31.x; v78.y = v31.y;
						v78.z = v30;
						v49.x = v48.x; v49.y = v48.y;
						v48.x = v48.z;
						v77.x = v49.x; v77.y = v49.y;
						v77.z = v48.x;
						v50 = v78 + v77;
						v39.x = v50.x; v39.y = v50.y;
						v40 = v50.z;
					}
					v51 = this.m_Particles;
					v52 = v51[v33];
					v53 = v52.m_BoneName;
					if (v53 != null)
					{
						m_watchParticleName = this.m_watchParticleName;
						if (!String.IsNullOrEmpty(m_watchParticleName))
						{
							v55 = this.m_Particles;
							v56 = v55[v33];
							v57 = v56.m_BoneName;
							if (!String.IsNullOrEmpty(v57))
							{
								v58 = this.m_Particles;
								v59 = v58[v33];
								v60 = v59.m_BoneName;
								if (v60.Contains(this.m_watchParticleName))
								{
									v61 = this.m_Particles;
									v62 = v61[v33];
									v62.m_angleDiff = v83;
									v63 = this.m_Particles;
									v64 = v63[v33];
									v64.m_appliedWindforce.x = v39.x; v64.m_appliedWindforce.y = v39.y;
									v64.m_appliedWindforce.z = v40;
									v65 = this.m_Particles;
									v66 = v65[v33];
									v66.m_curveValue = v75;
								}
							}
						}
					}
				}
				v67 = this.m_Particles;
				v68 = v67[v33];
				v69.x = this.m_ObjectMove.x; v69.y = this.m_ObjectMove.y;
				v74.z = this.m_ObjectMove.z;
				v79.x = v39.x; v79.y = v39.y;
				v79.z = v40;
				v74.x = v69.x; v74.y = v69.y;
				v68.UpdateVerlet(v74, v79, timeStep, lastTimeStep, v29);
				m_Particles = this.m_Particles;
				v34 = ++v33;
			}
		}

		//2026.4.04 8:52 PM Fin.
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

		//2026.4.04 8:54 PM Fin.
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

		//2026.4.04 8:54 PM Fin.
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

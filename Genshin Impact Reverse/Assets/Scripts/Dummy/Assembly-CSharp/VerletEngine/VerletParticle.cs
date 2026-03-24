using System;
using System.Collections.Generic;
using UnityEngine;

namespace VerletEngine
{
	public class VerletParticle
	{
		public ComputeThreadTransform cachedBoneTransform;

		public Matrix4x4 refPoseBoneWorldTransform;

		public Quaternion refPoseBoneWorldRotation;

		public int boneLineIndex = -1;

		public int childCount;

		public int rootListIndex = -1; 

		public bool bBoneTransformValid;

		private string _boneName = string.Empty;

		private Transform _boneTransform;

		public Vector3 m_InitLocalPosition = Vector3.zero;

		public Quaternion m_InitLocalRotation = Quaternion.identity;

		public Vector3 m_LastLocalPosition = Vector3.zero;

		public Quaternion m_LastLocalRotation = Quaternion.identity;

		public float m_RotateAngleY;

		public int m_RootIndex = -1;

		public int m_ParentIndex = -1;

		public float m_Damping;

		public float m_Elasticity;

		public float m_Stiffness;

		public float m_Inert;

		public float m_Radius;

		public float m_BoneLength;

		public Vector3 m_EndOffset = Vector3.zero;

		public Vector3 m_Position = Vector3.zero;

		public Vector3 m_PrevPosition = Vector3.zero;

		public Vector3 m_posOffset = Vector3.zero;

		public float m_angleDiff;

		public float m_curveValue;

		public Vector3 m_appliedWindforce;

		public float m_windForceMultiplier;
	
		//OK
		public string m_BoneName
		{
			get
			{
				return _boneName;
			}
		}

		//OK
		public Transform m_BoneTransform
		{
			get
			{
				return _boneTransform;
			}
			set
			{
				_boneTransform = value;
				_boneName = value == null ? null : value.name;
			}
		}

		//OK 100000%
		public void CacheDynamicBoneRootListIndex(Transform[] rootList)
		{
			rootListIndex = Array.IndexOf(rootList, _boneTransform);
			if (_boneTransform != null)
			{
				childCount = _boneTransform.childCount;
				bBoneTransformValid = true;
			}
			for (int i = 0; i < rootList.Length; i++)
			{
				Transform bone = rootList[i];
				if (bone != null)
				{
					if (_boneTransform != null && _boneTransform.IsChildOf(bone))
					{
						this.boneLineIndex = i;
						return;
					}
				}
			}
		}

		public void SetParams(float damping, float elasticity, float stiffness, float inert, float radius) {} // 0x000000018217BBB0-0x000000018217BBF0

		//OK
		public bool isRoot()
		{
			return m_ParentIndex < 0;
		}

		public void UpdateVerlet(Vector3 objectMove, Vector3 acceleration, float timeStep, float lastTimestep = -1f, float dbTimeStep = -1f)
		{
			if (m_ParentIndex >= 0)
			{
				m_Position = m_Position + (objectMove * m_Inert);
				m_PrevPosition = m_Position + (objectMove * m_Inert);
				if (lastTimestep > 0f)
				{
					m_Position = m_Position + acceleration * (dbTimeStep > 0f ? (dbTimeStep * dbTimeStep) : (timeStep * timeStep));
				}
				else
				{
					m_Position = m_Position + acceleration * timeStep * timeStep;
				}
			}
			else
			{
				m_PrevPosition = m_Position;
				m_Position = _boneTransform.position - m_posOffset;
			}
		}

		//OK
		public void UpdateKeepLengthToParent(ref VerletParticle parent, float boneLenToParent)
		{
			Vector3 offset = parent.m_Position - m_Position;
			float distance = offset.magnitude;
			if (distance > 0f)
			{
				m_Position = m_Position + (offset * ((distance - boneLenToParent) / distance));
			}
		}

		public void UpdateStiffnessToParent(ref VerletParticle parent, float weight, float boneLenToParent) {} // 0x000000018217C820-0x000000018217CBF0

		//OK
		public Vector3 GetRestPos(VerletParticle parent)
		{
			Matrix4x4 matrix = parent._boneTransform.localToWorldMatrix;
			matrix.SetRow(3, parent.m_Position);
			return matrix.MultiplyPoint3x4((_boneTransform == null) ? m_EndOffset : _boneTransform.localPosition);
		}

		///OK
		public void UpdateKeepShapeToParent(ref VerletParticle parent, float weight, float boneLenToParent, Vector3 restPos)
		{
			float lerp = Mathf.Lerp(1f, m_Stiffness, weight);
			if (lerp > 0f || m_Elasticity > 0f)
			{
				m_Position = m_Position + ((restPos - m_Position) * m_Elasticity);
				if (lerp > 0f)
				{
					Vector3 offset = restPos - m_Position;
					float distance = offset.magnitude;
					float maxdistance = ((1f - lerp) * boneLenToParent) + ((1f - lerp) * boneLenToParent);
					if (distance > maxdistance)
					{
						m_Position = m_Position + (offset * ((distance - maxdistance) / distance));
					}
				}
			}
		}

		public void UpdateCollision(List<DynamicBoneColliderBaseMMD> colliders, float objectScale, ref VerletParticle parent) {} // 0x000000018217BE90-0x000000018217BFC0
		public void UpdateCollisionRayCast(LayerMask colliderMask, float objectScale) {} // 0x000000018217BBF0-0x000000018217BE90

		//public Vector3 GetRestPos_ComputeThread(VerletParticle parent) => default; // 0x000000018217B870-0x000000018217B9E0
		//public void UpdateKeepShapeToParent_ComputeThread(ref VerletParticle parent, float weight, float boneLenToParent, Vector3 restPos) {} // 0x000000018217C1C0-0x000000018217C4F0
		//public void UpdateVerlet_ComputeThread(Vector3 objectMove, Vector3 acceleration, float timeStep, float lastTimestep = -1f /* Metadata: 0x0092E200 */, float dbTimeStep = -1f /* Metadata: 0x0092E204 */) {} // 0x000000018217CBF0-0x000000018217D110
	}
}

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

		//OK
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
						boneLineIndex = i;
						return;
					}
				}
			}
		}

		//OK
		public void SetParams(float damping, float elasticity, float stiffness, float inert, float radius)
		{
			m_Damping = damping;
			m_Radius = radius;
			m_Elasticity = elasticity;
			m_Stiffness = stiffness;
			m_Inert = inert;
		}

		//OK
		public bool isRoot()
		{
			return m_ParentIndex < 0;
		}

		#warning Incomplete... Address: 18217D110

		public void UpdateVerlet(Vector3 objectMove, Vector3 acceleration, float timeStep, float lastTimestep = -1f, float dbTimeStep = -1f)
		{
            Transform boneTransform; // rdx
            float v12; // eax
            Vector3 position; // rax
            __int64 v14; // xmm7_8
            float v15; // esi
            __int64 v16; // xmm6_8
            float v17; // ebx
            Vector3 v18; // rax
            __int64 v19; // xmm6_8
            float z; // esi
            float v21; // r15d
            __int64 v22; // xmm8_8
            Vector3 v23; // rax
            float m_Inert; // xmm3_4
            __int64 v25; // xmm11_8
            float v26; // r12d
            Vector3 v27; // rax
            __int64 v28; // xmm0_8
            __int64 v29; // xmm0_8
            Vector3 v30; // rax
            float v31; // ecx
            float v32; // xmm3_4
            float v33; // eax
            Vector3 v34; // rax
            float v35; // ebx
            __int64 v36; // xmm6_8
            __int64 v37; // xmm8_8
            float v38; // r14d
            float v39; // xmm9_4
            Vector3 v40; // rax
            __int64 v41; // xmm0_8
            Vector3 v42; // rax
            __int64 v43; // xmm0_8
            Vector3 v44; // rax
            __int64 v45; // xmm0_8
            Vector3 v46; // rax
            __int64 v47; // xmm0_8
            __int64 v48; // xmm8_8
            float v49; // r15d
            float m_Damping; // xmm6_4
            Vector3 v51; // rax
            __int64 v52; // xmm6_8
            float v53; // ebx
            Vector3 v54; // rax
            __int64 v55; // xmm0_8
            Vector3 v56; // rax
            __int64 v57; // xmm0_8
            Vector3 v58; // rax
            __int64 v59; // xmm0_8
            Vector3 v60; // [rsp+30h] [rbp-51h] BYREF
            Vector3 v61; // [rsp+40h] [rbp-41h] BYREF

            if (this.m_ParentIndex >= 0)
            {
                v19.x = this.m_Position.x; v19.y = this.m_Position.y;
                z = this.m_Position.z;
                v21 = this.m_PrevPosition.z;
                v22.x = this.m_PrevPosition.x; v22.y = this.m_PrevPosition.y;
                v60.z = z;
                v61.x = v22.x; v61.y = v22.y;
                v61.z = v21;
                v60.x = v19.x; v60.y = v19.y;
                v23 = v60 - v61;
                m_Inert = this.m_Inert;
                v61.x = objectMove.x; v61.y = objectMove.y;
                v25.x = v23.x; v25.y = v23.y;
                v26 = v23.z;
                v61.z = objectMove.z;
                v27 = v61 * m_Inert;
                v28.x = v27.x; v28.y = v27.y;
                v27.x = v27.z;
                v61.x = v28.x; v61.y = v28.y;
                v29.x = this.m_Position.x; v29.y = this.m_Position.y;
                v61.z = v27.x;
                v27.x = this.m_Position.z;
                v60.x = v29.x; v60.y = v29.y;
                v60.z = v27.x;
                v30 = v60 + v61;
                this.m_Position.x = v30.x; this.m_Position.y = v30.y;
                v31 = v30.z;
                this.m_Position.z = v31;
                this.m_PrevPosition = v30;
                if (lastTimestep <= 0f)
                {
                    v48.x = this.m_Position.x; v48.y = this.m_Position.y;
                    v49 = v31;
                    m_Damping = this.m_Damping;
                    v61.x = v25.x; v61.y = v25.y;
                    v61.z = v26;
                    v51 = v61 * (1f - m_Damping);
                    v61.x = acceleration.x; v61.y = acceleration.y;
                    v52.x = v51.x; v52.y = v51.y;
                    v53 = v51.z;
                    v61.z = acceleration.z;
                    v54 = v61 * timeStep;
                    v55.x = v54.x; v55.y = v54.y;
                    v54.x = v54.z;
                    v61.x = v55.x; v61.y = v55.y;
                    v61.z = v54.x;
                    v56 = v61 * timeStep;
                    v60.x = v52.x; v60.y = v52.y;
                    v60.z = v53;
                    v57.x = v56.x; v57.y = v56.y;
                    v56.x = v56.z;
                    v61.x = v57.x; v61.y = v57.y;
                    v61.z = v56.x;
                    v58 = v60 + v61;
                    v60.x = v48.x; v60.y = v48.y;
                    v60.z = v49;
                    v59.x = v58.x; v59.y = v58.y;
                    v58.x = v58.z;
                    v61.x = v59.x; v61.y = v59.y;
                    v61.z = v58.x;
                    v18 = v60 + v61;
                }
                else
                {
                    if (dbTimeStep > 0f)
                    {
                        v32 = dbTimeStep * dbTimeStep;
                    }
                    else
                    {
                        v32 = timeStep * timeStep;
                    }
                    v33 = acceleration.z;
                    v61.x = acceleration.x; v61.y = acceleration.y;
                    v61.z = v33;
                    v34 = v61 * v32;
                    v35 = v34.z;
                    v36.x = v34.x; v36.y = v34.y;
                    v37.x = this.m_Position.x; v37.y = this.m_Position.y;
                    v38 = this.m_Position.z;
                    v39 = this.m_Damping;
                    v61.x = v25.x; v61.y = v25.y;
                    v61.z = v26;
                    v40 = v61 * (1f - v39);
                    v41.x = v40.x; v41.y = v40.y;
                    v40.x = v40.z;
                    v61.x = v41.x; v61.y = v41.y;
                    v61.z = v40.x;
                    v42 = v61 * timeStep;
                    v43.x = v42.x; v43.y = v42.y;
                    v42.x = v42.z;
                    v61.x = v43.x; v61.y = v43.y;
                    v61.z = v42.x;
                    v44 = v61 / lastTimestep;
                    v61.x = v36.x; v61.y = v36.y;
                    v61.z = v35;
                    v45.x = v44.x; v45.y = v44.y;
                    v44.x = v44.z;
                    v60.x = v45.x; v60.y = v45.y;
                    v60.z = v44.x;
                    v46 = v60 + v61;
                    v60.x = v37.x; v60.y = v37.y;
                    v60.z = v38;
                    v47.x = v46.x; v47.y = v46.y;
                    v46.x = v46.z;
                    v61.x = v47.x; v61.y = v47.y;
                    v61.z = v46.x;
                    v18 = v60 + v61;
                }
            }
            else
            {
                boneTransform = this._boneTransform;
                v12 = this.m_Position.z;
                this.m_PrevPosition.x = this.m_Position.x; this.m_PrevPosition.y = this.m_Position.y;
                this.m_PrevPosition.z = v12;
                position = boneTransform.position;
                v14.x = this.m_posOffset.x; v14.y = this.m_posOffset.y;
                v15 = this.m_posOffset.z;
                v16.x = position.x; v16.y = position.y;
                v17 = position.z;
                v60.z = v15;
                v60.x = v14.x; v60.y = v14.y;
                v61.x = v16.x; v61.y = v16.y;
                v61.z = v17;
                v18 = v61 - v60;
            }
            this.m_Position.x = v18.x; this.m_Position.y = v18.y;
            this.m_Position.z = v18.z;
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

		#region Multithreading is not supported now

		//public Vector3 GetRestPos_ComputeThread(VerletParticle parent) => default; // 0x000000018217B870-0x000000018217B9E0
		//public void UpdateKeepShapeToParent_ComputeThread(ref VerletParticle parent, float weight, float boneLenToParent, Vector3 restPos) {} // 0x000000018217C1C0-0x000000018217C4F0
		//public void UpdateVerlet_ComputeThread(Vector3 objectMove, Vector3 acceleration, float timeStep, float lastTimestep = -1f /* Metadata: 0x0092E200 */, float dbTimeStep = -1f /* Metadata: 0x0092E204 */) {} // 0x000000018217CBF0-0x000000018217D110

		#endregion
	}
}

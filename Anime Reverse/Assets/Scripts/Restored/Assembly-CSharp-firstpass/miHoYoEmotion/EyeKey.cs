using UnityEngine;

namespace miHoYoEmotion
{
	[ExecuteInEditMode]
	public class EyeKey : MonoBehaviour
	{
		private const string LEFT_EYE_BONE_NAME = "+EyeBone L A01";

		private const string RIGHT_EYE_BONE_NAME = "+EyeBone R A01";

		private const string LEFT_EYE_BALL_NAME = "+EyeBone L A02";

		private const string RIGHT_EYE_BALL_NAME = "+EyeBone R A02";

		public Transform leftEyeBone;

		public Transform rightEyeBone;

		[Space]
		public Transform leftEyeBallBone;

		public Transform rightEyeBallBone;

		[Space]
		public Vector3 leftEyeRot = Vector3.zero;

		public Vector3 rightEyeRot = Vector3.zero;

		private Vector3 leftEyeScale = Vector3.one;

		private Vector3 rightEyeScale = Vector3.one;

		private Vector3 leftEyeBallRot = Vector3.zero;

		private Vector3 rightEyeBallRot = Vector3.zero;

		[Space]
		public Vector3 leftEyeBallScale = Vector3.one;

		public Vector3 rightEyeBallScale = Vector3.one;

		private int _leftEyeBoneHash = -1;

		private int _rightEyeBoneHash = -1;

		private int _leftEyeBallBoneHash = -1;

		private int _rightEyeBallBoneHash = -1;

		private Vector3 _originLeftEyePos;

		private Vector3 _originRightEyePos;

		private Vector3 _originLeftEyeRot;

		private Vector3 _originRightEyeRot;

		private Vector3 _originLeftEyeScale;

		private Vector3 _originRightEyeScale;

		private Vector3 _originLeftEyeBallPos;

		private Vector3 _originRightEyeBallPos;

		private Vector3 _originLeftEyeBallRot;

		private Vector3 _originRightEyeBallRot;

		private Vector3 _originLeftEyeBallScale;

		private Vector3 _originRightEyeBallScale;

		private void Start()
		{
		}

		private void Init()
		{
			CheckInit(leftEyeBone, ref _leftEyeBoneHash, ref _originLeftEyeRot, ref _originLeftEyeScale);
			CheckInit(rightEyeBone, ref _rightEyeBoneHash, ref _originRightEyeRot, ref _originRightEyeScale);
			CheckInit(leftEyeBallBone, ref _leftEyeBallBoneHash, ref _originLeftEyeBallRot, ref _originLeftEyeBallScale);
			CheckInit(rightEyeBallBone, ref _rightEyeBallBoneHash, ref _originRightEyeBallRot, ref _originRightEyeBallScale);
		}

		private void CheckInit(Transform bone, ref int hash, ref Vector3 originRot, ref Vector3 originScale)
		{
			if (bone == null)
			{
				hash = -1;
			}
			else if (hash != bone.GetHashCode())
			{
				hash = bone.GetHashCode();
				originRot = bone.localEulerAngles;
				originScale = bone.localScale;
			}
		}

		private void LateUpdate()
		{
			Init();
			Apply(leftEyeBone, ref _originLeftEyePos, ref _originLeftEyeRot, ref _originLeftEyeScale, ref leftEyeRot, ref leftEyeScale);
			Apply(rightEyeBone, ref _originRightEyePos, ref _originRightEyeRot, ref _originRightEyeScale, ref rightEyeRot, ref rightEyeScale);
			Apply(leftEyeBallBone, ref _originLeftEyeBallPos, ref _originLeftEyeBallRot, ref _originLeftEyeBallScale, ref leftEyeBallRot, ref leftEyeBallScale);
			Apply(rightEyeBallBone, ref _originRightEyeBallPos, ref _originRightEyeBallRot, ref _originRightEyeBallScale, ref rightEyeBallRot, ref rightEyeBallScale);
		}

		public void Reset()
		{
			CheckReset(ref leftEyeBone, _leftEyeBoneHash, _originLeftEyeRot);
			CheckReset(ref rightEyeBone, _rightEyeBoneHash, _originRightEyeRot);
			CheckReset(ref leftEyeBallBone, _leftEyeBallBoneHash, _originLeftEyeBallRot);
			CheckReset(ref rightEyeBallBone, _rightEyeBallBoneHash, _originRightEyeBallRot);
		}

		private void CheckReset(ref Transform bone, int hash, Vector3 rot)
		{
			if (bone != null && hash == bone.GetHashCode())
			{
				bone.localEulerAngles = rot;
			}
		}

		private void Apply(Transform bone, ref Vector3 originPos, ref Vector3 originRot, ref Vector3 originScale, ref Vector3 deltaRot, ref Vector3 deltaScale)
		{
			if (bone != null)
			{
				bone.localEulerAngles = originRot + deltaRot;
				bone.localScale = new Vector3(originScale.x * deltaScale.x, originScale.y * deltaScale.y, originScale.z * deltaScale.z);
			}
		}
	}
}

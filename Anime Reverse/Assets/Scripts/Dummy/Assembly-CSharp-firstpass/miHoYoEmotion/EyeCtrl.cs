using UnityEngine;

namespace miHoYoEmotion
{
	public class EyeCtrl : EmoMgrUser
	{
		public bool autoBlinkingEnabled;

		public BaseShape defaultBlinkShape;

		public float minimumBlinkGap = 2f;

		public float maximumBlinkGap = 5f;

		[SerializeField]
		private Transform _leftEyeLookAtBone;

		[SerializeField]
		private Transform _rightEyeLookAtBone;

		public Vector2 eyeRotationRangeX = new Vector2(0f, 0f);

		public Vector2 eyeRotationRangeY = new Vector2(0f, 0f);

		public bool targetEnabled;

		public Transform viewTarget;

		private float blinkTimer;

		private bool blinking;

		private Vector3 leftEuler;

		private Vector3 rightEuler;

		private Transform target;
	
		//OK
		public Transform LeftEyeLookAtBone 
		{ 
			get 
			{ 
				return _leftEyeLookAtBone; 
			} 
			set 
			{
				if (_leftEyeLookAtBone != value)
				{
					_leftEyeLookAtBone = value;
				}      
			} 
		}

		//OK
		public Transform RightEyeLookAtBone 
		{
			get
			{
				return _rightEyeLookAtBone;
			}
			set 
			{
				if (!_rightEyeLookAtBone != value)
				{
					_rightEyeLookAtBone = value;
				}
			} 
		}
	
		// Methods
		protected override void Start() {} // 0x00000001814EA710-0x00000001814EA8B0
		protected override void OnEnable() {} // 0x00000001814E7F00-0x00000001814E7F10

		//OK
		private void OnDestroy()
		{
			if (_emoAnim != null)
			{
				_emoAnim.UnregisterFinishHandler(new EmoTrack.EmoVoidHandler(BlinkFinish));
			}
		}

		private void LateUpdate() {} // 0x00000001814EA590-0x00000001814EA690

		//OK
		private void UpdateBlink()
		{
			if (autoBlinkingEnabled && !blinking)
			{
				if (blinkTimer <= 0.0)
				{
					Blink();
				}
				else if (_emoState.InState(EmoStateManager.EmoState.BLENDING))
				{
					blinkTimer = minimumBlinkGap;
				}
				else
				{
					blinkTimer -= Time.deltaTime;
				}
			}
		}

		//OK
		public void ToggleBlink(bool toggle)
		{
			if (_emoAnim != null)
			{
				_emoAnim.TogglePauseBlink(toggle);
			}
		}

		//OK
		private void Blink()
		{
			if (_emoAnim != null)
			{
				_emoAnim.ClearShapeOnly(1);
				BaseShape CurShape = _emoAnim.GetCurShape(0);
				if (CurShape != null)
				{
					_emoAnim.EnableShape(CurShape, 0f, 1);
					blinking = true;
					blinkTimer = Random.Range(minimumBlinkGap, maximumBlinkGap);
					SetState(EmoStateManager.EmoState.BLINKING);
				}
			}
		}

		//OK
		private void BlinkFinish()
		{
			blinking = false;
			blinkTimer = Random.Range(minimumBlinkGap, maximumBlinkGap);
			ClearState(EmoStateManager.EmoState.BLINKING);
		}

		private void UpdateLookTarget() {} // 0x00000001814EACA0-0x00000001814EAF40
		private void UpdateEyeTarget(Transform target, Transform eyeBone, Vector3 originEuler, out Vector3 deltaEulerRot) {
			deltaEulerRot = default;
		} // 0x00000001814EA9D0-0x00000001814EACA0
		private void ApplyEyeTarget(Transform leftEyeBone, Transform rightEyeBone, Vector3 leftOriginEuler, Vector3 rightOriginEuler, Vector3 leftDeltaRot, Vector3 rightDeltaRot) {} // 0x00000001814EA2F0-0x00000001814EA410
		private void CheckMinAngle(ref Vector3 euler) {} // 0x00000001814EA4F0-0x00000001814EA590
	}
}

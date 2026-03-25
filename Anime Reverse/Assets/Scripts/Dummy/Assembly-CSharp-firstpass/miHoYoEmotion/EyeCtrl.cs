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
	
		//OK
		protected override void Start()
		{
			UpdateManger();
			if (_leftEyeLookAtBone != null && _rightEyeLookAtBone != null)
			{
				leftEuler = _leftEyeLookAtBone.localEulerAngles;
				rightEuler = _rightEyeLookAtBone.localEulerAngles;
			}
			_emoAnim.UnregisterFinishHandler(new EmoTrack.EmoVoidHandler(BlinkFinish), 1);
			_emoAnim.RegisterFinishHandler(new EmoTrack.EmoVoidHandler(BlinkFinish), 1);
		}

		//OK
		protected override void OnEnable()
		{
			UpdateManger();
		}

		//OK
		private void OnDestroy()
		{
			if (_emoAnim != null)
			{
				_emoAnim.UnregisterFinishHandler(new EmoTrack.EmoVoidHandler(BlinkFinish), 1);
			}
		}

		//OK
		private void LateUpdate()
		{
			UpdateBlink();
			UpdateLookTarget();
		}

		//OK
		private void UpdateBlink()
		{
			if (autoBlinkingEnabled && !blinking)
			{
				if (blinkTimer <= 0f)
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

		//OK
		private void UpdateLookTarget()
		{
			target = viewTarget;
			if (targetEnabled && viewTarget != null && _leftEyeLookAtBone != null && _rightEyeLookAtBone != null)
			{
				UpdateEyeTarget(target, _leftEyeLookAtBone, leftEuler, out Vector3 leftDeltaRot);
				UpdateEyeTarget(target, _rightEyeLookAtBone, rightEuler, out Vector3 rightDeltaRot);
				ApplyEyeTarget(_leftEyeLookAtBone, _rightEyeLookAtBone, leftEuler, rightEuler, leftDeltaRot, rightDeltaRot);
			}
		}

		private void UpdateEyeTarget(Transform target, Transform eyeBone, Vector3 originEuler, out Vector3 deltaEulerRot) 
		{
			deltaEulerRot = default;
		} // 0x00000001814EA9D0-0x00000001814EACA0

		//OK
		private void ApplyEyeTarget(Transform leftEyeBone, Transform rightEyeBone, Vector3 leftOriginEuler, Vector3 rightOriginEuler, Vector3 leftDeltaRot, Vector3 rightDeltaRot)
		{
			if (rightDeltaRot.y * leftDeltaRot.y < 0f)
			{
				leftDeltaRot.y = 0f;
				rightDeltaRot.y = 0f;
			}
			leftEyeBone.localEulerAngles = new Vector3(leftDeltaRot.y + leftOriginEuler.x, leftOriginEuler.y, leftOriginEuler.z + leftDeltaRot.x);
			rightEyeBone.localEulerAngles = new Vector3(rightDeltaRot.y + rightOriginEuler.x, rightOriginEuler.y, rightOriginEuler.z + rightDeltaRot.x);
		}

		//OK
		private void CheckMinAngle(ref Vector3 euler)
		{
			float y = euler.y % 360f;
			float x = euler.x % 360f;
			if (y > 180f)
			{
				y -= 360f;
			}
			else if (y < -180f)
			{
				y += 360f;
			}
			if (x > 180f)
			{
				x -= 360f;
			}
			else if (x < -180f)
			{
				x += 360f;
			}
			euler.y = y;
			euler.x = x;
		}
	}
}

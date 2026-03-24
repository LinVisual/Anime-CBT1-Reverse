using UnityEngine;

namespace miHoYoEmotion
{
	public class EmoMgrUser : MonoBehaviour
	{
		[SerializeField]
		protected ElementManager.Type _type = ElementManager.Type.NONE;

		protected BaseEmoAnimation _emoAnim;

		protected EmoStateManager _emoState;

		//OK
		public ElementManager.Type type
		{
			get
			{
				return _type;
			}
		}

		//OK
		public BaseEmoAnimation emoAnim
		{
			get
			{
				return _emoAnim;
			}
		}

		//OK
		public ElementManager manager
		{
			get
			{
				return _emoAnim.manager;
			}
		}

		//OK
		public EmoStateManager emoState
		{
			get
			{
				return _emoState;
			}
		}
	
		//OK
		protected virtual void Start()
		{
			UpdateManger();
		}

		//OK
		public void UpdateManger()
		{
			ElementManager elementManager;
			if (_type == ElementManager.Type.NONE)
			{
				_emoAnim = null;
				return;
			}
			if (_type == ElementManager.Type.FRAME)
			{
				elementManager = GetComponent<FrameShapeManager>();
				if (elementManager == null)
				{
					_type = ElementManager.Type.NONE;
					Debug.LogWarning("There should be a FrameShapeManager standby!");
					return;
				}
			}
			else
			{
				elementManager = GetComponent<ClipShapeManager>();
				if (elementManager == null)
				{
					_type = ElementManager.Type.NONE;
					Debug.LogWarning("There should be a ClipShapeManager standby!");
					return;
				}
			}
			elementManager.InitEmoAnim();
			elementManager.InitStateMgr();
			_emoAnim = elementManager.emoAnim;
			_emoState = elementManager.stateMgr;
		}

		//OK
		protected virtual void OnEnable()
		{
			UpdateManger();
		}

		public void SetState(EmoStateManager.EmoState state) {} // 0x00000001814E7F10-0x00000001814E7FB0
		public void ClearState(EmoStateManager.EmoState state) {} // 0x00000001814E7DE0-0x00000001814E7EE0

		//OK
		public bool IsState(EmoStateManager.EmoState state)
		{
			return (_emoState != null) && _emoState.InState(state);
		}
	}
}

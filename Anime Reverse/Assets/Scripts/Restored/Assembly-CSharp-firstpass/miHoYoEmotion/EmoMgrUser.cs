using UnityEngine;

namespace miHoYoEmotion
{
	public class EmoMgrUser : MonoBehaviour
	{
		[SerializeField]
		protected ElementManager.Type _type = ElementManager.Type.NONE;

		protected BaseEmoAnimation _emoAnim;

		protected EmoStateManager _emoState;

		public ElementManager.Type type
		{
			get
			{
				return _type;
			}
		}

		public BaseEmoAnimation emoAnim
		{
			get
			{
				return _emoAnim;
			}
		}

		public ElementManager manager
		{
			get
			{
				return _emoAnim.manager;
			}
		}

		public EmoStateManager emoState
		{
			get
			{
				return _emoState;
			}
		}

		protected virtual void Start()
		{
			UpdateManger();
		}

		public void UpdateManger()
		{
			ElementManager elementManager = null;
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

		protected virtual void OnEnable()
		{
			UpdateManger();
		}

		public void SetState(EmoStateManager.EmoState state)
		{
			if (_emoState != null)
			{
				_emoState.SetState(state);
			}
		}

		public void ClearState(EmoStateManager.EmoState state)
		{
			if (_emoState != null)
			{
				_emoState.ClearState(state);
			}
		}

		public bool IsState(EmoStateManager.EmoState state)
		{
			return (_emoState != null) && _emoState.InState(state);
		}
	}
}

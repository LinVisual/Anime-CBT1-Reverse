using System.Collections.Generic;

namespace miHoYoEmotion
{
	public class EmoStateManager
	{
		private Dictionary<int, EmoTrack.EmoVoidHandler> _stateClearHandlerDic = new Dictionary<int, EmoTrack.EmoVoidHandler>();

		private Dictionary<int, bool> _stateDic = new Dictionary<int, bool>();

		public enum EmoState
		{
			INVALID = -1,
			BLENDING = 0,
			BLINKING = 1
		}
	
		public void SetState(EmoState state)
		{
			if (!_stateDic.ContainsKey((int)state))
			{
				_stateDic.Add((int)state, true);
			}
			else
			{
				_stateDic[(int)state] = true;
			}
		}

		public void ClearState(EmoState state)
		{
			if (_stateDic.ContainsKey((int)state) && _stateDic[(int)state])
			{
				_stateDic[(int)state] = false;
				CallStateClearHandler(state);
			}
		}

		public bool InState(EmoState state)
		{
			if (_stateDic.ContainsKey((int)state))
			{
				return _stateDic[(int)state];
			}
			return false;
		}

		public void SetStateClearHandler(EmoState state, EmoTrack.EmoVoidHandler handler)
		{
			if (!_stateClearHandlerDic.ContainsKey((int)state))
			{
				_stateClearHandlerDic.Add((int)state, null);
			}
			_stateClearHandlerDic[(int)state] = _stateClearHandlerDic[(int)state] += handler;
		}

		public void ClearStateClearHandler(EmoState state, EmoTrack.EmoVoidHandler handler)
		{
			if (!_stateClearHandlerDic.ContainsKey((int)state))
			{
				_stateClearHandlerDic.Add((int)state, null);
			}
			_stateClearHandlerDic[(int)state] = _stateClearHandlerDic[(int)state] -= handler;
		}

		private void CallStateClearHandler(EmoState state)
		{
			if (_stateClearHandlerDic.ContainsKey((int)state))
			{
				_stateClearHandlerDic[(int)state]?.Invoke();
			}
		}
	}
}

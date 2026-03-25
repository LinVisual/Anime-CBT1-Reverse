using System.Collections.Generic;

namespace miHoYoEmotion
{
	public class EmoStateManager
	{
		private Dictionary<int, EmoTrack.EmoVoidHandler> _stateClearHandlerDic;

		private Dictionary<int, bool> _stateDic;
	
		// Nested types
		public enum EmoState // TypeDefIndex: 6604
		{
			INVALID = -1,
			BLENDING = 0,
			BLINKING = 1
		}
	
		// Constructors
		public EmoStateManager() {} // 0x00000001814E8600-0x00000001814E8680
	
		//OK
		public void SetState(EmoState state)
		{
			if (!_stateDic.ContainsKey((int)state))
			{
				_stateDic.Add((int)state, true);
				return;
			}
			else
			{
				_stateDic[(int)state] = true;
			}
		}

		public void ClearState(EmoState state) {} // 0x00000001814E8310-0x00000001814E8410

		//OK
		public bool InState(EmoState state)
		{
			if (_stateDic.ContainsKey((int)state))
			{
				return _stateDic[(int)state];
			}
			return false;
		}

		public void SetStateClearHandler(EmoState state, EmoTrack.EmoVoidHandler handler) {} // 0x00000001814E8490-0x00000001814E8570
		public void ClearStateClearHandler(EmoState state, EmoTrack.EmoVoidHandler handler) {} // 0x00000001814E8230-0x00000001814E8310
		private void CallStateClearHandler(EmoState state) {} // 0x00000001814E81B0-0x00000001814E8230
	}
}

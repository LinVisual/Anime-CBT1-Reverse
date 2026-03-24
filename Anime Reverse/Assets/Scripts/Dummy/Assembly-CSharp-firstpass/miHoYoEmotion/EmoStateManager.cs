/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security;

// Image 19: Assembly-CSharp-firstpass.dll - Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5219-7968

namespace miHoYoEmotion
{
	public class EmoStateManager // TypeDefIndex: 6603
	{
		// Fields
		private Dictionary<int, EmoTrack.EmoVoidHandler> _stateClearHandlerDic; // 0x10
		private Dictionary<int, bool> _stateDic; // 0x18
	
		// Nested types
		public enum EmoState // TypeDefIndex: 6604
		{
			INVALID = -1,
			BLENDING = 0,
			BLINKING = 1
		}
	
		// Constructors
		public EmoStateManager() {} // 0x00000001814E8600-0x00000001814E8680
	
		// Methods
		public void SetState(EmoState state) {} // 0x00000001814E8570-0x00000001814E8600
		public void ClearState(EmoState state) {} // 0x00000001814E8310-0x00000001814E8410
		public bool InState(EmoState state) => default; // 0x00000001814E8410-0x00000001814E8490
		public void SetStateClearHandler(EmoState state, EmoTrack.EmoVoidHandler handler) {} // 0x00000001814E8490-0x00000001814E8570
		public void ClearStateClearHandler(EmoState state, EmoTrack.EmoVoidHandler handler) {} // 0x00000001814E8230-0x00000001814E8310
		private void CallStateClearHandler(EmoState state) {} // 0x00000001814E81B0-0x00000001814E8230
	}
}

/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security;
using UnityEngine;

// Image 19: Assembly-CSharp-firstpass.dll - Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5219-7968

namespace motion4hi
{
	[Serializable]
	public struct AnimationPhase // TypeDefIndex: 6926
	{
		// Fields
		public float _time; // 0x00
		public AnimationPhaseType _type; // 0x04
		public AnimationPhaseBlend _blend; // 0x08
		public int _customData; // 0x0C
		public Vector3 _offPos; // 0x10
		public Vector3 _motionPos; // 0x1C
		public List<string> _extraTrajName; // 0x28
		public List<Vector3> _extraTrajPos; // 0x30
	
		// Methods
		public Vector3 GetExtraTrajPos(string key) => default; // 0x0000000180C6BFB0-0x0000000180C6C130
	}
}

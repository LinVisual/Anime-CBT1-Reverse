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

namespace miHoYoEmotion
{
	[Serializable]
	public class BaseShape : ISerializationCallbackReceiver // TypeDefIndex: 6630
	{
		// Fields
		[SerializeField] // 0x00000001818193F0-0x0000000181819400
		public string name; // 0x10
		[SerializeField] // 0x00000001818193F0-0x0000000181819400
		public List<string> elements; // 0x18
	
		// Constructors
		public BaseShape() {} // 0x00000001814E0100-0x00000001814E0160
	
		// Methods
		public virtual string GetElementName() => default; // 0x00000001814E0020-0x00000001814E0090
		public void OnBeforeSerialize() {} // 0x00000001802CB650-0x00000001802CB660
		public void OnAfterDeserialize() {} // 0x00000001814E0090-0x00000001814E0100
	}
}

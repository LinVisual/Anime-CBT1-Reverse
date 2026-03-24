/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security;
using UnityEngine;

// Image 19: Assembly-CSharp-firstpass.dll - Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5219-7968

namespace miHoYoEmotion
{
	[Serializable]
	public class FrameShapeElement : ShapeElement, ISerializationCallbackReceiver // TypeDefIndex: 6637
	{
		// Fields
		[SerializeField] // 0x00000001818193F0-0x0000000181819400
		public TYPE type; // 0x18
		[SerializeField] // 0x00000001818193F0-0x0000000181819400
		public string propertyName; // 0x20
		[SerializeField] // 0x00000001818193F0-0x0000000181819400
		public float frameRate; // 0x28
		[SerializeField] // 0x00000001818193F0-0x0000000181819400
		public Texture2D[] mainFrames; // 0x30
		[SerializeField] // 0x00000001818193F0-0x0000000181819400
		public Texture2D[] postFrames; // 0x38
		[SerializeField] // 0x00000001818193F0-0x0000000181819400
		public Texture2D[] blinkFrames; // 0x40
	
		// Properties
		public override float duration { get => default; } // 0x00000001814EE060-0x00000001814EE090 
		public override float postDuration { get => default; } // 0x00000001814EE090-0x00000001814EE0C0 
		public override float blinkDuration { get => default; } // 0x00000001814EE030-0x00000001814EE060 
	
		// Nested types
		public enum TYPE // TypeDefIndex: 6638
		{
			INVALID = -1,
			MOUTH = 0,
			EYE_LEFT = 1,
			EYE_RIGHT = 2
		}
	
		// Constructors
		public FrameShapeElement() {} // 0x00000001814EDFE0-0x00000001814EE030
	
		// Methods
		public void OnBeforeSerialize() {} // 0x00000001802CB650-0x00000001802CB660
		public void OnAfterDeserialize() {} // 0x00000001814EDF80-0x00000001814EDFE0
	}
}

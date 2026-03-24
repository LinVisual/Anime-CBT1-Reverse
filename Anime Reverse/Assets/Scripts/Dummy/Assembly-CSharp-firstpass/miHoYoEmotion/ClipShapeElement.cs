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
	public class ClipShapeElement : ShapeElement // TypeDefIndex: 6633
	{
		// Fields
		public AnimationClip mainClip; // 0x18
		public ClipShapeCurveGrp mainCurveGrp; // 0x20
		public AnimationClip postClip; // 0x28
		public ClipShapeCurveGrp postCurveGrp; // 0x30
		public AnimationClip blinkClip; // 0x38
		public ClipShapeCurveGrp blinkCurveGrp; // 0x40
		[Space] // 0x0000000181822DF0-0x0000000181822E00
		public float postBlendTime; // 0x48
		public bool isPost; // 0x4C
		public string[] noPost; // 0x50
		public bool isToFinal; // 0x58
		public string[] toFinal; // 0x60
	
		// Properties
		public override float duration { get => default; } // 0x00000001814E3C60-0x00000001814E3CF0 
		public override float postDuration { get => default; } // 0x00000001814E3CF0-0x00000001814E3D90 
	
		// Constructors
		public ClipShapeElement() {} // 0x00000001814E3C40-0x00000001814E3C60
	}
}

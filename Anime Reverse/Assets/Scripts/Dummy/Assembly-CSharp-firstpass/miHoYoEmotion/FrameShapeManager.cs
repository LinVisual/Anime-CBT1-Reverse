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
	public class FrameShapeManager : ElementManager // TypeDefIndex: 6600
	{
		// Fields
		[SerializeField] // 0x00000001818193F0-0x0000000181819400
		private FrameShapeRuntime[] _phonemeShapeRuntimes; // 0x48
		[SerializeField] // 0x00000001818193F0-0x0000000181819400
		private FrameShapeRuntime[] _emotionShapeRuntimes; // 0x50
		protected FrameShapeData _frameShapeData; // 0x58
	
		// Nested types
		[Serializable]
		public class FrameBinding // TypeDefIndex: 6601
		{
			// Fields
			[SerializeField] // 0x00000001818193F0-0x0000000181819400
			public Material templateMat; // 0x10
			[SerializeField] // 0x00000001818193F0-0x0000000181819400
			public Renderer bindingRender; // 0x18
			[SerializeField] // 0x00000001818193F0-0x0000000181819400
			public int propertyID; // 0x20
			[SerializeField] // 0x00000001818193F0-0x0000000181819400
			public int matIndex; // 0x24
			private Material _runtimeMat; // 0x28
	
			// Constructors
			public FrameBinding() {} // 0x00000001802CB2E0-0x00000001802CB2F0
	
			// Methods
			public void Apply(Texture2D frame, Vector2 offset, Vector2 scale) {} // 0x00000001814EB9A0-0x00000001814EBB70
		}
	
		[Serializable]
		public class FrameShapeRuntime : ElementManager.BaseShapeRuntime // TypeDefIndex: 6602
		{
			// Fields
			[SerializeField] // 0x00000001818193F0-0x0000000181819400
			public FrameBinding binding; // 0x18
			[SerializeField] // 0x00000001818193F0-0x0000000181819400
			public Vector2 offset; // 0x20
			[SerializeField] // 0x00000001818193F0-0x0000000181819400
			public Vector2 scale; // 0x28
	
			// Constructors
			public FrameShapeRuntime() {} // 0x00000001814EE450-0x00000001814EE4F0
	
			// Methods
			public void Apply(Texture2D frame) {} // 0x00000001814EE3F0-0x00000001814EE450
		}
	
		// Constructors
		public FrameShapeManager() {} // 0x00000001814E7D80-0x00000001814E7DE0
	
		// Methods
		protected override void Start() {} // 0x00000001814EE140-0x00000001814EE180
		protected override void OnEnable() {} // 0x00000001814EE140-0x00000001814EE180
		public override void InitEmoAnim() {} // 0x00000001814EE0C0-0x00000001814EE140
		public void ForceUpdateShapeRuntime() {} // 0x00000001804D39D0-0x00000001804D39F0
		public override void UpdateShapeData() {} // 0x00000001814EE180-0x00000001814EE2A0
		protected override void UpdateShapeRuntime() {} // 0x00000001814EE2A0-0x00000001814EE3F0
	}
}

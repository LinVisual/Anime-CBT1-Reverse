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
	public class ClipEmoTrack : EmoTrack // TypeDefIndex: 6577
	{
		// Fields
		private string _preClip; // 0x50
		private string _curClip; // 0x58
		protected List<AnimationCurve> _animCurves; // 0x60
		protected List<ClipShapeManager.CurveBinding> _curveBindings; // 0x68
		protected List<float> _curveValues; // 0x70
		protected Dictionary<string, Dictionary<string, int>> _pathProp2IndexDic; // 0x78
		private ClipShapeManager _clipManager; // 0x80
	
		// Nested types
		public struct ClipCell // TypeDefIndex: 6578
		{
			// Fields
			public ClipShapeElement element; // 0x00
			public ClipShapeManager.ClipShapeRuntime shapeRuntime; // 0x08
	
			// Properties
			public bool IsMainClipValid { get => default; } // 0x00000001814E0910-0x00000001814E09C0 
			public float MainClipDuration { get => default; } // 0x00000001814E0B20-0x00000001814E0B50 
			public bool IsMainCurveValid { get => default; } // 0x00000001814E09C0-0x00000001814E0A40 
			public int MainCurveCnt { get => default; } // 0x00000001814E0B50-0x00000001814E0B80 
			public bool IsPostClipValid { get => default; } // 0x00000001814E0A40-0x00000001814E0AF0 
			public float PostClipDuration { get => default; } // 0x00000001814E0B80-0x00000001814E0BB0 
			public bool IsPostCurveValid { get => default; } // 0x00000001814E0AF0-0x00000001814E0B00 
			public int PostCurveCnt { get => default; } // 0x00000001814E0BB0-0x00000001814E0C00 
			public bool IsBlinkClipValid { get => default; } // 0x00000001814E07E0-0x00000001814E0890 
			public float BlinkClipDuration { get => default; } // 0x00000001814E0710-0x00000001814E0740 
			public bool IsBlinkCurveValid { get => default; } // 0x00000001814E0890-0x00000001814E0910 
			public int BlinkCurveCnt { get => default; } // 0x00000001814E0740-0x00000001814E07E0 
			public bool IsValid { get => default; } // 0x00000001814E0B00-0x00000001814E0B20 
	
			// Methods
			public ClipShapeCurveCell GetMainCurve(int index) => default; // 0x00000001814E0510-0x00000001814E0620
			public ClipShapeManager.CurveBinding GetMainBinding(int index) => default; // 0x00000001814E0490-0x00000001814E0510
			public ClipShapeCurveCell GetPostCurve(int index) => default; // 0x00000001814E06A0-0x00000001814E0710
			public ClipShapeManager.CurveBinding GetPostBinding(int index) => default; // 0x00000001814E0620-0x00000001814E06A0
			public ClipShapeCurveCell GetBlinkCurve(int index) => default; // 0x00000001814E0350-0x00000001814E0490
			public ClipShapeManager.CurveBinding GetBlinkBinding(int index) => default; // 0x00000001814E0340-0x00000001814E0350
		}
	
		// Constructors
		public ClipEmoTrack() {} // 0x00000001814E3460-0x00000001814E3570
	
		// Methods
		public override void Init(ElementManager manager) {} // 0x00000001814E2450-0x00000001814E24F0
		private int GetIndex(string path, string prop) => default; // 0x00000001814E2390-0x00000001814E2450
		private int AddIndex(string path, string prop, int index) => default; // 0x00000001814E1300-0x00000001814E1420
		protected ClipCell GetCell(string name) => default; // 0x00000001814E2300-0x00000001814E2390
		private bool IsPost(ref ClipCell fromCell, ref ClipCell toCell) => default; // 0x00000001814E24F0-0x00000001814E2650
		private bool IsToFinal(ref ClipCell fromCell, ref ClipCell toCell) => default; // 0x00000001814E26A0-0x00000001814E27F0
		public override void PlayDefault(BaseShape shape, string postToPlay = "" /* Metadata: 0x00920CCB */) {} // 0x00000001814E2DD0-0x00000001814E31D0
		public override void EnableShape(BaseShape shape, float startTime = 0f /* Metadata: 0x00920CCF */) {} // 0x00000001814E1FD0-0x00000001814E2300
		protected void BuildPreCurve(ref ClipCell preCell, ref ClipCell curCell, out float postTime, float defaultPostTime = 0.12f /* Metadata: 0x00920CD3 */) {
			postTime = default;
		} // 0x00000001814E1560-0x00000001814E1C40
		protected void MergeCurCurve(ref ClipCell preCell, ref ClipCell curCell, float postTime = 0.12f /* Metadata: 0x00920CD7 */) {} // 0x00000001814E27F0-0x00000001814E2940
		protected void MergeCurve(ClipShapeCurveCell curveCell, ClipShapeManager.CurveBinding binding, float postTime = 0.12f /* Metadata: 0x00920CDB */, bool isToFinal = false /* Metadata: 0x00920CDF */, bool clearPrecurve = true /* Metadata: 0x00920CE0 */) {} // 0x00000001814E2940-0x00000001814E2BB0
		public override void ClearShape() {} // 0x00000001814E1DA0-0x00000001814E1FD0
		protected virtual void ClearInternal() {} // 0x00000001814E1CA0-0x00000001814E1D10
		protected virtual void ClearCurve() {} // 0x00000001814E1C40-0x00000001814E1CA0
		public override void ClearShapeOnly() {} // 0x00000001814E1D10-0x00000001814E1DA0
		public override void PlayBakedSequence(SequenceBakeData.BakeData bakeData) {} // 0x00000001814E2BB0-0x00000001814E2DD0
		public override void StopSequence() {} // 0x00000001814E3220-0x00000001814E3240
		protected virtual void PreClearInternal() {} // 0x00000001814E31D0-0x00000001814E3220
		protected virtual bool IsRunning() => default; // 0x00000001814E2650-0x00000001814E26A0
		protected virtual void UpdateCurveValue() {} // 0x00000001814E3240-0x00000001814E3390
		public override void Update(float deltaTime) {} // 0x00000001814E3390-0x00000001814E3460
		public override void Apply() {} // 0x00000001814E1420-0x00000001814E1560
	}
}

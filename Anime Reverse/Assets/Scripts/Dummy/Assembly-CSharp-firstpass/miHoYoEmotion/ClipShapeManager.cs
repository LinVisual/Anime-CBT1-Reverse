using System;
using System.Collections.Generic;
using UnityEngine;

namespace miHoYoEmotion
{
	[RequireComponent(typeof(EyeKey))]
	public class ClipShapeManager : ElementManager // TypeDefIndex: 6585
	{
		// Fields
		[SerializeField] // 0x00000001818193F0-0x0000000181819400
		public List<CurveBinding> currModelBindingList; // 0x48
		[SerializeField] // 0x00000001818193F0-0x0000000181819400
		private ClipShapeRuntime[] _phonemeShapeRuntimes; // 0x50
		[SerializeField] // 0x00000001818193F0-0x0000000181819400
		private ClipShapeRuntime[] _emotionShapeRuntimes; // 0x58
		protected ClipShapeData _clipShapeData; // 0x60
		protected ClipShapeData _specialClipShapeData; // 0x68
	
		// Properties
		public ClipShapeRuntime[] PhonemeShapeRuntimes { get => default; } // 0x00000001802E9150-0x00000001802E9160 
		public ClipShapeRuntime[] EmotionShapeRuntimes { get => default; } // 0x00000001804C5C70-0x00000001804C5C80 
		public ClipShapeData SpecialClipShapeData { get => default; } // 0x00000001804C5C90-0x00000001804C5CA0 
	
		// Nested types
		[Serializable]
		public class CurveBinding // TypeDefIndex: 6586
		{
			// Fields
			public static readonly Dictionary<string, int> PROP_NAME_2_PROP_ID; // 0x00
			public static readonly Dictionary<int, string> PROP_ID_2_PROP_NAME; // 0x08
			public BindingType bindingType; // 0x10
			public Transform bindingTrans; // 0x18
			public Renderer bindingRender; // 0x20
			public EyeKey bindingEyeKey; // 0x28
			public int propertyID; // 0x30
			public float originValue; // 0x34
			private static Vector3 _tempEuler; // 0x10
			private static Vector3 _tempScale; // 0x1C
			private MaterialPropertyBlock _prop; // 0x38
			private int _propNameID; // 0x40
	
			// Nested types
			public enum BindingType // TypeDefIndex: 6587
			{
				INVALID = -1,
				BLEND_SHAPE = 0,
				TRANS_POS_X = 1,
				TRANS_POS_Y = 2,
				TRANS_POS_Z = 3,
				TRANS_EULER_X = 4,
				TRANS_EULER_Y = 5,
				TRANS_EULER_Z = 6,
				TRANS_SCALE_X = 7,
				TRANS_SCALE_Y = 8,
				TRANS_SCALE_Z = 9,
				MAT_FLOAT = 10,
				EYE_LEFT_POS_X = 11,
				EYE_LEFT_POS_Y = 12,
				EYE_LEFT_POS_Z = 13,
				EYE_RIGHT_POS_X = 14,
				EYE_RIGHT_POS_Y = 15,
				EYE_RIGHT_POS_Z = 16,
				EYE_LEFT_ROT_X = 17,
				EYE_LEFT_ROT_Y = 18,
				EYE_LEFT_ROT_Z = 19,
				EYE_RIGHT_ROT_X = 20,
				EYE_RIGHT_ROT_Y = 21,
				EYE_RIGHT_ROT_Z = 22,
				EYE_LEFT_SCALE_X = 23,
				EYE_LEFT_SCALE_Y = 24,
				EYE_LEFT_SCALE_Z = 25,
				EYE_RIGHT_SCALE_X = 26,
				EYE_RIGHT_SCALE_Y = 27,
				EYE_RIGHT_SCALE_Z = 28,
				EYE_BALL_LEFT_POS_X = 29,
				EYE_BALL_LEFT_POS_Y = 30,
				EYE_BALL_LEFT_POS_Z = 31,
				EYE_BALL_RIGHT_POS_X = 32,
				EYE_BALL_RIGHT_POS_Y = 33,
				EYE_BALL_RIGHT_POS_Z = 34,
				EYE_BALL_LEFT_ROT_X = 35,
				EYE_BALL_LEFT_ROT_Y = 36,
				EYE_BALL_LEFT_ROT_Z = 37,
				EYE_BALL_RIGHT_ROT_X = 38,
				EYE_BALL_RIGHT_ROT_Y = 39,
				EYE_BALL_RIGHT_ROT_Z = 40,
				EYE_BALL_LEFT_SCALE_X = 41,
				EYE_BALL_LEFT_SCALE_Y = 42,
				EYE_BALL_LEFT_SCALE_Z = 43,
				EYE_BALL_RIGHT_SCALE_X = 44,
				EYE_BALL_RIGHT_SCALE_Y = 45,
				EYE_BALL_RIGHT_SCALE_Z = 46,
				GO_ACTIVE = 47
			}
	
			// Constructors
			public CurveBinding() {} // 0x00000001814E6420-0x00000001814E6430
			static CurveBinding() {} // 0x00000001814E62D0-0x00000001814E6420
	
			// Methods
			public bool Equals(CurveBinding binding) => default; // 0x00000001814E5920-0x00000001814E5A60
			public void Apply(float value) {} // 0x00000001814E4F90-0x00000001814E5920
			public float GetValue() => default; // 0x00000001814E5A60-0x00000001814E62D0
			public float GetOriginValue() => default; // 0x00000001807986F0-0x0000000180798700
		}
	
		[Serializable]
		public class CurveBindingGrp // TypeDefIndex: 6588
		{
			// Fields
			[SerializeField] // 0x00000001818193F0-0x0000000181819400
			public List<int> curveBindings; // 0x10
			[SerializeField] // 0x00000001818193F0-0x0000000181819400
			public ClipShapeManager clipShapeManager; // 0x18
			private Dictionary<string, Dictionary<string, int>> _pathProp2IndexDic; // 0x20
	
			// Constructors
			public CurveBindingGrp() {} // 0x00000001814E4F10-0x00000001814E4F90
	
			// Methods
			public CurveBinding GetCurveBinding(int indexOfIndex) => default; // 0x00000001814E4B20-0x00000001814E4BE0
			public void PutCurveBinding(CurveBinding binding) {} // 0x00000001814E4CA0-0x00000001814E4E00
			public int GetIndex(string path, string prop) => default; // 0x00000001814E4BE0-0x00000001814E4CA0
			private int AddIndex(string path, string prop, int index) => default; // 0x00000001814E4A00-0x00000001814E4B20
			public void UpdateRuntimeIndex(ClipShapeCurveGrp shapeCurveGrp) {} // 0x00000001814E4E00-0x00000001814E4F10
		}
	
		[Serializable]
		public class ClipShapeRuntime : ElementManager.BaseShapeRuntime // TypeDefIndex: 6590
		{
			// Fields
			public CurveBindingGrp mainBindingGrp; // 0x18
			public CurveBindingGrp postBindingGrp; // 0x20
			public CurveBindingGrp blinkBindingGrp; // 0x28
	
			// Constructors
			public ClipShapeRuntime() {} // 0x00000001802CB2E0-0x00000001802CB2F0
	
			// Methods
			public void UpdateRuntimeIndex(ClipShapeElement shapeElement) {} // 0x00000001814E4920-0x00000001814E4990
		}
	
		// Constructors
		public ClipShapeManager() {} // 0x00000001814E4880-0x00000001814E4920
	
		// Methods
		public void ResetBlendShape() {} // 0x00000001814E4040-0x00000001814E4130
		protected override void Start() {} // 0x000000018110CB20-0x000000018110CB40
		protected override void OnEnable() {} // 0x000000018110CB20-0x000000018110CB40

		//OK
		public override void InitEmoAnim()
		{
			if (_emoAnim == null)
			{
				_emoAnim = new ClipEmoAnimation();
				_emoAnim.Init(this);
			}
		}

		public override void UpdateShapeData() {} // 0x00000001814E4560-0x00000001814E4730
		protected override void UpdateShapeRuntime() {} // 0x00000001814E4730-0x00000001814E4880
		private void UpdateRuntimeIndex() {} // 0x00000001814E4130-0x00000001814E4560
		public CurveBinding GetCurveBindingByBakedClipBinding(SequenceClipBakeData.ClipBinding clipBinding, ClipShapeCurveCell curveCell) => default; // 0x00000001814E3D90-0x00000001814E3FC0
	}
}

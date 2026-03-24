using UnityEngine;
using System;

namespace miHoYoEmotion
{
	public class SequenceClipBakeData : SequenceBakeData
	{
		[SerializeField]
		private BakeData _phonemeBakeData;

		[SerializeField]
		private BakeData _emotionBakeData;
	
		//OK
		public override SequenceBakeData.BakeData phonemeBakeData
		{
			get
			{
				return _phonemeBakeData;
			}
			set
			{
				_phonemeBakeData = value as BakeData;
			}
		}

		//OK
		public override SequenceBakeData.BakeData emotionBakeData
		{
			get
			{
				return _emotionBakeData;
			}
			set
			{
				_emotionBakeData = value as BakeData;
			}
		}
	
		// Nested types
		[Serializable]
		public class ClipPathProp : ISerializationCallbackReceiver // TypeDefIndex: 6619
		{
			// Fields
			public string path; // 0x10
			public string prop; // 0x18
	
			// Constructors
			public ClipPathProp() {} // 0x00000001802CB2E0-0x00000001802CB2F0
	
			// Methods
			public void OnBeforeSerialize() {} // 0x00000001802CB650-0x00000001802CB660
			public void OnAfterDeserialize() {} // 0x00000001814E3570-0x00000001814E35F0
		}
	
		[Serializable]
		public class ClipBinding : ISerializationCallbackReceiver // TypeDefIndex: 6620
		{
			// Fields
			public string elementName; // 0x10
			public Type grpType; // 0x18
	
			// Nested types
			public enum Type // TypeDefIndex: 6621
			{
				INVALID = -1,
				MAIN = 0,
				POST = 1,
				BLINK = 2
			}
	
			// Constructors
			public ClipBinding() {} // 0x0000000180F3A180-0x0000000180F3A190
	
			// Methods
			public void OnBeforeSerialize() {} // 0x00000001802CB650-0x00000001802CB660
			public void OnAfterDeserialize() {} // 0x00000001814E0210-0x00000001814E0340
			public static ClipBinding CreateBinding(string eName, Type bindingGrpType, int index) => default; // 0x00000001814E01A0-0x00000001814E0210
		}
	
		[Serializable]
		public class ClipBindingGrp // TypeDefIndex: 6622
		{
			// Fields
			[SerializeField] // 0x00000001818193F0-0x0000000181819400
			public ClipBinding[] bindings; // 0x10
	
			// Methods
			public void GetByIndex(int index, out ClipBinding clipBinding) {
				clipBinding = default;
			} // 0x00000001814E0160-0x00000001814E01A0
		}
	
		[Serializable]
		public new class BakeData : SequenceBakeData.BakeData
		{
			public ClipShapeCurveGrp bakedGrp;

			public ClipBindingGrp bakedClipBindingGrp;
		}
	}
}

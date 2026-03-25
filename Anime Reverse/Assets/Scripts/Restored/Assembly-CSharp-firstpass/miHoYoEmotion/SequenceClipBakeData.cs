using UnityEngine;
using System;
using MoleMole;

namespace miHoYoEmotion
{
	public class SequenceClipBakeData : SequenceBakeData
	{
		[Serializable]
		public class ClipPathProp : ISerializationCallbackReceiver
		{
			public string path;

			public string prop;

			public void OnBeforeSerialize()
			{
			}

			public void OnAfterDeserialize()
			{
				UniqueString.InternString(ref path);
				UniqueString.InternString(ref prop);
			}
		}

		[Serializable]
		public class ClipBinding : ISerializationCallbackReceiver
		{
			public string elementName;

			public Type grpType = Type.INVALID;

			public enum Type
			{
				INVALID = -1,
				MAIN = 0,
				POST = 1,
				BLINK = 2
			}

			public void OnBeforeSerialize()
			{
			}

			public void OnAfterDeserialize()
			{
				UniqueString.InternString(ref elementName);
			}

			public static ClipBinding CreateBinding(string eName, Type bindingGrpType, int index)
			{
				ClipBinding clipBinding = new ClipBinding();
				clipBinding.elementName = eName;
				clipBinding.grpType = bindingGrpType;
				return clipBinding;
			}
		}

		[Serializable]
		public class ClipBindingGrp
		{
			[SerializeField]
			public ClipBinding[] bindings;

			public void GetByIndex(int index, out ClipBinding clipBinding)
			{
				clipBinding = null;
				if (bindings != null && index >= 0 && index < bindings.Length)
				{
					clipBinding = bindings[index];
				}
			}
		}

		[Serializable]
		public new class BakeData : SequenceBakeData.BakeData
		{
			public ClipShapeCurveGrp bakedGrp;

			public ClipBindingGrp bakedClipBindingGrp;
		}
		
		[SerializeField]
		private BakeData _phonemeBakeData;

		[SerializeField]
		private BakeData _emotionBakeData;
	
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
	}
}

using System;
using UnityEngine;

namespace miHoYoEmotion
{
	[Serializable]
	[CreateAssetMenu]
	public class EmotionSetData : ScriptableObject, ISerializationCallbackReceiver // TypeDefIndex: 6615
	{
		[Space]
		public string[] phonemeSet;
		[Space]
		public string[] emotionSet;
		[Space]
		public string[] gestureSet;
	
		public EmotionSetData() {} // 0x00000001804C45E0-0x00000001804C45F0
	
		// Methods
		public string PhonemeName(int index) => default; // 0x00000001813A8900-0x00000001813A8940
		public string EmotionName(int index) => default; // 0x0000000180FFDE60-0x0000000180FFDEA0
		public string GestureName(int index) => default; // 0x0000000180F59910-0x0000000180F59950
		public void OnBeforeSerialize() {} // 0x00000001802CB650-0x00000001802CB660
		public void OnAfterDeserialize() {} // 0x00000001814EA010-0x00000001814EA0A0
	}
}

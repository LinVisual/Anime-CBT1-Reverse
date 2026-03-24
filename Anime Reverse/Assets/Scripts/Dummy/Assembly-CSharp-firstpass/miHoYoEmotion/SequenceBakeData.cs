using System;
using UnityEngine;

// Image 19: Assembly-CSharp-firstpass.dll - Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5219-7968

namespace miHoYoEmotion
{
	public class SequenceBakeData : ScriptableObject // TypeDefIndex: 6613
	{
		[HideInInspector]
		[SerializeField]
		public string lastEmotion = "Normal01";

		[HideInInspector]
		[SerializeField]
		public string firstEmotion = "Normal01";

		[SerializeField]
		public bool needBlend;
	
		// Properties
		public virtual float length { get => default; } // 0x0000000180BF5540-0x0000000180BF5550 

		//OK
		public virtual BakeData phonemeBakeData
		{
			get
			{
				return null;
			}
			set
			{

			}
		}

		//OK
		public virtual BakeData emotionBakeData
		{
			get
			{
				return null;
			}
			set
			{

			}
		}

		// Nested types
		[Serializable]
		public class BakeData // TypeDefIndex: 6614
		{
			// Fields
			public float length; // 0x10
	
			// Constructors
			public BakeData() {} // 0x00000001802CB2E0-0x00000001802CB2F0
		}
	}
}

using System;
using UnityEngine;

namespace miHoYoEmotion
{
	public class SequenceBakeData : ScriptableObject
	{
		[Serializable]
		public class BakeData
		{
			public float length;
		}

		[HideInInspector]
		[SerializeField]
		public string lastEmotion = "Normal01";

		[HideInInspector]
		[SerializeField]
		public string firstEmotion = "Normal01";

		[SerializeField]
		public bool needBlend;

		public virtual float length
		{
			get
			{
				return 0f;
			}
		}

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
	}
}

using UnityEngine;
using System;
using MoleMole;

namespace miHoYoEmotion
{
	[Serializable]
	public class FrameShapeElement : ShapeElement, ISerializationCallbackReceiver
	{
		public enum TYPE
		{
			INVALID = -1,
			MOUTH = 0,
			EYE_LEFT = 1,
			EYE_RIGHT = 2
		}

		[SerializeField]
		public TYPE type = TYPE.INVALID;

		[SerializeField]
		public string propertyName = "_MainTex";

		[SerializeField]
		public float frameRate = 30f;

		[SerializeField]
		public Texture2D[] mainFrames;

		[SerializeField]
		public Texture2D[] postFrames;

		[SerializeField]
		public Texture2D[] blinkFrames;

		public override float duration
		{
			get
			{
				if (mainFrames != null)
				{
					return 1f / frameRate * mainFrames.Length;
				}
				return 0f;
			}
		}

		public override float postDuration
		{
			get
			{
				if (postFrames != null)
				{
					return 1f / frameRate * postFrames.Length;
				}
				return 0f;
			}
		}

		public override float blinkDuration
		{
			get
			{
				if (blinkFrames != null)
				{
					return 1f / frameRate * blinkFrames.Length;
				}
				return 0f;
			}
		}


		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
			UniqueString.InternString(ref propertyName);
		}
	}
}

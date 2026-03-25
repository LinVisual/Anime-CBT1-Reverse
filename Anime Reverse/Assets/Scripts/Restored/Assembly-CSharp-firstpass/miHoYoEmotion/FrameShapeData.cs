using UnityEngine;
using System;

namespace miHoYoEmotion
{
	[Serializable]
	[CreateAssetMenu]
	public class FrameShapeData : BaseShapeData
	{
		[Space]
		public FrameShapeElement[] phonemeElements = new FrameShapeElement[0];

		public FrameShapeElement[] emotionElements = new FrameShapeElement[0];

		public override void UpdateElements()
		{
			base.UpdateElements();
			UpdateTypeElement(phonemeElements);
			UpdateTypeElement(emotionElements);
		}

		private void UpdateTypeElement(FrameShapeElement[] elements)
		{
			for (int i = 0; i < elements.Length; i++)
			{
				AddShapeElement(elements[i]);
			}
		}
	}
}

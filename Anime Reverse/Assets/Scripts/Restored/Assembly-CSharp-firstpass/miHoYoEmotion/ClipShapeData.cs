using System;
using UnityEngine;

namespace miHoYoEmotion
{
	[Serializable]
	[CreateAssetMenu]
	public class ClipShapeData : BaseShapeData
	{
		[Space]
		public ClipShapeElement[] phonemeElements = new ClipShapeElement[0];

		public ClipShapeElement[] emotionElements = new ClipShapeElement[0];

		public override void UpdateElements()
		{
			base.UpdateElements();
			UpdateTypeElement(phonemeElements);
			UpdateTypeElement(emotionElements);
		}

		private void UpdateTypeElement(ClipShapeElement[] elements)
		{
			for (int i = 0; i < elements.Length; i++)
			{
				AddShapeElement(elements[i]);
			}
		}
	}
}

using System;

namespace miHoYoEmotion
{
	[Serializable]
	public class ShapeElement
	{
		public string name;

		public virtual float duration
		{
			get
			{
				return 0f; 
			}
		}

		public virtual float postDuration
		{
			get
			{
				return 0f;
			}
		}

		public virtual float blinkDuration
		{
			get
			{
				return 0f;
			}
		}
	}
}

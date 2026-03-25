using System;
using UnityEngine;

namespace miHoYoEmotion
{
	[Serializable]
	public class ClipShapeElement : ShapeElement
	{
		public AnimationClip mainClip;

		public ClipShapeCurveGrp mainCurveGrp;

		public AnimationClip postClip;

		public ClipShapeCurveGrp postCurveGrp;

		public AnimationClip blinkClip;

		public ClipShapeCurveGrp blinkCurveGrp;

		[Space]
		public float postBlendTime = 0.15f;

		public bool isPost = true;

		public string[] noPost;

		public bool isToFinal = true;

		public string[] toFinal;

		public override float duration
		{
			get
			{
				if (mainClip == null)
				{
					return 0f;
				}
				return mainClip.length;
			}
		}

		public override float postDuration
		{
			get
			{
				if (postClip == null)
				{
					return 0.12f;
				}
				return postClip.length + 0.12f;
			}
		}
	}
}

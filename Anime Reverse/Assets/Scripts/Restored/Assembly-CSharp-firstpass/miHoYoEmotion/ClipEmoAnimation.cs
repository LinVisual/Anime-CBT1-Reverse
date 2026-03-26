namespace miHoYoEmotion
{
	public class ClipEmoAnimation : BaseEmoAnimation
	{
		public override void Init(ElementManager manager)
		{
			base.Init(manager);
			AddTrack(0, new ClipEmoTrack());
			AddTrack(1, new ClipEmoBlinkTrack());
			AddTrack(2, new ClipEmoTrack());
			for (int i = 0; i < _trackList.Count; i++)
			{
				EmoTrack emoTrack = _trackList[i];
				if (emoTrack != null)
				{
					emoTrack.Init(manager);
				}
			}
		}
	}
}

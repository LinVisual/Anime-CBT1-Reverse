namespace miHoYoEmotion
{
	public class ClipEmoAnimation : BaseEmoAnimation
	{
		public override void Init(ElementManager manager)
		{
			base.Init(manager);
			AddTrack(EmoTrack.TRACK_EMOTION, new ClipEmoTrack());
			AddTrack(EmoTrack.TRACK_BLINK, new ClipEmoBlinkTrack());
			AddTrack(EmoTrack.TRACK_PHONEME, new ClipEmoTrack());
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

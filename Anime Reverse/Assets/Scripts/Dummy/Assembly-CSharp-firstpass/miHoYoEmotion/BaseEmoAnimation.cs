using System.Collections.Generic;

namespace miHoYoEmotion
{
	public abstract class BaseEmoAnimation
	{
		protected ElementManager _manager;

		protected List<EmoTrack> _trackList =  new List<EmoTrack>();
	
		//OK
		public ElementManager manager
		{
			get
			{
				return _manager;
			}
		}
	
		//OK
		protected void AddTrack(int trackIndex, EmoTrack track)
		{
			while (trackIndex >=  _trackList.Count)
			{
				_trackList.Add(null);
			}
			_trackList[trackIndex] = track;
			track.Init(_manager);
		}

		//OK
		protected EmoTrack GetTrack(int trackIndex)
		{
			if (trackIndex < _trackList.Count)
			{
				return _trackList[trackIndex];
			}
			return null;
		}

		//OK
		public virtual void Init(ElementManager manager)
		{
			_manager = manager;
		}

		public void Update(float deltaTime) {} // 0x00000001812BDCC0-0x00000001812BDD80
		public void Apply() {} // 0x00000001812BD4B0-0x00000001812BD560
		public void RegisterFinishHandler(EmoTrack.EmoVoidHandler handler, int trackIndex = 0 /* Metadata: 0x00920C99 */) {} // 0x00000001812BD890-0x00000001812BD8D0
		public void UnregisterFinishHandler(EmoTrack.EmoVoidHandler handler, int trackIndex = 0 /* Metadata: 0x00920C9D */) {} // 0x00000001812BDC80-0x00000001812BDCC0
		public void CallFinishHandler(int trackIndex) {} // 0x00000001812BD560-0x00000001812BD590

		//OK
		public BaseShape GetCurShape(int trackIndex)
		{
			return GetTrack(trackIndex).GetCurShape();
		}

		public void SetCurShape(BaseShape shape, int trackIndex = 0 /* Metadata: 0x00920CA1 */) {} // 0x00000001812BD8D0-0x00000001812BD910
		public void EnableShape(BaseShape shape, float startTime = 0f /* Metadata: 0x00920CA5 */, int trackIndex = 0 /* Metadata: 0x00920CA9 */) {} // 0x00000001812BD5F0-0x00000001812BD640
		public void PlayDefault(BaseShape shape, int trackIndex = 0 /* Metadata: 0x00920CAD */, string postToPlay = "Normal" /* Metadata: 0x00920CB1 */) {} // 0x00000001812BD840-0x00000001812BD890
		public void ApendShape(BaseShape shape, float startTime = 0f /* Metadata: 0x00920CBB */, int trackIndex = 0 /* Metadata: 0x00920CBF */) {} // 0x00000001812BD460-0x00000001812BD4B0
		public void ClearShape(int trackIndex = 0 /* Metadata: 0x00920CC3 */) {} // 0x00000001812BD5C0-0x00000001812BD5F0

		//OK
		public void ClearShapeOnly(int trackIndex = 0)
		{
			GetTrack(trackIndex).ClearShapeOnly();
		}

		public void PlayBakedSequence(SequenceBakeData bakeData) {} // 0x00000001812BD6F0-0x00000001812BD840
		public void TogglePauseEmo(bool toggle) {} // 0x00000001812BDA90-0x00000001812BDC80
		public void TogglePauseBlink(bool toggle) {} // 0x00000001812BDA00-0x00000001812BDA90
		public void StopSequence() {} // 0x00000001812BD910-0x00000001812BDA00
	}
}

namespace miHoYoEmotion
{
	public abstract class EmoTrack
	{
		public const float DEFAULT_POST_TIME = 0.12f;

		public const float DEFUALT_BLEND_TIME = 0f;

		public const int TRACK_EMOTION = 0;

		public const int TRACK_BLINK = 1;

		public const int TRACK_PHONEME = 2;

		protected BaseShape _preShape;

		protected BaseShape _curShape;

		protected string _preTag = string.Empty;

		protected string _curTag = string.Empty;

		protected float _timeLength;

		protected float _timeCnt;

		protected bool _isPaused;

		protected bool _isTobeFinished;

		protected EmoVoidHandler _finishHandler;

		protected ElementManager _manager;

		public bool isPaused
		{
			get
			{
				return _isPaused;
			}
			set
			{
				_isPaused = value;
			}
		}
	
		public delegate void EmoVoidHandler();

		public virtual void Init(ElementManager manager)
		{
			_manager = manager;
		}

		public virtual void Update(float deltaTime)
		{
		}

		public virtual void Apply()
		{
		}

		public virtual void RegisterFinishHandler(EmoVoidHandler handler)
		{
			_finishHandler += handler;
		}

		public virtual void UnregisterFinishHandler(EmoVoidHandler handler)
		{
			_finishHandler -= handler;
		}

		public virtual void CallFinishHandler()
		{
			_finishHandler?.Invoke();
		}

		public BaseShape GetCurShape()
		{
			return _curShape;
		}

		public virtual void SetCurShape(BaseShape shape)
		{
			_curShape = shape;
		}

		public virtual void EnableShape(BaseShape shape, float startTime = 0f)
		{
			_curShape = shape;
		}

		public virtual void PlayDefault(BaseShape shape, string postToPlay = "")
		{
		}

		public virtual void ApendShape(BaseShape shape, float startTime = 0f)
		{
		}

		public virtual void ClearShape()
		{
			_curShape = null;
		}

		public virtual void ClearShapeOnly()
		{
			_curShape = null;
		}

		public virtual void PlayBakedSequence(SequenceBakeData.BakeData bakeData)
		{
		}

		public virtual void StopSequence()
		{
		}
	}
}

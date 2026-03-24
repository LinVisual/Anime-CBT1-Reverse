/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security;

// Image 19: Assembly-CSharp-firstpass.dll - Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5219-7968

namespace miHoYoEmotion
{
	public abstract class EmoTrack // TypeDefIndex: 6573
	{
		// Fields
		public const float DEFAULT_POST_TIME = 0.12f; // Metadata: 0x00920C85
		public const float DEFUALT_BLEND_TIME = 0f; // Metadata: 0x00920C89
		public const int TRACK_EMOTION = 0; // Metadata: 0x00920C8D
		public const int TRACK_BLINK = 1; // Metadata: 0x00920C91
		public const int TRACK_PHONEME = 2; // Metadata: 0x00920C95
		protected BaseShape _preShape; // 0x10
		protected BaseShape _curShape; // 0x18
		protected string _preTag; // 0x20
		protected string _curTag; // 0x28
		protected float _timeLength; // 0x30
		protected float _timeCnt; // 0x34
		protected bool _isPaused; // 0x38
		protected bool _isTobeFinished; // 0x39
		protected EmoVoidHandler _finishHandler; // 0x40
		protected ElementManager _manager; // 0x48
	
		// Properties
		public bool isPaused { get; set; } // 0x000000018080FDB0-0x000000018080FDC0 0x00000001809818B0-0x00000001809818C0
	
		// Nested types
		public delegate void EmoVoidHandler(); // TypeDefIndex: 6574; 0x0000000180772CA0-0x0000000180772D20
	
		// Constructors
		protected EmoTrack() {} // 0x00000001814E9F80-0x00000001814EA000
	
		// Methods
		public virtual void Init(ElementManager manager) {} // 0x0000000180502380-0x0000000180502390
		public virtual void Update(float deltaTime) {} // 0x00000001802CB650-0x00000001802CB660
		public virtual void Apply() {} // 0x00000001802CB650-0x00000001802CB660
		public virtual void RegisterFinishHandler(EmoVoidHandler handler) {} // 0x00000001814E9E80-0x00000001814E9F00
		public virtual void UnregisterFinishHandler(EmoVoidHandler handler) {} // 0x00000001814E9F00-0x00000001814E9F80
		public virtual void CallFinishHandler() {} // 0x00000001814E9E60-0x00000001814E9E80
		public BaseShape GetCurShape() => default; // 0x00000001802F4560-0x00000001802F4570
		public virtual void SetCurShape(BaseShape shape) {} // 0x000000018070F1F0-0x000000018070F200
		public virtual void EnableShape(BaseShape shape, float startTime = 0f /* Metadata: 0x00920C79 */) {} // 0x000000018070F1F0-0x000000018070F200
		public virtual void PlayDefault(BaseShape shape, string postToPlay = "" /* Metadata: 0x00920C7D */) {} // 0x00000001802CB650-0x00000001802CB660
		public virtual void ApendShape(BaseShape shape, float startTime = 0f /* Metadata: 0x00920C81 */) {} // 0x00000001802CB650-0x00000001802CB660
		public virtual void ClearShape() {} // 0x000000018082CA20-0x000000018082CA30
		public virtual void ClearShapeOnly() {} // 0x000000018082CA20-0x000000018082CA30
		public virtual void PlayBakedSequence(SequenceBakeData.BakeData bakeData) {} // 0x00000001802CB650-0x00000001802CB660
		public virtual void StopSequence() {} // 0x00000001802CB650-0x00000001802CB660
	}
}

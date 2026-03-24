/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security;

// Image 19: Assembly-CSharp-firstpass.dll - Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5219-7968

namespace miHoYoEmotion
{
	public abstract class BaseEmoAnimation // TypeDefIndex: 6575
	{
		// Fields
		protected ElementManager _manager; // 0x10
		protected List<EmoTrack> _trackList; // 0x18
	
		// Properties
		public ElementManager manager { get; } // 0x0000000180293970-0x0000000180293980 
	
		// Constructors
		protected BaseEmoAnimation() {} // 0x00000001812BDD80-0x00000001812BDDE0
	
		// Methods
		protected void AddTrack(int trackIndex, EmoTrack track) {} // 0x00000001812BD3A0-0x00000001812BD460
		protected EmoTrack GetTrack(int trackIndex) => default; // 0x00000001812BD670-0x00000001812BD6F0
		public virtual void Init(ElementManager manager) {} // 0x0000000180723BD0-0x0000000180723BE0
		public void Update(float deltaTime) {} // 0x00000001812BDCC0-0x00000001812BDD80
		public void Apply() {} // 0x00000001812BD4B0-0x00000001812BD560
		public void RegisterFinishHandler(EmoTrack.EmoVoidHandler handler, int trackIndex = 0 /* Metadata: 0x00920C99 */) {} // 0x00000001812BD890-0x00000001812BD8D0
		public void UnregisterFinishHandler(EmoTrack.EmoVoidHandler handler, int trackIndex = 0 /* Metadata: 0x00920C9D */) {} // 0x00000001812BDC80-0x00000001812BDCC0
		public void CallFinishHandler(int trackIndex) {} // 0x00000001812BD560-0x00000001812BD590
		public BaseShape GetCurShape(int trackIndex) => default; // 0x00000001812BD640-0x00000001812BD670
		public void SetCurShape(BaseShape shape, int trackIndex = 0 /* Metadata: 0x00920CA1 */) {} // 0x00000001812BD8D0-0x00000001812BD910
		public void EnableShape(BaseShape shape, float startTime = 0f /* Metadata: 0x00920CA5 */, int trackIndex = 0 /* Metadata: 0x00920CA9 */) {} // 0x00000001812BD5F0-0x00000001812BD640
		public void PlayDefault(BaseShape shape, int trackIndex = 0 /* Metadata: 0x00920CAD */, string postToPlay = "Normal" /* Metadata: 0x00920CB1 */) {} // 0x00000001812BD840-0x00000001812BD890
		public void ApendShape(BaseShape shape, float startTime = 0f /* Metadata: 0x00920CBB */, int trackIndex = 0 /* Metadata: 0x00920CBF */) {} // 0x00000001812BD460-0x00000001812BD4B0
		public void ClearShape(int trackIndex = 0 /* Metadata: 0x00920CC3 */) {} // 0x00000001812BD5C0-0x00000001812BD5F0
		public void ClearShapeOnly(int trackIndex = 0 /* Metadata: 0x00920CC7 */) {} // 0x00000001812BD590-0x00000001812BD5C0
		public void PlayBakedSequence(SequenceBakeData bakeData) {} // 0x00000001812BD6F0-0x00000001812BD840
		public void TogglePauseEmo(bool toggle) {} // 0x00000001812BDA90-0x00000001812BDC80
		public void TogglePauseBlink(bool toggle) {} // 0x00000001812BDA00-0x00000001812BDA90
		public void StopSequence() {} // 0x00000001812BD910-0x00000001812BDA00
	}
}

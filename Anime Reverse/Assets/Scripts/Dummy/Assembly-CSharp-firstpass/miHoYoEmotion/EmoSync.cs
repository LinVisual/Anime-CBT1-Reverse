/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security;
using UnityEngine;

// Image 19: Assembly-CSharp-firstpass.dll - Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5219-7968

namespace miHoYoEmotion
{
	public class EmoSync : EmoMgrUser // TypeDefIndex: 6595
	{
		// Fields
		public const string DEFAULT_EMOTION = "Default"; // Metadata: 0x00920DBF
		public const string DEFAULT_EMOTION01 = "Default"; // Metadata: 0x00920DCA
		public const string DEFAULT_PHONEMES = "P_Default"; // Metadata: 0x00920DD5
		[SerializeField] // 0x00000001818193F0-0x0000000181819400
		public string defaultEmotion; // 0x30
		[SerializeField] // 0x00000001818193F0-0x0000000181819400
		public string resetEmotion; // 0x38
		[SerializeField] // 0x00000001818193F0-0x0000000181819400
		public string resetPhoneme; // 0x40
		[SerializeField] // 0x00000001818193F0-0x0000000181819400
		private EmotionSetData _setData; // 0x48
		[SerializeField] // 0x00000001818193F0-0x0000000181819400
		public List<BaseShape> phonemes; // 0x50
		[SerializeField] // 0x00000001818193F0-0x0000000181819400
		public List<BaseShape> emotions; // 0x58
		private Dictionary<string, BaseShape> _phonemeCache; // 0x60
		private Dictionary<string, BaseShape> _emotionCahce; // 0x68
		private string _curEmotion; // 0x70
		private string _preEmotion; // 0x78
		private string _lastEmotion; // 0x80
		private bool _lastSeqNeedBlend; // 0x88
		private string _curPhoneme; // 0x90
		private string _prePhoneme; // 0x98
		private EmoParamCache _emoParamCache; // 0xA0
		private SequenceBakeData currentPlayingSeqData; // 0xA8
	
		// Properties
		public EmotionSetData setData { get => default; } // 0x00000001802CB2D0-0x00000001802CB2E0 
		private string preEmotion { get => default; } // 0x0000000180729330-0x0000000180729340 
		private string prePhoneme { get => default; } // 0x00000001804F7090-0x00000001804F70A0 
	
		// Nested types
		public class EmoParamCache // TypeDefIndex: 6596
		{
			// Fields
			public string emotionName; // 0x10
			public string phonemeName; // 0x18
			public float blendTime; // 0x20
			public SequenceBakeData seqData; // 0x28
			private bool _dirty; // 0x30
	
			// Properties
			public bool IsDirty { get => default; } // 0x0000000180798700-0x0000000180798710 
	
			// Constructors
			public EmoParamCache() {} // 0x00000001802CB2E0-0x00000001802CB2F0
	
			// Methods
			public void SetEmotionCache(string pEmotionName, float pBlendTime) {} // 0x00000001814E8180-0x00000001814E8190
			public void SetPhonemeCache(string pPhoneme, float pBlendTime) {} // 0x00000001814E8190-0x00000001814E81A0
			public void SetSeqDataCache(SequenceBakeData pSeqData) {} // 0x00000001814E81A0-0x00000001814E81B0
			private void SetDirty() {} // 0x0000000180C21B50-0x0000000180C21B60
			public void Clear() {} // 0x00000001814E8160-0x00000001814E8180
		}
	
		// Constructors
		public EmoSync() {} // 0x00000001814E9CE0-0x00000001814E9E60
	
		// Methods
		public string GetPhonemeNameByIndex(int index) => default; // 0x00000001814E89F0-0x00000001814E8A30
		public string GetEmotionNameByIndex(int index) => default; // 0x00000001814E8940-0x00000001814E8980
		public void UpdatePhonemeCache() {} // 0x00000001814E9C10-0x00000001814E9CE0
		public void UpdateEmotionCache() {} // 0x00000001814E9B40-0x00000001814E9C10
		public void UpdateCache() {} // 0x00000001814E9B20-0x00000001814E9B40
		public BaseShape GetPhoneme(string name) => default; // 0x00000001814E8A30-0x00000001814E8AA0
		public BaseShape GetEmotion(string name) => default; // 0x00000001814E8980-0x00000001814E89F0
		public void ResetPhoneme(bool playPost = false /* Metadata: 0x00920DBD */) {} // 0x00000001814E9070-0x00000001814E91C0
		public void SetPhoneme(string phonemeName, float blendTime) {} // 0x00000001814E95B0-0x00000001814E9720
		public void ResetEmotion(bool playPost = false /* Metadata: 0x00920DBE */) {} // 0x00000001814E8F30-0x00000001814E9070
		public void SetEmotion(string emotionName, float blendTime) {} // 0x00000001814E9460-0x00000001814E95B0
		public void SetEmotionOnly(string emotionName) {} // 0x00000001814E9350-0x00000001814E9460
		public void PlaySequence(SequenceBakeData seqData) {} // 0x00000001814E8CF0-0x00000001814E8F30
		private void DoPlay() {} // 0x00000001814E86B0-0x00000001814E8770
		public void Toggle(bool toggle) {} // 0x00000001814E9B00-0x00000001814E9B20
		public void ClearSequence() {} // 0x00000001814E86A0-0x00000001814E86B0
		public void ClearEmotion() {} // 0x00000001814E8680-0x00000001814E86A0
		private void EmoFinish() {} // 0x00000001814E8770-0x00000001814E8940
		private void PhoFinish() {} // 0x00000001814E86A0-0x00000001814E86B0
		private void PerformCache() {} // 0x00000001814E8B90-0x00000001814E8CF0
		protected override void Start() {} // 0x00000001814E9720-0x00000001814E9B00
		protected void SetDefaultEmotion() {} // 0x00000001814E91C0-0x00000001814E92D0
		protected void SetDefaultPhoneme() {} // 0x00000001814E92D0-0x00000001814E9350
		protected override void OnEnable() {} // 0x00000001814E8B60-0x00000001814E8B90
		private void OnDestroy() {} // 0x00000001814E8AA0-0x00000001814E8B60
	}
}

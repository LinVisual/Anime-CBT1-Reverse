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

namespace motion4hi
{
	public class AnimatorController : MonoBehaviour, ISerializationCallbackReceiver // TypeDefIndex: 6945
	{
		// Fields
		public TransitionPriority[] _overrideTransitionPriorities; // 0x18
		[HideInInspector] // 0x00000001818193F0-0x0000000181819400
		public Int3[] _transitionProirities; // 0x20
		[HideInInspector] // 0x00000001818193F0-0x0000000181819400
		public Dictionary<string, bool> _stateLoop; // 0x28
		[HideInInspector] // 0x00000001818193F0-0x0000000181819400
		public float _random; // 0x30
		[HideInInspector] // 0x00000001818193F0-0x0000000181819400
		public bool _disableNoFadeZone; // 0x34
		[HideInInspector] // 0x00000001818193F0-0x0000000181819400
		public Dictionary<StateMachineBehaviour, StateMachineBehaviourInfo> _currentBehaviour; // 0x38
		public string[] _curveExtractionKeywords; // 0x40
		[HideInInspector] // 0x00000001818193F0-0x0000000181819400
		public AnimationCurve[] _motionZCurves; // 0x48
		[HideInInspector] // 0x00000001818193F0-0x0000000181819400
		public AnimationCurve[] _motionQxCurves; // 0x50
		[HideInInspector] // 0x00000001818193F0-0x0000000181819400
		public AnimationCurve[] _motionQyCurves; // 0x58
		[HideInInspector] // 0x00000001818193F0-0x0000000181819400
		public AnimationCurve[] _motionQzCurves; // 0x60
		[HideInInspector] // 0x00000001818193F0-0x0000000181819400
		public AnimationCurve[] _motionQwCurves; // 0x68
		[HideInInspector] // 0x00000001818193F0-0x0000000181819400
		public string[] _stateNames; // 0x70
		[HideInInspector] // 0x00000001818193F0-0x0000000181819400
		public bool[] _stateLoops; // 0x78
		[HideInInspector] // 0x00000001818193F0-0x0000000181819400
		public int[] _stateHashes; // 0x80
		[HideInInspector] // 0x00000001818193F0-0x0000000181819400
		public bool[] _stateMirros; // 0x88
		[HideInInspector] // 0x00000001818193F0-0x0000000181819400
		public bool[] _stateHasMirrors; // 0x90
		[HideInInspector] // 0x00000001818193F0-0x0000000181819400
		public string[] _stateMirrorParams; // 0x98
		[HideInInspector] // 0x00000001818193F0-0x0000000181819400
		public string[] _statePhaseJsonPathes; // 0xA0
		[HideInInspector] // 0x00000001818193F0-0x0000000181819400
		public AnimationPhaseArray[] _statePhaseArrays; // 0xA8
		[HideInInspector] // 0x00000001818193F0-0x0000000181819400
		public float[] _stateDefaultDurations; // 0xB0
		[HideInInspector] // 0x00000001818193F0-0x0000000181819400
		public List<string> _serializedParamConstraints; // 0xB8
		[HideInInspector] // 0x00000001818193F0-0x0000000181819400
		public List<ParamConstraint> _paramConstraints; // 0xC0
		[HideInInspector] // 0x00000001818193F0-0x0000000181819400
		public bool[] _stateTransitionedArray; // 0xC8
		[HideInInspector] // 0x00000001818193F0-0x0000000181819400
		public Int3 _cfTransition; // 0xD0
		[HideInInspector] // 0x00000001818193F0-0x0000000181819400
		public Vector3 _cfParams; // 0xDC
		[HideInInspector] // 0x00000001818193F0-0x0000000181819400
		public Animator _animator; // 0xE8
		private int _frame; // 0xF0
		public AnimatorControllerParameter[] _allParams; // 0xF8
		public PropSpace _prop1Space; // 0x100
		[HideInInspector] // 0x00000001818193F0-0x0000000181819400
		public Vector3 _crossOverStepBorderNear0; // 0x104
		[HideInInspector] // 0x00000001818193F0-0x0000000181819400
		public Vector3 _crossOverStepBorderNear1; // 0x110
		[HideInInspector] // 0x00000001818193F0-0x0000000181819400
		public Vector3 _crossOverStepBorderFar0; // 0x11C
		[HideInInspector] // 0x00000001818193F0-0x0000000181819400
		public Vector3 _crossOverStepBorderFar1; // 0x128
		[HideInInspector] // 0x00000001818193F0-0x0000000181819400
		public Vector3 _crossOverJumpBorder0; // 0x134
		[HideInInspector] // 0x00000001818193F0-0x0000000181819400
		public Vector3 _crossOverJumpBorder1; // 0x140
		[HideInInspector] // 0x00000001818193F0-0x0000000181819400
		public Vector3 _crossOverPredictJumpPos; // 0x14C
		[HideInInspector] // 0x00000001818193F0-0x0000000181819400
		public Vector3 _crossOverPredictStepInPos; // 0x158
		[HideInInspector] // 0x00000001818193F0-0x0000000181819400
		public Vector3 _crossOverDecisionJumpPos; // 0x164
		[NonSerialized]
		[HideInInspector] // 0x00000001818193F0-0x0000000181819400
		public int _currentstateHash; // 0x170
		[NonSerialized]
		[HideInInspector] // 0x00000001818193F0-0x0000000181819400
		public int _nextstateHash; // 0x174
		[NonSerialized]
		[HideInInspector] // 0x00000001818193F0-0x0000000181819400
		public float _currentstateTime; // 0x178
		[NonSerialized]
		[HideInInspector] // 0x00000001818193F0-0x0000000181819400
		public float _nextstateTime; // 0x17C
		[HideInInspector] // 0x00000001818193F0-0x0000000181819400
		public Dictionary<string, Action<int>> _crossfadeCallbacks; // 0x180
	
		// Properties
		public int Frame { get => default; } // 0x0000000180C70950-0x0000000180C70960 
		public AnimatorControllerParameter[] allParams { get => default; } // 0x00000001802DE2F0-0x00000001802DE300 
	
		// Nested types
		[Serializable]
		public class TransitionPriority : ISerializationCallbackReceiver // TypeDefIndex: 6946
		{
			// Fields
			public string _srcStateName; // 0x10
			public string _tgtStateName; // 0x18
			public int _priority; // 0x20
	
			// Constructors
			public TransitionPriority() {} // 0x00000001802CB2E0-0x00000001802CB2F0
	
			// Methods
			public void OnBeforeSerialize() {} // 0x00000001802CB650-0x00000001802CB660
			public void OnAfterDeserialize() {} // 0x0000000180C9FE30-0x0000000180C9FF40
		}
	
		public struct StateMachineBehaviourInfo // TypeDefIndex: 6947
		{
			// Fields
			public int fullPathHash; // 0x00
			public int layerIndex; // 0x04
			public int count; // 0x08
	
			// Constructors
			public StateMachineBehaviourInfo(int layerIndex, int fullPathHash) {
				this.fullPathHash = default;
				this.layerIndex = default;
				count = default;
			} // 0x0000000180C94630-0x0000000180C94640
		}
	
		// Constructors
		public AnimatorController() {} // 0x0000000180C708B0-0x0000000180C70950
	
		// Methods
		public void OnBeforeSerialize() {} // 0x00000001802CB650-0x00000001802CB660
		public void OnAfterDeserialize() {} // 0x0000000180C6FBC0-0x0000000180C6FC60
		public string StateName(int index) => default; // 0x0000000180C70490-0x0000000180C70530
		//public AnimationPhaseArray StatePhaseArray(int index) => default; // 0x0000000180C705D0-0x0000000180C70620
		//public AnimationPhaseArray StatePhaseArray(string name) => default; // 0x0000000180C70530-0x0000000180C705D0
		//public static string[] SplitStateName(string inName) => default; // 0x0000000180C702E0-0x0000000180C70490
		//public string HashToName(int inHash) => default; // 0x0000000180C6EF80-0x0000000180C6F070
		//public float HashToDuration(int inHash) => default; // 0x0000000180C6E8C0-0x0000000180C6E950
		//public AnimationPhaseArray HashToPhaseArray(int hash) => default; // 0x0000000180C6F070-0x0000000180C6F100
		//public int HashToIndex(int inHash) => default; // 0x0000000180C6EC70-0x0000000180C6ECD0
		//public bool HashToHasMirror(int hash) => default; // 0x0000000180C6E950-0x0000000180C6E9E0
		//public int NameToIndex(string inName) => default; // 0x0000000180C6F890-0x0000000180C6F900
		//public int HashToIndex(string inName, AnimationPhaseType inPhase, bool inMatchExactly) => default; // 0x0000000180C6E9E0-0x0000000180C6EC70
		//public AnimationCurve NameToMotionZCurve(string name) => default; // 0x0000000180C6FB20-0x0000000180C6FBC0
		//public AnimationCurve HashToMotionZCurve(int hash) => default; // 0x0000000180C6EEF0-0x0000000180C6EF80
		//public QuaternionCurve NameToMotionQCurve(string name) => default; // 0x0000000180C6F900-0x0000000180C6FB20
		//public QuaternionCurve HashToMotionQCurve(int hash) => default; // 0x0000000180C6ECD0-0x0000000180C6EEF0
		public void Serialize() {} // 0x00000001802CB650-0x00000001802CB660
		public void UnSerialize() {} // 0x0000000180C706E0-0x0000000180C707F0
		public bool InZone(string zoneName, bool allowNext) => default; // 0x0000000180C6F2A0-0x0000000180C6F580
		public bool InZone(string zoneName) => default; // 0x0000000180C6F580-0x0000000180C6F780
		public bool InNextZone(string zoneName) => default; // 0x0000000180C6F100-0x0000000180C6F2A0
		public bool InZone(ref AnimatorStateInfo state, int nameHash) => default; // 0x0000000180C6F780-0x0000000180C6F890
		//public AnimationPhaseArray.ZoneTime CalcZoneTime(AnimatorStateInfo stateInfo, string zoneName) => default; // 0x0000000180C6CDC0-0x0000000180C6D060
		//public AnimationPhaseArray.ZoneTime CalcCurrentZoneTime(string zoneName) => default; // 0x0000000180C6CA50-0x0000000180C6CAF0
		//public AnimationPhaseArray.ZoneTime CalcNextZoneTime(string zoneName) => default; // 0x0000000180C6CD20-0x0000000180C6CDC0
		//public AnimationPhaseArray.ZoneTime CalcMostValidZoneTime(string zoneName) => default; // 0x0000000180C6CAF0-0x0000000180C6CD20
		//public KeyValuePair<AnimationPhase, float> GetPhase(AnimatorStateInfo stateInfo) => default; // 0x0000000180C6E450-0x0000000180C6E800
		public AnimatorControllerParameter GetParameterByName(string inName) => default; // 0x0000000180C6E320-0x0000000180C6E450
		private void Awake() {} // 0x0000000180C6C4D0-0x0000000180C6CA50
		public bool HasParam(string paramName) => default; // 0x0000000180C6E800-0x0000000180C6E8C0
		public bool GetMirrorByStateName(string stateName) => default; // 0x0000000180C6E250-0x0000000180C6E320
		public void SetMirrorByStateName(string stateName, bool isMirror) {} // 0x0000000180C70210-0x0000000180C702E0
		public bool GetMirrorByStateIndex(int stateIndex) => default; // 0x0000000180C6E1C0-0x0000000180C6E250
		public void SetMirrorByStateIndex(int stateIndex, bool isMirror) {} // 0x0000000180C70180-0x0000000180C70210
		public bool CrossFade(AnimatorStateInfo currState, string nextStateName, string allowZoneName, float fadeLength, float tgtTime, bool ignoreZone, bool exterpolateRootMotionAtFrameZero) => default; // 0x0000000180C6D530-0x0000000180C6D860
		public bool CrossFadeInNormalizedTime(AnimatorStateInfo currState, string nextStateName, string allowZoneName, float fadeLength, float tgtTime, bool ignoreZone, bool exterpolateRootMotionAtFrameZero) => default; // 0x0000000180C6D0A0-0x0000000180C6D530
		//public bool CrossFade(AnimatorStateInfo currState, string nextStateName, string allowZoneName, string allowTargetZoneName, float fadeLength, bool fadeOnPhase, bool allowNextNonMirror, bool allowNextMirror, AnimationPhaseType tgtMatchPhaseType, int tgtMatchCustomData, float prependTime, bool exterpolateRootMotionAtFrameZero) => default; // 0x0000000180C6D860-0x0000000180C6E1C0
		public void ClearCfTranstion() {} // 0x0000000180C6D060-0x0000000180C6D0A0
		private void OnDrawGizmos() {} // 0x0000000180C6FCD0-0x0000000180C6FFE0
		public void UpdateStateTime(int currentHash, int nextHash, float currentScale, float nextScale) {} // 0x0000000180C707F0-0x0000000180C708B0
		public void SendCallback(string callback, int nextState) {} // 0x0000000180C700C0-0x0000000180C70180
		public void RegisterCallback(string callback, Action<int> func) {} // 0x0000000180C6FFE0-0x0000000180C700C0
		public void UnRegisterCallback(string callback, Action<int> func) {} // 0x0000000180C70620-0x0000000180C706E0
		private void OnDisable() {} // 0x0000000180C6FC60-0x0000000180C6FCD0
	}
}

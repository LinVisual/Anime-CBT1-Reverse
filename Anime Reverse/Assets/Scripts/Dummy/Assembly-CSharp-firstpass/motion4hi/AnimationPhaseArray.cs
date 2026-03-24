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
	[Serializable]
	public class AnimationPhaseArray // TypeDefIndex: 6929
	{
		// Fields
		public List<AnimationPhase> _phaseList; // 0x10
		public List<AnimationZone> _zoneList; // 0x18
		private Vector3[] _collectedStepRangeArray; // 0x20
		private static int _leftPlantHash; // 0x00
		private static int _rightPlantHash; // 0x04
	
		// Nested types
		public struct ZoneTime // TypeDefIndex: 6930
		{
			// Fields
			public int _shortNameHash; // 0x00
			public float _wrapTime; // 0x04
			public Vector2 _timeSpan; // 0x08
	
			// Methods
			public int Justify() => default; // 0x0000000180CA5DE0-0x0000000180CA5E30
		}
	
		// Constructors
		public AnimationPhaseArray() {} // 0x0000000180C6BF30-0x0000000180C6BFB0
		static AnimationPhaseArray() {} // 0x0000000180C6BEC0-0x0000000180C6BF30
	
		// Methods
		public AnimationPhaseArray Copy() => default; // 0x0000000180C6A0A0-0x0000000180C6A480
		//public static bool CanBlendIn(AnimationPhaseBlend blend) => default; // 0x0000000180C69BA0-0x0000000180C69BC0
		//public static bool CanBlendOut(AnimationPhaseBlend blend) => default; // 0x0000000180C69BC0-0x0000000180C69BE0
		//public static bool MatchBlend(AnimationPhaseBlend b0, AnimationPhaseBlend b1) => default; // 0x0000000180C6B640-0x0000000180C6B740
		//public static bool IsStep(AnimationPhaseType phaseType) => default; // 0x0000000180C6B5C0-0x0000000180C6B5E0
		//public static bool IsStepStart(AnimationPhaseType phaseType) => default; // 0x0000000180C6B1A0-0x0000000180C6B1C0
		//public static int StepToIndex(AnimationPhaseType stepType) => default; // 0x0000000180C6BC70-0x0000000180C6BCA0
		//public AnimationPhase Find(float t, AnimationPhaseBlend blend, params /* 0x00000001818193F0-0x0000000181819400 */ AnimationPhaseType[] phaseTypes) => default; // 0x0000000180C6A650-0x0000000180C6A980
		//public bool IsStep(float t, float len, bool loop, ref AnimationPhase outPhase) => default; // 0x0000000180C6B1C0-0x0000000180C6B5C0
		//public static AnimationPhaseType Mirror(AnimationPhaseType inType, bool inMirror) => default; // 0x0000000180C6B740-0x0000000180C6B780
		//public static bool CalculateSourcePhase(out AnimationPhase outPhase, out float deltaTime, AnimationPhaseArray srcArray, string allowZoneName, float srcStdLength, bool srcLoop, float curNormalizedTime) {
		//	outPhase = default;
		//	deltaTime = default;
		//	return default;
		//} // 0x0000000180C69760-0x0000000180C69BA0
		//public static bool CalculateFutureStep(out AnimationPhase outPhase, out float deltaTime, AnimationPhaseArray inSrcArray, float inSrcLength, bool inSrcLoop, float inCurrTime) {
		//	outPhase = default;
		//	deltaTime = default;
		//	return default;
		//} // 0x0000000180C69480-0x0000000180C69760
		//public static Vector3 CalculateCrossFade(AnimationPhaseArray srcArray, bool srcMirror, float srcStdLength, bool srcLoop, bool tgtLoop, AnimationPhaseArray tgtArray, bool tgtMirror, float tgtStdLength, string allowZoneName, string allowTargetZoneName, float curNormalizedTime, AnimationPhaseType tgtMatchPhaseType, int tgtMatchCustomData, float prependNormalizedTime) => default; // 0x0000000180C68FF0-0x0000000180C69480
		//public void Ready() {} // 0x0000000180C6B780-0x0000000180C6BA80
		//public void Sort() {} // 0x0000000180C6BA80-0x0000000180C6BC70
		//public bool TestZone(float time, string allowZoneName) => default; // 0x0000000180C6BDA0-0x0000000180C6BEA0
		//public bool InZone(float time, string name) => default; // 0x0000000180C6B160-0x0000000180C6B1A0
		//public bool InZone(float time, int nameHash) => default; // 0x0000000180C6B080-0x0000000180C6B160
		//public bool TestZoneInNormalizedTime(float time, string allowZoneName, float stdLength) => default; // 0x0000000180C6BCA0-0x0000000180C6BDA0
		//public bool InZoneInNormalizedTime(float time, string name, float stdLength) => default; // 0x0000000180C6B020-0x0000000180C6B080
		//public bool InZoneInNormalizedTime(float time, int nameHash, float stdLength) => default; // 0x0000000180C6AF20-0x0000000180C6B020
		//public ZoneTime CalcZoneTime(int stateNameHash, float time, string name) => default; // 0x0000000180C68E00-0x0000000180C68FF0
		//public AnimationPhaseType GetFootStepType(Vector4 elapsed, bool isMirror, bool isLoop) => default; // 0x0000000180C6ADB0-0x0000000180C6AF20
		//public AnimationPhaseType GetFootStepType(out float stepElasped, Vector4 elapsed, bool isMirror, bool isLoop) {
		//	stepElasped = default;
		//	return default;
		//} // 0x0000000180C6AC50-0x0000000180C6ADB0
		//public Vector2 GetFootAirRatio(Vector4 elapsed, bool isMirror) => default; // 0x0000000180C6A980-0x0000000180C6AC50
		//public Vector3[] CollectStepRangeArray() => default; // 0x0000000180C69BE0-0x0000000180C69F70
		//public int CompareZone(float time, string name) => default; // 0x0000000180C69F70-0x0000000180C6A0A0
		//public static float FindTag(AnimatorController cont, int stateHash, AnimationPhaseType tagType, int tagCustomData) => default; // 0x0000000180C6A480-0x0000000180C6A650
		public static AnimationPhaseArray LoadFromJSON(string json) => default; // 0x0000000180C6B5E0-0x0000000180C6B640
	}
}

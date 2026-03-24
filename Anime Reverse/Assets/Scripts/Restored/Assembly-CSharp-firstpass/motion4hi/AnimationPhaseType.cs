using System;

namespace motion4hi
{
	[Serializable]
	public enum AnimationPhaseType
	{
		Invalid = 0,
		LeftStep = 1,
		RightStep = 2,
		LeftStart = 8,
		RightStart = 9,
		CustomLeft = 997,
		CustomRight = 998,
		Custom = 999,
		SpecialBegin = 1000,
		SpecialCustom = 1999
	}
}

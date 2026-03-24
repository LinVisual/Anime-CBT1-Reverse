using System;

namespace motion4hi
{
	[Serializable]
	public class ParamCompareCondition
	{
		public string _name;

		public ValueComparison _comparison;

		public bool _refBool;

		public int _refInt;

		public float _refFloat;
	}
}

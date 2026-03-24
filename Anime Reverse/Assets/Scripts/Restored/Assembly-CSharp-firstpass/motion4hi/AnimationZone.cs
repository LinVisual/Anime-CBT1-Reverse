using System;
using UnityEngine;

namespace motion4hi
{
	[Serializable]
	public struct AnimationZone
	{
		public Vector2 _timeSpan;

		public string _name;

		public int _nameHash;

		public Vector3 _beginMotionPos;

		public Vector3 _endMotionPos;

		public void Ready()
		{
			_nameHash = Animator.StringToHash(_name);
		}
	}
}

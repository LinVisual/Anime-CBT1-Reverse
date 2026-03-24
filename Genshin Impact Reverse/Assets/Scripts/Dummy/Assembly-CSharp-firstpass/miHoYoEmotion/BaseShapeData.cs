using System.Collections.Generic;
using UnityEngine;

namespace miHoYoEmotion
{
	public abstract class BaseShapeData : ScriptableObject // TypeDefIndex: 6606
	{
		// Fields
		protected Dictionary<string, ShapeElement> _elementDic; // 0x18
	
		// Constructors
		protected BaseShapeData() {} // 0x00000001804C45E0-0x00000001804C45F0
	
		// Methods
		protected void InitElementDic() {} // 0x00000001814DFEC0-0x00000001814DFF20
		public T GetShapeElement<T>(string name)
			where T : ShapeElement, new() => default;
		protected void AddShapeElement(ShapeElement shapeElement) {} // 0x00000001814DFDC0-0x00000001814DFEC0
		public virtual void UpdateElements() {} // 0x00000001814DFF20-0x00000001814DFFC0
	}
}

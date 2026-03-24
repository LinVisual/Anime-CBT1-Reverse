using UnityEngine;

namespace VerletEngine
{
	public struct ComputeThreadTransform
	{
		public Vector3 position; // 0x00
		public Quaternion rotation; // 0x0C
		public Matrix4x4 localToWorldMatrix; // 0x1C
		public Vector3 right; // 0x5C
		public Vector3 up; // 0x68
		public Vector3 forward; // 0x74
		public Vector3 localPosition; // 0x80
	
		// Methods
		public static Vector3 GetMatrixTranslation(Matrix4x4 m) => default; // 0x000000018215C420-0x000000018215C6F0
		public void RefreshByMatrix(Matrix4x4 mat) {} // 0x000000018215C6F0-0x000000018215C970
	}
}

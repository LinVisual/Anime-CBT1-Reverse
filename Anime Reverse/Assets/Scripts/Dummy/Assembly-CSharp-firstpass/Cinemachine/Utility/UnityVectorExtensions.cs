using UnityEngine;

namespace Cinemachine.Utility
{
	public static class UnityVectorExtensions
	{
		public const float Epsilon = 0.0001f;

		//2026.3.26 AM 10:03 Fin.
		public static int PointOnWhichSideOfLineSegment(Vector3 linePoint1, Vector3 linePoint2, Vector3 point)
		{
			Vector3 lineVec = linePoint2 - linePoint1;
			Vector3 linePoint = point - linePoint1;
			if (Vector3.Dot(linePoint, lineVec) <= 0f)
			{
				return 1;
			}
			if (lineVec.magnitude < linePoint.magnitude)
			{
				return 2;
			}
			return 0;
		}

		public static float SignedAngle(Vector3 from, Vector3 to, Vector3 refNormal) => default; // 0x00000001808A9940-0x00000001808A9B70
		public static Vector3 SlerpWithReferenceUp(Vector3 vA, Vector3 vB, float t, Vector3 up) => default; // 0x00000001808A9B70-0x00000001808A9EB0
		public static Vector3 Cartesian2Spherial(Vector3 cPos) => default; // 0x00000001808A8E00-0x00000001808A8F00
		public static Vector3 Spherial2Cartesian(Vector3 sPos) => default; // 0x00000001808A9EB0-0x00000001808A9FD0
	
		// Extension methods
		public static float ClosestPointOnSegment(this Vector3 p, Vector3 s0, Vector3 s1) => default; // 0x00000001808A8F00-0x00000001808A90C0
		public static float ClosestPointOnSegment(this Vector2 p, Vector2 s0, Vector2 s1) => default; // 0x00000001808A90C0-0x00000001808A91F0
		public static Vector3 ProjectOntoPlane(this Vector3 vector, Vector3 planeNormal) => default; // 0x00000001808A9380-0x00000001808A94A0

		//2026.3.26 AM 9:46 Fin.
		public static Vector3 ProjectPointOnLine(this Vector3 point, Vector3 linePoint, Vector3 lineVec)
		{
			return linePoint + (lineVec * Vector3.Dot(point - linePoint, lineVec));
		}

		#warning Just for test. Address: 1808A94A0

		public static Vector3 ProjectPointOnLineSegment(this Vector3 point, Vector3 linePoint1, Vector3 linePoint2)
		{
			Vector3 lineVec = linePoint2 - linePoint1;
			Vector3 projection = point.ProjectPointOnLine(linePoint1, lineVec.normalized);
			int side = PointOnWhichSideOfLineSegment(linePoint1, linePoint2, projection);
			if (side == 1)
			{
				return linePoint1;
			}
			else if (side == 2)
			{
				return linePoint2;
			}
			else
			{
				return projection;
			}
		}

		public static bool AlmostZero(this Vector3 v) => default; // 0x00000001808A8DD0-0x00000001808A8E00
	}
}

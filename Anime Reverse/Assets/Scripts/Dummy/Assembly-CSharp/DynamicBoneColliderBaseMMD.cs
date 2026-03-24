/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DynamicBoneImprove;
using UnityEngine;
using VerletEngine;

// Image 20: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7969-15031

public class DynamicBoneColliderBaseMMD : MonoBehaviour // TypeDefIndex: 14127
{
	// Fields
	public Direction m_Direction; // 0x18
	public Vector3 m_Center; // 0x1C
	public Bound m_Bound; // 0x28

	// Nested types
	public enum Direction // TypeDefIndex: 14128
	{
		X = 0,
		Y = 1,
		Z = 2
	}

	public enum Bound // TypeDefIndex: 14129
	{
		Outside = 0,
		Inside = 1
	}

	// Constructors
	public DynamicBoneColliderBaseMMD() {} // 0x0000000181D126E0-0x0000000181D12760

	// Methods
	public virtual float CollideParticleRotateParent(VerletParticle p, VerletParticle parent, float particleRadius, float angleStep = 1f /* Metadata: 0x0092E21B */, bool childCompensate = false /* Metadata: 0x0092E21F */, MainDirection axis = MainDirection.Y /* Metadata: 0x0092E220 */, bool rotatePositive = true /* Metadata: 0x0092E224 */) => default; // 0x0000000180BF5540-0x0000000180BF5550
	public virtual float CollideLineRotateParent(StaticHorizonLine shl, float particleRadius, float angleStep = 1f /* Metadata: 0x0092E225 */, bool childCompensate = false /* Metadata: 0x0092E229 */, MainDirection axis = MainDirection.Y /* Metadata: 0x0092E22A */, bool rotatePositive = true /* Metadata: 0x0092E22E */) => default; // 0x0000000180BF5540-0x0000000180BF5550
	public virtual void PrepareCollide() {} // 0x00000001802CB650-0x00000001802CB660
	public virtual void CollideParticle(ref Vector3 particlePosition, float particleRadius) {} // 0x00000001802CB650-0x00000001802CB660
	public virtual void CollideParticle(VerletParticle particle, float particleRadius) {} // 0x00000001802CB650-0x00000001802CB660
	public virtual void CollideParticleLine(ref Vector3 particlePosition, ref VerletParticle pParent, float lineRadius) {} // 0x00000001802CB650-0x00000001802CB660
}


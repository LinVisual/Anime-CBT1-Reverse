/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 20: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7969-15031

namespace MoleMole
{
	public abstract class BaseMonoEffect : MonoBehaviour // TypeDefIndex: 10906
	{
		// Fields
		[HideInInspector] // 0x00000001818193F0-0x0000000181819400
		public Transform effectTrans; // 0x18
		public Vector3 OffsetVec3; // 0x20
	
		// Properties
		public uint CGADGNCKJKA { get; set; } // 0x0000000180772BF0-0x0000000180772C00 0x0000000180784970-0x0000000180784980
		public string EDKHAIGCFJC { get; private set; } // 0x00000001802CC420-0x00000001802CC430 0x0000000180300AA0-0x0000000180300AB0
		public string PENHGBLIODD { get; private set; } // 0x00000001806DAB40-0x00000001806DAB50 0x00000001807D2B10-0x00000001807D2B20
		public uint JCFHHPBOHFA { get; private set; } // 0x000000018071C7C0-0x000000018071C880 0x00000001808DEBD0-0x00000001808DEC10
		public Vector3 OKJOBEOIJNH { get; protected set; } // 0x00000001822050F0-0x0000000182205130 0x0000000182205090-0x00000001822050F0
	
		// Constructors
		protected BaseMonoEffect() {} // 0x00000001802D6440-0x00000001802D6450
	
		// Methods
		protected virtual void Awake() {} // 0x00000001802CB650-0x00000001802CB660
		public virtual void Init(string HHOHHADKGML, string DMMJFDHCGCL, uint CGADGNCKJKA, Vector3 EDPFNKJHNOB, Quaternion PAHEEBLCMMM, Vector3 IILLGPHEFFP) {} // 0x0000000182204C90-0x0000000182205090
		public virtual void Setup() {} // 0x00000001802CB650-0x00000001802CB660
		public virtual void Start() {} // 0x00000001802CB650-0x00000001802CB660
		public Vector3 GetPosition() => default; // 0x0000000182036B20-0x0000000182036B70
		public virtual void Update() {} // 0x00000001802CB650-0x00000001802CB660
		public Transform GetAttachPoint(string CHAOIOGLKCP) => default; // 0x0000000180D506C0-0x0000000180D506D0
		protected virtual void OnDestroy() {} // 0x00000001802CB650-0x00000001802CB660
		public virtual bool IsToBeRemove() => default; // 0x00000001800F42E0-0x00000001800F42F0
		public virtual void CheckOwnerVisible() {} // 0x00000001802CB650-0x00000001802CB660
	}
}

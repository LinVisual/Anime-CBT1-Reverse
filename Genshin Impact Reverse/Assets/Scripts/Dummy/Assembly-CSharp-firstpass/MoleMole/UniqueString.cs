/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security;

// Image 19: Assembly-CSharp-firstpass.dll - Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5219-7968

namespace MoleMole
{
	public class UniqueString // TypeDefIndex: 7787
	{
		// Fields
		private static Dictionary<string, string> m_strings; // 0x00
	
		// Constructors
		public UniqueString() {} // 0x00000001802CB2E0-0x00000001802CB2F0
		static UniqueString() {} // 0x0000000180CA3D90-0x0000000180CA3DF0
	
		// Methods
		public static string Intern(string str, bool removable = true /* Metadata: 0x00922FD6 */) => default; // 0x0000000180CA3B00-0x0000000180CA3CC0
		public static void InternString(ref string inString, bool removable = true /* Metadata: 0x00922FD7 */) {} // 0x0000000180CA3A80-0x0000000180CA3B00
		public static void InternStringArray(string[] inStringArray, bool removable = true /* Metadata: 0x00922FD8 */) {} // 0x0000000180CA38D0-0x0000000180CA39C0
		public static void InternStringList(List<string> inStringArray) {} // 0x0000000180CA39C0-0x0000000180CA3A80
		public static string IsInterned(string str) => default; // 0x0000000180CA3CC0-0x0000000180CA3D90
		public static void Clear() {} // 0x0000000180CA37E0-0x0000000180CA38D0
	}
}

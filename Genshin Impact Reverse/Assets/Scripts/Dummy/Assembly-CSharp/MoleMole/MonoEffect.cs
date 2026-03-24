/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MoleMole.Config;
using UnityEngine;

// Image 20: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7969-15031

namespace MoleMole
{
	public class MonoEffect : BaseMonoEffect // TypeDefIndex: 10914
	{
		// Fields
		public float duration; // 0x48
		//private HODHNNHLEAF IAEFHLGLNCI; // 0x50
		//public Bounds bounds; // 0x58
		//private BaseMonoEffectPlugin[] KEHPDJGAIMP; // 0x70
		private ParticleSystem KDIHKDKEHHO; // 0x78
		private ParticleSystem[] NJNIBOBLPEO; // 0x80
		private ParticleSystemRenderer[] CIEJBBDCLMG; // 0x88
		private Animation[] NMIKFHHJCFK; // 0x90
		private Animator[] CBLFOBPHHKD; // 0x98
		private TrailRenderer[] ICGLIOGMPEH; // 0xA0
		private MeshRenderer[] JLADMCHHLII; // 0xA8
		private bool[] OIKBGPAIMJI; // 0xB0
		private SkinnedMeshRenderer[] MAHKOHEBEIH; // 0xB8
		private bool[] AKMNJINMKID; // 0xC0
		private float HFADFFCCKHI; // 0xC8
		private bool KNFCGMKHGCL; // 0xCC
		private bool IPAKOBHJCHJ; // 0xCD
		private bool EJBINAOOLAM; // 0xCE
		public bool tickWentCold; // 0xCF
		// [Header] // 0x0000000181853640-0x0000000181853670
		public bool dontDestroyWhenOwnerEvade; // 0xE8
		[NonSerialized]
		public bool disableGORecursively; // 0xE9
		public bool IgnoreTimescale; // 0xEA
		// [Header] // 0x00000001818536F0-0x0000000181853720
		public ParticleSystemRenderer[] ClearEffectWhenDestroy; // 0xF0
		// [Header] // 0x0000000181853720-0x0000000181853750
		public bool destroyImmediatelyIfSetDestroy; // 0xF8
		[NonSerialized]
		public string belongSkillName; // 0x100
		// [Header] // 0x00000001818538A0-0x00000001818538D0
		public bool disableIfOwnerIsInvisible; // 0x108
		// [Header] // 0x00000001818539C0-0x00000001818539F0
		public bool setDestroyOnDisabled; // 0x109
		// [Header] // 0x0000000181853A20-0x0000000181853A50
		public float delayDestory; // 0x10C
		//private HODHNNHLEAF KLIBCIOIFIL; // 0x110
		// [Header] // 0x0000000181853AD0-0x0000000181853B00
		public bool stopAllOnSetDestory; // 0x118
		// [Header] // 0x0000000181853B30-0x0000000181853B60
		public float particleRemainingLifetime; // 0x11C
		// [Header] // 0x0000000181853BE0-0x0000000181853C10
		public NBCHMCLHNCN elementViewShowType; // 0x120
		// [Header] // 0x0000000181853D40-0x0000000181853D70
		public ElementType elementViewElementType; // 0x124
		private const int GOAFMPKJEFH = 1000; // Metadata: 0x00927E58
		private static ParticleSystem.Particle[] ODKOENOJJEL; // 0x00
		private MaterialPropertyBlock KONCJILPDDF; // 0x138
		private static int GKPNFBJIBLF; // 0x08
		private int GCCEODKIDFM; // 0x140
		private int KMEFDFLDDFC; // 0x144
		private bool DOEKFHOBKKI; // 0x148
		private BDLHMKLBJBM[] ANJPFJIIFAB; // 0x150
	
		// Properties
		//public BMNJPBPOMPA LEFOPAJFFBE { get => default; private set {} } // 0x00000001804D3670-0x00000001804D3680 0x00000001802D2C60-0x00000001802D2C70
		//public BMNJPBPOMPA EHFFEFLFCLI { get => default; private set {} } // 0x00000001804C1540-0x00000001804C1550 0x00000001804C2810-0x00000001804C2820
		public Transform FJIOMIPEEOF { get => default; private set {} } // 0x00000001804C1160-0x00000001804C1170 0x00000001804C1810-0x00000001804C1820
		public ParticleSystem FLLKCKAGCCA { get => default; } // 0x0000000180729330-0x0000000180729340 
		public Vector3 AIBGGFOLGPG { get => default; private set {} } // 0x0000000182048BD0-0x0000000182048BF0 0x0000000182046E50-0x0000000182046E70
		public float HOKPOAOGPJI { get => default; } // 0x0000000182048AF0-0x0000000182048BD0 
	
		// Nested types
		public enum NBCHMCLHNCN // TypeDefIndex: 10915
		{
			AlwaysShow = 0,
			OnlyShowInElementView = 1,
			OnlyShowInNotElementView = 2
		}
	
		private struct BDLHMKLBJBM // TypeDefIndex: 10916
		{
			// Fields
			public float OLDIDMAKMJL; // 0x00
		}
	
		// Constructors
		public MonoEffect() {} // 0x0000000182048AD0-0x0000000182048AF0
		static MonoEffect() {} // 0x0000000182048A50-0x0000000182048AD0
	
		// Methods
		protected override void Awake() {} // 0x00000001820460E0-0x00000001820466C0
		private void OnValidate() {} // 0x0000000182047570-0x00000001820475E0
		public override void Setup() {} // 0x0000000182048480-0x0000000182048900
		//public void SetOwner(BMNJPBPOMPA LEFOPAJFFBE) {} // 0x0000000182048200-0x0000000182048260
		public void SetFromIndexed(bool JOPIMNHMDGF) {} // 0x0000000182047D40-0x0000000182047D50
		public void SetFollowParent(Transform PJCAKLEMPAI) {} // 0x00000001804C1810-0x00000001804C1820
		public void SetTargetPos(Vector3 GCCCGGKKCPF) {} // 0x0000000182046E50-0x0000000182046E70
		public void SetupPlugin() {} // 0x00000001820483C0-0x0000000182048480
		//public void SetupPluginFromTo(BMNJPBPOMPA EHFFEFLFCLI) {} // 0x0000000182048310-0x00000001820483C0
		public override void Update() {} // 0x0000000182048900-0x0000000182048A50
		public void SetMaterialFloat(int OBDGBPBNMNM, float MHOOLBMGPFL) {} // 0x0000000182047E10-0x0000000182048200
		private void INDHJMNFOEK() {} // 0x0000000182046A80-0x0000000182046C10
		private void IIFECFNGPJO(float IDENMCLPDKB) {} // 0x00000001820467F0-0x0000000182046A80
		private void GIIGLCLKIJL(bool OGNEBLLLAPF) {} // 0x00000001820466C0-0x00000001820467F0
		private void ANDJJMCGKCB(bool OGNEBLLLAPF) {} // 0x0000000182045E80-0x00000001820460E0
		private void MDMDONAOPDK() {} // 0x0000000182046E70-0x00000001820471A0
		public override bool IsToBeRemove() => default; // 0x0000000182046C30-0x0000000182046E30
		public void SetDestroy() {} // 0x0000000182047830-0x0000000182047D40
		protected override void OnDestroy() {} // 0x0000000182047460-0x0000000182047470
		public void SetDestroyImmediately() {} // 0x00000001820476C0-0x0000000182047830
		public bool IsActive() => default; // 0x0000000182046C10-0x0000000182046C20
		public bool IsValid() => default; // 0x0000000182046E30-0x0000000182046E50
		public bool IsDestroying() => default; // 0x0000000182046C20-0x0000000182046C30
		private void OnDisable() {} // 0x0000000182047470-0x0000000182047570
		public ParticleSystem[] GetAllParticleSystems() => default; // 0x000000018050B230-0x000000018050B240
		public ParticleSystemRenderer[] GetAllParticleSystemsRenderer() => default; // 0x00000001804F7080-0x00000001804F7090
		public void Pause(bool IDJGKMMGEOI) {} // 0x00000001820475E0-0x00000001820476C0
		public void SetVisible(bool IDJGKMMGEOI) {} // 0x0000000182048260-0x0000000182048310
		public void SetGameObjectActive(bool OGNEBLLLAPF, bool GHGKFIKAJOF) {} // 0x0000000182047D50-0x0000000182047E10
		private void NILFMOBPCBF(float CHPOPAICGMA) {} // 0x00000001820471A0-0x0000000182047460
	}
}

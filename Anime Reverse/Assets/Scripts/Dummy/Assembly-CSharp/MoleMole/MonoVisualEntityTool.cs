using miHoYoEmotion;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace MoleMole
{
	[ExecuteInEditMode]
	public class MonoVisualEntityTool : MonoBehaviour
	{
		// Fields
		[HideInInspector] // 0x00000001818193F0-0x0000000181819400
		public NamedTransform[] transforms; // 0x18
		[HideInInspector] // 0x00000001818193F0-0x0000000181819400
		public NamedTransform[] hitObjectList; // 0x20
		private Dictionary<string, Transform> HDHCECNENGK; // 0x28
		private Renderer[] JKJLELJCBGI; // 0x30
		[HideInInspector] // 0x00000001818193F0-0x0000000181819400
		public RendererInfo[] rendererInfos; // 0x38
		[HideInInspector] // 0x00000001818193F0-0x0000000181819400
		private List<Collider> ILBHBKJNCOP; // 0x40
		public NamedCollider[] hitBoxes; // 0x48
		[NonSerialized]
		public bool complexHitBox; // 0x50
		[HideInInspector] // 0x00000001818193F0-0x0000000181819400
		public NamedTransform[] pushColliders; // 0x58
		public float shoesOffset; // 0x60
		public float characterPushCollisionRadius; // 0x64
		[NonSerialized]
		[HideInInspector] // 0x00000001818193F0-0x0000000181819400
		public List<MonoEffect> attachedAnimatorEffects; // 0x68
		private EmoSync CDANCNEGICA; // 0x70
		private EyeCtrl MHPLDHDJEPI; // 0x78
		private EyeKey DLGIEGOLDJJ; // 0x80

		// Properties
		public Renderer[] EMNJEEMOOEM { get => default; } // 0x000000018219E030-0x000000018219E170 
		public EmoSync HBJFMNIMLFF { get => default; } // 0x0000000180729320-0x0000000180729330 
		public EyeCtrl DFDBLPNIKBP { get => default; } // 0x0000000180729330-0x0000000180729340 
		public EyeKey HNPKFMBHAKC { get => default; } // 0x000000018050B230-0x000000018050B240 
		public Renderer AJKHBIMLOFJ { get => default; private set { } } // 0x00000001804F7080-0x00000001804F7090 0x00000001804F7220-0x00000001804F7230

		// Constructors
		public MonoVisualEntityTool() {} // 0x000000018219DFB0-0x000000018219E030
	
		// Methods
		public bool HasHeadBox(Collider BEKMKGLIAEC) => default; // 0x000000018219D540-0x000000018219D5A0
		public void EnableAutoEmotion(bool MHOOLBMGPFL) {} // 0x000000018219C500-0x000000018219C630
		public void Start() {} // 0x000000018219DD40-0x000000018219DFB0
		public bool IsRendering() => default; // 0x000000018219D7C0-0x000000018219D880
		private void NDPFBLPOEJB() {} // 0x000000018219D880-0x000000018219DB00
		private Renderer BPCOKFFAPMI() => default; // 0x000000018219C330-0x000000018219C500
		public void InitMonoRef() {} // 0x000000018219D5A0-0x000000018219D610
		private void JCJOHFHBNME<T>(T[] GOPHEBPAJLD, out Dictionary<string, T> MJPKPKIDDDE)
			where T : UnityEngine.Object {
			MJPKPKIDDDE = default;
		}
		private T HGNPJCGAAGG<T>(string DHHCEJMJLDP, Dictionary<string, T> MJPKPKIDDDE)
			where T : UnityEngine.Object => default;
		public Transform GetTransformByName(string CHAOIOGLKCP) => default; // 0x000000018219D400-0x000000018219D540
		public Transform GetDynamicTransform(string CHAOIOGLKCP) => default; // 0x000000018219CAF0-0x000000018219CB60
		public void SetDynamicTransformPos(string CHAOIOGLKCP, Vector3 HIBMCEDBNGN) {} // 0x000000018219DB00-0x000000018219DCA0
		private Transform GIEOJNGEOHG(string CHAOIOGLKCP) => default; // 0x000000018219C630-0x000000018219C740
		public Transform GetHitObjectListByName(uint NLNDLEALHLG) => default; // 0x000000018219D1A0-0x000000018219D200
		public Renderer GetRendereByName(string CHAOIOGLKCP) => default; // 0x000000018219D2F0-0x000000018219D400
		//public Collider[] GetPushColliderByName(string CHAOIOGLKCP) => default; // 0x000000018219D200-0x000000018219D2F0
		//public NamedCollider GetHitBoxByName(string CHAOIOGLKCP) => default; // 0x000000018219CD00-0x000000018219CDE0
		//public NamedCollider GetHitBoxByIndex(uint NLNDLEALHLG) => default; // 0x000000018219CC90-0x000000018219CD00
		//public NamedCollider GetHitBoxByCollder(Collider OPKJKBKAFMH) => default; // 0x000000018219CB60-0x000000018219CC90
		//public HitColliderType GetHitColliderType(Collider OPKJKBKAFMH, ref int GCNIMHDPCOL) => default; // 0x000000018219CF50-0x000000018219D1A0
		//public Collider GetHitColliderByTypeAndIndex(HitColliderType PHDJOJFOAJF, int GCNIMHDPCOL) => default; // 0x000000018219CDE0-0x000000018219CF50
		public bool IsAnyRenderersVisible() => default; // 0x000000018219D6B0-0x000000018219D7C0
		public bool IsAllRenderersVisible() => default; // 0x000000018219D610-0x000000018219D6B0
		public void SetRenderersVisible(bool LEPKGLPHHKF) {} // 0x000000018219DCA0-0x000000018219DD40
		public Bounds? GetBounds() => default; // 0x000000018219C740-0x000000018219CAF0
	}
}

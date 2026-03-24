/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using UnityEngine;

// Image 20: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7969-15031

namespace MoleMole
{
	public static class Miscs // TypeDefIndex: 14236
	{
		// Fields
		public static int[] EMPTY_INTS; // 0x00
		public static string[] EMPTY_STRINGS; // 0x08
		private static RaycastHit[] raycastHits; // 0x10
		public static Camera _mainCamera; // 0x18
		private static Camera _mainCanvasCamera; // 0x20
		public static System.Random ranSystem; // 0x28
		private static int _staticSceneLayerMask; // 0x30
		private static int _sceneLayerMask; // 0x34
		private static int _sceneTriggerLayerMask; // 0x38
		private static int _sceneLayerMaskWithWater; // 0x3C
		private static int _groundLayerMaskWithoutTemp; // 0x40
		private static int _bulletHitLayerMask; // 0x44
		private static int _characterLayerMask; // 0x48
		private static string postfix; // 0x50
		private static string origin_postfix; // 0x58
		private static string subName; // 0x60
		private static string subFullName; // 0x68
		private static string subVFullName; // 0x70
		private static string subAniFullName; // 0x78
		private static string commonOutputPattern; // 0x80
		private static string anyPattern; // 0x88
		private static string cutsceneFilePattern; // 0x90
		private static string cameraAniFilePattern; // 0x98
		private static string emotionFilePattern; // 0xA0
		private static string assetPattern; // 0xA8
		public const string BULLET_AIM_POS_GLOBAL_VALUE_KEY = "BulletAimPos"; // Metadata: 0x0092E52B
		//private static ConfigChannel _configChannel; // 0xB0
		public static Dictionary<int, string> DeviceGenerationName; // 0xB8

		//OK
		public static Camera mainCamera
		{
			get
			{
				if (mainCamera == null)
				{
					return Camera.main;
				}
				return _mainCamera;
			}
			set
			{
				_mainCamera = value;
			}
		}
			
		public static Camera mainCanvasCamera { get; set; } // 0x0000000181E310D0-0x0000000181E31130 0x0000000181E31230-0x0000000181E31290
	
		// Nested types
		public enum VersionStringType // TypeDefIndex: 14237
		{
			Full = 0,
			Project = 1,
			Resource = 2
		}
	
		public enum ChangeAvatarFailType // TypeDefIndex: 14238
		{
			NONE = 0,
			FAIL_AIM = 1,
			FAIL_CLIMB = 2,
			FAIL_FLY = 3,
			FAIL_JUMP = 4,
			FAIL_LADDER = 5,
			FAIL_SWIM = 6,
			FAIL_IN_PROCESS = 7,
			FAIL_LEVEL_FORBIDDEN = 8,
			FAIL_TARGETAVATAR = 9,
			FAIL_PERFORM = 10
		}
	
		public struct ScopeUnityProfilerSample : IDisposable // TypeDefIndex: 14239
		{
			// Constructors
			public ScopeUnityProfilerSample(string sampleName) {} // 0x00000001802CB650-0x00000001802CB660
	
			// Methods
			public void Dispose() {} // 0x00000001802CB650-0x00000001802CB660
		}
	
		public enum ServerType // TypeDefIndex: 14240
		{
			None = 0,
			USA = 1,
			EUR = 2
		}
	
		// Constructors
		static Miscs() {} // 0x0000000181E30C20-0x0000000181E31000

		// Methods
		//public static void ParseEffectCreation(ConfigEffectPattern patternConfig) {} // 0x0000000181E2D4F0-0x0000000181E2D650
		//private static EffectCreationOp ParseFromEffectCreationOpEntry(EffectCreationOpEntry opEntry) => default; // 0x0000000181E2D650-0x0000000181E2D810
		//public static ConfigEffectPatternFullInspector ConvertToEffectPatternFullInspector(ConfigEffectPattern patternConfig) => default; // 0x0000000181E1C220-0x0000000181E1C870
		//public static ConfigEffectPattern ConvertToEffectPattern(ConfigEffectPatternFullInspector patternConfigFI) => default; // 0x0000000181E1C870-0x0000000181E1C8F0
		//public static void ConvertToEffectPattern(ConfigEffectPatternFullInspector patternConfigFI, ConfigEffectPattern config) {} // 0x0000000181E1C8F0-0x0000000181E1CFF0
		//public static Collider GetColliderFromGameObjectByLayer(GameObject gameObject, int layer) => default; // 0x0000000181E261C0-0x0000000181E262A0
		//public static BMNJPBPOMPA GetEntityFromGameObejct(GameObject gameObject) => default; // 0x0000000181E27910-0x0000000181E27A30
		//public static float DistanceXZSquare(Vector3 pos1, Vector3 pos2) => default; // 0x0000000181E1D170-0x0000000181E1D1A0
		//public static float CalcCurrentGroundHeight(float x, float z) => default; // 0x0000000181E190E0-0x0000000181E191B0
		//public static float CalcCurrentWaterHeight(float x, float z) => default; // 0x0000000181E19990-0x0000000181E19A60
		//public static float CalcCurrentGroundWaterHeight(float x, float z) => default; // 0x0000000181E19820-0x0000000181E198F0
		//public static float CalcCurrentHeightByLayer(float x, float z, int layer) => default; // 0x0000000181E198F0-0x0000000181E19990
		//public static float CalcCurrentGroundHeight(float x, float z, float rayStartHeight, float rayDetectLength, int layer) => default; // 0x0000000181E191B0-0x0000000181E193C0
		//public static bool RaycastTest(Ray ray, float detectLength, out Vector3 normal, out Vector3 hitPoint, out float hitDistance, int layermask, Color color, bool drawLine = false /* Metadata: 0x0092E4FC */) {
		//	normal = default;
		//	hitPoint = default;
		//	hitDistance = default;
		//	return default;
		//} // 0x0000000181E2DFA0-0x0000000181E2E0E0
		//public static bool RaycastTest(Ray ray, float detectLength, out Vector3 normal, out Vector3 hitPoint, out float hitDistance, out int hitTriangleIndex, int layermask, Color color, bool drawLine = false /* Metadata: 0x0092E4FD */) {
		//	normal = default;
		//	hitPoint = default;
		//	hitDistance = default;
		//	hitTriangleIndex = default;
		//	return default;
		//} // 0x0000000181E2E2C0-0x0000000181E2E3F0
		//public static bool RaycastTest(Ray ray, float detectLength, out Vector3 normal, out Vector3 hitPoint, out float hitDistance, out int hitTriangleIndex, out Collider collider, int layermask, Color color, float drawDuration = 0f /* Metadata: 0x0092E4FE */) {
		//	normal = default;
		//	hitPoint = default;
		//	hitDistance = default;
		//	hitTriangleIndex = default;
		//	collider = default;
		//	return default;
		//} // 0x0000000181E2E0E0-0x0000000181E2E2C0
		//public static int RaycastAllTest(Ray ray, float detectLength, out RaycastHit[] raycastHitsOut, int layermask, Color color, float drawDuration = 0f /* Metadata: 0x0092E502 */) {
		//	raycastHitsOut = default;
		//	return default;
		//} // 0x0000000181E2DED0-0x0000000181E2DFA0
		//public static Vector3 CalcCurrentGroundNorm(Vector3 pos) => default; // 0x0000000181E193C0-0x0000000181E19820
		//public static T GetLogicComponentFromEntity<T>(uint runtimeID)
		//	where T : LCBase => default;
		//public static T GetVisualComponentFromEntity<T>(uint runtimeID)
		//	where T : BEMIFOMEEMM => default;
		//public static void ParseAnimatorEventEntry(ConfigAnimatorEventPattern patternConfig) {} // 0x0000000181E2D420-0x0000000181E2D4F0
		//public static AnimatorEventEntry[] ConvertToAnimatorEventEntries(AnimatorEvent[] animatorEvents) => default; // 0x0000000181E1BAC0-0x0000000181E1BC00
		//public static AnimatorEvent[] ConvertToAnimatorEvents(AnimatorEventEntry[] entries) => default; // 0x0000000181E1C0F0-0x0000000181E1C220
		//public static ConfigAnimatorEventPattern ConvertToAnimatorEventPattern(ConfigAnimatorEventPatternFullInspector animatorEventPatternFI) => default; // 0x0000000181E1BE40-0x0000000181E1BEC0
		//public static void ConvertToAnimatorEventPattern(ConfigAnimatorEventPatternFullInspector animatorEventPatternFI, ConfigAnimatorEventPattern config) {} // 0x0000000181E1BEC0-0x0000000181E1C0F0
		//public static ConfigAnimatorEventPatternFullInspector ConvertToAnimatorEventPatternFullInspector(ConfigAnimatorEventPattern patternConfig) => default; // 0x0000000181E1BC00-0x0000000181E1BE40
		//public static Proto.Vector ToProto(Vector3 refVec, Proto.Vector protoVec) => default; // 0x0000000181E30960-0x0000000181E30A00
		//public static Dictionary<TKey, TValue> FromPbcMapToDictionary<TKey, TValue>(MapField<TKey, TValue> pbcMap) => default;
		//public static List<T> SampleList<T>(List<T> input, int num) => default;
		//public static List<T> ListRandom<T>(List<T> myList) => default;
		//public static Vector2 GetXZ(Vector3 vec) => default; // 0x0000000180EB73A0-0x0000000180EB73D0
		//public static float GetLerpRatioValue(float value, float lastValue) => default; // 0x0000000181E288F0-0x0000000181E28910
		//public static float GetEuler0To360(float value) => default; // 0x0000000181E27A30-0x0000000181E27A60
		//public static float Lerp(float v1, float v2, float speed) => default; // 0x0000000181E2D1F0-0x0000000181E2D2C0
		//public static int ArrayRefCountOf<T>(T[] arr, T element)
		//	where T : class => default;
		//public static string GetGadgetName(BMNJPBPOMPA entity) => default; // 0x0000000181E27B80-0x0000000181E27C50
		//public static string GetGadgetInteractionTitle(BMNJPBPOMPA entity) => default; // 0x0000000181E27A60-0x0000000181E27B80
		//public static uint GetTimeStampFromDateTime(DateTime datetime) => default; // 0x0000000181E2C6F0-0x0000000181E2C7C0
		//public static DateTime GetDateTimeFromTimeStamp(uint timeStamp) => default; // 0x0000000181E273D0-0x0000000181E27460
		//public static DateTime GetDateTimeFromMilliTimeStamp(ulong timeStamp) => default; // 0x0000000181E27330-0x0000000181E273D0
		//public static string GetTransformPath(Transform trans, Transform parent = null) => default; // 0x0000000181E2C7C0-0x0000000181E2C830
		//public static bool ArrayContains<T>(T[] array, T element) => default;
		//public static string GetDebugAbilityEntityName(NKAAOMEOOHM lcAbility) => default; // 0x0000000181E27460-0x0000000181E27630
		//public static void InitLayerMask() {} // 0x0000000181E2CAF0-0x0000000181E2CCC0
		//public static bool IsHitScene(int layer) => default; // 0x0000000181E2CE30-0x0000000181E2CEA0
		//public static bool IsNoClimbTag(Collider col, int triangleIndex) => default; // 0x0000000181E2CF00-0x0000000181E2CFA0
		//public static bool IsHitEntity(int layer) => default; // 0x0000000181E2CDD0-0x0000000181E2CE30
		//public static int GetHitLayerMask() => default; // 0x0000000181E28730-0x0000000181E28790
		//public static int GetSceneLayerMask() => default; // 0x0000000181E2C370-0x0000000181E2C3D0
		//public static int GetStaticSceneLayerMask() => default; // 0x0000000181E2C440-0x0000000181E2C4A0
		//public static int GetHitSceneLayerMask() => default; // 0x0000000181E28790-0x0000000181E287F0
		//public static EFENMJAKINM GetSceneObjTag(Collider col, int triangleIndex) => default; // 0x0000000181E2C3D0-0x0000000181E2C400
		//public static int GetWaterLayerMask() => default; // 0x0000000181E2CA90-0x0000000181E2CAF0
		//public static int GetSceneGroundLayerMask() => default; // 0x0000000181E2C310-0x0000000181E2C370
		//public static int GetSceneGroundLayerMaskWithoutTemp() => default; // 0x0000000181E2C2B0-0x0000000181E2C310
		//public static int GetCameraLayerMask() => default; // 0x0000000181E26100-0x0000000181E26160
		//public static int GetIKSceneLayerMask() => default; // 0x0000000181E287F0-0x0000000181E28850
		//public static int GetCharacterLayerMask() => default; // 0x0000000181E26160-0x0000000181E261C0
		//public static int GetBulletHitLayerMask() => default; // 0x0000000181E260A0-0x0000000181E26100
		//public static float ProtoInt2Float(PropValue propValue) => default; // 0x0000000181E2DD70-0x0000000181E2DDF0
		//public static float ProtoLong2Float(long value, uint type) => default; // 0x0000000181E2DDF0-0x0000000181E2DE30
		//public static float FightProtoInt2Float(PropValue propValue) => default; // 0x0000000181E1D2F0-0x0000000181E1D460
		//public static int ProtoFloat2Int(float num, PropType type) => default; // 0x0000000181E2DD40-0x0000000181E2DD70
		//public static FightPropType ElemTypeToProto(ElementType type) => default; // 0x0000000181E1D280-0x0000000181E1D2F0
		//public static FightPropType ElemTypeToProtoMax(ElementType type) => default; // 0x0000000181E1D210-0x0000000181E1D280
		//public static ElementType ProtoToElemType(FightPropType type) => default; // 0x0000000181E2DE30-0x0000000181E2DED0
		//public static bool IsEnergyType(FightPropType type) => default; // 0x0000000181E2CD50-0x0000000181E2CDD0
		//public static int ProtoFloat2Int(float num, FightPropType type) => default; // 0x0000000181E2DC10-0x0000000181E2DD40
		//public static bool IsValidPath(string assetPath) => default; // 0x0000000181E2D0E0-0x0000000181E2D1F0
		//private static bool CheckAssetPattern(string assetPath) => default; // 0x0000000181E1A850-0x0000000181E1AB90
		//private static string GetCommonPattern(string name, bool hasAni = true /* Metadata: 0x0092E506 */) => default; // 0x0000000181E262A0-0x0000000181E27160
		//private static string GenerateAniamtionPattern(string ppf, string animn) => default; // 0x0000000181E1D8B0-0x0000000181E1EDC0
		//private static string GenerateOriginPattern() => default; // 0x0000000181E1EDC0-0x0000000181E22650
		//private static string GetPrefabPattern(string name) => default; // 0x0000000181E2BF80-0x0000000181E2C1D0
		//private static string GetAvatarEquipPattern(string name) => default; // 0x0000000181E25830-0x0000000181E25E80
		//private static string GenerateStreamPattern() => default; // 0x0000000181E22650-0x0000000181E25830
		//public static string CheckAbilityTalentConfigs() => default; // 0x0000000181E1A0B0-0x0000000181E1A850
		//private static void CheckUnlockTalentParamInAbility(ConfigAbility ability, HashSet<string> validTalentParams, StringBuilder errorLog) {} // 0x0000000181E1ABC0-0x0000000181E1AF20
		//private static void CheckUnlockTalentParamInMixins(string abilityName, ConfigAbilityMixin[] mixins, HashSet<string> validTalentParams, StringBuilder errorLog) {} // 0x0000000181E1B0A0-0x0000000181E1B3B0
		//private static void CheckUnlockTalentParamInModifier(string abilityName, ConfigAbilityModifier modifier, HashSet<string> validTalentParams, StringBuilder errorLog) {} // 0x0000000181E1B3B0-0x0000000181E1B560
		//private static void CheckUnlockTalentParamInActions(string abilityName, ConfigAbilityAction[] actions, HashSet<string> validTalentParams, StringBuilder errorLog) {} // 0x0000000181E1AF20-0x0000000181E1B0A0
		//private static void CheckUnlockTalentParamInPredicates(string abilityName, ConfigAbilityPredicate[] predicates, HashSet<string> validTalentParams, StringBuilder errorLog) {} // 0x0000000181E1B560-0x0000000181E1B940
		//public static float ComputeElemBallEnergy(uint configID, float energy) => default; // 0x0000000181E1B940-0x0000000181E1BAC0
		//private static NKAAOMEOOHM CheckAbilityComAvailable(NKAAOMEOOHM target, bool includeGhost = false /* Metadata: 0x0092E507 */) => default; // 0x0000000181E1A070-0x0000000181E1A0B0
		//private static BMNJPBPOMPA CheckEntityAvailable(BMNJPBPOMPA target, bool includeGhost = false /* Metadata: 0x0092E508 */) => default; // 0x0000000181E1AB90-0x0000000181E1ABC0
		//public static NKAAOMEOOHM[] FilterTargetArray(NKAAOMEOOHM[] targets, bool includeGhost = false /* Metadata: 0x0092E509 */) => default; // 0x0000000181E1D460-0x0000000181E1D550
		//public static void SelectShapeTargets(SelectTargetsByShape selectTargets, OGJBBKKADFE instancedAbility, MEIICGMHLBC instancedModifier, NKAAOMEOOHM self, BMNJPBPOMPA other, out List<BBJGKGAKDOP.IFHHNCJOLCP> outTargetLs) {
		//	outTargetLs = default;
		//} // 0x0000000181E2FA20-0x0000000181E307E0
		//public static void SelectEquipTargets(SelectTargetsByEquipParts selectEquipTargets, NKAAOMEOOHM self, out List<BBJGKGAKDOP.IFHHNCJOLCP> outTargetLs) {
		//	outTargetLs = default;
		//} // 0x0000000181E2ECF0-0x0000000181E2EF30
		//public static void SelectChildrenTargets(SelectTargetsByChildren selectEquipTargets, BMNJPBPOMPA entity, out List<BBJGKGAKDOP.IFHHNCJOLCP> outTargetLs) {
		//	outTargetLs = default;
		//} // 0x0000000181E2E6A0-0x0000000181E2ECF0
		//public static void SelectNormalTarget(AbilityTargetting selectTarget, NKAAOMEOOHM self, OGJBBKKADFE instancedAbility, MEIICGMHLBC instancedModifier, BMNJPBPOMPA other, out BBJGKGAKDOP.IFHHNCJOLCP outTarget, out List<BBJGKGAKDOP.IFHHNCJOLCP> outTargetLs) {
		//	outTarget = default;
		//	outTargetLs = default;
		//} // 0x0000000181E2EF30-0x0000000181E2F650
		//public static void SelectPredicateTarget(AbilityTargetting selectTarget, BMNJPBPOMPA target, BMNJPBPOMPA self, OGJBBKKADFE instancedAbility, MEIICGMHLBC instancedModifier, ref BMNJPBPOMPA outTarget) {} // 0x0000000181E2F650-0x0000000181E2FA20
		//public static void GetPositionByBornType(ConfigBornType configBornType, OGJBBKKADFE instancedAbility, MEIICGMHLBC instancedModifier, DAKBHIEBBNM evt, BMNJPBPOMPA targetEntity, BBJGKGAKDOP.IFHHNCJOLCP? attackTarget, BMNJPBPOMPA selfEntity, out Vector3 bornPos, out Quaternion bornRot) {
		//	bornPos = default;
		//	bornRot = default;
		//} // 0x0000000181E28EB0-0x0000000181E2BF80
		//public static Vector3? GetBulletAimPosOnTarget(BMNJPBPOMPA entity) => default; // 0x0000000181E25E80-0x0000000181E260A0
		//public static WWWForm CreateWWWForm(Dictionary<string, string> formDict) => default; // 0x0000000181E1CFF0-0x0000000181E1D170
		//[DebuggerHidden] // 0x0000000181819400-0x0000000181819410
		//public static IEnumerator WWWRequestWithTimeOut(string url, Action<string> callback, Action timeOutCallback, float timeoutSecond = 5f /* Metadata: 0x0092E50A */, byte[] postData = null, Dictionary<string, string> headers = null, Dictionary<string, string> formDict = null, bool needDispose = true /* Metadata: 0x0092E50E */) => default; // 0x0000000181E30B70-0x0000000181E30C20
		//[DebuggerHidden] // 0x0000000181819400-0x0000000181819410
		//public static IEnumerator WWWRequestWithRetry(string url, Action<string> callback, Action timeOutCallback, byte[] postData = null, Dictionary<string, string> headers = null, Dictionary<string, string> formDict = null, float timeoutSecond = 5f /* Metadata: 0x0092E50F */, int retryTime = 3 /* Metadata: 0x0092E513 */) => default; // 0x0000000181E30A00-0x0000000181E30AB0
		//[DebuggerHidden] // 0x0000000181819400-0x0000000181819410
		//public static IEnumerator WWWRequestWithRetry(List<string> urlList, Action<string> callback, Action timeOutCallback, byte[] postData = null, Dictionary<string, string> headers = null, Dictionary<string, string> formDict = null, float timeoutSecond = 5f /* Metadata: 0x0092E517 */, int retryTime = 3 /* Metadata: 0x0092E51B */, Action<string> updateServerUrl = null) => default; // 0x0000000181E30AB0-0x0000000181E30B70
		//public static string GetP4Version(VersionStringType type = VersionStringType.Full /* Metadata: 0x0092E51F */) => default; // 0x0000000181E28910-0x0000000181E28EB0
		//public static string GetGameVersion() => default; // 0x0000000181E27C50-0x0000000181E27D60
		//public static T GetPrivateProperty<T>(object instance, string propertyname) => default;
		//public static T GetPrivateField<T>(object instance, string fieldname) => default;
		//public static T CallPrivateMethod<T>(object instance, string name, params /* 0x00000001818193F0-0x0000000181819400 */ object[] param) => default;
		//public static bool CanChangeAvatarEntity(DCCIGJNFLEO entity, uint configId, ref ChangeAvatarFailType failType) => default; // 0x0000000181E19D40-0x0000000181E1A070
		//public static void ShowChangeAvatarFailMessage(ChangeAvatarFailType failType) {} // 0x0000000181E30850-0x0000000181E30960
		//public static bool IsMale(BodyType type) => default; // 0x0000000181E2CEA0-0x0000000181E2CEC0
		//public static bool ShouldUseMPAbility(BMNJPBPOMPA entity) => default; // 0x0000000181E307E0-0x0000000181E30850
		//public static BMNJPBPOMPA GetValidEntity(uint runtimeID) => default; // 0x0000000181E2C9F0-0x0000000181E2CA90
		//public static OGJBBKKADFE GetInstancedAbility(BMNJPBPOMPA entity, uint instancedAbilityId) => default; // 0x0000000181E28850-0x0000000181E288A0
		//public static MEIICGMHLBC GetInstancedModifier(BMNJPBPOMPA entity, int instancedModifierId) => default; // 0x0000000181E288A0-0x0000000181E288F0
		//public static bool IsAvatarRangeAttack(DCCIGJNFLEO entity) => default; // 0x0000000181E2CCC0-0x0000000181E2CD50
		//public static bool IsModifierMuteRemote(BMNJPBPOMPA entity, ConfigAbilityModifier modifierConfig) => default; // 0x0000000181E2CEC0-0x0000000181E2CF00
		//public static void ForceReplaceAvatarPos(BMNJPBPOMPA playerEntity, BMNJPBPOMPA changeEntity, bool replacePos, Vector3 pos, Quaternion rot) {} // 0x0000000181E1D550-0x0000000181E1D830
		//public static void OnAvatarRaplaced(BMNJPBPOMPA playerEntity, BMNJPBPOMPA changeEntity) {} // 0x0000000181E2D380-0x0000000181E2D420
		//public static bool CanBeHitInMultiplayer(uint attackerRuntimeID, uint attackeeRuntimeID) => default; // 0x0000000181E19AD0-0x0000000181E19D40
		//public static void RecoverServerAnimatorParameter(BMNJPBPOMPA entity, MapField<int, AnimatorParameterValueInfo> animatorParaMap) {} // 0x0000000181E2E3F0-0x0000000181E2E5C0
		//public static void RecoverServerEntityRendererVisible(BMNJPBPOMPA entity, EntityRendererChangedInfo rendererInfo) {} // 0x0000000181E2E5C0-0x0000000181E2E6A0
		//public static Vector3 MultiplyVector3(Vector3 v1, Vector3 v2) => default; // 0x0000000180CA5660-0x0000000180CA56B0
		//public static Vector3 DivideVector3(Vector3 a, Vector3 b) => default; // 0x0000000181E1D1A0-0x0000000181E1D210
		//public static void PauseLevelTime(bool enable, int type = 6 /* Metadata: 0x0092E523 */) {} // 0x0000000181E2D810-0x0000000181E2DAA0
		//public static void PauseRemoteLevelTime(bool enable, int type = 6 /* Metadata: 0x0092E527 */) {} // 0x0000000181E2DAA0-0x0000000181E2DC10
		//public static Transform GetTargetLockPointTrans(BMNJPBPOMPA targetEntity, string lockPoint) => default; // 0x0000000181E2C5D0-0x0000000181E2C6F0
		//public static Transform GetTargetLockPointTrans(BMNJPBPOMPA targetEntity, uint lockPointIndex) => default; // 0x0000000181E2C4B0-0x0000000181E2C5D0
		//public static AssetJobPriority Magnitude2Piroity(float magitude, SECTR_LayerType type) => default; // 0x0000000181E2D2C0-0x0000000181E2D380
		//public static ConfigChannel GetConfigChannel() => default; // 0x0000000181E27160-0x0000000181E272E0
		//public static string GetSystemVersion() => default; // 0x0000000181E2C4A0-0x0000000181E2C4B0
		//public static string GetDeviceName() => default; // 0x0000000181E27900-0x0000000181E27910
		//public static string GetDeviceInfo() => default; // 0x0000000181E27630-0x0000000181E27900
		//public static string GetCurrentPlatform() => default; // 0x0000000181E272E0-0x0000000181E27330
		//public static void InitValideDevice(JSONNode deviceList) {} // 0x00000001802CB650-0x00000001802CB660
		//public static bool IsValideDevice() => default; // 0x00000001804375E0-0x00000001804375F0
		//public static string GetValidDeviceName() => default; // 0x0000000181E2C9C0-0x0000000181E2C9F0
		//public static string GetUrlExtInfo() => default; // 0x0000000181E2C830-0x0000000181E2C9C0
		//public static string GetGlobalDispatchUrl(string url) => default; // 0x0000000181E27D60-0x0000000181E280D0
		//public static string GetServerTag(ServerType server) => default; // 0x0000000181E2C400-0x0000000181E2C440
		//public static string GetGlobalServer() => default; // 0x0000000181E283D0-0x0000000181E28730
		//public static string GetGlobalServerZone(string name) => default; // 0x0000000181E280D0-0x0000000181E283D0

		//// Extension methods
		//public static Vector3 FromProto(this Proto.Vector protoVec) => default; // 0x0000000181E1D830-0x0000000181E1D8B0
		//public static bool IsRendering(this Renderer r) => default; // 0x0000000181E2D0A0-0x0000000181E2D0E0
		//public static T AddAndReturnElement<T>(this List<T> list, T inElement) => default;
		//public static bool IsNoneParent(this RectTransform rectTransform) => default; // 0x0000000181E2CFA0-0x0000000181E2D0A0
		//public static object GetPrivateField(this object instance, string fieldname) => default; // 0x0000000181E2C1D0-0x0000000181E2C240
		//public static object GetPrivateProperty(this object instance, string propertyname) => default; // 0x0000000181E2C240-0x0000000181E2C2B0
		//public static object CallPrivateMethod(this object instance, string name, params /* 0x00000001818193F0-0x0000000181819400 */ object[] param) => default; // 0x0000000181E19A60-0x0000000181E19AD0
		//public static bool Contains<T>(this List<T> lst, T item, IEqualityComparer<T> comparer) => default;
	}
}

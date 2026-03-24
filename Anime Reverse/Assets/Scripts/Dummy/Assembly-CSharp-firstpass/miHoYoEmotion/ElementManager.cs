using System;
using System.Collections.Generic;
using MoleMole;
using UnityEngine;

namespace miHoYoEmotion
{
	[ExecuteInEditMode]
	public class ElementManager : MonoBehaviour // TypeDefIndex: 6591
	{
		public enum Type
		{
			NONE = -1,
			CLIP = 0,
			FRAME = 1
		}

		//OK
		[Serializable]
		public class BaseShapeRuntime : ISerializationCallbackReceiver
		{
			public string name;

			//OK
			public void OnBeforeSerialize()
			{
			}

			//OK
			public void OnAfterDeserialize()
			{
				UniqueString.InternString(ref name, true);
			}
		}

		[SerializeField]
		protected BaseShapeData _shapeData;

		[SerializeField]
		protected BaseShapeData _specialShapeData;

		protected BaseEmoAnimation _emoAnim;

		protected Dictionary<string, BaseShapeRuntime> _shapeRuntimeCache = new Dictionary<string, BaseShapeRuntime>();

		protected EmoStateManager _stateMgr;

		protected double _timeCheckPoint;

		//OK
		public BaseEmoAnimation emoAnim
		{
			get
			{
				return _emoAnim;
			}
		}

		//OK
		public EmoStateManager stateMgr
		{
			get
			{
				return _stateMgr;
			}
		}
	
		// Methods
		public T GetShapeElement<T>(string name) where T : ShapeElement, new() => default;
		protected void AddShapeRuntime(string name, BaseShapeRuntime shapeRuntime) {} // 0x00000001814E7AC0-0x00000001814E7C00
		public T GetShapeRuntime<T>(string name) where T : BaseShapeRuntime, new() => default;

		//OK
		protected virtual void UpdateShapeRuntime()
		{
			_shapeRuntimeCache.Clear();
		}

		//OK
		public virtual void InitEmoAnim()
		{
		}

		public virtual void InitStateMgr() {} // 0x00000001814E7C00-0x00000001814E7CD0

		//OK
		public virtual void UpdateShapeData()
		{
		}

		//OK
		protected virtual void OnEnable()
		{
		}

		//OK
		protected virtual void OnDisable()
		{
		}

		//OK
		protected virtual void Start()
		{
		}

		//OK
		protected virtual void LateUpdate()
		{
			if (Application.isPlaying && _emoAnim != null)
			{
				_emoAnim.Update(Time.deltaTime);
				_emoAnim.Apply();
			}
		}
	}
}

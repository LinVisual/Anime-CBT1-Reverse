namespace MoleMole
{
	public static class Singleton<T> where T : class
	{
		private static T _instance;

		public static T Instance { get; }

		static Singleton() {}

		public static void CreateByInstance(T instance) {}
		public static void Create() {}
		public static T GetInstance() => default;
		public static void Destroy() {}
	}
}

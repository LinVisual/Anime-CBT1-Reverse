namespace MoleMole
{
	public abstract class BaseManager
	{
		protected BaseManager()
		{
		}

		public abstract void Init();

		public virtual void Tick()
		{
		}

		public virtual void LateTick()
		{
		}

		public abstract void Destroy();
	}
}

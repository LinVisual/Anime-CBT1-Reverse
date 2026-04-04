namespace MoleMole
{
	public abstract class BaseManager
	{
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

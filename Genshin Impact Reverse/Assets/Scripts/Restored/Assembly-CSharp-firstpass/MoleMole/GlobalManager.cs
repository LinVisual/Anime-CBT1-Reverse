namespace MoleMole
{
	public abstract class GlobalManager : BaseManager
	{
		protected GlobalManager()
		{
		}

		public abstract void ClearOnLevelDestroy();

		public virtual void InitOnConnect()
		{
		}

		public virtual void ClearOnDisconnect()
		{
		}

		public virtual void ClearOnBackHome(bool forceClear = true)
		{
		}
	}
}
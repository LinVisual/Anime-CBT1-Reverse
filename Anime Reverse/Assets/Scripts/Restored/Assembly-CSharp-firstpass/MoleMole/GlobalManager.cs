namespace MoleMole
{
	public abstract class GlobalManager : BaseManager
	{
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
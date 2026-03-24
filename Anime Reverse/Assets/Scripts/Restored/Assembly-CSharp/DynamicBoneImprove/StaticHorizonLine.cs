using VerletEngine;

namespace DynamicBoneImprove
{
	public class StaticHorizonLine
	{
		public VerletParticle p0;

		public VerletParticle p1;

		public VerletParticle parentP0;

		public VerletParticle parentP1;

		public bool collision;

		public StaticHorizonLine(VerletParticle p0, VerletParticle p1, VerletParticle parentP0, VerletParticle parentP1)
		{
			this.p0 = p0;
			this.parentP0 = parentP0;
			this.parentP1 = parentP1;
			this.p1 = p1;
		}
	}
}
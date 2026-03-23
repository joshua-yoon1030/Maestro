using BaseLib.Abstracts;
using BaseLib.Utils;
using Maestro.MaestroCode.Character;
using Maestro.MaestroCode.Powers;
using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.Models.RelicPools;
using MegaCrit.Sts2.Core.Models.Relics;
using MegaCrit.Sts2.Core.Rooms;
using MegaCrit.Sts2.Core.Runs;

namespace Maestro.MaestroCode.Relics;

[Pool(typeof(MaestroRelicPool))]
public sealed class ConductorBaton : CustomRelicModel
{
	public override RelicRarity Rarity => RelicRarity.Starter;

	protected override IEnumerable<DynamicVar> CanonicalVars
	{
		get
		{
			return new DynamicVar[]
			{
				new DynamicVar("Amount", 2M)
			};
		}
	}

	protected override IEnumerable<IHoverTip> ExtraHoverTips
	{
		get { return [HoverTipFactory.FromPower<Resonance>()]; }
	}

	public override async Task BeforeCombatStart()
	{

		ConductorBaton baton = this;
		Resonance res = await PowerCmd.Apply<Resonance>(baton.Owner.Creature, 2M, baton.Owner.Creature, (CardModel) null);
	}
}
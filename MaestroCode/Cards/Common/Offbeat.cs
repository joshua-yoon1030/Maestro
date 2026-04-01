using BaseLib.Abstracts;
using BaseLib.Utils;
using Maestro.MaestroCode.Character;
using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Combat.History.Entries;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;

namespace Maestro.MaestroCode.Cards.Common;

[Pool(typeof(MaestroCardPool))]
public class Offbeat : CustomCardModel
{
	public Offbeat()
		: base(2, CardType.Skill, CardRarity.Common, TargetType.Self)
	{
	}

	public override bool GainsBlock => true;
	protected override bool ShouldGlowGoldInternal => this.ShouldRefundEnergy;

	private bool ShouldRefundEnergy
	{
		get
		{
			return CombatManager.Instance.History.CardPlaysFinished.Count(e => e.HappenedThisTurn(CombatState) && e.CardPlay.Card.Owner == Owner) == 2;
		}
	}

	protected override IEnumerable<DynamicVar> CanonicalVars => [new BlockVar(9M, ValueProp.Move), new EnergyVar("Energy", 1)];

	protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
	{
		Offbeat offbeat = this;
		Decimal num = await CreatureCmd.GainBlock(offbeat.Owner.Creature, offbeat.DynamicVars.Block, cardPlay);

		if (!ShouldRefundEnergy) return;
		
		await PlayerCmd.GainEnergy(offbeat.DynamicVars.Energy.IntValue, offbeat.Owner);
	}

	protected override void OnUpgrade()
	{
		DynamicVars.Block.UpgradeValueBy(3M);
	}
}
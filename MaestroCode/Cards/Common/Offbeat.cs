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
public class Offbeat() : CustomCardModel(2, CardType.Skill, CardRarity.Common, TargetType.Self)
{
	public override bool GainsBlock => true;
	protected override bool ShouldGlowGoldInternal => ShouldRefundEnergy;

	private bool ShouldRefundEnergy =>
		CombatManager.Instance.History.CardPlaysFinished.Count(e => e.HappenedThisTurn(CombatState) && e.CardPlay.Card.Owner == Owner) == 2;

	protected override IEnumerable<DynamicVar> CanonicalVars => [new BlockVar(9, ValueProp.Move), new EnergyVar("Energy", 1)];

	protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
	{
		await CreatureCmd.GainBlock(Owner.Creature, DynamicVars.Block, cardPlay);

		if (!ShouldRefundEnergy) return;

		await PlayerCmd.GainEnergy(DynamicVars.Energy.IntValue, Owner);
	}

	protected override void OnUpgrade()
	{
		DynamicVars.Block.UpgradeValueBy(3);
	}
}
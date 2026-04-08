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
public class Offbeat() : MaestroCard(2, CardType.Skill, CardRarity.Common, TargetType.Self)
{
	public override bool GainsBlock => true;
	protected override bool ShouldGlowGoldInternal => CombatManager.Instance.History.CardPlaysFinished.Count(e => e.HappenedThisTurn(CombatState) && e.CardPlay.Card.Owner == Owner) == 1;

	protected override IEnumerable<DynamicVar> CanonicalVars => [new BlockVar(9, ValueProp.Move)];

	protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
	{
		await CreatureCmd.GainBlock(Owner.Creature, DynamicVars.Block, cardPlay);
	}

	public override Task AfterCardPlayed(PlayerChoiceContext context, CardPlay cardPlay)
	{
		if (cardPlay.Card.Owner != Owner)
			return Task.CompletedTask;
		if (CombatManager.Instance.History.CardPlaysFinished.Count(e =>
			    e.HappenedThisTurn(CombatState) && e.CardPlay.Card.Owner == Owner) == 1)
		{
			UpdateCost(-1);
		}
		else if (CombatManager.Instance.History.CardPlaysFinished.Count(e =>
			         e.HappenedThisTurn(CombatState) && e.CardPlay.Card.Owner == Owner) == 2)
		{
			UpdateCost(1);
		}
        
		return Task.CompletedTask;
	}
    
	private void UpdateCost(int amount) => EnergyCost.AddThisTurn(amount);

	protected override void OnUpgrade()
	{
		DynamicVars.Block.UpgradeValueBy(3);
	}
}
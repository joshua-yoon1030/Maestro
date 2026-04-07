using BaseLib.Extensions;
using BaseLib.Utils;
using Maestro.MaestroCode.Cards.Token;
using Maestro.MaestroCode.Character;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Factories;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.ValueProps;

namespace Maestro.MaestroCode.Cards.Common;


[Pool(typeof(MaestroCardPool))]
public class Delegate() : MaestroCard(1, CardType.Attack, CardRarity.Common, TargetType.AnyEnemy)
{
	protected override IEnumerable<DynamicVar> CanonicalVars => [new DamageVar(3, ValueProp.Move).WithTooltip("Performer")];

	protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
	{
		await DamageCmd.Attack(DynamicVars.Damage.BaseValue).FromCard(this).Targeting(cardPlay.Target).Execute(choiceContext);
		
		CardModel card = CardFactory.GetDistinctForCombat(Owner, Owner.Character.CardPool.GetUnlockedCards(Owner.UnlockState, Owner.RunState.CardMultiplayerConstraint).Where( c => c.Tags.Contains(CustomCardTags.Performer)), 1, Owner.RunState.Rng.CombatCardGeneration).FirstOrDefault();
		if (card == null)
			return;
		await CardPileCmd.AddGeneratedCardToCombat(card, PileType.Hand, true);
	}
}

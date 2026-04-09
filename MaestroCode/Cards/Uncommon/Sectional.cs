using BaseLib.Extensions;
using Maestro.MaestroCode.Cards.Token;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Factories;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.ValueProps;

namespace Maestro.MaestroCode.Cards.Uncommon;

public class Sectional(): MaestroCard(2, CardType.Skill, CardRarity.Uncommon, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [new DynamicVar("Amount", 3).WithTooltip("PERFORMER")];
    
    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        CardModel card = CardFactory.GetDistinctForCombat(Owner, Owner.Character.CardPool.GetUnlockedCards(Owner.UnlockState, Owner.RunState.CardMultiplayerConstraint).Where( c => c.Tags.Contains(CustomCardTags.Performer)), 1, Owner.RunState.Rng.CombatCardGeneration).FirstOrDefault();
        if (card == null)
            return;

        for (int i = 0; i < DynamicVars["Amount"].IntValue; i++)
        {
            await CardPileCmd.AddGeneratedCardToCombat(card.CreateClone(), PileType.Hand, true);
        }
    }
    
    protected override void OnUpgrade()
    {
        DynamicVars["Amount"].UpgradeValueBy(1);
    }
}
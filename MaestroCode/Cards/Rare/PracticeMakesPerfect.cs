using BaseLib.Abstracts;
using BaseLib.Utils;
using Maestro.MaestroCode.Character;
using MegaCrit.Sts2.Core.CardSelection;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models;

namespace Maestro.MaestroCode.Cards.Rare;


[Pool(typeof(MaestroCardPool))]
public sealed class PracticeMakesPerfect() : CustomCardModel(-1, CardType.Skill, CardRarity.Rare, TargetType.Self)
{
    protected override bool HasEnergyCostX => true;

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await CreatureCmd.TriggerAnim(Owner.Creature, "Cast", Owner.Character.CastAnimDelay);
        CardSelectorPrefs prefs = new CardSelectorPrefs(SelectionScreenPrompt, 1)
        {
            PretendCardsCanBePlayed = true
        };
        CardModel card = (await CardSelectCmd.FromHand(choiceContext, Owner, prefs, c => !c.Keywords.Contains(CardKeyword.Unplayable), this)).FirstOrDefault();
        int count = ResolveEnergyXValue();
        if (IsUpgraded)
            ++count;
        for (int i = 0; i < count; ++i)
        {
            await CardCmd.AutoPlay(choiceContext, card, null);
        }
    }
}
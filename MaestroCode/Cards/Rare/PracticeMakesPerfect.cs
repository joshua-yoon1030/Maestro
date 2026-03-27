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
public sealed class PracticeMakesPerfect : CustomCardModel
{
    public PracticeMakesPerfect() : base(-1, CardType.Skill, CardRarity.Rare, TargetType.Self)
    {
    }
    
    protected override bool HasEnergyCostX => true;
    
    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        PracticeMakesPerfect source = this;
        await CreatureCmd.TriggerAnim(source.Owner.Creature, "Cast", source.Owner.Character.CastAnimDelay);
        CardSelectorPrefs prefs = new CardSelectorPrefs(source.SelectionScreenPrompt, 1)
        {
            PretendCardsCanBePlayed = true
        };
        CardModel card = (await CardSelectCmd.FromHand(choiceContext, source.Owner, prefs, (Func<CardModel, bool>) (c => !c.Keywords.Contains(CardKeyword.Unplayable)), source)).FirstOrDefault();
        int count = source.ResolveEnergyXValue();
        if (source.IsUpgraded)
            ++count;
        for (int i = 0; i < count; ++i)
        {
            if (card.Type == CardType.Skill || card.Type == CardType.Power)
            {
                await CardCmd.AutoPlay(choiceContext, card, null);
            }
            else
            {
                await CardCmd.AutoPlay(choiceContext, card, null);
            }
            
        }
        
    }
}
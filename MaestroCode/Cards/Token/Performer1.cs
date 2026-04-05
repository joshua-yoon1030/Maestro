using BaseLib.Abstracts;
using BaseLib.Utils;
using Maestro.MaestroCode.Character;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;

namespace Maestro.MaestroCode.Cards.Token;

[Pool(typeof(MaestroCardPool))]
public class Performer1() : CustomCardModel(0, CardType.Skill, CardRarity.Token, TargetType.Self)
{
    protected override HashSet<CardTag> CanonicalTags => [CustomCardTags.Performer];
    protected override IEnumerable<DynamicVar> CanonicalVars => [new CardsVar(1)];
    public override IEnumerable<CardKeyword> CanonicalKeywords => [CardKeyword.Exhaust];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await CardPileCmd.Draw(choiceContext, DynamicVars.Cards.BaseValue, Owner);
    }

    protected override void OnUpgrade() => DynamicVars.Cards.UpgradeValueBy(1);
}
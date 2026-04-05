using BaseLib.Abstracts;
using BaseLib.Utils;
using Maestro.MaestroCode.Character;
using Maestro.MaestroCode.Powers;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Localization.DynamicVars;

namespace Maestro.MaestroCode.Cards.Token;

[Pool(typeof(MaestroCardPool))]
public class Performer3() : CustomCardModel(0, CardType.Skill, CardRarity.Token, TargetType.Self)
{
    public override IEnumerable<CardKeyword> CanonicalKeywords => [CardKeyword.Exhaust];

    protected override HashSet<CardTag> CanonicalTags => [CustomCardTags.Performer];
    protected override IEnumerable<DynamicVar> CanonicalVars => [new PowerVar<Resonance>(2)];
    protected override IEnumerable<IHoverTip> ExtraHoverTips => [HoverTipFactory.FromPower<Resonance>()];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await PowerCmd.Apply<Resonance>(Owner.Creature, DynamicVars["Resonance"].IntValue, Owner.Creature, this);
    }

    protected override void OnUpgrade() => DynamicVars["Resonance"].UpgradeValueBy(1);
}
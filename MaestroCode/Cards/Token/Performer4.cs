using BaseLib.Utils;
using Maestro.MaestroCode.Character;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Powers;

namespace Maestro.MaestroCode.Cards.Token;


//Performer 4: Flautist

[Pool(typeof(MaestroCardPool))]
public class Performer4() : MaestroCard(0, CardType.Skill, CardRarity.Token, TargetType.AnyEnemy)
{
    public override IEnumerable<CardKeyword> CanonicalKeywords => [CardKeyword.Exhaust];

    protected override HashSet<CardTag> CanonicalTags => [CustomCardTags.Performer];
    protected override IEnumerable<DynamicVar> CanonicalVars => [new PowerVar<WeakPower>(1)];
    protected override IEnumerable<IHoverTip> ExtraHoverTips => [HoverTipFactory.FromPower<WeakPower>()];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    { 
        await PowerCmd.Apply<WeakPower>(cardPlay.Target, DynamicVars.Weak.BaseValue, Owner.Creature, this);
    }

    protected override void OnUpgrade() => DynamicVars.Weak.UpgradeValueBy(1);
}
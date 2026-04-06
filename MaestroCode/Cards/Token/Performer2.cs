using BaseLib.Abstracts;
using BaseLib.Utils;
using Maestro.MaestroCode.Character;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Powers;

namespace Maestro.MaestroCode.Cards.Token;

//Performer 2: Percussionist
[Pool(typeof(MaestroCardPool))]
public class Performer2() : MaestroCard(0, CardType.Skill, CardRarity.Token, TargetType.AllEnemies)
{
    public override IEnumerable<CardKeyword> CanonicalKeywords => [CardKeyword.Exhaust];

    protected override HashSet<CardTag> CanonicalTags => [CustomCardTags.Performer];
    protected override IEnumerable<DynamicVar> CanonicalVars => [new PowerVar<VulnerablePower>(1)];
    protected override IEnumerable<IHoverTip> ExtraHoverTips => [HoverTipFactory.FromPower<VulnerablePower>()];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await PowerCmd.Apply<VulnerablePower>(CombatState.HittableEnemies, DynamicVars.Vulnerable.BaseValue, Owner.Creature, this);
    }

    protected override void OnUpgrade() => DynamicVars.Vulnerable.UpgradeValueBy(1);
}
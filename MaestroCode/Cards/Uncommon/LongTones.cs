using BaseLib.Abstracts;
using BaseLib.Utils;
using Maestro.MaestroCode.Character;
using Maestro.MaestroCode.Powers;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;

namespace Maestro.MaestroCode.Cards.Uncommon;


[Pool(typeof(MaestroCardPool))]
public sealed class LongTones() : MaestroCard(1, CardType.Skill, CardRarity.Rare, TargetType.Self)
{
    private int upgradeAmount = 2;

    public override int MaxUpgradeLevel => 999;

    protected override IEnumerable<DynamicVar> CanonicalVars => [new PowerVar<Resonance>(3), new DynamicVar("CurrentUpgradeLevel", 0)];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await PowerCmd.Apply<Resonance>(Owner.Creature, DynamicVars["Resonance"].IntValue, Owner.Creature, this);
    }

    protected override void OnUpgrade()
    {
        DynamicVars["CurrentUpgradeLevel"].UpgradeValueBy(1);
        DynamicVars["Resonance"].UpgradeValueBy(upgradeAmount);
        upgradeAmount += 1;
    }
}
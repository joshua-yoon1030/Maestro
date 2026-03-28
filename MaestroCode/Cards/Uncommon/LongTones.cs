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
public sealed class LongTones : CustomCardModel
{
    private Decimal upgradeAmount;
    public LongTones() : base(1, CardType.Skill, CardRarity.Rare, TargetType.Self)
    {
        upgradeAmount = 2M;
    }

    public override int MaxUpgradeLevel => 999;
    
    protected override IEnumerable<DynamicVar> CanonicalVars => [new DynamicVar("Amount", 3M), new DynamicVar("CurrentUpgradeLevel", 0M)];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        LongTones card = this;
        Resonance res = await PowerCmd.Apply<Resonance>(card.Owner.Creature, DynamicVars["Amount"].BaseValue,
            card.Owner.Creature, card);
    }
    
    protected override void OnUpgrade() {
        DynamicVars["CurrentUpgradeLevel"].UpgradeValueBy(1M);
        DynamicVars["Amount"].UpgradeValueBy(upgradeAmount);
        upgradeAmount += 1M;
    }
}
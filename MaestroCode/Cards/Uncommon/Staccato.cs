using BaseLib.Abstracts;
using BaseLib.Utils;
using Maestro.MaestroCode.Character;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.ValueProps;

namespace Maestro.MaestroCode.Cards.Uncommon;


[Pool(typeof(MaestroCardPool))]
public sealed class Staccato : CustomCardModel
{
    public Staccato(): base(2, CardType.Skill, CardRarity.Uncommon, TargetType.Self)
    {
    }
    
    public override bool GainsBlock => true;

    protected override IEnumerable<DynamicVar> CanonicalVars => [new BlockVar(10M, ValueProp.Move), new PowerVar<ThornsPower>(1M)];

    protected override IEnumerable<IHoverTip> ExtraHoverTips => [HoverTipFactory.FromPower<ThornsPower>()];
    
    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        Staccato staccato = this;
        Decimal num = await CreatureCmd.GainBlock(staccato.Owner.Creature, staccato.DynamicVars.Block, cardPlay);
        ThornsPower? thorns = await PowerCmd.Apply<ThornsPower>(staccato.Owner.Creature,
            staccato.DynamicVars["ThornsPower"].BaseValue, staccato.Owner.Creature, staccato);
    }

    protected override void OnUpgrade()
    {
        DynamicVars.Block.UpgradeValueBy(2M);
        DynamicVars["ThornsPower"].UpgradeValueBy(1M);
    }
}
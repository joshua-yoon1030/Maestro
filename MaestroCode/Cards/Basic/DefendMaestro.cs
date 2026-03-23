using BaseLib.Abstracts;
using BaseLib.Utils;
using Maestro.MaestroCode.Character;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Cards;
using MegaCrit.Sts2.Core.ValueProps;

namespace Maestro.MaestroCode.Cards.Basic;

[Pool(typeof(MaestroCardPool))]
public sealed class DefendMaestro : CustomCardModel
{
    public DefendMaestro()
        : base(1, CardType.Skill, CardRarity.Basic, TargetType.Self)
    {
    }

    public override bool GainsBlock => true;

    protected override HashSet<CardTag> CanonicalTags
    {
        get => new HashSet<CardTag>() { CardTag.Defend };
    }

    protected override IEnumerable<DynamicVar> CanonicalVars => [new BlockVar(5M, ValueProp.Move)];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        DefendMaestro defendMaestro = this;
        Decimal num = await CreatureCmd.GainBlock(defendMaestro.Owner.Creature, defendMaestro.DynamicVars.Block, cardPlay);
    }

    protected override void OnUpgrade() => this.DynamicVars.Block.UpgradeValueBy(3M);
}
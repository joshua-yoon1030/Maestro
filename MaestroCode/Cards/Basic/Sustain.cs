using BaseLib.Abstracts;
using BaseLib.Utils;
using Maestro.MaestroCode.Character;
using Maestro.MaestroCode.Powers;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.ValueProps;

namespace Maestro.MaestroCode.Cards.Basic;


[Pool(typeof(MaestroCardPool))]
public sealed class Sustain: CustomCardModel
{
    public Sustain(): base(1, CardType.Skill, CardRarity.Basic, TargetType.Self)
    {
    }
    
    protected override IEnumerable<DynamicVar> CanonicalVars
    {
        get
        {
            return new DynamicVar[]
            {
                new DynamicVar("Amount", 2M)
            };
        }
    }

    protected override IEnumerable<IHoverTip> ExtraHoverTips
    {
        get { return [HoverTipFactory.FromPower<Resonance>()]; }
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        Sustain card = this;
        Resonance res = await PowerCmd.Apply<Resonance>(card.Owner.Creature, this.DynamicVars["Amount"].BaseValue, card.Owner.Creature, this);
    }
    
    
    protected override void OnUpgrade() =>  this.DynamicVars["Amount"].UpgradeValueBy(1M);
}
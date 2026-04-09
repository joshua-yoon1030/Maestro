using BaseLib.Abstracts;
using BaseLib.Utils;
using Maestro.MaestroCode.Character;
using Maestro.MaestroCode.Powers;
using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Localization.DynamicVars;

namespace Maestro.MaestroCode.Cards.Rare;

[Pool(typeof(MaestroCardPool))]
public class Octave() : MaestroCard(0, CardType.Skill, CardRarity.Rare, TargetType.Self)
{
    protected override bool ShouldGlowGoldInternal => CombatManager.Instance.History.CardPlaysFinished.Count(e => e.HappenedThisTurn(CombatState) && e.CardPlay.Card.Owner == Owner) == 7;
    protected override bool IsPlayable => ShouldGlowGoldInternal;
    protected override IEnumerable<DynamicVar> CanonicalVars => [new PowerVar<Resonance>(2)];

    protected override IEnumerable<IHoverTip> ExtraHoverTips => [HoverTipFactory.FromPower<Resonance>()];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await PowerCmd.Apply<Resonance>(Owner.Creature, DynamicVars["Resonance"].IntValue,
            Owner.Creature, this);
    }
    
    protected override void OnUpgrade() => DynamicVars["Resonance"].UpgradeValueBy(4);
}

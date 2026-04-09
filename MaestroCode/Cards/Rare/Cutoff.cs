using BaseLib.Abstracts;
using BaseLib.Extensions;
using BaseLib.Utils;
using Maestro.MaestroCode.Character;
using Maestro.MaestroCode.Powers;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;

namespace Maestro.MaestroCode.Cards.Rare;


[Pool(typeof(MaestroCardPool))]
public class Cutoff() : MaestroCard(1, CardType.Attack, CardRarity.Rare, TargetType.AnyEnemy)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [new DamageVar(1, ValueProp.Move)];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        int DamageAmount = Owner.Creature.Powers.FirstOrDefault(p => p is Resonance).Amount;
        DamageAmount = IsUpgraded ? DamageAmount * 3 : DamageAmount * 2;
        await DamageCmd.Attack(DamageAmount).FromCard(this).Targeting(cardPlay.Target).Execute(choiceContext);
    }
}

using BaseLib.Abstracts;
using BaseLib.Utils;
using Maestro.MaestroCode.Character;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Commands.Builders;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Cards;
using MegaCrit.Sts2.Core.ValueProps;

namespace Maestro.MaestroCode.Cards.Common;

[Pool(typeof(MaestroCardPool))]
public sealed class MissedEntrance: CustomCardModel
{
    public MissedEntrance(): base(1, CardType.Attack, CardRarity.Common, TargetType.AnyEnemy)
    {
    }
    
    protected override IEnumerable<DynamicVar> CanonicalVars => [new DamageVar(12M, ValueProp.Move)];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        MissedEntrance card = this;
        AttackCommand attackCommand = await DamageCmd.Attack(card.DynamicVars.Damage.BaseValue).FromCard(card).Targeting(cardPlay.Target).Execute(choiceContext);
        CardCmd.PreviewCardPileAdd(await CardPileCmd.AddGeneratedCardToCombat(card.CombatState.CreateCard<Shame>(card.Owner), PileType.Draw, true), 2.2f);
    }

    protected override void OnUpgrade() =>  this.DynamicVars.Damage.UpgradeValueBy(5M);
}
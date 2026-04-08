using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;

namespace Maestro.MaestroCode.Cards.Uncommon;


public class ThirdMovement(): MaestroCard(2, CardType.Attack, CardRarity.Uncommon, TargetType.AnyEnemy)
{
    protected override bool ShouldGlowGoldInternal => CombatManager.Instance.History.CardPlaysFinished.Count(e => e.HappenedThisTurn(CombatState) && e.CardPlay.Card.Owner == Owner) == 2;
    
    protected override IEnumerable<DynamicVar> CanonicalVars => [new DamageVar(10, ValueProp.Move)];
    
    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await DamageCmd.Attack(DynamicVars.Damage.BaseValue).FromCard(this).Targeting(cardPlay.Target).Execute(choiceContext);
    }
    
    public override Task AfterCardPlayed(PlayerChoiceContext context, CardPlay cardPlay)
    {
        if (cardPlay.Card.Owner != Owner)
            return Task.CompletedTask;
        if (CombatManager.Instance.History.CardPlaysFinished.Count(e =>
                e.HappenedThisTurn(CombatState) && e.CardPlay.Card.Owner == Owner) == 2)
        {
            UpdateCost(-1);
        }
        else if (CombatManager.Instance.History.CardPlaysFinished.Count(e =>
                     e.HappenedThisTurn(CombatState) && e.CardPlay.Card.Owner == Owner) == 3)
        {
            UpdateCost(1);
        }
        
        return Task.CompletedTask;
    }
    
    private void UpdateCost(int amount) => EnergyCost.AddThisTurn(amount);
    
    protected override void OnUpgrade()
    {
        DynamicVars.Damage.UpgradeValueBy(4);
    }
    
}
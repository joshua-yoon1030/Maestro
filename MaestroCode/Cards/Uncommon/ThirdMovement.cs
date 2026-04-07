using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;

namespace Maestro.MaestroCode.Cards.Uncommon;


public class ThirdMovement(): MaestroCard(2, CardType.Attack, CardRarity.Uncommon, TargetType.AnyEnemy)
{
    
    protected override bool ShouldGlowGoldInternal => CombatManager.Instance.History.CardPlaysFinished.Count(e => e.HappenedThisTurn(CombatState) && e.CardPlay.Card.Owner == Owner) == 3;
    
    protected override IEnumerable<DynamicVar> CanonicalVars => [new DamageVar(10, ValueProp.Move), new EnergyVar("Energy", 1)];
    
    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await CreatureCmd.GainBlock(Owner.Creature, DynamicVars.Block, cardPlay);
        
    }
    
    public override Task BeforeCardPlayed(CardPlay cardPlay)
    {
        if (cardPlay.Card.Owner != Owner)
            return Task.CompletedTask;
        if (CombatManager.Instance.History.CardPlaysFinished.Count(e =>
                e.HappenedThisTurn(CombatState) && e.CardPlay.Card.Owner == Owner) == 3)
        {
            UpdateCost(-1);
        }
        else if (CombatManager.Instance.History.CardPlaysFinished.Count(e =>
                     e.HappenedThisTurn(CombatState) && e.CardPlay.Card.Owner == Owner) == 4)
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
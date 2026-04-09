using Maestro.MaestroCode.Cards.Token;
using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.Factories;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;
using MegaCrit.Sts2.Core.Models.Powers;

namespace Maestro.MaestroCode.Powers;

public class JamSessionPower : MaestroPower
{
    public override PowerType Type => PowerType.Buff;

    public override PowerStackType StackType => PowerStackType.Counter;

    protected override IEnumerable<DynamicVar> CanonicalVars => [new PowerVar<JamSessionPower>(1)];
    
    public override async Task BeforeHandDraw(
        Player player,
        PlayerChoiceContext choiceContext,
        CombatState combatState)
    {
        if (player != Owner.Player)
            return;
        Flash();
        CardModel card = CardFactory.GetDistinctForCombat(Owner.Player, Owner.Player.Character.CardPool.GetUnlockedCards(Owner.Player.UnlockState, Owner.Player.RunState.CardMultiplayerConstraint).Where( c => c.Tags.Contains(CustomCardTags.Performer)), 1, Owner.Player.RunState.Rng.CombatCardGeneration).FirstOrDefault();
        if (card == null)
            return;
        await CardPileCmd.AddGeneratedCardToCombat(card.CreateClone(), PileType.Hand, true);
    }
}

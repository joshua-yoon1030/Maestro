using BaseLib.Abstracts;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;

namespace Maestro.MaestroCode.Powers;

public class PageFlipPower : CustomPowerModel
{
    public override PowerType Type => PowerType.Buff;

    public override PowerStackType StackType => PowerStackType.Counter;
    
    protected override IEnumerable<DynamicVar> CanonicalVars
    {
        get
        {
            return new DynamicVar[]
            {
                new PowerVar<PageFlipPower>(1M),
            };
        }
    }
    
    public override async Task AfterPlayerTurnStart(PlayerChoiceContext choiceContext, Player player)
    {
        PageFlipPower pageFlipPower = this;
        if (player != pageFlipPower.Owner.Player) return;
        
        pageFlipPower.Flash();
        IEnumerable<CardModel> cardModels = await CardPileCmd.Draw(choiceContext, pageFlipPower.Amount, player);
        await PowerCmd.Remove<PageFlipPower>(player.Creature);
    }
}
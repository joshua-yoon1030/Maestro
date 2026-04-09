using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.Localization.DynamicVars;

namespace Maestro.MaestroCode.Powers;

public class AccelerandoPower : MaestroPower
{
    public override PowerType Type => PowerType.Buff;

    public override PowerStackType StackType => PowerStackType.Counter;

    protected override IEnumerable<DynamicVar> CanonicalVars => [new PowerVar<AccelerandoPower>(1)];
    
    public override Decimal ModifyHandDraw(Player player, Decimal count)
    {
        return player != Owner.Player ? count : count + Amount;
    }
}

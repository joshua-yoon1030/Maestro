using BaseLib.Abstracts;
using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;

namespace Maestro.MaestroCode.Powers;

public class Resonance : CustomPowerModel
{
	public override PowerType Type => PowerType.Buff;
	public override PowerStackType StackType => PowerStackType.Counter;
	
	protected override IEnumerable<DynamicVar> CanonicalVars
	{
		get
		{
			return new DynamicVar[]
			{
				new PowerVar<Resonance>(2M),
				new DynamicVar("Decrease", 1M),
			};
		}
	}

	public override async Task BeforeTurnEnd(PlayerChoiceContext choiceContext, CombatSide side)
	{
		Resonance res = this;
		if (side != res.Owner.Side) return;

		res.Flash();
		IEnumerable<DamageResult> damageResults = await CreatureCmd.Damage(choiceContext, (IEnumerable<Creature>)res.Owner.CombatState.HittableEnemies, new DamageVar(res.Amount, ValueProp.Move), res.Owner);

		await PowerCmd.ModifyAmount(this, -res.DynamicVars["Decrease"].BaseValue, res.Owner, null);
	}
}
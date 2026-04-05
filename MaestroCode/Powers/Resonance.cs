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

	protected override IEnumerable<DynamicVar> CanonicalVars => 
	[
		new PowerVar<Resonance>(Amount),
		new DynamicVar("Decrease", 1)
	];

	public override async Task BeforeTurnEnd(PlayerChoiceContext choiceContext, CombatSide side)
	{
		if (side != Owner.Side) return;

		Flash();
		await CreatureCmd.Damage(choiceContext, Owner.CombatState.HittableEnemies, new DamageVar(Amount, ValueProp.Move), Owner);

		await PowerCmd.ModifyAmount(this, -DynamicVars["Decrease"].BaseValue, Owner, null);
	}
}
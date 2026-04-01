using BaseLib.Abstracts;
using BaseLib.Utils;
using Maestro.MaestroCode.Character;
using Maestro.MaestroCode.Powers;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.ValueProps;

namespace Maestro.MaestroCode.Cards.Common;

[Pool(typeof(MaestroCardPool))]
public class BowingTechnique: CustomCardModel
{
	public BowingTechnique()
		: base(1, CardType.Attack, CardRarity.Common, TargetType.AnyEnemy)
	{
	}

	protected override IEnumerable<DynamicVar> CanonicalVars => [new DamageVar(5M, ValueProp.Move), new PowerVar<DexterityPower>(1M)];

	protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
	{
		BowingTechnique card = this;
		
		BowingTechniquePower btPower = await PowerCmd.Apply<BowingTechniquePower>(card.Owner.Creature, card.DynamicVars.Dexterity.BaseValue, card.Owner.Creature, card);
	}

	protected override void OnUpgrade()
	{
		DynamicVars.Damage.UpgradeValueBy(1M);
		DynamicVars.Dexterity.UpgradeValueBy(1M);
	}
}
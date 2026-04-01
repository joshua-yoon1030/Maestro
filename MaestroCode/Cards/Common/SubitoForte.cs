using BaseLib.Abstracts;
using BaseLib.Utils;
using Maestro.MaestroCode.Character;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.ValueProps;

namespace Maestro.MaestroCode.Cards.Common;

[Pool(typeof(MaestroCardPool))]
public class SubitoForte : CustomCardModel
{
	public SubitoForte()
		: base(2, CardType.Attack, CardRarity.Common, TargetType.AnyEnemy)
	{
	}
	
	protected override IEnumerable<DynamicVar> CanonicalVars => [new DamageVar(3M, ValueProp.Move), new PowerVar<VigorPower>(3M)];

	protected override IEnumerable<IHoverTip> ExtraHoverTips => [HoverTipFactory.FromPower<VigorPower>()];
	
	protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
	{
		SubitoForte cardSource = this;
		Decimal num = await CreatureCmd.GainBlock(cardSource.Owner.Creature, cardSource.DynamicVars.Block, cardPlay);
		await CreatureCmd.TriggerAnim(cardSource.Owner.Creature, "Cast", cardSource.Owner.Character.CastAnimDelay);
		VigorPower vigorPower = await PowerCmd.Apply<VigorPower>(cardSource.Owner.Creature, cardSource.DynamicVars["VigorPower"].IntValue, cardSource.Owner.Creature, cardSource);
	}

	protected override void OnUpgrade()
	{
		DynamicVars["VigorPower"].UpgradeValueBy(3M);
	}
}
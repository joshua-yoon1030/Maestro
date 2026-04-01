using BaseLib.Abstracts;
using BaseLib.Utils;
using Maestro.MaestroCode.Character;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Commands.Builders;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;
using MegaCrit.Sts2.Core.ValueProps;

namespace Maestro.MaestroCode.Cards.Common;

[Pool(typeof(MaestroCardPool))]
public class Finale : CustomCardModel
{
	public Finale()
		: base(2, CardType.Attack, CardRarity.Common, TargetType.AnyEnemy)
	{
	}

	protected override IEnumerable<DynamicVar> CanonicalVars => [new DamageVar(17M, ValueProp.Move)];

	protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
	{
		Finale card = this;
		
		if (!(await DamageCmd.Attack(card.DynamicVars.Damage.BaseValue).FromCard(card).Targeting(cardPlay.Target).Execute(choiceContext)).Results.Any (r => r.WasTargetKilled))
			return;
		PlayerCmd.EndTurn(card.Owner, false);
	}
	
	protected override void OnUpgrade() =>  DynamicVars.Damage.UpgradeValueBy(5M);
}
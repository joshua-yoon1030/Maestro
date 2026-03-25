using BaseLib.Abstracts;
using BaseLib.Utils;
using Maestro.MaestroCode.Character;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;
using MegaCrit.Sts2.Core.ValueProps;

namespace Maestro.MaestroCode.Cards.Basic;

[Pool(typeof(MaestroCardPool))]
public sealed class ConcertA : CustomCardModel
{
	public ConcertA()
		: base(0, CardType.Skill, CardRarity.Basic, TargetType.Self)
	{
	}

	public override bool GainsBlock => true;

	protected override IEnumerable<DynamicVar> CanonicalVars
	{
		get
		{
			return [new BlockVar(8M, ValueProp.Move)];
		}
	}

	public override IEnumerable<CardKeyword> CanonicalKeywords
	{
		get
		{
			return [CardKeyword.Innate, CardKeyword.Exhaust];
		}
	}

	protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
	{
		ConcertA concertA = this;
		Decimal num = await CreatureCmd.GainBlock(concertA.Owner.Creature, concertA.DynamicVars.Block, cardPlay);
	}

	protected override void OnUpgrade() => this.DynamicVars.Block.UpgradeValueBy(3M);
}
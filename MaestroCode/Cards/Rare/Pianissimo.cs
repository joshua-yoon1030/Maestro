using BaseLib.Abstracts;
using BaseLib.Utils;
using Maestro.MaestroCode.Character;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Powers;

namespace Maestro.MaestroCode.Cards.Rare;

[Pool(typeof(MaestroCardPool))]
public class Pianissimo() : MaestroCard(1, CardType.Skill, CardRarity.Rare, TargetType.Self)
{
	public override IEnumerable<CardKeyword> CanonicalKeywords => [CardKeyword.Exhaust];
    protected override IEnumerable<DynamicVar> CanonicalVars => [new PowerVar<IntangiblePower>(1), new DynamicVar("Turns", 2)];
    protected override IEnumerable<IHoverTip> ExtraHoverTips => [HoverTipFactory.FromPower<IntangiblePower>()];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    { 
	    await PowerCmd.Apply<IntangiblePower>(Owner.Creature, DynamicVars["IntangiblePower"].BaseValue, Owner.Creature, this);
		await PowerCmd.Apply<NoBlockPower>(Owner.Creature, DynamicVars["Turns"].BaseValue, Owner.Creature, this);
    }

    protected override void OnUpgrade() => EnergyCost.UpgradeBy(-1);
}

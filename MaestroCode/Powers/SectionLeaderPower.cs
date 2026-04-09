using Maestro.MaestroCode.Cards.Token;
using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Nodes.CommonUi;

namespace Maestro.MaestroCode.Powers;


public class SectionLeaderPower : MaestroPower
{
    public override PowerType Type => PowerType.Buff;

    public override PowerStackType StackType => PowerStackType.Single;

    protected override IEnumerable<DynamicVar> CanonicalVars => [new PowerVar<SectionLeaderPower>(1)];

    public override Task AfterCardGeneratedForCombat(
	    CardModel cardModel,
	    bool b)
    { 
		if (cardModel.Owner != Owner.Player) return Task.CompletedTask;
		if (cardModel.Tags.Contains(CustomCardTags.Performer))
		{
			CardCmd.Upgrade(cardModel, CardPreviewStyle.None);
		}
		return Task.CompletedTask;
    }
}

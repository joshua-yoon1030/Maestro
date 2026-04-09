using BaseLib.Abstracts;
using BaseLib.Extensions;
using BaseLib.Utils;
using Maestro.MaestroCode.Character;
using Maestro.MaestroCode.Powers;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;

namespace Maestro.MaestroCode.Cards.Uncommon;

[Pool(typeof(MaestroCardPool))]
public class JamSession() : MaestroCard(1, CardType.Power, CardRarity.Uncommon, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [new PowerVar<JamSessionPower>(1).WithTooltip("PERFORMER")];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        await PowerCmd.Apply<JamSessionPower>(Owner.Creature, DynamicVars[nameof(JamSessionPower)].BaseValue, Owner.Creature, this);
    }

    protected override void OnUpgrade()
    {
        AddKeyword(CardKeyword.Innate);
    }
}
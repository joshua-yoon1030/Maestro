using BaseLib.Abstracts;
using BaseLib.Utils;
using Maestro.MaestroCode.Character;
using Maestro.MaestroCode.Powers;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.ValueProps;

namespace Maestro.MaestroCode.Cards.Common;

[Pool(typeof(MaestroCardPool))]
public class PageFlip : CustomCardModel
{
    
    public PageFlip(): base(1, CardType.Skill, CardRarity.Common, TargetType.Self)
    {
    }
    
    protected override IEnumerable<DynamicVar> CanonicalVars
    {
        get
        {
            return
            [
                new DynamicVar("FirstDraw", 1M),
                new DynamicVar("SecondDraw", 1M)
            ];
        }
    }
    
    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
    {
        PageFlip pageflip = this;
        IEnumerable<CardModel> cardModels = await CardPileCmd.Draw(choiceContext, pageflip.DynamicVars["FirstDraw"].BaseValue, pageflip.Owner);
        PageFlipPower pageFlipPower = await PowerCmd.Apply<PageFlipPower>(pageflip.Owner.Creature, this.DynamicVars["SecondDraw"].BaseValue,
            pageflip.Owner.Creature, this);
    }

    protected override void OnUpgrade()
    { 
        this.DynamicVars["FirstDraw"].UpgradeValueBy(1M);
        this.DynamicVars["SecondDraw"].UpgradeValueBy(1M);
    }
}
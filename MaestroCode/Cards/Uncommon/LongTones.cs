using BaseLib.Abstracts;
using BaseLib.Utils;
using Maestro.MaestroCode.Character;
using MegaCrit.Sts2.Core.Entities.Cards;

namespace Maestro.MaestroCode.Cards.Uncommon;


[Pool(typeof(MaestroCardPool))]
public sealed class LongTones : CustomCardModel
{
    public LongTones() : base(1, CardType.Skill, CardRarity.Rare, TargetType.Self)
    {
    }

    public override int MaxUpgradeLevel => 999;
    
    
}
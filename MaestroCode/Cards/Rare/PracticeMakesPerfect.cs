using BaseLib.Abstracts;
using BaseLib.Utils;
using Maestro.MaestroCode.Character;
using MegaCrit.Sts2.Core.Entities.Cards;

namespace Maestro.MaestroCode.Cards.Rare;


[Pool(typeof(MaestroCardPool))]
public sealed class PracticeMakesPerfect : CustomCardModel
{
    public PracticeMakesPerfect() : base(0, CardType.Skill, CardRarity.Rare, TargetType.Self)
    {
    }
}
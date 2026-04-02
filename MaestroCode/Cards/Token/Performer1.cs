using BaseLib.Abstracts;
using BaseLib.Utils;
using Maestro.MaestroCode.Character;
using MegaCrit.Sts2.Core.Entities.Cards;

namespace Maestro.MaestroCode.Cards.Token;

[Pool(typeof(MaestroCardPool))]
public class Performer1 : CustomCardModel
{
    public Performer1() : base(2, CardType.Skill, CardRarity.Token, TargetType.Self)
    {
    }

    protected override HashSet<CardTag> CanonicalTags => [CustomCardTags.Performer];
    
}
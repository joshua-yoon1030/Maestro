using Maestro.MaestroCode.Cards.Common;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;
using MegaCrit.Sts2.Core.Models.Powers;

namespace Maestro.MaestroCode.Powers;

public class BowingTechniquePower: TemporaryDexterityPower
{
	public override AbstractModel OriginModel => (AbstractModel) ModelDb.Card<BowingTechnique>();
}

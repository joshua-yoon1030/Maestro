using BaseLib.Abstracts;
using BaseLib.Utils;
using Maestro.MaestroCode.Character;

namespace Maestro.MaestroCode.Potions;

[Pool(typeof(MaestroPotionPool))]
public abstract class MaestroPotion : CustomPotionModel;
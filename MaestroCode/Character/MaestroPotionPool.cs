using BaseLib.Abstracts;
using Maestro.MaestroCode.Extensions;
using Godot;

namespace Maestro.MaestroCode.Character;

public class MaestroPotionPool : CustomPotionPoolModel
{
    public override Color LabOutlineColor => Maestro.Color;


    public override string BigEnergyIconPath => "charui/big_energy.png".ImagePath();
    public override string TextEnergyIconPath => "charui/text_energy.png".ImagePath();
}
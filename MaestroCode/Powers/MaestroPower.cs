using BaseLib.Abstracts;
using BaseLib.Extensions;
using Maestro.MaestroCode.Extensions;
using Godot;

namespace Maestro.MaestroCode.Powers;

public abstract class MaestroPower : CustomPowerModel
{
    //Loads from Maestro/images/powers/your_power.png
    public override string CustomPackedIconPath
    {
        get
        {
            var path = $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".PowerImagePath();
            return ResourceLoader.Exists(path) ? path : "power.png".PowerImagePath();
        }
    }

    public override string CustomBigIconPath
    {
        get
        {
            var path = $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".BigPowerImagePath();
            return ResourceLoader.Exists(path) ? path : "power.png".BigPowerImagePath();
        }
    }
}
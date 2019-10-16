using System;
using Scripting;
using Ecue.Base.Data.Rendering;

public static class RGBtoHexProPhotoColor
{
    public static void Run(out string hex, out ProPhotoColor color, int red=0, int green=0, int blue=0, int alpha=255 )

    {
        hex = String.Format("#{0}{1}{2}{3}", alpha.ToString("X2"), red.ToString("X2"), green.ToString("X2"), blue.ToString("X2"));
        color = new ProPhotoColor(hex);
    }
}

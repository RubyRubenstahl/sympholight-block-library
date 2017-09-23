using System;
using Scripting;

/**
* Set the angle of a ColorEffect2DSequenceItem in degrees.
**/
public static class SetAngle
{	
	private const double TWO_PI = Math.PI * 2;
    public static void Run(string id, double angle)
    {
        ColorEffect2DSequenceItem layer = (ColorEffect2DSequenceItem) ContentObjectAccessor.GetObject(id);
		layer.Angle = -angle / 360 * TWO_PI;
    }
}

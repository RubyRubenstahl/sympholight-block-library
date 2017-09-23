using System;
using Scripting;
using SympholightCore.Rendering.Data;

/**
* Set the color of a SolidColor2DEffect with HSB 
* hue = 0-360
* saturation = 0-1
* brightness = 0-1
*/ 
public static class SetColorHSB
{
    public static void Run(string effectIdentifier, double hue=0, double saturation=255, double brightness=255)
    {
        ProPhotoColor color  = HsvToRgb(hue,saturation/255,brightness/255);
		SolidColor2DEffect effect = (SolidColor2DEffect) ContentObjectAccessor.GetObject(effectIdentifier);
		effect.Value = color;
		
    }
	
	
	private static ProPhotoColor HsvToRgb(double h, double S, double V)
	{    
	  double H = h;
	  while (H < 0) { H += 360; };
	  while (H >= 360) { H -= 360; };
	  double R, G, B;
	  if (V <= 0)
	    { R = G = B = 0; }
	  else if (S <= 0)
	  {
	    R = G = B = V;
	  }
	  else
	  {
	    double hf = H / 60.0;
	    int i = (int)Math.Floor(hf);
	    double f = hf - i;
	    double pv = V * (1 - S);
	    double qv = V * (1 - S * f);
	    double tv = V * (1 - S * (1 - f));
	    switch (i)
	    {

	      // Red is the dominant color

	      case 0:
	        R = V;
	        G = tv;
	        B = pv;
	        break;

	      // Green is the dominant color

	      case 1:
	        R = qv;
	        G = V;
	        B = pv;
	        break;
	      case 2:
	        R = pv;
	        G = V;
	        B = tv;
	        break;

	      // Blue is the dominant color

	      case 3:
	        R = pv;
	        G = qv;
	        B = V;
	        break;
	      case 4:
	        R = tv;
	        G = pv;
	        B = V;
	        break;

	      // Red is the dominant color

	      case 5:
	        R = V;
	        G = pv;
	        B = qv;
	        break;

	      // Just in case we overshoot on our math by a little, we put these here. Since its a switch it won't slow us down at all to put these here.

	      case 6:
	        R = V;
	        G = tv;
	        B = pv;
	        break;
	      case -1:
	        R = V;
	        G = pv;
	        B = qv;
	        break;

	      // The color is not defined, we should throw an error.

	      default:
	        //LFATAL("i Value error in Pixel conversion, Value is %d", i);
	        R = G = B = V; // Just pretend its black/white
	        break;
	    }
	  }
	  return new ProPhotoColor(
		  (byte) Clamp((int)(R * 255.0)),
		  (byte) Clamp((int)(G * 255.0)),
		  (byte) Clamp((int)(B * 255.0))
		  );
	}

	/// <summary>
	/// Clamp a value to 0-255
	/// </summary>
	private static int Clamp(int i)
	{
	  if (i < 0) return 0;
	  if (i > 255) return 255;
	  return i;
	}
	
	
}

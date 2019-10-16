using System;
using Scripting;

using Ecue.Base.Data.Rendering;
public static class ApButtonSettings
{
    public static void Run(string identifier, string bgColor="#FF444444", string borderColor="#FF888888", string textColor="#FFFFFFFF", string text="", bool bold=false, bool italic=false)
    {
     ProPhotoGradient RgbGradient = new ProPhotoGradient(new ProPhotoColor[1]
      {
        new ProPhotoColor(bgColor),
      });
		ActionPadButtonControl button = (ActionPadButtonControl) ContentObjectAccessor.GetObject(identifier);
		button.BorderColor = new ProPhotoColor(borderColor);
		button.ActiveTextColor = new ProPhotoColor(textColor);
		button.InactiveTextColor = new ProPhotoColor(textColor);
		button.InactiveBackgroundColor = RgbGradient;
		button.ActiveBackgroundColor= RgbGradient;
		button.ButtonText=text;
		button.ItalicText=italic;
		button.BoldText = bold;
	}

}

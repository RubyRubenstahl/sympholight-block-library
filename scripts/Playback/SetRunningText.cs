using System;
using Scripting;

/**
* Set the text of a RunningText (ScrollTextEffect) effect.
**/
public static class SetRunningText
{
    public static void Run(string id, string text="")
    {
        ScrollTextEffect scrollText = (ScrollTextEffect) ContentObjectAccessor.GetObject(id);
		scrollText.Text = text;
    }
}

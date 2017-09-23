using System;
using Scripting;

/**
* Output the the text in the given index
**/
public static class TextSelect
{
    public static string Run(int index=1, 
		string text1 = "", string text2 = "", string text3 = "", string text4 = "",
		string text5 = "", string text6 = "", string text7 = "", string text8 = "",
		string text9 = "", string text10 = "", string text11 = "", string text12 = ""
		)
    {
        string[] values = new string[] {
			text1, text2, text3, text4, text5, text6,
			text7, text8, text9, text10, text11, text12
		};
		if(index<1 || index > values.Length){
			Logger.Warn("TextSwitch index out of range", true);
			return "Index out of range";
		}
		return values[index-1];
    }
}

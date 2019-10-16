using System;
using Scripting;

public static class FormatDateTime
{
    public static void Run(DateTime dateTime,  out string output,string format="h:mm tt")
    {
      output = dateTime.ToString(format);
    }
}

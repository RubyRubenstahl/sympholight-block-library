using System;
using Scripting;

/**
* Play the sequence by it's identifier
**/
public static class StopSequence
{
    public static void Run(string id)
    {
        Sequence sequence = (Sequence) ContentObjectAccessor.GetObject(id);
		sequence.Stop();
    }
}
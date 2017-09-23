using System;
using Scripting;

/**
* Pause the sequence by it's identifier
**/
public static class PauseSequence
{
    public static void Run(string id)
    {
        Sequence sequence = (Sequence) ContentObjectAccessor.GetObject(id);
		sequence.Pause();
    }
}
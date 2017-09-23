using System;
using Scripting;

public static class GotoCue
{
    public static void Run(string sequenceId, int cueNum)
    {
			Sequence sequence = (Sequence) ContentObjectAccessor.GetObject(sequenceId);
			string cueId = String.Format("{0}.Cue_{1}", sequenceId, cueNum.ToString());
			Logger.Info(String.Format("GotoCue: {0}", cueId));
			Cue cue = (Cue) ContentObjectAccessor.GetObject(cueId);
			
			sequence.StartCue(cue);
    }
}



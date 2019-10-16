using System;
using Scripting;

public static class NextCue
{
    public static void Run(string sequenceId)
    {
			Sequence sequence = (Sequence) ContentObjectAccessor.GetObject(sequenceId);
			int playbackState = (int)sequence.PlaybackState;
			Logger.Info(playbackState.ToString());
			if(playbackState==0){
				sequence.Start();
			} else{
				sequence.GoToNextCue();
			}
		
    }
}



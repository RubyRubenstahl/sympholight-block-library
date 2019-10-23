using System;
using Scripting;

public static class RemoteCommands {
	public static void Run (string command) {
		string[] commandParts = command.Trim ().Split ('/');
		if (commandParts.Length < 2) {
			Logger.Error (string.Format ("Invalid REST command received {0}", command));
			return;
		}

		switch (commandParts[1].ToLower ()) {
			case "sequence":
				handleSequenceCommands (commandParts);
				break;
			case "grandmaster":
				handleGrandmasterLevelCommand (commandParts);
				break;

		}
	}

	public static void handleSequenceCommands (string[] commandParts) {

		if (commandParts.Length < 3) {
			Logger.Error ("Invalid sequence command received.\n Format must be '/sequence/<sequence_id>/<start, stop, continue, or pause>'\n Sequence IDs are case sensitive");
			return;
		}

		string sequenceId = commandParts[2];

		try {

			Sequence sequence = (Sequence) ContentObjectAccessor.GetObject (sequenceId);

			switch (commandParts[3].ToLower ()) {
				case "start":
					sequence.Start ();
					break;

				case "stop":
					sequence.Stop ();
					break;

				case "pause":
					sequence.Pause ();
					break;

				case "continue":
					sequence.Continue ();
					break;
				case "level":
					handleSequenceLevelCommand (sequence, commandParts);
					break;
				default:
					Logger.Error ("Invalid sequence command received.\n Format must be '/sequence/<sequence_id>/<start, stop, continue, or pause>'\n Sequence IDs are case sensitive");
					break;
			}
		} catch (Exception e) {
			Logger.Error (string.Format ("Sequence '{0}' does not exist", sequenceId));
			Logger.Error (e.ToString ());
		}
	}

	public static void handleSequenceLevelCommand (Sequence sequence, string[] commandParts) {
		if (commandParts.Length < 5) {
			Logger.Error ("Opacity level must be specified");
			return;
		}
		float level = float.Parse (commandParts[4]);

		// I added this to ensure opacity level is between 0 and 100. 
		if (level < 0 || level > 100) {
			Logger.Error ("Invalid level command received.\n Level must be between 0 and 100\n ");
			return;
		}

		sequence.Opacity = level;
	}

	public static void handleGrandmasterLevelCommand (string[] commandParts) {
		if (commandParts.Length < 2) {
			Logger.Error ("Grandmaster level must be specified");
			return;
		}
		float level = float.Parse (commandParts[2]);

		// I added this to ensure opacity level is between 0 and 100. 
		if (level < 0 || level > 100) {
			Logger.Error ("Invalid level command received.\n Level must be between 0 and 100\n ");
			return;
		}

		try {
			ShowInformation showInformation = (ShowInformation) ContentObjectAccessor.GetObject ("ShowInformation");
			showInformation.Opacity = level;

		} catch (Exception e) {
			Logger.Error ("Failed to set grandmaster level");
		}

	}
}
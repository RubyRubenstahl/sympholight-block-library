# RemoteCommands


RemoteCommands receives commands as raw text in a URL style format. It is primarily intended for use with the UDP, RS232, and RS485 blocks, but can be used with any text input. 

The code for the script can be found [here](../scripts/Network/RemoteCommands.cs)

## Input Ports
#### \<String>   command 
  The command to run. 
  
>  **!!!! Important !!!!** Make sure to set the Port mode to **"Passive"** otherwise your commands will not run properly. 

## Usage
Commands are sent in a URL style format. For example, the following command will start a sequence. 
```
/sequence/Sequence_1/start
```

Whitespace such as carriage returns, newlines, and spaces at the end of the command will be ignored, meaning that they can be included but are not necessary. 

# Commands

## /grandmaster/\<level_value>
Set the opacity level of the show grandmaster.

The level value is a floating point number between 0 and 100;

**Example:**
```
/sequence/Sequence_1/level/50
```


## /sequence/\<sequence_identifier>/start
Start a sequence from the beggining.

**Example:**
```
/sequence/Sequence_1/start
```

## /sequence/\<sequence_identifier>/stop
Stop a sequence completely.

**Example:**
```
/sequence/Sequence_1/stop
```

## /sequence/\<sequence_identifier>/pause
Pause a sequence

**Example:**
```
/sequence/Sequence_1/pause
```

## /sequence/\<sequence_identifier>/continue
Continue a sequence after pausing

**Example:**
```
/sequence/Sequence_1/continue
```

## /sequence/\<sequence_identifier>/level/\<level_value>
Set the opacity level of a sequence.

The level value is a floating point number between 0 and 100;

**Example:**
```
/sequence/Sequence_1/level/50
```

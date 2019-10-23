# Sympholight Block Library
The block library is a set of c# scripts that can be imported into Sympholight to create workflow designer blocks. 


## Getting the code
The library can be downloaded by using the green "Clone or download" button at the top right of the screen. Once downloaded, scripts can be imported using the "import" button in the Sympholight Scripting tab. 

As an alterantive, the code can be copied directly from the github page and pasted into a new script within the Sympholight Scripting tab. 

# Script documentation
The is not currently documentation for most scripts. As it is added, links will be added to this section.

* Networking
  * [RemoteCommands](docs/RemoteCommands.md) - Run commands from RS232, RS485, and UDP blocks. 


## Usage
There are a couple of things to know in order to use the blocks included in this library successfully. 

### Configuring Ports ###

There are 2 ways to set values on input ports in the block library. By default, inputs are set to `Property` mode. In this mode, you set the value on the port by selecting the block and manually entering the value in the property window for the block. 

In order to allow you to take values in from other blocks, you must change the Input Type setting from `Property` to `Port`. When you do this, the circle at the input port on the block will show a thin line instead of a thick line to indicate that it is available for input. Once you do this, you can connect it to the output of another block with a compatible data type.  

### Identifiers (id)
Blocks that work with specific SYMPHOLIGHT Objects (Sequences, Cues, Effects, etc) have anÂ idÂ input.Â The identifier is a unique name that you must set for the object that you want to access. Please read this article to get an understanding of what identifiers are and how they work

 
### Keys
Some of the blocks in this library,Â including the Counter andÂ LimitedIncrement blocks, must keep track of a value between runs of the script. Due to the way that the blocks must be written, each instance of a block will use the same memory location to track values.Â Because of this, multiple instances of the same block type would override the value of the others of the same type when it is run. In order to avoid this, a unique key can be provided for each instance of the block. This willÂ allow the block to access its own separate memory location, enabling multiple instances of the same block to be used without them interfering with each other. The key is simply a string(text) value that must be different for each instance of that block type. 


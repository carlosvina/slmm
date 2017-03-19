#### SLMM

### 1 - Instructions and requirements to run the application

The following software is needed

* Visual Studio 2015
* .NET Framework 4.5.2

NUnit3 framework for unit testing was used. Nuget should automatically download this dependency.

### 2 - Assumptions

* SLMM always starts at (0,0) [width, length] facing north.
* SLMM will always wait the specific time for moving even if movement not possible (ie: SLMM at boundary)
* When no commands in the queue SLMM will run default "DoNothing" command that lasts 5s.
* When "Stop" command issued user won't be able to give more commands.
* When "Stop" command gets executed program will stop. 



### Controls

* Arrow keys (Up, Left, Right, Down) will send Move, TurnLeft, TurnRight, Stop commands.
* Esc key will send Stop command.
* Enter and M keys will send Mown command.


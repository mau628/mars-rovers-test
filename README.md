# Mars Rovers

A test project for DealerOn.

## Requirements

NASA intends to land robotic rovers on Mars to explore a particularly curious-looking plateau. The rovers must navigate
this rectangular plateau in a way so that their on board cameras can get a complete image of the surrounding terrain to
send back to Earth.

A simple two-dimensional coordinate grid is mapped to the plateau to aid in rover navigation. Each point on the grid is
represented by a pair of numbers X Y which correspond to the number of points East or North, respectively, from the
origin. The origin of the grid is represented by 0 0 which corresponds to the southwest corner of the plateau. 0 1 is
the point directly north of 0 0, 1 1 is the point immediately east of 0 1, etc. A rover’s current position and heading are
represented by a triple X Y Z consisting of its current grid position X Y plus a letter Z corresponding to one of the four
cardinal compass points, N E S W. For example, 0 0 N indicates that the rover is in the very southwest corner of the
plateau, facing north.

NASA remotely controls rovers via instructions consisting of strings of letters. Possible instruction letters are L, R,
and M. L and R instruct the rover to turn 90 degrees left or right, respectively (without moving from its current spot),
while M instructs the rover to move forward one grid point along its current heading.
Your task is write an application that takes the test input (instructions from NASA) and provides the expected output
(the feedback from the rovers to NASA). Each rover will move in series, i.e. the next rover will not start moving until
the one preceding it finishes.

### Input

Assume the southwest corner of the grid is 0,0 (the origin). The first line of input establishes the exploration grid
bounds by indicating the coordinates corresponding to the northeast corner of the plateau. Next, each rover is given its
instructions in turn. Each rover’s instructions consists of two lines of strings. The first string confirms the rover’s
current position and heading. The second string consists of turn / move instructions.

### Output

Once each rover has received and completely executed its given
instructions, it transmits its updated position and heading to NASA.

## Test Data

|Input
|---
|5 5
|1 2 N
|LMLMLMLMM
|3 3 E
|MMRMMRMRRM

|Output
|---
|1 3 N
|5 1 E

## Running the application
1. `dotnet restore`
1. `dotnet build`
1. `dotnet run --project .\mars-rovers\mars-rovers.csproj`

Or you can run the application from VSCode by pressing F5.

## Running the tests

Run the tests by running the `test` task from VSCode.
You can also run the tests from the command line by running
`dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=lcov /p:CoverletOutput=./lcov.info`
from the root of the project.

This will show code coverage in output window.


## Notes
### Assumptions
- A console application is assumed.  No UI is provided.
- A one at a time run is assumed.  The application will not run until all rovers have been placed.
- The only validation done is to ensure that the rovers instructions are valid.  No validation is done to ensure that the rovers are placed on the grid.
- VSCode is assumed as the IDE.  The project is configured to run from VSCode.

### Design
- Dependency injection is used to allow for easy testing and extensibility.
- Graphic rendering is done using ASCII characters.  This is not the most efficient way to render graphics, but it is the easiest to implement and provides a good visual representation of the grid.
- Moq, FluentAssertions and Coverlet are used for testing, as they are the most popular and well supported libraries for testing in .NET Core.
- Program is excluded from code coverage, as it is not testable.

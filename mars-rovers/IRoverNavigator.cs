namespace mars_rovers;

using System.Collections.Generic;

using mars_rovers.Models;

public interface IRoverNavigator
{
    List<RoverInstructions> NavigateAll(List<string> inputValues);
}

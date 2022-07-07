using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Web.Controllers;
using Web.Models;

namespace Web.Tests.Controllers;

public class DummyControllerTests
{
    [Fact]
    public void GetPersons_ReturnOkObjectResultWithPersons()
    {
        // Arrange
        var controller = new DummyController(new Mock<ILogger<DummyController>>().Object);
        
        // Act
        var result = controller.GetPersons();
        
        // Arrange
        Assert.NotNull(result);
        Assert.IsType<ActionResult<IEnumerable<Person>>>(result);
    }
}
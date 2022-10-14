using IceCream.Application.Dtos.Request;
using IceCream.Application.Interfaces;
using IceCream.Utilities.Static;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace IceCream.Test.Category;
[TestClass]
public class CategoryApplicationTest
{
    private static WebApplicationFactory<Program>? _factory = null;
    private static IServiceScopeFactory? _scopeFactory = null;

    [ClassInitialize]
    public static void Initialize(TestContext _testContext)
    {
        _factory = new CustomWebApplicationFactory();
        _scopeFactory = _factory.Services.GetService<IServiceScopeFactory>();
    }

    [TestMethod]
    public async Task RegisterCategory_WhenSendingNullValuesOrEmpty_ValidationErrors()
    {
        using var scope = _scopeFactory?.CreateScope();
        var context = scope?.ServiceProvider.GetService<ICategoryApplication>();

        //Arrange
        var name = "";
        var description = "";
        var state = 1;
        var expected = ReplyMessage.MESSAGE_VALIDATE;

        //Act
        var result = await context!.RegisterCategory(new CategoryRequestDto()
        {
            Name = name,
            Description = description,
            State = state
        });
        var current = result.Message;

        //Assert
        Assert.AreEqual(expected, result);
    }

}

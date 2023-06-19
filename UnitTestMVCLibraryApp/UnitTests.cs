using MVCLibraryApp.Controllers;
using MVCLibraryApp.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Microsoft.AspNetCore.Identity;
using MVCLibraryApp.Interfaces;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using MVCLibraryApp.Services;
using Moq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using MVCLibraryApp.Data;

namespace YourNamespace.Tests;

[TestFixture]
public class UnitTests
{
    private ApplicationDbContext context;
    private UserManager<BezoekerModel> userManager;

    private Mock<IAccountService> accountServiceMock;
    private Mock<IUserRedirectionService> redirectionServiceMock;
    private Mock<RoleManager<IdentityRole>> roleManagerMock;
    private BezoekerController controller;


    [SetUp]
    public void Setup()
    {
        // Create options for DbContext instance
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "BibliotheekS1186143") // Unique name for in-memory database
            .Options;

        // Instantiate DbContext with InMemory option
        context = new ApplicationDbContext(options);

        // UserStore and UserManager for UserManager instance
        var userStore = new UserStore<BezoekerModel>(context);
        userManager = new UserManager<BezoekerModel>(userStore, null, null, null, null, null, null, null, null);

        // Mock SignInManager
        var signInManagerMock = new Mock<SignInManager<BezoekerModel>>(userManager, new HttpContextAccessor(), new Mock<IUserClaimsPrincipalFactory<BezoekerModel>>().Object, null, null, null, null);

        // Mock RoleManager
        var roleStore = new Mock<IRoleStore<IdentityRole>>();
        roleManagerMock = new Mock<RoleManager<IdentityRole>>(roleStore.Object, null, null, null, null);

        // Mock IAccountService
        accountServiceMock = new Mock<IAccountService>();

        // Mock UserRedirectionService
        redirectionServiceMock = new Mock<IUserRedirectionService>();

        // Instantiate the controller with UserManager and other mocked instances
        controller = new BezoekerController(context, userManager, signInManagerMock.Object, roleManagerMock.Object, accountServiceMock.Object, redirectionServiceMock.Object);
    }

    [Test]
    public async Task Dashboard_RedirectsToLogin_WhenUserIsNotAuthenticated()
    {
        // Arrange
        var expectedRedirectResult = new RedirectToActionResult("Login", "Visitor", null);
        redirectionServiceMock.Setup(rs => rs.GetRedirectBasedOnRole(It.IsAny<ClaimsPrincipal>()))
                              .ReturnsAsync(expectedRedirectResult);

        // Act
        var result = await controller.Dashboard();

        // Assert
        Assert.IsInstanceOf<RedirectToActionResult>(result);
        var redirectResult = result as RedirectToActionResult;
        Assert.AreEqual(expectedRedirectResult.ControllerName, redirectResult.ControllerName);
        Assert.AreEqual(expectedRedirectResult.ActionName, redirectResult.ActionName);
    }

    [Test]
    public async Task Dashboard_RedirectsToBezoekerDashboard_WhenUserIsBezoeker()
    {
        // Arrange
        var expectedRedirectResult = new RedirectToActionResult("Dashboard", "Visitor", null);

        // Create a ClaimsPrincipal with the role of Visitor
        var claimsPrincipal = new ClaimsPrincipal(
            new ClaimsIdentity(
                new Claim[]
                {
                    new Claim(ClaimTypes.Name, "TestUser"),
                    new Claim(ClaimTypes.Role, "Visitor")
                },
                "TestAuthentication"
            )
        );

        redirectionServiceMock.Setup(rs => rs.GetRedirectBasedOnRole(It.Is<ClaimsPrincipal>(p => p == claimsPrincipal)))
                              .ReturnsAsync(expectedRedirectResult);

        // Add the ClaimsPrincipal to the HttpContext.User of the Controller
        controller.ControllerContext = new ControllerContext()
        {
            HttpContext = new DefaultHttpContext() { User = claimsPrincipal }
        };

        // Act
        var result = await controller.Dashboard();

        // Assert
        Assert.IsInstanceOf<RedirectToActionResult>(result);
        var redirectResult = result as RedirectToActionResult;
        Assert.AreEqual(expectedRedirectResult.ControllerName, redirectResult.ControllerName);
        Assert.AreEqual(expectedRedirectResult.ActionName, redirectResult.ActionName);
    }

    [Test]
    public async Task Dashboard_RedirectsToMedewerkerDashboard_WhenUserIsMedewerker()
    {
        // Arrange
        var expectedRedirectResult = new RedirectToActionResult("Dashboard", "Employee", null);

        // Create a ClaimsPrincipal with the role of Employee
        var claimsPrincipal = new ClaimsPrincipal(
            new ClaimsIdentity(
                new Claim[]
                {
                    new Claim(ClaimTypes.Name, "TestUser"),
                    new Claim(ClaimTypes.Role, "Employee")
                },
                "TestAuthentication"
            )
        );

        redirectionServiceMock.Setup(rs => rs.GetRedirectBasedOnRole(It.Is<ClaimsPrincipal>(p => p == claimsPrincipal)))
                              .ReturnsAsync(expectedRedirectResult);

        // Add the ClaimsPrincipal to the HttpContext.User of the Controller
        controller.ControllerContext = new ControllerContext()
        {
            HttpContext = new DefaultHttpContext() { User = claimsPrincipal }
        };

        // Act
        var result = await controller.Dashboard();

        // Assert
        Assert.IsInstanceOf<RedirectToActionResult>(result);
        var redirectResult = result as RedirectToActionResult;
        Assert.AreEqual(expectedRedirectResult.ControllerName, redirectResult.ControllerName);
        Assert.AreEqual(expectedRedirectResult.ActionName, redirectResult.ActionName);
    }

    [Test]
    public async Task Dashboard_RedirectsToBeheerderDashboard_WhenUserIsBeheerder()
    {
        // Arrange
        var expectedRedirectResult = new RedirectToActionResult("Dashboard", "Admin", null);

        // Create a ClaimsPrincipal with the role of Admin
        var claimsPrincipal = new ClaimsPrincipal(
            new ClaimsIdentity(
                new Claim[]
                {
                    new Claim(ClaimTypes.Name, "TestUser"),
                    new Claim(ClaimTypes.Role, "Admin")
                },
                "TestAuthentication"
            )
        );

        redirectionServiceMock.Setup(rs => rs.GetRedirectBasedOnRole(It.Is<ClaimsPrincipal>(p => p == claimsPrincipal)))
                              .ReturnsAsync(expectedRedirectResult);

        // Add the ClaimsPrincipal to the HttpContext.User of the Controller
        controller.ControllerContext = new ControllerContext()
        {
            HttpContext = new DefaultHttpContext() { User = claimsPrincipal }
        };

        // Act
        var result = await controller.Dashboard();

        // Assert
        Assert.IsInstanceOf<RedirectToActionResult>(result);
        var redirectResult = result as RedirectToActionResult;
        Assert.AreEqual(expectedRedirectResult.ControllerName, redirectResult.ControllerName);
        Assert.AreEqual(expectedRedirectResult.ActionName, redirectResult.ActionName);
    }

    [Test]
    public async Task Register_Get_ReturnsView_WhenUserIsNotAuthenticated()
    {
        // Arrange
        redirectionServiceMock.Setup(rs => rs.GetRedirectBasedOnRole(It.IsAny<ClaimsPrincipal>()))
                              .ReturnsAsync((IActionResult)null);

        // Act
        var result = await controller.Register();

        // Assert
        Assert.IsInstanceOf<ViewResult>(result);
    }

    [Test]
    public async Task Register_Get_Redirects_WhenUserIsAuthenticated()
    {
        // Arrange
        var expectedRedirectResult = new RedirectToActionResult("Dashboard", "Visitor", null);
        redirectionServiceMock.Setup(rs => rs.GetRedirectBasedOnRole(It.IsAny<ClaimsPrincipal>()))
                              .ReturnsAsync(expectedRedirectResult);

        // Act
        var result = await controller.Register();

        // Assert
        Assert.IsInstanceOf<RedirectToActionResult>(result);
        var redirectResult = result as RedirectToActionResult;
        Assert.AreEqual(expectedRedirectResult.ControllerName, redirectResult.ControllerName);
        Assert.AreEqual(expectedRedirectResult.ActionName, redirectResult.ActionName);
    }

    [Test]
    public async Task Register_GET_ReturnsViewResult()
    {
        // Arrange

        // Act
        var result = await controller.Register();

        // Assert
        Assert.IsInstanceOf<ViewResult>(result);
    }

    [Test]
    public async Task Register_POST_WithValidModelState_RedirectsToDashboard()
    {
        // Arrange
        var model = new RegisterModel();
        accountServiceMock.Setup(s => s.RegisterUser(model))
            .ReturnsAsync(IdentityResult.Success);

        // Act
        var result = await controller.Register(model);

        // Assert
        Assert.IsInstanceOf<RedirectToActionResult>(result);
        var redirectResult = (RedirectToActionResult)result;
        Assert.AreEqual("Dashboard", redirectResult.ActionName);
    }

    [Test]
    public async Task Register_POST_WithInvalidModelState_ReturnsViewResultWithModel()
    {
        // Arrange
        var model = new RegisterModel();
        controller.ModelState.AddModelError("Email", "Email is required.");

        // Act
        var result = await controller.Register(model);

        // Assert
        Assert.IsInstanceOf<ViewResult>(result);
        var viewResult = (ViewResult)result;
        Assert.AreEqual(model, viewResult.Model);
    }

    [Test]
    public async Task Register_POST_WithFailedRegistration_ReturnsViewResultWithErrors()
    {
        // Arrange
        var model = new RegisterModel();
        var error = new IdentityError { Description = "Registration failed." };
        var result = IdentityResult.Failed(error);
        accountServiceMock.Setup(s => s.RegisterUser(model)).ReturnsAsync(result);

        // Act
        var actionResult = await controller.Register(model);
        var viewResult = (ViewResult)actionResult;

        // Assert
        Assert.IsInstanceOf<ViewResult>(actionResult);
        Assert.IsTrue(viewResult.ViewData.ModelState.ContainsKey(string.Empty));
        var modelStateEntry = viewResult.ViewData.ModelState[string.Empty];
        Assert.IsTrue(modelStateEntry.Errors.Any(e => e.ErrorMessage == error.Description));
    }

    [Test]
    public async Task Logout_RedirectsToHomeControllerIndex()
    {
        // Arrange

        // Act
        var result = await controller.Logout();

        // Assert
        Assert.IsInstanceOf<RedirectToActionResult>(result);
        var redirectResult = (RedirectToActionResult)result;
        Assert.AreEqual("Index", redirectResult.ActionName);
        Assert.AreEqual("Home", redirectResult.ControllerName);
    }
    
}

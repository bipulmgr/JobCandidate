using Microsoft.AspNetCore.Mvc;

namespace JobCandidate.Api.Controllers.V1;
/// <summary>
/// Base controller that provides common functionality for API controllers.
/// </summary>
[ApiController]
[Route("api/v1/[controller]")]
public abstract class BaseController : ControllerBase
{
    public BaseController()
    {
    }
}

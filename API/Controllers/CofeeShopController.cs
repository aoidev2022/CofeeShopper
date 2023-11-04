using API.Services;

using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CofeeShopController : ControllerBase
{
    private readonly ICofeeShopService _cofeeShopService;

    public CofeeShopController(ICofeeShopService cofeeShopService)
    {
        _cofeeShopService = cofeeShopService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var list = await _cofeeShopService.GetAll();
        return Ok(list);
    }
}

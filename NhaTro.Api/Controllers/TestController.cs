// NhaTroSaaS.Api/Controllers/TestController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NhaTro.Infrastructure.Persistence;
using NhaTro.Api.Constants;

namespace NhaTro.Api.Controllers;

[ApiController]
[Route("api/test")]  // controller test
public class TestController : ControllerBase
{
    private readonly AppDbContext _context;
    public TestController(AppDbContext context) => _context = context;

    [HttpGet("vai-tro")]
    public async Task<IActionResult> GetVaiTro()
    {
        var list = await _context.VaiTros.ToListAsync();
        return Ok(list);
    }
}
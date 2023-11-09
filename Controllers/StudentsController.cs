using Microsoft.AspNetCore.Mvc;

namespace miniApi.Controllers;

// localhost:port/api/students
[Route("api/[controller]")]
[ApiController]
public class StudentsController : Controller
{
    // GET : localhost:port/api/students
    [HttpGet]
    public IActionResult GetAllStudets()
    {
        string[] allStudent = { "ok1", "ok2", "ok3" };
        return Ok(allStudent);
    }
}
using Microsoft.AspNetCore.Mvc;
using signalr_poc.Domain.Entities;

namespace signalr_poc.Controllers;

[Controller]
[Route("test")]
public class SimpleController : ControllerBase
{
    [HttpGet]
    public ActionResult test()
    {
        return Ok(new Dummy
        {
            Id = 1,
            Label = "123",
            Description = "data"
        });
    }
}
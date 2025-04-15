using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NQDTechPro.Controllers
{
    [Route("/")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public string Hello()
        {
            return "Hello, NQDTech is running !!!";
        }
    }
}

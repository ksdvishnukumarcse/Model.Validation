using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Validation.API.Validator;
using Model.Validation.Common.Filters;
using System.Threading.Tasks;

namespace Model.Validation.API.Controllers
{
    [Route("validate")]
    [ApiController]
    //[ModelValidationActionFilter]
    public class ClassLevelValidationController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> InsertData([FromBody] PersonValidator person)
        {
            ObjectResult objectResult = null;
            objectResult = StatusCode(StatusCodes.Status200OK, "Success");
            return objectResult;
        }
    }
}

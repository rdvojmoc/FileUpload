using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FileUpload.Controllers
{
    [Route("api/[controller]")]
    public class FilesController : Controller
    {
        // POST api/values
        [HttpPost]
		[DisableFormValueModelBinding]
        public IActionResult Post(Asset asset)
        {
			if (!ControllerContext.ModelState.IsValid)
			{
				return BadRequest(ControllerContext.ModelState);
			}

			return Ok();
        }
		
    }
}

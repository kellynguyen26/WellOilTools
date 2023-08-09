using Microsoft.AspNetCore.Mvc;
using OilWellToolsMicroservice.Models;
using OilWellToolsMicroservice.Repository;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OilWellToolsMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OilWellToolsController : ControllerBase
    {
        private readonly IOilWellToolRepository _toolRepository;

        public OilWellToolsController(IOilWellToolRepository toolRepository)
        {
            _toolRepository = toolRepository;
        }

        // GET: api/<OilWellToolsController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<OilWellTool> tools = _toolRepository.GetTools(); ;
            return new OkObjectResult(tools);
        }

        // GET api/<OilWellToolsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            OilWellTool? tool = _toolRepository.GetToolByID(id);
            if (tool == null)
            {
                return NotFound($"Tool (id={id}) is not found.");
            }
            return new OkObjectResult(tool);
        }

        // POST api/<OilWellToolsController>
        [HttpPost]
        public IActionResult Post([FromBody] OilWellTool tool)
        {
            _toolRepository.InsertTool(tool);
            return CreatedAtAction(nameof(Get), new { id = tool.Id }, tool);
        }

        // PUT api/<OilWellToolsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] OilWellTool tool)
        {
            if (tool != null)
            {
                _toolRepository.UpdateTool(tool);
                return new OkResult();
            }
            return new NoContentResult();
        }

        // DELETE api/<OilWellToolsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _toolRepository.DeleteTool(id);
            return new OkResult();
        }
    }
}

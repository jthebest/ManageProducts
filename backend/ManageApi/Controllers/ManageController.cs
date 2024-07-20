using ManageApi.Interfaces;
using ManageApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManageApi.Controllers
{
    [Route("api/manages")]
    [ApiController]
    public class ManageController : ControllerBase
    {
        private readonly IManageService _manageService;

        public ManageController(IManageService manageService)
        {
            _manageService = manageService;
        }

        // GET: api/manages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manage>>> GetManages()
        {
            var manages = await _manageService.GetManages();
            return Ok(manages);
        }

        // GET: api/manages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Manage>> GetManage(long id)
        {
            var manage = await _manageService.GetManage(id);

            if (manage == null)
            {
                return NotFound();
            }

            return Ok(manage);
        }

        // POST: api/manages
        [HttpPost]
        public async Task<ActionResult<Manage>> CreateManage(Manage manage)
        {
            var createdManage = await _manageService.CreateManage(manage);
            return CreatedAtAction(nameof(GetManage), new { id = createdManage.Id }, createdManage);
        }

        // PUT: api/manages/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateManage(long id, Manage manage)
        {
            if (id != manage.Id)
            {
                return BadRequest();
            }

            await _manageService.UpdateManage(id, manage);

            return NoContent();
        }

        // DELETE: api/manages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManage(long id)
        {
            await _manageService.DeleteManage(id);

            return NoContent();
        }
    }
}

using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service.manager;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerService _managerService;

        public ManagerController(IManagerService managerService)
        {
            _managerService = managerService;
        }


        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_managerService.GetAll());
        }


        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var manager = _managerService.GetById(id);
            if (manager == null)
            {
                return NotFound();
            }

            return Ok(manager);
        }


        [HttpPost]
        public ActionResult Create(Manager manager)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _managerService.Create(manager);
            return CreatedAtAction("GetById", new { id = manager.Id }, manager);
        }


        [HttpPut("{id}")]
        public ActionResult Update(int id, Manager manager)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != manager.Id)
            {
                return BadRequest();
            }

            try
            {
                _managerService.Update(manager);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(manager);
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var manager = _managerService.GetById(id);
            if (manager == null)
            {
                return NotFound();
            }

            _managerService.Delete(manager);
            return NoContent();
        }

    }
}

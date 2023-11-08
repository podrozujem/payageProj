using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service.floor;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class FloorController : ControllerBase
    {
        private readonly IFloorService floorService;

        public FloorController(IFloorService floorService)
        {
            this.floorService = floorService;
        }

        //GET: api/buildings
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(floorService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var floor = floorService.GetById(id);
            if (floor == null)
            {
                return NotFound();
            }
            return Ok(floor);
        }

        [HttpGet("floorsByBuilding/{id}")]
        public ActionResult GetFloorsByBuilding(int id)
        {
            return Ok(floorService.GetFloorsByBuilding(id));
        }

        [HttpPost]
        public ActionResult Create(Floor floor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            floorService.Create(floor);
            return CreatedAtAction("GetById", new { id = floor.Id }, floor);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, Floor floor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != floor.Id)
            {
                return BadRequest();
            }

            try
            {
                floorService.Update(floor);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(floor);
        }

        // DELETE api/rooms/2
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var floor = floorService.GetById(id);
            if (floor == null)
            {
                return NotFound();
            }

            floorService.Delete(floor);
            return NoContent();
        }     
    }
}

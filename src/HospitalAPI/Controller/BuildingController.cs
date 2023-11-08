using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service.building;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly IBuildingService buildingService;

        public BuildingController(IBuildingService buildingService)
        {
            this.buildingService = buildingService;
        }

        //GET: api/buildings
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(buildingService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var building = buildingService.GetById(id);
            if (building == null)
            {
                return NotFound();
            }
            return Ok(building);
        }

        [HttpPost]
        public ActionResult Create(Building building)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            buildingService.Create(building);
            return CreatedAtAction("GetById", new { id = building.Id }, building);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, Building building)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != building.Id)
            {
                return BadRequest();
            }

            try
            {
                buildingService.Update(building);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(building);
        }

        // DELETE api/rooms/2
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var building = buildingService.GetById(id);
            if (building == null)
            {
                return NotFound();
            }

            buildingService.Delete(building);
            return NoContent();
        }
    }
}

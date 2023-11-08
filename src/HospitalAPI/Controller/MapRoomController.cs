﻿using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Model.map;
using HospitalLibrary.Core.Service.building;
using HospitalLibrary.Core.Service.map;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HospitalAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapRoomController : ControllerBase
    {
        private readonly IMapRoomService mapService;

        public MapRoomController(IMapRoomService mapService)
        {
            this.mapService = mapService;
        }
        //GET: api/buildings
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(mapService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var mapElement = mapService.GetById(id);
            if (mapElement == null)
            {
                return NotFound();
            }
            return Ok(mapElement);
        }

        /*[HttpGet("mapRoomsByRooms")]
        public ActionResult GetMapRoomsByRooms(List<Room> rooms)
        {
            return Ok(mapService.GetMapRoomsByRooms(rooms));
        }*/
        [HttpGet("mapRoomsByFloor/{id}")]
        public ActionResult GetMapRoomsByFloor(int id)
        {
            return Ok(mapService.GetMapRoomsByFloor(id));
        }

        [HttpPost]
        public ActionResult Create(MapRoom mapElement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            mapService.Create(mapElement);
            return CreatedAtAction("GetById", new { id = mapElement.Id }, mapElement);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, MapRoom mapElement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mapElement.Id)
            {
                return BadRequest();
            }

            try
            {
                mapService.Update(mapElement);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(mapElement);
        }

        // DELETE api/rooms/2
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var mapElement = mapService.GetById(id);
            if (mapElement == null)
            {
                return NotFound();
            }

            mapService.Delete(mapElement);
            return NoContent();
        }
    }
}

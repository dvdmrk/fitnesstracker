﻿using Microsoft.AspNetCore.Mvc;
using RoutineCatalogue.Models.Entities;
using RoutineCatalogue.Models.ViewModels;
using RoutineCatalogue.MVC.Repositories;
using System;
namespace RoutineCatalogue.API.Controllers
{
    public class ExerciseController : ControllerBase
    {
        IRepository<Exercise, ExerciseViewModel, ExerciseIndexViewModel> _repo;
        public ExerciseController(IRepository<Exercise, ExerciseViewModel, ExerciseIndexViewModel> repo)
        {
            _repo = repo;
        }
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                return Ok(_repo.Get(id));
            }
            catch (Exception e)
            {
                return BadRequest(new { e.Message });
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] Exercise body)
        {
            try
            {
                return Ok(_repo.Add(body));
            }
            catch (Exception e)
            {
                return BadRequest(new { e.Message });
            }
        }
        [HttpPut]
        public IActionResult Put([FromBody] ExerciseViewModel body)
        {
            try
            {
                _repo.Update(body);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new { e.Message });
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _repo.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new { e.Message });
            }
        }
    }
}

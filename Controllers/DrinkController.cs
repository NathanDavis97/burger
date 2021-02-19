
using System.Collections.Generic;
using System;
using burger.Models;
using burger.Services;
using Microsoft.AspNetCore.Mvc;

namespace burger.Controllers
{
    [ApiController]
    [Route("[controller]")]
        public class DrinkController : ControllerBase
    {
    private readonly DrinkService _ds;
    public DrinkController(DrinkService ds)
    {
      _ds = ds;
    }
    [HttpGet]
    public ActionResult<IEnumerable<Drink>> Get()
    {
        try
        {
        return Ok(_ds.Get());
      }
        catch (System.Exception err)
        {
            
                return BadRequest(err.Message);
        }
    }
        [HttpGet("{id}")]
        public ActionResult<Drink> Get(int id)
        {
            try
            {
        Drink drink = _ds.GetById(id);
        return Ok(drink);
      }
            catch (Exception e)
            {
                
        return BadRequest(e.Message);
            }
        }
        [HttpPost]
    public ActionResult<Drink> Create([FromBody] Drink newDrink)
    {
        try
        {
        Drink drink = _ds.Create(newDrink);
        return Ok(drink);
      }
        catch (System.Exception err)
        {
            
                return BadRequest(err.Message);
        }
    }
[HttpDelete("{drinkId}")]
    public ActionResult<string> Delete(int drinkId)
    {
      try
      {
        _ds.Delete(drinkId);
        {
          return Ok("Drink Purchased");
        };
        throw new System.Exception("Drink does not exist");
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }

    }

   [HttpPut("{drinkId}")]
        public ActionResult<Drink> edit([FromBody] Drink drinkUpdate, int drinkId)
        {
            try
            {
        drinkUpdate.Id = drinkId;
        Drink drink = _ds.Edit(drinkUpdate);
        return Ok(drinkUpdate);
      }
            catch (System.Exception err)
            {
                
                return BadRequest(err.Message);
            }
        }
  }
}
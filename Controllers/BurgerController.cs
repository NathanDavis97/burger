
using System.Collections.Generic;
using System;
using burger.Models;
using burger.Services;
using Microsoft.AspNetCore.Mvc;

namespace burger.Controllers
{
    [ApiController]
    [Route("[controller]")]
        public class BurgerController : ControllerBase
    {
    private readonly BurgerService _bs;
    public BurgerController(BurgerService bs)
    {
      _bs = bs;
    }
    [HttpGet]
    public ActionResult<IEnumerable<Burger>> Get()
    {
        try
        {
        return Ok(_bs.Get());
      }
        catch (System.Exception err)
        {
            
                return BadRequest(err.Message);
        }
    }
        [HttpGet("{id}")]
        public ActionResult<Burger> Get(int id)
        {
            try
            {
        Burger burger = _bs.GetById(id);
        return Ok(burger);
      }
            catch (Exception e)
            {
                
        return BadRequest(e.Message);
            }
        }
        [HttpPost]
    public ActionResult<Burger> Create([FromBody] Burger newBurger)
    {
        try
        {
        Burger burger = _bs.Create(newBurger);
        return Ok(burger);
      }
        catch (System.Exception err)
        {
            
                return BadRequest(err.Message);
        }
    }
[HttpDelete("{burgerId}")]
    public ActionResult<string> Delete(int burgerId)
    {
      try
      {
        _bs.Delete(burgerId);
        {
          return Ok("Burger Purchased");
        };
        throw new System.Exception("Burger does not exist");
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }

    }

   [HttpPut("{burgerId}")]
        public ActionResult<Burger> edit([FromBody] Burger burgerUpdate, int burgerId)
        {
            try
            {
        burgerUpdate.Id = burgerId;
        Burger burger = _bs.Edit(burgerUpdate);
        return Ok(burgerUpdate);
      }
            catch (System.Exception err)
            {
                
                return BadRequest(err.Message);
            }
        }
  }
}
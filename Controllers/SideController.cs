
using System.Collections.Generic;
using System;
using burger.Models;
using burger.Services;
using Microsoft.AspNetCore.Mvc;

namespace burger.Controllers
{
    [ApiController]
    [Route("[controller]")]
        public class SideController : ControllerBase
    {
    private readonly SideService _ss;
    public SideController(SideService ss)
    {
      _ss = ss;
    }
    [HttpGet]
    public ActionResult<IEnumerable<Side>> Get()
    {
        try
        {
        return Ok(_ss.Get());
      }
        catch (System.Exception err)
        {
            
                return BadRequest(err.Message);
        }
    }
        [HttpGet("{id}")]
        public ActionResult<Side> Get(int id)
        {
            try
            {
        Side side = _ss.GetById(id);
        return Ok(side);
      }
            catch (Exception e)
            {
                
        return BadRequest(e.Message);
            }
        }
        [HttpPost]
    public ActionResult<Side> Create([FromBody] Side newSide)
    {
        try
        {
        Side side = _ss.Create(newSide);
        return Ok(side);
      }
        catch (System.Exception err)
        {
            
                return BadRequest(err.Message);
        }
    }
[HttpDelete("{sideId}")]
    public ActionResult<string> Delete(int sideId)
    {
      try
      {
        _ss.Delete(sideId);
        {
          return Ok("Side Purchased");
        };
        throw new System.Exception("Side does not exist");
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }

    }

   [HttpPut("{sideId}")]
        public ActionResult<Side> edit([FromBody] Side sideUpdate, int sideId)
        {
            try
            {
        sideUpdate.Id = sideId;
        Side side = _ss.Edit(sideUpdate);
        return Ok(sideUpdate);
      }
            catch (System.Exception err)
            {
                
                return BadRequest(err.Message);
            }
        }
  }
}
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class AutosController : ControllerBase
{
    private readonly MongoDbContext _context;

    public AutosController(MongoDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Auto>> Get()
    {
        var autos = _context.Autos.Find(auto => true).ToList();
        return autos;
    }

    [HttpGet("{id}", Name = "GetAuto")]
    public ActionResult<Auto> Get(int id)
    {
        var auto = _context.Autos.Find(a => a.Id == id).FirstOrDefault();

        if (auto == null)
        {
            return NotFound();
        }
        return auto;
    }

    [HttpPost]
    public IActionResult Post([FromBody] Auto auto)
    {
        _context.Autos.InsertOne(auto);
        return CreatedAtRoute("GetAuto", new { id = auto.Id }, auto);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Auto autoIn)
    {
        var auto = _context.Autos.Find(a => a.Id == id).FirstOrDefault();

        if (auto == null)
        {
            return NotFound();
        }
        _context.Autos.ReplaceOne(a => a.Id == id, autoIn);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var auto = _context.Autos.Find(a => a.Id == id).FirstOrDefault();

        if (auto == null)
        {
            return NotFound();
        }
        _context.Autos.DeleteOne(a => a.Id == id);
        return NoContent();
    }
}

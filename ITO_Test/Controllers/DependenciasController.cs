using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ITO_Test;
using ITO_Test.Models;

namespace ITO_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DependenciasController : ControllerBase
    {
        private readonly AppContext _context;

        public DependenciasController(AppContext context)
        {
            _context = context;
        }

        // GET: api/Dependencias
        [HttpGet]
        public IEnumerable<Dependencia> GetDependencias()
        {
            return _context.Dependencias;
        }

        // GET: api/Dependencias/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDependencia([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dependencia = await _context.Dependencias.FindAsync(id);

            if (dependencia == null)
            {
                return NotFound();
            }

            return Ok(dependencia);
        }

        // PUT: api/Dependencias/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDependencia([FromRoute] int id, [FromBody] Dependencia dependencia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dependencia.dependeciaId)
            {
                return BadRequest();
            }

            _context.Entry(dependencia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DependenciaExists(id))
                {
                    return NotFound();
                }
            }

            return NoContent();
        }

        // POST: api/Dependencias
        [HttpPost]
        public async Task<IActionResult> PostDependencia([FromBody] Dependencia dependencia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Dependencias.Add(dependencia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDependencia", new { id = dependencia.dependeciaId }, dependencia);
        }

        // DELETE: api/Dependencias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDependencia([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dependencia = await _context.Dependencias.FindAsync(id);
            if (dependencia == null)
            {
                return NotFound();
            }

            _context.Dependencias.Remove(dependencia);
            await _context.SaveChangesAsync();

            return Ok(dependencia);
        }

        private bool DependenciaExists(int id)
        {
            return _context.Dependencias.Any(e => e.dependeciaId == id);
        }
    }
}
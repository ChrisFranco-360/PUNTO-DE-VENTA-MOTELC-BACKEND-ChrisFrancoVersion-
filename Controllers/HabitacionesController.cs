using Microsoft.AspNetCore.Mvc;
using MTLCRISTALVK18BACK.Contexts;
using MTLCRISTALVK18BACK.Models.Habitaciones;
using Microsoft.EntityFrameworkCore;

namespace MTLCRISTALVK18BACK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitacionesController : ControllerBase
    {
        private readonly MTLCRISTALContexts _context;

        public HabitacionesController(MTLCRISTALContexts context)
        {
            _context = context;
        }

        [HttpGet("{numhab}")]
        public async Task<IActionResult> GetHabitacion(int numhab)
        {
            var habitacion = await _context.Habitaciones.FirstOrDefaultAsync(h => h.Numhab == numhab);
            if (habitacion == null)
            {
                return NotFound();
            }
            return Ok(habitacion);
        }

        [HttpPost("guardar")]
        public async Task<IActionResult> GuardarHabitacion([FromBody] Habitaciones model)
        {
            var habitacionExistente = await _context.Habitaciones.FirstOrDefaultAsync(h => h.Numhab == model.Numhab);

            if (habitacionExistente == null)
            {
                _context.Habitaciones.Add(model);
            }
            else
            {
                // actualizar campos
                habitacionExistente.Tipohab = model.Tipohab;
                habitacionExistente.TipoCamahab = model.TipoCamahab;
                habitacionExistente.Jacuzzihab = model.Jacuzzihab;
                habitacionExistente.Albercahab = model.Albercahab;
                habitacionExistente.Preciohab = model.Preciohab;
                habitacionExistente.AcargoUserMTL = model.AcargoUserMTL;
                habitacionExistente.TurnoUserMTL = model.TurnoUserMTL;
            }

            await _context.SaveChangesAsync();
            return Ok(new { success = true });
        }
    }
}

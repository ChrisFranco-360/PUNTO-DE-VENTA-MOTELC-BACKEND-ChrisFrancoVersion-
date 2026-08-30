using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTLCRISTALVK18BACK.Contexts;
using MTLCRISTALVK18BACK.Models.Reservas;

namespace MTLCRISTALVK18BACK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasController : ControllerBase
    {
        private readonly MTLCRISTALContexts _context;

        public ReservasController(MTLCRISTALContexts context)
        {
            _context = context;
        }


        // GET: api/Reservas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservas>>> GetReservas()
        {
            return await _context.Reservas
                .Include(r => r.Tipo1ResvdCl)
                .Include(r => r.Tipo2ResvdCl)
                .ToListAsync();
        }


        // GET: api/Reservas/5
        [HttpGet("{idResv}")]
        public async Task<ActionResult<Reservas>> GetReserva(int idResv)
        {
            var reserva = await _context.Reservas
                .Include(r => r.Tipo1ResvdCl)
                .Include(r => r.Tipo2ResvdCl)
                .FirstOrDefaultAsync(r => r.IdResv == idResv);

            if (reserva == null)
            {
                return NotFound();
            }

            return reserva;
        }


        // POST: api/Reservas
        [HttpPost]
        public async Task<ActionResult<Reservas>> PostReserva(Reservas reserva)
        {
            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetReserva),
                new { idResv = reserva.IdResv },
                reserva
            );
        }


        // PUT: api/Reservas/5
        [HttpPut("{idResv}")]
        public async Task<IActionResult> PutReserva(
            int idResv,
            Reservas reserva)
        {
            if (idResv != reserva.IdResv)
            {
                return BadRequest();
            }

            _context.Entry(reserva).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservaExists(idResv))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }


        // DELETE: api/Reservas/5
        [HttpDelete("{idResv}")]
        public async Task<IActionResult> DeleteReserva(int idResv)
        {
            var reserva = await _context.Reservas
                .Include(r => r.Tipo1ResvdCl)
                .Include(r => r.Tipo2ResvdCl)
                .FirstOrDefaultAsync(r => r.IdResv == idResv);

            if (reserva == null)
            {
                return NotFound();
            }

            _context.Reservas.Remove(reserva);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        private bool ReservaExists(int idResv)
        {
            return _context.Reservas.Any(r => r.IdResv == idResv);
        }
    }
}
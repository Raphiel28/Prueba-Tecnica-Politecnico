using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace politecnico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnsController : ControllerBase
    {

       private readonly DataContext _context;

        public TurnsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Turns>>> Get()
        {
            return Ok(await _context.turn.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Turns>> Get(int id)
        {
            var clas = await _context.turn.FindAsync(id);
            if (clas == null)
                return BadRequest("Classroom not found.");
            return Ok(clas);
        }

        [HttpPost]
        public async Task<ActionResult<List<Turns>>> AddTurns(Turns clas)
        {

            var listturn1 = await _context.turn.ToListAsync();

            foreach (var turn in listturn1)
            {
                if (clas.Materia != turn.Materia && clas.IdProfesores == turn.IdProfesores && clas.IdClassroom == turn.IdClassroom)
                {
                    return BadRequest("Error with professor and materia.");
                }
            }

            var listTurnos = await _context.turn.Where(x => x.IdClassroom == clas.IdClassroom).ToListAsync();



            foreach (var item in listTurnos)
            {
                if (clas.FirstHours == item.FirstHours ||
                clas.LastHours == item.LastHours ||
                clas.FirstHours >= item.FirstHours && clas.FirstHours <= item.LastHours ||
               clas.LastHours >= item.FirstHours && clas.LastHours <= item.LastHours
                )
                {
                    return BadRequest("Error with Date.");
                }
            }
            var compare_f = DateTime.Compare(clas.FirstHours, DateTime.Now);
            var compare_f2 = DateTime.Compare(clas.FirstHours, clas.LastHours);
            if (compare_f < 0 || compare_f2 > 0)
            {
                return BadRequest("Error with Date.");
            }
            _context.turn.Add(clas);
            await _context.SaveChangesAsync();

            return Ok(await _context.turn.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Turns>>> UpdateTurns(Turns request)
        {
            var dbclas = await _context.turn.FindAsync(request.Id);
            if (dbclas == null)
                return BadRequest("Teachers not found.");

            var listturn1 = await _context.turn.ToListAsync();

            foreach (var turn in listturn1)
            {
                if(request.Materia != turn.Materia && request.IdProfesores == turn.IdProfesores && request.IdClassroom == turn.IdClassroom)
                {
                    return BadRequest("Error with professor and materia.");
                }
            }

            var listTurnos = await _context.turn.Where(x => x.IdClassroom == request.IdClassroom).ToListAsync();

            foreach (var item in listTurnos)
            {
                if (request.FirstHours == item.FirstHours ||
                request.LastHours == item.LastHours ||
                request.FirstHours >= item.FirstHours && request.FirstHours <= item.LastHours ||
               request.LastHours >= item.FirstHours && request.LastHours <= item.LastHours
                )
                {
                    return BadRequest("Error with Date.");
                }
            }
            var compare_f = DateTime.Compare(request.FirstHours, DateTime.Now);
            var compare_f2 = DateTime.Compare(request.FirstHours, request.LastHours);
            if (compare_f < 0 || compare_f2 > 0)
            {
                return BadRequest("Error with Date.");
            }

            dbclas.IdClassroom = request.IdClassroom;
            dbclas.IdProfesores = request.IdProfesores;
            dbclas.Materia = request.Materia;
            dbclas.FirstHours = dbclas.FirstHours;
            dbclas.LastHours = dbclas.LastHours;
            await _context.SaveChangesAsync();

            return Ok(await _context.turn.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Turns>>> Delete(int id)
        {
            var dbClas = await _context.turn.FindAsync(id);
            if (dbClas == null)
                return BadRequest("Teachers not found.");

            _context.turn.Remove(dbClas);
            await _context.SaveChangesAsync();

            return Ok(await _context.turn.ToListAsync());
        }
      
    }
}

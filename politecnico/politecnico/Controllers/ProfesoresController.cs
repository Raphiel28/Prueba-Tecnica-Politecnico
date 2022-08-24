using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace politecnico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesoresController : ControllerBase
    {
        private readonly DataContext _context;

        public ProfesoresController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Profesores>>> Get()
        {
            return Ok(await _context.Teachers.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Profesores>> Get(int id)
        {
            var clas = await _context.Teachers.FindAsync(id);
            if (clas == null)
                return BadRequest("Classroom not found.");
            return Ok(clas);
        }

        [HttpPost]
        public async Task<ActionResult<List<Profesores>>> AddTeacher(Profesores clas)
        {
            clas.DateCreate = DateTime.Now;
            clas.DateInactive = DateTime.Now;
            clas.IsActive = true;
            _context.Teachers.Add(clas);
            await _context.SaveChangesAsync();

            return Ok(await _context.Teachers.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Profesores>>> UpdateTeacher(Profesores request)
        {
            var dbclas = await _context.Teachers.FindAsync(request.Id);
            if (dbclas == null)
                return BadRequest("Teachers not found.");

            dbclas.Name = request.Name;
            dbclas.IsActive = true;
            dbclas.DateCreate = DateTime.Now;
            dbclas.DateInactive = DateTime.Now;


            await _context.SaveChangesAsync();

            return Ok(await _context.Teachers.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Profesores>>> Delete(int id)
        {
            var dbClas = await _context.Teachers.FindAsync(id);
            if (dbClas == null)
                return BadRequest("Teachers not found.");

            dbClas.IsActive = false;
            dbClas.DateInactive = DateTime.Now;
            
            await _context.SaveChangesAsync();

            return Ok(await _context.Teachers.ToListAsync());
        }
    }
}

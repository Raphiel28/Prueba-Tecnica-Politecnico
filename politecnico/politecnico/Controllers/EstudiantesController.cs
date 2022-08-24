using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace politecnico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {
        private readonly DataContext _context;

        public EstudiantesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Estudiantes>>> Get()
        {
            return Ok(await _context.Students.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Estudiantes>> Get(int id)
        {
            var clas = await _context.Students.FindAsync(id);
            if (clas == null)
                return BadRequest("Students not found.");
            return Ok(clas);
        }

        [HttpPost]
        public async Task<ActionResult<List<Estudiantes>>> AddStudent(Estudiantes clas)
        {
            var NumStudent = await _context.Students.Where(x => x.IdClassroom == clas.IdClassroom).CountAsync();

            if(NumStudent >= 30) {
                return BadRequest("Limit of student for Classroom.");
            }

            _context.Students.Add(clas);
            await _context.SaveChangesAsync();

            return Ok(await _context.Students.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Estudiantes>>> UpdateStudent(Estudiantes request)
        {
            var dbclas = await _context.Students.FindAsync(request.Id);
            if (dbclas == null)
                return BadRequest("Students not found.");



            dbclas.Name = request.Name;
            dbclas.IdClassroom = request.IdClassroom;

            await _context.SaveChangesAsync();

            return Ok(await _context.Students.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Estudiantes>>> Delete(int id)
        {
            var dbClas = await _context.Students.FindAsync(id);
            if (dbClas == null)
                return BadRequest("Students not found.");

            _context.Students.Remove(dbClas);
            await _context.SaveChangesAsync();

            return Ok(await _context.Students.ToListAsync());
        }
    }
}

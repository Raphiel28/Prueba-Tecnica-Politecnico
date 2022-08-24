using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace politecnico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClasssroomsController : ControllerBase
    {

        private readonly DataContext _context;

        public ClasssroomsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Classrooms>>> Get()
        {
            return Ok(await _context.Classroomss.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Classrooms>> Get(int id)
        {
            var clas = await _context.Classroomss.FindAsync(id);
            if ( clas == null)
                return BadRequest("Classroom not found.");
            return Ok(clas);
        }

        [HttpPost]
        public async Task<ActionResult<List<Classrooms>>> AddStudent(Classrooms clas)
        {
            _context.Classroomss.Add(clas);
            await _context.SaveChangesAsync();

            return Ok(await _context.Classroomss.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Classrooms>>> UpdateStudent(Classrooms request)
        {
            var dbclas = await _context.Classroomss.FindAsync(request.Id);
            if (dbclas == null)
                return BadRequest("Classroom not found.");

            dbclas.Name = request.Name;
           

            await _context.SaveChangesAsync();

            return Ok(await _context.Classroomss.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Classrooms>>> Delete(int id)
        {
            var dbClas = await _context.Classroomss.FindAsync(id);
            if (dbClas == null)
                return BadRequest("Classroom not found.");

            _context.Classroomss.Remove(dbClas);
            await _context.SaveChangesAsync();

            return Ok(await _context.Classroomss.ToListAsync());
        }
       
    }
}

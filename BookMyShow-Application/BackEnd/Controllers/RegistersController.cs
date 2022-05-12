using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookMyShow_BE.Models;
using PetaPoco;
using PetaPoco.Providers;
using BookMyShow_BE.Services;


namespace BookMyShow_BE.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly BookMyShowContext _context;
        private readonly IHelpers _helpers;
        
        public RegistersController(BookMyShowContext context,IHelpers helpers)
        {
            _context = context;
            _helpers= helpers;
        }

        // GET: api/Registers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Register>>> GetRegisters()
        {
            return await _helpers.GetUsers();
        }

        // GET: api/Registers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Register>> GetRegister(int id)
        {
          if (_context.Registers == null)
          {
              return NotFound();
          }
            var register = await _context.Registers.FindAsync(id);

            if (register == null)
            {
                return NotFound();
            }

            return register;
        }

        // PUT: api/Registers/5
        // To protect from overposting attacks, see 
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegister(int id, Register register)
        {
            if (id != register.Id)
            {
                return BadRequest();
            }

            _context.Entry(register).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegisterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Registers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Register>> PostRegister(Register register)
        {
            var db = DatabaseConfiguration.Build()
                       .UsingConnectionString("Data Source=.\\sqlexpress;Initial Catalog=BookMyShow;Integrated Security=True")
                       .UsingProvider<SqlSererMsDataDatabaseProvider>()
                       .UsingDefaultMapper<ConventionMapper>(m =>
                       {
                           m.InflectTableName = (inflector, s) => inflector.Pluralise(inflector.Underscore(s));
                           m.InflectColumnName = (inflector, s) => inflector.Underscore(s);
                       })
                       .Create();
            var a = db.SingleOrDefault<Register>("SELECT * FROM Register where Email=@0", register.Email);
            if(a!=null)
            {
                return NotFound();
            }

            if (_context.Registers == null)
          {
              return Problem("Entity set 'BookMyShowContext.Registers'  is null.");
          }
            _context.Registers.Add(register);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegister", new { id = register.Id }, register);
        }

        [HttpPost]
        public async Task<ActionResult<Register>> PostLogin(Login userDetails)
        {
            var db = DatabaseConfiguration.Build()
                     .UsingConnectionString("Data Source=.\\sqlexpress;Initial Catalog=BookMyShow;Integrated Security=True")
                     .UsingProvider<SqlSererMsDataDatabaseProvider>()
                     .UsingDefaultMapper<ConventionMapper>(m =>
                     {
                         m.InflectTableName = (inflector, s) => inflector.Pluralise(inflector.Underscore(s));
                         m.InflectColumnName = (inflector, s) => inflector.Underscore(s);
                     })
                     .Create();
            var a = db.SingleOrDefault<Register>("SELECT * FROM Register where Email=@0 and Password=@1", userDetails.Email, userDetails.Password);
            if(a!= null)
            {
                return a;
            }

            return Ok(null);
        }



        // DELETE: api/Registers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegister(int id)
        {
            if (_context.Registers == null)
            {
                return NotFound();
            }
            var register = await _context.Registers.FindAsync(id);
            if (register == null)
            {
                return NotFound();
            }

            _context.Registers.Remove(register);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RegisterExists(int id)
        {
            return (_context.Registers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

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
using BookMyShow_BE.Data_Models;


namespace BookMyShow_BE.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly BookMyShowContext _context;
        private readonly IHelper _helper;
        public RegistersController(BookMyShowContext context, IHelper helper)
        {
            _context = context;
            _helper = helper;

        }

        
        [HttpGet]
        public ActionResult<IEnumerable<RegisterDTO>> GetRegisters()
        {
            return Ok(_helper.GetRegisters());
        }

        
        [HttpGet("{id}")]
        public ActionResult<RegisterDTO> GetRegister(int id)
        {

            var res= _helper.GetRegister(id);
            return Ok(res);
        }

       
        [HttpPost]
        public async Task<ActionResult<RegisterDTO>> PostRegister(RegisterDTO registerdto)
        {
            var res = await _helper.PostRegister(registerdto);
            return res;
        }

        [HttpPost]
        public ActionResult<RegisterDTO> CheckRegister(Login login)
        {
            return Ok(_helper.CheckRegister(login));
        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (_context.Registers == null)
            {
                return NotFound();
            }
            var user = await _context.Registers.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Registers.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}

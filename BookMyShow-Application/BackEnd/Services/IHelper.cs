using BookMyShow_BE.Models;
using Microsoft.AspNetCore.Mvc;
using BookMyShow_BE.Data_Models;

namespace BookMyShow_BE.Services
{
    public interface IHelper
    {
        public List<RegisterDTO> GetRegisters();
        public RegisterDTO GetRegister(int id);
        public Task<ActionResult<RegisterDTO>> PostRegister(RegisterDTO registerdto);
        public RegisterDTO CheckRegister(Login login);

    }
}



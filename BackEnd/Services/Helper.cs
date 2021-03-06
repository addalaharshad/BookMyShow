using BookMyShow_BE.Models;
using Microsoft.AspNetCore.Mvc;
using PetaPoco;
using PetaPoco.Providers;
using AutoMapper;
using BookMyShow_BE.Data_Models;
using BookMyShow_BE.Services.Shared_Db;

namespace BookMyShow_BE.Services
{
    public class Helper : IHelper
    {
        private readonly BookMyShowContext _context;
        private readonly IDatabase db;
        private readonly AutoMapper.IMapper _mapper;
        sharedDb sd = new sharedDb();
        public Helper(BookMyShowContext context, AutoMapper.IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
            db = sd.getDb();
        }
        public List<RegisterDTO> GetRegisters()
        {
            List<RegisterDTO> users = new List<RegisterDTO>();
            var res = _context.Registers.ToList();
            foreach (var a in res)
            {
                users.Add(_mapper.Map<RegisterDTO>(a));
            }
            return users;
        }
        public RegisterDTO GetRegister(int id)
        {
            return _mapper.Map<RegisterDTO>(_context.Registers.Find(id));
        }
        public async Task<ActionResult<RegisterDTO>> PostRegister(RegisterDTO registerdto)
        {
            var a = db.SingleOrDefault<Register>("SELECT * FROM Register where Email=@0", registerdto.Email);
            if (a != null)
            {
                return null;
            }
            var res = _mapper.Map<Register>(registerdto);
            res.CreatedOn = DateTime.Now;
            _context.Registers.Add(res);
            await _context.SaveChangesAsync();
            return _mapper.Map<RegisterDTO>(res);
        }
        public RegisterDTO CheckRegister(Login login)
        {
            var a = db.SingleOrDefault<Register>("SELECT * FROM Register where Email=@0 and Password=@1", login.Email, login.Password);
            return _mapper.Map<RegisterDTO>(a);
        }
    }
}

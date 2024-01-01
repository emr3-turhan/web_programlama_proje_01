using Microsoft.AspNetCore.Mvc;
using web_programlama_proje_001.Data;
using web_programlama_proje_001.Interfaces;
using web_programlama_proje_001.Models;
using Microsoft.EntityFrameworkCore;

namespace web_programlama_proje_001.Repositories
{
    public class DoktorRepository : IDoktorRepository
    {
        private readonly ApplicationDbContext _context;

        public DoktorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Doktor doktor)
        {
            _context.Doktors.Add(doktor);
            return Save();
        }

        public bool Delete(Doktor doktor)
        {
            _context.Doktors.Remove(doktor);
            return Save();
        }

        public async Task<IEnumerable<Doktor>> GetAll()
        {
            return await _context.Doktors.ToListAsync();
        }

        public async Task<Doktor> GetByIdAsync(int id)
        {
            return await _context.Doktors.FirstOrDefaultAsync(d => d.DoktorId == id);
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public bool Update(Doktor doktor)
        {
            _context.Doktors.Update(doktor);
            return Save();
        }
    }
}

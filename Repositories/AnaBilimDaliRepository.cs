using Microsoft.EntityFrameworkCore;
using web_programlama_proje_001.Data;
using web_programlama_proje_001.Interfaces;
using web_programlama_proje_001.Models;

namespace web_programlama_proje_001.Repositories
{
    public class AnaBilimDaliRepository : IAnaBilimDaliRepository
    {
        private readonly ApplicationDbContext _context;

        public AnaBilimDaliRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(AnaBilimDali anaBilimDali)
        {
            _context.Add(anaBilimDali);
            return Save();
        }

        public bool Delete(AnaBilimDali anaBilimDali)
        {
            _context.Remove(anaBilimDali);
            return Save();
        }

        public async Task<IEnumerable<AnaBilimDali>> GetAll()
        {
            return await _context.AnaBilimDalis.ToListAsync();
        }

        public async Task<AnaBilimDali> GetByIdAsync(int id)
        {
            return await _context.AnaBilimDalis.FirstOrDefaultAsync(i => i.AnaBilimDaliId == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public bool Update(AnaBilimDali anaBilimDali)
        {
            _context.Update(anaBilimDali);
            return Save();
        }
    }
}

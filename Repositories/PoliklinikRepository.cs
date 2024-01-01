using web_programlama_proje_001.Data;
using web_programlama_proje_001.Interfaces;
using web_programlama_proje_001.Models;
using Microsoft.EntityFrameworkCore;

namespace web_programlama_proje_001.Repositories
{
    public class PoliklinikRepository : IPoliklinikRepository
    {
        private readonly ApplicationDbContext _context;

        public PoliklinikRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Poliklinik poliklinik)
        {
            _context.Add(poliklinik);
            return Save();
        }

        public bool Delete(Poliklinik poliklinik)
        {
            _context.Remove(poliklinik);
            return Save();
        }

        public async Task<IEnumerable<Poliklinik>> GetAll()
        {
            return await _context.Polikliniks.ToListAsync();
        }

        public async Task<Poliklinik> GetByIdAsync(int id)
        {
            return await _context.Polikliniks.FirstOrDefaultAsync(p => p.PoliklinikId == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public bool Update(Poliklinik poliklinik)
        {
            _context.Update(poliklinik);
            return Save();
        }
    }
}

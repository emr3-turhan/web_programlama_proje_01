using web_programlama_proje_001.Models;

namespace web_programlama_proje_001.Interfaces
{
    public interface IDoktorRepository
    {
        Task<IEnumerable<Doktor>> GetAll();
        Task<Doktor> GetByIdAsync(int id);
        bool Add(Doktor doktor);
        bool Update(Doktor doktor);
        bool Delete(Doktor doktor);
        bool Save();
    }
}

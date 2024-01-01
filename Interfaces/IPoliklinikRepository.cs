using web_programlama_proje_001.Models;

namespace web_programlama_proje_001.Interfaces
{
    public interface IPoliklinikRepository
    {
        Task<IEnumerable<Poliklinik>> GetAll();
        Task<Poliklinik> GetByIdAsync(int id);
        bool Add(Poliklinik poliklinik);
        bool Update(Poliklinik poliklinik);
        bool Delete(Poliklinik poliklinik);
        bool Save();
    }
}

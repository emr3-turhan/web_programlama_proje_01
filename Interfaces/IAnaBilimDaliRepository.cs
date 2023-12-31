using web_programlama_proje_001.Models;

namespace web_programlama_proje_001.Interfaces
{
    public interface IAnaBilimDaliRepository
    {
        Task<IEnumerable<AnaBilimDali>> GetAll();
        Task<AnaBilimDali> GetByIdAsync(int id);
        bool Add(AnaBilimDali anaBilimDali);
        bool Update(AnaBilimDali anaBilimDali);
        bool Delete(AnaBilimDali anaBilimDali);
        bool Save();
    }
}

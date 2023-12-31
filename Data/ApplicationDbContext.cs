using Microsoft.EntityFrameworkCore;
using web_programlama_proje_001.Models;

namespace web_programlama_proje_001.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
        }
        public DbSet<AnaBilimDali> AnaBilimDalis { get; set; }
        
        public DbSet<Doktor> Doktors { get; set; }

        public DbSet<DoktorHareket> DoktorHarekets { get; set; }

        public DbSet<Hasta> Hastas { get; set; }

        public DbSet<Kullanici> Kullanicis {  get; set; }

        public DbSet<Poliklinik> Polikliniks { get; set; }

        public DbSet<Randevu> Randevus { get; set; }

        public DbSet<Rol> Rols { get; set; }
        public object AnaBilimDallari { get; internal set; }
    }
}

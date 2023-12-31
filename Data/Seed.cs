using System.Diagnostics;
using System.Net;
using web_programlama_proje_001.Models;

namespace web_programlama_proje_001.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                if (!context.AnaBilimDalis.Any())
                {
                    // Ana Bilim Dalları
                    var anaBilimDallari = new List<AnaBilimDali>
                {
                    new AnaBilimDali { Name = "Kardiyoloji" },
                    new AnaBilimDali { Name = "Ortopedi" }
                };

                    context.AnaBilimDalis.AddRange(anaBilimDallari);
                    context.SaveChanges();

                    // Poliklinikler
                    var poliklinikler = new List<Poliklinik>
                {
                    new Poliklinik { Name = "Kardiyoloji Polikliniği", AnaBilimDaliId = anaBilimDallari[0].AnaBilimDaliId },
                    new Poliklinik { Name = "Ortopedi Polikliniği", AnaBilimDaliId = anaBilimDallari[1].AnaBilimDaliId }
                };

                    context.Polikliniks.AddRange(poliklinikler);
                    context.SaveChanges();

                    // Doktorlar
                    var doktorlar = new List<Doktor>
                {
                    new Doktor { Name = "Dr. Ahmet", PoliklinikId = poliklinikler[0].PoliklinikId },
                    new Doktor { Name = "Dr. Mehmet", PoliklinikId = poliklinikler[1].PoliklinikId }
                };

                    context.Doktors.AddRange(doktorlar);
                    context.SaveChanges();

                    // Hastalar
                    var hastalar = new List<Hasta>
                {
                    new Hasta { Ad = "Ali", Soyad = "Yılmaz", TCKimlikNo = "12345678901", Telefon = "555-1234567" },
                    new Hasta { Ad = "Ayşe", Soyad = "Kara", TCKimlikNo = "98765432109", Telefon = "555-7654321" }
                };

                    context.Hastas.AddRange(hastalar);
                    context.SaveChanges();

                    // Kullanıcılar
                    var kullanicilar = new List<Kullanici>
                {
                    new Kullanici { KullaniciAdi = "admin", Sifre = "admin123", Email = "admin@example.com" },
                    new Kullanici { KullaniciAdi = "doktor1", Sifre = "doktor123", Email = "doktor1@example.com" },
                    new Kullanici { KullaniciAdi = "hasta1", Sifre = "hasta123", Email = "hasta1@example.com" }
                };

                    context.Kullanicis.AddRange(kullanicilar);
                    context.SaveChanges();

                    // Roller
                    var roller = new List<Rol>
                {
                    new Rol { RolAdi = "Admin" },
                    new Rol { RolAdi = "Doktor" },
                    new Rol { RolAdi = "Hasta" }
                };

                    context.Rols.AddRange(roller);
                    context.SaveChanges();
                }
            }
        }
    }

}

namespace web_programlama_proje_001.ViewModels
{
    public class DetailsPoliklinikViewModel
    {
        public int PoliklinikId { get; set; }

        public string Name { get; set; }

        public int AnaBilimDaliId { get; set; } // Poliklinik'in bağlı olduğu Ana Bilim Dali

        public string AnaBilimDaliName { get; set; } // Ana Bilim Dali adı
    }

}

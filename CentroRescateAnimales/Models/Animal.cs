namespace CentroRescateAnimales.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Especie { get; set; }
        public int Edad { get; set; }
        public string Estado { get; set; } // Disponible, Adoptado
        public int? AdoptanteId { get; set; }
        public Adoptante Adoptante { get; set; }
    }

}
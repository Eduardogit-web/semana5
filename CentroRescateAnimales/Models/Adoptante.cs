namespace CentroRescateAnimales.Models
{
    public class Adoptante
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public List<Animal> Animales { get; set; }
    }
}

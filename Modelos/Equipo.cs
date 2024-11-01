using System.ComponentModel.DataAnnotations;

namespace BlazorFutbol.Modelos
{
    public class Equipo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del equipo es obligatorio.")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El estadio es obligatorio.")]
        public string Estadio { get; set; } = string.Empty;

        public int EntrenadorId { get; set; }
        public Entrenador? Entrenador { get; set; }

        public ICollection<Partido> PartidosLocal { get; set; } = new List<Partido>();
        public ICollection<Partido> PartidosVisitante { get; set; } = new List<Partido>();
    }
}

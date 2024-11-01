namespace BlazorFutbol.Modelos
{
    public class Entrenador
    {
        // Identificador único del entrenador
        public int Id { get; set; }

        // Nombre del entrenador
        public string Nombre { get; set; } = string.Empty;

        // Identificador del equipo relacionado
        public int EquipoId { get; set; }

        // Relación con el equipo
        public Equipo? Equipo { get; set; }
    }
}

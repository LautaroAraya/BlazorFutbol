namespace BlazorFutbol.Class
{
    public class ApiEndPoints
    {
        public static string Entrenador { get; set; } = "entrenadors";
        public static string Equipo { get; set; } = "equipoes";
        public static string Jugador { get; set; } = "jugadores";
        public static string Liga { get; set; } = "ligas";
        public static string Partido { get; set; } = "partidoes";

        public static string GetEndpoint(string name)
        {
            return name switch
            {
                nameof(Entrenador) => Entrenador,
                nameof(Equipo) => Equipo,
                nameof(Jugador) => Jugador,
                nameof(Liga) => Liga,
                nameof(Partido) => Partido,
                _ => throw new ArgumentException($"Endpoint '{name}' no está definido.")
            };
        }



        // Métodos dinámicos para relaciones
        public static string GetEntrenadoresDeEquipoEndpoint(int equipoId)
        {
            return $"equipoes/{equipoId}/entrenadors";
        }

        public static string GetPartidosDeEquipoEndpoint(int equipoId)
        {
            return $"equipoes/{equipoId}/partidoes";
        }
    }
}

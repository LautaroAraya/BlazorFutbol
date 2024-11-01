using BlazorFutbol.Enums;

namespace BlazorFutbol.Modelos
{
    public class Usuario
    {
        public int Id { get; set; }
        public string User { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty; // Opcional con Firebase
        public TipoUsuarioEnum TipoUsuario { get; set; }
        public int? EntrenadorId { get; set; }
        public Entrenador? Entrenador { get; set; } = null;
        
        public bool Eliminado { get; set; } = false;


        public override string ToString()
        {
            return $"{Entrenador?.Nombre}" ?? string.Empty;
        }
    }
}


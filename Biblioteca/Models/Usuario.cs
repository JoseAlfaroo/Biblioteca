using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Biblioteca.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? UsuarioID { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public int? IntentosFallidos { get; set; }
        public DateTime? UltimoIntento { get; set; }
        public int? RolId { get; set; }

        [JsonIgnore]
        public Rol? Rol { get; set; }



    }
}

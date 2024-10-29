using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace catalogo.Models
{
    public class Afiliacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Tecnologia { get; set; }
        public string? Aplicacion { get; set; }
        public DateTime Fecha { get; set; } = DateTime.UtcNow;
        public string? ResponsableSquad { get; set; }
        public string? ResponsableSeguridad { get; set; }
        public string? Telefono { get; set; }
        
        [EmailAddress]
        public string? Correo { get; set; }
        
        public required string TipoAfiliacion { get; set; }
    }
}
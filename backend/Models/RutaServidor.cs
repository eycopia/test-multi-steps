using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace catalogo.Models
{
    public class RutaServidor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string Ruta { get; set; }
        
        public required int AfiliacionId { get; set; }
        public required Afiliacion Afiliacion { get; set; }
    }
}
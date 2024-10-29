using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace catalogo.Models
{
    public class EmpresaAfiliacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public required  Empresa Empresa { get; set; }
        
        public required  int AfiliacionId { get; set; }
        public required Afiliacion Afiliacion { get; set; }
        
        public required string SquadResponsable { get; set; }
    }
}

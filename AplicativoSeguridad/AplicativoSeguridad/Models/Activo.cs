using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace AplicativoSeguridad.Models
{
    public class Activo
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Identificador { get; set; }
        [Required]
        public string? Ubicacion { get; set; }
        [Required]
        public string? Proceso { get; set; }
        [Required]
        public string? NombreActivo { get; set; }
        [Required]
        public string? Descripcion { get; set; }
        [Required]
        public string? Tipo { get; set; }
        [Required]
        public string? Responsable { get; set; }
        
        public string? Clasificacion { get; set; }
        [Required,Range(1,3)]
        public int ValEconomico { get; set; }
        [Required, Range(1, 3)]
        public int ValOps { get; set; }
        [Required, Range(1, 3)]
        public int ValLegal { get; set; }
        [Required, Range(1, 3)]
        public int ValRep { get; set; }
        [Required, Range(1, 3)]
        public int ValPriv { get; set; }
        [Required, Range(1, 3)]
        public int ValSeg { get; set; }

        public int Criticidad { get; set; }
    }
}

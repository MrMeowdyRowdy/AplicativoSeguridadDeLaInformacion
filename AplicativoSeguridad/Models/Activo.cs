using System.ComponentModel.DataAnnotations;

namespace AplicativoSeguridad.Models
{
    public class Activo
    {
        public int ActivoID { get; set; }
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
        public string? Responsable { get; set; }
        [Required]
        public string? Clasificacion { get; set; }
        [Required]
        public int ValEconomico {  get; set; }
        [Required]
        public int ValOps { get; set; }
        [Required]
        public int ValLegal { get; set; }
        [Required]
        public int ValRep { get; set; }
        [Required]
        public int ValPriv { get; set; }
        [Required]
        public int ValSeg { get; set; }
        public int Criticidad { get; set; }
    }
}

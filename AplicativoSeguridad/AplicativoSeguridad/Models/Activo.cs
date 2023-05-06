using System.Runtime.InteropServices;

namespace AplicativoSeguridad.Models
{
    public class Activo
    {
        public int Id { get; set; }
        public string? Identificador { get; set; }
        public string? Ubicacion { get; set; }
        public string? Proceso { get; set; }
        public string? NombreActivo { get; set; }
        public string? Descripcion { get; set; }
        public string? Responsable { get; set; }
        public string? Clasificacion { get; set; }
        public int ValEconomico { get; set; }
        public int ValOps { get; set; }
        public int ValLegal { get; set; }
        public int ValRep { get; set; }
        public int ValPriv { get; set; }
        public int ValSeg { get; set; }
        public int Criticidad { get; set; }
    }
}

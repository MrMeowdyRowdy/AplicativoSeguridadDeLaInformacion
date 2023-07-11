using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace AplicativoSeguridad.Models
{
    public class Control
    {

        [Required]
        public int Id { get; set; }
        [Required]
        public string? Codigo { get; set; }
        [Required]
        public string? Responsable { get; set; }
        [Required]
        public string? Periodicidad { get; set; }
        [Required]
        public string? Proposito { get; set; }
        [Required]
        public string? Definicion { get; set; }
        [Required]
        public string? Acciones { get; set; }
        [Required, Range(1, 3)]
        public int Eficiencia { get; set; }
        
    }
}

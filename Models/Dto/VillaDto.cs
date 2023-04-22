using System.ComponentModel.DataAnnotations;

namespace WebApiNet.Models.Dto
{
    public class VillaDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string? Nombre { get; set; }

        public string Detalle { get; set; }

        [Required]
        public double Tarifa { get; set; }
        public int Ocupantes { get; set; }
        public int MestrosCuadrados { get; set; }
        public string ImagenUrl { get; set; }
        public string Amenidad { get; set; }

    }
}

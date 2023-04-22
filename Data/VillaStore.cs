using WebApiNet.Models;
using WebApiNet.Models.Dto;

namespace WebApiNet.Data
{
    public static class VillaStore
    {
        public static List<VillaDto> villalist = new List<VillaDto>
        {
            new VillaDto { Id = 1, Nombre = "Villa Paisa", Ocupantes = 10, MestrosCuadrados=45},
            new VillaDto { Id = 2, Nombre = "Vista loma", Ocupantes = 15, MestrosCuadrados=30}
        };

    }
}

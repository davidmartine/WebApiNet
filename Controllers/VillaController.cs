using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiNet.Data;
using WebApiNet.Models;
using WebApiNet.Models.Dto;

namespace WebApiNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaController : ControllerBase
    {
        private readonly ILogger<VillaController> _logger;
        private readonly ApplicationDbContext _db;

        public VillaController(ILogger<VillaController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }


        [HttpGet]
        public ActionResult<IEnumerable<VillaDto>> GetVillas()
        {
            _logger.LogInformation("Obtener las villas");
            return Ok(_db.Villas.ToList());

        }

        [HttpGet("{id:int}",Name ="GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDto> GetVillaDto(int id)
        {
            if (id == 0)
            {
                _logger.LogError("Error al traer villa con el id " + id);
                return BadRequest();
            }
            //var respuesta = VillaStore.villalist.FirstOrDefault(x => x.Id == id);
            var respuesta = _db.Villas.FirstOrDefault(x => x.Id == id);
            if (respuesta == null)
            {
                return NotFound();
            }
            return Ok(respuesta);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<VillaDto> Crear([FromBody] VillaDto dto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(_db.Villas.FirstOrDefault(x => x.Nombre.ToLower() == dto.Nombre.ToLower()) !=null)
            {
                ModelState.AddModelError("Nombre", "La villa ya Existe");
                return BadRequest(ModelState);
            }
            if (dto == null)
            {
                return BadRequest(dto);
            }
            if(dto.Id > 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            // dto.Id = VillaStore.villalist.OrderByDescending(x => x.Id).FirstOrDefault().Id +1;
            // VillaStore.villalist.Add(dto);

            Villa modelo = new()
            {

                Nombre = dto.Nombre,
                Detalle = dto.Detalle,
                ImagenUrl = dto.ImagenUrl,
                Ocupantes = dto.Ocupantes,
                Tarifa = dto.Tarifa,
                MetrosCuadrados = dto.MestrosCuadrados,
                Amenidad = dto.Amenidad
            };

            _db.Villas.Add(modelo);
            _db.SaveChanges();

            return CreatedAtRoute("GetVilla",new {id = dto.Id},dto);

        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Eliminar(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            var villa = _db.Villas.FirstOrDefault(x =>x.Id == id);
            if (villa == null)
            {
                return NotFound();
            }
            //VillaStore.villalist.Remove(villa);
            _db.Villas.Remove(villa);
            _db.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Actualizar(int id, [FromBody] VillaDto vdto)
        {
            if(vdto == null || id != vdto.Id)
            {
                return BadRequest();
            }
            //var villa = VillaStore.villalist.FirstOrDefault(v => v.Id == id);
            //villa.Nombre = vdto.Nombre;
            //villa.Ocupantes = vdto.Ocupantes;
            //villa.MestrosCuadrados = vdto.MestrosCuadrados;
            Villa modelo = new()
            {
                Id=vdto.Id,
                Nombre=vdto.Nombre,
                Detalle =vdto.Detalle,
                ImagenUrl=vdto.ImagenUrl,
                Ocupantes=vdto.Ocupantes,
                Tarifa=vdto.Tarifa,
                MetrosCuadrados=vdto.MestrosCuadrados,
                Amenidad=vdto.Amenidad
            };

            _db.Villas.Update(modelo);
            _db.SaveChanges();

            return NoContent();
        }


        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ActualizarVilla(int id, JsonPatchDocument<VillaDto> jsonPatch)
        {
            if (jsonPatch == null || id == 0)
            {
                return BadRequest();
            }
            // var villa = VillaStore.villalist.FirstOrDefault(v => v.Id == id);
            var villa = _db.Villas.AsNoTracking().FirstOrDefault(x => x.Id == id);

            VillaDto villaDto = new()
            {
                Id = villa.Id,
                Nombre = villa.Nombre,
                Detalle = villa.Detalle,
                ImagenUrl = villa.ImagenUrl,
                Tarifa = villa.Tarifa,
                MestrosCuadrados = villa.MetrosCuadrados,
                Amenidad = villa.Amenidad
            };

            if(villaDto == null)
            {
                return BadRequest();
            }

            jsonPatch.ApplyTo(villaDto,ModelState);
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Villa modelo = new()
            {
                Id = villaDto.Id,
                Nombre = villaDto.Nombre,
                Detalle = villaDto.Detalle,
                ImagenUrl = villaDto.ImagenUrl,
                Ocupantes = villaDto.Ocupantes,
                Tarifa = villaDto.Tarifa,
                MetrosCuadrados = villaDto.MestrosCuadrados,
                Amenidad = villaDto.Amenidad
            };

            _db.Update(modelo);
            _db.SaveChanges();

            return NoContent();
        }


    }
}

using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyDanCu.Dto;
using QuanLyDanCu.Interfaces;
using QuanLyDanCu.Models;
using QuanLyDanCu.Repository;

namespace QuanLyDanCu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CanHoController : ControllerBase
    {
        private readonly ICanHoRepository _canHoRepository;
        private readonly IMapper _mapper;
        public CanHoController(ICanHoRepository canHoRepository, IMapper mapper)
        {
            _canHoRepository = canHoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CanHo>))]
        public IActionResult GetCanHos()
        {
            var canHos = _mapper.Map<List<CanHoDto>>(_canHoRepository.GetCanHos());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(canHos);
        }

        [HttpGet("{canHoId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CanHo>))]
        [ProducesResponseType(400)]
        public IActionResult GetCanHo(int canHoId)
        {
            if (!_canHoRepository.CanHoExists(canHoId))
                return NotFound();

            var canHo = _mapper.Map<CanHoDto>(_canHoRepository.GetCanHo(canHoId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(canHo);
        }

        [HttpGet("CuDan/{canHoId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CanHo>))]
        [ProducesResponseType(400)]
        public IActionResult GetCuDanByCanHoId(int canHoId)
        {
            if(!_canHoRepository.CanHoExists(canHoId))
                return NotFound();
            var cuDans = _mapper.Map<List<CuDanDto>>(
                _canHoRepository.GetCuDanByCanHo(canHoId));

            if (!ModelState.IsValid) return BadRequest();

            return Ok(cuDans);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCuDan([FromBody] CanHoDto canHoCreate)
        {
            if (canHoCreate == null)
                return BadRequest(ModelState);

            var canHoMap = _mapper.Map<CanHo>(canHoCreate);

            if (!_canHoRepository.CreateCanHo(canHoMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok();
        }

        [HttpPut("{canHoId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCanHo(int canHoId, [FromBody] CanHoDto updateCanHo)
        {
            if (updateCanHo == null)
                return BadRequest(ModelState);

            if (canHoId != updateCanHo.Id)
                return BadRequest(ModelState);

            if (!_canHoRepository.CanHoExists(canHoId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var canHoMap = _mapper.Map<CanHo>(updateCanHo);

            if (!_canHoRepository.UpdateCanHo(canHoMap))
            {
                ModelState.AddModelError("", "Some thing went wrong updating can ho");
                return StatusCode(500, ModelState);
            }

            return Ok();
        }

        [HttpDelete("{canHoId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteCanHo(int canHoId)
        {
            if (!_canHoRepository.CanHoExists(canHoId))
            {
                return NotFound();
            }

            var canHoToDelete = _canHoRepository.GetCanHo(canHoId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_canHoRepository.DeleteCanHo(canHoToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting can ho");
            }

            return Ok();
        } 
    }
}

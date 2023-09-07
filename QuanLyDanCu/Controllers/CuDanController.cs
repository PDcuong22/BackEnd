using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyDanCu.Data;
using QuanLyDanCu.Dto;
using QuanLyDanCu.Interfaces;
using QuanLyDanCu.Models;
using QuanLyDanCu.Repository;

namespace QuanLyDanCu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuDanController : ControllerBase
    {
        private readonly ICuDanRepository _cuDanRepository;
        private readonly IMapper _mapper;

        public CuDanController(ICuDanRepository cuDanRepository, IMapper mapper)
        {
            _cuDanRepository = cuDanRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CuDan>))]
        public IActionResult GetCuDans()
        {
            var cuDans = _mapper.Map<List<CuDanDto>>(_cuDanRepository.GetCuDans());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(cuDans);
        }

        [HttpGet("{cuDanId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CuDan>))]
        [ProducesResponseType(400)]
        public IActionResult GetCuDan(int cuDanId)
        {
            if (!_cuDanRepository.CuDanExist(cuDanId))
                return NotFound();

            var cuDan = _mapper.Map<CuDanDto>(_cuDanRepository.GetCuDan(cuDanId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(cuDan);
        }

        [HttpGet("CanHo/{cuDanId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CuDan>))]
        [ProducesResponseType(400)]
        public IActionResult GetCanHoByCuDanId(int cuDanId)
        {
            if(!_cuDanRepository.CuDanExist(cuDanId))
                return NotFound();
            var canHos = _mapper.Map<List<CanHoDto>>(
                _cuDanRepository.GetCanHoByCuDan(cuDanId));

            if (!ModelState.IsValid) return BadRequest();

            return Ok(canHos);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCuDan([FromBody] CuDanDto cuDanCreate)
        {
            if (cuDanCreate == null)
                return BadRequest(ModelState);

            var cuDanMap = _mapper.Map<CuDan>(cuDanCreate);

            if (!_cuDanRepository.CreateCuDan(cuDanMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok();
        }
        
        [HttpPost("{cuDanId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult AddCuDanForCanHo(int cuDanId, [FromQuery] int canHoId)
        {

            if (!_cuDanRepository.AddCuDanForCanHo(cuDanId, canHoId))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok();
        }
        
        [HttpPut("{cuDanId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCuDan(int cuDanId, [FromBody] CuDanDto updateCuDan)
        {
            if (updateCuDan == null)
                return BadRequest(ModelState);

            if(cuDanId != updateCuDan.Id)
                return BadRequest(ModelState);

            if (!_cuDanRepository.CuDanExist(cuDanId))
                return NotFound();

            if(!ModelState.IsValid) 
                return BadRequest(ModelState);

            var cuDanMap = _mapper.Map<CuDan>(updateCuDan);

            if(!_cuDanRepository.UpdateCuDan(cuDanMap))
            {
                ModelState.AddModelError("", "Some thing went wrong updating cu dan");
                return StatusCode(500, ModelState);
            }

            return Ok();
        }

        [HttpDelete("{cuDanId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteCuDan(int cuDanId)
        {
            if (!_cuDanRepository.CuDanExist(cuDanId))
            {
                return NotFound();
            }

            var cuDanToDelete = _cuDanRepository.GetCuDan(cuDanId);

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_cuDanRepository.DeleteCuDan(cuDanToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting cu dan");
            }

            return Ok();
        }
    }
}

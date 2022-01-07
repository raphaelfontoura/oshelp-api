namespace webapi.Controllers
{
  using AutoMapper;
  using Microsoft.AspNetCore.Mvc;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading.Tasks;
  using webapi.Data;
  using webapi.Data.Dtos;
  using webapi.Models;

  [Route("api/[controller]")]
  [ApiController]
  public class ChamadosController : ControllerBase
  {
    private ChamadoContext _context;
    private IMapper _mapper;

    public ChamadosController(ChamadoContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<Chamado> GetChamados()
    {
      return _context.Chamados;
    }

    [HttpGet("{id}")]
    public IActionResult GetChamadoId(int id)
    {
      var chamado = _context.Chamados.FirstOrDefault(chamado => chamado.Id == id);
      if (chamado != null)
      {
        return Ok(chamado);
      }
      return NotFound();
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateChamadoDto chamadoDto)
    {
      if (chamadoDto.DateOpen == DateTime.MinValue) chamadoDto.DateOpen = DateTime.Now;
      var chamado = _mapper.Map<Chamado>(chamadoDto);
      _context.Chamados.Add(chamado);
      _context.SaveChanges();
      return CreatedAtAction(nameof(GetChamadoId), new { Id = chamado.Id }, chamado);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateChamado(int id, [FromBody] UpdateChamadoDto chamadoDto)
    {
      var chamado = _context.Chamados.FirstOrDefault(chamado => chamado.Id == id);
      if (chamado == null) return NotFound();
      _mapper.Map(chamadoDto, chamado);
      _context.SaveChanges();
      return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteChamado(int id)
    {
      var chamado = _context.Chamados.FirstOrDefault(chamado => chamado.Id == id);
      if (chamado == null) return NotFound();
      _context.Remove(chamado);
      _context.SaveChanges();
      return NoContent();
    }
  }
}

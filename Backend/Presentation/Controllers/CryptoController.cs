using Backend.Application.DTOs.Crypto;
using Backend.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Presentation.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CryptoController : ControllerBase
{

    private readonly CryptoService _cryptoService;

    public CryptoController(CryptoService cryptoService)
    {
        _cryptoService = cryptoService;
    }


    [HttpPost]
    public async Task<ActionResult<ReadCryptoDTO>> Create([FromBody] CreateCryptoDTO dto)
    {
        var created = await _cryptoService.CreateCryptoAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ReadCryptoDTO>> GetById(int id)
    {
        var crypto = await _cryptoService.GetByIdAsync(id);
        if (crypto == null) return NotFound();

        return Ok(crypto);
    }


    [HttpGet("symbol/{symbol}")]
    public async Task<ActionResult<ReadCryptoDTO>> GetBySymbol(string symbol)
    {
        var crypto = await _cryptoService.GetBySymbolAsync(symbol);
        if (crypto == null) return NotFound();

        return Ok(crypto);
    }


    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _cryptoService.DeleteAsync(id);
        if (!deleted) return NotFound();

        return NoContent();
    }

}

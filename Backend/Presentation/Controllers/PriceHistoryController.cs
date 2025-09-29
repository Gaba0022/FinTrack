using Backend.Application.DTOs.PriceHistory;
using Backend.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PriceHistoryController : ControllerBase
{
    private readonly PriceHistoryService _service;

    public PriceHistoryController(PriceHistoryService service)
    {
        _service = service;
    }


    [HttpPost]
    public async Task<ActionResult<ReadPriceHistoryDTO>> Create([FromBody] CreatePriceHistoryDTO dto)
    {
        try
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<ReadPriceHistoryDTO?>> GetById(long id)
    {
        var history = await _service.GetByIdAsync(id);
        if (history == null) return NotFound();
        return Ok(history);
    }


    [HttpGet("latest/{cryptoCoinId}")]
    public async Task<ActionResult<ReadPriceHistoryDTO?>> GetLatestByCrypto(string cryptoCoinId)
    {
        var history = await _service.GetByCryptoCoinIdAsync(cryptoCoinId);
        if (history == null) return NotFound();
        return Ok(history);
    }


    [HttpGet("range/{cryptoCoinId}")]
    public async Task<ActionResult<List<ReadPriceHistoryDTO>>> GetAllByCrypto(
        string cryptoCoinId,
        [FromQuery] DateTime from,
        [FromQuery] DateTime to)
    {
        var histories = await _service.GetAllByCryptoAsync(cryptoCoinId, from, to);
        return Ok(histories);
    }
}

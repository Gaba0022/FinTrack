using Backend.Application.DTOs.PriceAlert;
using Backend.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PriceAlertController : ControllerBase
{
    private readonly PriceAlertService _service;

    public PriceAlertController(PriceAlertService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<ActionResult<ReadPriceAlertDTO>> Create([FromBody] CreatePriceAlertDTO dto)
    {
        var alert = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = alert.Id }, alert);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ReadPriceAlertDTO>> GetById(Guid id)
    {
        var alert = await _service.GetByIdAsync(id);
        if (alert == null) return NotFound();
        return Ok(alert);
    }

    [HttpGet("user/{userId}")]
    public async Task<ActionResult<List<ReadPriceAlertDTO>>> GetByUserId(Guid userId)
    {
        var alerts = await _service.GetByUserIdAsync(userId);
        return Ok(alerts);
    }

    [HttpGet("coin/{coinId}")]
    public async Task<ActionResult<List<ReadPriceAlertDTO>>> GetByCoinId(string coinId)
    {
        var alerts = await _service.GetByCoinIdAsync(coinId);
        return Ok(alerts);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ReadPriceAlertDTO?>> Update(Guid id, [FromBody] UpdatePriceAlertDTO dto)
    {
        var updated = await _service.UpdateAsync(id, dto);
        if (updated == null) return NotFound();
        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _service.DeleteAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}

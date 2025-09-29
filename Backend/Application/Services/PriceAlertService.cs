using AutoMapper;
using Backend.Application.DTOs.PriceAlert;
using Backend.Domain.Entities;
using Backend.Infrastructure.Persistence.Repositories;

namespace Backend.Application.Services;

public class PriceAlertService
{
    private readonly PriceAlertRepository _repository;
    private readonly IMapper _mapper;

    public PriceAlertService(PriceAlertRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }


    public async Task<ReadPriceAlertDTO> CreateAsync(CreatePriceAlertDTO dto)
    {
        var alert = _mapper.Map<PriceAlert>(dto);
        var createdAlert = await _repository.CreateAsync(alert);
        return _mapper.Map<ReadPriceAlertDTO>(createdAlert);
    }


    public async Task<ReadPriceAlertDTO?> GetByIdAsync(Guid id)
    {
        var alert = await _repository.GetByIdAsync(id);
        if (alert == null) return null;
        return _mapper.Map<ReadPriceAlertDTO>(alert);
    }


    public async Task<List<ReadPriceAlertDTO>> GetByUserIdAsync(Guid userId)
    {
        var alerts = await _repository.GetByUserIdAsync(userId);
        return _mapper.Map<List<ReadPriceAlertDTO>>(alerts);
    }


    public async Task<List<ReadPriceAlertDTO>> GetByCoinIdAsync(string coinId)
    {
        var alerts = await _repository.GetByCoinIdAsync(coinId);
        return _mapper.Map<List<ReadPriceAlertDTO>>(alerts);
    }


    public async Task<ReadPriceAlertDTO?> UpdateAsync(Guid id, UpdatePriceAlertDTO dto)
    {
        var alert = await _repository.GetByIdAsync(id);
        if (alert == null) return null;

        alert.TargetPrice = dto.TargetPrice;
        alert.Direction = dto.Direction;
        alert.IsActive = dto.IsActive;

        var updated = await _repository.UpdateAsync(alert);
        return _mapper.Map<ReadPriceAlertDTO>(updated);
    }


    public async Task<bool> DeleteAsync(Guid id)
    {
        return await _repository.DeleteAsync(id);
    }
}

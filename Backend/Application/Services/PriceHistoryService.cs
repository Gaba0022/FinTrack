using AutoMapper;
using Backend.Application.DTOs.PriceHistory;
using Backend.Domain.Entities;
using Backend.Infrastructure.Persistence.Repositories;

namespace Backend.Application.Services;

public class PriceHistoryService
{
    private readonly PriceHistoryRepository _repository;
    private readonly IMapper _mapper;

    public PriceHistoryService(PriceHistoryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ReadPriceHistoryDTO> CreateAsync(CreatePriceHistoryDTO dto)
    {
        var priceHistory = _mapper.Map<PriceHistory>(dto);
        var createPriceHistory = await _repository.CreateAsync(priceHistory);

        return _mapper.Map<ReadPriceHistoryDTO>(createPriceHistory);
    }

    public async Task<ReadPriceHistoryDTO?> GetByIdAsync(long id)
    {
        var priceHistory = await _repository.GetByIdAsync(id);
        if (priceHistory == null) return null;

        return _mapper.Map<ReadPriceHistoryDTO>(priceHistory);
    }

    public async Task<ReadPriceHistoryDTO?> GetByCryptoCoinIdAsync(string cryptoCoinId)
    {
        var priceHistory = await _repository.GetByCryptoCoinIdAsync(cryptoCoinId);
        if (priceHistory == null) return null;

        return _mapper.Map<ReadPriceHistoryDTO>(priceHistory);
    }

    public async Task<List<ReadPriceHistoryDTO>> GetAllByCryptoAsync(string cryptoCoinId, DateTime from, DateTime to)
    {
        var histories = await _repository.GetAllByCryptoAsync(cryptoCoinId, from, to);
        return _mapper.Map<List<ReadPriceHistoryDTO>>(histories);
    }

}

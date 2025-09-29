using Backend.Domain.Entities;

namespace Backend.Domain.Interfaces;

public interface IPriceHistoryRepository
{

    Task<PriceHistory> CreateAsync(PriceHistory priceHistory);
    Task<PriceHistory?> GetByIdAsync(long id);
    Task<PriceHistory?> GetByCryptoCoinIdAsync(string CryptoCoinId);
    Task<List<PriceHistory>> GetAllByCryptoAsync(string cryptoCoinId, DateTime from, DateTime to);
}

using Backend.Domain.Entities;

namespace Backend.Domain.Interfaces;

public interface IPriceAlertRepository
{
    Task<PriceAlert> CreateAsync(PriceAlert alert);
    Task<PriceAlert?> GetByIdAsync(Guid id);
    Task<List<PriceAlert>> GetByUserIdAsync(Guid userId);
    Task<List<PriceAlert>> GetByCoinIdAsync(string coinId);
    Task<PriceAlert?> UpdateAsync(PriceAlert alert);
    Task<bool> DeleteAsync(Guid id);
}

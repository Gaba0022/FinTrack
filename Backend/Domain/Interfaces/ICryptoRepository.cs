using Backend.Domain.Entities;

namespace Backend.Domain.Interfaces;

public interface ICryptoRepository
{
    Task<Crypto> CreateAsync(Crypto crypto);
    Task<Crypto?> GetByIdAsync(int id);
    Task<Crypto?> GetBySymbolAsync(string symbol);
    Task<bool> DeleteAsync(int id);

}

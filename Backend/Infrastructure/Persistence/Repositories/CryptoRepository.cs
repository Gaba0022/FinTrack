using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Persistence.Repositories;

public class CryptoRepository: ICryptoRepository
{
    private readonly AppDbContext _context;

    public CryptoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Crypto> CreateAsync(Crypto crypto) 
    {
        _context.Cryptos.Add(crypto);
        await _context.SaveChangesAsync();
        return crypto;

    }
    public async Task<Crypto?> GetByIdAsync(int id)
    {
        return await _context.Cryptos
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);
    }
    public async Task<Crypto?> GetBySymbolAsync(string symbol) 
    {
        return await _context.Cryptos
            .FirstOrDefaultAsync(x => x.Symbol == symbol);
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var crypto = await this.GetByIdAsync(id);
        if (crypto != null)
        {
            _context.Cryptos.Remove(crypto);
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }

}

using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Persistence.Repositories;

public class PriceHistoryRepository : IPriceHistoryRepository
{
    private readonly AppDbContext _context;

    public PriceHistoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<PriceHistory> CreateAsync(PriceHistory priceHistory) 
    {
        _context.PriceHistories.Add(priceHistory);
        await _context.SaveChangesAsync();
        return priceHistory;
    }
    public async Task<PriceHistory?> GetByIdAsync(long id) 
    {
        return await _context.PriceHistories
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);

    }
    public async Task<PriceHistory?> GetByCryptoCoinIdAsync(string cryptoCoinId)
    {
        return await _context.PriceHistories
            .Where(x => x.CryptoCoinId == cryptoCoinId)
            .OrderByDescending(x => x.Timestamp) // garante que o registro mais recente venha primeiro
            .FirstOrDefaultAsync();
    }
    public async Task<List<PriceHistory>> GetAllByCryptoAsync(string cryptoCoinId, DateTime from, DateTime to) 
    {
        return await _context.PriceHistories
        .AsNoTracking()
        .Where(ph => ph.CryptoCoinId == cryptoCoinId && ph.Timestamp >= from && ph.Timestamp <= to)
        .OrderBy(ph => ph.Timestamp) //Ordena do mais antigo para o mais recente
        .ToListAsync();
    }

}

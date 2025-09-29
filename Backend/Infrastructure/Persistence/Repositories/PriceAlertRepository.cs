using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Persistence.Repositories;

public class PriceAlertRepository : IPriceAlertRepository
{
    private readonly AppDbContext _context;

    public PriceAlertRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<PriceAlert> CreateAsync(PriceAlert alert)
    {
        _context.PriceAlerts.Add(alert);
        await _context.SaveChangesAsync();
        return alert;
    }

    public async Task<PriceAlert?> GetByIdAsync(Guid id)
    {
        return await _context.PriceAlerts
            .Include(a => a.User)
            .Include(a => a.Crypto)
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<List<PriceAlert>> GetByUserIdAsync(Guid userId)
    {
        return await _context.PriceAlerts
            .Include(a => a.Crypto)
            .Where(a => a.UserId == userId)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<PriceAlert>> GetByCoinIdAsync(string coinId)
    {
        return await _context.PriceAlerts
            .Include(a => a.User)
            .Where(a => a.CoinId == coinId)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<PriceAlert?> UpdateAsync(PriceAlert alert)
    {
        var existingAlert = await _context.PriceAlerts.FindAsync(alert.Id);
        if (existingAlert == null) return null;

        _context.Entry(existingAlert).CurrentValues.SetValues(alert);
        await _context.SaveChangesAsync();
        return existingAlert;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var alert = await _context.PriceAlerts.FindAsync(id);
        if (alert == null) return false;

        _context.PriceAlerts.Remove(alert);
        await _context.SaveChangesAsync();
        return true;
    }
}

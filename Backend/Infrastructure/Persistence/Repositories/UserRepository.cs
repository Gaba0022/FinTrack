using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;

    }

    public async Task<User> CreateAsync(User user) 
    { 
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;

    }
    public async Task<User?> GetByIdAsync(Guid id) 
    {
        return await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id); //AsNoTracking usado para melhorar a consulta(menos consumo de memoria e leitura mais rapida)
    }
    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task<User?> UpdateAsync(User user)
    {
        var existingUser = await this.GetByIdAsync(user.Id);
        if (existingUser != null)
        {
            return null;
        }

        _context.Users.Update(existingUser).CurrentValues.SetValues(user);
        await _context.SaveChangesAsync();
        return user;

    }

    public async Task<bool> DeleteAsync(Guid id)
    {

        var user = await this.GetByIdAsync(id);
        if (user != null)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }

}

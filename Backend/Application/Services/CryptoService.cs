using AutoMapper;
using Backend.Application.DTOs.Crypto;
using Backend.Application.DTOs.Users;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Backend.Infrastructure.Persistence.Repositories;

namespace Backend.Application.Services;

public class CryptoService
{
    private readonly CryptoRepository _cryptoRepository;
    private readonly IMapper _mapper;

    public CryptoService(CryptoRepository cryptoRepository, IMapper mapper)
    {
        _cryptoRepository = cryptoRepository;
        _mapper = mapper;
    }


    public async Task<ReadCryptoDTO> CreateCryptoAsync(CreateCryptoDTO dto)
    {
        var crypto = _mapper.Map<Crypto>(dto);
        var createdCrypto = await _cryptoRepository.CreateAsync(crypto);

        return _mapper.Map<ReadCryptoDTO>(createdCrypto);
    }

    public async Task<ReadCryptoDTO?> GetByIdAsync(int id)
    {
        var crypto = await _cryptoRepository.GetByIdAsync(id);
        if (crypto == null) return null;

        return _mapper.Map<ReadCryptoDTO>(crypto);
    }

    public async Task<ReadCryptoDTO?> GetBySymbolAsync(string symbol)
    {
        var crypto = await _cryptoRepository.GetBySymbolAsync(symbol);
        if (crypto == null) return null;

        return _mapper.Map<ReadCryptoDTO>(crypto);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _cryptoRepository.DeleteAsync(id);
    }

}

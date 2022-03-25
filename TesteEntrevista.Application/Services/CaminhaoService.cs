using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteEntrevista.Domain.DTO;
using TesteEntrevista.Domain.Interfaces.Repositories;
using TesteEntrevista.Domain.Interfaces.Services;

namespace TesteEntrevista.Application.Services
{
    public class CaminhaoService : ICaminhaoService
    {
        private readonly ICaminhaoRepository _caminhaoRepository;

        public CaminhaoService(ICaminhaoRepository caminhaoRepository)
        {
            _caminhaoRepository = caminhaoRepository;
        }

        public async Task ApagarCaminhaoAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task AtualizarCaminhaoAsync(int id, AtualizarCaminhaoRequestDTO request)
        {
            throw new NotImplementedException();
        }

        public async Task<int> CriarCaminhaoAsync(NovoCaminhaoRequestDTO request)
        {
            throw new NotImplementedException();
        }

        public async Task<CaminhaoResponseDTO> RecuperarCaminhaoPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CaminhaoResponseDTO>> RecuperarTodosCaminhoesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
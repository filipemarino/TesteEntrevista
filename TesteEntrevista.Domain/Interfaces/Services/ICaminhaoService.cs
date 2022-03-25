using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteEntrevista.Domain.DTO;

namespace TesteEntrevista.Domain.Interfaces.Services
{
    public interface ICaminhaoService
    {
        Task<IEnumerable<CaminhaoResponseDTO>> RecuperarTodosCaminhoesAsync();
        Task<CaminhaoResponseDTO> RecuperarCaminhaoPorIdAsync(int id);
        Task<int> CriarCaminhaoAsync(NovoCaminhaoRequestDTO request);
        Task AtualizarCaminhaoAsync(int id, AtualizarCaminhaoRequestDTO request);
        Task ApagarCaminhaoAsync(int id);
    }
}
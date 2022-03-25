using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteEntrevista.Domain.Entities;

namespace TesteEntrevista.Domain.Interfaces.Repositories
{
    public interface ICaminhaoRepository
    {
        Task<IEnumerable<Caminhao>> RecuperarTodosCaminhoesAsync();
        Task<Caminhao> RecuperarCaminhaoPorId(int id);
        Task<int> CriarCaminhaoAsync(Caminhao caminhao);
        Task AtualizarCaminhaoAsync(Caminhao caminhao);
        Task ApagarCaminhaoAsync(int id);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteEntrevista.Domain.Entities;
using TesteEntrevista.Domain.Interfaces.Repositories;

namespace TesteEntrevista.EF.Repositories
{
    public class CaminhaoRepository : ICaminhaoRepository
    {
        public Task ApagarCaminhaopAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task AtualizarCaminhaoAsync(Caminhao caminhao)
        {
            throw new NotImplementedException();
        }

        public Task<int> CriarCaminhaoAsync(Caminhao caminhao)
        {
            throw new NotImplementedException();
        }

        public Task<Caminhao> RecuperarCaminhaoPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Caminhao>> RecuperarTodosCaminhoesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
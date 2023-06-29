using HealthSystem.Dominio.Entidades;
using HealthSystem.Infra.Repositorios.Interfaces;
using HealthSystem.Servicos.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthSystem.Servicos
{
    public class ConsultaServico : IConsultaServico
    {
        private readonly IConsultaRepositorio _consultaRepositorio;

        public ConsultaServico(IConsultaRepositorio consultaRepositorio)
        {            
            _consultaRepositorio = consultaRepositorio;
        }

        public async Task<IEnumerable<Consulta>> ObterTodasConsultas()
        {
            return await _consultaRepositorio.ObterTodos();
        }

        public async Task<Consulta> ObterConsultaPorId(int id)
        {
            return await _consultaRepositorio.ObterPorId(id);
        }

        public async Task<int> AgendarConsulta(Consulta consulta)
        {
            return await _consultaRepositorio.Inserir(consulta);
        }

        public async Task AtualizarConsulta(Consulta consulta)
        {
            await _consultaRepositorio.Atualizar(consulta);
        }

        public async Task RemoverConsulta(int id)
        {
            await _consultaRepositorio.Remover(id);
        }
    }
}

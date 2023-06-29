using HealthSystem.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthSystem.Servicos.Interfaces
{
    public interface IConsultaServico
    {
        Task<IEnumerable<Consulta>> ObterTodasConsultas();
        Task<Consulta> ObterConsultaPorId(int id);
        Task<int> AgendarConsulta(Consulta consulta);
        Task AtualizarConsulta(Consulta consulta);
        Task RemoverConsulta(int id);
    }
}

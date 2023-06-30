using HealthSystem.Aplicacao.Comandos.ConsultaComandos;
using HealthSystem.Dominio.Entidades;

namespace HealthSystem.Servicos.Interfaces
{
    public interface IConsultaServico
    {
        Task<IEnumerable<Consulta>> ObterTodasConsultas();
        Task<Consulta> ObterConsultaPorId(int id);
        Task<int> AgendarConsulta(CriarConsultaComando consulta);
        Task AtualizarConsulta(AtualizarConsultaComando consulta);
        Task RemoverConsulta(int id);
    }
}

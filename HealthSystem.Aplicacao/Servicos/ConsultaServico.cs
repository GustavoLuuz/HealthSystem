using HealthSystem.Aplicacao.Comandos.ConsultaComandos;
using HealthSystem.Dominio.Entidades;
using HealthSystem.Dominio.Enumerador;
using HealthSystem.Dominio.InterfaceRepositorios;
using HealthSystem.Servicos.Interfaces;

namespace HealthSystem.Servicos
{
    public class ConsultaServico : IConsultaServico
    {
        private readonly IConsultaRepositorio _consultaRepositorio;
        private readonly IMedicoRepositorio _medicoRepositorio;
        private readonly IPacienteRepositorio _pacienteRepositorio;

        public ConsultaServico(
            IConsultaRepositorio consultaRepositorio,
            IMedicoRepositorio medicoRepositorio,
            IPacienteRepositorio pacienteRepositorio)
        {
            _consultaRepositorio = consultaRepositorio;
            _medicoRepositorio = medicoRepositorio;
            _pacienteRepositorio = pacienteRepositorio;
        }

        public async Task<IEnumerable<Consulta>> ObterTodasConsultas()
        {
            return await _consultaRepositorio.ObterTodos();
        }

        public async Task<Consulta> ObterConsultaPorId(int id)
        {
            return await _consultaRepositorio.ObterPorId(id);
        }

        public async Task<int> AgendarConsulta(CriarConsultaComando consultaComando)
        {
            var medico = await _medicoRepositorio.ObterPorId(consultaComando.MedicoId);
            var paciente = await _pacienteRepositorio.ObterPorId(consultaComando.PacienteId);

            var consulta = new Consulta(
                consultaComando.DataHora,
                medico,
                paciente,
                consultaComando.Observacoes,
                EConsultaSituacao.Agendada
            );

            return await _consultaRepositorio.Inserir(consulta);
        }

        public async Task AtualizarConsulta(AtualizarConsultaComando consultaComando)
        {
            var consulta = await _consultaRepositorio.ObterPorId(consultaComando.Id);

            var novoMedico = await _medicoRepositorio.ObterPorId(consultaComando.MedicoId);
            var novoPaciente = await _pacienteRepositorio.ObterPorId(consultaComando.PacienteId);

            consulta.AtualizarConsulta(
                novoMedico,
                novoPaciente,
                consultaComando.DataHora,
                consultaComando.Observacoes,
                EConsultaSituacao.Agendada
            );

            await _consultaRepositorio.Atualizar(consulta);
        }

        public async Task RemoverConsulta(int id)
        {
            await _consultaRepositorio.Remover(id);
        }
    }
}

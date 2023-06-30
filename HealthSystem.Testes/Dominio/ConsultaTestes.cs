using Xunit;
using HealthSystem.Dominio.Entidades;
using System;
using HealthSystem.Dominio.Enumerador;

namespace HealthSystem.Testes.Dominio
{
    public class ConsultaTestes
    {
        private readonly Medico _medico;
        private readonly Paciente _paciente;

        public ConsultaTestes()
        {            
            _medico = new Medico("Dr. Teste", "41762691035", new DateTime(1980, 1, 1), "teste@medico.com", "Cardiologia", "12345678");
            _paciente = new Paciente("Sr. Teste", "98299067014", new DateTime(1990, 1, 1), "teste@paciente.com", "Plano Saude X");
        }

        [Fact]
        public void CriarConsulta_DeveRetornarConsulta_QuandoDadosValidos()
        {
            var dataHora = DateTime.Now.AddHours(2);
            var observacoes = "Teste de observações";

            var consulta = Consulta.CriarConsulta(dataHora, _medico, _paciente, observacoes);

            Assert.Equal(dataHora, consulta.DataHora);
            Assert.Equal(_medico, consulta.Medico);
            Assert.Equal(_paciente, consulta.Paciente);
            Assert.Equal(observacoes, consulta.Observacoes);
            Assert.Equal(EConsultaSituacao.Agendada, consulta.Situacao);
        }

        [Fact]
        public void CriarConsulta_DeveLancarExcecao_QuandoDataHoraNoPassado()
        {
            var dataHora = DateTime.Now.AddHours(-2);

            Assert.Throws<ArgumentException>(() => Consulta.CriarConsulta(dataHora, _medico, _paciente, "observacoes"));
        }

        [Fact]
        public void CriarConsulta_DeveLancarExcecao_QuandoMedicoNulo()
        {
            Assert.Throws<ArgumentNullException>(() => Consulta.CriarConsulta(DateTime.Now.AddHours(2), null, _paciente, "observacoes"));
        }

        [Fact]
        public void CriarConsulta_DeveLancarExcecao_QuandoPacienteNulo()
        {
            Assert.Throws<ArgumentNullException>(() => Consulta.CriarConsulta(DateTime.Now.AddHours(2), _medico, null, "observacoes"));
        }

        [Fact]
        public void AtualizarConsulta_DeveAtualizarDadosCorretamente_QuandoDadosValidos()
        {
            var consulta = Consulta.CriarConsulta(DateTime.Now.AddHours(2), _medico, _paciente, "observacoes");

            var novoMedico = new Medico("Dr. Teste Atualizado", "05214823053", new DateTime(1980, 1, 2), "teste2@medico.com", "Neurologia", "23456789");
            var novoPaciente = new Paciente("Sr. Teste Atualizado", "22584114089", new DateTime(1990, 1, 2), "teste2@paciente.com", "Plano Saude Y");
            var novaDataHora = DateTime.Now.AddHours(3);
            var novasObservacoes = "Teste de observações atualizadas";
            var novaSituacao = EConsultaSituacao.Concluida;

            consulta.AtualizarConsulta(novoMedico, novoPaciente, novaDataHora, novasObservacoes, novaSituacao);

            Assert.Equal(novaDataHora, consulta.DataHora);
            Assert.Equal(novoMedico, consulta.Medico);
            Assert.Equal(novoPaciente, consulta.Paciente);
            Assert.Equal(novasObservacoes, consulta.Observacoes);
            Assert.Equal(novaSituacao, consulta.Situacao);
        }

        [Fact]
        public void AtualizarConsulta_DeveLancarExcecao_QuandoDataHoraNoPassado()
        {
            var consulta = Consulta.CriarConsulta(DateTime.Now.AddHours(2), _medico, _paciente, "observacoes");

            var dataHoraPassada = DateTime.Now.AddHours(-2);

            Assert.Throws<ArgumentException>(() => consulta.AtualizarConsulta(_medico, _paciente, dataHoraPassada, "observacoes", EConsultaSituacao.Agendada));
        }

        [Fact]
        public void AtualizarConsulta_DeveLancarExcecao_QuandoMedicoNulo()
        {
            var consulta = Consulta.CriarConsulta(DateTime.Now.AddHours(2), _medico, _paciente, "observacoes");

            Assert.Throws<ArgumentNullException>(() => consulta.AtualizarConsulta(null, _paciente, DateTime.Now.AddHours(2), "observacoes", EConsultaSituacao.Agendada));
        }

        [Fact]
        public void AtualizarConsulta_DeveLancarExcecao_QuandoPacienteNulo()
        {
            var consulta = Consulta.CriarConsulta(DateTime.Now.AddHours(2), _medico, _paciente, "observacoes");

            Assert.Throws<ArgumentNullException>(() => consulta.AtualizarConsulta(_medico, null, DateTime.Now.AddHours(2), "observacoes", EConsultaSituacao.Agendada));
        }

    }
}

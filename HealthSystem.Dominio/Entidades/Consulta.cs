using System;
using HealthSystem.Dominio.Entidades;
using HealthSystem.Dominio.Enumerador;

namespace HealthSystem.Domain.Entidades
{   
    public class Consulta
    {
        public int Id { get; private set; }
        public DateTime DataHora { get; private set; }
        public Medico Medico { get; private set; }
        public Paciente Paciente { get; private set; }
        public string Observacoes { get; private set; }
        public EConsultaSituacao Situacao { get; private set; }

        private Consulta(
            DateTime dataHora, 
            Medico medico, 
            Paciente paciente, 
            string observacoes, 
            EConsultaSituacao situacao)
        {
            DefinirDataHora(dataHora);
            DefinirMedico(medico);
            DefinirPaciente(paciente);
            DefinirObservacoes(observacoes);
            DefinirSituacao(situacao);
        }

        public static Consulta CriarConsulta(
            DateTime dataHora,
            Medico medico,
            Paciente paciente,
            string observacoes)
        {
            return new Consulta(dataHora, medico, paciente, observacoes, EConsultaSituacao.Agendada);
        }

        private void DefinirDataHora(DateTime dataHora)
        {
            if (dataHora < DateTime.Now)
                throw new ArgumentException("A data e hora da consulta não pode ser no passado.");

            DataHora = dataHora;
        }

        private void DefinirMedico(Medico medico)
        {
            if (medico == null)
                throw new ArgumentNullException(nameof(medico), "O médico da consulta não pode ser nulo.");

            Medico = medico;
        }

        private void DefinirPaciente(Paciente paciente)
        {
            if (paciente == null)
                throw new ArgumentNullException(nameof(paciente), "O paciente da consulta não pode ser nulo.");

            Paciente = paciente;
        }

        private void DefinirObservacoes(string observacoes)
        {
            Observacoes = observacoes;
        }

        private void DefinirSituacao(EConsultaSituacao situacao)
        {            
            Situacao = situacao;
        }
    }
}

using System;

namespace HealthSystem.Dominio
{
    public class Medico : Pessoa
    {
        public string Especialidade { get; private set; }
        public string CRM { get; private set; }

        public Medico(
            string nome, 
            string cpf, 
            DateTime dataNascimento,
            string email,
            string especialidade, 
            string crm)
            : base(nome, cpf, dataNascimento, email)
        {
            DefinirEspecialidade(especialidade);
            DefinirCRM(crm);
        }

        private void DefinirEspecialidade(string especialidade)
        {
            if (string.IsNullOrWhiteSpace(especialidade))
                throw new ArgumentException("A especialidade do médico não pode estar em branco.");

            Especialidade = especialidade;
        }

        private void DefinirCRM(string crm)
        {
            if (string.IsNullOrWhiteSpace(crm))
                throw new ArgumentException("O CRM do médico não pode estar em branco.");

            CRM = crm;
        }
    }
}

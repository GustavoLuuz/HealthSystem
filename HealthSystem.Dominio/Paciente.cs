using System;

namespace HealthSystem.Dominio
{
    public class Paciente : Pessoa
    {
        public string PlanoSaude { get; private set; }

        public Paciente(
            string nome,
            string cpf,
            DateTime dataNascimento,
            string email,
            string planoSaude)
            : base(nome, cpf, dataNascimento, email)
        {
            DefinirPlanoSaude(planoSaude);
        }

        private void DefinirPlanoSaude(string planoSaude)
        {
            if (string.IsNullOrWhiteSpace(planoSaude))
                throw new ArgumentException("O plano de saúde do paciente não pode estar em branco.");

            PlanoSaude = planoSaude;
        }
    }
}

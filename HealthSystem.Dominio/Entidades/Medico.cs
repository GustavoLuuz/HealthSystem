namespace HealthSystem.Dominio.Entidades
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
            : base( nome, cpf, dataNascimento, email)
        {
            DefinirEspecialidade(especialidade);
            DefinirCRM(crm);
        }
        protected Medico()
        { }

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
        public void AtualizarMedico(
                    string nome,
                    string cpf,
                    DateTime dataNascimento,
                    string email,
                    string especialidade,
                    string crm)
        {
            DefinirNome(nome);
            DefinirCPF(cpf);
            DefinirDataNascimento(dataNascimento);
            DefinirEmail(email);
            DefinirEspecialidade(especialidade);
            DefinirCRM(crm);
        }

    }
}

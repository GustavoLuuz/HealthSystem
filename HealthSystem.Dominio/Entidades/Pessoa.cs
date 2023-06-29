using System.Text.RegularExpressions;

namespace HealthSystem.Dominio.Entidades
{
    public abstract class Pessoa
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string Email { get; private set; }
        public DateTime DataNascimento { get; private set; }

        protected Pessoa(string nome, string cpf, DateTime dataNascimento, string email)
        {
            DefinirNome(nome);
            DefinirCPF(cpf);
            DefinirDataNascimento(dataNascimento);
            DefinirEmail(email);
        }
        protected Pessoa(){}

        protected void DefinirNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome não pode estar em branco.");

            Nome = nome;
        }

        protected void DefinirCPF(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                throw new ArgumentException("O CPF não pode estar em branco.");

            cpf = RemoverFormatacaoCPF(cpf);

            if (!ValidarCPF(cpf))
                throw new ArgumentException("O CPF informado é inválido.");

            CPF = cpf;
        }
        private string RemoverFormatacaoCPF(string cpf)
        {
            return Regex.Replace(cpf, @"[^0-9]", "");
        }

        private bool ValidarCPF(string cpf)
        {
            if (cpf.Length != 11)
                return false;

            if (Regex.IsMatch(cpf, @"^(\d)\1*$"))
                return false;

            int[] multiplicadores1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicadores2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicadores1[i];

            int resto = soma % 11;
            int digito1 = resto < 2 ? 0 : 11 - resto;

            tempCpf += digito1;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicadores2[i];

            resto = soma % 11;
            int digito2 = resto < 2 ? 0 : 11 - resto;

            return cpf.EndsWith(digito1.ToString() + digito2.ToString());
        }

        protected void DefinirDataNascimento(DateTime dataNascimento)
        {
            if (!ValidarDataNascimento(dataNascimento))
                throw new ArgumentException("A data de nascimento não é válida.");

            DataNascimento = dataNascimento.Date;
        }

        private bool ValidarDataNascimento(DateTime dataNascimento)
        {
            return dataNascimento != DateTime.MinValue && dataNascimento <= DateTime.Now.Date;
        }
        protected void DefinirEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("O email não pode estar em branco.");

            if (!ValidarEmail(email))
                throw new ArgumentException("O email informado é inválido.");

            Email = email;
        }

        private bool ValidarEmail(string email)
        {
            string pattern = @"^.+@.+\..+$";
            return Regex.IsMatch(email, pattern);
        }
    }
}

namespace HealthSystem.Aplicacao.Comandos
{
    public class AtualizarMedicoComando
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Especialidade { get; set; }
        public string CRM { get; set; }
    }
}

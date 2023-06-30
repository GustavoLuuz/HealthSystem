namespace HealthSystem.Aplicacao.Comandos.ConsultaComandos
{
    public class AtualizarConsultaComando
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; }
        public int MedicoId { get; set; }
        public int PacienteId { get; set; }
        public string Observacoes { get; set; }
    }
}
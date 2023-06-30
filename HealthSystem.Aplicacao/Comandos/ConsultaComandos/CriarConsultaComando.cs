namespace HealthSystem.Aplicacao.Comandos.ConsultaComandos
{
    public class CriarConsultaComando
    {
        public DateTime DataHora { get; set; }
        public int MedicoId { get; set; }
        public int PacienteId { get; set; }
        public string Observacoes { get; set; }
    }
}
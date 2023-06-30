using HealthSystem.Dominio.Entidades;

namespace HealthSystem.Testes.Dominio
{
    public class MedicoTestes
    {
        [Fact]
        public void CriarMedico_DeveCriarMedicoCorretamente_QuandoDadosValidos()
        {
            // Arrange
            var nome = "Dr. Teste";
            var cpf = "78979793006";
            var dataNascimento = new DateTime(1980, 1, 1);
            var email = "teste@medico.com";
            var especialidade = "Cardiologia";
            var crm = "12345678";

            // Act
            var medico = new Medico(nome, cpf, dataNascimento, email, especialidade, crm);

            // Assert
            Assert.Equal(nome, medico.Nome);
            Assert.Equal(cpf, medico.CPF);
            Assert.Equal(dataNascimento, medico.DataNascimento);
            Assert.Equal(email, medico.Email);
            Assert.Equal(especialidade, medico.Especialidade);
            Assert.Equal(crm, medico.CRM);
        }

        [Fact]
        public void AtualizarMedico_DeveAtualizarDadosCorretamente_QuandoDadosValidos()
        {
            // Arrange
            var medico = new Medico("Dr. Teste", "30139805087", new DateTime(1980, 1, 1), "teste@medico.com", "Cardiologia", "12345678");
            var novoNome = "Dr. Teste Atualizado";
            var novoCpf = "51135969060";
            var novaDataNascimento = new DateTime(1980, 1, 2);
            var novoEmail = "teste2@medico.com";
            var novaEspecialidade = "Neurologia";
            var novoCrm = "23456789";

            // Act
            medico.AtualizarMedico(novoNome, novoCpf, novaDataNascimento, novoEmail, novaEspecialidade, novoCrm);

            // Assert
            Assert.Equal(novoNome, medico.Nome);
            Assert.Equal(novoCpf, medico.CPF);
            Assert.Equal(novaDataNascimento, medico.DataNascimento);
            Assert.Equal(novoEmail, medico.Email);
            Assert.Equal(novaEspecialidade, medico.Especialidade);
            Assert.Equal(novoCrm, medico.CRM);
        }
                
        [Fact]
        public void CriarMedico_DeveLancarExcecao_QuandoNomeInvalido()
        {
            // Arrange
            var nomeInvalido = "";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Medico(nomeInvalido, "78979793006", new DateTime(1980, 1, 1), "teste@medico.com", "Cardiologia", "12345678"));
        }

        [Fact]
        public void CriarMedico_DeveLancarExcecao_QuandoCPFInvalido()
        {
            // Arrange
            var cpfInvalido = "";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Medico("Dr. Teste", cpfInvalido, new DateTime(1980, 1, 1), "teste@medico.com", "Cardiologia", "12345678"));
        }

        [Fact]
        public void CriarMedico_DeveLancarExcecao_QuandoEmailInvalido()
        {
            // Arrange
            var emailInvalido = "";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Medico("Dr. Teste", "26200827060", new DateTime(1980, 1, 1), emailInvalido, "Cardiologia", "12345678"));
        }

        [Fact]
        public void CriarMedico_DeveLancarExcecao_QuandoCRMInvalido()
        {
            // Arrange
            var crmInvalido = "";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Medico("Dr. Teste", "65933431028", new DateTime(1980, 1, 1), "teste@medico.com", "Cardiologia", crmInvalido));
        }

        [Fact]
        public void AtualizarMedico_DeveLancarExcecao_QuandoNomeInvalido()
        {
            // Arrange
            var medico = new Medico("Dr. Teste", "14990565088", new DateTime(1980, 1, 1), "teste@medico.com", "Cardiologia", "12345678");
            var nomeInvalido = "";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => medico.AtualizarMedico(nomeInvalido, "14990565088", new DateTime(1980, 1, 2), "teste2@medico.com", "Neurologia", "23456789"));
        }
    }
}

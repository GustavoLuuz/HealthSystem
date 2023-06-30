using HealthSystem.Dominio.Entidades;

namespace HealthSystem.Testes.Dominio
{
    public class PacienteTestes
    {
        [Fact]
        public void CriarPaciente_DeveLancarExcecao_QuandoCPFInvalido()
        {
            // Arrange
            string nome = "Paciente Teste";
            string cpfInvalido = "1234590"; // CPF com menos de 11 digitos
            DateTime dataNascimento = new DateTime(1980, 1, 1);
            string email = "teste@paciente.com";
            string planoSaude = "Plano Saude A";

            // Act
            Action act = () => new Paciente(nome, cpfInvalido, dataNascimento, email, planoSaude);

            // Assert
            Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void CriarPaciente_DeveLancarExcecao_QuandoDataNascimentoInvalida()
        {
            // Arrange
            string nome = "Paciente Teste";
            string cpf = "61514548046";
            DateTime dataNascimentoInvalida = new DateTime(2050, 1, 1); // Data de nascimento no futuro
            string email = "teste@paciente.com";
            string planoSaude = "Plano Saude A";

            // Act
            Action act = () => new Paciente(nome, cpf, dataNascimentoInvalida, email, planoSaude);

            // Assert
            Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void CriarPaciente_NaoDeveLancarExcecao_QuandoDataNascimentoValida()
        {
            // Arrange
            string nome = "Paciente Teste";
            string cpf = "61514548046";
            DateTime dataNascimentoValida = new DateTime(2000, 1, 1);
            string email = "teste@paciente.com";
            string planoSaude = "Plano Saude A";

            // Act
            Action act = () => new Paciente(nome, cpf, dataNascimentoValida, email, planoSaude);

            // Assert
            var ex = Record.Exception(act);
            Assert.Null(ex);
        }



        [Fact]
        public void CriarPaciente_DeveLancarExcecao_QuandoEmailInvalido()
        {
            // Arrange
            string nome = "Paciente Teste";
            string cpf = "61514548046";
            DateTime dataNascimento = new DateTime(1980, 1, 1);
            string emailInvalido = "teste";
            string planoSaude = "Plano Saude A";

            // Act
            Action act = () => new Paciente(nome, cpf, dataNascimento, emailInvalido, planoSaude);

            // Assert
            Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void CriarPaciente_DeveLancarExcecao_QuandoPlanoSaudeInvalido()
        {
            // Arrange
            string nome = "Paciente Teste";
            string cpf = "61514548046";
            DateTime dataNascimento = new DateTime(1980, 1, 1);
            string email = "teste@paciente.com";
            string planoSaudeInvalido = ""; // Plano de Saúde em branco

            // Act
            Action act = () => new Paciente(nome, cpf, dataNascimento, email, planoSaudeInvalido);

            // Assert
            Assert.Throws<ArgumentException>(act);
        }

    }
}

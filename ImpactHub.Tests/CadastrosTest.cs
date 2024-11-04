using ImpactHub.API.Requests;
using ImpactHub.Business.Enums;
using ImpactHub.Business.Models;
using MongoDB.Bson;

namespace ImpactHub.Tests
{
    public class CadastrosTest
    {
        private List<CadastroModel> _cadastros;
        private readonly CadastroModel _novoCadastro;

        public CadastrosTest()
        {
            _cadastros = new List<CadastroModel>();
            _novoCadastro = new CadastroModel
            {
                IdCadastro = new ObjectId("64bcbaba1234567890abcdef"),
                NomeEmpresa = "Tech Innovators",
                Cnpj = "12345678000190",
                InscricaoEstadual = "1234567890",
                RazaoSocial = "Tech Innovators Ltda.",
                Porte = PorteEmpresaEnum.Grande,
                DataAbertura = DateTime.Parse("2024-11-02T22:30:04.333Z"),
                Email = "contato@techinnovators.com.br",
                NomeUsuario = "admin1",
                Senha = "senha123",
                StatusMonitoramento = StatusMonitoramentoEnum.Concluido
            };
        }

        [Fact]
        public async Task AddCadastro_WhenCadastroIsValid()
        {
            // Act
            await Task.Run(() => _cadastros.Add(_novoCadastro));

            // Assert
            var listaCadastros = _cadastros.FirstOrDefault(c => c.IdCadastro == _novoCadastro.IdCadastro);
            Assert.NotNull(listaCadastros);
            Assert.Equal(_novoCadastro.NomeEmpresa, listaCadastros.NomeEmpresa);
            Assert.Equal(_novoCadastro.Cnpj, listaCadastros.Cnpj);
            Assert.Equal(_novoCadastro.InscricaoEstadual, listaCadastros.InscricaoEstadual);
            Assert.Equal(_novoCadastro.RazaoSocial, listaCadastros.RazaoSocial);
            Assert.Equal(_novoCadastro.Porte, listaCadastros.Porte);
            Assert.Equal(_novoCadastro.DataAbertura, listaCadastros.DataAbertura);
            Assert.Equal(_novoCadastro.Email, listaCadastros.Email);
            Assert.Equal(_novoCadastro.NomeUsuario, listaCadastros.NomeUsuario);
            Assert.Equal(_novoCadastro.Senha, listaCadastros.Senha);
            Assert.Equal(_novoCadastro.StatusMonitoramento, listaCadastros.StatusMonitoramento);
        }


        [Fact]
        public async Task UpdateCadastro_WhenCadastroExists()
        {
            // Arrange
            _cadastros.Add(_novoCadastro);

            var cadastroRequestAtualizado = new CadastroRequest
            {
                NomeEmpresa = "Tech Innovators Updated",
                Cnpj = "12345678000190",
                InscricaoEstadual = "1234567890",
                RazaoSocial = "Tech Innovators Ltda.",
                Porte = PorteEmpresaEnum.Medio,
                DataAbertura = DateTime.UtcNow,
                Email = "updated@techinnovators.com.br",
                NomeUsuario = "admin2",
                Senha = "novaSenha123",
                StatusMonitoramento = StatusMonitoramentoEnum.NaoIniciado
            };

            // Act
            await Task.Run(() =>
            {
                var cadastro = _cadastros.FirstOrDefault(c => c.IdCadastro == _novoCadastro.IdCadastro);
                if (cadastro != null)
                {
                    cadastro.NomeEmpresa = cadastroRequestAtualizado.NomeEmpresa;
                    cadastro.Porte = cadastroRequestAtualizado.Porte;
                    cadastro.Email = cadastroRequestAtualizado.Email;
                }
            });

            // Assert
            var listaCadastros = _cadastros.FirstOrDefault(c => c.IdCadastro == _novoCadastro.IdCadastro);
            Assert.NotNull(listaCadastros);
            Assert.Equal(_novoCadastro.NomeEmpresa, listaCadastros.NomeEmpresa);
            Assert.Equal(_novoCadastro.Cnpj, listaCadastros.Cnpj);
            Assert.Equal(_novoCadastro.InscricaoEstadual, listaCadastros.InscricaoEstadual);
            Assert.Equal(_novoCadastro.RazaoSocial, listaCadastros.RazaoSocial);
            Assert.Equal(_novoCadastro.Porte, listaCadastros.Porte);
            Assert.Equal(_novoCadastro.DataAbertura, listaCadastros.DataAbertura);
            Assert.Equal(_novoCadastro.Email, listaCadastros.Email);
            Assert.Equal(_novoCadastro.NomeUsuario, listaCadastros.NomeUsuario);
            Assert.Equal(_novoCadastro.Senha, listaCadastros.Senha);
            Assert.Equal(_novoCadastro.StatusMonitoramento, listaCadastros.StatusMonitoramento);
        }

        [Fact]
        public async Task DeleteCadastro_WhenCadastroExists()
        {
            // Arrange
            _cadastros.Add(_novoCadastro);

            // Act
            await Task.Run(() => _cadastros.RemoveAll(c => c.IdCadastro == _novoCadastro.IdCadastro));

            // Assert
            var listaCadastros = _cadastros.FirstOrDefault(c => c.IdCadastro == _novoCadastro.IdCadastro);
            Assert.Null(listaCadastros);
        }

        [Fact]
        public async Task GetCadastroById_WhenCadastroExists()
        {
            // Arrange
            _cadastros.Add(_novoCadastro);

            // Act
            var listaCadastros = await Task.Run(() => _cadastros.FirstOrDefault(c => c.IdCadastro == _novoCadastro.IdCadastro));

            // Assert
            Assert.NotNull(listaCadastros);
            Assert.Equal(_novoCadastro.NomeEmpresa, listaCadastros.NomeEmpresa);
            Assert.Equal(_novoCadastro.Cnpj, listaCadastros.Cnpj);
            Assert.Equal(_novoCadastro.InscricaoEstadual, listaCadastros.InscricaoEstadual);
            Assert.Equal(_novoCadastro.RazaoSocial, listaCadastros.RazaoSocial);
            Assert.Equal(_novoCadastro.Porte, listaCadastros.Porte);
            Assert.Equal(_novoCadastro.DataAbertura, listaCadastros.DataAbertura);
            Assert.Equal(_novoCadastro.Email, listaCadastros.Email);
            Assert.Equal(_novoCadastro.NomeUsuario, listaCadastros.NomeUsuario);
            Assert.Equal(_novoCadastro.Senha, listaCadastros.Senha);
            Assert.Equal(_novoCadastro.StatusMonitoramento, listaCadastros.StatusMonitoramento);
        }

        [Fact]
        public void GetCadastro_ShouldReturnNull_WhenCadastroDoesNotExist()
        {
            //Arrange
            var idInvalido = new ObjectId("abc0def1fed2cba3abc4def5");

            //Act
            var listaCadastro = _cadastros.FirstOrDefault(m => m.IdCadastro == idInvalido);

            //Assert
            Assert.Null(listaCadastro);
        }
    }
}

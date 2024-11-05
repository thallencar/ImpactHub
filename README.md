# ImpactHub API
#### Integrantes
- Bruno Mathews Ciccio De Oliveira – RM99097 
- Isabelle Corsi – RM97751 
- José Luiz Ferreira Duarte – RM99488 
- Marina De Souza Cucco – RM551569 
- Thalita Fachinete de Alencar – RM99292 

## O Projeto
Impacthub é uma plataforma inovadora que auxilia empresas a gerenciar suas práticas de ESG (Environmental, Social and Governance) de forma eficiente e automatizada. Com a crescente demanda por sustentabilidade, transparência e responsabilidade social, muitas empresas enfrentam desafios para se manterem em conformidade com as regulamentações e demonstrar seu compromisso com o meio ambiente e a sociedade. A plataforma resolve esses desafios automatizando a coleta de dados, facilitando a conformidade com certificações e regulamentos, e oferecendo um ranking público de conformidade ESG. As principais soluções oferecidas incluem:
1. Automação e Insights Inteligentes
2. Conformidade e Certificação
3. Integração com Ferramentas de Negócios
4. Ranking Público e Engajamento
5. Transparência e Credibilidade

## Arquitetura da API
A arquitetura do projeto segue a abordagem de microsserviços.
> "Microsserviços são uma abordagem arquitetônica e organizacional do desenvolvimento de software na qual o software consiste em pequenos serviços independentes que se comunicam usando APIs bem definidas. Esses serviços pertencem a pequenas equipes autossuficientes. As arquiteturas de microsserviços facilitam a escalabilidade e agilizam o desenvolvimento de aplicativos, habilitando a inovação e acelerando o tempo de introdução de novos recursos no mercado."  - (AWS) 

Essa abordagem foi escolhida devido à necessidade de escalabilidade e independência dos serviços, permitindo que diferentes partes da aplicação sejam escaladas de forma isolada. Isso melhora a manutenção e aumenta a flexibilidade do projeto, permitindo alterações simultâneas em diversos serviços. Além disso, a arquitetura está alinhada com os princípios SOLID e padrões de design, promovendo uma divisão clara de responsabilidades e reduzindo a complexidade.


## Monolítico x Microsserviços
Embora a arquitetura monolítica não seja incorreta, é importante avaliar a complexidade do projeto e suas regras de negócio para decidir qual abordagem adotar. Aqui estão os prós e contras de cada modelo:
### 1. Monolítica
#### Prós
  - Estrutura simplificada: O projeto é desenvolvido em uma única camada, facilitando o desenvolvimento.
  - Menor consumo de recursos: Não exige a implantação de muitos recursos durante o desenvolvimento.
  - Depuração simplificada: Com a aplicação em uma única camada, a depuração é mais direta.
#### Contras
  - Manutenção: Conforme o projeto cresce, torna-se mais difícil realizar alterações rápidas.
  - Restrição tecnológica: A aplicação fica limitada ao uso de uma base tecnológica única.
  - Riscos de segurança: A concentração de dados em uma camada única aumenta a vulnerabilidade a ataques.
### 2. Microserviços
#### Prós
  - Objetividade: A arquitetura segue o padrão SOLID, dividindo responsabilidades de forma clara.
  - Flexibilidade: Permite o uso de diferentes tecnologias ao longo do desenvolvimento sem impacto no funcionamento.
  - Confiabilidade: A separação das responsabilidades reduz a probabilidade de falhas generalizadas ou ataques bem-sucedidos.
#### Contras
  - Complexidade: A comunicação entre microsserviços exige coordenação cuidadosa para garantir consistência dos dados.
  - Custo: Cada microsserviço tem seus próprios custos, o que pode aumentar os gastos.
  - Despadronização: O aumento da equipe de desenvolvimento pode levar à falta de padronização no código.


## Design Patterns
Os design patterns são soluções comprovadas para problemas comuns enfrentados por desenvolvedores. A API do ImpactHub implementa os seguintes padrões:
### Repository Pattern
Isola a camada de acesso a dados (Data Access Layer - DAL) e encapsula a lógica de comunicação com o banco de dados, utilizando repositórios especializados para cada entidade.
```
public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
{
    Task<TEntity> GetById(int id);
    Task<IEnumerable<TEntity>> GetAll();
    Task Add(TEntity entity);
    Task Update(TEntity entity);
    Task Delete(TEntity entity);
    Task<int> SaveChanges();
}
```
### Unity of Work
Gerencia transações com o banco de dados, garantindo a consistência dos dados. As alterações são salvas de forma atômica — ou todas são aplicadas ou nenhuma.
```
public async Task<int> SaveChanges()
{
    return await _context.SaveChangesAsync();
}

public void Dispose()
{
    _context?.Dispose();
}
```
### Data Acess Layer (DAL)
Responsável pela comunicação com o banco de dados, encapsula o código necessário para acessar e manipular dados, separando essa lógica do restante da aplicação.
```
public class ImpactHubDbContext : DbContext
{
    public ImpactHubDbContext(DbContextOptions options) : base(options) { }

     public DbSet<CadastroModel> Cadastros { get; set; }
     public DbSet<ContatoModel> Contatos { get; set; }
     public DbSet<EnderecoModel> Enderecos { get; set; }
     public DbSet<ResultadoESGModel> Resultados { get; set; }
     public DbSet<QuestionarioESGModel> Questionarios { get; set; }
}
```
### Controller Pattern
Gerencia as solicitações HTTP, interage com o modelo (representado pelo repositório) e retorna a resposta apropriada.
```
 [Route("[controller]")]
 [ApiController]
 public class CadastrosController : ControllerBase
 {
     private readonly ICadastroRepository _cadastroRepository;
     private readonly IMapper _mapper;

     public CadastrosController(ICadastroRepository cadastroRepository, IMapper mapper)
     {
         _cadastroRepository = cadastroRepository;
         _mapper = mapper;
     }

     [HttpGet]
     [ProducesResponseType(typeof(IEnumerable<CadastroResponse>), (int)HttpStatusCode.OK)]
     public async Task<IActionResult> GetAllCadastros()
     {
         var responseCadastros = _mapper.Map<IEnumerable<CadastroResponse>>(await _cadastroRepository.GetAllCadastros());

         return Ok(responseCadastros);
     }
```
### Singleton
Garante que uma classe tenha apenas uma instância e fornece um ponto de acesso global para essa instância.
```
IConfiguration configuration = builder.Configuration;
APIConfiguration appConfiguration = new();
configuration.Bind(appConfiguration);
builder.Services.Configure<APIConfiguration>(configuration);
```
## Testes Implementados
A API do ImpactHub inclui testes para garantir a funcionalidade e a qualidade do código. Testes Unitários foram implementados para verificar a lógica de cada unidade do código, utilizando o framework xUnit. Esse tipo de teste garante que métodos e funções individuais se comportem conforme o esperado.

```
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
```

## Práticas de Clean Code
várias práticas de Clean Code foram adotadas para garantir que o código seja legível, mantenha uma boa estrutura e facilite a manutenção. As principais práticas incluem:

**Nomenclatura Clara:** Variáveis, métodos e classes foram nomeados de forma que sua finalidade seja clara, evitando ambiguidades.
```
public string IdResultado { get; set; }
public double PontuacaoAmbiental { get; set; }
public double PontuacaoSocial { get; set; }
public double PontuacaoGovernanca { get; set; }
public string StatusResultado { get; set; }
public DateTime DataGeracao { get; set; }
public string NomeEmpresa { get; set; }
```
**Responsabilidade Única:** Cada classe e método tem uma única responsabilidade, o que melhora a coesão e facilita testes e manutenções futuras.
```
[HttpGet("{id}")]
[ProducesResponseType(typeof(QuestionarioESGModel), (int)HttpStatusCode.OK)]
[ProducesResponseType((int)HttpStatusCode.NotFound)]
public async Task<IActionResult> GetQuestionario(string id)
{
    var objectId = new ObjectId(id);
    var questionario = await GetQuestionarioById(objectId);

    if (questionario == null) return NotFound();

    return Ok(questionario);
}

```
**Redução de Código Duplicado:** Foi aplicado o princípio DRY (Don't Repeat Yourself), consolidando lógica comum em métodos e classes reutilizáveis.
```
[HttpGet]
[ProducesResponseType(typeof(IEnumerable<CadastroResponse>), (int)HttpStatusCode.OK)]
public async Task<IActionResult> GetAllCadastros()
{
    var responseCadastros = _mapper.Map<IEnumerable<CadastroResponse>>(await _cadastroRepository.GetAllCadastros());

    return Ok(responseCadastros);
}
```
**Organização e Estrutura:** O código é organizado em pacotes e namespaces lógicos, facilitando a navegação e compreensão do projeto.
```
namespace ImpactHub.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class QuestionarioESGController : ControllerBase
    {
        // Métodos do controlador
    }
}

```
**Manutenibilidade:** O código foi escrito pensando na facilidade de manutenção futura, com boas práticas de encapsulamento e desacoplamento.
```
public static IServiceCollection AddRepository(this IServiceCollection services)
{
    services.AddScoped<ICadastroRepository, CadastroRepository>();
    services.AddScoped<IContatoRepository, ContatoRepository>();
    services.AddScoped<IEnderecoRepository, EnderecoRepository>();
    services.AddScoped<IResultadoESGRepository, ResultadoESGRepository>();
    services.AddScoped<IQuestionarioESGRepository, QuestionarioESGRepository>();

    return services;
}
```

## SOLID
Os princípios SOLID foram aplicados para garantir que o código seja robusto, extensível e de fácil manutenção.
**Single Responsibility Principle (SRP):** Cada classe tem uma única responsabilidade. Por exemplo, o QuestionarioESGController é responsável apenas por lidar com as requisições relacionadas ao questionário ESG.

**Open/Closed Principle (OCP):** Classes e módulos estão abertos para extensão, mas fechados para modificação. Isso permite a adição de novas funcionalidades sem alterar o código existente.
**Liskov Substitution Principle (LSP):** Subclasses podem ser substituídas por suas classes base sem alterar o comportamento correto do programa.
**Interface Segregation Principle (ISP):** Interfaces específicas são definidas para evitar a implementação de métodos desnecessários em classes que as utilizam.
**Dependency Inversion Principle (DIP):** Dependa de abstrações, e não de implementações concretas.

### Exemplo Aplicado
```
public class QuestionarioESGController : ControllerBase
{
    private readonly IQuestionarioESGRepository _questionarioESGRepository;
    private readonly IMapper _mapper;

    public QuestionarioESGController(IQuestionarioESGRepository questionarioESGRepository, IMapper mapper)
    {
        _questionarioESGRepository = questionarioESGRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllQuestionarios()
    {
        var responseQuestionarios = _mapper.Map<IEnumerable<QuestionarioESGResponse>>(await _questionarioESGRepository.GetAllQuestionariosESG());
        return Ok(responseQuestionarios);
    }
}
```

### Funcionalidades da IA Generativa
A API incorpora funcionalidades de IA generativa para aprimorar os insights e relatórios ESG, incluindo:

**Análise Preditiva:** Utiliza modelos de Machine Learning para prever o desempenho ESG das empresas com base em dados históricos e tendências atuais.
**Geração de Relatórios Inteligentes:** Criação automática de relatórios detalhados sobre práticas ESG, adaptados às necessidades específicas de cada empresa.
**Sugestões Proativas:** A IA oferece sugestões para melhoria contínua nas práticas ESG, ajudando as empresas a se manterem competitivas e em conformidade com os padrões regulatórios.

# ImpactHub API

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
    public DbSet<LoginModel> Logins { get; set; }
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

    public CadastrosController(ICadastroRepository cadastroRepository)
    {
        _cadastroRepository = cadastroRepository;
    }

    // GET: api/cadastros
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<CadastroModel>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAllCadastros()
    {
        var cadastros = await _cadastroRepository.GetAllCadastros();

        return Ok(cadastros);
    }
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

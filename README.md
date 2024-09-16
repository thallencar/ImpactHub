# ImpactHub API

## O Projeto
Impacthub é uma plataforma inovadora para ajudar empresas a gerenciar suas práticas de ESG (Environmental, Social and Governance) de forma eficiente e automatizada. Com a crescente demanda por sustentabilidade, transparência e responsabilidade social, muitas empresas encontram dificuldades para se manter em conformidade com as regulamentações e provar seu compromisso com o meio ambiente e sociedade. A plataforma resolve esses desafios automatizando a coleta de dados, facilitando a conformidade com certificações e regulamentos, e oferecendo um ranking públic de conformidade ESG. A plataforma oferece cinco soluções principais:
1. Automação e Insights Inteligentes
2. Conformidade e Certificação
3. Integração com Ferramentas de Negócios
4. Ranking Público e Engajamento
5. Transparência e Credibilidade

## Arquitetura da API
A arquitetura escolhida para o projeto, foi a abordagem de microsservices.
> "Microsserviços são uma abordagem arquitetônica e organizacional do desenvolvimento de software na qual o software consiste em pequenos serviços independentes que se comunicam usando APIs bem definidas. Esses serviços pertencem a pequenas equipes autossuficientes. As arquiteturas de microsserviços facilitam a escalabilidade e agilizam o desenvolvimento de aplicativos, habilitando a inovação e acelerando o tempo de introdução de novos recursos no mercado."  - (AWS) 

A escolha foi baseada na necessidade de escalabilidade e independência entre os serviços, permitindo que diferentes partes da aplicação sejam escaladas de forma independente e sem a necessidade de escalar toda a aplicação. Com isso, há uma melhora significativa na manutenção do projeto, além do aumento de sua flexibilidade, permitindo a alteração simutânea em diferentes serviços. Além disso, essa abordagem está mais alinhada com os princípios SOLID e design patterns, assim promovendo uma melhor divisão de responsabilidades e reduzindo a complexidade do projeto.


## Monolithic x Microservices
Como descrito no tópico acima, microservices são um tipo de arquitetura que combina flexibilidade, escalabilidade, interdependência e baixo nível de complexidade. A arquitetura monolítica não é em si errada, porém é necessário avaliar a complexidade do projeto, bem como sua regra de negócio. Ao fazer o levantamento de requisitos do projeto, devemos levar em conta esses dois pontos levantados e assim decidir a melhor forma de conduzir o projeto. Houve o seguinte levantamento de prós e contras:
### 1. Monolítica
#### Prós
  - Estrutura simplificada: O projeto é criado em apenas uma camada, gerando uma maior facilidade para desenvolver o código;
  - Redução de recursos: Não é necessária a implantação de muitos recursos ao longo do desenvolvimento do projeto;
  - Depuração de testes: Uma vez em que a aplicação encontra-se em uma camada só, a depuração do código fica mais simples.
#### Contras
  - Manutenção: Ao passo que a aplicação vai aumentando, suas responsabilidades também. Assim ficará cada vez mais difícil de fazer rápidas alterações no código;
  - Restrição: Por usar a mesma base de tecnlogias, a aplicação não se torna apta a receber diferentes tecnologias;
  - Riscos: Pelo fato de todos os dados se encontrarem algomerados em uma camada só, a aplicação se torna mais vulnerável à ataques e tentativas maliciosas de dano ao produto.
### 2. Microserviços
#### Prós
  - Objetividade: A arquitetura consequentemente adota o padrão SOLID, dividindo cada camada em uma responsabilidade diferente;
  - Flexibilidade: Várias tecnologias podem ser implementadas ao longo do desenvolvimento do projeto, sem interferir na sua aplicabilidade;
  - Confiabilidade: Pelo fato de cada camada ter a sua responsabilidade, a probabilidade de sofrer ataques ou ter a aplicação derrubada é muito menor.
#### Contras
  - Complexibilidade: A comunicação entre os microserviços requerem uma abordagem cuidadosa para garantir a coordenação e a consistência dos dados;
  - Custos: Cada microserviço possui seu custo, o que pode eventualmente fugir da realidade financeira da empresa;
  - Despadronização: À medida em que o projeto é desenvolvido, mais pessoas podem se juntar ao time de desenvolvimento, podendo acarretar na falta de padronização dos códigos.


## Design Patterns
Design Patterns são resoluções de problemas diferentes, comumente enfrentados por desenvolvedores. A API do Impacthub conta com a implementação de alguns padrões de designs:
### Repository Pattern
Isola a Data Acess Layer (DAL) e encapsula a lógica necessária para a comunicação com o banco de dados, utilizando os repositórios especializados para criar uma interface para cada entidade da camada de negócio.
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
Gerencia as transações de banco de dados e garante a consistência dos dados. O padrão garante que todas as mudanças sejam salvas de forma atômica, ou seja, todas as operações são concluídas ou nenhuma é.
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
Camada que lida com a comunicação com o banco de dados, encapsulando o código necessário para acessar e manipular os dados, separando a lógica do restante da aplicação.
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
Recebe as solicitações HTTP, interage com o modelo (representado pelo repositório) e retorna a resposta apropriada.
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
Permite a garantia de que uma classe tenha apenas uma instância, enquanto provê um ponto de acesso global para essa instância.
```
            IConfiguration configuration = builder.Configuration;
            APIConfiguration appConfiguration = new();
            configuration.Bind(appConfiguration);
            builder.Services.Configure<APIConfiguration>(configuration);
```

using ImpactHub.Business.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ML;

namespace ImpactHub.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ESGPrevisoesController : ControllerBase
    {
        private readonly string caminhoModelo = Path.Combine(Environment.CurrentDirectory, "wwwroot", "MLModels", "ModeloESG.zip");
        private readonly string caminhoTreinamento = Path.Combine(Environment.CurrentDirectory, "Data", "data.csv");
        private readonly MLContext mlContext;

        public ESGPrevisoesController()
        {
            mlContext = new MLContext();

            if (!System.IO.File.Exists(caminhoModelo))
            {
                Console.WriteLine("Modelo não encontrado. Iniciando treinamento...");
                TreinarModelo();
            }
        }

        private void TreinarModelo()
        {
            var pastaModelo = Path.GetDirectoryName(caminhoModelo);
            if (!Directory.Exists(pastaModelo))
            {
                Directory.CreateDirectory(pastaModelo);
                Console.WriteLine($"Diretório criado: {pastaModelo}");
            }

            // Carregar dados de treinamento
            IDataView dadosTreinamento = mlContext.Data.LoadFromTextFile<ESGPrevisaoMlModel>(
                path: caminhoTreinamento, hasHeader: true, separatorChar: ',');

            // Definir a pipeline de transformações e treinamento
            var pipeline = mlContext.Transforms.CopyColumns(outputColumnName: "Label", inputColumnName: nameof(ESGPrevisaoMlModel.TotalScore))
                .Append(mlContext.Transforms.Concatenate("Features", nameof(ESGPrevisaoMlModel.EnvironmentScore), nameof(ESGPrevisaoMlModel.SocialScore), nameof(ESGPrevisaoMlModel.GovernanceScore)))
                .Append(mlContext.Regression.Trainers.FastTree());

            // Treinamento do modelo
            var modelo = pipeline.Fit(dadosTreinamento);

            // Salvar o modelo treinado em um arquivo .zip
            mlContext.Model.Save(modelo, dadosTreinamento.Schema, caminhoModelo);
            Console.WriteLine($"Modelo treinado e salvo em: {caminhoModelo}");
        }

        [HttpPost("prever")]
        public ActionResult<PrevisaoESG> PreverESG([FromBody] ESGPrevisaoMlModel dados)
        {
            if (!System.IO.File.Exists(caminhoModelo))
            {
                return BadRequest("O modelo ainda não foi treinado.");
            }

            // Carregar o modelo salvo
            ITransformer modelo;
            using (var stream = new FileStream(caminhoModelo, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                modelo = mlContext.Model.Load(stream, out var modeloSchema);
            }

            // Criar o engine de previsão
            var enginePrevisao = mlContext.Model.CreatePredictionEngine<ESGPrevisaoMlModel, PrevisaoESG>(modelo);

            // Realizar a previsão
            var previsao = enginePrevisao.Predict(dados);

            return Ok(previsao);
        }
    }
}
﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ImpactHub.API.Responses
{
    public class EnderecoResponse
    {
        public string IdEndereco { get; set; }
        public string Cep { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string? Complemento { get; set; }
        public string PontoReferencia { get; set; }
        public string NomeEmpresa { get; set; }
    }
}

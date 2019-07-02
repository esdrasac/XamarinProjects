using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using App01_ConsultarCep.Serviços.Modelo;
using Newtonsoft.Json;

namespace App01_ConsultarCep.Serviços {
    public class ViaCepServico {
        public static string EnderecoURL = "https://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCep(string cep) {
            string novoEnderecoUrl = string.Format(EnderecoURL, cep);
            WebClient wc = new WebClient();
            string conteudo = wc.DownloadString(novoEnderecoUrl);
            Endereco end = JsonConvert.DeserializeObject<Endereco>(conteudo);
            if(end.cep == null) return null;
            return end;
        }
    }
}

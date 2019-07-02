using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCep.Serviços;
using App01_ConsultarCep.Serviços.Modelo;
namespace App01_ConsultarCep {
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();
            Botao.Clicked += BuscarCep;
        }
        private void BuscarCep(object sender, EventArgs args) {
            string cep = CEP.Text.Trim();
            if(isValid(cep)) {
                try {
                    Endereco end = ViaCepServico.BuscarEnderecoViaCep(cep);
                    if(end != null) {
                        Resultado.Text = string.Format($"CEP {cep}\n\n{end.logradouro} - {end.bairro} - {end.localidade}/{end.uf}");
                    }
                    else {
                        Resultado.Text = "Não foi encontrado nenhum endereço correspondente ao CEP digitado";
                    }
                }catch(Exception e) {
                    Resultado.Text = "Verifique sua conexão com a internet";
                }
            }
            else {
                CEP.Text = "";
            }
        }

        private bool isValid(string cep){
            bool valido = true;
            if(cep.Length != 8) {
                Resultado.Text = "CEP inválido\n\nPor favor, digite outro CEP.";
                valido = false;
            }
            int novoCep = 0;
            if(!int.TryParse(cep, out novoCep)) {
                Resultado.Text = "Use apenas números.";

                valido = false;
            }

            return valido;
        }
    }
}

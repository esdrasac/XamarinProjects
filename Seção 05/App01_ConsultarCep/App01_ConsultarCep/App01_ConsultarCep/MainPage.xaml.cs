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
            
            try {
                string cep = CEP.Text.Trim();
                validacao.Text = "";
                if(isValid(cep)) {
                    try {
                        Endereco end = ViaCepServico.BuscarEnderecoViaCep(cep);
                        if(end != null) {
                            Resultado.IsVisible = true;
                            Resultado.Text = string.Format($"CEP {cep}\n\n{end.logradouro} - {end.bairro} - {end.localidade}/{end.uf}");

                        }
                        else {
                            Resultado.Text = "Não foi encontrado nenhum endereço correspondente ao CEP digitado";
                        }
                    }
                    catch(Exception e) {
                        Resultado.Text = "Verifique sua conexão com a internet";
                    }
                }
                else {
                    CEP.Text = "";
                }
            }
            catch(Exception i) {
                validacao.Text = "Digite um CEP";
            }
            }

        private bool isValid(string cep) {
            bool valido = true;
            if(cep.Length != 8) {
                validacao.Text = "CEP inválido\n\nPor favor, digite outro CEP.";
                valido = false;
            }
            int novoCep = 0;
            if(!int.TryParse(cep, out novoCep)) {
                validacao.Text = "Use apenas números.";

                valido = false;
            }

            return valido;
        }
    }
}

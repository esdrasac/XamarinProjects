﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App02_TiposPaginaXF.TipoPagina.Carousel {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TipoPagina03 : ContentPage {
        public TipoPagina03() {
            InitializeComponent();
        }
        private void MudarPagina(object sender, EventArgs args) {
            App.Current.MainPage = new Navigation.Pagina01();
        }
    }
}
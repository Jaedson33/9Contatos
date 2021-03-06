﻿using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace _9Contatos.Interface
{
    public sealed partial class Janela_EditaContato : ContentDialog
    {

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
    "NumeroEditado", typeof(string), typeof(Janela_EditaContato), new PropertyMetadata(default(string)));

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        private string Nome = "";
        private string Celular = "";

        public string Result = "X";
        public Janela_EditaContato()
        {
            this.InitializeComponent();
        }

        public Janela_EditaContato(string Nome, string Celular)
        {
            this.Nome = Nome;
            this.Celular = Celular;
            this.InitializeComponent();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            // Cancelar
            Result = NumeroEditado.Text;
            NumeroEditado.Text = "X";
            this.Hide();


        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            // Editar
            this.Hide();
        }

        private void ContentDialog_Loaded(object sender, RoutedEventArgs e)
        {
            NomeEditado.Text = this.Nome;
            NumeroEditado.Text = this.Celular;
        }
    }
}

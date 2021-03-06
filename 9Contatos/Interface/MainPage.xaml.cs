﻿using System;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using _9Contatos.Classe;
using Windows.UI.Popups;
using _9Contatos.Interface;

#warning TEM UM GRANDE CONSUMO DE MEMÓRIA AO TROCAR DE FRAMES, PRECISO CORRIGIR ISSO!!!

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace _9Contatos
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private OpcoesAvancadas xx;

        public MainPage()
        {
            InitializeComponent();
            Globais.contatos.Clear();
        }

        private void bt_Mais_Opcoes_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(OpcoesAvancadas),xx);
        }

        private async void image1_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ProgressBar.Visibility = Visibility.Visible;
            Globais.api_usada = QualAPI.PeopleAPI;
            bool Carregar = await CarregaContatos.Carrega(QualAPI.PeopleAPI);
            ProgressBar.Visibility = Visibility.Collapsed;
            if (Carregar == true)
            {
                if (Globais.contatos.Count() == 0)
                {
                    var pergunta = new MessageDialog("Como não tem nenhum contato na agenda você não poderá editar nada.");
                    pergunta.Title = "Nenhum contato encontrado";
                    pergunta.Commands.Add(new UICommand { Label = "Entendi", Id = 0 });
                    await pergunta.ShowAsync();
                }
                else
                {
                    Frame.Navigate(typeof(TelaContatos));
                }
            }
        }

        private void bt_Sobre_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Sobre));
        }

        private void image1_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            Image1_border.Background = new SolidColorBrush(Windows.UI.Colors.Gray);
        }

        private void image1_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            Image1_border.Background = new SolidColorBrush(Windows.UI.Colors.Black);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x416

namespace LegendsOfSenai
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        int x=20;
        public MainPage()
        {
            this.InitializeComponent();
            Debug.WriteLine(x);

        //    MainCanvas.Background = Image_Loaded(object sender);
        }

     /*   void Image_Loaded(object sender)
        {
            Image BgImage =  new Image;
            BitmapImage bitmapImage = new BitmapImage();
            BgImage.Width = bitmapImage.DecodePixelWidth =520; //natural px width of image source
                                                        
            bitmapImage.UriSource = new Uri(BgImage.BaseUri, "Assets/Zeldao.gif");
        }*/

        private void Start_Button_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("aaaaaaaaaaaa");

            /*  Tela1_Mapa TelaMapa = new Tela1_Mapa();
              var host = new Window();
              host.Content =  TelaMapa;
              host.Show();
              */
            this.Frame.Navigate(typeof(Tela1_Mapa));
         
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            x += 5;
            Debug.WriteLine(x);
        }

        private async void anyEVent(object sender, RoutedEventArgs e)
        {
           /* var a = new Legends_lib.Personagem();

            a.Nome = "NAME";
            a.Classe = "Classe";

            var b = new Legends_lib.maps.mapa_geral.Controls.MainMapControl();
            b.MetricaX(this.ActualWidth);*/


        }
    }
}

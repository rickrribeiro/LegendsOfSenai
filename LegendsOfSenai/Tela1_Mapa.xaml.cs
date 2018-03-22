﻿using Legends_lib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Windows.UI.Input;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Legends_lib.maps.mapa_geral.Controls;
using Legends_lib.Item;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml;
using Windows.Media.Playback;
using Windows.Media.Core;

namespace LegendsOfSenai
{
   
    
        /// <summary>
        /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
        /// </summary>
        public sealed partial class Tela1_Mapa : Page
        {
        
        public Mapa Map = new MainMapControl().InciarMapa();
        public Personagem selecionado;
        public bool selecionou;
        Queue<Jogador> FilaJogador;
        Jogador JogadorAtual;
        
        Dictionary<uint, Windows.UI.Xaml.Input.Pointer> pointers;
        public Tela1_Mapa()
        {
            selecionou = false;
            this.InitializeComponent();
            pointers = new Dictionary<uint, Pointer>();
            FilaJogador = new Queue<Jogador>();
            FilaJogador.Enqueue(new Jogador());
            FilaJogador.Enqueue(new Jogador());
            JogadorAtual = FilaJogador.Dequeue();
           
          //  BtnPlayWav(); MUSICA
            IniciarCastelos();

            //Setando o data biding


            JogadorAtual.Inventario = new List<Item>();
            JogadorAtual.Inventario.Add(new Item { Nome = "item1", Tipo = EItens.Consumivel });
            JogadorAtual.Inventario.Add(new Item { Nome = "item2", Tipo = EItens.Equipavel });
            JogadorAtual.Inventario.Add(new Item { Nome = "item3", Tipo = EItens.NaoUtilizavel });
            Invetario_list.ItemsSource = JogadorAtual.Inventario;
            Player_info.ItemsSource = new List<Jogador>() { JogadorAtual };

           
        }
        private async void BtnPlayWav()
        {
            MediaElement mysong = new MediaElement();
            Windows.Storage.StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
            Windows.Storage.StorageFile file = await folder.GetFileAsync("MusicaMain.mp3");
            var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
            mysong.SetSource(stream, file.ContentType);
           
           // mysong.Volume = 100;
            mysong.Play();
        }
        private void IniciarCastelos()
        {
            Debug.WriteLine("Iniciando Castelos");

            JogadorAtual.Castelos.Add(new Castelo(1,7));
            JogadorAtual.Castelos.Add(new Castelo(2,7));
            JogadorAtual.Castelos.Add(new Castelo(1,8));
            JogadorAtual.Castelos.Add(new Castelo(2,8));

            FilaJogador.Enqueue(JogadorAtual);
            JogadorAtual = FilaJogador.Dequeue();

            JogadorAtual.Castelos.Add(new Castelo(17,7));
            JogadorAtual.Castelos.Add(new Castelo(18,7));
            JogadorAtual.Castelos.Add(new Castelo(17,8));
            JogadorAtual.Castelos.Add(new Castelo(18,8));

            FilaJogador.Enqueue(JogadorAtual);
            JogadorAtual = FilaJogador.Dequeue();
        }

      

        private void Target_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
           
            e.Handled = true;

            PointerPoint ptrPt = e.GetCurrentPoint(mapa);
            Debug.WriteLine("pos X: " + ptrPt.Position.X);

            Debug.WriteLine("pos Y: " + ptrPt.Position.Y);

            Debug.WriteLine(calcCasa.getPosCasa((int)ptrPt.Position.X));
            if(Map.casa[calcCasa.getPosCasa((int)ptrPt.Position.X), calcCasa.getPosCasa((int)ptrPt.Position.Y)].Personagem != null){
                Debug.WriteLine("TEM PERSONAGEM AQUI");
            }
            if (selecionou == false)
            {
                Debug.WriteLine("entrou");
                if (Map.casa[calcCasa.getPosCasa((int)ptrPt.Position.X),calcCasa.getPosCasa((int)ptrPt.Position.Y)].Personagem != null)
                {
                    selecionou = true;
                    selecionado = Map.casa[calcCasa.getPosCasa((int)ptrPt.Position.X),calcCasa.getPosCasa((int)ptrPt.Position.Y)].Personagem;
                   // map.casa[calcCasa.getPosCasa((int)ptrPt.Position.X)][calcCasa.getPosCasa((int)ptrPt.Position.Y)].Personagem = null;
                }
            }
            else
            {
                if (Map.casa[calcCasa.getPosCasa((int)ptrPt.Position.X),calcCasa.getPosCasa((int)ptrPt.Position.Y)].Personagem == null && Map.casa[calcCasa.getPosCasa((int)ptrPt.Position.X), calcCasa.getPosCasa((int)ptrPt.Position.Y)].Andavel)
                {
                    Debug.WriteLine(Map.casa[calcCasa.getPosCasa((int)ptrPt.Position.X), calcCasa.getPosCasa((int)ptrPt.Position.Y)].Andavel);
                    selecionou = false;
                    Map.casa[calcCasa.getPosCasa((int)ptrPt.Position.X),calcCasa.getPosCasa((int)ptrPt.Position.Y)].Personagem=selecionado;
                    Map.casa[selecionado.PosX, selecionado.PosY].Personagem = null;
                    selecionado.PosX = calcCasa.getPosCasa((int)ptrPt.Position.X);
                    selecionado.PosY = calcCasa.getPosCasa((int)ptrPt.Position.Y);
                    Canvas.SetLeft(selecionado.Imagem, (calcCasa.getPosCasa((int)ptrPt.Position.X)) * 40);
                    Canvas.SetTop(selecionado.Imagem, (calcCasa.getPosCasa((int)ptrPt.Position.Y)) * 40);
                    
                    // map.casa[calcCasa.getPosCasa((int)ptrPt.Position.X)][calcCasa.getPosCasa((int)ptrPt.Position.Y)].Personagem = null;
                }
            }


        }

        private void Button_Mudar_Turno(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            FilaJogador.Enqueue(JogadorAtual);
            JogadorAtual = FilaJogador.Dequeue();
        }

        private void Inventario_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (Inventario.Opacity != 0) {
                Inventario.Opacity = 0;
            }
            else
            {
                Inventario.Opacity = 100;
            }
           
        }
        private void Recrutamento(object sender, RoutedEventArgs e)
        {
            foreach (Castelo cast in JogadorAtual.Castelos) {
              
                if (Map.casa[cast.Cordx, cast.Cordy].Personagem == null)
                {
                    Personagem person = new Guerreiro(cast.Cordx, cast.Cordy);
                    person.CriarImagem();
                    mapa.Children.Add(person.Imagem);
                    Canvas.SetLeft(person.Imagem, cast.Cordx * 40);
                    Canvas.SetTop(person.Imagem, cast.Cordy * 40);
                    Map.casa[cast.Cordx, cast.Cordy].Personagem = person;
                    JogadorAtual.Personagens.Add(person);
                    break;
                    }
               
            }
         //   Personagem person = new Guerreiro();
        }
       
        private void AbreRecrutamento(object sender, TappedRoutedEventArgs e)
        {
            FlyoutBase.ShowAttachedFlyout((FrameworkElement) sender);
        }
        private void UpdateEventLog(string v)
        {
            throw new NotImplementedException();
        }

        private void Button_Turno_Click(object sender, RoutedEventArgs e)
        {

        }
    }
    
}

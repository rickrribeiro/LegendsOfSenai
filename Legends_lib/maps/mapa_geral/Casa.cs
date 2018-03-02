﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legends_lib
{ 
    public class Casa
    {
        public bool Andavel { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public Personagem Personagem { get; set; }
        public Item Item { get; set; }

        Casa(bool andavel,int posX,int posY)
        {
            this.Andavel = andavel;
            this.PosX = posX;
            this.PosY = posY;
            this.Personagem = null;
            this.Item = null;
        }

        // fazer o metodo de alteração aleatoria 
    }
}
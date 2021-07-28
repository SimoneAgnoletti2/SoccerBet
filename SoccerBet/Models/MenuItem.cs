using System;
using System.Collections.Generic;
using System.Text;

namespace SoccerBet.Models
{
    public class MenuItemCustom
    {
        public string Immagine { get; set; }
        public string Nome { get; set; }

        public MenuItemCustom()
        { }
        public MenuItemCustom(string immagine, string nome)
        {
            Immagine = immagine;
            Nome = nome;
        }

    }
}

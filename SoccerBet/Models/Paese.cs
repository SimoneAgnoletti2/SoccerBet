using System;
using System.Collections.Generic;
using System.Text;

namespace SoccerBet.Models
{
    public class Paese
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string LinkImage { get; set; }
        public int Valida { get; set; }
        public Paese()
        {

        }
        public Paese(int id, string nome, string linkImage, int preferito, int valida)
        {
            Id = id;
            Nome = nome;
            LinkImage = linkImage;
            Valida = valida;
        }
    }
}

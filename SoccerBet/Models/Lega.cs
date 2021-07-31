using System;
using System.Collections.Generic;
using System.Text;

namespace SoccerBet.Models
{
    public class Lega
    {
        public int Id { get; set; }
        public int IdPaese { get; set; }
        public string Nome { get; set; }
        public string LinkImage { get; set; }
        public Lega() { }
        public Lega(int id, int idpaese, string nome, string linkimage)
        {
            Id = id;
            IdPaese = idpaese;
            Nome = nome;
            LinkImage = linkimage;
        }

    }
}

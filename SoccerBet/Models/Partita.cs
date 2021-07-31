using System;
using System.Collections.Generic;
using System.Text;

namespace SoccerBet.Models
{
    public class Partita
    {
        public int Id { get; set; }
        public int Id_Lega { get; set; }
        public string NomeCasa { get; set; }
        public string LinkCasa { get; set; }
        public string NomeFuori { get; set; }
        public string LinkFuori { get; set; }
        public string Orario  { get; set; }
        public string Risultato { get; set; }
        public string Data { get; set; }
        public float Quota_1 { get; set; }
        public float Quota_X { get; set; }
        public float Quota_2 { get; set; }
        public float Quota_Under05 { get; set; }
        public float Quota_Over05 { get; set; }
        public float Quota_Under15 { get; set; }
        public float Quota_Over15 { get; set; }
        public float Quota_Under25 { get; set; }
        public float Quota_Over25 { get; set; }
        public float Quota_Under35 { get; set; }
        public float Quota_Over35 { get; set; }
        public float Quota_1X { get; set; }
        public float Quota_X2 { get; set; }
        public float Quota_12 { get; set; }
        public float Quota_Goal { get; set; }
        public float Quota_NoGoal { get; set; }
        public Partita() { }
        public Partita(int id, int id_Lega, string nomeCasa, string linkCasa, string nomeFuori, string linkFuori, string orario,
                        string risultato, string data, float quota_1, float quota_X, float quota_2, float quota_Under05,
                        float quota_Over05, float quota_Under15, float quota_Over15, float quota_Under25, float quota_Over25,
                        float quota_Under35, float quota_Over35, float quota_1X, float quota_X2, float quota_12, float quota_Goal,
                        float quota_NoGoal)
        {
            Id = id;
            Id_Lega = id_Lega;
            NomeCasa = nomeCasa;
            LinkCasa = linkCasa;
            NomeFuori = nomeFuori;
            LinkFuori = linkFuori;
            Orario = orario;
            Risultato = risultato;
            Data = data;
            Quota_1 = quota_1;
            Quota_X = quota_X;
            Quota_2 = quota_2;
            Quota_Under05 = quota_Under05;
            Quota_Over05 = quota_Over05;
            Quota_Under15 = quota_Under15;
            Quota_Over15 = quota_Over15;
            Quota_Under25 = quota_Under25;
            Quota_Over25 = quota_Over25;
            Quota_Under35 = quota_Under35;
            Quota_Over35 = quota_Over35;
            Quota_1X = quota_1X;
            Quota_X2 = quota_X2;
            Quota_12 = quota_12;
            Quota_Goal = quota_Goal;
            Quota_NoGoal = quota_NoGoal;
        }
    }
}

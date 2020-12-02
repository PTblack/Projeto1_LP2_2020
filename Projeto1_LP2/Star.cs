using System;
using System.Collections.Generic;
using System.Resources;
using System.Text;

namespace Projeto1_LP2
{
    public struct Star
    {
        //SE QUISEREM MUDAR A ORDEM PARA COINCIDIR COM O FICHEIRO MUDEM
        public int Teff { get; }
        public int Age { get; }
        public int Rotp { get; }
        public float Rade { get; }
        public float Masse { get; }
        public float Vsin { get; }
        public float Dist { get; }

        //disc stands for discovery
        public string Disc_method { get; }
        public int Disc_year { get; }

        public Star(
            int teff, int age, int rotp, int disc_year, float rade, 
            float masse, float vsin, float dist, string disc_method)
        {
            Teff = teff;
            Age = age;
            Rotp = rotp;
            Disc_year = disc_year;
            Rade = rade;
            Masse = masse;
            Vsin = vsin;
            Dist = dist;
            Disc_method = disc_method;
        }
    }
}
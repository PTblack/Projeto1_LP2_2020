using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto1_LP2
{
    public struct Planet
    {
        //SE QUISEREM MUDAR A ORDEM PARA COINCIDIR COM O FICHEIRO MUDEM
        public string Name { get; }
        public string HostName { get; } 
        public float Rade { get; }
        public float Masse { get; }
        public int Eqt { get; }
        public int Orberter { get; }

        //disc stands for discovery
        public string Disc_method { get; }
        public int Disc_year { get; }

        public Planet(
            int eqt, int orberter, int disc_year,  float rade,
            float masse, string name, string hostname, string disc_method)
        {
            Eqt = eqt;
            Orberter = orberter;
            Disc_year = disc_year;
            Rade = rade;
            Masse = masse;
            Name = name;
            HostName = hostname;
            Disc_method = disc_method;
        }
    }   
}

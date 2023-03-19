using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joc_de_Carti_Final
{
    class CarteSpeciala : Carte
    {
        int aux;
        public CarteSpeciala(int numar, int forma)
        {
            this.numar = numar;
            this.forma = forma;
        }

        override public int SpecialMove()
        {
            switch (numar)
            {
                case 13: aux = 5; return aux;
                case 1: aux = 2; return aux;
                case 10: aux = 2; return aux;
                case 12: aux = 1; return aux;
                default: aux = 0; return aux;
            }
        }
    }
}

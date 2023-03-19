using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joc_de_Carti_Final
{
    class CarteNormala : Carte
    {
        public CarteNormala(int numar, int forma)
        {
            this.numar = numar;
            this.forma = forma;
        }

        public CarteNormala(System.Drawing.Image imgaux)
        {
            this.SetImage(imgaux);
            this.numar = 15;
            this.forma = 15;
        }

        override public int SpecialMove() { return 0; }
    }
}

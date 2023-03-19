using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Joc_de_Carti_Final
{
    class Joc : Pachet
    {
        List<Carte> Deck = new List<Carte>();
        string[] vector_valori_numere = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "Joker" };
        string[] vector_valori_forma = { "inima rosie", "romb", "trefla", "inima neagra", "rosu", "negru" };
        Random rng = new Random();
        bool turn;
        int active, picknumber;

        protected override void Initializeaza()
        {
            Deck.Clear();
            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    switch (i)
                    {
                        case 0: Deck.Add(new CarteSpeciala(i, j)); break;
                        case 1: Deck.Add(new CarteSpeciala(i, j)); break;
                        case 10: Deck.Add(new CarteSpeciala(i, j)); break;
                        case 12: Deck.Add(new CarteSpeciala(i, j)); break;
                        case 13: Deck.Add(new CarteSpeciala(i, j)); break;
                        default: Deck.Add(new CarteNormala(i, j)); break;
                    }
                }
            }
            if (joker_flag)
            {
                Deck.Add(new CarteSpeciala(13, 4));
                Deck.Add(new CarteSpeciala(13, 5));
            }
        }

        public void Shuffle()
        {
            foreach (Carte aux in Deck)
            {
                aux.SetPut(false);
            }
        }

        public Carte Pick()
        {
            bool preamulte = false;
            int contor_luate = 0;
            active = rng.Next(this.nr_carti);
            while (Deck[active].GetTaken() || Deck[active].GetPut())
            {
                active = rng.Next(this.nr_carti);
                if (contor_luate++ > 200)
                {
                    preamulte = true;
                    break;
                }
            }
            if (preamulte) { 
                foreach (Carte o in Deck)
                {
                    if(!Deck[active].GetTaken() && !Deck[active].GetPut())
                    {
                        return o;
                    }
                }
                return null; 
            }
            Deck[active].SetTaken(true);
            Deck[active].SetImage(System.Drawing.Image.FromFile(@"..\..\Properties\Imagini\" 
            + vector_valori_numere[Deck[active].GetNumar()] 
            + vector_valori_forma[Deck[active].GetForma()] + ".png"));
            return Deck[active];
        }

        public void SetPut(System.Drawing.Image imagine_put)
        {
            for (int i = 0; i < Deck.Count(); i++)
            {
                if (imagine_put == Deck[i].GetImage())
                {
                    Deck[i].SetTaken(false);
                    Deck[i].SetPut(true);
                    break;
                }
            }
        }

        public bool SwapPlayers() { return (turn = !turn); }

        public int GetPickNumber() { return picknumber; }

        public void SetPickNumber(int picknumber) { this.picknumber = picknumber; }

        public Carte ReturnTaken(int numar, int forma)
        {
            for (int i = 0; i < Deck.Count; i++)
            {
                if (Deck[i].GetNumar() == numar && Deck[i].GetForma() == forma)
                {
                    Deck[i].SetTaken(true);
                    Deck[i].SetImage(System.Drawing.Image.FromFile(@"..\..\Properties\Imagini\" + vector_valori_numere[Deck[i].GetNumar()] + vector_valori_forma[Deck[i].GetForma()] + ".png"));
                    return Deck[i];
                }
            }
            return null;
        }

        public Joc(bool joker_flag)
        {
            picknumber = 1;
            turn = true;
            if (this.joker_flag = joker_flag) { this.nr_carti = 54; }
            else { this.nr_carti = 52; }
            Initializeaza();
        }
    }
}
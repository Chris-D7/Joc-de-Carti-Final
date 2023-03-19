using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joc_de_Carti_Final
{
    abstract class Carte
    {
        protected bool taken;
        protected bool put;
        protected int numar;
        protected int forma;
        protected System.Windows.Forms.PictureBox imagine = new System.Windows.Forms.PictureBox();
        public Carte()
        {
            taken = false;
            put = false;
        }
        #region Getters/Setters
        public int GetNumar() { return numar; }
        public int GetForma() { return forma; }

        public void SetTaken(bool taken) { this.taken = taken; }
        public bool GetTaken() { return taken; }

        public void SetPut(bool put) { this.put = put; }
        public bool GetPut() { return put; }

        public void SetImage(System.Drawing.Image image) { imagine.Image = image; }
        public System.Drawing.Image GetImage() { return imagine.Image; }
        public System.Windows.Forms.PictureBox GetPictureBox() { return imagine; }
        #endregion

        public abstract int SpecialMove();
    }
}

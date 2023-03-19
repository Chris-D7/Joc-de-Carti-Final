using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Joc_de_Carti_Final
{
    public partial class ClientForm : Form
    {
        Joc Macao = new Joc(true);
        List<Carte> ExDeck1 = new List<Carte>();
        List<Carte> ExDeck2 = new List<Carte>();
        Carte First_Card;
        int active; bool turn = false;
        SoundPlayer simplesound = new SoundPlayer(global::Joc_de_Carti_Final.Properties.Resources.boom_sound_effect);
        SoundPlayer shufflesound = new SoundPlayer(global::Joc_de_Carti_Final.Properties.Resources.shuffle);

        public TcpClient client;
        public NetworkStream clientStream;
        public bool ascult;
        public Thread t;

        public ClientForm()
        {
            InitializeComponent();
        }

        private void Asculta_client()
        {
            StreamReader citire = new StreamReader(clientStream);
            String dateClient;
            while (ascult)
            {
                dateClient = citire.ReadLine();
                MethodInvoker m = new MethodInvoker(() =>
                {
                    InfoPrimit.Text = dateClient;
                    String[] sprimit = dateClient.Split(' ');
                    if (sprimit[0] == "-1")
                    {
                        Macao.SetPickNumber(Int16.Parse(sprimit[1]) - ExDeck2.Count);
                        if (ExDeck2.Count == 0)
                        {
                            Macao.SetPickNumber(5);
                        }
                        for (int i = 0; i < Macao.GetPickNumber(); i++)
                        {
                            Carte auxiliar = new CarteNormala(System.Drawing.Image.FromFile(@"..\..\Properties\Imagini\Back.png"));
                            ExDeck2.Add(auxiliar);
                            ExDeck2[ExDeck2.Count - 1].GetPictureBox().Location = new System.Drawing.Point(3, 3);
                            ExDeck2[ExDeck2.Count - 1].GetPictureBox().Size = new System.Drawing.Size(125, 156);
                            ExDeck2[ExDeck2.Count - 1].GetPictureBox().TabStop = false;
                            flowPlayer2.Controls.Add(ExDeck2[ExDeck2.Count - 1].GetPictureBox());
                            Player2cardcount.Text = ExDeck2.Count + " CARDS";
                        }
                        Macao.SetPickNumber(1);
                    }
                    if (sprimit[0] == "first")
                    {
                        int numar = Int16.Parse(sprimit[1]);
                        int forma = Int16.Parse(sprimit[2]);
                        First_Card = Macao.ReturnTaken(numar, forma);
                        pictureBoxPUT.Image = First_Card.GetImage();

                    }
                    if (sprimit[0] == "carte")
                    {
                        int numar = Int16.Parse(sprimit[1]);
                        int forma = Int16.Parse(sprimit[2]);
                        ExDeck1.Add(Macao.ReturnTaken(numar, forma));
                        ExDeck1[ExDeck1.Count - 1].GetPictureBox().Location = new System.Drawing.Point(3, 3);
                        ExDeck1[ExDeck1.Count - 1].GetPictureBox().Size = new System.Drawing.Size(125, 156);
                        ExDeck1[ExDeck1.Count - 1].GetPictureBox().TabStop = false;
                        ExDeck1[ExDeck1.Count - 1].GetPictureBox().Click += new System.EventHandler(auxiliar_image_Click1);
                        flowPlayer1.Controls.Add(ExDeck1[ExDeck1.Count - 1].GetPictureBox());
                        Player1cardcount.Text = ExDeck1.Count + " CARDS";
                    }
                    if (sprimit[0] == "turn")
                    {
                        swaplabelcolor();
                        turn = !Boolean.Parse(sprimit[1]);
                    }
                    if (sprimit[0] == "place")
                    {
                        flowPlayer2.Controls.Remove(ExDeck2[ExDeck2.Count - 1].GetPictureBox());
                        ExDeck2.RemoveAt(ExDeck2.Count - 1);
                        Player2cardcount.Text = ExDeck2.Count + " CARDS";

                        int numar = Int16.Parse(sprimit[1]);
                        int forma = Int16.Parse(sprimit[2]);
                        First_Card = Macao.ReturnTaken(numar, forma);

                        if (First_Card.GetNumar() == 13) { simplesound.Play(); }
                        pictureBoxPUT.Image = First_Card.GetImage();

                        int spaux = First_Card.SpecialMove();
                        switch (First_Card.GetNumar())
                        {
                            case 13: if (Macao.GetPickNumber() == 1) { Macao.SetPickNumber(0); } Macao.SetPickNumber(Macao.GetPickNumber() + spaux); break;
                            case 1: if (Macao.GetPickNumber() == 1) { Macao.SetPickNumber(0); } Macao.SetPickNumber(Macao.GetPickNumber() + spaux); break;
                            case 10: if (Macao.GetPickNumber() == 1) { Macao.SetPickNumber(0); } Macao.SetPickNumber(Macao.GetPickNumber() + spaux); break;
                            case 12: Macao.SetPickNumber(spaux); break;
                            default: break;
                        }
                    }
                    if (sprimit[0] == "shuffle")
                    {
                        shufflesound.Play();
                    }
                    if (sprimit[0] == "won")
                    {
                        labelPLayer2.Text = null;
                        labelPlayer1.Text = labelPlayer1.Text + " WINS!";
                        btnPick.Click -= this.btnPick_Click;
                        btnPlace.Click -= this.Place_Click;
                        simplesound.Play();
                    }
                });
                InfoPrimit.Invoke(m);
            }
        }

        private void ClientFormClosed(object sender, FormClosedEventArgs e)
        {
            ascult = false;
            if (t != null) { t.Abort(); }
            if (clientStream != null)
            {
                clientStream.Close();
            }
            if (client != null)
            {
                client.Close();
            }
            Environment.Exit(0);
        }

        private void btnPick_Click(object sender, EventArgs e)
        {
            if (turn)
            {
                btnPlace.Image = null;
                InfoTrimis.Text = "-1";
                Trimite();
                Macao.SetPickNumber(1);
            }
        }

        private void Place_Click(object sender, EventArgs e)
        {
            if (btnPlace.Image != null)
            {
                if (Macao.GetPickNumber() > 1)
                {
                    if (turn)
                    {
                        if (ExDeck1[active].GetNumar() == 1 || ExDeck1[active].GetNumar() == 10 || ExDeck1[active].GetNumar() == 12 || ExDeck1[active].GetNumar() == 13)
                        {
                            PlaceFunction();
                        }
                        else { MessageBox.Show("Nope", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                }
                else
                {
                    if (turn)
                    {
                        if (ExDeck1[active].GetForma() == First_Card.GetForma() || ExDeck1[active].GetNumar() == First_Card.GetNumar()
                            || (First_Card.GetForma() == 4 && (ExDeck1[active].GetForma() == 0 || ExDeck1[active].GetForma() == 1))
                            || (First_Card.GetForma() == 5 && (ExDeck1[active].GetForma() == 2 || ExDeck1[active].GetForma() == 3))
                            || (ExDeck1[active].GetForma() == 4 && (First_Card.GetForma() == 0 || First_Card.GetForma() == 1))
                            || (ExDeck1[active].GetForma() == 5 && (First_Card.GetForma() == 2 || First_Card.GetForma() == 3)))
                        {
                            PlaceFunction();
                        }
                        else { MessageBox.Show("Nope", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                }
            }
        }

        private void PlaceFunction()
        {
            if (btnPlace.Image != null && turn)
            {
                if (ExDeck1.Count == 1)
                {
                    labelPlayer1.Text = null;
                    labelPLayer2.Text = labelPLayer2.Text + " WINS!";
                    btnPick.Click -= this.btnPick_Click;
                    btnPlace.Click -= this.Place_Click;
                    simplesound.Play();
                    InfoTrimis.Text = "won";
                    Trimite();
                }
                flowPlayer1.Controls.Remove(ExDeck1[active].GetPictureBox());
                if (ExDeck1[active].GetNumar() == 13) { simplesound.Play(); }
                ExDeck1[active].GetPictureBox().Click -= auxiliar_image_Click1;
                Macao.SetPut(First_Card.GetImage());
                First_Card = ExDeck1[active];
                ExDeck1.RemoveAt(active);
                pictureBoxPUT.Image = btnPlace.Image;
                Player1cardcount.Text = ExDeck1.Count + " CARDS";
                btnPlace.Image = null;
                InfoTrimis.Text = "place " + First_Card.GetNumar() + " " + First_Card.GetForma();
                Trimite();
            }
        }

        private void auxiliar_image_Click1(object sender, EventArgs e)
        {
            if (turn)
            {
                btnPlace.Image = ((System.Windows.Forms.PictureBox)sender).Image;
                for (int i = 0; i < ExDeck1.Count(); i++)
                {
                    if (ExDeck1[i].GetImage() == btnPlace.Image)
                    {
                        active = i;
                    }
                }
            }
        }

        private void swaplabelcolor()
        {
            System.Drawing.Color auxcolor = labelPLayer2.ForeColor;
            labelPLayer2.ForeColor = labelPlayer1.ForeColor;
            labelPlayer1.ForeColor = auxcolor;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (btnConnect.Text == "Connect")
            {
                if (IpBox.Text.Length > 0)
                {
                    try { 
                        client = new TcpClient(IpBox.Text, 3000);
                        ascult = true;
                        t = new Thread(new ThreadStart(Asculta_client));
                        t.Start();
                        clientStream = client.GetStream();

                        btnPick.Enabled = true;
                        btnPlace.Enabled = true;
                        IpBox.Visible = false;
                        IpBox.Enabled = false;
                        btnConnect.Text = "Disconnect";
                    }
                    catch (System.Net.Sockets.SocketException exp)
                    {
                        DialogResult res = MessageBox.Show("Adresa nu este valida!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Specificati adresa de IP");
                }
            }
            else
            {
                ascult = false;
                t.Abort();
                StreamWriter scriere = new StreamWriter(clientStream);
                scriere.AutoFlush = true; // enable automatic flushing
                try
                {
                    scriere.WriteLine("#Gata");
                }
                catch(System.IO.IOException exp) { Environment.Exit(0); }
            }
        }

        private void Trimite()
        {
            try
            {
                StreamWriter scriere = new StreamWriter(clientStream);
                scriere.AutoFlush = true; // enable automatic flushing
                scriere.WriteLine(InfoTrimis.Text);
                // s_text.Close();
            }
            catch (Exception e)
            {

            }
            finally
            {
                // code in finally block is guranteed 
                // to execute irrespective of 
                // whether any exception occurs or does 
                // not occur in the try block
                //  client.Close();
            }
        }
    }
}

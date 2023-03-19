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
using Joc_de_Carti_Final;

namespace Joc_de_Carti_Final
{
    public partial class ServerForm : Form
    {
        Joc Macao = new Joc(true);
        List<Carte> ExDeck1 = new List<Carte>();
        List<Carte> ExDeck2 = new List<Carte>();
        Carte First_Card;
        int active; bool turn = true;
        SoundPlayer simplesound = new SoundPlayer(global::Joc_de_Carti_Final.Properties.Resources.boom_sound_effect);
        SoundPlayer shufflesound = new SoundPlayer(global::Joc_de_Carti_Final.Properties.Resources.shuffle);

        public TcpListener server;
        public String dateServer;
        //private static fServer serverForm;
        Thread t;
        bool workThread;
        NetworkStream streamServer;

        public ServerForm()
        {
            InitializeComponent();

            server = new TcpListener(System.Net.IPAddress.Any, 3000);
            server.Start();
            t = new Thread(new ThreadStart(Asculta_Server));
            workThread = true;
            t.Start();
        }

        public void Asculta_Server()
        {

            while (workThread)
            {
                Socket socketServer = server.AcceptSocket();
                try
                {
                    streamServer = new NetworkStream(socketServer);
                    StreamReader citireServer = new StreamReader(streamServer);

                    while (workThread)
                    {
                        dateServer = citireServer.ReadLine();
                        //char temp;
                        //    do {
                        //    temp = (char)citireServer.Read();
                        //    dateServer += temp;
                        //} while (!citireServer.EndOfStream);


                        if (dateServer == null) break;//primesc nimic - clientul a plecat
                        else if (dateServer == "#Gata") //ca sa pot sa inchid serverul
                            workThread = false;
                        MethodInvoker m = new MethodInvoker(() => {
                            this.InfoPrimit.Text = dateServer;
                            if (dateServer == "-1")
                            {
                                Carte auxiliar;
                                if ((auxiliar = Macao.Pick()) != null)
                                {
                                    if (ExDeck2.Count == 0)
                                    {
                                        Macao.SetPickNumber(5);
                                    }
                                    for (int i = 0; i < Macao.GetPickNumber(); i++)
                                    {
                                        if (ExDeck2.Count != 0) { if (auxiliar == ExDeck2[ExDeck2.Count - 1]) { auxiliar = Macao.Pick(); } }
                                        if (auxiliar != null)
                                        {
                                            ExDeck2.Add(auxiliar);
                                            ExDeck2[ExDeck2.Count - 1].GetPictureBox().Image = System.Drawing.Image.FromFile(@"..\..\Properties\Imagini\Back.png");
                                            ExDeck2[ExDeck2.Count - 1].GetPictureBox().Location = new System.Drawing.Point(3, 3);
                                            ExDeck2[ExDeck2.Count - 1].GetPictureBox().Size = new System.Drawing.Size(125, 156);
                                            ExDeck2[ExDeck2.Count - 1].GetPictureBox().TabStop = false;
                                            flowPlayer2.Controls.Add(ExDeck2[ExDeck2.Count - 1].GetPictureBox());
                                            InfoTrimis.Text = "carte " + ExDeck2[ExDeck2.Count - 1].GetNumar() + " " + ExDeck2[ExDeck2.Count - 1].GetForma();
                                            Trimite();
                                            Player2cardcount.Text = ExDeck2.Count + " CARDS";
                                        }
                                    }
                                    ChangeTurns();
                                    Macao.SetPickNumber(1);
                                }
                                else
                                {
                                    InfoTrimis.Text = "shuffle";
                                    Trimite();
                                    shufflesound.Play();
                                    Macao.Shuffle();
                                }
                            }
                            if (dateServer != "-1")
                            {
                                String[] sprimit = dateServer.Split(' ');
                                if (sprimit[0] == "place")
                                {
                                    Macao.SetPut(First_Card.GetImage());
                                    flowPlayer2.Controls.Remove(ExDeck2[ExDeck2.Count - 1].GetPictureBox());
                                    ExDeck2.RemoveAt(ExDeck2.Count - 1);
                                    Player2cardcount.Text = ExDeck2.Count + " CARDS";

                                    int numar = Int16.Parse(sprimit[1]);
                                    int forma = Int16.Parse(sprimit[2]);
                                    First_Card = Macao.ReturnTaken(numar, forma);

                                    if (First_Card.GetNumar() == 13) { simplesound.Play(); }
                                    pictureBoxPUT.Image = First_Card.GetImage();
                                    First_Card.SetImage(System.Drawing.Image.FromFile(@"..\..\Properties\Imagini\Back.png"));
                                    int spaux = First_Card.SpecialMove();
                                    switch (First_Card.GetNumar())
                                    {
                                        case 13: if (Macao.GetPickNumber() == 1) { Macao.SetPickNumber(0); } Macao.SetPickNumber(Macao.GetPickNumber() + spaux); break;
                                        case 1: if (Macao.GetPickNumber() == 1) { Macao.SetPickNumber(0); } Macao.SetPickNumber(Macao.GetPickNumber() + spaux); break;
                                        case 10: if (Macao.GetPickNumber() == 1) { Macao.SetPickNumber(0); } Macao.SetPickNumber(Macao.GetPickNumber() + spaux); break;
                                        case 12: Macao.SetPickNumber(spaux); break;
                                        case 0: ChangeTurns(); break;
                                        default: break;
                                    }
                                }
                                ChangeTurns();
                                if (sprimit[0] == "won")
                                {
                                    swaplabelcolor();
                                    labelPlayer1.Text = null;
                                    labelPLayer2.Text = labelPLayer2.Text + " WINS!";
                                    btnPick.Click -= this.btnPick_Click;
                                    btnPlace.Click -= this.Place_Click;
                                    simplesound.Play();
                                }
                            }
                        });
                        this.InfoPrimit.Invoke(m);
                    }
                    streamServer.Close();
                }
                catch (Exception e)
                {
#if LOG
                    Console.WriteLine(e.Message);
#endif
                }
                socketServer.Close();
            }

        }

        private void ServerFormClosed(object sender, FormClosedEventArgs e)
        {
            workThread = false;
            if (streamServer != null) streamServer.Close();
            Environment.Exit(0);
        }

        private void btnPick_Click(object sender, EventArgs e)
        {
            Carte auxiliar;
            if ((auxiliar = Macao.Pick()) != null)
            {
                if (turn)
                {
                    if (pictureBoxPUT.Image == null)
                    {
                        First_Card = Macao.Pick();
                        pictureBoxPUT.Image = First_Card.GetImage();
                        InfoTrimis.Text = "first " + First_Card.GetNumar() + " " + First_Card.GetForma();
                        Trimite();
                    }
                    btnPlace.Image = null;
                    if (ExDeck1.Count == 0)
                    {
                        Macao.SetPickNumber(5);
                    }
                    for (int i = 0; i < Macao.GetPickNumber(); i++)
                    {
                        if (ExDeck1.Count != 0) { if (auxiliar == ExDeck1[ExDeck1.Count - 1]) { auxiliar = Macao.Pick(); } }
                        if (auxiliar != null)
                        {
                            ExDeck1.Add(auxiliar);
                            ExDeck1[ExDeck1.Count - 1].GetPictureBox().Location = new System.Drawing.Point(3, 3);
                            ExDeck1[ExDeck1.Count - 1].GetPictureBox().Size = new System.Drawing.Size(125, 156);
                            ExDeck1[ExDeck1.Count - 1].GetPictureBox().TabStop = false;
                            ExDeck1[ExDeck1.Count - 1].GetPictureBox().Click += new System.EventHandler(auxiliar_image_Click1);
                            flowPlayer1.Controls.Add(ExDeck1[ExDeck1.Count - 1].GetPictureBox());
                            Player1cardcount.Text = ExDeck1.Count + " CARDS";
                        }
                    }
                    ChangeTurns();
                    InfoTrimis.Text = "-1 " + ExDeck1.Count;
                    Macao.SetPickNumber(1);
                    Trimite();
                }
            }
            else {
                InfoTrimis.Text = "shuffle";
                Trimite();
                shufflesound.Play(); 
                Macao.Shuffle(); 
            }
        }

        private void Place_Click(object sender, EventArgs e)
        {
            if (turn)
            {
                if (btnPlace.Image != null)
                {
                    if (Macao.GetPickNumber() > 1)
                    {
                        if (ExDeck1[active].GetNumar() == 1 || ExDeck1[active].GetNumar() == 10
                            || ExDeck1[active].GetNumar() == 12 || ExDeck1[active].GetNumar() == 13)
                        {
                            PlaceFunction();
                        }
                        else { MessageBox.Show("Nope", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                    else
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
                if (ExDeck1.Count == 1)
                {
                    swaplabelcolor();
                    labelPLayer2.Text = null;
                    labelPlayer1.Text = labelPlayer1.Text + " WINS!";
                    btnPick.Click -= this.btnPick_Click;
                    btnPlace.Click -= this.Place_Click;
                    simplesound.Play();
                    InfoTrimis.Text = "won";
                    Trimite();
                }
                int spaux = ExDeck1[active].SpecialMove();
                flowPlayer1.Controls.Remove(ExDeck1[active].GetPictureBox());
                ExDeck1[active].GetPictureBox().Click -= auxiliar_image_Click1;
                Macao.SetPut(First_Card.GetImage());
                First_Card = ExDeck1[active];
                ExDeck1.RemoveAt(active);
                pictureBoxPUT.Image = btnPlace.Image;
                Player1cardcount.Text = ExDeck1.Count + " CARDS";
                switch (First_Card.GetNumar())
                {
                    case 13: if (Macao.GetPickNumber() == 1) { Macao.SetPickNumber(0); } Macao.SetPickNumber(Macao.GetPickNumber() + spaux); break;
                    case 1: if (Macao.GetPickNumber() == 1) { Macao.SetPickNumber(0); } Macao.SetPickNumber(Macao.GetPickNumber() + spaux); break;
                    case 10: if (Macao.GetPickNumber() == 1) { Macao.SetPickNumber(0); } Macao.SetPickNumber(Macao.GetPickNumber() + spaux); break;
                    case 12: Macao.SetPickNumber(spaux); break;
                    case 0: ChangeTurns(); break;
                    default: break;
                }
                ChangeTurns();
                btnPlace.Image = null;
                InfoTrimis.Text = "place " + First_Card.GetNumar() + " " + First_Card.GetForma();
                Trimite();
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
                        break;
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

        private void ChangeTurns()
        {
            turn = Macao.SwapPlayers();
            swaplabelcolor();
            InfoTrimis.Text = "turn " + turn;
            Trimite();
        }

        private void Trimite()
        {
            try
            {
                StreamWriter scriere = new StreamWriter(streamServer);
                scriere.AutoFlush = true; // enable automatic flushing
                scriere.WriteLine(InfoTrimis.Text);
                // s_text.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Nu este nimeni conectat la tine!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


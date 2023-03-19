using System.Collections.Generic;
using System.Media;

namespace Joc_de_Carti_Final
{
    partial class ClientForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowPlayer1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPick = new System.Windows.Forms.Button();
            this.flowPlayer2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPlace = new System.Windows.Forms.Button();
            this.pictureBoxPUT = new System.Windows.Forms.PictureBox();
            this.labelPlayer1 = new System.Windows.Forms.Label();
            this.labelPLayer2 = new System.Windows.Forms.Label();
            this.Player2cardcount = new System.Windows.Forms.Label();
            this.Player1cardcount = new System.Windows.Forms.Label();
            this.InfoTrimis = new System.Windows.Forms.Label();
            this.InfoPrimit = new System.Windows.Forms.Label();
            this.IpBox = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPUT)).BeginInit();
            this.SuspendLayout();
            // 
            // flowPlayer1
            // 
            this.flowPlayer1.AutoScroll = true;
            this.flowPlayer1.Location = new System.Drawing.Point(155, 369);
            this.flowPlayer1.Name = "flowPlayer1";
            this.flowPlayer1.Size = new System.Drawing.Size(683, 180);
            this.flowPlayer1.TabIndex = 1;
            this.flowPlayer1.WrapContents = false;
            // 
            // btnPick
            // 
            this.btnPick.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPick.Image = global::Joc_de_Carti_Final.Properties.Resources.Back;
            this.btnPick.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPick.Location = new System.Drawing.Point(12, 369);
            this.btnPick.Name = "btnPick";
            this.btnPick.Size = new System.Drawing.Size(137, 180);
            this.btnPick.TabIndex = 2;
            this.btnPick.Text = "PICK";
            this.btnPick.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPick.UseVisualStyleBackColor = true;
            this.btnPick.Click += new System.EventHandler(this.btnPick_Click);
            // 
            // flowPlayer2
            // 
            this.flowPlayer2.AutoScroll = true;
            this.flowPlayer2.Location = new System.Drawing.Point(155, 12);
            this.flowPlayer2.Name = "flowPlayer2";
            this.flowPlayer2.Size = new System.Drawing.Size(683, 180);
            this.flowPlayer2.TabIndex = 3;
            this.flowPlayer2.WrapContents = false;
            // 
            // btnPlace
            // 
            this.btnPlace.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPlace.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPlace.Location = new System.Drawing.Point(12, 12);
            this.btnPlace.Name = "btnPlace";
            this.btnPlace.Size = new System.Drawing.Size(137, 180);
            this.btnPlace.TabIndex = 4;
            this.btnPlace.Text = "PLACE";
            this.btnPlace.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPlace.UseVisualStyleBackColor = true;
            this.btnPlace.Click += new System.EventHandler(this.Place_Click);
            // 
            // pictureBoxPUT
            // 
            this.pictureBoxPUT.Location = new System.Drawing.Point(12, 198);
            this.pictureBoxPUT.Name = "pictureBoxPUT";
            this.pictureBoxPUT.Padding = new System.Windows.Forms.Padding(6, 4, 6, 5);
            this.pictureBoxPUT.Size = new System.Drawing.Size(137, 165);
            this.pictureBoxPUT.TabIndex = 5;
            this.pictureBoxPUT.TabStop = false;
            // 
            // labelPlayer1
            // 
            this.labelPlayer1.AutoSize = true;
            this.labelPlayer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayer1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.labelPlayer1.Location = new System.Drawing.Point(155, 195);
            this.labelPlayer1.Name = "labelPlayer1";
            this.labelPlayer1.Size = new System.Drawing.Size(94, 20);
            this.labelPlayer1.TabIndex = 6;
            this.labelPlayer1.Text = "PLAYER 2";
            this.labelPlayer1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelPLayer2
            // 
            this.labelPLayer2.AutoSize = true;
            this.labelPLayer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPLayer2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelPLayer2.Location = new System.Drawing.Point(155, 346);
            this.labelPLayer2.Name = "labelPLayer2";
            this.labelPLayer2.Size = new System.Drawing.Size(94, 20);
            this.labelPLayer2.TabIndex = 7;
            this.labelPLayer2.Text = "PLAYER 1";
            this.labelPLayer2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Player2cardcount
            // 
            this.Player2cardcount.AutoSize = true;
            this.Player2cardcount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player2cardcount.ForeColor = System.Drawing.Color.Black;
            this.Player2cardcount.Location = new System.Drawing.Point(718, 195);
            this.Player2cardcount.Name = "Player2cardcount";
            this.Player2cardcount.Size = new System.Drawing.Size(0, 20);
            this.Player2cardcount.TabIndex = 10;
            this.Player2cardcount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Player1cardcount
            // 
            this.Player1cardcount.AutoSize = true;
            this.Player1cardcount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player1cardcount.ForeColor = System.Drawing.Color.Black;
            this.Player1cardcount.Location = new System.Drawing.Point(718, 346);
            this.Player1cardcount.Name = "Player1cardcount";
            this.Player1cardcount.Size = new System.Drawing.Size(0, 20);
            this.Player1cardcount.TabIndex = 11;
            this.Player1cardcount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // InfoTrimis
            // 
            this.InfoTrimis.AutoSize = true;
            this.InfoTrimis.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InfoTrimis.Location = new System.Drawing.Point(255, 323);
            this.InfoTrimis.Name = "InfoTrimis";
            this.InfoTrimis.Size = new System.Drawing.Size(58, 20);
            this.InfoTrimis.TabIndex = 12;
            this.InfoTrimis.Text = "NONE";
            // 
            // InfoPrimit
            // 
            this.InfoPrimit.AutoSize = true;
            this.InfoPrimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InfoPrimit.Location = new System.Drawing.Point(255, 218);
            this.InfoPrimit.Name = "InfoPrimit";
            this.InfoPrimit.Size = new System.Drawing.Size(58, 20);
            this.InfoPrimit.TabIndex = 13;
            this.InfoPrimit.Text = "NONE";
            // 
            // IpBox
            // 
            this.IpBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IpBox.Location = new System.Drawing.Point(575, 266);
            this.IpBox.Name = "IpBox";
            this.IpBox.Size = new System.Drawing.Size(143, 26);
            this.IpBox.TabIndex = 14;
            this.IpBox.Text = "127.0.0.1";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(724, 266);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 26);
            this.btnConnect.TabIndex = 15;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.IpBox);
            this.Controls.Add(this.InfoPrimit);
            this.Controls.Add(this.InfoTrimis);
            this.Controls.Add(this.Player1cardcount);
            this.Controls.Add(this.Player2cardcount);
            this.Controls.Add(this.labelPLayer2);
            this.Controls.Add(this.labelPlayer1);
            this.Controls.Add(this.pictureBoxPUT);
            this.Controls.Add(this.btnPlace);
            this.Controls.Add(this.flowPlayer2);
            this.Controls.Add(this.btnPick);
            this.Controls.Add(this.flowPlayer1);
            this.Name = "ClientForm";
            this.Text = "Macao - Client";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ClientFormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPUT)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPick;
        private System.Windows.Forms.FlowLayoutPanel flowPlayer1;
        private System.Windows.Forms.FlowLayoutPanel flowPlayer2;
        private System.Windows.Forms.Button btnPlace;
        private System.Windows.Forms.PictureBox pictureBoxPUT;
        private System.Windows.Forms.Label labelPlayer1;
        private System.Windows.Forms.Label labelPLayer2;
        private System.Windows.Forms.Label Player2cardcount;
        private System.Windows.Forms.Label Player1cardcount;
        private System.Windows.Forms.Label InfoTrimis;
        private System.Windows.Forms.Label InfoPrimit;
        private System.Windows.Forms.TextBox IpBox;
        private System.Windows.Forms.Button btnConnect;
    }
}


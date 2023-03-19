
namespace Joc_de_Carti_Final
{
    partial class MenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            this.MenuText = new System.Windows.Forms.Label();
            this.btnHost = new System.Windows.Forms.Button();
            this.btnJoin = new System.Windows.Forms.Button();
            this.btnRules = new System.Windows.Forms.Button();
            this.labelRules = new System.Windows.Forms.Label();
            this.pictureBoxMenu = new System.Windows.Forms.PictureBox();
            this.pictureBoxAce = new System.Windows.Forms.PictureBox();
            this.pictureBoxJoker = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAce)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxJoker)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuText
            // 
            this.MenuText.AutoSize = true;
            this.MenuText.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuText.Location = new System.Drawing.Point(57, 46);
            this.MenuText.Name = "MenuText";
            this.MenuText.Size = new System.Drawing.Size(230, 63);
            this.MenuText.TabIndex = 0;
            this.MenuText.Text = "MACAO";
            // 
            // btnHost
            // 
            this.btnHost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHost.Location = new System.Drawing.Point(68, 127);
            this.btnHost.Name = "btnHost";
            this.btnHost.Size = new System.Drawing.Size(142, 50);
            this.btnHost.TabIndex = 1;
            this.btnHost.Text = "HOST";
            this.btnHost.UseVisualStyleBackColor = true;
            this.btnHost.Click += new System.EventHandler(this.btnHost_Click);
            // 
            // btnJoin
            // 
            this.btnJoin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJoin.Location = new System.Drawing.Point(68, 198);
            this.btnJoin.Name = "btnJoin";
            this.btnJoin.Size = new System.Drawing.Size(142, 50);
            this.btnJoin.TabIndex = 2;
            this.btnJoin.Text = "JOIN";
            this.btnJoin.UseVisualStyleBackColor = true;
            this.btnJoin.Click += new System.EventHandler(this.btnJoin_Click);
            // 
            // btnRules
            // 
            this.btnRules.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRules.Location = new System.Drawing.Point(68, 272);
            this.btnRules.Name = "btnRules";
            this.btnRules.Size = new System.Drawing.Size(142, 50);
            this.btnRules.TabIndex = 3;
            this.btnRules.Text = "RULES";
            this.btnRules.UseVisualStyleBackColor = true;
            this.btnRules.Click += new System.EventHandler(this.btnRules_Click);
            // 
            // labelRules
            // 
            this.labelRules.AutoSize = true;
            this.labelRules.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRules.Location = new System.Drawing.Point(238, 127);
            this.labelRules.Name = "labelRules";
            this.labelRules.Size = new System.Drawing.Size(395, 275);
            this.labelRules.TabIndex = 5;
            this.labelRules.Text = resources.GetString("labelRules.Text");
            this.labelRules.Visible = false;
            // 
            // pictureBoxMenu
            // 
            this.pictureBoxMenu.Image = global::Joc_de_Carti_Final.Properties.Resources.Back;
            this.pictureBoxMenu.InitialImage = null;
            this.pictureBoxMenu.Location = new System.Drawing.Point(650, 272);
            this.pictureBoxMenu.Name = "pictureBoxMenu";
            this.pictureBoxMenu.Size = new System.Drawing.Size(125, 156);
            this.pictureBoxMenu.TabIndex = 4;
            this.pictureBoxMenu.TabStop = false;
            // 
            // pictureBoxAce
            // 
            this.pictureBoxAce.Image = global::Joc_de_Carti_Final.Properties.Resources.Aromb;
            this.pictureBoxAce.InitialImage = null;
            this.pictureBoxAce.Location = new System.Drawing.Point(534, 31);
            this.pictureBoxAce.Name = "pictureBoxAce";
            this.pictureBoxAce.Size = new System.Drawing.Size(125, 156);
            this.pictureBoxAce.TabIndex = 6;
            this.pictureBoxAce.TabStop = false;
            this.pictureBoxAce.Visible = false;
            // 
            // pictureBoxJoker
            // 
            this.pictureBoxJoker.Image = global::Joc_de_Carti_Final.Properties.Resources.Jokerrosu;
            this.pictureBoxJoker.InitialImage = null;
            this.pictureBoxJoker.Location = new System.Drawing.Point(618, 92);
            this.pictureBoxJoker.Name = "pictureBoxJoker";
            this.pictureBoxJoker.Size = new System.Drawing.Size(125, 156);
            this.pictureBoxJoker.TabIndex = 7;
            this.pictureBoxJoker.TabStop = false;
            this.pictureBoxJoker.Visible = false;
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBoxJoker);
            this.Controls.Add(this.pictureBoxAce);
            this.Controls.Add(this.labelRules);
            this.Controls.Add(this.pictureBoxMenu);
            this.Controls.Add(this.btnRules);
            this.Controls.Add(this.btnJoin);
            this.Controls.Add(this.btnHost);
            this.Controls.Add(this.MenuText);
            this.Name = "MenuForm";
            this.Text = "Macao - Menu";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAce)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxJoker)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label MenuText;
        private System.Windows.Forms.Button btnHost;
        private System.Windows.Forms.Button btnJoin;
        private System.Windows.Forms.Button btnRules;
        private System.Windows.Forms.PictureBox pictureBoxMenu;
        private System.Windows.Forms.Label labelRules;
        private System.Windows.Forms.PictureBox pictureBoxAce;
        private System.Windows.Forms.PictureBox pictureBoxJoker;
    }
}
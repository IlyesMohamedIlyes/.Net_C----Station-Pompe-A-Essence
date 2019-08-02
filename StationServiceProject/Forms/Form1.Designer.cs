namespace StationServiceProject
{
    partial class PrincipalForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrincipalForm));
            this.label_Connect = new System.Windows.Forms.Label();
            this.timer_SlidingPanel = new System.Windows.Forms.Timer(this.components);
            this.panel_SlidingPanel = new System.Windows.Forms.Panel();
            this.button_Home = new System.Windows.Forms.Button();
            this.button_pompiste = new System.Windows.Forms.Button();
            this.button_Sliding = new System.Windows.Forms.Button();
            this.button_Produits = new System.Windows.Forms.Button();
            this.button_About = new System.Windows.Forms.Button();
            this.button_Machines = new System.Windows.Forms.Button();
            this.button_Clients = new System.Windows.Forms.Button();
            this.button_Versements = new System.Windows.Forms.Button();
            this.panel_Container = new System.Windows.Forms.Panel();
            this.button_Quit = new System.Windows.Forms.Button();
            this.panel_SlidingPanel.SuspendLayout();
            this.panel_Container.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_Connect
            // 
            this.label_Connect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Connect.AutoSize = true;
            this.label_Connect.BackColor = System.Drawing.Color.Transparent;
            this.label_Connect.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Connect.ForeColor = System.Drawing.Color.Blue;
            this.label_Connect.Location = new System.Drawing.Point(1092, 9);
            this.label_Connect.Name = "label_Connect";
            this.label_Connect.Size = new System.Drawing.Size(90, 17);
            this.label_Connect.TabIndex = 7;
            this.label_Connect.Text = "se connecter";
            // 
            // timer_SlidingPanel
            // 
            this.timer_SlidingPanel.Interval = 10;
            this.timer_SlidingPanel.Tick += new System.EventHandler(this.timer_SlidingPanel_Tick);
            // 
            // panel_SlidingPanel
            // 
            this.panel_SlidingPanel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel_SlidingPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_SlidingPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_SlidingPanel.Controls.Add(this.button_Home);
            this.panel_SlidingPanel.Controls.Add(this.button_pompiste);
            this.panel_SlidingPanel.Controls.Add(this.button_Sliding);
            this.panel_SlidingPanel.Controls.Add(this.button_Produits);
            this.panel_SlidingPanel.Controls.Add(this.button_About);
            this.panel_SlidingPanel.Controls.Add(this.button_Machines);
            this.panel_SlidingPanel.Controls.Add(this.button_Clients);
            this.panel_SlidingPanel.Controls.Add(this.button_Versements);
            this.panel_SlidingPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_SlidingPanel.Location = new System.Drawing.Point(0, 0);
            this.panel_SlidingPanel.Name = "panel_SlidingPanel";
            this.panel_SlidingPanel.Size = new System.Drawing.Size(68, 601);
            this.panel_SlidingPanel.TabIndex = 8;
            // 
            // button_Home
            // 
            this.button_Home.BackColor = System.Drawing.SystemColors.Control;
            this.button_Home.FlatAppearance.BorderSize = 0;
            this.button_Home.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button_Home.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button_Home.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Home.Font = new System.Drawing.Font("Lucida Handwriting", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Home.Image = ((System.Drawing.Image)(resources.GetObject("button_Home.Image")));
            this.button_Home.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Home.Location = new System.Drawing.Point(3, 60);
            this.button_Home.Name = "button_Home";
            this.button_Home.Size = new System.Drawing.Size(62, 54);
            this.button_Home.TabIndex = 7;
            this.button_Home.UseVisualStyleBackColor = false;
            this.button_Home.Click += new System.EventHandler(this.button_Home_Click);
            // 
            // button_pompiste
            // 
            this.button_pompiste.BackColor = System.Drawing.SystemColors.Control;
            this.button_pompiste.FlatAppearance.BorderSize = 0;
            this.button_pompiste.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button_pompiste.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button_pompiste.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_pompiste.Font = new System.Drawing.Font("Lucida Handwriting", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_pompiste.Image = ((System.Drawing.Image)(resources.GetObject("button_pompiste.Image")));
            this.button_pompiste.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_pompiste.Location = new System.Drawing.Point(2, 176);
            this.button_pompiste.Name = "button_pompiste";
            this.button_pompiste.Size = new System.Drawing.Size(60, 54);
            this.button_pompiste.TabIndex = 6;
            this.button_pompiste.Text = "Pompistes";
            this.button_pompiste.UseVisualStyleBackColor = false;
            this.button_pompiste.Click += new System.EventHandler(this.button_pompiste_Click);
            // 
            // button_Sliding
            // 
            this.button_Sliding.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button_Sliding.FlatAppearance.BorderSize = 0;
            this.button_Sliding.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button_Sliding.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button_Sliding.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Sliding.Image = ((System.Drawing.Image)(resources.GetObject("button_Sliding.Image")));
            this.button_Sliding.Location = new System.Drawing.Point(0, 0);
            this.button_Sliding.Name = "button_Sliding";
            this.button_Sliding.Size = new System.Drawing.Size(68, 54);
            this.button_Sliding.TabIndex = 0;
            this.button_Sliding.UseVisualStyleBackColor = false;
            this.button_Sliding.Click += new System.EventHandler(this.button_Sliding_Click);
            // 
            // button_Produits
            // 
            this.button_Produits.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button_Produits.FlatAppearance.BorderSize = 0;
            this.button_Produits.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button_Produits.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button_Produits.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Produits.Font = new System.Drawing.Font("Lucida Handwriting", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Produits.Image = ((System.Drawing.Image)(resources.GetObject("button_Produits.Image")));
            this.button_Produits.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Produits.Location = new System.Drawing.Point(4, 236);
            this.button_Produits.Name = "button_Produits";
            this.button_Produits.Size = new System.Drawing.Size(62, 54);
            this.button_Produits.TabIndex = 1;
            this.button_Produits.Text = "Lubrifiants";
            this.button_Produits.UseVisualStyleBackColor = false;
            this.button_Produits.Click += new System.EventHandler(this.button_Produits_Click);
            // 
            // button_About
            // 
            this.button_About.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_About.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button_About.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button_About.FlatAppearance.BorderSize = 0;
            this.button_About.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button_About.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button_About.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_About.Font = new System.Drawing.Font("Lucida Handwriting", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_About.Image = ((System.Drawing.Image)(resources.GetObject("button_About.Image")));
            this.button_About.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_About.Location = new System.Drawing.Point(3, 535);
            this.button_About.Name = "button_About";
            this.button_About.Size = new System.Drawing.Size(62, 54);
            this.button_About.TabIndex = 5;
            this.button_About.Text = "A propos";
            this.button_About.UseVisualStyleBackColor = false;
            this.button_About.Click += new System.EventHandler(this.button_About_Click);
            // 
            // button_Machines
            // 
            this.button_Machines.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button_Machines.FlatAppearance.BorderSize = 0;
            this.button_Machines.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button_Machines.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button_Machines.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Machines.Font = new System.Drawing.Font("Lucida Handwriting", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Machines.Image = ((System.Drawing.Image)(resources.GetObject("button_Machines.Image")));
            this.button_Machines.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Machines.Location = new System.Drawing.Point(3, 308);
            this.button_Machines.Name = "button_Machines";
            this.button_Machines.Size = new System.Drawing.Size(62, 54);
            this.button_Machines.TabIndex = 2;
            this.button_Machines.Text = "Machines";
            this.button_Machines.UseVisualStyleBackColor = false;
            this.button_Machines.Click += new System.EventHandler(this.button_Machines_Click);
            // 
            // button_Clients
            // 
            this.button_Clients.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button_Clients.FlatAppearance.BorderSize = 0;
            this.button_Clients.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button_Clients.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button_Clients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Clients.Font = new System.Drawing.Font("Lucida Handwriting", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Clients.Image = ((System.Drawing.Image)(resources.GetObject("button_Clients.Image")));
            this.button_Clients.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Clients.Location = new System.Drawing.Point(3, 448);
            this.button_Clients.Name = "button_Clients";
            this.button_Clients.Size = new System.Drawing.Size(62, 54);
            this.button_Clients.TabIndex = 4;
            this.button_Clients.Text = "Clients";
            this.button_Clients.UseVisualStyleBackColor = false;
            this.button_Clients.Click += new System.EventHandler(this.button_Clients_Click);
            // 
            // button_Versements
            // 
            this.button_Versements.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button_Versements.FlatAppearance.BorderSize = 0;
            this.button_Versements.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button_Versements.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button_Versements.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Versements.Font = new System.Drawing.Font("Lucida Handwriting", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Versements.Image = ((System.Drawing.Image)(resources.GetObject("button_Versements.Image")));
            this.button_Versements.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Versements.Location = new System.Drawing.Point(3, 379);
            this.button_Versements.Name = "button_Versements";
            this.button_Versements.Size = new System.Drawing.Size(62, 54);
            this.button_Versements.TabIndex = 3;
            this.button_Versements.Text = "Versements";
            this.button_Versements.UseVisualStyleBackColor = false;
            this.button_Versements.Click += new System.EventHandler(this.button_Versements_Click);
            // 
            // panel_Container
            // 
            this.panel_Container.AutoScrollMargin = new System.Drawing.Size(0, 450);
            this.panel_Container.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel_Container.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel_Container.Controls.Add(this.button_Quit);
            this.panel_Container.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_Container.Location = new System.Drawing.Point(70, 0);
            this.panel_Container.Name = "panel_Container";
            this.panel_Container.Size = new System.Drawing.Size(1114, 601);
            this.panel_Container.TabIndex = 9;
            // 
            // button_Quit
            // 
            this.button_Quit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Quit.Location = new System.Drawing.Point(1034, 575);
            this.button_Quit.Name = "button_Quit";
            this.button_Quit.Size = new System.Drawing.Size(75, 23);
            this.button_Quit.TabIndex = 11;
            this.button_Quit.Text = "Quitter";
            this.button_Quit.UseVisualStyleBackColor = true;
            this.button_Quit.Click += new System.EventHandler(this.button_Quit_Click);
            // 
            // PrincipalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 601);
            this.Controls.Add(this.label_Connect);
            this.Controls.Add(this.panel_Container);
            this.Controls.Add(this.panel_SlidingPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(1200, 640);
            this.Name = "PrincipalForm";
            this.Text = "Station de Service de ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PrincipalForm_FormClosing);
            this.Load += new System.EventHandler(this.PrincipalForm_Load);
            this.panel_SlidingPanel.ResumeLayout(false);
            this.panel_Container.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Sliding;
        private System.Windows.Forms.Button button_Produits;
        private System.Windows.Forms.Button button_Machines;
        private System.Windows.Forms.Button button_Versements;
        private System.Windows.Forms.Button button_Clients;
        private System.Windows.Forms.Button button_About;
        private System.Windows.Forms.Label label_Connect;
        private System.Windows.Forms.Panel panel_SlidingPanel;
        private System.Windows.Forms.Button button_pompiste;
        private System.Windows.Forms.Timer timer_SlidingPanel;
        private System.Windows.Forms.Panel panel_Container;
        private System.Windows.Forms.Button button_Quit;
        private System.Windows.Forms.Button button_Home;
    }
}


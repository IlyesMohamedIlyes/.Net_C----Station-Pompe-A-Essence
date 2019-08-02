namespace StationServiceProject
{
    partial class userControl_Client
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(userControl_Client));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox_Search = new System.Windows.Forms.TextBox();
            this.radioButton_ParRS = new System.Windows.Forms.RadioButton();
            this.radioButton_ParNom = new System.Windows.Forms.RadioButton();
            this.panel_underscore_Search = new System.Windows.Forms.Panel();
            this.button_Search = new System.Windows.Forms.Button();
            this.textBox_NomClient = new System.Windows.Forms.TextBox();
            this.textBox_RaisonSocial = new System.Windows.Forms.TextBox();
            this.textBox_Versement = new System.Windows.Forms.TextBox();
            this.textBox_PhoneNumber = new System.Windows.Forms.TextBox();
            this.textBox_Adresse = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button_Ajouter = new System.Windows.Forms.Button();
            this.button_Clean = new System.Windows.Forms.Button();
            this.button_CancelModifications = new System.Windows.Forms.Button();
            this.button_SaveModifications = new System.Windows.Forms.Button();
            this.button_Modify = new System.Windows.Forms.Button();
            this.button_Remove = new System.Windows.Forms.Button();
            this.button_RemoveAll = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(164, 71);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(842, 280);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // textBox_Search
            // 
            this.textBox_Search.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_Search.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBox_Search.ForeColor = System.Drawing.Color.Silver;
            this.textBox_Search.Location = new System.Drawing.Point(696, 39);
            this.textBox_Search.MaxLength = 50;
            this.textBox_Search.Name = "textBox_Search";
            this.textBox_Search.Size = new System.Drawing.Size(265, 19);
            this.textBox_Search.TabIndex = 2;
            this.textBox_Search.Tag = "Rechercher par Nom";
            this.textBox_Search.Text = "Rechercher par Nom";
            this.textBox_Search.Enter += new System.EventHandler(this.textBox_Search_Enter);
            this.textBox_Search.Leave += new System.EventHandler(this.textBox_Search_Leave);
            // 
            // radioButton_ParRS
            // 
            this.radioButton_ParRS.AutoSize = true;
            this.radioButton_ParRS.Location = new System.Drawing.Point(583, 42);
            this.radioButton_ParRS.Name = "radioButton_ParRS";
            this.radioButton_ParRS.Size = new System.Drawing.Size(107, 17);
            this.radioButton_ParRS.TabIndex = 3;
            this.radioButton_ParRS.Text = "Par Raison social";
            this.radioButton_ParRS.UseVisualStyleBackColor = true;
            // 
            // radioButton_ParNom
            // 
            this.radioButton_ParNom.AutoSize = true;
            this.radioButton_ParNom.Checked = true;
            this.radioButton_ParNom.Location = new System.Drawing.Point(511, 42);
            this.radioButton_ParNom.Name = "radioButton_ParNom";
            this.radioButton_ParNom.Size = new System.Drawing.Size(66, 17);
            this.radioButton_ParNom.TabIndex = 4;
            this.radioButton_ParNom.TabStop = true;
            this.radioButton_ParNom.Text = "Par Nom";
            this.radioButton_ParNom.UseVisualStyleBackColor = true;
            this.radioButton_ParNom.CheckedChanged += new System.EventHandler(this.radioButton_ParNom_CheckedChanged);
            // 
            // panel_underscore_Search
            // 
            this.panel_underscore_Search.BackColor = System.Drawing.Color.Gray;
            this.panel_underscore_Search.Location = new System.Drawing.Point(696, 57);
            this.panel_underscore_Search.Name = "panel_underscore_Search";
            this.panel_underscore_Search.Size = new System.Drawing.Size(265, 1);
            this.panel_underscore_Search.TabIndex = 5;
            this.panel_underscore_Search.Visible = false;
            // 
            // button_Search
            // 
            this.button_Search.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_Search.FlatAppearance.BorderSize = 0;
            this.button_Search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Search.Image = ((System.Drawing.Image)(resources.GetObject("button_Search.Image")));
            this.button_Search.Location = new System.Drawing.Point(958, 30);
            this.button_Search.Name = "button_Search";
            this.button_Search.Size = new System.Drawing.Size(35, 35);
            this.button_Search.TabIndex = 1;
            this.button_Search.UseVisualStyleBackColor = false;
            this.button_Search.Click += new System.EventHandler(this.button_Search_Click);
            // 
            // textBox_NomClient
            // 
            this.textBox_NomClient.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_NomClient.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_NomClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBox_NomClient.ForeColor = System.Drawing.Color.Black;
            this.textBox_NomClient.Location = new System.Drawing.Point(309, 461);
            this.textBox_NomClient.MaxLength = 50;
            this.textBox_NomClient.Name = "textBox_NomClient";
            this.textBox_NomClient.Size = new System.Drawing.Size(236, 19);
            this.textBox_NomClient.TabIndex = 6;
            this.textBox_NomClient.Tag = "";
            // 
            // textBox_RaisonSocial
            // 
            this.textBox_RaisonSocial.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_RaisonSocial.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_RaisonSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBox_RaisonSocial.ForeColor = System.Drawing.Color.Black;
            this.textBox_RaisonSocial.Location = new System.Drawing.Point(309, 417);
            this.textBox_RaisonSocial.MaxLength = 20;
            this.textBox_RaisonSocial.Name = "textBox_RaisonSocial";
            this.textBox_RaisonSocial.Size = new System.Drawing.Size(236, 19);
            this.textBox_RaisonSocial.TabIndex = 7;
            this.textBox_RaisonSocial.Tag = "";
            // 
            // textBox_Versement
            // 
            this.textBox_Versement.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_Versement.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Versement.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBox_Versement.ForeColor = System.Drawing.Color.Black;
            this.textBox_Versement.Location = new System.Drawing.Point(399, 506);
            this.textBox_Versement.MaxLength = 50;
            this.textBox_Versement.Name = "textBox_Versement";
            this.textBox_Versement.Size = new System.Drawing.Size(291, 19);
            this.textBox_Versement.TabIndex = 8;
            this.textBox_Versement.Tag = "";
            this.textBox_Versement.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Versement_KeyPress);
            // 
            // textBox_PhoneNumber
            // 
            this.textBox_PhoneNumber.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_PhoneNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_PhoneNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBox_PhoneNumber.ForeColor = System.Drawing.Color.Black;
            this.textBox_PhoneNumber.Location = new System.Drawing.Point(719, 417);
            this.textBox_PhoneNumber.MaxLength = 14;
            this.textBox_PhoneNumber.Name = "textBox_PhoneNumber";
            this.textBox_PhoneNumber.Size = new System.Drawing.Size(201, 19);
            this.textBox_PhoneNumber.TabIndex = 9;
            this.textBox_PhoneNumber.Tag = "";
            this.textBox_PhoneNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_PhoneNumber_KeyPress);
            // 
            // textBox_Adresse
            // 
            this.textBox_Adresse.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_Adresse.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Adresse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBox_Adresse.ForeColor = System.Drawing.Color.Black;
            this.textBox_Adresse.Location = new System.Drawing.Point(728, 461);
            this.textBox_Adresse.MaxLength = 50;
            this.textBox_Adresse.Name = "textBox_Adresse";
            this.textBox_Adresse.Size = new System.Drawing.Size(265, 19);
            this.textBox_Adresse.TabIndex = 10;
            this.textBox_Adresse.Tag = "";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGreen;
            this.panel1.Location = new System.Drawing.Point(719, 438);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(201, 1);
            this.panel1.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGreen;
            this.panel2.Location = new System.Drawing.Point(728, 479);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(265, 1);
            this.panel2.TabIndex = 13;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightGreen;
            this.panel4.Location = new System.Drawing.Point(399, 524);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(291, 1);
            this.panel4.TabIndex = 13;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.LightGreen;
            this.panel5.Location = new System.Drawing.Point(309, 479);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(236, 1);
            this.panel5.TabIndex = 13;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.LightGreen;
            this.panel6.Location = new System.Drawing.Point(309, 435);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(236, 1);
            this.panel6.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label2.Location = new System.Drawing.Point(171, 414);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 22);
            this.label2.TabIndex = 15;
            this.label2.Text = "Raison social : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label1.Location = new System.Drawing.Point(171, 458);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 22);
            this.label1.TabIndex = 16;
            this.label1.Text = "Nom du client : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label3.Location = new System.Drawing.Point(171, 503);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(222, 22);
            this.label3.TabIndex = 17;
            this.label3.Text = "Versement total du client : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(564, 417);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 22);
            this.label4.TabIndex = 18;
            this.label4.Text = "N°=Tel du client :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Enabled = false;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label5.Location = new System.Drawing.Point(564, 458);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 22);
            this.label5.TabIndex = 19;
            this.label5.Text = "Adresse du client :";
            // 
            // button_Ajouter
            // 
            this.button_Ajouter.BackColor = System.Drawing.Color.PaleGreen;
            this.button_Ajouter.FlatAppearance.BorderSize = 0;
            this.button_Ajouter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Ajouter.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.button_Ajouter.Location = new System.Drawing.Point(904, 524);
            this.button_Ajouter.Name = "button_Ajouter";
            this.button_Ajouter.Size = new System.Drawing.Size(89, 38);
            this.button_Ajouter.TabIndex = 20;
            this.button_Ajouter.Text = "Ajouter";
            this.button_Ajouter.UseVisualStyleBackColor = false;
            this.button_Ajouter.Click += new System.EventHandler(this.button_Ajouter_Click);
            // 
            // button_Clean
            // 
            this.button_Clean.BackColor = System.Drawing.Color.PaleGreen;
            this.button_Clean.FlatAppearance.BorderSize = 0;
            this.button_Clean.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Clean.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.button_Clean.Location = new System.Drawing.Point(771, 528);
            this.button_Clean.Name = "button_Clean";
            this.button_Clean.Size = new System.Drawing.Size(94, 31);
            this.button_Clean.TabIndex = 21;
            this.button_Clean.Text = "Vider les champs";
            this.button_Clean.UseVisualStyleBackColor = false;
            this.button_Clean.Click += new System.EventHandler(this.button_Clean_Click);
            // 
            // button_CancelModifications
            // 
            this.button_CancelModifications.BackColor = System.Drawing.Color.PaleGreen;
            this.button_CancelModifications.FlatAppearance.BorderSize = 0;
            this.button_CancelModifications.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_CancelModifications.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold);
            this.button_CancelModifications.Location = new System.Drawing.Point(779, 531);
            this.button_CancelModifications.Name = "button_CancelModifications";
            this.button_CancelModifications.Size = new System.Drawing.Size(86, 28);
            this.button_CancelModifications.TabIndex = 22;
            this.button_CancelModifications.Text = "Annuler les modifications";
            this.button_CancelModifications.UseVisualStyleBackColor = false;
            this.button_CancelModifications.Visible = false;
            this.button_CancelModifications.Click += new System.EventHandler(this.button_CancelModifications_Click);
            // 
            // button_SaveModifications
            // 
            this.button_SaveModifications.BackColor = System.Drawing.Color.PaleGreen;
            this.button_SaveModifications.FlatAppearance.BorderSize = 0;
            this.button_SaveModifications.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_SaveModifications.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.button_SaveModifications.Location = new System.Drawing.Point(881, 524);
            this.button_SaveModifications.Name = "button_SaveModifications";
            this.button_SaveModifications.Size = new System.Drawing.Size(112, 38);
            this.button_SaveModifications.TabIndex = 23;
            this.button_SaveModifications.Text = "Enregister les modifications";
            this.button_SaveModifications.UseVisualStyleBackColor = false;
            this.button_SaveModifications.Visible = false;
            this.button_SaveModifications.Click += new System.EventHandler(this.button_SaveModifications_Click);
            // 
            // button_Modify
            // 
            this.button_Modify.BackColor = System.Drawing.Color.PaleGreen;
            this.button_Modify.FlatAppearance.BorderSize = 0;
            this.button_Modify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Modify.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.button_Modify.Location = new System.Drawing.Point(823, 357);
            this.button_Modify.Name = "button_Modify";
            this.button_Modify.Size = new System.Drawing.Size(89, 38);
            this.button_Modify.TabIndex = 24;
            this.button_Modify.Text = "Modifier";
            this.button_Modify.UseVisualStyleBackColor = false;
            this.button_Modify.Click += new System.EventHandler(this.button_Modify_Click);
            // 
            // button_Remove
            // 
            this.button_Remove.BackColor = System.Drawing.Color.PaleGreen;
            this.button_Remove.FlatAppearance.BorderSize = 0;
            this.button_Remove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Remove.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.button_Remove.Location = new System.Drawing.Point(696, 357);
            this.button_Remove.Name = "button_Remove";
            this.button_Remove.Size = new System.Drawing.Size(89, 38);
            this.button_Remove.TabIndex = 25;
            this.button_Remove.Text = "Supprimer";
            this.button_Remove.UseVisualStyleBackColor = false;
            this.button_Remove.Click += new System.EventHandler(this.button_Remove_Click);
            // 
            // button_RemoveAll
            // 
            this.button_RemoveAll.BackColor = System.Drawing.Color.PaleGreen;
            this.button_RemoveAll.FlatAppearance.BorderSize = 0;
            this.button_RemoveAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_RemoveAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.button_RemoveAll.Location = new System.Drawing.Point(184, 357);
            this.button_RemoveAll.Name = "button_RemoveAll";
            this.button_RemoveAll.Size = new System.Drawing.Size(121, 38);
            this.button_RemoveAll.TabIndex = 26;
            this.button_RemoveAll.Text = "Supprimer tout";
            this.button_RemoveAll.UseVisualStyleBackColor = false;
            this.button_RemoveAll.Click += new System.EventHandler(this.button_RemoveAll_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 23F);
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(177, 35);
            this.label6.TabIndex = 27;
            this.label6.Text = "Mes Clients";
            // 
            // userControl_Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.button_Ajouter);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button_RemoveAll);
            this.Controls.Add(this.button_Remove);
            this.Controls.Add(this.button_Modify);
            this.Controls.Add(this.button_SaveModifications);
            this.Controls.Add(this.button_CancelModifications);
            this.Controls.Add(this.button_Clean);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox_Adresse);
            this.Controls.Add(this.textBox_PhoneNumber);
            this.Controls.Add(this.textBox_Versement);
            this.Controls.Add(this.textBox_RaisonSocial);
            this.Controls.Add(this.textBox_NomClient);
            this.Controls.Add(this.panel_underscore_Search);
            this.Controls.Add(this.radioButton_ParNom);
            this.Controls.Add(this.radioButton_ParRS);
            this.Controls.Add(this.textBox_Search);
            this.Controls.Add(this.button_Search);
            this.Controls.Add(this.dataGridView1);
            this.Name = "userControl_Client";
            this.Size = new System.Drawing.Size(1009, 601);
            this.DoubleClick += new System.EventHandler(this.userControl_Client_DoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_Search;
        private System.Windows.Forms.TextBox textBox_Search;
        private System.Windows.Forms.RadioButton radioButton_ParRS;
        private System.Windows.Forms.RadioButton radioButton_ParNom;
        private System.Windows.Forms.Panel panel_underscore_Search;
        private System.Windows.Forms.TextBox textBox_NomClient;
        private System.Windows.Forms.TextBox textBox_RaisonSocial;
        private System.Windows.Forms.TextBox textBox_Versement;
        private System.Windows.Forms.TextBox textBox_PhoneNumber;
        private System.Windows.Forms.TextBox textBox_Adresse;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_Ajouter;
        private System.Windows.Forms.Button button_Clean;
        private System.Windows.Forms.Button button_CancelModifications;
        private System.Windows.Forms.Button button_SaveModifications;
        private System.Windows.Forms.Button button_Modify;
        private System.Windows.Forms.Button button_Remove;
        private System.Windows.Forms.Button button_RemoveAll;
        private System.Windows.Forms.Label label6;
    }
}

namespace StationServiceProject
{
    partial class Machine_UserControl
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
            this.components = new System.ComponentModel.Container();
            this.label6 = new System.Windows.Forms.Label();
            this.button_Essence_Passager = new System.Windows.Forms.Button();
            this.button_Essence_Chaffeur = new System.Windows.Forms.Button();
            this.button_GasoilePiste = new System.Windows.Forms.Button();
            this.button_B_SNP_1 = new System.Windows.Forms.Button();
            this.button_B_SNP_2 = new System.Windows.Forms.Button();
            this.button_B_SNP_3 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button_B_SUP_1 = new System.Windows.Forms.Button();
            this.button_B_SUP_2 = new System.Windows.Forms.Button();
            this.button_B_SUP_3 = new System.Windows.Forms.Button();
            this.button_H_SNP_1 = new System.Windows.Forms.Button();
            this.button_H_SNP_2 = new System.Windows.Forms.Button();
            this.button_H_SNP_3 = new System.Windows.Forms.Button();
            this.button_H_SUP_1 = new System.Windows.Forms.Button();
            this.button_H_SUP_2 = new System.Windows.Forms.Button();
            this.button_H_SUP_3 = new System.Windows.Forms.Button();
            this.button_M1_Chauffeur = new System.Windows.Forms.Button();
            this.button_M2_Chauffeur = new System.Windows.Forms.Button();
            this.button_M3_Chauffeur = new System.Windows.Forms.Button();
            this.button_M1_Passager = new System.Windows.Forms.Button();
            this.button_M2_Passager = new System.Windows.Forms.Button();
            this.button_M3_Passager = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_codeMachine = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button_M4_Reserve = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 23F);
            this.label6.Location = new System.Drawing.Point(3, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(215, 35);
            this.label6.TabIndex = 57;
            this.label6.Text = "Mes Machines";
            // 
            // button_Essence_Passager
            // 
            this.button_Essence_Passager.Location = new System.Drawing.Point(36, 137);
            this.button_Essence_Passager.Name = "button_Essence_Passager";
            this.button_Essence_Passager.Size = new System.Drawing.Size(182, 78);
            this.button_Essence_Passager.TabIndex = 58;
            this.button_Essence_Passager.Text = "PISTE Essence - Coté Passager";
            this.button_Essence_Passager.UseVisualStyleBackColor = true;
            this.button_Essence_Passager.Click += new System.EventHandler(this.button_Essence_Passager_Click);
            // 
            // button_Essence_Chaffeur
            // 
            this.button_Essence_Chaffeur.Location = new System.Drawing.Point(36, 250);
            this.button_Essence_Chaffeur.Name = "button_Essence_Chaffeur";
            this.button_Essence_Chaffeur.Size = new System.Drawing.Size(182, 78);
            this.button_Essence_Chaffeur.TabIndex = 59;
            this.button_Essence_Chaffeur.Text = "PISTE Essence - Coté chauffeur";
            this.button_Essence_Chaffeur.UseVisualStyleBackColor = true;
            this.button_Essence_Chaffeur.Click += new System.EventHandler(this.button_Essence_Chauffeur_Click);
            // 
            // button_GasoilePiste
            // 
            this.button_GasoilePiste.Location = new System.Drawing.Point(36, 357);
            this.button_GasoilePiste.Name = "button_GasoilePiste";
            this.button_GasoilePiste.Size = new System.Drawing.Size(182, 78);
            this.button_GasoilePiste.TabIndex = 60;
            this.button_GasoilePiste.Text = "PISTE GASOILE";
            this.button_GasoilePiste.UseVisualStyleBackColor = true;
            this.button_GasoilePiste.Click += new System.EventHandler(this.button_Gasoile_Click);
            // 
            // button_B_SNP_1
            // 
            this.button_B_SNP_1.Location = new System.Drawing.Point(101, 152);
            this.button_B_SNP_1.Name = "button_B_SNP_1";
            this.button_B_SNP_1.Size = new System.Drawing.Size(103, 48);
            this.button_B_SNP_1.TabIndex = 62;
            this.button_B_SNP_1.Text = "Machine 1 - Sans plomb";
            this.button_B_SNP_1.UseVisualStyleBackColor = true;
            this.button_B_SNP_1.Click += new System.EventHandler(this.button_Machine_Choice_Click);
            // 
            // button_B_SNP_2
            // 
            this.button_B_SNP_2.Location = new System.Drawing.Point(101, 152);
            this.button_B_SNP_2.Name = "button_B_SNP_2";
            this.button_B_SNP_2.Size = new System.Drawing.Size(103, 48);
            this.button_B_SNP_2.TabIndex = 63;
            this.button_B_SNP_2.Text = "Machine 2 - Sans plomb";
            this.button_B_SNP_2.UseVisualStyleBackColor = true;
            this.button_B_SNP_2.Click += new System.EventHandler(this.button_Machine_Choice_Click);
            // 
            // button_B_SNP_3
            // 
            this.button_B_SNP_3.Location = new System.Drawing.Point(101, 152);
            this.button_B_SNP_3.Name = "button_B_SNP_3";
            this.button_B_SNP_3.Size = new System.Drawing.Size(103, 48);
            this.button_B_SNP_3.TabIndex = 64;
            this.button_B_SNP_3.Text = "Machine 3 - Sans plomb";
            this.button_B_SNP_3.UseVisualStyleBackColor = true;
            this.button_B_SNP_3.Click += new System.EventHandler(this.button_Machine_Choice_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button_B_SUP_1
            // 
            this.button_B_SUP_1.Location = new System.Drawing.Point(101, 152);
            this.button_B_SUP_1.Name = "button_B_SUP_1";
            this.button_B_SUP_1.Size = new System.Drawing.Size(103, 48);
            this.button_B_SUP_1.TabIndex = 66;
            this.button_B_SUP_1.Text = "Machine 1 - SUPER";
            this.button_B_SUP_1.UseVisualStyleBackColor = true;
            this.button_B_SUP_1.Click += new System.EventHandler(this.button_Machine_Choice_Click);
            // 
            // button_B_SUP_2
            // 
            this.button_B_SUP_2.Location = new System.Drawing.Point(101, 152);
            this.button_B_SUP_2.Name = "button_B_SUP_2";
            this.button_B_SUP_2.Size = new System.Drawing.Size(103, 48);
            this.button_B_SUP_2.TabIndex = 67;
            this.button_B_SUP_2.Text = "Machine 2 - SUPER";
            this.button_B_SUP_2.UseVisualStyleBackColor = true;
            this.button_B_SUP_2.Click += new System.EventHandler(this.button_Machine_Choice_Click);
            // 
            // button_B_SUP_3
            // 
            this.button_B_SUP_3.Location = new System.Drawing.Point(101, 152);
            this.button_B_SUP_3.Name = "button_B_SUP_3";
            this.button_B_SUP_3.Size = new System.Drawing.Size(103, 48);
            this.button_B_SUP_3.TabIndex = 65;
            this.button_B_SUP_3.Text = "Machine 3 - SUPER";
            this.button_B_SUP_3.UseVisualStyleBackColor = true;
            this.button_B_SUP_3.Click += new System.EventHandler(this.button_Machine_Choice_Click);
            // 
            // button_H_SNP_1
            // 
            this.button_H_SNP_1.Location = new System.Drawing.Point(101, 265);
            this.button_H_SNP_1.Name = "button_H_SNP_1";
            this.button_H_SNP_1.Size = new System.Drawing.Size(103, 48);
            this.button_H_SNP_1.TabIndex = 69;
            this.button_H_SNP_1.Text = "Machine 1 - Sans plomb";
            this.button_H_SNP_1.UseVisualStyleBackColor = true;
            this.button_H_SNP_1.Click += new System.EventHandler(this.button_Machine_Choice_Click);
            // 
            // button_H_SNP_2
            // 
            this.button_H_SNP_2.Location = new System.Drawing.Point(101, 265);
            this.button_H_SNP_2.Name = "button_H_SNP_2";
            this.button_H_SNP_2.Size = new System.Drawing.Size(103, 48);
            this.button_H_SNP_2.TabIndex = 70;
            this.button_H_SNP_2.Text = "Machine 2 - Sans plomb";
            this.button_H_SNP_2.UseVisualStyleBackColor = true;
            this.button_H_SNP_2.Click += new System.EventHandler(this.button_Machine_Choice_Click);
            // 
            // button_H_SNP_3
            // 
            this.button_H_SNP_3.Location = new System.Drawing.Point(101, 265);
            this.button_H_SNP_3.Name = "button_H_SNP_3";
            this.button_H_SNP_3.Size = new System.Drawing.Size(103, 48);
            this.button_H_SNP_3.TabIndex = 68;
            this.button_H_SNP_3.Text = "Machine 3 - Sans plomb";
            this.button_H_SNP_3.UseVisualStyleBackColor = true;
            this.button_H_SNP_3.Click += new System.EventHandler(this.button_Machine_Choice_Click);
            // 
            // button_H_SUP_1
            // 
            this.button_H_SUP_1.Location = new System.Drawing.Point(101, 265);
            this.button_H_SUP_1.Name = "button_H_SUP_1";
            this.button_H_SUP_1.Size = new System.Drawing.Size(103, 48);
            this.button_H_SUP_1.TabIndex = 72;
            this.button_H_SUP_1.Text = "Machine 1 - SUPER";
            this.button_H_SUP_1.UseVisualStyleBackColor = true;
            this.button_H_SUP_1.Click += new System.EventHandler(this.button_Machine_Choice_Click);
            // 
            // button_H_SUP_2
            // 
            this.button_H_SUP_2.Location = new System.Drawing.Point(101, 265);
            this.button_H_SUP_2.Name = "button_H_SUP_2";
            this.button_H_SUP_2.Size = new System.Drawing.Size(103, 48);
            this.button_H_SUP_2.TabIndex = 73;
            this.button_H_SUP_2.Text = "Machine 2 - SUPER";
            this.button_H_SUP_2.UseVisualStyleBackColor = true;
            this.button_H_SUP_2.Click += new System.EventHandler(this.button_Machine_Choice_Click);
            // 
            // button_H_SUP_3
            // 
            this.button_H_SUP_3.Location = new System.Drawing.Point(101, 265);
            this.button_H_SUP_3.Name = "button_H_SUP_3";
            this.button_H_SUP_3.Size = new System.Drawing.Size(103, 48);
            this.button_H_SUP_3.TabIndex = 71;
            this.button_H_SUP_3.Text = "Machine 3 - SUPER";
            this.button_H_SUP_3.UseVisualStyleBackColor = true;
            this.button_H_SUP_3.Click += new System.EventHandler(this.button_Machine_Choice_Click);
            // 
            // button_M1_Chauffeur
            // 
            this.button_M1_Chauffeur.Location = new System.Drawing.Point(101, 372);
            this.button_M1_Chauffeur.Name = "button_M1_Chauffeur";
            this.button_M1_Chauffeur.Size = new System.Drawing.Size(103, 48);
            this.button_M1_Chauffeur.TabIndex = 75;
            this.button_M1_Chauffeur.Text = "Machine 1 - Coté Chaffeur";
            this.button_M1_Chauffeur.UseVisualStyleBackColor = true;
            this.button_M1_Chauffeur.Click += new System.EventHandler(this.button_Machine_Choice_Click);
            // 
            // button_M2_Chauffeur
            // 
            this.button_M2_Chauffeur.Location = new System.Drawing.Point(101, 372);
            this.button_M2_Chauffeur.Name = "button_M2_Chauffeur";
            this.button_M2_Chauffeur.Size = new System.Drawing.Size(103, 48);
            this.button_M2_Chauffeur.TabIndex = 76;
            this.button_M2_Chauffeur.Text = "Machine 2 - Coté Chauffeur";
            this.button_M2_Chauffeur.UseVisualStyleBackColor = true;
            this.button_M2_Chauffeur.Click += new System.EventHandler(this.button_Machine_Choice_Click);
            // 
            // button_M3_Chauffeur
            // 
            this.button_M3_Chauffeur.Location = new System.Drawing.Point(101, 372);
            this.button_M3_Chauffeur.Name = "button_M3_Chauffeur";
            this.button_M3_Chauffeur.Size = new System.Drawing.Size(103, 48);
            this.button_M3_Chauffeur.TabIndex = 74;
            this.button_M3_Chauffeur.Text = "Machine 3 - Coté Chauffeur";
            this.button_M3_Chauffeur.UseVisualStyleBackColor = true;
            this.button_M3_Chauffeur.Click += new System.EventHandler(this.button_Machine_Choice_Click);
            // 
            // button_M1_Passager
            // 
            this.button_M1_Passager.Location = new System.Drawing.Point(101, 372);
            this.button_M1_Passager.Name = "button_M1_Passager";
            this.button_M1_Passager.Size = new System.Drawing.Size(103, 48);
            this.button_M1_Passager.TabIndex = 78;
            this.button_M1_Passager.Text = "Machine 1 - Coté Passager";
            this.button_M1_Passager.UseVisualStyleBackColor = true;
            this.button_M1_Passager.Click += new System.EventHandler(this.button_Machine_Choice_Click);
            // 
            // button_M2_Passager
            // 
            this.button_M2_Passager.Location = new System.Drawing.Point(101, 372);
            this.button_M2_Passager.Name = "button_M2_Passager";
            this.button_M2_Passager.Size = new System.Drawing.Size(103, 48);
            this.button_M2_Passager.TabIndex = 79;
            this.button_M2_Passager.Text = "Machine 2 - Coté Passager";
            this.button_M2_Passager.UseVisualStyleBackColor = true;
            this.button_M2_Passager.Click += new System.EventHandler(this.button_Machine_Choice_Click);
            // 
            // button_M3_Passager
            // 
            this.button_M3_Passager.Location = new System.Drawing.Point(101, 372);
            this.button_M3_Passager.Name = "button_M3_Passager";
            this.button_M3_Passager.Size = new System.Drawing.Size(103, 48);
            this.button_M3_Passager.TabIndex = 77;
            this.button_M3_Passager.Text = " Machine 3 - Coté Passager";
            this.button_M3_Passager.UseVisualStyleBackColor = true;
            this.button_M3_Passager.Click += new System.EventHandler(this.button_Machine_Choice_Click);
            // 
            // timer2
            // 
            this.timer2.Interval = 1;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Interval = 1;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(620, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2, 509);
            this.panel1.TabIndex = 80;
            // 
            // label_codeMachine
            // 
            this.label_codeMachine.AutoSize = true;
            this.label_codeMachine.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_codeMachine.Location = new System.Drawing.Point(648, 78);
            this.label_codeMachine.Name = "label_codeMachine";
            this.label_codeMachine.Size = new System.Drawing.Size(264, 24);
            this.label_codeMachine.TabIndex = 81;
            this.label_codeMachine.Text = "Code Machine - Dernier Index";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(647, 122);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.Size = new System.Drawing.Size(349, 422);
            this.dataGridView1.TabIndex = 83;
            // 
            // button_M4_Reserve
            // 
            this.button_M4_Reserve.Location = new System.Drawing.Point(115, 372);
            this.button_M4_Reserve.Name = "button_M4_Reserve";
            this.button_M4_Reserve.Size = new System.Drawing.Size(103, 48);
            this.button_M4_Reserve.TabIndex = 84;
            this.button_M4_Reserve.Text = " Machine 4 - Réserve";
            this.button_M4_Reserve.UseVisualStyleBackColor = true;
            this.button_M4_Reserve.Click += new System.EventHandler(this.button_Machine_Choice_Click);
            // 
            // Machine_UserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label_codeMachine);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button_Essence_Chaffeur);
            this.Controls.Add(this.button_H_SNP_1);
            this.Controls.Add(this.button_H_SNP_2);
            this.Controls.Add(this.button_H_SNP_3);
            this.Controls.Add(this.button_H_SUP_1);
            this.Controls.Add(this.button_H_SUP_2);
            this.Controls.Add(this.button_H_SUP_3);
            this.Controls.Add(this.button_GasoilePiste);
            this.Controls.Add(this.button_Essence_Passager);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button_B_SNP_2);
            this.Controls.Add(this.button_B_SNP_3);
            this.Controls.Add(this.button_B_SNP_1);
            this.Controls.Add(this.button_B_SUP_1);
            this.Controls.Add(this.button_B_SUP_2);
            this.Controls.Add(this.button_B_SUP_3);
            this.Controls.Add(this.button_M1_Chauffeur);
            this.Controls.Add(this.button_M2_Chauffeur);
            this.Controls.Add(this.button_M3_Chauffeur);
            this.Controls.Add(this.button_M1_Passager);
            this.Controls.Add(this.button_M2_Passager);
            this.Controls.Add(this.button_M3_Passager);
            this.Controls.Add(this.button_M4_Reserve);
            this.Name = "Machine_UserControl";
            this.Size = new System.Drawing.Size(1009, 601);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_Essence_Passager;
        private System.Windows.Forms.Button button_Essence_Chaffeur;
        private System.Windows.Forms.Button button_GasoilePiste;
        private System.Windows.Forms.Button button_B_SNP_1;
        private System.Windows.Forms.Button button_B_SNP_2;
        private System.Windows.Forms.Button button_B_SNP_3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button_B_SUP_1;
        private System.Windows.Forms.Button button_B_SUP_2;
        private System.Windows.Forms.Button button_B_SUP_3;
        private System.Windows.Forms.Button button_H_SNP_1;
        private System.Windows.Forms.Button button_H_SNP_2;
        private System.Windows.Forms.Button button_H_SNP_3;
        private System.Windows.Forms.Button button_H_SUP_1;
        private System.Windows.Forms.Button button_H_SUP_2;
        private System.Windows.Forms.Button button_H_SUP_3;
        private System.Windows.Forms.Button button_M1_Chauffeur;
        private System.Windows.Forms.Button button_M2_Chauffeur;
        private System.Windows.Forms.Button button_M3_Chauffeur;
        private System.Windows.Forms.Button button_M1_Passager;
        private System.Windows.Forms.Button button_M2_Passager;
        private System.Windows.Forms.Button button_M3_Passager;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_codeMachine;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_M4_Reserve;
    }
}

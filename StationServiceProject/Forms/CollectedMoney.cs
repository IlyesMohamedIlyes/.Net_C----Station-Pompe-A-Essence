using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StationServiceProject.UserControls;

namespace StationServiceProject.Forms
{
    public partial class CollectedMoney : Form
    {
        private static CollectedMoney _instance;
        public static CollectedMoney Instance
        {
            get
            {
                return _instance;
            }
        }

        public string Billet_2000 { get; private set; }
        public string Billet_1000 { get; private set; }
        public string Billet_500 { get; private set; }
        public string Billet_200 { get; private set; }
        public string Billet_100 { get; private set; }
        public string Tac_850 { get; private set; }
        public string Tac_690 { get; private set; }
        public string Tac_20l { get; private set; }
        public string Versement { get; private set; }
        public string Monnaie { get; private set; }


        public CollectedMoney(string labelInfos)
        {
            _instance = this;
            InitializeComponent();
            label_Informations.Text = labelInfos;

            Billet_2000 = "0";
            Billet_1000 = "0";
            Billet_500 = "0";
            Billet_200 = "0";
            Billet_100 = "0";
            Tac_850 = "0";
            Tac_690 = "0";
            Tac_20l = "0";
            Versement = "0";
            Monnaie = "0";
        }

        private void textBox_money_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) ||
      (e.KeyChar == '.'))
            {
                e.Handled = true;
            }

        }


        private void textBoxes_TextChanged(object sender, EventArgs e)
        {
            int[] coef = new int[10];
            decimal somme = 0;

            if (string.IsNullOrWhiteSpace(textBox_2000.Text) && !textBox_2000.Focused)
                textBox_2000.Text = "0";
            else
            {
                if (!int.TryParse(textBox_2000.Text, out coef[0]))
                    MessageBox.Show("Vérifiez qu'il existe que des chiffres dans les 2000");
                else
                    somme += 2000 * coef[0];
            }
            if (string.IsNullOrWhiteSpace(textBox_1000.Text) && !textBox_1000.Focused)
                textBox_1000.Text = "0";
            else
            {
                if (!int.TryParse(textBox_1000.Text, out coef[1]))
                    MessageBox.Show("Vérifiez qu'il existe que des chiffres dans les 1000");
                else
                    somme += 1000 * coef[1];
            }
            if (string.IsNullOrWhiteSpace(textBox_500.Text) && !textBox_500.Focused)
                textBox_500.Text = "0";
            else
            {
                if (!int.TryParse(textBox_500.Text, out coef[2]))
                    MessageBox.Show("Vérifiez qu'il existe que des chiffres dans les 500");
                else
                    somme += 500 * coef[2];
            }
            if (string.IsNullOrWhiteSpace(textBox_200.Text) && !textBox_200.Focused)
                textBox_200.Text = "0";
            else
            {
                if (!int.TryParse(textBox_200.Text, out coef[3]))
                    MessageBox.Show("Vérifiez qu'il existe que des chiffres dans les 200");
                else
                    somme += 200 * coef[3];
            }
            if (string.IsNullOrWhiteSpace(textBox_100.Text) && !textBox_100.Focused)
                textBox_100.Text = "0";
            else
            {
                if (!int.TryParse(textBox_100.Text, out coef[4]))
                    MessageBox.Show("Vérifiez qu'il existe que des chiffres dans les 100");
                else
                    somme += 100 * coef[4];
            }
            if (string.IsNullOrWhiteSpace(textBox_850.Text) && !textBox_850.Focused)
                textBox_850.Text = "0";
            else
            {
                if (!int.TryParse(textBox_850.Text, out coef[5]))
                    MessageBox.Show("Vérifiez qu'il existe que des chiffres dans les tac de 850");
                else
                    somme += 850 * coef[5];
            }
            if (string.IsNullOrWhiteSpace(textBox_690.Text) && !textBox_690.Focused)
                textBox_690.Text = "0";
            else
            {
                if (!int.TryParse(textBox_690.Text, out coef[6]))
                    MessageBox.Show("Vérifiez qu'il existe que des chiffres dans les tac de 690");
                else
                    somme += 690 * coef[6]; 
            }
            if (string.IsNullOrWhiteSpace(textBox_20l.Text) && !textBox_20l.Focused)
                textBox_20l.Text = "0";
            else
            {
                if (!int.TryParse(textBox_20l.Text, out coef[7]))
                    MessageBox.Show("Vérifiez qu'il existe que des chiffres dans les tac de 20l");
                else
                    somme += 839.4M * coef[7];
            }
            if (string.IsNullOrWhiteSpace(textBox_Versement.Text) && !textBox_Versement.Focused)
                textBox_Versement.Text = "0";
            else
            {
                if (!int.TryParse(textBox_Versement.Text, out coef[8]))
                    MessageBox.Show("Vérifiez qu'il existe que des chiffres dans les versements");
                else
                    somme += coef[8];
            }
            if (string.IsNullOrWhiteSpace(textBox_Monnaie.Text) && !textBox_Monnaie.Focused)
                textBox_Monnaie.Text = "0";
            else
            {
                if (!int.TryParse(textBox_Monnaie.Text, out coef[9]))
                    MessageBox.Show("Vérifiez qu'il existe que des chiffres dans la monnaie");
                else
                    somme += coef[9];
            }
            
            textBox_total.Text = somme.ToString();
            
        }
        
        private void button_enregistrer_Click(object sender, EventArgs e)
        {
            Billet_2000 = textBox_2000.Text;
            Billet_1000 = textBox_1000.Text;
            Billet_500 = textBox_500.Text;
            Billet_200 = textBox_200.Text;
            Billet_100 = textBox_100.Text;
            Tac_850 = textBox_850.Text;
            Tac_690 = textBox_690.Text;
            Tac_20l = textBox_20l.Text;
            Versement = textBox_Versement.Text;
            Monnaie = textBox_Monnaie.Text;

            Acceuil_UserControl.Instance.ActualiserSommeRecoltee(textBox_total.Text);
            this.Close();
        }

        private void CollectedMoney_FormClosing(object sender, FormClosingEventArgs e)
        {
            textBox_2000.Text = Billet_2000;
            textBox_1000.Text = Billet_1000;
            textBox_500.Text = Billet_500;
            textBox_200.Text = Billet_200;
            textBox_100.Text = Billet_100;
            textBox_850.Text = Tac_850;
            textBox_690.Text = Tac_690;
            textBox_20l.Text = Tac_20l;
            textBox_Versement.Text = Versement;
            textBox_Monnaie.Text = Monnaie;
        }
    }
}

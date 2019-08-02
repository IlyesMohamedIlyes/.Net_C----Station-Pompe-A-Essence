using System;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using StationServiceProject.Scripts;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Drawing.Printing;
using StationServiceProject.Forms;


namespace StationServiceProject.UserControls
{
    public enum PisteNumberState
    {
        Piste_1,
        Piste_2,
        Piste_3,
        NONE
    }

    public partial class Acceuil_UserControl : UserControl
    {
        string _date;
        CollectedMoney formCollectedMoney = null;
        PisteNumberState _PisteChoice;
        SqlConnection _connection = DatabaseAccess.Instance.Connection;
        SqlCommand _commande;
        SqlDataAdapter _dataAdapter;
        DataSet _dataSet;
        const decimal _PrixUnitaire_SUPER = 41.97M, _PrixUnitaire_SANSPLOMB = 41.62M, _PrixUnitaire_GASOIL = 23.06M;

        int[] _lastIndexes = new int[7];

        private static Acceuil_UserControl _instance;
        public static Acceuil_UserControl Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Acceuil_UserControl();

                return _instance;
            }
        }
        public Acceuil_UserControl()
        {
            InitializeComponent();
             
            _PisteChoice = PisteNumberState.NONE;

            LoadComboBoxFromDatabase_IDPompiste();
            LoadComboBoxFromDatabase_CodeProduct();

            _date = dateTimePicker.Value.ToString("dd/MM/yyyy");
            dataGridView_ProduitsVendus.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            
        }
        private void LoadComboBoxFromDatabase_CodeProduct()
        {
            _commande = new SqlCommand("Code_Product", _connection);
            _commande.CommandType = CommandType.StoredProcedure;

            _dataAdapter = new SqlDataAdapter(_commande);
            _dataSet = new DataSet();
            _dataAdapter.Fill(_dataSet);

            _connection.Open();

            try
            {
                _commande.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR\n" + ex);
                _connection.Close();
                return;
            }

            _connection.Close();

            comboBox_ProductVendus.DataSource = _dataSet.Tables[0];
            comboBox_ProductVendus.DisplayMember = "CodeProduit";
            comboBox_ProductVendus.ValueMember = "CodeProduit";
        }
    

        private void LoadComboBoxFromDatabase_IDPompiste()
        {

            _commande = new SqlCommand("ID_Name_Pompiste", _connection);
            _commande.CommandType = CommandType.StoredProcedure;
            
            _dataAdapter = new SqlDataAdapter(_commande);
            _dataSet = new DataSet();
            _dataAdapter.Fill(_dataSet);
            

            _connection.Open();

            try
            {
                _commande.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR\n" + ex);
                _connection.Close();
                return;
            }

            _connection.Close();

            comboBox_IdPompiste.DataSource = _dataSet.Tables[0];
            comboBox_IdPompiste.DisplayMember = "PrenomPompiste";
            comboBox_IdPompiste.ValueMember = "IDPompiste";


        }

        private void comboBox_IdPompiste_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_IdPompiste.SelectedItem == null)
                return;

            int id = (int)comboBox_IdPompiste.SelectedValue;

            _commande = new SqlCommand("PompisteInformations", _connection);
            _commande.CommandType = CommandType.StoredProcedure;

            _commande.Parameters.AddWithValue("@IDPompiste", id);
            
            _dataAdapter = new SqlDataAdapter(_commande);
            _dataSet = new DataSet();
            _dataAdapter.Fill(_dataSet);

            _connection.Open();
            try
            {
                using (var reader = _commande.ExecuteReader())
                {
                    reader.Read();
                    label_NomPrenom.Text = reader.GetString(0);
                    label_DateNaiss.Text = reader.GetDateTime(1).ToString("dd/MM/yyyy");
                    textBox_NombreReleve.Text = reader.GetInt32(2).ToString();
                    textBox_Ecart.Text = reader.GetSqlMoney(3).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                _connection.Close();
            }

            _connection.Close();
        }
        
        private bool Get_QteEnStock_QtePresente(out int qtePresente, out int qteStock)
        {
            _commande = new SqlCommand("QteEnStock_Product", _connection);

            _commande.CommandType = CommandType.StoredProcedure;

            _commande.Parameters.AddWithValue("@CodeProduit", comboBox_ProductVendus.SelectedValue);

            _connection.Open();
            try
            {   
                using (var reader = _commande.ExecuteReader())
                {
                    reader.Read();
                    qteStock = reader.GetInt32(0);
                }

                _commande.CommandText = "QtePresente_Product";
                using (var reader = _commande.ExecuteReader())
                {
                    reader.Read();
                    qtePresente = reader.GetInt32(0);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                qteStock = qtePresente =-1;
                return false;
            }

            _connection.Close();
            return true;
            

        }

        private bool verifyFields_AddSoldProduct()
        {
            

            return true;
        }

        private void button_AddProduct_Click(object sender, EventArgs e)
        {
            if (comboBox_ProductVendus.SelectedItem == null)
                return;

            int quantiteVendue, quantiteStock, quantitePresente;
            if (!Get_QteEnStock_QtePresente(out quantitePresente, out quantiteStock))
                return;

            if (!int.TryParse(textBox_QuantitéVendue.Text, out quantiteVendue))
            {
                MessageBox.Show("Erreur. Veuillez vérifier la quantité de produits vendus entrés.");
                return;
            }
                if (quantiteVendue > quantitePresente)
                {
                    if (MessageBox.Show("La quantité vendue est plus gande que la quantité présenté ! " +
                        "Voulez-vous continuer ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                             MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        if (quantiteVendue > quantitePresente + quantiteStock)
                        {
                            MessageBox.Show("La quantité vendue est plus grande que la quantité présentée et stockée." +
                   " Veuillez vérifier le problème et réesseyer", "Impossible de continuer",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBox_QuantitéVendue.Text = "";
                            return;
                        }

                    }
                    else
                    {
                        Debug.WriteLine("GET OUT!");
                        return;
                    }
                }

            var length = dataGridView_ProduitsVendus.Rows.Count;
            var code = comboBox_ProductVendus.SelectedValue.ToString();
            int i = 0;
            bool exists = false;
            try
            {
                while (i < length && !exists)
                {
                    if (dataGridView_ProduitsVendus[0, i].Value.ToString() == code)
                    {
                        exists = true;
                    }

                    i++;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }

            if (exists)
            {
                MessageBox.Show("Ce produit existe déjà dans le tableau !");
                return;
            }

            dataGridView_ProduitsVendus.Rows.Add(comboBox_ProductVendus.SelectedValue, textBox_QuantitéVendue.Text);
        }

        private void button_DeleteProduct_Click(object sender, EventArgs e)
        {
            if (dataGridView_ProduitsVendus.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez selectionner un produit à supprimer.");
                return;
            }

            dataGridView_ProduitsVendus.Rows.RemoveAt(dataGridView_ProduitsVendus.SelectedRows[0].Index);

        }

        private void radioButton_Piste_3_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton_Piste_Changed();
        }

        private void radioButton_Piste_1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton_Piste_Changed();
        }
        
        private void radioButton_Piste_2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton_Piste_Changed();
        }

        private void RadioButton_Piste_Changed()
        {
            if (radioButton_Piste_3.Checked)
            {
                if (_PisteChoice == PisteNumberState.Piste_3)
                    return;

                _PisteChoice = PisteNumberState.Piste_3;
                label_Header_Right.Text = "GASOIL coté Chauffeur";
                label_Header_Left.Text = "GASOIL coté Passager";

                textBox_Reserve.Visible = true;
                label_Reserve.Visible = true;

            }
            else
            {
                label_attention_Reserve.Visible = false;
            }

            if (radioButton_Piste_2.Checked)
            {
                if (_PisteChoice == PisteNumberState.Piste_2)
                    return;

                _PisteChoice = PisteNumberState.Piste_2;


                label_Header_Right.Text = "SANS PLOMB";
                label_Header_Left.Text = "SUPER";
                textBox_Reserve.Visible = false;
                label_Reserve.Visible = false;
            }

            if (radioButton_Piste_1.Checked)
            {
                if (_PisteChoice == PisteNumberState.Piste_1)
                    return;

                _PisteChoice = PisteNumberState.Piste_1;


                label_Header_Right.Text = "SANS PLOMB";
                label_Header_Left.Text = "SUPER";
                textBox_Reserve.Visible = false;
                label_Reserve.Visible = false;
               
            }

            textBox_Right_1.Text = "";
            textBox_Right_2.Text = "";
            textBox_Right_3.Text = "";
            textBox_Left_1.Text = "";
            textBox_Left_2.Text = "";
            textBox_Left_3.Text = "";
            textBox_Reserve.Text = "";
        }

        private void button_Calculer_Click(object sender, EventArgs e)
        {
            if (!VerifyFields())
                return;

            if (comboBox_IdPompiste.SelectedItem == null)
                MessageBox.Show("Merci de sélectionner un pompiste.");

            _commande = new SqlCommand("PrixVente_Produit", _connection);
            _commande.CommandType = CommandType.StoredProcedure;
            
            decimal totalProduits = 0;
            decimal totalSUPER = 0;
            decimal totalSANSPLOMB = 0;
            decimal totalGASOIL = 0;

            button_Print.Visible = false;

            panel_Montant.Visible = true;
            panel_Montant.Enabled = true;
            panel_Releve.Enabled = false;
            button_Save.Visible = true;
            button_undo.Visible = true;
            textBox_SommeRecolte.Enabled = true;

            try
            {
                _connection.Open();
                using (var reader = _commande.ExecuteReader())
                {
                    var length = dataGridView_ProduitsVendus.Rows.Count;
                    while (reader.Read())
                    {
                        var code = reader.GetString(0);
                        for (int i = 0; i < length; i++)
                        {
                            if (dataGridView_ProduitsVendus.Rows[i].Cells[0].Value.ToString() == code)
                            {
                                var prix = reader.GetDecimal(1);
                                totalProduits += int.Parse(dataGridView_ProduitsVendus[1, i].Value.ToString())
                                        * prix;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                _connection.Close();
                return;
            }

            _connection.Close();

            // Now calculate ( (SUPER and SANSPLOMB) or GASOIL ) Fual
            
            try
            {
                if (_PisteChoice == PisteNumberState.Piste_3)
                {
                    totalGASOIL += (int.Parse(textBox_Left_1.Text) - _lastIndexes[0]) * _PrixUnitaire_GASOIL;

                    totalGASOIL += (int.Parse(textBox_Left_2.Text) - _lastIndexes[1]) * _PrixUnitaire_GASOIL;

                    totalGASOIL += (int.Parse(textBox_Left_3.Text) - _lastIndexes[2]) * _PrixUnitaire_GASOIL;

                    totalGASOIL += (int.Parse(textBox_Right_1.Text) - _lastIndexes[3]) * _PrixUnitaire_GASOIL;

                    totalGASOIL += (int.Parse(textBox_Right_2.Text) - _lastIndexes[4]) * _PrixUnitaire_GASOIL;

                    totalGASOIL += (int.Parse(textBox_Right_3.Text) - _lastIndexes[5]) * _PrixUnitaire_GASOIL;

                    totalGASOIL += (int.Parse(textBox_Reserve.Text) - _lastIndexes[6]) * _PrixUnitaire_GASOIL;
                     
                }
                else
                {
                    // Calculate SUPER
                    totalSUPER += (int.Parse(textBox_Left_1.Text) - _lastIndexes[0]) * _PrixUnitaire_SUPER;

                    totalSUPER += (int.Parse(textBox_Left_2.Text) - _lastIndexes[1]) * _PrixUnitaire_SUPER;

                    totalSUPER += (int.Parse(textBox_Left_3.Text) - _lastIndexes[2]) * _PrixUnitaire_SUPER;

                    //Calulate SANSPLOMB
                    totalSANSPLOMB += (int.Parse(textBox_Right_1.Text) - _lastIndexes[3]) * _PrixUnitaire_SANSPLOMB;

                    totalSANSPLOMB += (int.Parse(textBox_Right_2.Text) - _lastIndexes[4]) * _PrixUnitaire_SANSPLOMB;

                    totalSANSPLOMB += (int.Parse(textBox_Right_3.Text) - _lastIndexes[5]) * _PrixUnitaire_SANSPLOMB;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            textBox_MontantGASOIL.Text = totalGASOIL.ToString();
            textBox_MontantProduits.Text = totalProduits.ToString();
            textBox_MontantSANSPLOMB.Text = totalSANSPLOMB.ToString();
            textBox_MontantSUPER.Text = totalSUPER.ToString();

            var total = totalGASOIL + totalSANSPLOMB + totalSUPER + totalProduits;

            textBox_MontantTotal.Text = total.ToString();
        }

        private void button_Relever_Click(object sender, EventArgs e)
        {
            if (panel_Montant.Visible)
            {
                if (MessageBox.Show("Voulez vous effacer tout le contenu des champs de saisies et tableaux en bas ?", 
                    "Annuler tout", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;

                ViderFields();
                return;
            }

            //Get up releve panel using a timer
            
            timer1.Start();

            //
            button_Relever.Text = "REFAIRE A ZERO";
        }

        private void button_undo_Click(object sender, EventArgs e)
        {
            panel_Montant.Enabled = false;
            panel_Releve.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (panel_Releve.Location.Y <= 188)
            {
                timer1.Stop();
                return;
            }
            var p = new Point(panel_Releve.Location.X, panel_Releve.Location.Y - 3);
            panel_Releve.Location = p;
        }

        private void Acceuil_UserControl_Leave(object sender, EventArgs e)
        {
            button_Relever.Text = "RELEVER";
            panel_Releve.Location = new Point(30, 607);

            panel_Releve.Enabled = true;
            panel_Montant.Visible = false;
        }
      
        private void label_details_MouseEnter(object sender, EventArgs e)
        {
            label_details.ForeColor = Color.SkyBlue;
        }

        private void label_details_MouseLeave(object sender, EventArgs e)
        {
            label_details.ForeColor = Color.SteelBlue;
        }

        private void label_details_Click(object sender, EventArgs e)
        {
            panel_details.Visible = !panel_details.Visible;
            if (panel_details.Visible)
                label_details.Text = "<< details";
            else
                label_details.Text = "details >>";

        }

        private void ViderFields()
        {
            panel_Releve.Enabled = true;
            panel_Montant.Visible = false;

            radioButton_Piste_1.Checked = false;
            radioButton_Piste_2.Checked = false;
            radioButton_Piste_3.Checked = false;
            _PisteChoice = PisteNumberState.NONE;
           /* panel_Left.Visible = false;
            panel_Right.Visible = false;
            */

            dataGridView_ProduitsVendus.Rows.Clear();
            textBox_QuantitéVendue.Text = "";
            comboBox_ProductVendus.Text = "";

            textBox_Right_1.Text = "";
            textBox_Right_2.Text = "";
            textBox_Right_3.Text = "";
            textBox_Left_1.Text = "";
            textBox_Left_2.Text = "";
            textBox_Left_3.Text = "";
            textBox_Reserve.Text = "";
       /*     label_Left_1.Visible = false;
                
            label_Left_2.Visible = false;
            label_Left_3.Visible = false;
            label_Right_1.Visible = false;
            label_Right_2.Visible = false;
            label_Right_3.Visible = false;
            label_attention_Reserve.Visible = false;
            */
            comboBox_IdPompiste.Text = "";
            textBox_NombreReleve.Text = "";
            textBox_Ecart.Text = "";
            label_NomPrenom.Text = "Nom et Prénom";
            label_DateNaiss.Text = "__/__/____";

            formCollectedMoney = null;
        }
        
        private bool VerifyFields()
        {
            // Simplicity is better than complex

            if (radioButton_Piste_3.Checked)
            {
                if (string.IsNullOrWhiteSpace(textBox_Right_1.Text))
                {
                    MessageBox.Show("Veuillez entrer l'index de la machine 1 case GASOIL coté Chauffeur");
                    return false;
                }
                if (!Regex.IsMatch(textBox_Right_1.Text, @"^[a-zA-Z0-9]+$"))
                {
                    MessageBox.Show("Veuillez enter que des lettres et numéros dans champ de saisie de la machine 1 case GASOIL coté Chauffeur");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(textBox_Right_2.Text))
                {
                    MessageBox.Show("Veuillez entrer l'index de la machine 2 case GASOIL coté Chauffeur");
                    return false;
                }
                if (!Regex.IsMatch(textBox_Right_2.Text, @"^[a-zA-Z0-9]+$"))
                {
                    MessageBox.Show("Veuillez enter que des lettres et numéros dans champ de saisie de la machine 2 case GASOIL coté Chauffeur");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(textBox_Right_3.Text))
                {
                    MessageBox.Show("Veuillez entrer l'index de la machine 3 case GASOIL coté Chauffeur");
                    return false;
                }

                if (!Regex.IsMatch(textBox_Right_3.Text, @"^[a-zA-Z0-9]+$"))
                {
                    MessageBox.Show("Veuillez enter que des lettres et numéros dans champ de saisie de la machine 3 case GASOIL coté Chauffeur");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(textBox_Left_1.Text))
                {
                    MessageBox.Show("Veuillez entrer l'index de la machine 1 case GASOIL coté Passager");
                    return false;
                }
                if (!Regex.IsMatch(textBox_Left_1.Text, @"^[a-zA-Z0-9]+$"))
                {
                    MessageBox.Show("Veuillez enter que des lettres et numéros dans champ de saisie de la machine 1 case GASOIL coté Passager");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(textBox_Left_2.Text))

                {
                    MessageBox.Show("Veuillez entrer l'index de la machine 2 case GASOIL coté Passager");
                    return false;
                }
                if (!Regex.IsMatch(textBox_Left_2.Text, @"^[a-zA-Z0-9]+$"))
                {
                    MessageBox.Show("Veuillez enter que des lettres et numéros dans champ de saisie de la machine 2 case GASOIL coté Passager");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(textBox_Left_3.Text))
                {
                    MessageBox.Show("Veuillez entrer l'index de la machine 3 case GASOIL coté Passager");
                    return false;
                }
                if (!Regex.IsMatch(textBox_Left_3.Text, @"^[a-zA-Z0-9]+$"))
                {
                    MessageBox.Show("Veuillez enter que des lettres et numéros dans champ de saisie de la machine 3 case GASOIL coté Passager");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(textBox_Reserve.Text))
                {
                    MessageBox.Show("Veuillez entrer l'index de la machine de RESERVE");
                    return false;
                }

                if (!Regex.IsMatch(textBox_Reserve.Text, @"^[a-zA-Z0-9]+$"))
                {
                    MessageBox.Show("Veuillez enter que des lettres et numéros dans champ de saisie de la machine de RESERVE");
                    return false;
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(textBox_Right_1.Text))
                {
                    MessageBox.Show("Veuillez entrer l'index de la machine 1 case SANS PLOMB");
                    return false;
                }
                if (!Regex.IsMatch(textBox_Right_1.Text, @"^[a-zA-Z0-9]+$"))
                {
                    MessageBox.Show("Veuillez enter que des lettres et numéros dans champ de saisie de la machine 1 case SANS PLOMB");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(textBox_Right_2.Text))
                {
                    MessageBox.Show("Veuillez entrer l'index de la machine 2 case SANS PLOMB");
                    return false;
                }
                if (!Regex.IsMatch(textBox_Right_2.Text, @"^[a-zA-Z0-9]+$"))
                {
                    MessageBox.Show("Veuillez enter que des lettres et numéros dans champ de saisie de la machine 2 case SANS PLOMB");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(textBox_Right_3.Text))
                {
                    MessageBox.Show("Veuillez entrer l'index de la machine 3 case SANS PLOMB");
                    return false;
                }

                if (!Regex.IsMatch(textBox_Right_3.Text, @"^[a-zA-Z0-9]+$"))
                {
                    MessageBox.Show("Veuillez enter que des lettres et numéros dans champ de saisie de la machine 3 case SANS PLOMB");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(textBox_Left_1.Text))
                {
                    MessageBox.Show("Veuillez entrer l'index de la machine 1 case SUPER");
                    return false;
                }

                if (!Regex.IsMatch(textBox_Left_1.Text, @"^[a-zA-Z0-9]+$"))
                {
                    MessageBox.Show("Veuillez enter que des lettres et numéros dans champ de saisie de la machine 1 case SUPER");
                    return false;
                }
                if (string.IsNullOrWhiteSpace(textBox_Left_2.Text))

                {
                    MessageBox.Show("Veuillez entrer l'index de la machine 2 case SUPER");
                    return false;
                }

                if (!Regex.IsMatch(textBox_Left_2.Text, @"^[a-zA-Z0-9]+$"))
                {
                    MessageBox.Show("Veuillez enter que des lettres et numéros dans champ de saisie de la machine 2 case SUPER");
                    return false;
                }
                if (string.IsNullOrWhiteSpace(textBox_Left_3.Text))
                {
                    MessageBox.Show("Veuillez entrer l'index de la machine 3 case SUPER");
                    return false;
                }

                if (!Regex.IsMatch(textBox_Left_3.Text, @"^[a-zA-Z0-9]+$"))
                {
                    MessageBox.Show("Veuillez enter que des lettres et numéros dans champ de saisie de la machine 3 case SUPER");
                    return false;
                }
            }
            bool isIndexesErreur = false;

            if (label_Left_1.Visible)
                isIndexesErreur = true;
            if (label_Left_2.Visible)
                isIndexesErreur = true;
            if (label_Left_3.Visible)
                isIndexesErreur = true;
            if (label_Right_1.Visible)
                isIndexesErreur = true;
            if (label_Right_2.Visible)
                isIndexesErreur = true;
            if (label_Right_3.Visible)
                isIndexesErreur = true;
            if (label_attention_Reserve.Visible)
                isIndexesErreur = true;

            if (isIndexesErreur)
            {
                MessageBox.Show("ERREUR. Un ou plusieurs indexes que vous avez entré sont infèrieurs aux derniers indexes" +
                   "des machines correspondantes. Veuillez corriger les erreurs pour calculer.");

                return false;
            }
            return true;
        }

        private void textBox_Indexes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!radioButtonChecked())
            {
                e.Handled = true;
                return;
            }

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) ||
      (e.KeyChar == '.'))
            {
                e.Handled = true;
            }

        }

        private bool radioButtonChecked()
        {
            return radioButton_Piste_1.Checked || radioButton_Piste_2.Checked || radioButton_Piste_3.Checked;
        }

        private void textBox_Left_1_Enter(object sender, EventArgs e)
        {
            if (!radioButtonChecked())
            {
                MessageBox.Show("Veuillez choisir une piste.");
                return;
            }

            label_Left_1.Visible = true;
        }

        private void textBox_Left_1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_Left_1.Text))
                return;

            int index = 0;

            _commande = new SqlCommand("IndexDernier_Machine", _connection);
            _commande.CommandType = CommandType.StoredProcedure;

            if (radioButton_Piste_1.Checked)
            {
                _commande.Parameters.AddWithValue("@CodeMachine", "B_SUP_1");
            }
            else
            {
                if (radioButton_Piste_2.Checked)
                    _commande.Parameters.AddWithValue("@CodeMachine", "H_SUP_1");
                else
                {
                    if (radioButton_Piste_3.Checked)
                        _commande.Parameters.AddWithValue("@CodeMachine", "M1_Passager");
                    else
                        return;
                }
            }


            try
            {
                _connection.Open();
                using (var reader = _commande.ExecuteReader())
                {
                    reader.Read();
                    index = reader.GetInt32(0);
                    _lastIndexes[0] = index;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                _connection.Close();
                return;
            }

            _connection.Close();

            int indexEntre = 0;
            if (int.TryParse(textBox_Left_1.Text, out indexEntre))
            {
                if (indexEntre >= index)
                {
                    label_Left_1.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("Erreur. Verifier que vous avez entré que des numéros dans le champ 1 à gauche");
            }
        }

        private void textBox_Left_2_Enter(object sender, EventArgs e)
        {
            if (!radioButtonChecked())
            {
                MessageBox.Show("Veuillez choisir une piste.");
                return;
            }

            label_Left_2.Visible = true;
        }

        private void textBox_Left_2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_Left_2.Text))
                return;

            int index = 0;

            _commande = new SqlCommand("IndexDernier_Machine", _connection);
            _commande.CommandType = CommandType.StoredProcedure;

            if (radioButton_Piste_1.Checked)
            {
                _commande.Parameters.AddWithValue("@CodeMachine", "B_SUP_2");
            }
            else
            {
                if (radioButton_Piste_2.Checked)
                    _commande.Parameters.AddWithValue("@CodeMachine", "H_SUP_2");
                else
                {
                    if (radioButton_Piste_3.Checked)
                        _commande.Parameters.AddWithValue("@CodeMachine", "M2_Passager");
                    else
                        return;
                }
            }

            _connection.Open();

            try
            {
                using (var reader = _commande.ExecuteReader())
                {
                    reader.Read();
                    index = reader.GetInt32(0);
                    _lastIndexes[1] = index;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                _connection.Close();
                return;
            }

            _connection.Close();

            int indexEntre = 0;
            if (int.TryParse(textBox_Left_2.Text, out indexEntre))
            {
                if (indexEntre >= index)
                {
                    label_Left_2.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("Erreur. Verifier que vous avez entré que des numéros dans le champ 2 à gauche");
            }
        }

        private void textBox_Left_3_Enter(object sender, EventArgs e)
        {
            if (!radioButtonChecked())
            {
                MessageBox.Show("Veuillez choisir une piste.");
                return;
            }

            label_Left_3.Visible = true;
        }

        private void textBox_Left_3_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_Left_3.Text))
                return;

            int index = 0;

            _commande = new SqlCommand("IndexDernier_Machine", _connection);
            _commande.CommandType = CommandType.StoredProcedure;

            if (radioButton_Piste_1.Checked)
            {
                _commande.Parameters.AddWithValue("@CodeMachine", "B_SUP_3");
            }
            else
            {
                if (radioButton_Piste_2.Checked)
                    _commande.Parameters.AddWithValue("@CodeMachine", "H_SUP_3");
                else
                {
                    if (radioButton_Piste_3.Checked)
                        _commande.Parameters.AddWithValue("@CodeMachine", "M3_Passager");
                    else
                        return;
                }
            }

            _connection.Open();

            try
            {
                using (var reader = _commande.ExecuteReader())
                {
                    reader.Read();
                    index = reader.GetInt32(0);
                    _lastIndexes[2] = index;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                _connection.Close();
                return;
            }

            _connection.Close();

            int indexEntre = 0;
            if (int.TryParse(textBox_Left_3.Text, out indexEntre))
            {
                if (indexEntre >= index)
                {
                    label_Left_3.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("Erreur. Verifier que vous avez entré que des numéros dans le champ 3 à gauche");
            }
        }

        private void textBox_Right_1_Enter(object sender, EventArgs e)
        {
            if (!radioButtonChecked())
            {
                MessageBox.Show("Veuillez choisir une piste.");
                return;
            }

            label_Right_1.Visible = true;
        }

        private void textBox_Right_1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_Right_1.Text))
                return;

            int index = 0;

            _commande = new SqlCommand("IndexDernier_Machine", _connection);
            _commande.CommandType = CommandType.StoredProcedure;

            if (radioButton_Piste_1.Checked)
            {
                _commande.Parameters.AddWithValue("@CodeMachine", "B_SNP_1");
            }
            else
            {
                if (radioButton_Piste_2.Checked)
                    _commande.Parameters.AddWithValue("@CodeMachine", "H_SNP_1");
                else
                {
                    if (radioButton_Piste_3.Checked)
                        _commande.Parameters.AddWithValue("@CodeMachine", "M1_Chauffeur");
                    else
                        return;
                }
            }

            _connection.Open();

            try
            {
                using (var reader = _commande.ExecuteReader())
                {
                    reader.Read();
                    index = reader.GetInt32(0);
                    _lastIndexes[3] = index;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                _connection.Close();
                return;
            }

            _connection.Close();

            int indexEntre = 0;
            if (int.TryParse(textBox_Right_1.Text, out indexEntre))
            {
                if (indexEntre >= index)
                {
                    label_Right_1.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("Erreur. Verifier que vous avez entré que des numéros dans le champ 1 à droite");
            }
        }

        private void textBox_Right_2_Enter(object sender, EventArgs e)
        {
            if (!radioButtonChecked())
            {
                MessageBox.Show("Veuillez choisir une piste.");
                return;
            }

            label_Right_2.Visible = true;
        }

        private void textBox_Right_2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_Right_2.Text))
                return;

            int index = 0;

            _commande = new SqlCommand("IndexDernier_Machine", _connection);
            _commande.CommandType = CommandType.StoredProcedure;

            if (radioButton_Piste_1.Checked)
            {
                _commande.Parameters.AddWithValue("@CodeMachine", "B_SNP_2");
            }
            else
            {
                if (radioButton_Piste_2.Checked)
                    _commande.Parameters.AddWithValue("@CodeMachine", "H_SNP_2");
                else
                {
                    if (radioButton_Piste_3.Checked)
                        _commande.Parameters.AddWithValue("@CodeMachine", "M2_Chauffeur");
                    else
                        return;
                }
            }

            _connection.Open();

            try
            {
                using (var reader = _commande.ExecuteReader())
                {
                    reader.Read();
                    index = reader.GetInt32(0);
                    _lastIndexes[4] = index;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                _connection.Close();
                return;
            }

            _connection.Close();

            int indexEntre = 0;
            if (int.TryParse(textBox_Right_2.Text, out indexEntre))
            {
                if (indexEntre >= index)
                {
                    label_Right_2.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("Erreur. Verifiez que vous avez entré que des numéros dans le champ 2 à droite");
            }
        }

        private void textBox_Right_3_Enter(object sender, EventArgs e)
        {
            if (!radioButtonChecked())
            {
                MessageBox.Show("Veuillez choisir une piste.");
                return;
            }

            label_Right_3.Visible = true;
        }

        private void textBox_Right_3_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_Right_3.Text))
                return;

            int index = 0;

            _commande = new SqlCommand("IndexDernier_Machine", _connection);
            _commande.CommandType = CommandType.StoredProcedure;

            if (radioButton_Piste_1.Checked)
            {
                _commande.Parameters.AddWithValue("@CodeMachine", "B_SNP_3");
            }
            else
            {
                if (radioButton_Piste_2.Checked)
                    _commande.Parameters.AddWithValue("@CodeMachine", "H_SNP_3");
                else
                {
                    if (radioButton_Piste_3.Checked)
                        _commande.Parameters.AddWithValue("@CodeMachine", "M3_Chauffeur");
                    else
                        return;
                }
            }

            _connection.Open();

            try
            {
                using (var reader = _commande.ExecuteReader())
                {
                    reader.Read();
                    index = reader.GetInt32(0);
                    _lastIndexes[5] = index;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                _connection.Close();
                return;
            }

            _connection.Close();

            int indexEntre = 0;
            if (int.TryParse(textBox_Right_3.Text, out indexEntre))
            {
                if (indexEntre >= index)
                {
                    label_Right_3.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("Erreur. Vérifiez que vous avez entré que des numeros dans le champ 3 à droite.");
            }
        }

        private void textBox_Reserve_Enter(object sender, EventArgs e)
        {
            if (!radioButtonChecked())
            {
                MessageBox.Show("Veuillez choisir une piste.");
                return;
            }

            label_attention_Reserve.Visible = true;
        }

        private void textBox_SommeRecolte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) ||
      (e.KeyChar == '.'))
            {
                e.Handled = true;
            }
        }

        private void button_Print_MouseEnter(object sender, EventArgs e)
        {
            panel_underline_print.Visible = true;
        }

        private void button_Print_Click(object sender, EventArgs e)
        {

        }

        private void button_Print_MouseLeave(object sender, EventArgs e)
        {
            panel_underline_print.Visible = false;
        }

        private void button_Preview_MouseEnter(object sender, EventArgs e)
        {
            panel_underline_preview.Visible = true;
        }

        private void button_Preview_MouseLeave(object sender, EventArgs e)
        {
            panel_underline_preview.Visible = false;
        }
        
        private void button_Preview_Click(object sender, EventArgs e)
        { 

            printPreviewDialog1.Document = printDocument1;


            /*Produit_UserControl dis = Produit_UserControl.Instance;
            Graphics g = dis.CreateGraphics();

            
            Graphics mg = Graphics.FromImage(bmap);

            mg.CopyFromScreen(dis.Location.X, dis.Location.Y, 0, 0, dis.Size);
            */
            if (_PisteChoice == PisteNumberState.NONE)
                printPreviewDialog1.Document.DefaultPageSettings.Landscape = true;
            else
                printPreviewDialog1.Document.DefaultPageSettings.Landscape = false;
            
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var previousday = dateTimePicker.Value.AddDays(-1);
            string previousdayS = previousday.ToString("dd/MM/yyyy");

            switch(_PisteChoice)
            {
                case PisteNumberState.Piste_1:
                    PrintDocuments.Instance.PrintDocument_FeuilleJournee_SUP_SNP(e);
                    e.Graphics.DrawString(_date, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(685, 94));
                    e.Graphics.DrawString(previousdayS, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(585, 94));

                    e.Graphics.DrawString(textBox_Left_1.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(60, 230));
                    e.Graphics.DrawString(textBox_Left_2.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(60, 330));
                    e.Graphics.DrawString(textBox_Left_3.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(60, 430));
                    
                    break;

                case PisteNumberState.Piste_2:
                    PrintDocuments.Instance.PrintDocument_FeuilleJournee_SUP_SNP(e);
                    e.Graphics.DrawString(_date, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(685, 94));
                    e.Graphics.DrawString(previousdayS, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(585, 94));

                    break;

                case PisteNumberState.Piste_3:
                    PrintDocuments.Instance.PrintDocument_FeuilleJournee_Gasoil(e);

                    e.Graphics.DrawString(_date, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(710, 117));
                    e.Graphics.DrawString(previousdayS, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(605, 117));
                    
                    break;

                default: // Test, the default contain only return instruction
                    PrintDocuments.Instance.PrintDocument_FeuilleBrigade((int)comboBox_IdPompiste.SelectedValue, _date, previousdayS, e);
                    return;
                    

            }
            

        }

        private void button_EntreMoney_Click(object sender, EventArgs e)
        {
            string labelInfo = comboBox_IdPompiste.Text + " - " + _date;
            if (formCollectedMoney == null)
                formCollectedMoney = new CollectedMoney(labelInfo);
            
            formCollectedMoney.ShowDialog();
        }

        public void ActualiserSommeRecoltee(string somme)
        {
            textBox_SommeRecolte.Text = somme;
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            _date = dateTimePicker.Value.ToString("dd/MM/yyyy");
        }

        private void textBox_Reserve_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_Reserve.Text))
                return;

            int index = 0;

            _commande = new SqlCommand("IndexDernier_Machine", _connection);
            _commande.CommandType = CommandType.StoredProcedure;

            _commande.Parameters.AddWithValue("@CodeMachine", "M4_Reserve");

            _connection.Open();

            try
            {
                using (var reader = _commande.ExecuteReader())
                {
                    reader.Read();
                    index = reader.GetInt32(0);
                    _lastIndexes[6] = index;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                _connection.Close();
                return;
            }

            _connection.Close();

            int indexEntre = 0;
            if (int.TryParse(textBox_Reserve.Text, out indexEntre))
            {
                if (indexEntre >= index)
                {
                    label_attention_Reserve.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("Erreur. Verifiez que vous avez entré que des numéros dans le champ de reserve.");
            }
        }


        private void button_Save_Click(object sender, EventArgs e)
        {
            // Calculate the difference between total amount and cash got from the pompiste
            // Ask if the user want to proceed saving
            //
            // create a sql command with the insert quest in releve table already created in StoredProcedures
            // add parameters values
            // ID Pompiste from combo, Date from dateTimePicker, Code Machine from textBoxs name 
            // and actual indexes from textBoxs text
            // 
            // create a sql command with the insert quest in VenteProduit table already created in StoredProcedures
            // ID Pompiste from combo, Date from dateTimePicker, Code Produit and quantite vendu from datagridview,  
            // and reduce la quantite vendue du produit vendu
            // Modify index of each machine saved in the table Releve
            // open connection
            // 
            
            decimal sommeRecolte;
            if (!decimal.TryParse(textBox_SommeRecolte.Text, out sommeRecolte))
            {
                MessageBox.Show("Veuillez vérifier que vous avez entré que des chiffres dans le champ de la Somme récoltée" +
                    " par le pompiste.");
                return;
            }

            decimal ecart = decimal.Parse(textBox_MontantTotal.Text) - sommeRecolte;

            if (MessageBox.Show("Vous êtes sur le point de sauvegarder cette relève où l'écart entre " +
                "les deux montants est de :\t" + ecart + "DA\nEtes vous certains des informations" +
                " ajoutées ?", "SAUVEGARDER LA RELEVE", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1) == DialogResult.No)
                return;

            
            var idPomp = comboBox_IdPompiste.SelectedValue.ToString();
            var length = dataGridView_ProduitsVendus.Rows.Count;
            int qtevendu = -1;
            string codeProd = null;
            int qtestock = -1;
            int qtepresente = -1;

            // Begin with table Produit vendu
            try
            {
                _connection.Open();
                for (int i = 0; i < length; i++)
                { 
                    Debug.WriteLine("Iteration number " + i + 1);
                    codeProd = dataGridView_ProduitsVendus[0, i].Value.ToString();
                    qtevendu = int.Parse(dataGridView_ProduitsVendus[1, i].Value.ToString());

                    using (var comm = new SqlCommand("Add_Product_Vendu", _connection))
                    {
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.Parameters.AddWithValue("@IDPompiste", idPomp);
                        comm.Parameters.AddWithValue("@DateBrigade", _date);
                        comm.Parameters.AddWithValue("@CodeProduit", codeProd);
                        comm.Parameters.AddWithValue("@QteVendu", qtevendu);

                        comm.ExecuteNonQuery();
                    }

                    using (var comm = new SqlCommand("QtePresente_Product", _connection))
                    {
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.Parameters.AddWithValue("@CodeProduit", codeProd);

                        using (var reader = comm.ExecuteReader())
                        {
                            reader.Read();
                            qtepresente = reader.GetInt32(0);
                        }
                    }

                    using (var comm = new SqlCommand("QteEnStock_Product", _connection))
                    {
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.Parameters.AddWithValue("@CodeProduit", codeProd);

                        using (var reader = comm.ExecuteReader())
                        {
                            reader.Read();
                            qtestock = reader.GetInt32(0);
                        }
                    }

                    qtepresente -= qtevendu;
                    if (qtepresente < 0)
                    {
                        qtestock += qtepresente;
                        qtepresente = 0;
                    }

                    using (var comm = new SqlCommand("Modify_Product_Quantite", _connection))
                    {
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.Parameters.AddWithValue("@CodeProduit", codeProd);
                        comm.Parameters.AddWithValue("@QteStock", qtestock);
                        comm.Parameters.AddWithValue("@QtePresente", qtepresente);

                        comm.ExecuteNonQuery();
                    }
                }
                _connection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                _connection.Close();
                return;
            }

            // Now
            // add to table Releve
            // add to table ReleveAmoutMoney
            try
            {
                _connection.Open();

                using (var comm = new SqlCommand ("Add_Releve", _connection))
                {
                    comm.CommandType = CommandType.StoredProcedure;

                    // Left 1
                    comm.Parameters.AddWithValue("@IDPompiste", idPomp);
                    comm.Parameters.AddWithValue("@DateBrigade", _date);
                    comm.Parameters.AddWithValue("@IndexActuel", textBox_Left_1.Text);
                    if (radioButton_Piste_1.Checked)
                        comm.Parameters.AddWithValue("@CodeMachine", "B_SUP_1");
                    if (radioButton_Piste_2.Checked)
                        comm.Parameters.AddWithValue("@CodeMachine", "H_SUP_1");
                    if (radioButton_Piste_3.Checked)
                        comm.Parameters.AddWithValue("@CodeMachine", "M1_Passager");

                    comm.ExecuteNonQuery();

                    // Modify its last index
                    using (var cmdIndex = new SqlCommand("Modify_IndexDernier_Machine", _connection))
                    {
                        cmdIndex.CommandType = CommandType.StoredProcedure;
                        cmdIndex.Parameters.AddWithValue("@IndexDernier", textBox_Left_1.Text);
                        if (radioButton_Piste_1.Checked)
                            cmdIndex.Parameters.AddWithValue("@CodeMachine", "B_SUP_1");
                        if (radioButton_Piste_2.Checked)
                            cmdIndex.Parameters.AddWithValue("@CodeMachine", "H_SUP_1");
                        if (radioButton_Piste_3.Checked)
                            cmdIndex.Parameters.AddWithValue("@CodeMachine", "M1_Passager");
                        cmdIndex.ExecuteNonQuery();
                    }

                    comm.Parameters.Clear();

                    // Left 2
                    comm.Parameters.AddWithValue("@IDPompiste", idPomp);
                    comm.Parameters.AddWithValue("@DateBrigade", _date);
                    comm.Parameters.AddWithValue("@IndexActuel", textBox_Left_2.Text);
                    if (radioButton_Piste_1.Checked)
                        comm.Parameters.AddWithValue("@CodeMachine", "B_SUP_2");
                    if (radioButton_Piste_2.Checked)
                        comm.Parameters.AddWithValue("@CodeMachine", "H_SUP_2");
                    if (radioButton_Piste_3.Checked)
                        comm.Parameters.AddWithValue("@CodeMachine", "M2_Passager");

                    comm.ExecuteNonQuery();

                    // Modify its last index
                    using (var cmdIndex = new SqlCommand("Modify_IndexDernier_Machine", _connection))
                    {
                        cmdIndex.CommandType = CommandType.StoredProcedure;
                        cmdIndex.Parameters.AddWithValue("@IndexDernier", textBox_Left_2.Text);
                        if (radioButton_Piste_1.Checked)
                            cmdIndex.Parameters.AddWithValue("@CodeMachine", "B_SUP_2");
                        if (radioButton_Piste_2.Checked)
                            cmdIndex.Parameters.AddWithValue("@CodeMachine", "H_SUP_2");
                        if (radioButton_Piste_3.Checked)
                            cmdIndex.Parameters.AddWithValue("@CodeMachine", "M2_Passager");
                        cmdIndex.ExecuteNonQuery();
                    }

                    comm.Parameters.Clear();

                    // Left 3
                    comm.Parameters.AddWithValue("@IDPompiste", idPomp);
                    comm.Parameters.AddWithValue("@DateBrigade", _date);
                    comm.Parameters.AddWithValue("@IndexActuel", textBox_Left_3.Text);
                    if (radioButton_Piste_1.Checked)
                        comm.Parameters.AddWithValue("@CodeMachine", "B_SUP_3");
                    if (radioButton_Piste_2.Checked)
                        comm.Parameters.AddWithValue("@CodeMachine", "H_SUP_3");
                    if (radioButton_Piste_3.Checked)
                        comm.Parameters.AddWithValue("@CodeMachine", "M3_Passager");

                    comm.ExecuteNonQuery();

                    // Modify its last index
                    using (var cmdIndex = new SqlCommand("Modify_IndexDernier_Machine", _connection))
                    {
                        cmdIndex.CommandType = CommandType.StoredProcedure;
                        cmdIndex.Parameters.AddWithValue("@IndexDernier", textBox_Left_3.Text);
                        if (radioButton_Piste_1.Checked)
                            cmdIndex.Parameters.AddWithValue("@CodeMachine", "B_SUP_3");
                        if (radioButton_Piste_2.Checked)
                            cmdIndex.Parameters.AddWithValue("@CodeMachine", "H_SUP_3");
                        if (radioButton_Piste_3.Checked)
                            cmdIndex.Parameters.AddWithValue("@CodeMachine", "M3_Passager");
                        cmdIndex.ExecuteNonQuery();
                    }

                    comm.Parameters.Clear();

                    // Right 1
                    comm.Parameters.AddWithValue("@IDPompiste", idPomp);
                    comm.Parameters.AddWithValue("@DateBrigade", _date);
                    comm.Parameters.AddWithValue("@IndexActuel", textBox_Right_1.Text);
                    if (radioButton_Piste_1.Checked)
                        comm.Parameters.AddWithValue("@CodeMachine", "B_SNP_1");
                    if (radioButton_Piste_2.Checked)
                        comm.Parameters.AddWithValue("@CodeMachine", "H_SNP_1");
                    if (radioButton_Piste_3.Checked)
                        comm.Parameters.AddWithValue("@CodeMachine", "M1_Chauffeur");

                    comm.ExecuteNonQuery();

                    // Modify its last index
                    using (var cmdIndex = new SqlCommand("Modify_IndexDernier_Machine", _connection))
                    {
                        cmdIndex.CommandType = CommandType.StoredProcedure;
                        cmdIndex.Parameters.AddWithValue("@IndexDernier", textBox_Right_1.Text);
                        if (radioButton_Piste_1.Checked)
                            cmdIndex.Parameters.AddWithValue("@CodeMachine", "B_SNP_1");
                        if (radioButton_Piste_2.Checked)
                            cmdIndex.Parameters.AddWithValue("@CodeMachine", "H_SNP_1");
                        if (radioButton_Piste_3.Checked)
                            cmdIndex.Parameters.AddWithValue("@CodeMachine", "M1_Chauffeur");
                        cmdIndex.ExecuteNonQuery();
                    }

                    comm.Parameters.Clear();

                    // Right 2
                    comm.Parameters.AddWithValue("@IDPompiste", idPomp);
                    comm.Parameters.AddWithValue("@DateBrigade", _date);
                    comm.Parameters.AddWithValue("@IndexActuel", textBox_Right_2.Text);
                    if (radioButton_Piste_1.Checked)
                        comm.Parameters.AddWithValue("@CodeMachine", "B_SNP_2");
                    if (radioButton_Piste_2.Checked)
                        comm.Parameters.AddWithValue("@CodeMachine", "H_SNP_2");
                    if (radioButton_Piste_3.Checked)
                        comm.Parameters.AddWithValue("@CodeMachine", "M2_Chauffeur");

                    comm.ExecuteNonQuery();

                    // Modify its last index
                    using (var cmdIndex = new SqlCommand("Modify_IndexDernier_Machine", _connection))
                    {
                        cmdIndex.CommandType = CommandType.StoredProcedure;
                        cmdIndex.Parameters.AddWithValue("@IndexDernier", textBox_Right_2.Text);
                        if (radioButton_Piste_1.Checked)
                            cmdIndex.Parameters.AddWithValue("@CodeMachine", "B_SNP_2");
                        if (radioButton_Piste_2.Checked)
                            cmdIndex.Parameters.AddWithValue("@CodeMachine", "H_SNP_2");
                        if (radioButton_Piste_3.Checked)
                            cmdIndex.Parameters.AddWithValue("@CodeMachine", "M2_Chauffeur");
                        cmdIndex.ExecuteNonQuery();
                    }

                    comm.Parameters.Clear();

                    // Right 3
                    comm.Parameters.AddWithValue("@IDPompiste", idPomp);
                    comm.Parameters.AddWithValue("@DateBrigade", _date);
                    comm.Parameters.AddWithValue("@IndexActuel", textBox_Right_3.Text);
                    if (radioButton_Piste_1.Checked)
                        comm.Parameters.AddWithValue("@CodeMachine", "B_SNP_3");
                    if (radioButton_Piste_2.Checked)
                        comm.Parameters.AddWithValue("@CodeMachine", "H_SNP_3");
                    if (radioButton_Piste_3.Checked)
                        comm.Parameters.AddWithValue("@CodeMachine", "M3_Chauffeur");

                    comm.ExecuteNonQuery();

                    // Modify its last index
                    using (var cmdIndex = new SqlCommand("Modify_IndexDernier_Machine", _connection))
                    {
                        cmdIndex.CommandType = CommandType.StoredProcedure;
                        cmdIndex.Parameters.AddWithValue("@IndexDernier", textBox_Right_3.Text);
                        if (radioButton_Piste_1.Checked)
                            cmdIndex.Parameters.AddWithValue("@CodeMachine", "B_SNP_3");
                        if (radioButton_Piste_2.Checked)
                            cmdIndex.Parameters.AddWithValue("@CodeMachine", "H_SNP_3");
                        if (radioButton_Piste_3.Checked)
                            cmdIndex.Parameters.AddWithValue("@CodeMachine", "M3_Chauffeur");
                        cmdIndex.ExecuteNonQuery();
                    }

                    // Another one for reserve
                    if (radioButton_Piste_3.Checked)
                    {
                        comm.Parameters.Clear();

                        comm.Parameters.AddWithValue("@IDPompiste", idPomp);
                        comm.Parameters.AddWithValue("@DateBrigade", _date);
                        comm.Parameters.AddWithValue("@IndexActuel", textBox_Reserve.Text);
                        comm.Parameters.AddWithValue("@CodeMachine", "M4_Reserve");

                        comm.ExecuteNonQuery();

                        // Modify its last index
                        using (var cmdIndex = new SqlCommand("Modify_IndexDernier_Machine", _connection))
                        {
                            cmdIndex.CommandType = CommandType.StoredProcedure;
                            cmdIndex.Parameters.AddWithValue("@IndexDernier", textBox_Reserve.Text);
                            cmdIndex.Parameters.AddWithValue("@CodeMachine", "M4_Reserve");
                            cmdIndex.ExecuteNonQuery();
                        }
                    }
                }

                // Add by one pompiste nombre releve
                using (var comm = new SqlCommand("Modify_NbrReleve_Ecart_Pompiste", _connection))
                {
                    int nbrReleve = int.Parse(textBox_NombreReleve.Text) + 1;
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@IDPompiste", idPomp);
                    comm.Parameters.AddWithValue("@Ecart", ecart);

                    comm.ExecuteNonQuery();
                }

                // Add somme recoltee to table ReleveAmountMoney
                using (var comm = new SqlCommand("Add_ReleveAmountMoney", _connection))
                {
                    using (var collMon = CollectedMoney.Instance)
                    {
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.Parameters.AddWithValue("@IDPompiste", idPomp);
                        comm.Parameters.AddWithValue("@DateBrigade", _date);
                        comm.Parameters.AddWithValue("@SommeRecoltee", sommeRecolte);
                        comm.Parameters.AddWithValue("@MontantSUP", decimal.Parse(textBox_MontantSUPER.Text));
                        comm.Parameters.AddWithValue("@MontantSNP", decimal.Parse(textBox_MontantSANSPLOMB.Text));
                        comm.Parameters.AddWithValue("@MontantGasoil", decimal.Parse(textBox_MontantGASOIL.Text));
                        comm.Parameters.AddWithValue("@MontantProducts", decimal.Parse(textBox_MontantProduits.Text));
                        comm.Parameters.AddWithValue("@billet_2000", collMon.Billet_2000);
                        comm.Parameters.AddWithValue("@billet_1000 ", collMon.Billet_1000);
                        comm.Parameters.AddWithValue("@billet_500", collMon.Billet_500);
                        comm.Parameters.AddWithValue("@billet_200 ", collMon.Billet_200);
                        comm.Parameters.AddWithValue("@billet_100", collMon.Billet_100);
                        comm.Parameters.AddWithValue("@TAC_850", collMon.Tac_850);
                        comm.Parameters.AddWithValue("@TAC_690", collMon.Tac_690);
                        comm.Parameters.AddWithValue("@TAC_20L", collMon.Tac_20l);
                        comm.Parameters.AddWithValue("@Versement", collMon.Versement);
                        comm.Parameters.AddWithValue("@Monnaie", collMon.Monnaie);

                        comm.ExecuteNonQuery();
                    }
                }
                
                _connection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                _connection.Close();
                return;
            }

            MessageBox.Show("LA RELEVE A ETE AJOUTE AVEC SUCCEES.");
            button_Save.Visible = false;
            button_undo.Visible = false;
            textBox_SommeRecolte.Enabled = false;

            button_Print.Visible = true;
            button_Preview.Visible = true;

            formCollectedMoney = null;
        }
    
       
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using StationServiceProject.Scripts;
using System.Text.RegularExpressions;

namespace StationServiceProject
{
    public partial class Produit_UserControl : UserControl
    {
        private static Produit_UserControl _instance;
        public static Produit_UserControl Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Produit_UserControl();

                return _instance;
            }
        }

        public Produit_UserControl()
        {
            InitializeComponent();
            refreshProductTable();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        SqlConnection _connection = DatabaseAccess.Instance.Connection;
        SqlCommand _commande;
        SqlDataAdapter _dataAdapter;
        DataSet _dataSet;

        public void refreshProductTable()
        {
            try
            {
                _commande = new SqlCommand("RefreshProduct", _connection);
                _commande.CommandType = CommandType.StoredProcedure;

                _dataAdapter = new SqlDataAdapter(_commande);
                _dataSet = new DataSet();
                _dataAdapter.Fill(_dataSet);

                _connection.Open();
                try
                {
                    _commande.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show("INVALID\n" + e);
                    _connection.Close();
                    return;
                }
                _connection.Close();
                
                dataGridView1.DataSource = _dataSet.Tables[0];
                
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells; // Code Product
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells; // Nom Product
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Prix Achat
                dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Prix vente
                dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Qte Total
                dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Qte en stock
                dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Qte présente
            }
            catch (Exception e)
            {
                MessageBox.Show("INVALID. " + e);
                _connection.Close();
                return;
            }

        }

        private void textBox_Search_Enter(object sender, EventArgs e)
        {
            textBox_Search.Text = "";
            textBox_Search.ForeColor = Color.Black;
            panel_underscore_Search.Visible = true;
        }


        private void textBox_Search_Leave(object sender, EventArgs e)
        {
            // 
            if (textBox_Search.Text != "")
                return;

            toogleMessage();
            textBox_Search.ForeColor = Color.Silver;
            panel_underscore_Search.Visible = false;
        }

        private void toogleMessage()
        {
            // To avoid Changing content during typing
            if (radioButton_ParNom.Checked)
                textBox_Search.Text = "Rechercher par Nom";

            if (radioButton_ParCodeP.Checked)
                textBox_Search.Text = "Rechercher par Code Produit";

        }

        private void radioButton_ParNom_CheckedChanged(object sender, EventArgs e)
        {
            // Change message in search textBox to the most suitable message
            // Messages can be "Rechercher par Nom" or "Rechercher par Code Produit".
            toogleMessage();
        }

        string _cp, _nom, _pa, _pv, _qt, _qs, _qp; // Used in button_Modify_Click and button_SaveModifications_Click methods.

        private void button_Modify_Click(object sender, EventArgs e)
        {
            // Modify clients informations
            //
            // Check if an item is selected in the DataGridView
            // if no, view MessageBox asking to select an item
            // if yes, paste selected client informations in the textbox belew the DataGridView
            // Turn off visibility of Add and Clean fields buttons
            // Turn on visibility of Cancel modifications and Save modifications buttons
            // Disable Remove, Remove all and Modify buttons

            //Code 

            if (dataGridView1.SelectedRows.Count != 1) // Only one item
            {
                MessageBox.Show("Merci de selectionner un et un seul client pour modifier ses informations");
                return;
            }

            var pa = dataGridView1.SelectedRows[0].Cells[2].Value.ToString().Replace(',', '.');
            var pv = dataGridView1.SelectedRows[0].Cells[3].Value.ToString().Replace(',', '.');
            //if item selected do
            textBox_CodeProduit.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox_NomProduit.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox_PrixAchat.Text = pa;
            textBox_PrixVente.Text = pv;
            textBox_QteEnStock.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox_QtePresente.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();

            _cp = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            _nom = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            _pa = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            _pv = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            _qt = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            _qs = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            _qp = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();

            button_Ajouter.Visible = false;
            button_Clean.Visible = false;
            
            button_SaveModifications.Visible = true;
            button_CancelModifications.Visible = true;

            textBox_CodeProduit.Enabled = false;
            button_Remove.Enabled = false;
            button_RemoveAll.Enabled = false;
            button_Modify.Enabled = false;
            dataGridView1.Enabled = false;
            panel_Choice.Enabled = false;
        }

        private void button_CancelModifications_Click(object sender, EventArgs e)
        {
            // Abord client informations modifications done in the textBoxs
            //
            // Clean all fields
            // Turn on visibility of Add and Clean fields buttons
            // Turn off visibility of Cancel modifications and Save modifications buttons
            // Enable Remove, Remove all and Modify buttons

            cleanFields();

            button_Ajouter.Visible = true;
            button_Clean.Visible = true;

            button_SaveModifications.Visible = false;
            button_CancelModifications.Visible = false;
            
            textBox_CodeProduit.Enabled = true;
            button_Remove.Enabled = true;
            button_RemoveAll.Enabled = true;
            button_Modify.Enabled = true;
            dataGridView1.Enabled = true;
            panel_Choice.Enabled = true;
        }

        private void button_SaveModifications_Click(object sender, EventArgs e)
        {
            // Save client informations modifications in Database
            // 
            // Show messageBox confirming if the data has been successfuly modified
            // Clean all fields
            // Turn on visibility of Add and Clean fields buttons
            // Turn off visibility of Cancel modifications and Save modifications buttons
            // Enable Remove, Remove all and Modify buttons
            
            string message = "Vous êtes sur le point de modifier le produit\n ? " +
                "Les modifications apportés sont :\n\n"
            ;
            if (MessageBox.Show(message, "Modification du produit",
       MessageBoxButtons.YesNo, MessageBoxIcon.Question,
       MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;

            _commande = new SqlCommand("Modify_Product", _connection);
            _commande.CommandType = CommandType.StoredProcedure;
            
            _commande.Parameters.AddWithValue("@CodeProduit", textBox_CodeProduit.Text);
            _commande.Parameters.AddWithValue("@NomProduit", textBox_NomProduit.Text);
            _commande.Parameters.AddWithValue("@PrixAchat", textBox_PrixAchat.Text);
            _commande.Parameters.AddWithValue("@PrixVente", textBox_PrixVente.Text);
            _commande.Parameters.AddWithValue("@QteTotal", int.Parse(textBox_QtePresente.Text) + int.Parse(textBox_QteEnStock.Text));
            _commande.Parameters.AddWithValue("@QteEnStock", textBox_QteEnStock.Text);
            _commande.Parameters.AddWithValue("@QtePresente", textBox_QtePresente.Text);

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

            MessageBox.Show("Modifications enregistrées.");

            button_Ajouter.Visible = true;
            button_Clean.Visible = true;
            
            button_SaveModifications.Visible = false;
            button_CancelModifications.Visible = false;

            textBox_CodeProduit.Enabled = true;
            button_Remove.Enabled = true;
            button_RemoveAll.Enabled = true;
            button_Modify.Enabled = true;
            dataGridView1.Enabled = true;
            panel_Choice.Enabled = true;

            cleanFields();
            refreshProductTable();
        }

        private void cleanFields()
        {
            textBox_CodeProduit.Text = "";
            textBox_NomProduit.Text = "";
            textBox_PrixAchat.Text = "";
            textBox_PrixVente.Text = "";
            textBox_QteEnStock.Text = "";
            textBox_QtePresente.Text = "";

            toogleMessage();
        }

        private bool verifyFields()
        { 
            textBox_CodeProduit.Text = textBox_CodeProduit.Text.ToUpper();
            if (string.IsNullOrWhiteSpace(textBox_CodeProduit.Text))
            {
                MessageBox.Show("Veuillez entrer un code au produit");
                return false;
            }

            if (!Regex.IsMatch(textBox_CodeProduit.Text, @"^[a-zA-Z0-9]+$"))
            {
                MessageBox.Show("Veuillez enter que des lettres et numéros dans le code du produit");
                return false;
            }
            
            var rs = Regex.Replace(textBox_NomProduit.Text, @"\s+", "");
            if (string.IsNullOrWhiteSpace(rs))
            {
                MessageBox.Show("Veuillez entrer un nom au produit");
                return false;
            }

            if (!Regex.IsMatch(textBox_NomProduit.Text, @"^[a-zA-Z0-9 ]+$"))
            {
                MessageBox.Show("Veuillez enter que des lettres et numéros dans le nom du produit");
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBox_PrixVente.Text))
            {
                MessageBox.Show("Veuillez entrer le prix de vente du produit");
                return false;
            }

            if (!Regex.IsMatch(textBox_PrixVente.Text, @"^[0-9.]+$"))
            {
                MessageBox.Show("Veuillez entrer que des numeros dans le prix de vente du produit");
                return false;
            }

            if (!string.IsNullOrWhiteSpace(textBox_PrixAchat.Text))
            {
                if (!Regex.IsMatch(textBox_PrixVente.Text, @"^[0-9.]+$"))
                {
                    MessageBox.Show("Veuillez entrer que des numeros dans le prix de vente du produit");
                    return false;
                }
            }
            
            if (!Regex.IsMatch(textBox_QteEnStock.Text, @"^[0-9]+$"))
            {
                MessageBox.Show("Veuillez entrer que des numeros dans la quantite en stock du produit");
                return false;
            }

            if (!Regex.IsMatch(textBox_QtePresente.Text, @"^[0-9]+$"))
            {
                MessageBox.Show("Veuillez entrer que des numeros dans la quantite présentée du produit");
                return false;
            }

            return true;
        }

        private void button_Ajouter_Click(object sender, EventArgs e)
        {
            // Add items to produit table on the database
            
            // Verify if textBoxs of other are valid in type if they were entered
            // Add to database

            if (!verifyFields())
                return;

            // Save in database
            _commande = new SqlCommand("Add_Product", _connection);
            _commande.CommandType = CommandType.StoredProcedure;
            int qt;
            if (textBox_QtePresente.Text == "")
            {
                qt = 0;
            }
            else
            {
                qt = int.Parse(textBox_QtePresente.Text);
            }
            if (textBox_QteEnStock.Text == "")
            {
                qt += 0;
            }
            else
            {
                qt += int.Parse(textBox_QteEnStock.Text);
            }
            
            _commande.Parameters.AddWithValue("@CodeProduit", textBox_CodeProduit.Text);
            _commande.Parameters.AddWithValue("@NomProduit", textBox_NomProduit.Text);
            _commande.Parameters.AddWithValue("@PrixAchat", textBox_PrixAchat.Text);
            _commande.Parameters.AddWithValue("@PrixVente", textBox_PrixVente.Text);
            _commande.Parameters.AddWithValue("@QteTotal", qt.ToString());
            _commande.Parameters.AddWithValue("@QteEnStock", textBox_QteEnStock.Text);
            _commande.Parameters.AddWithValue("@QtePresente", textBox_QtePresente.Text);

            _connection.Open();
            try
            {
                _commande.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("               <<<<<CANNOT SAVE IN DATA BASE>>>>>               \n" + ex);
                _connection.Close();

                return;
            }
            _connection.Close();

            MessageBox.Show("Produit ajouté avec succées.");
            refreshProductTable();
            cleanFields();
        }


        private bool RemoveAllProducts()
        {
            _commande = new SqlCommand("RemoveAll_Product", _connection);
            _commande.CommandType = CommandType.StoredProcedure;

            _connection.Open();
            try
            {
                _commande.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("NOT DONE\n" + ex);
                _connection.Close();

                return false;
            }
            _connection.Close();

            refreshProductTable();

            return true;


        }

        private void button_RemoveAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voulez-vous vraiment Supprimer tout les clients ?", "Supprimer tout les clients",
       MessageBoxButtons.YesNo, MessageBoxIcon.Question,
       MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (MessageBox.Show("Attention vous êtes sur le point de Supprimer tout les clients, Cette action " +
                    "est irréversible, Voulez-vous continuer ?", "Supprimer tout les clients",
       MessageBoxButtons.YesNo, MessageBoxIcon.Question,
       MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (MessageBox.Show("Supprimer tout les clients, Continuer ?", "Supprimer tout les clients",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        RemoveAllProducts();
                    }
                }
            }
        }

        private void button_Remove_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Merci de selectionner un ou plusieurs produits à supprimer.");
                return;
            }

            string message = "Voulez-vous vraiment Supprimer le produit ? :\n";
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                message += string.Format("- Code Produit: {0}\n", dataGridView1.SelectedRows[i].Cells[0].Value);
            }
            if (MessageBox.Show(message, "Suppression du produit",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                _commande = new SqlCommand("Remove_Product", _connection);
                _commande.CommandType = CommandType.StoredProcedure;

                 _connection.Open();
                try
                {
                    _commande.Parameters.AddWithValue("@key", dataGridView1.SelectedRows[0].Cells[0].Value);
                    _commande.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("SUPPRESSION ERRONEE.\n" + ex);

                   _connection.Close();
                   return;
                }
                _connection.Close();
              
                MessageBox.Show("La suppression du produit s'est effectuée avec succées.");
                refreshProductTable();
            }
        }

        
        private void button_Clean_Click(object sender, EventArgs e)
        {
            cleanFields(); 
        }
        
        private void radioButton_AjoutQuantite_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton_AjoutQuantite.Checked)
            {
                if (dataGridView1.SelectedRows.Count != 1)
                {
                    radioButton_AjoutQuantite.Checked = false;
                    radioButton_AjoutProduit.Checked = true;
                    MessageBox.Show("Merci de selectionner un et un seul produit pour modifier sa quantité.");

                    return;
                }

                panel_AjoutQuantite.BringToFront();
                button_Modify.Enabled = false;
                button_Remove.Enabled = false;
                button_RemoveAll.Enabled = false;

                label_ProductInformations.Text = string.Format("{0} - {1}",
                    dataGridView1.SelectedRows[0].Cells[0].Value.ToString(),
                    dataGridView1.SelectedRows[0].Cells[1].Value.ToString()
                    );
                textBox_Presente.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                textBox_Stock.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            }
            else
            {
                panel_AjoutProduit.BringToFront();
                button_Modify.Enabled = true;
                button_Remove.Enabled = true;
                button_RemoveAll.Enabled = true;
            }
        }

        
        private void button_Down_presente_Click(object sender, EventArgs e)
        {
            try
            {
                int number = int.Parse(textBox_Presente.Text);
                number--;
                textBox_Presente.Text = number.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR IN CONVERTING\n" + ex);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;

            if (radioButton_AjoutQuantite.Checked)
            {
                label_ProductInformations.Text = string.Format("{0} - {1}",
                    dataGridView1.SelectedRows[0].Cells[0].Value.ToString(),
                    dataGridView1.SelectedRows[0].Cells[1].Value.ToString()
                    );
                textBox_Presente.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                textBox_Stock.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            }
        }

        private void button_Up_stock_Click(object sender, EventArgs e)
        {
            try
            {
                int number = int.Parse(textBox_Stock.Text);
                number++;
                textBox_Stock.Text = number.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR IN CONVERTING\n" + ex);
            }
        }


        private void button_Up_presente_Click(object sender, EventArgs e)
        {
            try
            {
                int number = int.Parse(textBox_Presente.Text);
                number++;
                textBox_Presente.Text = number.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR IN CONVERTING\n" + ex);
            }
        }


        private void button_Down_stock_Click(object sender, EventArgs e)
        {
            try
            {
                int number = int.Parse(textBox_Stock.Text);
                number--;
                textBox_Stock.Text = number.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR IN CONVERTING\n" + ex);
            }
        }

        private void textBox_QteEnStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) ||
       (e.KeyChar == '.'))
            {
                e.Handled = true;
            }
        }

        private void textBox_QtePresente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) ||
       (e.KeyChar == '.'))
            {
                e.Handled = true;
            }
            
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            //CP_Search_Product
            //name_Search_Product
            var text = Regex.Replace(textBox_Search.Text, @"\s+", "");
            if (string.IsNullOrWhiteSpace(textBox_Search.Text))
            {
                refreshProductTable();
                return;
            }
            bool notTyping = textBox_Search.Text == "Rechercher par Nom" || textBox_Search.Text == "Rechercher par Code Produit";

            if (notTyping)
                return;

            try
            {
                if (radioButton_ParNom.Checked)
                {
                    // Search by Nom
                    _commande = new SqlCommand("name_Search_Product", _connection);
                    _commande.Parameters.AddWithValue("@name", textBox_Search.Text);
                }
                else
                {// radioButton_ParCP is checked

                    // Search by Code Produit
                    _commande = new SqlCommand("CP_Search_Product", _connection);
                    _commande.Parameters.AddWithValue("@CodeProduit", textBox_Search.Text);
                }

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
                    MessageBox.Show("INVALID\n" + ex);
                    _connection.Close();
                    return;
                }
                _connection.Close();

                dataGridView1.DataSource = _dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("INVALID. " + ex);
                _connection.Close();
                return;
            }

        }

        private void Produit_UserControl_DoubleClick(object sender, EventArgs e)
        {
            if (textBox_Search.Text == "" || string.IsNullOrWhiteSpace(textBox_Search.Text))
                refreshProductTable();
        }

        // This is in the second panel -  modify quantite panel  - 
        private void button_saveQuantite_Click(object sender, EventArgs e)
        {
            _commande = new SqlCommand("Modify_Product_Quantite", _connection);
            _commande.CommandType = CommandType.StoredProcedure;
            string codeProduit = label_ProductInformations.Text.Split(" - ".ToCharArray())[0];
            
            _commande.Parameters.AddWithValue("@CodeProduit", codeProduit);
            _commande.Parameters.AddWithValue("@QteStock", textBox_Stock.Text);
            _commande.Parameters.AddWithValue("@QtePresente", textBox_Presente.Text);
            

            _connection.Open();
            try
            {
                _commande.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show("\tERROR\n" + ex);
                _connection.Close();
                return;
            }
            _connection.Close();
            refreshProductTable();
            MessageBox.Show("Les quantités ont été mises à jour avec succées.");
        }

        private void textBox_NomProduit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !Regex.IsMatch(e.KeyChar.ToString(), @"^[a-zA-Z0-9 ]+$"))
                e.Handled = true;
        }

        private void textBox_CodeProduit_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = e.KeyChar.ToString().ToUpper()[0];
            if (!char.IsControl(e.KeyChar) && !Regex.IsMatch(e.KeyChar.ToString(), @"^[a-zA-Z0-9]+$"))
                e.Handled = true;
        }
        
        private void textBox_PrixAchat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        private void textBox_PrixVente_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
           (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }

                // only allow one decimal point
                if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                {
                    e.Handled = true;
                }
        }

        private void textBox_Stock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) ||
       (e.KeyChar == '.'))
            {
                e.Handled = true;
            }
        }

        private void textBox_Presente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) ||
       (e.KeyChar == '.'))
            {
                e.Handled = true;
            }
        }

    }
}

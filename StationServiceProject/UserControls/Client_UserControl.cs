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
using System.Text.RegularExpressions;
using StationServiceProject.Scripts;

namespace StationServiceProject
{
    public partial class userControl_Client : UserControl
    {
        private static userControl_Client _instance;
        public static userControl_Client Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new userControl_Client();

                return _instance;
            }
        }

        public userControl_Client()
        {
            InitializeComponent();
            refreshClientTable();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // DataGridView code starts from here

        SqlConnection _connection = DatabaseAccess.Instance.Connection;
        SqlCommand _commande;
        SqlDataReader _reader;
        SqlDataAdapter _dataAdapter;
        DataSet _dataSet;

        public void refreshClientTable()
        {
            try
            {
                _commande = new SqlCommand("RefreshClient", _connection);
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
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells; // ID
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells; // Nom
                dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells; // Versement
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Raison social
                dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Adresse
                
            }
            catch(Exception e)
            {
                MessageBox.Show("INVALID. " + e);
                _connection.Close();
                return;
            }

        }

       
        // Buttons mechanics code starts from here

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
            
            if (radioButton_ParRS.Checked)
                textBox_Search.Text = "Rechercher par Raison social";
        }

        private void radioButton_ParNom_CheckedChanged(object sender, EventArgs e)
        {
            // Change message in search textBox to the most suitable message
            // Messages can be "Rechercher par Nom" or "Rechercher par Raison social".
            toogleMessage();
        }


        string _id, _adr, _nom, _pn, _rs, _vs; // Used in button_Modify_Click and button_SaveModifications_Click methods.

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

            //if item selected do
            textBox_Adresse.Text = (string)dataGridView1.SelectedRows[0].Cells[3].Value;
            textBox_NomClient.Text = (string)dataGridView1.SelectedRows[0].Cells[2].Value;
            textBox_PhoneNumber.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox_RaisonSocial.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            var v = dataGridView1.SelectedRows[0].Cells[4].Value.ToString().Replace(',', '.');
            textBox_Versement.Text = v;

            _adr = (string)dataGridView1.SelectedRows[0].Cells[3].Value;
            _nom = (string)dataGridView1.SelectedRows[0].Cells[2].Value;
            _pn = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            _rs = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            _vs = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            _id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();


            button_Ajouter.Visible = false;
            button_Clean.Visible = false;

            button_SaveModifications.Visible = true;
            button_CancelModifications.Visible = true;

            button_Remove.Enabled = false;
            button_RemoveAll.Enabled = false;
            button_Modify.Enabled = false;
            dataGridView1.Enabled = false;

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

            button_Remove.Enabled = true;
            button_RemoveAll.Enabled = true;
            button_Modify.Enabled = true;
            dataGridView1.Enabled = true;
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

            //textBox_Adresse.Text == _adr ? "" : string.Format("- Adresse : De {0} _à_ {1}\n", _adr, textBox_Adresse.Text) +
            //textBox_NomClient.Text == _nom ? "" : string.Format("- Nom : De {0} _à_ {1}\n", _nom, textBox_NomClient.Text) +
            //textBox_PhoneNumber.Text == _pn ? "" : string.Format("- N Tel : De {0} _à_ {1}\n", _pn, textBox_PhoneNumber.Text) +
            //textBox_RaisonSocial.Text == _rs ? "" : string.Format("- Raison social : De {0} _à_ {1}\n", _rs, textBox_RaisonSocial.Text) +
            //textBox_Versement.Text == _vs ? "" : string.Format("- Versement : De {0} _à_ {1}\n", _vs, textBox_Versement.Text)

            string message = "Vous êtes sur le point de modifier le client\n ? " +
                "Les modifications apportés sont :\n\n"
            ;
            if (MessageBox.Show(message, "Modification du client",
       MessageBoxButtons.YesNo, MessageBoxIcon.Question,
       MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;

            if (!verifyFields())
                return;

            _commande = new SqlCommand("Modify_Client", _connection);
            _commande.CommandType = CommandType.StoredProcedure;
             
            _commande.Parameters.AddWithValue("@IDClient", _id);
            _commande.Parameters.AddWithValue("@RaisonSocial", textBox_RaisonSocial.Text);
            _commande.Parameters.AddWithValue("@NomClient", textBox_NomClient.Text);
            _commande.Parameters.AddWithValue("@AdresseClient", textBox_Adresse.Text);
            _commande.Parameters.AddWithValue("@TotalVersement", textBox_Versement.Text);
            _commande.Parameters.AddWithValue("@NumTelClient", textBox_PhoneNumber.Text);

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

            button_Remove.Enabled = true;
            button_RemoveAll.Enabled = true;
            button_Modify.Enabled = true;
            dataGridView1.Enabled = true;

            cleanFields();
            refreshClientTable();
        }

        private void textBox_PhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
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

        private void button_Ajouter_Click(object sender, EventArgs e)
        {
            // Add items to client table on the database

            // Verify if "raisonSocial" and "nom" of the client are entered
            // Verify if textBoxs of other are valid in type if they were entered
            // Add to database

            if (!verifyFields())
                return;

            // Save in database
            _commande = new SqlCommand("Add_Client", _connection);
            _commande.CommandType = CommandType.StoredProcedure;
           
            _commande.Parameters.AddWithValue("@RaisonSocial", textBox_RaisonSocial.Text);
            _commande.Parameters.AddWithValue("@NomClient", textBox_NomClient.Text);
            _commande.Parameters.AddWithValue("@AdresseClient", textBox_Adresse.Text);
            _commande.Parameters.AddWithValue("@TotalVersement", textBox_Versement.Text);
            _commande.Parameters.AddWithValue("@NumTelClient", textBox_PhoneNumber.Text);

            _connection.Open();
            try
            {
                _commande.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show("               <<<<<CANNOT SAVE IN DATA BASE>>>>>               \n" + ex);
                _connection.Close();

                return;
            }
            _connection.Close();

            MessageBox.Show("Client ajouté avec succées");
            refreshClientTable();
            cleanFields();
        }

        private void cleanFields()
        {
            textBox_Adresse.Text = "";
            textBox_NomClient.Text = "";
            textBox_PhoneNumber.Text = "";
            textBox_RaisonSocial.Text = "";
            textBox_Versement.Text = "";
            textBox_Search.Text = "";
            toogleMessage();
        }

        private bool verifyFields()
        {
            textBox_NomClient.Text = Regex.Replace(textBox_NomClient.Text, @"\s+", "");
            if (textBox_NomClient.Text == "")
            {
                MessageBox.Show("Veuillez entrer un nom au client");
                return false;
            }

            var rs = Regex.Replace(textBox_RaisonSocial.Text, @"\s+", "");
            if (rs == "")
            {
                MessageBox.Show("Veuillez entrer une raison social au client");
                return false;
            }

            textBox_PhoneNumber.Text = Regex.Replace(textBox_PhoneNumber.Text, @"\s+", "");
            if (textBox_PhoneNumber.Text != "")
            {
                if (!IsNumbersOnly(textBox_PhoneNumber.Text))
                {
                    MessageBox.Show("Veuillez entrer que des numeros dans le numero de telephone du Client");
                    return false;
                }
            }

            textBox_Versement.Text = Regex.Replace(textBox_Versement.Text, @"\s+", "");
            if (textBox_Versement.Text != "")
            {
                if (!IsNumbersOnly(textBox_Versement.Text))
                {
                    MessageBox.Show("Veuillez entrer que des numeros le versement total du Client");
                    return false;
                }
            }

            return true;
        }

        private bool IsNumbersOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        private void button_Clean_Click(object sender, EventArgs e)
        {
            cleanFields();
        }

        private void userControl_Client_DoubleClick(object sender, EventArgs e)
        {
            if (textBox_Search.Text == "" || string.IsNullOrWhiteSpace(textBox_Search.Text))
                refreshClientTable();
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            var text = Regex.Replace(textBox_Search.Text, @"\s+", "");
            if (text == "")
                return;

            bool notTyping = textBox_Search.Text == "Rechercher par Nom" || textBox_Search.Text == "Rechercher par Raison social";

            if (notTyping)
                return;

            try
            {
                if (radioButton_ParNom.Checked)
                {
                    // Search by Nom
                    _commande = new SqlCommand("name_Search_Client", _connection);
                    _commande.Parameters.AddWithValue("@NomClient", textBox_Search.Text);
                }
                else
                {// radioButton_ParRS is checked
                    
                    // Search by RaisonSocial
                    _commande = new SqlCommand("RS_Search_Client", _connection);
                    _commande.Parameters.AddWithValue("@RaisonSocial", textBox_Search.Text);
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
        
        private bool RemoveAllClients()
        {
            _commande = new SqlCommand("RemoveAll_Client", _connection);
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

            refreshClientTable();

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
                        RemoveAllClients();
                    }
                }
            }
        }

        private void button_Remove_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Merci de selectionner un et un seul client à supprimer.");
                return;
            }

            string message = "Voulez-vous vraiment Supprimer le client ? :\n";
            message += string.Format("- Nom: {0}, Versement: {1}.\n", dataGridView1.SelectedRows[0].Cells[2].Value,
                    dataGridView1.SelectedRows[0].Cells[4].Value);

            if (MessageBox.Show(message, "Suppression du client",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                _commande = new SqlCommand("Remove_Client", _connection);
                _commande.CommandType = CommandType.StoredProcedure;

                _connection.Open();
                try
                {
                    _commande.Parameters.AddWithValue("@key",(int)dataGridView1.SelectedRows[0].Cells[0].Value);
                    _commande.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("SUPPRESSION ERRONEE.\n" + ex);
                    _connection.Close();

                    return;
                }
                _connection.Close();
                MessageBox.Show("La suppression du client s'est effectuée avec succées.");
                refreshClientTable();
            }
        }

        private void textBox_Versement_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}

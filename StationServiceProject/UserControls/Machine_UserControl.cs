using System;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using StationServiceProject.Scripts;


namespace StationServiceProject
{
    public partial class Machine_UserControl : UserControl
    {
        bool[] _isDisplayed = { true, true, true};
        int _speedY = 2, _speedX = 3;
        
        SqlConnection _connection = DatabaseAccess.Instance.Connection;
        SqlCommand _commande;
        SqlDataAdapter _dataAdapter;
        DataSet _dataSet;

        private static Machine_UserControl _instance;
        public static Machine_UserControl Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Machine_UserControl();

                return _instance;
            }
        }


        public Machine_UserControl()
        {
            InitializeComponent();
        }

        private int LoadFromDatabase(string codeMachine)
        {
            int result = -1;

            _commande = new SqlCommand("MachineInformations", _connection);
            _commande.CommandType = CommandType.StoredProcedure;

            _commande.Parameters.AddWithValue("@CodeMachine", codeMachine);

            _dataAdapter = new SqlDataAdapter(_commande);
            _dataSet = new DataSet();
            _dataAdapter.Fill(_dataSet);

            _connection.Open();

            try
            {
                _commande.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show("ERROR\n" + ex);
                _connection.Close();
                return result;
            }

            _connection.Close();
            
            dataGridView1.DataSource = _dataSet.Tables[0];
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; 
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].HeaderText = "Prénom et NOM";
            dataGridView1.Columns[2].HeaderText = "Index de la releve";
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            _commande.CommandText = "IndexDernier_Machine";
            
            _connection.Open();
            try
            {
                using (var reader = _commande.ExecuteReader())
                {
                    reader.Read();

                    result = reader.GetInt32(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR\n" + ex);
                _connection.Close();
                return result;
            }

            _connection.Close();

            return result;

        }


        private void button_Machine_Choice_Click(object sender, EventArgs e)
        {
            //Extracting the code machine from the button name
            string codeMachine = ((Button)sender).Name.Split(new[] { '_' }, 2)[1];

            int indexDer = LoadFromDatabase(codeMachine);

            
            label_codeMachine.Text = codeMachine + " - Dernier index: " + indexDer;
        }


        //Buttons mechanics code starts from here

        private void timer1_Tick(object sender, EventArgs e)
        {
            DisplayPiste(0, button_B_SNP_1, button_B_SUP_1, button_B_SNP_2, button_B_SUP_2, button_B_SNP_3, button_B_SUP_3);
        }
        
        private void timer2_Tick(object sender, EventArgs e)
        {
            DisplayPiste(1, button_H_SNP_1, button_H_SUP_1, button_H_SNP_2, button_H_SUP_2, button_H_SNP_3, button_H_SUP_3);
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            DisplayPiste(2, button_M1_Chauffeur, button_M1_Passager, button_M2_Chauffeur, button_M2_Passager, button_M3_Chauffeur, button_M3_Passager);

            Point p;
            if (!_isDisplayed[2])
            {
                if (button_M4_Reserve.Location.Y >= 441)
                    return;

                p = new Point(button_M4_Reserve.Location.X, button_M4_Reserve.Location.Y + _speedY);
                
            }
            else
            {
                if (button_M4_Reserve.Location.Y <= 372)
                    return;

                p = new Point(button_M4_Reserve.Location.X, button_M4_Reserve.Location.Y - _speedY);
            }

            button_M4_Reserve.Location = p;
        }
        
        private void button_Essence_Passager_Click(object sender, EventArgs e)
        {   
            _isDisplayed[0] = !_isDisplayed[0];

            timer1.Start();


            // Close other openned pistes
            _isDisplayed[1] = true;
            _isDisplayed[2] = true;

            timer2.Start();
            timer3.Start();
        }


        private void button_Essence_Chauffeur_Click(object sender, EventArgs e)
        {
            _isDisplayed[1] = !_isDisplayed[1];

            timer2.Start();


            // Close other openned pistes
            _isDisplayed[0] = true;
            _isDisplayed[2] = true;
            
            timer1.Start();
            timer3.Start();
        }

        private void button_Gasoile_Click(object sender, EventArgs e)
        {
            _isDisplayed[2] = !_isDisplayed[2];

            timer3.Start();


            // Close other openned pistes
            _isDisplayed[0] = true;
            _isDisplayed[1] = true;

            timer1.Start();
            timer2.Start();
        }

        private void StopTimer(int index)
        {
            switch(index)
            {
                case 0:
                    timer1.Stop();
                    break;
                case 1:
                    timer2.Stop();
                    break;
                case 2:
                    timer3.Stop();
                    break;
                default:
                    MessageBox.Show("Probleme in timer index");
                    break;
            }
        }
        
        private void DisplayPiste(int index, Button b_Up_Left, Button b_Up_Right, Button b_Middle_Left, Button b_Middle_Right,
            Button b_Down_Left, Button b_Down_Right)
        {
            Point p, pp;

            if (!_isDisplayed[index])
            {
                if (b_Up_Left.Location.Y <= b_Middle_Left.Location.Y - 54)
                {
                    if (b_Up_Right.Location.X >= 355)
                    {
                     //   label1.Location = new Point(b_Up_Left.Location.X, b_Up_Left.Location.Y - 10);
                        StopTimer(index);
                        return;
                    }
                    var p8 = new Point(b_Up_Right.Location.X + _speedX, b_Up_Right.Location.Y);
                    b_Up_Right.Location = p8;
                    var p9 = new Point(b_Middle_Right.Location.X + _speedX, b_Middle_Right.Location.Y);
                    b_Middle_Right.Location = p9;
                    var p10 = new Point(b_Down_Right.Location.X + _speedX, b_Down_Right.Location.Y);
                    b_Down_Right.Location = p10;
                    return;
                }

                if (b_Up_Left.Location.X >= 170)
                {
                    p = new Point(b_Up_Left.Location.X + _speedX, b_Up_Left.Location.Y - _speedY);

                    pp = new Point(b_Down_Left.Location.X + _speedX, b_Down_Left.Location.Y + _speedY);
                }
                else
                {
                    p = new Point(b_Up_Left.Location.X + _speedX, b_Up_Left.Location.Y);

                    pp = new Point(b_Down_Left.Location.X + _speedX, b_Down_Left.Location.Y);
                }

                b_Up_Left.Location = p;
                b_Up_Right.Location = p;
                var p6 = new Point(b_Middle_Left.Location.X + _speedX, b_Middle_Left.Location.Y);
                b_Middle_Left.Location = p6;
                b_Middle_Right.Location = p6;
                b_Down_Left.Location = pp;
                b_Down_Right.Location = pp;
            }
            else
            {
                if (b_Up_Right.Location.X >= b_Up_Left.Location.X)
                {
                    var p8 = new Point(b_Up_Right.Location.X - _speedX, b_Up_Right.Location.Y);
                    b_Up_Right.Location = p8;
                    var p9 = new Point(b_Middle_Right.Location.X - _speedX, b_Middle_Right.Location.Y);
                    b_Middle_Right.Location = p9;
                    var p10 = new Point(b_Down_Right.Location.X - _speedX, b_Down_Right.Location.Y);
                    b_Down_Right.Location = p10;
                    return;
                }

                if (b_Up_Left.Location.X == 101)
                {
                    StopTimer(index);
                    return;
                }
                if (b_Up_Left.Location.Y < b_Middle_Left.Location.Y)
                {
                    p = new Point(b_Up_Left.Location.X - _speedX, b_Up_Left.Location.Y + _speedY);
                    pp = new Point(b_Down_Left.Location.X - _speedX, b_Down_Left.Location.Y - _speedY);
                }
                else
                {
                    p = new Point(b_Up_Left.Location.X - _speedX, b_Up_Left.Location.Y);
                    pp = new Point(b_Down_Left.Location.X - _speedX, b_Down_Left.Location.Y);
                }
                b_Up_Left.Location = p;
                b_Up_Right.Location = p;
                var p6 = new Point(b_Middle_Left.Location.X - _speedX, b_Middle_Left.Location.Y);
                b_Middle_Left.Location = p6;
                b_Middle_Right.Location = p6;
                b_Down_Left.Location = pp;
                b_Down_Right.Location = pp;
            }
        }
    
   
    }
}

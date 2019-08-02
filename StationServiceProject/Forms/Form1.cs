using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using StationServiceProject.UserControls;
using StationServiceProject.Scripts;


namespace StationServiceProject
{
    public partial class PrincipalForm : Form
    {

        private bool _isSlidingPanelExpanded;

        SqlConnection _connection = DatabaseAccess.Instance.Connection;
        SqlCommand _commande;
        SqlDataReader _reader;

        public PrincipalForm()
        {
            InitializeComponent();

            _isSlidingPanelExpanded = false;
            OnRetractedSlidingPanel();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show("Label clicked");
        }
         
        private void PrincipalForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Voulez-vous vraiment quitter ?", "Quitter",
    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
    MessageBoxDefaultButton.Button1) == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
        }
        
        private void button_Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        // Sliding Panel code starts from here

        private const float _maxSlideWidth = 155, _minSlideWidth = 68;
        private const int _speed = 5;

        private void OnExpandedSlidingPanel()
        {
            button_About.Text = "à propos";
            button_Clients.Text = "Clients";
            button_Machines.Text = "Machines";
            button_pompiste.Text = "Pompistes";
            button_Produits.Text = "Produits";
            button_Versements.Text = "Versements";

            button_About.Image = null;
            button_Clients.Image = null;
            button_Machines.Image = null;
            button_pompiste.Image = null;
            button_Produits.Image = null;
            button_Versements.Image = null;
            button_Sliding.Image = Properties.Resources.image_slide_retract_55x54;
        }

        private void OnRetractedSlidingPanel()
        {
            button_About.Text = "";
            button_Clients.Text = "";
            button_Machines.Text = "";
            button_pompiste.Text = "";
            button_Produits.Text = "";
            button_Versements.Text = "";

            button_About.Image = Properties.Resources.image_about_55x54;
            button_Clients.Image = Properties.Resources.image_client_55x54;
            button_Machines.Image = Properties.Resources.image_machine_55x54;
            button_pompiste.Image = Properties.Resources.image_pompiste_55x54;
            button_Produits.Image = Properties.Resources.image_detergent_55x54;
            button_Versements.Image = Properties.Resources.image_versement_55x54;
            button_Sliding.Image = Properties.Resources.image_slide_expand_55x54;

        }
        private void updateToolsWidth(int speed)
        {
            // Updates Tools width when sliding the menu bar 

            panel_SlidingPanel.Width += speed;
            button_About.Width += speed;
            button_Clients.Width += speed;
            button_Machines.Width += speed;
            button_pompiste.Width += speed;
            button_Produits.Width += speed;
            button_Versements.Width += speed;
            button_Sliding.Width += speed;
            button_Home.Width += speed;
            panel_Container.Width += -speed;

        }
        private void timer_SlidingPanel_Tick(object sender, EventArgs e)
        {
            if (_isSlidingPanelExpanded)
            {
                // Rectract panel
                // Rectract buttons and panels

                updateToolsWidth(-_speed);
                if (panel_SlidingPanel.Width <= _minSlideWidth)
                {
                    // Panel has been retracted
                    // Stop Timer.
                    // remove text and show images

                    timer_SlidingPanel.Stop();
                    OnRetractedSlidingPanel();
                    _isSlidingPanelExpanded = false;
                    this.Refresh();

                }
            }
            else
            {
                // Expand panel
                // Expand buttons and panels

                updateToolsWidth(_speed);

                if (panel_SlidingPanel.Width >= _maxSlideWidth)
                {
                    // Panel has been expanded
                    // Stop Timer
                    // remove images and show text

                    timer_SlidingPanel.Stop();
                    OnExpandedSlidingPanel();
                    _isSlidingPanelExpanded = true;
                    this.Refresh();

                }
            }
        }
        
        private void PrincipalForm_Load(object sender, EventArgs e)
        {

        }
        
        private void button_Sliding_Click(object sender, EventArgs e)
        {
            timer_SlidingPanel.Start();
        }
        

        // UserControls buttons
        
        private void button_pompiste_Click(object sender, EventArgs e)
        {
            if (!panel_Container.Controls.Contains(Pompiste_UserControl.Instance))
            {
                panel_Container.Controls.Add(Pompiste_UserControl.Instance);
                Pompiste_UserControl.Instance.Dock = DockStyle.Fill;
                Pompiste_UserControl.Instance.BringToFront();
            }
            else
            {
                Pompiste_UserControl.Instance.BringToFront();
            }
        }

        private void button_Produits_Click(object sender, EventArgs e)
        {
            if (!panel_Container.Controls.Contains(Produit_UserControl.Instance))
            {
                panel_Container.Controls.Add(Produit_UserControl.Instance);
                Produit_UserControl.Instance.Dock = DockStyle.Fill;
                Produit_UserControl.Instance.BringToFront();
            }
            else
            {
                Produit_UserControl.Instance.BringToFront();
                Produit_UserControl.Instance.refreshProductTable();
            }
        }

        private void button_Versements_Click(object sender, EventArgs e)
        {
            if (!panel_Container.Controls.Contains(Versement_UserControl.Instance))
            {
                panel_Container.Controls.Add(Versement_UserControl.Instance);
                Versement_UserControl.Instance.Dock = DockStyle.Fill;
                Versement_UserControl.Instance.BringToFront();
            }
            else
            {
                Versement_UserControl.Instance.BringToFront();
            }
        }

        private void button_Clients_Click(object sender, EventArgs e)
        {
            if (!panel_Container.Controls.Contains(userControl_Client.Instance))
            {
                panel_Container.Controls.Add(userControl_Client.Instance);
                userControl_Client.Instance.Dock = DockStyle.Fill;
                userControl_Client.Instance.BringToFront();
            }
            else
            {
                userControl_Client.Instance.BringToFront();
                userControl_Client.Instance.refreshClientTable();
            }
        }

        private void button_About_Click(object sender, EventArgs e)
        {
            if (!panel_Container.Controls.Contains(About_UserControl.Instance))
            {
                panel_Container.Controls.Add(About_UserControl.Instance);
                About_UserControl.Instance.Dock = DockStyle.Fill;
                About_UserControl.Instance.BringToFront();
            }
            else
            {
                About_UserControl.Instance.BringToFront();
            }

        }

        private void button_Home_Click(object sender, EventArgs e)
        {
            if (!panel_Container.Controls.Contains(Acceuil_UserControl.Instance))
            {
                panel_Container.Controls.Add(Acceuil_UserControl.Instance);
                Acceuil_UserControl.Instance.Dock = DockStyle.Fill;
                Acceuil_UserControl.Instance.BringToFront();
            }
            else
            {
                Acceuil_UserControl.Instance.BringToFront();
            }
        }

        private void button_Machines_Click(object sender, EventArgs e)
        {
            if (!panel_Container.Controls.Contains(Machine_UserControl.Instance))
            {
                panel_Container.Controls.Add(Machine_UserControl.Instance);
                Machine_UserControl.Instance.Dock = DockStyle.Fill;
                Machine_UserControl.Instance.BringToFront();
            }
            else
            {
                Machine_UserControl.Instance.BringToFront();
            }
        }

        
    }
}

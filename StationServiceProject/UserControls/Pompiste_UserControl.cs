using System;
using System.Windows.Forms;

namespace StationServiceProject.UserControls
{
    public partial class Pompiste_UserControl : UserControl
    {
        private static Pompiste_UserControl _instance;
        public static Pompiste_UserControl Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Pompiste_UserControl();

                return _instance;
            }
        }

        public Pompiste_UserControl()
        {
            InitializeComponent();
        }

        private void Pompiste_UserControl_Load(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StationServiceProject
{
    public partial class Versement_UserControl : UserControl
    {
        private static Versement_UserControl _instance;
        public static Versement_UserControl Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Versement_UserControl();

                return _instance;
            }
        }
        public Versement_UserControl()
        {
            InitializeComponent();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using StationServiceProject.UserControls;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using StationServiceProject.Scripts;
using System.Diagnostics;
using System.Text.RegularExpressions;
using StationServiceProject;
using System.Data.SqlClient;

namespace StationServiceProject.Scripts
{
    class PrintDocuments
    {
        
        private static PrintDocuments _instance;
        

        public static PrintDocuments Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PrintDocuments();
                }

                return _instance;
            }
        }


        public void PrintDocument_FeuilleJournee_Gasoil (System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bmap = Properties.Resources.image_FeuilleJournee_Gasoil;
            Image img = bmap;
            e.Graphics.DrawImage(img, 0, 0, img.Width - 1560, img.Height - 2200);
            
        }

        public void PrintDocument_FeuilleJournee_SUP_SNP(System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bmap = Properties.Resources.image_FeuilleJournee_SUP_SNP;
            Image img = bmap;
            e.Graphics.DrawImage(img, 0, 0, img.Width + 150, img.Height + 210);
        }

        public void PrintDocument_FeuilleBrigade(int idpompiste, string datebrigade, string dataprevious, System.Drawing.Printing.PrintPageEventArgs e)
        {
            decimal[] informations = { 22654569.23M, 333333333.23M, 444444444.23M, 555555555.23M, };// new decimal[15];

            Bitmap bmap = Properties.Resources.image_FeuilleDeBrigade;
            Image img = bmap;
            
            e.Graphics.DrawImage(img, 0, 0, img.Width, img.Height);
            /*
            using (var conn = DatabaseAccess.Instance.Connection)
            {
                try
                {
                
                    conn.Open();
                    using (var comm = new SqlCommand("Informations_ReleveAmountMoney", conn))
                    {
                        comm.CommandType = CommandType.StoredProcedure;

                        comm.Parameters.AddWithValue("@IDPompiste", idpompiste);
                        comm.Parameters.AddWithValue("@DateBrigade", datebrigade);

                        using (var reader = comm.ExecuteReader())
                        {
                            reader.Read();
                            informations[0] = reader.GetDecimal(2); // Sommerecoltee
                            informations[1] = reader.GetDecimal(3); // MontantSUP
                            informations[2] = reader.GetDecimal(4); // MontantSNP
                            informations[3] = reader.GetDecimal(5); // MontantGasoil
                            informations[4] = reader.GetDecimal(6); // MontantProducts
                            informations[5] = reader.GetInt32(7); // billets_2000
                            informations[6] = reader.GetInt32(8); // billets_1000
                            informations[7] = reader.GetInt32(9); // billets_500
                            informations[8] = reader.GetInt32(10); // billets_200
                            informations[9] = reader.GetInt32(11); // billets_100
                            informations[10] = reader.GetInt32(12); // TAC_850
                            informations[11] = reader.GetInt32(13); // TAC_690
                            informations[12] = reader.GetDecimal(14); // TAC_20l
                            informations[13] = reader.GetDecimal(15); // Versement
                            informations[14] = reader.GetInt32(16); // Monnaie
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    conn.Close();
                    return;
                }
            }
            
            */
            
            e.Graphics.DrawString(dataprevious, new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(465, 60));
            e.Graphics.DrawString(datebrigade, new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(630, 60));
        }
    }
}

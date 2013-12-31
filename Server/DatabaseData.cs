using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Server
{
    public partial class DatabaseData : Form
    {
        public static List<string>[] listData = new List<string>[4];
        public DatabaseData()
        {
            InitializeComponent();
            
        }

        public void showData()
        {
            
            dgDisplay.Rows.Clear();
            for (int i = 0; i < listData[0].Count; i++)
            {
                int number = dgDisplay.Rows.Add();
                dgDisplay.Rows[number].Cells[0].Value = listData[0][i];
                dgDisplay.Rows[number].Cells[1].Value = listData[1][i];
                dgDisplay.Rows[number].Cells[2].Value = listData[2][i];
                dgDisplay.Rows[number].Cells[3].Value = listData[3][i];
            }
        }
    }
}

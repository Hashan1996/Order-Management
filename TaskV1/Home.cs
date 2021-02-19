using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskV1
{
    public partial class Home : Form
    {
        string conn = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        public Home()
        {
            InitializeComponent();
            GetOrderDetails();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            SalesOrder salesOrder = new SalesOrder();
            salesOrder.ShowDialog();
        }

        private void GetOrderDetails()
        {
            SqlConnection sqlConn = new SqlConnection(conn);
            SqlCommand sqlComm = new SqlCommand("GetOrderDetailsInformation", sqlConn);
            sqlComm.CommandType = CommandType.StoredProcedure;
            sqlConn.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlComm);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            dataGridView2.DataSource = dt;
            sqlConn.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //this.Hide();
            SalesOrder salesOrder = new SalesOrder();
            salesOrder.textBoxRefNo.Text = this.dataGridView2.CurrentRow.Cells[0].Value.ToString();
            salesOrder.comboBox_CustomerName.Text = this.dataGridView2.CurrentRow.Cells[4].Value.ToString();
            salesOrder.textBoxInvoiceNo.Text = this.dataGridView2.CurrentRow.Cells[5].Value.ToString();
            
            salesOrder.textBoxNote.Text = this.dataGridView2.CurrentRow.Cells[7].Value.ToString();
            //salesOrder.dataGridView1.Rows[0].Cells[0].Value = this.dataGridView2.CurrentRow.Cells[1].Value.ToString();
            salesOrder.dataGridView1.Rows[0].Cells[1].Value = this.dataGridView2.CurrentRow.Cells[2].Value.ToString();
            salesOrder.dataGridView1.Rows[0].Cells[2].Value = this.dataGridView2.CurrentRow.Cells[3].Value.ToString();
            salesOrder.dataGridView1.Rows[0].Cells[3].Value = this.dataGridView2.CurrentRow.Cells[8].Value.ToString();
            salesOrder.dataGridView1.Rows[0].Cells[4].Value = this.dataGridView2.CurrentRow.Cells[9].Value.ToString();
            salesOrder.dataGridView1.Rows[0].Cells[5].Value = this.dataGridView2.CurrentRow.Cells[10].Value.ToString();
            salesOrder.dataGridView1.Rows[0].Cells[6].Value = this.dataGridView2.CurrentRow.Cells[11].Value.ToString();
            salesOrder.dataGridView1.Rows[0].Cells[7].Value = this.dataGridView2.CurrentRow.Cells[12].Value.ToString();
            salesOrder.dataGridView1.Rows[0].Cells[8].Value = this.dataGridView2.CurrentRow.Cells[13].Value.ToString();
            salesOrder.textBoxTotalExcl.Text = this.dataGridView2.CurrentRow.Cells[14].Value.ToString();
            salesOrder.textBoxTotalTax.Text = this.dataGridView2.CurrentRow.Cells[15].Value.ToString();
            salesOrder.textBoxTotalIncl.Text = this.dataGridView2.CurrentRow.Cells[16].Value.ToString();

            salesOrder.ShowDialog();

        }
    }
}

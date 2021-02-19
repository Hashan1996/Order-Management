using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Diagnostics;
using System.Data.Entity;
using TaskV1.Model;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using TaskV1.CrystalReport;

namespace TaskV1
{
    public partial class SalesOrder : Form
    {
        ItemOrder itemOrderModel = new ItemOrder();
        Client clientModel = new Client();
        OrderDetail orderDetailModel = new OrderDetail();
        StkItem stkItemModel = new StkItem();
        Task_DBEntities9 task_DBEntities = new Task_DBEntities9();
        string conn = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        Guid RefID = Guid.NewGuid(); 

        public SalesOrder()
        {
            InitializeComponent();
        }
        private void SalesOrder_Load(object sender, EventArgs e)
        {
            try
            {
                fillCustomerNameCombo();
                fillItemCodeCombo();
                fillDescriptionCombo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void fillCustomerNameCombo()
        {
            SqlConnection sqlConn = new SqlConnection(conn);
            string sqlQuery = "SELECT DCLink, Name FROM Client";
            SqlCommand sqlComm = new SqlCommand(sqlQuery, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlComm);
                DataTable ds = new DataTable();
                sqlDataAdapter.Fill(ds);
                comboBox_CustomerName.DisplayMember = "Name";
                comboBox_CustomerName.ValueMember = "DCLink";
                comboBox_CustomerName.DataSource = ds;
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void comboBox_CustomerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection sqlConn = new SqlConnection(conn);
            string sqlQuery = "SELECT Physical1, Physical2, Physical3, Physical4, Physical5, PhysicalPC FROM Client WHERE Name = '" + comboBox_CustomerName.Text + "'";
            SqlCommand sqlComm = new SqlCommand(sqlQuery, sqlConn);
            
            SqlDataReader rd;
            try
            {
                sqlConn.Open();
                rd = sqlComm.ExecuteReader();

                while (rd.Read())
                {
                    textBoxAddress1.Text = (string)rd["Physical1"].ToString();
                    textBoxAddress2.Text = (string)rd["Physical2"].ToString();
                    textBoxAddress3.Text = (string)rd["Physical3"].ToString();
                    textBoxSubrb.Text = (string)rd["Physical4"].ToString();
                    textBoxStates.Text = (string)rd["Physical5"].ToString();
                    textBoxPC.Text = (string)rd["PhysicalPC"].ToString();
                }
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void fillItemCodeCombo()
        {
            SqlConnection sqlConn = new SqlConnection(conn);
            string sqlQuery = "SELECT StockLink, Code FROM StkItem";
            SqlCommand sqlComm = new SqlCommand(sqlQuery, sqlConn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlComm);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            this.Code.DisplayMember = "Code";
            this.Code.ValueMember = "StockLink";
            this.Code.DataSource = dt;

        }

        private void fillDescriptionCombo()
        {
            SqlConnection sqlConn = new SqlConnection(conn);
            string sqlQuery = "SELECT Description_1 FROM StkItem";
            SqlCommand sqlComm = new SqlCommand(sqlQuery, sqlConn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlComm);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            this.Description_1.DisplayMember = "Description_1";
            this.Description_1.DataSource = dt;

        }
        private void label10_Click(object sender, EventArgs e)
        {

        }

       

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            calculateFields();
        }
        
        private void calculateFields()
        {
            //Calculate Excl, Tax, Incl Amount
            foreach (DataGridViewRow gridViewRow in dataGridView1.Rows)
            {
                gridViewRow.Cells[dataGridView1.Columns["ExclAmount"].Index].Value =
                    (Convert.ToDouble(gridViewRow.Cells[dataGridView1.Columns["Quantity"].Index].Value) * Convert.ToDouble(gridViewRow.Cells[dataGridView1.Columns["Price"].Index].Value));

                gridViewRow.Cells[dataGridView1.Columns["TaxAmount"].Index].Value =
                    (Convert.ToDouble(gridViewRow.Cells[dataGridView1.Columns["ExclAmount"].Index].Value) * (Convert.ToDouble(gridViewRow.Cells[dataGridView1.Columns["Tax"].Index].Value) / 100));

                gridViewRow.Cells[dataGridView1.Columns["InclAmount"].Index].Value =
                    (Convert.ToDouble(gridViewRow.Cells[dataGridView1.Columns["ExclAmount"].Index].Value) + Convert.ToDouble(gridViewRow.Cells[dataGridView1.Columns["TaxAmount"].Index].Value));
            }

            //Calculate Total Excl Amount
            double totalExclAmount = 0;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                totalExclAmount += Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value);
            }
            textBoxTotalExcl.Text = totalExclAmount.ToString();

            //Calculate Total Tax Amount
            double totalTaxAmount = 0;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                totalTaxAmount += Convert.ToDouble(dataGridView1.Rows[i].Cells[7].Value);
            }
            textBoxTotalTax.Text = totalTaxAmount.ToString();

            //Calculate Total Incl Amount
            double totalInclAmount = 0;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                totalInclAmount += Convert.ToDouble(dataGridView1.Rows[i].Cells[8].Value);
            }
            textBoxTotalIncl.Text = totalInclAmount.ToString();
        }

       

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                orderDetailModel.OD_DCLink = int.Parse(comboBox_CustomerName.SelectedValue.ToString()); 
                orderDetailModel.InvoiceNo = textBoxInvoiceNo.Text.Trim();
                orderDetailModel.InvoiceDate = dateTimeInvoice.Value.Date;
                orderDetailModel.RefNo = Guid.Parse(textBoxRefNo.Text.Trim());
                orderDetailModel.OrderDetailsNote = textBoxNote.Text.Trim();
                orderDetailModel.TotalExclAmount = Convert.ToDecimal(textBoxTotalExcl.Text);
                orderDetailModel.TotalTaxAmount = Convert.ToDecimal(textBoxTotalTax.Text);
                orderDetailModel.TotalInclAmount = Convert.ToDecimal(textBoxTotalIncl.Text);
                task_DBEntities.OrderDetails.Add(orderDetailModel);
                task_DBEntities.SaveChanges();
                

                if (orderDetailModel.RefNo != null)
                {
                    using (var context = new Task_DBEntities9())
                    {
                        foreach (DataGridViewRow dr in dataGridView1.Rows)
                        {
                            if (dr == null || dr.Cells[0].Value == null)
                                continue;
                            itemOrderModel.IO_RefNo = orderDetailModel.RefNo;
                            itemOrderModel.IO_StockLink = Convert.ToInt32(dr.Cells[0].Value.ToString());
                            itemOrderModel.Description = dr.Cells[1].Value.ToString(); 
                            itemOrderModel.ItemOrderNote = dr.Cells[2].Value.ToString();
                            itemOrderModel.Qty = Convert.ToInt32(dr.Cells[3].Value);
                            itemOrderModel.Price = Convert.ToInt32(dr.Cells[4].Value);
                            itemOrderModel.Tax = Convert.ToInt32(dr.Cells[5].Value);
                            itemOrderModel.ExclAmount = Convert.ToInt32(dr.Cells[6].Value);
                            itemOrderModel.TaxAmount = Convert.ToInt32(dr.Cells[7].Value);
                            itemOrderModel.InclAmount = Convert.ToInt32(dr.Cells[8].Value);

                            if (itemOrderModel.IO_RefNo != null)
                                task_DBEntities.Entry(itemOrderModel).State = EntityState.Modified;
                            else
                            {
                                task_DBEntities.ItemOrders.Add(itemOrderModel);
                            }
                            
                            task_DBEntities.SaveChanges();
                        }
                        MessageBox.Show("Order details saved successfully!");
                    }
                }
                else
                {
                    MessageBox.Show("Cannot save order details!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentCell.RowIndex != -1)
                {

                    orderDetailModel.RefNo = Guid.Parse(textBoxRefNo.Text.Trim());
                    orderDetailModel = task_DBEntities.OrderDetails.Where(x => x.RefNo == orderDetailModel.RefNo).FirstOrDefault();

                    orderDetailModel.OD_DCLink = int.Parse(comboBox_CustomerName.SelectedValue.ToString());
                    orderDetailModel.InvoiceNo = textBoxInvoiceNo.Text.Trim();
                    orderDetailModel.InvoiceDate = dateTimeInvoice.Value.Date;

                    orderDetailModel.OrderDetailsNote = textBoxNote.Text.Trim();
                    orderDetailModel.TotalExclAmount = Convert.ToDecimal(textBoxTotalExcl.Text);
                    orderDetailModel.TotalTaxAmount = Convert.ToDecimal(textBoxTotalTax.Text);
                    orderDetailModel.TotalInclAmount = Convert.ToDecimal(textBoxTotalIncl.Text);
                    task_DBEntities.ItemOrders.Add(itemOrderModel);
                    //task_DBEntities.SaveChanges();
                    

                    if (orderDetailModel.RefNo != null)
                    {
                        using (var context = new Task_DBEntities9())
                        {
                            itemOrderModel.IO_RefNo = orderDetailModel.RefNo;
                            itemOrderModel.IO_StockLink = Convert.ToInt32(dataGridView1.Rows[0].Cells[0].Value.ToString());
                            itemOrderModel.Description = dataGridView1.Rows[0].Cells[1].Value.ToString();
                            itemOrderModel.ItemOrderNote = dataGridView1.Rows[0].Cells[2].Value.ToString();
                            itemOrderModel.Qty = Convert.ToInt32(dataGridView1.Rows[0].Cells[3].Value);
                            itemOrderModel.Price = Convert.ToInt32(dataGridView1.Rows[0].Cells[4].Value);
                            itemOrderModel.Tax = Convert.ToInt32(dataGridView1.Rows[0].Cells[5].Value);
                            itemOrderModel.ExclAmount = Convert.ToInt32(dataGridView1.Rows[0].Cells[6].Value);
                            itemOrderModel.TaxAmount = Convert.ToInt32(dataGridView1.Rows[0].Cells[7].Value);
                            itemOrderModel.InclAmount = Convert.ToInt32(dataGridView1.Rows[0].Cells[8].Value);

                                if (itemOrderModel.IO_RefNo != null)
                                    task_DBEntities.Entry(itemOrderModel).State = EntityState.Modified;
                                else
                                {
                                    task_DBEntities.ItemOrders.Add(itemOrderModel);
                                }

                                task_DBEntities.SaveChanges();
                            
                            MessageBox.Show("Order details updated successfully!");
                        }
                    }
                }



            }
           
             catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        public void ClearFields() // Clear the fields after Insert or Update or Delete operation  
        {
            comboBox_CustomerName.Text = "";
            textBoxAddress1.Text = "";
            //txtCity.Text = "";
            //cmbGender.SelectedIndex = -1;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home home = new Home();
            home.ShowDialog();
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReportView reportView = new ReportView();
            SalesDetailsCrystalReport crystalReport = new SalesDetailsCrystalReport();

            TextObject textObject1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["RefNo"];
            textObject1.Text = textBoxRefNo.Text;

            TextObject textObject2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Description"];
            textObject2.Text = dataGridView1.Rows[0].Cells[1].Value.ToString(); ;

            TextObject textObject3 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Code"];
            textObject3.Text = dataGridView1.Rows[0].Cells[0].Value.ToString(); ;

            TextObject textObject4 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Name"];
            textObject4.Text = comboBox_CustomerName.Text;

            TextObject textObject5 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["InvoiceNo"];
            textObject5.Text = textBoxInvoiceNo.Text;

            TextObject textObject6 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["TotalExclAmount"];
            textObject6.Text = textBoxTotalExcl.Text;

            TextObject textObject7 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["TotalTaxAmount"];
            textObject7.Text = textBoxTotalTax.Text;

            TextObject textObject8 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["TotalInclAmount"];
            textObject8.Text = textBoxTotalIncl.Text;

            reportView.crystalReportViewer1.ReportSource = crystalReport;


            reportView.ShowDialog();
        }
    }
}

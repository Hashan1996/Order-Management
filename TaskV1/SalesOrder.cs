using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using TaskV1.CrystalReport;
using TaskV1.Model;

namespace TaskV1
{
    public partial class SalesOrder : Form
    {
        ItemOrder itemOrderModel = new ItemOrder();
        Client clientModel = new Client();
        OrderDetail orderDetailModel = new OrderDetail();
        StkItem stkItemModel = new StkItem();
        Task_DBEntities11 task_DBEntities = new Task_DBEntities11();

        /// <summary>
        /// Database Connection 
        /// </summary>
        string conn = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
      

        public SalesOrder()
        {
            InitializeComponent();
        }
        private void SalesOrder_Load(object sender, EventArgs e)
        {
            try
            {
                FillCustomerNameCombo();
                FillItemCodeCombo();
                FillDescriptionCombo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// Retrive client name to combobox
        /// </summary>
        private void FillCustomerNameCombo()
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

        /// <summary>
        /// This Client namecombobox clicking, then address details auto fill to fields
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// /// <summary>
        /// Retrive Item Code data to datagridView combobox 
        /// </summary>
        private void FillItemCodeCombo()
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

        /// <summary>
        /// Retrive Description data to datagridView combobox 
        /// </summary>
        private void FillDescriptionCombo()
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
        
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CalculateFields();
        }

        /// <summary>
        /// Calculate Excl, Tax and Incl Amounts
        /// </summary>
        private void CalculateFields()
        {
            foreach (DataGridViewRow gridViewRow in dataGridView1.Rows)
            {
                gridViewRow.Cells[dataGridView1.Columns["ExclAmount"].Index].Value =
                    (Convert.ToDouble(gridViewRow.Cells[dataGridView1.Columns["Quantity"].Index].Value) * Convert.ToDouble(gridViewRow.Cells[dataGridView1.Columns["Price"].Index].Value));

                gridViewRow.Cells[dataGridView1.Columns["TaxAmount"].Index].Value =
                    (Convert.ToDouble(gridViewRow.Cells[dataGridView1.Columns["ExclAmount"].Index].Value) * (Convert.ToDouble(gridViewRow.Cells[dataGridView1.Columns["Tax"].Index].Value) / 100));

                gridViewRow.Cells[dataGridView1.Columns["InclAmount"].Index].Value =
                    (Convert.ToDouble(gridViewRow.Cells[dataGridView1.Columns["ExclAmount"].Index].Value) + Convert.ToDouble(gridViewRow.Cells[dataGridView1.Columns["TaxAmount"].Index].Value));
            }

            double totalExclAmount = 0;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                totalExclAmount += Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value);
            }
            textBoxTotalExcl.Text = totalExclAmount.ToString();


            double totalTaxAmount = 0;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                totalTaxAmount += Convert.ToDouble(dataGridView1.Rows[i].Cells[7].Value);
            }
            textBoxTotalTax.Text = totalTaxAmount.ToString();

            double totalInclAmount = 0;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                totalInclAmount += Convert.ToDouble(dataGridView1.Rows[i].Cells[8].Value);
            }
            textBoxTotalIncl.Text = totalInclAmount.ToString();
        }

        /// <summary>
        /// Insert Order details using EF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                orderDetailModel.RefNo = Guid.Parse(textBoxRefNo.Text.Trim());
                orderDetailModel.OD_DCLink = int.Parse(comboBox_CustomerName.SelectedValue.ToString());
                orderDetailModel.InvoiceNo = textBoxInvoiceNo.Text.Trim();
                orderDetailModel.InvoiceDate = dateTimeInvoice.Value.Date;
                orderDetailModel.OrderDetailsNote = textBoxNote.Text.Trim();
                orderDetailModel.TotalExclAmount = Convert.ToDecimal(textBoxTotalExcl.Text);
                orderDetailModel.TotalTaxAmount = Convert.ToDecimal(textBoxTotalTax.Text);
                orderDetailModel.TotalInclAmount = Convert.ToDecimal(textBoxTotalIncl.Text);
                task_DBEntities.OrderDetails.Add(orderDetailModel);
                task_DBEntities.SaveChanges();

                if (orderDetailModel.RefNo != null)
                {
                    using (var context = new Task_DBEntities11())
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

                            task_DBEntities.ItemOrders.Add(itemOrderModel);
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

        /// <summary>
        /// Update Order deatils using EF(ADO.NET)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (orderDetailModel.RefNo != null)
                {

                    orderDetailModel.OD_DCLink = int.Parse(comboBox_CustomerName.SelectedValue.ToString());
                    orderDetailModel.InvoiceNo = textBoxInvoiceNo.Text.Trim();
                    orderDetailModel.InvoiceDate = dateTimeInvoice.Value.Date;
                    orderDetailModel.OrderDetailsNote = textBoxNote.Text.Trim();
                    orderDetailModel.TotalExclAmount = Convert.ToDecimal(textBoxTotalExcl.Text);
                    orderDetailModel.TotalTaxAmount = Convert.ToDecimal(textBoxTotalTax.Text);
                    orderDetailModel.TotalInclAmount = Convert.ToDecimal(textBoxTotalIncl.Text);
                    task_DBEntities.OrderDetails.Add(orderDetailModel);
                    task_DBEntities.SaveChanges();


                    if (orderDetailModel.RefNo != null)
                    {
                        using (var context = new Task_DBEntities11())
                        {
                            itemOrderModel.IO_RefNo = orderDetailModel.RefNo;
                            itemOrderModel.IO_StockLink = Convert.ToInt32(dataGridView1.Rows[0].Cells[0].Value.ToString());
                            itemOrderModel.Description = dataGridView1.Rows[0].Cells[1].Value.ToString();
                            itemOrderModel.ItemOrderNote = dataGridView1.Rows[0].Cells[2].Value.ToString();
                            itemOrderModel.Qty = (int)dataGridView1.Rows[0].Cells[3].Value;
                            itemOrderModel.Price = Convert.ToInt32(dataGridView1.Rows[0].Cells[4].Value);
                            itemOrderModel.Tax = Convert.ToInt32(dataGridView1.Rows[0].Cells[5].Value);
                            itemOrderModel.ExclAmount = Convert.ToInt32(dataGridView1.Rows[0].Cells[6].Value);
                            itemOrderModel.TaxAmount = Convert.ToInt32(dataGridView1.Rows[0].Cells[7].Value);
                            itemOrderModel.InclAmount = (int)dataGridView1.Rows[0].Cells[8].Value;

                            task_DBEntities.Entry(itemOrderModel).State = EntityState.Modified;
                            task_DBEntities.ItemOrders.Add(itemOrderModel);
                            

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

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home home = new Home();
            home.ShowDialog();
        }

        /// <summary>
        /// Crystal Report generate method (order details report)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPrint_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReportView reportView = new ReportView();
            SalesDetailsCrystalReport crystalReport = new SalesDetailsCrystalReport();

            TextObject textObjectRefNo = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["RefNo"];
            textObjectRefNo.Text = textBoxRefNo.Text;

            TextObject textObjectCode = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Code"];
            textObjectCode.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();

            TextObject textObjectDes = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Description"];
            textObjectDes.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();

            TextObject textObjectName = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Name"];
            textObjectName.Text = comboBox_CustomerName.Text;

            TextObject textObjectIneNo = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["InvoiceNo"];
            textObjectIneNo.Text = textBoxInvoiceNo.Text;

            TextObject textObjectOrderNote = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["OrderNote"];
            textObjectOrderNote.Text = textBoxNote.Text;

            TextObject textObjectQTY = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["QTY"];
            textObjectQTY.Text = dataGridView1.Rows[0].Cells[3].Value.ToString();

            TextObject textObjectPrice = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Price"];
            textObjectPrice.Text = dataGridView1.Rows[0].Cells[4].Value.ToString();

            TextObject textObjectTax = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Tax"];
            textObjectTax.Text = dataGridView1.Rows[0].Cells[5].Value.ToString();

            TextObject textObjectEA = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["ExclAmount"];
            textObjectEA.Text = dataGridView1.Rows[0].Cells[6].Value.ToString();

            TextObject textObjectTA = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["TaxAmount"];
            textObjectTA.Text = dataGridView1.Rows[0].Cells[7].Value.ToString();

            TextObject textObjectIA = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["InclAmount"];
            textObjectIA.Text = dataGridView1.Rows[0].Cells[8].Value.ToString();

           
            TextObject textObjectTEA = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["TotalExclAmount"];
            textObjectTEA.Text = textBoxTotalExcl.Text;

            TextObject textObjectTTA = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["TotalTaxAmount"];
            textObjectTTA.Text = textBoxTotalTax.Text;

            TextObject textObjectTIA = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["TotalInclAmount"];
            textObjectTIA.Text = textBoxTotalIncl.Text;

            TextObject textObjectItemNote = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["ItemNote"];
            textObjectItemNote.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();

            reportView.crystalReportViewer1.ReportSource = crystalReport;
            reportView.ShowDialog();
        }
    }
}

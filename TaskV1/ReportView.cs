using System.Windows.Forms;

namespace TaskV1
{
    public partial class ReportView : Form
    {
        public ReportView()
        {
            InitializeComponent();
        }

        private void buttonBack_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            SalesOrder salesOrder = new SalesOrder();
            salesOrder.ShowDialog();
        }
    }
}

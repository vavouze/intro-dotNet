using System.Data;
using DataProvider;

namespace Presentation
{
    public partial class Form1 : Form
    {
        private DataGridView masterDataGridView = new DataGridView();
        private BindingSource masterBindingSource = new BindingSource();

        private readonly PersonRepository _repository = new PersonRepository();

        [STAThreadAttribute()]
        public static void Main()
        {
            Application.Run(new Form1());
        }
        public Form1()
        {
            masterDataGridView.Dock = DockStyle.Fill;

            SplitContainer splitContainer1 = new SplitContainer();
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Orientation = Orientation.Horizontal;
            splitContainer1.Panel1.Controls.Add(masterDataGridView);

            this.Controls.Add(splitContainer1);
            this.Load += Form1_Load;
            this.Text = "DataGridView master/detail demo";
        }

        private void GetData()
        {
            masterBindingSource.DataSource = _repository.GetAll();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            masterDataGridView.DataSource = masterBindingSource;
            GetData();
            
            masterDataGridView.AutoResizeColumns();
            masterDataGridView.Columns["PersonId"].Visible = false;
        }
    }
}
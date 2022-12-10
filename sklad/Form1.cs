using DGVPrinterHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sklad
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "sotrudnikiDataSet.Table". При необходимости она может быть перемещена или удалена.
            this.tableTableAdapter1.Fill(this.sotrudnikiDataSet.Table);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "nomenklatDataSet.Table". При необходимости она может быть перемещена или удалена.
            this.tableTableAdapter.Fill(this.nomenklatDataSet.Table);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "nomenklatDataSet.Table". При необходимости она может быть перемещена или удалена.
            this.tableTableAdapter.Fill(this.nomenklatDataSet.Table);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "nomenklatDataSet.Table". При необходимости она может быть перемещена или удалена.
            this.tableTableAdapter.Fill(this.nomenklatDataSet.Table);

           

        }

       

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.tableTableAdapter.Fill(this.nomenklatDataSet.Table);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tableBindingSource.EndEdit();
            tableTableAdapter.Update(nomenklatDataSet);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == tableBindingSource)
            {
                tableBindingSource.Filter = " [Наименование] LIKE'" + textBox1.Text + "%'";
               
            }

        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            
            DGVPrinter printer = new DGVPrinter();
            Bitmap bitmap1 = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "Resources\\logo.png");
            DGVPrinter.ImbeddedImage img1 = new DGVPrinter.ImbeddedImage();
            img1.theImage = bitmap1; img1.ImageX = 50; img1.ImageY = 50;
            img1.ImageAlignment = DGVPrinter.Alignment.NotSet;
            img1.ImageLocation = DGVPrinter.Location.Absolute;
            printer.ImbeddedImageList.Add(img1);
            printer.Title = "Инвентаризация";//Header
            printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date.ToString("MM/dd/yyyy"));
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "DeStroy";//Footer
            printer.FooterSpacing = 15;
            printer.PageSettings.Landscape = true;
            printer.PrintPreviewDataGridView(dataGridView1);
                     
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 npform2 = new Form2();
            npform2.Show();
            
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            tableTableAdapter.Fill(nomenklatDataSet.Table);
            dataGridView1.Refresh();
        }
    }

    
    
}

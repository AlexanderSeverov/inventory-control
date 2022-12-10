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
    public partial class Form2 : Form
    {
        int row,kolspis,pozspis;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "nomenklatDataSet.Table". При необходимости она может быть перемещена или удалена.
            this.tableTableAdapter1.Fill(this.nomenklatDataSet.Table);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "sotrudnikiDataSet.Table". При необходимости она может быть перемещена или удалена.
            this.tableTableAdapter.Fill(this.sotrudnikiDataSet.Table);
         
        }

        private void tableBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.tableTableAdapter.Fill(this.sotrudnikiDataSet.Table);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentCell.Value.ToString();

            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
           
            tableBindingSource1.EndEdit();
            tableTableAdapter1.Update(nomenklatDataSet);
            

            DGVPrinter printer = new DGVPrinter();
            Bitmap bitmap1 = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "Resources\\logo.png");
            DGVPrinter.ImbeddedImage img1 = new DGVPrinter.ImbeddedImage();
            img1.theImage = bitmap1; img1.ImageX = 50; img1.ImageY = 50;
            img1.ImageAlignment = DGVPrinter.Alignment.NotSet;
            img1.ImageLocation = DGVPrinter.Location.Absolute;
            printer.ImbeddedImageList.Add(img1);
            printer.Title = string.Format("Date: {0}", DateTime.Now.Date.ToString("MM/dd/yyyy"))+ "\n";//Header
            printer.SubTitle = "НАКЛАДНАЯ"+ "\n" + "Выдача материальных ценностей сотруднику - " + textBox1.Text;
            printer.PageText = "Страница - ";
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "DeStroy";//Footer
            printer.FooterSpacing = 15;
            printer.PageSettings.Landscape = true;
            printer.PrintPreviewDataGridView(dataGridView3);

            
            this.Close();

            


        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1.ActiveForm.Activate();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (dataGridView2.DataSource == tableBindingSource1)
            {
                tableBindingSource1.Filter = " [Наименование] LIKE'" + textBox4.Text + "%'";

            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
                textBox3.Text = dataGridView2.CurrentCell.Value.ToString();

            dataGridView3.Rows.Add();
            dataGridView3[1,pozspis].Value = dataGridView2.CurrentCell.Value;        
            row = dataGridView2.CurrentCell.RowIndex;

            dataGridView3[0, pozspis].Value = dataGridView2[0, row].Value;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            kolspis = int.Parse(textBox2.Text);
            dataGridView3[2, pozspis].Value = kolspis;
            int tmp=0;

            tmp = int.Parse(dataGridView2[2, row].Value.ToString());
            dataGridView2[2,row].Value = tmp - kolspis;

           
            pozspis++;
            textBox2.Text = "";

        }
    }
}

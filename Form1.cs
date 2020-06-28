using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// import this library SqlClient before everything
using System.Data.SqlClient;

namespace pruebaSearch
{
    public partial class Form1 : Form
    {
        // 
        SqlConnection connectionClientes = new SqlConnection("Data Source=FEDECOMPU\\SQLEXPRESS01;Initial Catalog=avamcarprueba;Integrated Security=True");
        DataTable dt;
        SqlDataAdapter sqlAdapter;




        // constructor 
        public Form1()
        {
            InitializeComponent();
            displayValue();
        }
        // Function for display de text input in the textBox1
        public void displayValue()
        {
            connectionClientes.Open();
            sqlAdapter = new SqlDataAdapter("select * from CLIENTES", connectionClientes);
            dt = new DataTable();
            sqlAdapter.Fill(dt);
            dataGridView1.DataSource = dt;
            connectionClientes.Close();
        }
        // action function for the textbox1
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            searchData(textBox1.Text);
        }
        // function implements a SQL query based on string of textBox, and create and new dataGridview datasource for display
        public void searchData(string search)
        {
            connectionClientes.Open();
            string query = "SELECT * FROM CLIENTES WHERE CLIENTES.NOMBRE LIKe '%" + search + "%'";
            sqlAdapter = new SqlDataAdapter(query, connectionClientes);
            dt = new DataTable();
            sqlAdapter.Fill(dt);
            dataGridView1.DataSource = dt;
            connectionClientes.Close();
        }
    }
}

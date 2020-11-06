using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {

        DataGridViewColumn Output;
        List<string> CategoryData = new List<string>() { "Memory", "Processor", "GPU Engine", "GPU Adapter Memory", "GPU Process Memory", "IPv4", "IPv6", "LogicalDisk", "Network Adapter", "Network Interface", "Paging File", "PhysicalDisk", "Power Meter", "Processor Information", "Storage Spaces Virtual Disk", "System", "Thread", "USB" };
        public Form1()
        {
            InitializeComponent();
            SetDispatcher();
            InitDataGridView();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //Method sets up the DataGridView
        //Adds the 3 ComboBox Columns and also the Output Column
        private void InitDataGridView()
        {
            DataGridViewComboBoxColumn Category = MakeComboBoxColumnWithData("Category", CategoryData);
            DataGridViewComboBoxColumn Instance = MakeComboBoxColumn("Instance");
            DataGridViewComboBoxColumn Counter = MakeComboBoxColumn("Counter");

            
            DataGridViewColumn Output = MakeColumn("Output");

            //Adds all the Columns to the DataGridView
            dataGridView1.Columns.Add(Category);
            dataGridView1.Columns.Add(Instance);
            dataGridView1.Columns.Add(Counter);
            dataGridView1.Columns.Add(Output);
        }

        //Method for making a Text Box Column
        private DataGridViewTextBoxColumn MakeColumn(string name)
        {
            DataGridViewTextBoxColumn dgc = new DataGridViewTextBoxColumn();
            dgc.HeaderText = name;
            dgc.Name = name;
            
            return dgc;
        }

        //Method for making a ComboBox Column
        private DataGridViewComboBoxColumn MakeComboBoxColumn(string name)
        {
            DataGridViewComboBoxColumn cbc = new DataGridViewComboBoxColumn();

            cbc.HeaderText = name;
            cbc.Name = name;
            

            return cbc;

        }

        //Method for making a ComboBox Column with Data
        private DataGridViewComboBoxColumn MakeComboBoxColumnWithData(string name, List<string> data)
        {
            DataGridViewComboBoxColumn cbc = new DataGridViewComboBoxColumn();

            cbc.DataSource = data; 
            cbc.HeaderText = name;
            cbc.Name = name;


            return cbc;

        }

        //Method currently gets Category's
        //Method needs to add instances to the instance combobox
        //Need to figure out how to clear the instance and add the data
        private void PopulateAndSortInstances()
        {
            DataGridViewComboBoxColumn Instance;
            PerformanceCounterCategory instances;

            String category;
            int col = 0;
            //First for loop gets the cateogory
            for (int row = 0; row < dataGridView1.Rows.Count; row++)
            {
                category = (String)dataGridView1[col, row].Value;
                //Code tries to get the instances and put the in the combobox
                if (category != null)
                {


                    instances = new PerformanceCounterCategory(category);
                    string[] varArray = instances.GetInstanceNames();
                    String listOfInstances = "";
                    //instanceComboBox1.Items.Clear();
                    //Instance = dataGridView1[col + 1, row].get
                    //Instance.Items.Clear();
                    foreach (string instance in varArray)
                    {
                        listOfInstances += instance + "\n";
                        //Instance.Items.Add(instance);
                        //instanceComboBox1.Items.Add(instance);
                    }
                }
            }

        }

        //Adds a row to the DataGridView
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(); 
        }

        //Sets up the Timer Method
        public void SetDispatcher()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        //Update Method, Currently runs every second
        void timer_Tick(object sender, EventArgs e)
        {
            PopulateAndSortInstances();
        }
    }
}
//Init method makes DataGrid able to add rows
//Find out how to make this work with my current code and combobox columns or change the method to have combobox columns
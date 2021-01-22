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
{ //Updated
    public partial class Form1 : Form
    {
        DataGridViewComboBoxColumn Category;
        DataGridViewComboBoxColumn Instance;
        DataGridViewComboBoxColumn Counter;
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
            Category = MakeComboBoxColumnWithData("categoryIdComboBoxColumn", "CategoryID", CategoryData, "Category");
            Instance = MakeComboBoxColumn("instanceIdComboBoxColumn", "InstanceID", "Instance");
            Counter = MakeComboBoxColumn("counterIdComboBoxColumn", "CounterID", "Counter");

            
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
        private DataGridViewComboBoxColumn MakeComboBoxColumn(string name1, string propertyName, string name2)
        {
            DataGridViewComboBoxColumn cbc = new DataGridViewComboBoxColumn();

            cbc.Name = name1;
            cbc.DataPropertyName = propertyName;
            cbc.ValueMember = "Id";
            cbc.DisplayMember = "Name";
            cbc.HeaderText = name2;
            

            return cbc;

        }

        //Method for making a ComboBox Column with Data
        private DataGridViewComboBoxColumn MakeComboBoxColumnWithData(string name1, string propertyName, List<string> data, string name2)
        {
            DataGridViewComboBoxColumn cbc = new DataGridViewComboBoxColumn();

            cbc.Name = name1;
            cbc.DataPropertyName = propertyName;
            cbc.DataSource = data; 
            cbc.ValueMember = "Id";
            cbc.DisplayMember = "Name";
            cbc.HeaderText = name2;



            return cbc;

        }

        //Method currently gets Category's
        //Method needs to add instances to the instance combobox
        //Need to figure out how to clear the instance and add the data
        private void PopulateAndSortInstances()
        {

            //Sets all Instance cells to "Please select a category"
            List<String> selectCategory = new List<String>();
                    selectCategory.Add("Please select a category");
                    Instance.DataSource = selectCategory;

                

            PerformanceCounterCategory instances;
            //DataGridViewComboBoxCell comboBoxCell = new DataGridViewComboBoxCell();

            String category;
            int col = 0;
            //First for loop gets the category
            for (int row = 0; row < dataGridView1.Rows.Count; row++)
            {
                category = (String)dataGridView1[col, row].Value;
                Console.WriteLine(category);
                Console.WriteLine("Category on Row: " + row + " " + category);
                DataGridViewColumn dc = dataGridView1.Columns[1];
                Console.WriteLine("dc" + dc);
                //Sets all other cells to READ-ONLY 
                /*
                foreach (DataGridViewColumn dc in dataGridView1.Columns)
                {
                    if (dc.Index.Equals(0) || dc.Index.Equals(1))
                    {
                        dc.ReadOnly = false;
                    }
                    else
                    {
                        dc.ReadOnly = true;
                    }
                }
                */

                //  Console.WriteLine(dataGridView1.Columns + "AAAAAA");


                //Uses the category to get the list of instances
                if (category != null && category.Length > 1)
                {
                    Console.WriteLine("Getting Instances");
                    instances = new PerformanceCounterCategory(category);
                    string[] varArray = instances.GetInstanceNames();
                    List<String> listOfInstances = new List<string>();
                    foreach (string instance in varArray)
                    {
                        listOfInstances.Add(instance);
                      //  Console.WriteLine("Instances: " + instance);
                       
                    }
                    /*
                    DataGridViewComboBoxCell comboCell = (DataGridViewComboBoxCell)dataGridView1[row, col];
                    //comboCell.DataSource = listOfInstances;
                    //comboCell.Items.Clear();
                    //comboCell.Items.AddRange(listOfInstances);

                    comboCell.DataSource = listOfInstances;
                    comboCell.DisplayMember = dataGridView1[col + 1, row].Value.ToString();
                    comboCell.ValueMember = listOfInstances.ToString();
                    dataGridView1[col + 1, row].Value = comboCell;
                    */
                    
                    //dataGridView1.Columns[1].ReadOnly = true;


                    //Console.WriteLine(dataGridView1.Rows[row].Cells[1].Value.ToString() + " AAAA");

                    dataGridView1.CurrentCell = dataGridView1.Rows[row].Cells[1];

                    DataGridViewCell cell = dataGridView1.Rows[row].Cells[1];

                  //  cell.ValueType = typeof(string);
                    cell.Value = CategoryData;


                    DataGridViewComboBoxCell newCell = new DataGridViewComboBoxCell();
                    List<String> cellList = new List<String>();

                    cellList.Add("Test");
                    cellList.Add("Test1");

                   // newCell.ValueType = typeof(string);
                    newCell.DataSource = cellList;
                    

                    //dataGridView1.CurrentCell = cell;
                    
                    


                    /*
                    DataGridViewCell cell = dataGridView1.Rows[row].Cells[0];
                    dataGridView1.CurrentCell = cell;
                    dataGridView1.BeginEdit(true);
                    */


                    //dataGridView1[col, row].Value = listOfInstances;
                    //this.dataGridView1.CurrentCell = this.dataGridView1[col+1, row];
                    //this.dataGridView1.CurrentCell.Value = "Test"; 




                    /*
                    //string[,] test = new string[,] { { "Test1", "Test2"}, {"Test3", "Test4"} };
                    List<List<String>> test = new List<List<String>>();
                    List<String> a = new List<String>();
                    a.Add("Test1");
                    List<String> b = new List<String>();
                    b.Add("Test2");

                    test.Add(a);
                    test.Add(b);


                    Instance.DataSource = test;        
                    */
                    /*
                    Console.WriteLine("List of Instances: " + listOfInstances);
                    //Sets all Instance cells to "Please select a category"
                    List<String> selectCategory = new List<String>();
                    //selectCategory.Add("Please select a category");
                    //Instance.DataSource = selectCategory;

                    DataGridViewComboBoxCell comboCell = (DataGridViewComboBoxCell)dataGridView1[row, col];
                    //comboCell.DataSource = listOfInstances;
                    //comboCell.Items.Clear();
                    //comboCell.Items.AddRange(listOfInstances);
                    
                    comboBoxCell.DataSource = listOfInstances;
                    comboBoxCell.DisplayMember = dataGridView1[col + 1, row].Value.ToString;
                    comboBoxCell.ValueMember = listOfInstances.ToString();
                    dataGridView1[col + 1, row].Value = comboBoxCell;
                    */
                    //DataGridViewComboBoxCell test = dataGridView1[col + 1, row].Value;



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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
            //Gets the Column Index
            int col = dataGridView1.CurrentCell.ColumnIndex;
            int row = dataGridView1.CurrentCell.RowIndex;

            int newCol = col - 1; 
            

            //Gets the Column Name
            String columnName = dataGridView1.Columns[col].Name;

            if (columnName == "Instance")
            {
                dataGridView1.CurrentCell = dataGridView1[newCol][row];

            }

            

            //Get Category Name

            

            //dataGridView1.CurrentCell.ColumnIndex.ToString();
            */
        }
    }
}
//Init method makes DataGrid able to add rows
//Find out how to make this work with my current code and combobox columns or change the method to have combobox columns
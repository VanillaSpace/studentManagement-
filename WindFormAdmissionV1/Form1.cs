using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsAdmissionV1
{
    public partial class Form1 : Form
    {
        int index;

        List<Student> myList = new List<Student>();

        public Form1()
        {
            InitializeComponent();
        }
        public  void ShowContent(List <Student> myList, ListBox listBox1)
        {
            this.listBox1.Items.Clear();

            if (this.myList.Capacity != 0)
            {
                foreach (Student item in this.myList)
                {
                    this.listBox1.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("... NO DATA.....");
                textBoxId.Focus();
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Student aStudent = new Student(); // create an object student
           
            aStudent.SetId(Convert.ToInt32(this.textBoxId.Text));
            aStudent.SetFn(this.textBoxFn.Text);
            aStudent.SetLn(this.textBoxLn.Text);

            //-------------3-------------
            ///////////////////////         
            aStudent.SetStatus((EnumStatus)this.comboBoxStatus.SelectedIndex);

           
            myList.Add(aStudent);

            this.buttonAdd.Enabled = false; //after adding a student disable the button Add to avoid 
            //to add again (in the list) the same student 
        }

        private void buttonDisplay_Click(object sender, EventArgs e)
        {

            ShowContent(this.myList, this.listBox1);            
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            textBoxId.Text = "";
            textBoxFn.Text = "";
            textBoxLn.Text = "";
            textBoxId.Focus();
            this.listBox1.Items.Clear();
           
            this.buttonAdd.Enabled = true; //enable the button Add (to add a new student to the list) 
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("... End of the application Windows Forms Admission Version 01.....");
            this.Close();
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = this.listBox1.SelectedIndex;
            MessageBox.Show("THE INDEX SELECTED IN THE listBox1 is : " + index  );

            this.textBoxId.Text = Convert.ToString(this.myList[index].GetId());
            this.textBoxFn.Text = this.myList[index].GetFn();
            this.textBoxLn.Text = this.myList[index].GetLn();

            //--------------2-------------
            ////////////
            this.comboBoxStatus.Text = Convert.ToString(this.myList[index].GetStatus());
            
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            this.myList.RemoveAt(index);
            ShowContent(this.myList, this.listBox1);            
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            this.myList[index].SetFn(this.textBoxFn.Text);
            this.myList[index].SetLn(this.textBoxLn.Text);

            //---- 4---

            this.myList[index].SetStatus((EnumStatus)this.comboBoxStatus.SelectedIndex);

        }

        // ------ 1---------
        ///
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach ( EnumStatus   element     in  Enum.GetValues( typeof(EnumStatus))    )
            {
                this.comboBoxStatus.Items.Add(element);
            }
         this.comboBoxStatus.Text =    Convert.ToString ( this.comboBoxStatus.Items[0]);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            bool found = false;
            Student currentStudents = new Student();
            if (this.myList.Capacity != 0)
            {
                foreach (Student item in this.myList)
                {
                    int tmp = Convert.ToInt32(this.textBoxSearch.Text);
                    if (tmp == item.GetId())
                    {
                        currentStudents = item;
                        found = true;
                    }
                    else
                    {
                        found = false;
                    }
                }
                if (found == true)
                {
                    MessageBox.Show("Found Student: " + currentStudents);
                }
                else
                {
                    MessageBox.Show("No Student Found.");
                }
            }

        }

        private void textBoxKey_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

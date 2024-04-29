using System;
using System.Data;
using System.Windows.Forms;

namespace To_Do_List_App
{
    public partial class ToDoList : Form
    {
        public ToDoList()
        {
            InitializeComponent();
        }

        private readonly DataTable _todoList = new DataTable();
        internal bool IsEditing;
        private DataRow CurrentRow => _todoList.Rows[toDoListView.CurrentCell.RowIndex];

        private void ToDoList_Load(object sender, EventArgs e)
        {
            _todoList.Columns.Add("Title");
            _todoList.Columns.Add("Description");
            toDoListView.DataSource = _todoList;
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            titleTextBox.Text = "";
            descriptionTextBox.Text = "";
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (toDoListView.CurrentCell != null)
            {
                IsEditing = true;
                titleTextBox.Text = CurrentRow.ItemArray[0].ToString();
                descriptionTextBox.Text = CurrentRow.ItemArray[1].ToString();
            }
            else
            {
                MessageBox.Show(@"Please select a task to edit.");
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (toDoListView.CurrentCell != null)
            {
                CurrentRow.Delete();
            }
            else
            {
                MessageBox.Show(@"Please select a task to delete.");
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (IsEditing)
            {
                CurrentRow["Title"] = titleTextBox.Text;
                CurrentRow["Description"] = descriptionTextBox.Text;
            }
            else
            {
                _todoList.Rows.Add(titleTextBox.Text, descriptionTextBox.Text);
            }
            titleTextBox.Text = "";
            descriptionTextBox.Text = "";
            IsEditing = false;
        }
    }
}
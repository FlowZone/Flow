using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flow
{
    public partial class EditItems : Form
    {
        public List<Item> returnItems;
        private List<Item> items;

        public EditItems(List<Item> existingItems = null)
        {
            items = existingItems ?? new List<Item>();
            InitializeComponent();
            updateTaskList();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            returnItems = items;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void Add_Item_Click(object sender, EventArgs e)
        {
            items.Add(new Item {Title = tb_title.Text, Task = tb_Task.Text});
            tb_title.Clear();
            tb_Task.Clear();
            updateTaskList();
        }

        private void updateTaskList()
        {
            Items.Items.Clear();
            foreach (var item in items)
            {
                Items.Items.Add(item.Title);
            }
        }

        private void Remove_Item_Click(object sender, EventArgs e)
        {
            items.Remove(items.Find(x => x.Title == Items.SelectedItem.ToString()));
            updateTaskList();
        }
    }

    public class Item
    {
        public string Title { get; set; }
        public string Task { get; set; }
    }
}

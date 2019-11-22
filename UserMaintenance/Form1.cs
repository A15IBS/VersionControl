using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintenance.Entities;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();
        public Form1()
        {
            InitializeComponent();
            lblFullName.Text = Resource1.FullName;
            
            btnAdd.Text = Resource1.Add;
            listUsers.DataSource = users;
            listUsers.ValueMember = "ID";
            listUsers.DisplayMember = "FullName";

            btnSave.Text = Resource1.Save;

            btnDelete.Text = Resource1.Delete;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
                FullName = txtFullName.Text,
                
            };
            users.Add(u);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName))
                {
                    sw.Write("ID - TeljesNév");
                    sw.WriteLine();
                    foreach (var item in users)
                    {
                        sw.Write(item.ID);
                        sw.Write(" - ");
                        sw.Write(item.FullName);
                        sw.WriteLine();
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Guid sID = (Guid)listUsers.SelectedValue;
            var ur = from x in users where x.ID == sID select x;
            users.Remove(ur.FirstOrDefault());
            
        }
    }
}

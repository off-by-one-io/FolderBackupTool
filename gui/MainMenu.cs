using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FolderBackupTool.gui
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void CreateBackupButton_Click(object sender, EventArgs e)
        {
            new CreateBackupMenu().Show();
        }

        private void RestoreBackupButton_Click(object sender, EventArgs e)
        {
            new RestoreBackupMenu().Show();
        }
    }
}

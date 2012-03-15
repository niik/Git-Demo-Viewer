using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LibGit2Sharp;
using System.Diagnostics;

namespace git_demo_viewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Repository Repository { get; set; }
        public GitViewModel Model { get; set; }

        public MainWindow()
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();

            this.Repository = new Repository(dialog.SelectedPath);
            //this.Repository = new Repository(@"e:\code\misc\demo2\.git");
            this.Model = new GitViewModel(this.Repository);
            this.DataContext = this.Model;

            InitializeComponent();
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (e.Key == Key.F5)
            {
                if ((e.KeyboardDevice.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
                    this.Model.Reload();
                else
                    this.Model.Refresh();
            }

            base.OnKeyUp(e);
        }

    }
}

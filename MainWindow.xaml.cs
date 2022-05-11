using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.IO;
using MessageBox = System.Windows.MessageBox;

namespace Lib
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void FolderBtn_Click(object sender, RoutedEventArgs e)
        {
            ItemListBox.Items.Clear();
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string vExtention;
                    if (GbaCheck.IsChecked == true)
                    {
                        vExtention = "*.gba";
                    }
                    else if (GbCheck.IsChecked == true)
                    {
                        vExtention = "*.gb";
                    }
                    else if (GbcCheck.IsChecked == true)
                    {
                        vExtention = "*.gbc";
                    }
                    else
                    {
                        vExtention = "*.gb";
                    }

                    string[] files = Directory.GetFiles(fbd.SelectedPath, vExtention, SearchOption.AllDirectories);

                    for (int i = 0; i < files.Length; i++)
                    {
                        ItemListBox.Items.Add(System.IO.Path.GetFileName(files[i]));
                        ItemListBox.Items.SortDescriptions.Add(
                            new System.ComponentModel.SortDescription("",
                            System.ComponentModel.ListSortDirection.Ascending));
                    }
                }
            }
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            
            ItemsFoundWindow SecWin = new ItemsFoundWindow();
            SecWin.ItemsBox.Items.Clear();

            for (int i = 0; i < ItemListBox.Items.Count; i++)
            {
                if (!string.IsNullOrEmpty(Search_InputBox.Text))
                {
                    if (ItemListBox.Items[i].ToString().Contains(Search_InputBox.Text)) {
                        SecWin.ItemsBox.Items.Add(ItemListBox.Items[i]);
                        SecWin.ItemsBox.Items.SortDescriptions.Add(
                            new System.ComponentModel.SortDescription("",
                            System.ComponentModel.ListSortDirection.Ascending));
                    }

                    SecWin.Show();
                }
                
            }
        }
    }
}

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

namespace Attestation
{
    /// <summary>
    /// Логика взаимодействия для AttestationPage.xaml
    /// </summary>
    public partial class AttestationPage : Page
    {
        List<RowTab> DATA = new List<RowTab>();

        public AttestationPage()
        {
            InitializeComponent();
        }

        private void DataGridMain_Loaded(object sender, RoutedEventArgs e)
        {
            //List<RowTab> result = new List<RowTab>();
            this.DATA.Clear();
            for(int i=0; i < 25; i++) {
                bool c = false;
                if (i % 2 == 0) c = true;
                this.DATA.Add(new RowTab(i+1, c, (88345634+i).ToString() ,(float)(i+0.5), (float)(i + 1.5), (float)(i + 2.5)));
            }
            DataGridMain.ItemsSource = this.DATA;

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RowTab row = (RowTab)DataGridMain.SelectedItem;
            int idx = DataGridMain.SelectedIndex;

            System.Windows.MessageBox.Show(row.Id.ToString());
            //DataGridMain.Items.RemoveAt(DataGridMain.SelectedIndex);
            this.DATA.RemoveAt(idx);
            DataGridMain.ItemsSource = null;
            DataGridMain.ItemsSource = this.DATA;
           
        }

        private void button_add_Click(object sender, RoutedEventArgs e)
        {
            this.DATA.Add(new RowTab( 1, true, (88345634).ToString(), (float)(2), (float)(2), (float)(2)));
            DataGridMain.ItemsSource = null;
            DataGridMain.ItemsSource = this.DATA;
        }
    }
}

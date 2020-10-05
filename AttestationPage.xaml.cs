using System;
using System.Collections.Generic;
using System.IO;
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
        public int idx; // индекс строки
        private Global global;

        public AttestationPage()
        {
            InitializeComponent();
            global = Global.getInstance();
        }

        private void DataGridMain_Loaded(object sender, RoutedEventArgs e)
        {
            //List<RowTab> result = new List<RowTab>();
            global.DATA.Clear();

            Image leftFoto;
            Image rightFoto;
            Image topFoto;
            
            for(int i=0; i < 26; i++) {
                bool c = false;

                leftFoto = getImage("C:/Projects/АРМ_ОТК/Resources/pexels-mark-plötz-2790396.jpg");
                rightFoto = getImage("C:/Projects/АРМ_ОТК/Resources/pexels-pixabay-258455.jpg");
                topFoto = getImage("C:/Projects/АРМ_ОТК/Resources/pexels-sergio-souza-3197995.jpg");
                
                if (i % 2 == 0)
                {
                    c = true;
                    leftFoto = null;
                    rightFoto = null;
                    topFoto = null;

                }
                global.DATA.Add(new RowTab(i+1, c, (88345634+i).ToString() ,(float)(i+0.5),
                    (float)(i + 1.5), (float)(i + 2.5), (Image)leftFoto, (Image)rightFoto, (Image)topFoto ));
            }
            DataGridMain.ItemsSource = global.DATA;

            
        }
        Image getImage(String im)
        {
            Image image = new Image();
            image.Width = 300;
            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri(im);
            logo.EndInit();
            image.Source = logo;
            return image;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /*
            RowTab row = (RowTab)DataGridMain.SelectedItem;
            int idx = DataGridMain.SelectedIndex;

            System.Windows.MessageBox.Show(row.Id.ToString());
            //DataGridMain.Items.RemoveAt(DataGridMain.SelectedIndex);
            this.DATA.RemoveAt(idx);
            DataGridMain.ItemsSource = null;
            DataGridMain.ItemsSource = this.DATA;
            */
            global.Idx = DataGridMain.SelectedIndex;
            RowTab row = global.DATA[global.Idx];
            if(row.LeftFoto != null & row.RightFoto != null & row.TopFoto != null)
            {
                ShowPhotos showPhotos = new ShowPhotos();
                showPhotos.ShowDialog();
            }
            else
            {
                System.Windows.MessageBox.Show("У строки {row.Id.ToString()} нет фотографий");
            }

        }

        private void button_add_Click(object sender, RoutedEventArgs e)
        {
            /*
            this.DATA.Add(new RowTab( 1, true, (88345634).ToString(), (float)(2), (float)(2), (float)(2)));
            DataGridMain.ItemsSource = null;
            DataGridMain.ItemsSource = this.DATA;
            */
        }
    }
}

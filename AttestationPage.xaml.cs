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
using System.Drawing;
using iTextSharp.text;
using System.Drawing.Imaging;

namespace Attestation
{
    public partial class AttestationPage : Page
    {
        System.Drawing.Image leftFoto;
        System.Drawing.Image rightFoto;
        System.Drawing.Image topFoto;
        public string Image1FromRowTab { set; get; }
        public string Image2FromRowTab { set; get; }
        public string Image3FromRowTab { set; get; }

        public int idx; // индекс строки
        private Global global;

        public AttestationPage()
        {
            InitializeComponent();
            global = Global.getInstance();
            Image1FromRowTab = "C:/Projects/АРМ_ОТК/ImageFromRowTab/Bitmap1.bmp";
            Image2FromRowTab = "C:/Projects/АРМ_ОТК/ImageFromRowTab/Bitmap2.bmp";
            Image3FromRowTab = "C:/Projects/АРМ_ОТК/ImageFromRowTab/Bitmap3.bmp";
        }

        private void DataGridMain_Loaded(object sender, RoutedEventArgs e)
        {
            global.DATA.Clear();
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
                    (float)(i + 1.5), (float)(i + 2.5), (System.Drawing.Image)leftFoto, 
                    (System.Drawing.Image)rightFoto, (System.Drawing.Image)topFoto ));
            }
            DataGridMain.ItemsSource = global.DATA;
        }
        System.Drawing.Image getImage(String im)
        {
            System.Drawing.Image image = System.Drawing.Image.FromFile(im);
            /*
            image.Width = 300;
            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri(im);
            logo.EndInit();
            image.Source = logo;
            */
            var ms = new MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            var bytes = ms.ToArray();
            var imageMemoryStream = new MemoryStream(bytes);
            System.Drawing.Image imgFromStream = System.Drawing.Image.FromStream(imageMemoryStream);
            return imgFromStream;

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
                //showPhotos.image1. = row.LeftFoto;
                row.LeftFoto.Save(Image1FromRowTab, System.Drawing.Imaging.ImageFormat.Jpeg);
                row.RightFoto.Save(Image2FromRowTab, System.Drawing.Imaging.ImageFormat.Jpeg);
                row.TopFoto.Save(Image3FromRowTab, System.Drawing.Imaging.ImageFormat.Jpeg);
                showPhotos.image1.Source = new BitmapImage(new Uri(Image1FromRowTab));
                showPhotos.image2.Source = new BitmapImage(new Uri(Image2FromRowTab));
                showPhotos.image3.Source = new BitmapImage(new Uri(Image3FromRowTab));
                showPhotos.ShowDialog();
            }
            else
            {
                System.Windows.MessageBox.Show("У строки " + row.Id.ToString() + " нет фотографий");
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

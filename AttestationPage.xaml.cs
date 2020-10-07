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
        //System.Drawing.Image leftFoto;
        //System.Drawing.Image rightFoto;
        //System.Drawing.Image topFoto;
        byte[] leftFoto;
        byte[] rightFoto;
        byte[] topFoto;
        //public string Image1FromRowTab { set; get; }
        //public string Image2FromRowTab { set; get; }
        //public string Image3FromRowTab { set; get; }
        public int idx; // индекс строки
        private Global global;
        public AttestationPage()
        {
            InitializeComponent();
            global = Global.getInstance();
            //Image1FromRowTab = "C:/Projects/АРМ_ОТК/ImageFromRowTab/Bitmap1.bmp";
            //Image2FromRowTab = "C:/Projects/АРМ_ОТК/ImageFromRowTab/Bitmap2.bmp";
            //Image3FromRowTab = "C:/Projects/АРМ_ОТК/ImageFromRowTab/Bitmap3.bmp";


        }
        private void DataGridMain_Loaded(object sender, RoutedEventArgs e)
        {
            global.DATA.Clear();
            for(int i=0; i < 26; i++) {
                bool c = false;
                /*
                leftFoto = getImage("C:/Projects/АРМ_ОТК/Resources/pexels-mark-plötz-2790396.jpg");
                rightFoto = getImage("C:/Projects/АРМ_ОТК/Resources/pexels-pixabay-258455.jpg");
                topFoto = getImage("C:/Projects/АРМ_ОТК/Resources/pexels-sergio-souza-3197995.jpg");
                */

                leftFoto = ImageToByteArray(System.Drawing.Image.FromFile("C:/Projects/АРМ_ОТК/Resources/pexels-mark-plötz-2790396.jpg"));
                rightFoto = ImageToByteArray(System.Drawing.Image.FromFile("C:/Projects/АРМ_ОТК/Resources/pexels-pixabay-258455.jpg"));
                topFoto = ImageToByteArray(System.Drawing.Image.FromFile("C:/Projects/АРМ_ОТК/Resources/pexels-sergio-souza-3197995.jpg"));

                if (i % 2 == 0)
                {
                    c = true;
                    leftFoto = null;
                    rightFoto = null;
                    topFoto = null;
                }
                global.DATA.Add(new RowTab(i+1, c, (88345634+i).ToString() ,(float)(i+0.5),
                    (float)(i + 1.5), (float)(i + 2.5), leftFoto, 
                    rightFoto, topFoto ));

                /*
                global.DATA.Add(new RowTab(i + 1, c, (88345634 + i).ToString(), (float)(i + 0.5),
                    (float)(i + 1.5), (float)(i + 2.5), (System.Drawing.Image)leftFoto,
                    (System.Drawing.Image)rightFoto, (System.Drawing.Image)topFoto));
                */
            }
            DataGridMain.ItemsSource = global.DATA;
        }
        /*
        System.Drawing.Image getImage(String im)
        {
            System.Drawing.Image image = System.Drawing.Image.FromFile(im);
            var ms = new MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            var bytes = ms.ToArray();
            var imageMemoryStream = new MemoryStream(bytes);
            System.Drawing.Image imgFromStream = System.Drawing.Image.FromStream(imageMemoryStream);
            return imgFromStream;

        }
        */
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /* 
            * Удаление строки из DataGrid 
            */
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
                /*
                //showPhotos.image1. = row.LeftFoto;
                row.LeftFoto.Save(Image1FromRowTab, System.Drawing.Imaging.ImageFormat.Jpeg); // запись в файл
                row.RightFoto.Save(Image2FromRowTab, System.Drawing.Imaging.ImageFormat.Jpeg);
                row.TopFoto.Save(Image3FromRowTab, System.Drawing.Imaging.ImageFormat.Jpeg);
                showPhotos.image1.Source = new BitmapImage(new Uri(Image1FromRowTab)); // передача из файла в элемент Image
                showPhotos.image2.Source = new BitmapImage(new Uri(Image2FromRowTab));
                showPhotos.image3.Source = new BitmapImage(new Uri(Image3FromRowTab));
                */


                /*
                byte[] bytes1 = ImageToByteArray(row.LeftFoto);
                byte[] bytes2 = ImageToByteArray(row.RightFoto);
                byte[] bytes3 = ImageToByteArray(row.TopFoto);
                showPhotos.image1.Source = ByteArraytoBitmap(bytes1);
                showPhotos.image2.Source = ByteArraytoBitmap(bytes2);
                showPhotos.image3.Source = ByteArraytoBitmap(bytes3);
                */
                showPhotos.image1.Source = ByteArraytoBitmap(leftFoto);
                showPhotos.image2.Source = ByteArraytoBitmap(rightFoto);
                showPhotos.image3.Source = ByteArraytoBitmap(topFoto);


                showPhotos.ShowDialog();
            }
            else
            {
                System.Windows.MessageBox.Show("У строки " + row.Id.ToString() + " нет фотографий");
                
            }
        }
        public static BitmapImage ByteArraytoBitmap(Byte[] byteArray)
        {
            MemoryStream stream = new MemoryStream(byteArray);
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = stream;
            bitmapImage.EndInit();
            return bitmapImage;
        }
        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
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

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}

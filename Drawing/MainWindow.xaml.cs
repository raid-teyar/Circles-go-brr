using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Timers;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Drawing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static byte alpha = 255;
        static byte R = 255 ;
        static byte G = 100;
        static byte B = 100;
        double bigRaduis = 10;
        double bigraduisscaling = 1;
        double raduisscaling = 1;
        double angel = 0;
        double rgb = 5;
        double x = 0;
        double speed = 50;
        double y = 0;
        DispatcherTimer timer = new DispatcherTimer();
        Point center = new Point(1000/2, 600/2);
        private double thickness = 0.5;
        double thicknessscaling = 0.5;
        private int counter = 1;
        private double raduis;

        public MainWindow()
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromMilliseconds(speed);

            timer.Tick += Start;
           
        }

        private void Start(object sender, EventArgs e)
        {
            if(R == 255 && B == 100 && G != 255)
            {
                G = (byte)(G + rgb);
            }
            if(G == 255 && B == 100 && R != 100)
            {
                R = (byte)(R - rgb);
            }
            if(R == 100 && G == 255 && B != 255)
            {
                B = (byte)(B + rgb);
            }
            if (R == 100 && B == 255 && G != 100)
            {
                G = (byte)(G - rgb);
            }
            if (G == 100 && B == 255 && R != 255)
            {
                R = (byte)(R + rgb);
            }
            if (G == 100 && R == 255 && B != 100)
            {
                B = (byte)(B - rgb);
            }            

            if(counter == 1)
            {
                timer.Interval = TimeSpan.FromMilliseconds(sliderhoho.Value);
                raduis = Convert.ToDouble(raduisText.Text);
                bigRaduis = Convert.ToDouble(bigRaduisText.Text);
                bigraduisscaling = Convert.ToDouble(ScalingbigRaduisText.Text);
                raduisscaling = Convert.ToDouble(ScalingraduisText.Text);
                thicknessscaling = Convert.ToDouble(thicknessText.Text);
                rgb = Convert.ToDouble(rgbText.Text);

            }

            counter++;
            thickness = thickness + thicknessscaling;

            center.X = center.X + x;
            center.Y = center.Y + y;
            x = Math.Cos(angel) * bigRaduis;
            y = Math.Sin(angel) * bigRaduis;
            angel++;
            bigRaduis = bigRaduis + bigraduisscaling;
            raduis = raduis + raduisscaling;
            Brush colore = new SolidColorBrush(Color.FromArgb(alpha, R, G, B));
            CreatShape(center.X, center.Y, raduis, colore, thickness);
        }

        void CreatShape(double X,double Y,double raduis,Brush colore,double thickness)
        {
                Ellipse ellipse = new Ellipse()
            {
                StrokeThickness = thickness,
                Stroke = colore,
                Height = raduis,
                Width = raduis
            };
          
            Point position = new Point(X, Y);
            SetPosition(ellipse, position);
            myCanvas.Children.Add(ellipse);             
        }

        void SetPosition(Shape shape,Point position)
        {
            Canvas.SetTop(shape, position.Y - shape.Height/2);
            Canvas.SetLeft(shape, position.X - shape.Width/2);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            counter = 1;
            thickness = 0.5;
            raduis = Convert.ToDouble(raduisText.Text);
            bigRaduis = Convert.ToDouble(bigRaduisText.Text);
            x = 0;
            y = 0;
            angel = 0;
            center = new Point(1000 / 2 - bigRaduis/2, 600 / 2 - bigRaduis);
           
            timer.Start();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            myCanvas.Children.Clear();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TaShu.Controls
{
    /// <summary>
    /// Instrument.xaml 的交互逻辑
    /// </summary>
    public partial class Instrument : UserControl
    {
        //依赖属性
        public int Value
        {
            get
            {
                return (int)this.GetValue(ValueProperty);
            }
            set
            {
                this.SetValue(ValueProperty, value);
            }
        }
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(int), typeof(Instrument), new PropertyMetadata(default(int), new PropertyChangedCallback(OnPropertyChanged)));

        public int MinVal
        {
            get { return (int)GetValue(MinValProperty); }
            set { SetValue(MinValProperty, value); }
        }

        public static readonly DependencyProperty MinValProperty = DependencyProperty.Register("MinVal", typeof(int), typeof(Instrument), new PropertyMetadata(default(int), new PropertyChangedCallback(OnPropertyChanged)));

        public int MaxVal
        {
            get { return (int)GetValue(MaxValProperty); }
            set { SetValue(MaxValProperty, value); }
        }

        public static readonly DependencyProperty MaxValProperty = DependencyProperty.Register("MaxVal", typeof(int), typeof(Instrument), new PropertyMetadata(default(int), new PropertyChangedCallback(OnPropertyChanged)));

        //专业的叫法Interval,大格子数量
        public int ScaleCountArea
        {
            get { return (int)GetValue(ScaleCountAreaProperty); }
            set { SetValue(ScaleCountAreaProperty, value); }
        }

        public static readonly DependencyProperty ScaleCountAreaProperty = DependencyProperty.Register("ScaleCountArea", typeof(int), typeof(Instrument), new PropertyMetadata(default(int), new PropertyChangedCallback(OnPropertyChanged)));

        //刻度/刻度值/小圈的颜色
        public Brush ScaleBackground
        {
            get { return (Brush)GetValue(ScaleBackgroundProperty); }
            set { SetValue(ScaleBackgroundProperty, value); }
        }

        public static readonly DependencyProperty ScaleBackgroundProperty =
            DependencyProperty.Register("ScaleBackground", typeof(Brush), typeof(Instrument), new PropertyMetadata(default(Brush), new PropertyChangedCallback(OnPropertyChanged)));

        //面板颜色
        public Brush PlateBackground
        {
            get { return (Brush)GetValue(PlateBackgroundProperty); }
            set { SetValue(PlateBackgroundProperty, value); }
        }

        public static readonly DependencyProperty PlateBackgroundProperty =
            DependencyProperty.Register("PlateBackground", typeof(Brush), typeof(Instrument), new PropertyMetadata(default(Brush)));



        public int ScalTextSize
        {
            get { return (int)GetValue(ScalTextSizeProperty); }
            set { SetValue(ScalTextSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ScalTextSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ScalTextSizeProperty =
            DependencyProperty.Register("ScalTextSize", typeof(int), typeof(Instrument), new PropertyMetadata(default(int), new PropertyChangedCallback(OnPropertyChanged)));




        public static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                (d as Instrument).Refresh();
            }
            catch (Exception ex)
            {

            }
        }

        public Instrument()
        {
            InitializeComponent();
            this.SizeChanged += Instrument_SizeChanged;
        }

        private void Instrument_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double mixSize = Math.Min(this.RenderSize.Width, this.RenderSize.Height);
            this.backEllipse.Width = mixSize;
            this.backEllipse.Height = mixSize;

        }

        private void Refresh()
        {

            double radius = this.backEllipse.Width / 2;
            if (double.IsNaN(radius))
            {
                return;
            }
            this.mainCanvas.Children.Clear();

            double min = this.MinVal;
            double max = this.MaxVal;
            int scaleCountArea = this.ScaleCountArea;
            double step = 270.0 / (max - min);
            //添加一圈刻度
            for (int i = 0; i <= max - min; i++)
            {
                Line lineScale = new Line();
                //if (i % scaleCountArea == 0)
                //{
                //    lineScale.X1 = radius - (radius - 40) * Math.Cos((i * step - 45) * Math.PI / 180);
                //    lineScale.Y1 = radius - (radius - 40) * Math.Sin((i * step - 45) * Math.PI / 180);
                //}
                //else
                {
                    //X1,Y1点在里面,X2,Y2点在外面
                    lineScale.X1 = radius - (radius - 10) * Math.Cos((i * step - 45) * Math.PI / 180);
                    lineScale.Y1 = radius - (radius - 10) * Math.Sin((i * step - 45) * Math.PI / 180);
                }
                lineScale.X2 = radius - (radius - 8) * Math.Cos((i * step - 45) * Math.PI / 180);
                lineScale.Y2 = radius - (radius - 8) * Math.Sin((i * step - 45) * Math.PI / 180);

                lineScale.Stroke = this.ScaleBackground;
                lineScale.StrokeThickness = 1;

                this.mainCanvas.Children.Add(lineScale);
            }

            double longStep = 270.0 / this.ScaleCountArea;
            //增加长刻度
            for (int i = 0; i <= scaleCountArea; i++)
            {
                Line lineScale = new Line();
                lineScale.X1 = radius - (radius - 20) * Math.Cos((i * longStep - 45) * Math.PI / 180);
                lineScale.Y1 = radius - (radius - 20) * Math.Sin((i * longStep - 45) * Math.PI / 180);

                lineScale.X2 = radius - (radius - 8) * Math.Cos((i * longStep - 45) * Math.PI / 180);
                lineScale.Y2 = radius - (radius - 8) * Math.Sin((i * longStep - 45) * Math.PI / 180);

                lineScale.Stroke = this.ScaleBackground;
                lineScale.StrokeThickness = 1;

                this.mainCanvas.Children.Add(lineScale);

                TextBlock textBlock = new TextBlock();
                textBlock.Width = 34;
                textBlock.TextAlignment = TextAlignment.Center;
                textBlock.FontSize = this.ScalTextSize;
                textBlock.Foreground = this.ScaleBackground;
                textBlock.Text = ((max - min) / scaleCountArea * (i - 1)).ToString();
                Canvas.SetLeft(textBlock, radius - (radius - 36) * Math.Cos((i * longStep - 45) * Math.PI / 180) - 17);
                Canvas.SetTop(textBlock, radius - (radius - 36) * Math.Sin((i * longStep - 45) * Math.PI / 180) - 10);
                this.mainCanvas.Children.Add(textBlock);
            }

            //小圈
            string sData = "M{0} {1} A{0} {0} 0 1 1 {1} {2}";
            sData = string.Format(sData, radius / 2, radius, radius * 1.5);
            var converter = TypeDescriptor.GetConverter(typeof(Geometry));
            this.circle.Data = (Geometry)converter.ConvertFrom(sData);
            this.circle.Stroke = this.ScaleBackground;

            //指针
            //this.rtPointer.Angle = this.Value * step - 45;
            DoubleAnimation da = new DoubleAnimation((this.Value - min) * step - 45, new Duration(TimeSpan.FromMilliseconds(300)));
            this.rtPointer.BeginAnimation(RotateTransform.AngleProperty, da);
            sData = "M{0} {1},{1} {2},{1} {3}";
            sData = string.Format(sData, radius * 0.3, radius, radius - 5, radius + 5);
            this.pointer.Data = (Geometry)converter.ConvertFrom(sData);

        }
    }
}

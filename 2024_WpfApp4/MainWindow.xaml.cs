using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace _2024_WpfApp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Color strokeColor = Colors.Black;
        Color fillColor = Colors.Aqua;
        Brush strokeBrush = Brushes.Black;
        Brush fillBrush = Brushes.Aqua;
        string shape;
        int strokeThickness = 1;
        Point start, dest;
        public MainWindow()
        {
            InitializeComponent();
            strokeColorPicker.SelectedColor = strokeColor;
            fillColorPicker.SelectedColor = fillColor;
        }

        private void myCanvas_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            myCanvas.Cursor = Cursors.Pen;
        }

        private void myCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            dest = e.GetPosition(myCanvas);
            statusPoint.Content = $"({Convert.ToInt32(start.X)}, {Convert.ToInt32(start.Y)}) - ({Convert.ToInt32(dest.X)}, {Convert.ToInt32(dest.Y)})";
        }

        private void myCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var brush = new SolidColorBrush(strokeColor);
            Line line = new Line
            {
                X1 = start.X,
                Y1 = start.Y,
                X2 = dest.X,
                Y2 = dest.Y,
                Stroke = brush,
                StrokeThickness = 2
            };
            myCanvas.Children.Add(line);
        }

        private void strokeColorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            strokeColor = strokeColorPicker.SelectedColor.Value;
        }

        private void fillColorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            fillColor = fillColorPicker.SelectedColor.Value;
        }

        private void ShapeButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as RadioButton;
            shape = button.Tag.ToString();
            MessageBox.Show(shape);
        }

        private void EraseButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void strokeThicknessSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            strokeThickness = (int)strokeThicknessSlider.Value;
        }

        private void myCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            start = e.GetPosition(myCanvas);
            myCanvas.Cursor = Cursors.Cross;
        }
    }
}
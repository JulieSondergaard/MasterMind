using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MasterMind
{
    /// <summary>
    /// Interaction logic for RoundButtonUserControl.xaml
    /// </summary>
    public partial class RoundButtonUserControl : UserControl
    {

       
        private SolidColorBrush backgroundColor;

        public SolidColorBrush BackgroundColor
        {
            get { return backgroundColor; }
            set { backgroundColor = value;
                RoundButton.Background = value; }
        }



        public RoundButtonUserControl()
        {
            InitializeComponent();
            this.DataContext = this;
            
        }

        //private void RoundButton_Click(object sender, RoutedEventArgs e)
        //{
        //    Debug.WriteLine(GameManager.currentColor);
        //    BackgroundColor = (SolidColorBrush)GameManager.currentColor;


        //}

    }
}

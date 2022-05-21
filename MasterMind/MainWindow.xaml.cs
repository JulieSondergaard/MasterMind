using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace MasterMind
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 



    public partial class MainWindow : Window
    {
        GameManager game = new GameManager();
        bool[] isColorSet = new bool[4];
        private bool colorSelected = false;

        private string[] Colors = new string[8] { "#FF800080", "#FF000000", "#FF8FBC8F", "#FFFF0000", "#FFFFC0CB", "#FFFFFF00", "#FF0000FF", "#FFFFA500" };
        public string[] SecretColors = new string[4];

        private Button[] currentRow = new Button[4];
        private Button[] currentPinRow = new Button[4];

        int[] correctPinPlaceI = new int[4] { -1, -1, -1, -1 };
        int[] correctPinPlaceJ = new int[4] { -1, -1, -1, -1 };
        Random random = new Random();

        private int round = 1;

        Button[] row1;
        Button[] row2;
        Button[] row3;
        Button[] row4;
        Button[] row5;

        Button[] pinRow1;
        Button[] pinRow2;
        Button[] pinRow3;
        Button[] pinRow4;
        Button[] pinRow5;
        public MainWindow()
        {

            InitializeComponent();
            row1 = new Button[4] { Button51, Button52, Button53, Button54, };
            row2 = new Button[4] { Button41, Button42, Button43, Button44, };
            row3 = new Button[4] { Button31, Button32, Button33, Button34, };
            row4 = new Button[4] { Button21, Button22, Button23, Button24, };
            row5 = new Button[4] { Button11, Button12, Button13, Button14, };

            pinRow1 = new Button[4] { Pin51, Pin52, Pin53, Pin54 };
            pinRow2 = new Button[4] { Pin41, Pin42, Pin43, Pin44 };
            pinRow3 = new Button[4] { Pin31, Pin32, Pin33, Pin34 };
            pinRow4 = new Button[4] { Pin21, Pin22, Pin23, Pin24 };
            pinRow5 = new Button[4] { Pin11, Pin12, Pin13, Pin14 };
            
            SetSecretColors();
            Round1();
        }

        public void SetSecretColors()
        {
            int randomColor1 = random.Next(0, 8);
            SecretColors[0] = Colors[randomColor1];
            SecretColor1.Background = (SolidColorBrush)new BrushConverter().ConvertFromString(SecretColors[0]);

            int randomColor2 = random.Next(0, 8);
            SecretColors[1] = Colors[randomColor2];
            SecretColor2.Background = (SolidColorBrush)new BrushConverter().ConvertFromString(SecretColors[1]);

            int randomColor3 = random.Next(0, 8);
            SecretColors[2] = Colors[randomColor3];
            SecretColor3.Background = (SolidColorBrush)new BrushConverter().ConvertFromString(SecretColors[2]);

            int randomColor4 = random.Next(0, 8);
            SecretColors[3] = Colors[randomColor4];
            SecretColor4.Background = (SolidColorBrush)new BrushConverter().ConvertFromString(SecretColors[3]);

            Debug.WriteLine(SecretColors[0]);
            Debug.WriteLine(SecretColors[1]);
            Debug.WriteLine(SecretColors[2]);
            Debug.WriteLine(SecretColors[3]);
        }

        public void CheckRow(Button[] row, Button[] pinRow)
        {             
            int firstCount = CheckExactColorPin(row, pinRow);
            PlaceExactPin(pinRow, firstCount);

            int finalCount = firstCount;
            finalCount += CheckCorrectColorPin(row, pinRow);
            PlaceCorrectPin(pinRow, finalCount, firstCount);
        }

        public void PlaceExactPin(Button[] pinRow, int count)
        {
            for (int i = 0; i < count; i++)
            {
                pinRow[i].Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FF000000");
            }
        }
        
        public void PlaceCorrectPin(Button[] pinRow, int finalCount, int firstCount)
        {
            
            for (int i = firstCount; i < finalCount; i++)
            {
                pinRow[i].Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFFF0000");
            }
        }
        
        public int CheckExactColorPin(Button[] row, Button[] pinRow)
        {

            // Checking for correct pins
            int correctPin = 0;
            
            for (int i = 0; i < row.Length; i++)
            {
                if (row[i].Background.ToString() == SecretColors[i])
                {
                    correctPin++;
                    correctPinPlaceI[i] = 1;
                    correctPinPlaceJ[i] = 1;

                }
            }
            if (correctPin == 4)
            {
                SecretColor1.IsEnabled = true;
                SecretColor2.IsEnabled = true;
                SecretColor3.IsEnabled = true;
                SecretColor4.IsEnabled = true;
            }
            Debug.WriteLine(correctPin);
            return correctPin;
        }

        public int CheckCorrectColorPin(Button[] row, Button[] pinRow)
        { 
            int correctColor = 0;
                      
            
            // Checking for correct colors
            for (int i = 0; i < row.Length; i++)
            {
                for (int j = 0; j < pinRow.Length; j++)
                {
                    if ((i != j) && (correctPinPlaceI[i] != 1) && (correctPinPlaceJ[j] != 1))
                    {
                        if (row[i].Background.ToString() == SecretColors[j])
                        {
                            correctColor++;
                            correctPinPlaceI[i] = 1;
                            correctPinPlaceJ[j] = 1;
                            j = 5;
                        }
                    }
                }
            }
            Debug.Write(correctColor);
            return correctColor;

        }     

        public void Round1()
        {
            if (round == 1)
            {
                currentRow = row1;
                currentPinRow = pinRow1;

                foreach (Button button in row1)
                {
                    button.IsEnabled = true;
                    button.Click += Button_Click;
                }
            }
        }

        public void Round2()
        {
            if (round == 2)
            {
                currentRow = row2;
                currentPinRow = pinRow2;

                foreach (Button button in row2)
                {
                    button.IsEnabled = true;
                    button.Click += Button_Click;
                }
            }
        }
        public void Round3()
        {

            if (round == 3)
            {
                currentRow = row3;
                currentPinRow = pinRow3;

                foreach (Button button in row3)
                {

                    button.IsEnabled = true;
                    button.Click += Button_Click;
                }



            }



        }
        public void Round4()
        {

            if (round == 4)
            {
                currentRow = row4;
                currentPinRow = pinRow4;

                foreach (Button button in row4)
                {

                    button.IsEnabled = true;
                    button.Click += Button_Click;
                }



            }



        }

        public void Round5()
        {


            if (round == 5)
            {
                currentRow = row5;
                currentPinRow = pinRow5;

                foreach (Button button in row5)
                {
                    button.IsEnabled = true;
                    button.Click += Button_Click;
                }


            }


        }


        public void RemoveClick(Button button)
        {
            button.Click -= Button_Click;

        }


        private void Color_Click(object sender, RoutedEventArgs e)
        {
            Button button = e.Source as Button;
            game.SetColor(button.Background);
            colorSelected = true;

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (colorSelected == true)
            {
                Button button = e.Source as Button;
                button.Background = game.GetColor();

                for (int i = 0; i < isColorSet.Length; i++)
                {
                    isColorSet[i] = true;
                }
            }
        }

        private void roundCount()
        {
            if (isColorSet[0] == true && isColorSet[1] == true && isColorSet[2] == true && isColorSet[3] == true)
            {
                round++;
            }
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            CheckRow(currentRow, currentPinRow);
            roundCount();

            for (int i = 0; i < isColorSet.Length; i++)
            {
                if (isColorSet[i] == true)
                {

                    isColorSet[i] = false;
                    if (round == 2)
                    {


                        RemoveClick(row1[i]);

                        Round2();



                    }
                    if (round == 3)
                    {


                        
                            RemoveClick(row2[i]);
                        
                        Round3();


                    }
                    if (round == 4)
                    {
                       
                            RemoveClick(row3[i]);
                        
                        Round4();


                    }
                    if (round == 5)
                    {
                        
                            RemoveClick(row4[i]);
                        
                        Round5();

                    }


                }
            }


        }


    }


}


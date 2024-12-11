namespace Calc4GH
{
    public partial class Form1 : Form
    {
        // bufor na to co znikn�o z wy�wietlacza
        float buffer = 0;
        // zapami�tana "zaleg�a" operacja
        char operation = ' ';
        // Flaga, kt�ra m�wi, czy wynik zosta� ju� obliczony
        bool resultShown = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonPressed(object sender, EventArgs e)
        {
            // Je�li wynik zosta� ju� pokazany, resetujemy ekran przed wpisaniem nowej liczby
            if (resultShown)
            {
                displayTextBox.Text = string.Empty;
                resultShown = false;
            }

            int number = int.Parse(((Button)sender).Text);
            displayTextBox.Text += number;
        }

        private void ClearDisplay(object sender, EventArgs e)
        {
            displayTextBox.Text = String.Empty;
            buffer = 0;
            operation = ' ';
        }

        private void FunctionButtonPressed(object sender, EventArgs e)
        {
            // Je�eli nie ma zapisanej operacji, zapisujemy operacj�
            if (operation == ' ')
            {
                buffer = float.Parse(displayTextBox.Text);  // Przechowujemy liczb� w buforze
                displayTextBox.Text = string.Empty;
                operation = ((Button)sender).Text[0]; // Zapisujemy operacj�
            }
            else
            {
                // Wykonujemy operacj� na poprzednim buforze i obecnym wy�wietlaczu
                PerformOperation();
                // Po wykonaniu operacji, zapisujemy now� operacj�
                operation = ((Button)sender).Text[0];
                resultShown = false;
            }
        }

        private void ShowResult(object sender, EventArgs e)
        {
            // Wykonanie operacji i wy�wietlenie wyniku
            PerformOperation();
            // Reset operacji, poniewa� u�ytkownik widzi wynik
            operation = ' ';
            resultShown = true;
        }

        private void PerformOperation()
        {
            // Wykonanie operacji w zale�no�ci od tego, jaki operator jest zapisany w zmiennej 'operation'
            switch (operation)
            {
                case '+':
                    buffer += float.Parse(displayTextBox.Text);
                    break;
                case '-':
                    buffer -= float.Parse(displayTextBox.Text);
                    break;
                case '*':
                    buffer *= float.Parse(displayTextBox.Text);
                    break;
                case '/':
                    // Sprawdzamy, czy nie dzielimy przez 0
                    if (float.Parse(displayTextBox.Text) == 0)
                    {
                        displayTextBox.Text = "B��d: Dzielenie przez 0";
                        return;
                    }
                    buffer /= float.Parse(displayTextBox.Text);
                    break;
                default:
                    break;
            }

            // Wy�wietlamy wynik w TextBoxie
            displayTextBox.Text = buffer.ToString();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            // Odejmowanie
            if (operation == ' ')
            {
                buffer = float.Parse(displayTextBox.Text);
                displayTextBox.Text = String.Empty;
                operation = '-';
            }
            else
            {
                PerformOperation();
                operation = '-';
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            // Mno�enie
            if (operation == ' ')
            {
                buffer = float.Parse(displayTextBox.Text);
                displayTextBox.Text = String.Empty;
                operation = '*';
            }
            else
            {
                PerformOperation();
                operation = '*';
            }
        }

        // Dodajemy metod� obs�uguj�c� dzielenie
        private void button16_Click(object sender, EventArgs e)
        {
            // Dzielenie
            if (operation == ' ')
            {
                buffer = float.Parse(displayTextBox.Text);
                displayTextBox.Text = String.Empty;
                operation = '/';
            }
            else
            {
                PerformOperation();
                operation = '/';
            }
        }
    }
}

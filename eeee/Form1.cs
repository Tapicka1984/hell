using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace eeee
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Dictionary<int, bool> EratosthenesSieveAlgorithm(int max)
        {
            Dictionary<int, bool> numbers = new Dictionary<int, bool>();

            for (int i = 2; i <= max; i++)
            {
                numbers[i] = true;
            }

            for (int key = 2; key <= max; key++)
            {
                if (numbers[key])
                {
                    for (int i = key * key; i <= max; i += key)
                    {
                        if (numbers.ContainsKey(i))
                        {
                            numbers[i] = false;
                        }
                    }
                }
            }

            return numbers;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int max))
            {
                var primes = EratosthenesSieveAlgorithm(max);

                string primeNumbers = "";
                foreach (var kvp in primes)
                {
                    if (kvp.Value)
                    {
                        primeNumbers += kvp.Key + " ";
                    }
                }

                MessageBox.Show("Primes up to " + max + ":\n" + primeNumbers);
            }
            else
            {
                MessageBox.Show("Neplatné číslo v TextBoxu.");
            }
        }
    }
}

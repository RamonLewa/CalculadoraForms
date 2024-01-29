using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CalculadoraForms
{
    public partial class Calculadora : Form
    {
        decimal calculo;
        bool adicao = false;
        bool subtracao = false;
        bool multiplicacao = false;
        bool divisao = false;
        bool resultado = false;

        public Calculadora()
        {
            InitializeComponent();
        }

        private void btnUm_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "1";
            txtOperacao.Text += "1";
        }

        private void btnDois_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "2";
            txtOperacao.Text += "2";
        }

        private void btnTres_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "3";
            txtOperacao.Text += "3";
        }

        private void btnQuatro_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "4";
            txtOperacao.Text += "4";
        }

        private void btnCinco_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "5";
            txtOperacao.Text += "5";
        }

        private void btnSeis_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "6";
            txtOperacao.Text += "6";
        }

        private void btnSete_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "7";
            txtOperacao.Text += "7";
        }

        private void btnOito_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "8";
            txtOperacao.Text += "8";
        }

        private void btnNove_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "9";
            txtOperacao.Text += "9";
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "0";
            txtOperacao.Text += "0";
        }

        private void btnVirgula_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text == "")
            {
                txtOperacao.Text += "0,";
                txtResultado.Text += "0,";
            } else if (txtResultado.Text[txtResultado.Text.Length - 1] == ','
                      || txtResultado.Text.Contains(","))
            {
                txtOperacao.Text += "";
                txtResultado.Text += "";
            } else
            {
                txtResultado.Text += ",";
                txtOperacao.Text += ",";
            }
        }
        private void btnAdicao_Click(object sender, EventArgs e)
        {
            try
            {
                calculo = decimal.Parse(txtResultado.Text);
                txtOperacao.Text += "+";
                txtResultado.Text = "";
                adicao = true;
                subtracao = false;
                multiplicacao = false;
                divisao = false;
            }
            catch (Exception) { }
        }
        private void btnSubtracao_Click(object sender, EventArgs e)
        {
            try
            {
                calculo = decimal.Parse(txtResultado.Text);
                txtOperacao.Text += "-";
                txtResultado.Text = "";

                adicao = false;
                subtracao = true;
                multiplicacao = false;
                divisao = false;
            }
            catch (Exception) { }
        }

        private void btnMultiplicacao_Click(object sender, EventArgs e)
        {
            try
            {
                calculo = decimal.Parse(txtResultado.Text);
                txtOperacao.Text += "*";
                txtResultado.Text = "";

                adicao = false;
                subtracao = false;
                multiplicacao = true;
                divisao = false;
            }
            catch (Exception) { }
        }

        private void btnDivisao_Click(object sender, EventArgs e)
        {
            try
            {
                calculo = decimal.Parse(txtResultado.Text);
                txtOperacao.Text += "/";
                txtResultado.Text = "";

                adicao = false;
                subtracao = false;
                multiplicacao = false;
                divisao = true;
            }
            catch (Exception) { }
        }

        private void btnPorcentagem_Click(object sender, EventArgs e)
        {
            if (subtracao == true)
            {
                double valor1 = Convert.ToDouble(calculo);
                double porcentagem = Convert.ToDouble(txtResultado.Text) / 100;
                txtResultado.Text = Convert.ToString(valor1 - (porcentagem * valor1));
                txtOperacao.Text += "% =";
                txtOperacao.Text += txtResultado.Text;
            }

            if (adicao == true)
            {
                try
                {
                    double valor1 = Convert.ToDouble(calculo);
                    double porcentagem = Convert.ToDouble(txtResultado.Text) / 100;
                    txtResultado.Text = Convert.ToString(valor1 + (porcentagem * valor1));
                    txtOperacao.Text += "% =";
                    txtOperacao.Text += txtResultado.Text;
                }
                catch (Exception) 
                { 

                }
            }
        }

        private void btnRaiz_Click(object sender, EventArgs e)
        {
            try
            {
                double x = Convert.ToDouble(txtResultado.Text);
                if (x <= 0) {
                    MessageBox.Show("Tentativa de divisão por zero");
                    txtOperacao.Text = "";
                    txtResultado.Text = "";
                } else
                {
                    x = Math.Sqrt(x);
                    txtResultado.Text = x.ToString();
                    txtOperacao.Text += "√ =";
                    txtOperacao.Text += x.ToString();
                }
            }
            catch (Exception) { }
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            if (txtOperacao.Text.Length > 0
                && txtOperacao.Text[txtOperacao.Text.Length - 1] != '='
                && txtOperacao.Text[txtOperacao.Text.Length - 1] != '+'
                && txtOperacao.Text[txtOperacao.Text.Length - 1] != '-'
                && txtOperacao.Text[txtOperacao.Text.Length - 1] != '*'
                && txtOperacao.Text[txtOperacao.Text.Length - 1] != '/')
            {
                try
                {
                    resultado = true;
                    if (adicao == true)
                    {
                        txtResultado.Text = Convert.ToString(Convert.ToDecimal(txtResultado.Text) + calculo);
                    }

                    if (subtracao == true)
                    {
                        txtResultado.Text = Convert.ToString(calculo - Convert.ToDecimal(txtResultado.Text));
                        txtOperacao.Text += txtResultado.Text + " ";
                    }

                    if (multiplicacao == true)
                    {
                        txtResultado.Text = Convert.ToString(decimal.Parse(txtResultado.Text) * calculo);
                        txtOperacao.Text += txtResultado.Text + " ";
                    }

                    if (divisao == true)
                    {
                        try
                        {
                            txtResultado.Text = Convert.ToString(calculo / decimal.Parse(txtResultado.Text));
                            txtOperacao.Text += txtResultado.Text + " ";
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Tentativa de divisão por zero");
                            txtOperacao.Text = "";
                            txtResultado.Text = "";
                        }
                } else
                {
                    txtOperacao.Text += "";
                    txtResultado.Text += "";
                }
              
                } catch (Exception)
                {

                } 
            }
        }
        

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtResultado.Text = "";
            txtOperacao.Text = "";
            calculo = 0;
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            try
            {
                string Apagar = txtResultado.Text;
                Apagar = Apagar.Remove(Apagar.Length - 1);
                txtResultado.Text = Apagar;
                txtOperacao.Text = Apagar;
            }
            catch (Exception) { }
            {

            }
        }
    }
}

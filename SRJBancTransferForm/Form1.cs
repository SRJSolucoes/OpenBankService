using BankService;
using BankService.Entities;
using BankService.Interfaces;
using BankService.Services;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Windows.Forms;

namespace SRJBancTransferForm
{
    public partial class Form1 : Form
    {
        private readonly ILogger<Worker> _logger;

        private readonly IBankService BankService = new APIBankService();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TelaValida())
            {
                lblMsg.Visible = true;

                IOperadora Operator = new SRJService(tbUsuarioSRJ.Text,
                                                     tbSenhaSRJ.Text);

                IBank Bank = new QeshServices(tbUsuarioT28.Text,
                                              tbSenhaT28.Text,
                                              tbSenha4Dig.Text);

                var resultado = new ResultadoProcessamento();
                resultado.Horario = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                DayOfWeek dayOfWeek = DateTime.Now.DayOfWeek;

                if ((dayOfWeek != DayOfWeek.Saturday) && (dayOfWeek != DayOfWeek.Sunday))
                {
                    try
                    {
                        //_logger.LogInformation("Worker executando em: {time}", DateTimeOffset.Now);

                        // Fazer uma rotina de Schedule disso, para executar quantas vezes for schedulado por dia
                        BankService.MakeDayTransfers(_logger, Operator, Bank);

                        resultado.Status = "Success";

                        //await Task.Delay(
                        //    _serviceConfigurations.Intervalo, stoppingToken);

                        string jsonResultado = JsonConvert.SerializeObject(resultado);
                        lblMsg.Visible = false;
                    }
                    catch (Exception ex)
                    {
                        lblMsg.Visible = false;
                        resultado.Status = "Exception";
                        resultado.Exception = ex;
                        string jsonResultado = JsonConvert.SerializeObject(resultado);
                        //_logger.LogError(jsonResultado);
                    }
                }

            }
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Esconder Senha")
            {
                tbSenhaSRJ.PasswordChar = '*';
                button2.Text = "Mostrar Senha";
            }
            else
            {
                tbSenhaSRJ.PasswordChar = '\0';
                button2.Text = "Esconder Senha";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "Esconder Senha")
            {
                tbSenhaT28.PasswordChar = '*';
                tbSenha4Dig.PasswordChar = '*';
                button2.Text = "Mostrar Senha";
            }
            else
            {
                tbSenhaT28.PasswordChar = '\0';
                tbSenha4Dig.PasswordChar = '\0';
                button3.Text = "Esconder Senha";
            }
        }

        private bool TelaValida()
        {
            if (!validateUserEntry(tbUsuarioSRJ,"Usuário SRF")) {
                return false;
            }

            if (!validateUserEntry(tbSenhaSRJ,"Senha SRJ"))
            {
                return false;
            }
            if (!validateUserEntry(tbUsuarioT28,"Usuário T28"))
            {
                return false;
            }
            if (!validateUserEntry(tbSenhaT28,"Senha T28"))
            {
                return false;
            }
            if (!validateUserEntry(tbSenha4Dig, "Senha de 4 dígitos"))
            {
                return false;
            }

            return true;
        }

        private bool validateUserEntry(TextBox textbox, string nomedocampo)
        {
            // Checks the value of the text.
            if (textbox.Text.Length == 0)
            {
                // Initializes the variables to pass to the MessageBox.Show method.
                string message = String.Format("O campo {0} deve estar preenchido.", nomedocampo);
                string caption = "Erro";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
                return false;
            }
            else return true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

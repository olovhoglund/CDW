using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Cdw.Objects;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cdw.App
{
    public partial class Login : Form
    {

         WCFService.ServiceClient client = new WCFService.ServiceClient();

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.FormClosed += new FormClosedEventHandler(Login_Closed);
            domainbox.Text = Program.LoginContext.Domain;
        }

        private void Login_Closed(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var request = new AuthenticationRequest();
            request.Username = uidbox.Text;
            request.Password = pwdbox.Text;
            request.Domain = domainbox.Text;
            var response = client.Login(request);
            if (response.Result == Statics.Result.Error)
            {
                MessageBox.Show(response.Errors[0], "Authentication failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Program.DeploymentContext = response.DeploymentContext;
                Program.User = response.User;
                this.Hide();
                var Wizard = new Wizard();
                Wizard.Show();
            }
        }

        
    }
}

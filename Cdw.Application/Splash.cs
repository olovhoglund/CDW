using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Threading;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Runtime.Remoting.Messaging;
using Cdw.Objects;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cdw.App
{
    public partial class Splash : Form
    {

        WCFService.ServiceClient client = new WCFService.ServiceClient();
        SynchronizationContext syncContext;

        public Splash()
        {
            InitializeComponent();
            syncContext = SynchronizationContext.Current;
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            SetupForm();
            client.GetLoginContextCompleted += new EventHandler<WCFService.GetLoginContextCompletedEventArgs>(GetLoginContext_Completed);
            GetLoginContext();
        }

        private void GetLoginContext()
        {
            client.GetLoginContextAsync();
        }

        private void GetComputerInfo(object state)
        {
            var computer = new Computer();
            SynchronizationContext uiContext = state as SynchronizationContext;
            var ps = new Cdw.Powershell.Manager("");
            var result = ps.GetComputerBIOSInfo(ref computer);
            if (result.HasErrors())
            {
                SetError(string.Concat(result.Errors.ToArray()));
            }
            result = ps.GetComputerNICInfo(ref computer);
            if (result.HasErrors())
            {
                SetError(string.Concat(result.Errors.ToArray()));
            }
            result = ps.GetComputerSystemInfo(ref computer);
            if (result.HasErrors())
            {
                SetError(string.Concat(result.Errors.ToArray()));
            }
            Program.Computer = computer;
            uiContext.Post(SwitchForms,null);
        }


        private void SwitchForms(object state)
        {
            var Login = new Login();
            Login.Show();
            this.Hide();
        }

        private void GetLoginContext_Completed(object sender, WCFService.GetLoginContextCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                // success
                Program.LoginContext = e.Result;
                client = null;
                // start getting computer info async
                loadinglabel.Text = "examining computer ...";
                var thread = new System.Threading.Thread(GetComputerInfo);
                thread.Start(syncContext);
            }
            else
            {
                SetError(e.Error.Message);
            }
        }

        private void SetupForm()
        {
            retrybutton.Visible = false;
            statuspanel.Visible = false;
            loadingpanel.Visible = true;
            loadinglabel.Text = "downloading settings ...";
        }

        private void SetError(string Message)
        {
            retrybutton.Visible = true;
            statuspanel.Visible = true;
            loadingpanel.Visible = false;
            statuslabel.Text = Message;
        }

        private void retrybutton_Click(object sender, EventArgs e)
        {
            SetupForm();
            GetLoginContext();
        }
    }
}

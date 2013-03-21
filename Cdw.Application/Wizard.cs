using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Text;
using Cdw.Objects;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cdw.App
{
    public partial class Wizard : Form
    {

        WCFService.ServiceClient client = new WCFService.ServiceClient();
        SynchronizationContext syncContext;
        string lastError = "";

        public Wizard()
        {
            InitializeComponent();
            syncContext = SynchronizationContext.Current;
            MyWizard.SelectedIndexChanged += new EventHandler(Wizard_Changed);
            this.FormClosed += new FormClosedEventHandler(Wizard_Closed);
            client.GetUserCompleted += new EventHandler<WCFService.GetUserCompletedEventArgs>(GetUser_Completed);
            client.GetSoftwareCompleted += new EventHandler<WCFService.GetSoftwareCompletedEventArgs>(GetSoftware_Completed);
            client.GetComputerCompleted += new EventHandler<WCFService.GetComputerCompletedEventArgs>(GetComputer_Completed);
            softwarelist.ItemSelectionChanged += new ListViewItemSelectionChangedEventHandler(SoftwareList_ItemSelected);
            check_computername.CheckedChanged += new EventHandler(Check_Computername_Changed);
            namebox.Leave += new EventHandler(Namebox_Leave);
            namebox.TextChanged += new EventHandler(Namebox_Changed);
            init();
        }

        private void init()
        {
            // set up all forms etc.
            Program.Computer.Owner = "";
            Program.Computer.Location = "";
            Program.Computer.Description = "";
            Program.Computer.Prefix = "";
            Program.Computer.DriverPath = "";
            Program.Computer.InstalledBy = "";
            Program.Computer.OrganizationalUnit = "";
            Program.Computer.Name = "";
            lb_start_BIOSGuid.Text = Program.Computer.BiosGuid;
            lb_start_BIOSVersion.Text = Program.Computer.BiosVersion;
            lb_start_ip.Text = Program.Computer.IPAddress;
            lb_start_mac.Text = Program.Computer.MACAddress;
            lb_start_manufacturer.Text = Program.Computer.Manufacturer;
            lb_start_model.Text = Program.Computer.Model;
            lb_start_serialnumber.Text = Program.Computer.SerialNumber;
            backbutton.Visible = false;
            grouppanel.Visible = false;
            nextbutton.Text = "START";
            ownerpanel.Visible = false;
            orglist.DisplayMember = "DisplayName";
            orglist.ValueMember = "DistinguishedName";
            foreach (OrganizationalUnit ou in Program.DeploymentContext.OrganizationalUnits)
            {
                orglist.Items.Add(ou);
            }
            var OSWin7 = new OperatingSystemItem();
            var OSWin8 = new OperatingSystemItem();
            OSWin7.OSName = "Windows7";
            OSWin7.OSDescription = "Microsoft Windows 7 Enterprise";
            OSWin8.OSName = "Windows8";
            OSWin8.OSDescription = "Microsoft Windows 8 Enterprise";
            oslist.DisplayMember = "OSDescription";
            oslist.Items.Add(OSWin7);
            oslist.Items.Add(OSWin8);
            oslist.SelectedItem = OSWin7;
            Program.Computer.OperatingSystem = OSWin8;
            var langSv = new LanguageItem();
            var langEng = new LanguageItem();
            langSv.LanguageCode = "sv-SE";
            langSv.LanguageName = "Swedish";
            langEng.LanguageCode = "en-US";
            langEng.LanguageName = "English";
            languagelist.DisplayMember = "LanguageName";
            languagelist.Items.Add(langSv);
            languagelist.Items.Add(langEng);
            languagelist.SelectedItem = langSv;
            Program.Computer.Language = langSv;
            ownersearchpanel.Visible = false;
            softwarepanel.Visible = false;
            statuspanel.Visible = false;
            namestatuspanel.Visible = false;
            // always assume auto generated computer names
            check_computername.Checked = true;
            namepanel.BackColor = Color.LightGray;
            namebox.BackColor = Color.LightGray;
            namebox.Enabled = false;
            computercreatedpanel.Visible = false;
            namecreatedlabel.Visible = false;
            if (Program.DeploymentContext.ForceGeneratedName)
            {
                check_computername.Enabled = false;
            }
            else
            {
                check_computername.Enabled = true;
            }
        }

        private void Wizard_Closed(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Wizard_Changed(object sender, EventArgs e)
        {
            switch (MyWizard.SelectedTab.Text.ToLower())
            {
                case "page_start":
                    backbutton.Visible = false;
                    nextbutton.Text = "START";
                    nextbutton.Enabled = true;
                    break;
                case "page_owner":
                    backbutton.Visible = true;
                    nextbutton.Text = "NEXT";
                    if (Program.Computer.Owner.Length > 0)
                    {
                        nextbutton.Enabled = true;
                    }
                    else
                    {
                        nextbutton.Enabled = false;
                    }
                    break;
                case "page_organization":
                    backbutton.Visible = true;
                    nextbutton.Text = "NEXT";
                    if (Program.Computer.OrganizationalUnit.Length > 0)
                    {
                        nextbutton.Enabled = true;
                    }
                    else
                    {
                        nextbutton.Enabled = false;
                    }
                    break;
                case "page_computer" :
                    backbutton.Visible = true;
                    nextbutton.Text = "NEXT";
                    nextbutton.Enabled = true;
                    break;
                case "page_language" :
                    backbutton.Visible = true;
                    nextbutton.Text = "NEXT";
                    if (Program.Computer.Language != null)
                    {
                        nextbutton.Enabled = true;
                    }
                    else
                    {
                        nextbutton.Enabled = false;
                    }
                    break;
                case "page_software":
                    backbutton.Visible = true;
                    nextbutton.Text = "NEXT";
                    nextbutton.Enabled = true;
                    if (Program.Software == null)
                    {
                        softwarepanel.Visible = true;
                        client.GetSoftwareAsync();
                    }
                    break;
                case "page_summary":
                    backbutton.Visible = true;
                    nextbutton.Text = "FINISH";
                    nextbutton.Enabled = true;
                    Refresh_Summary();
                    break;
                case "finished" :
                    backbutton.Visible = false;
                    nextbutton.Visible = false;
                    var thread = new System.Threading.Thread(Finish);
                    thread.Start(syncContext);
                    break;
            }
        }

        private void nextbutton_Click(object sender, EventArgs e)
        {
            switch (MyWizard.SelectedTab.Text.ToLower())
            {
                case "page_start":
                    MyWizard.SelectedTab = Page_owner;
                    break;
                case "page_owner":
                    MyWizard.SelectedTab = Page_organization;
                    break;
                case "page_organization":
                    MyWizard.SelectedTab = Page_computer;
                    break;
                case "page_computer" :
                    Program.Computer.Description = descriptionbox.Text;
                    Program.Computer.Location = locationbox.Text;
                    Program.Computer.Department = departmentbox.Text;
                    // if nothing in the UI has been changed - better safe than sorry
                    if (check_computername.Checked)
                    {
                        Program.Computer.Prefix = prefixlist.SelectedItem.ToString();
                    }
                    MyWizard.SelectedTab = Page_language;
                    break;
                case "page_language":
                    MyWizard.SelectedTab = Page_software;
                    break;
                case "page_software":
                    MyWizard.SelectedTab = Page_summary;
                    break;
                case "page_summary" :
                    MyWizard.SelectedTab = Finished;
                    break;
                case "finished" :
                    End();
                    break;
            }
        }

        private void backbutton_Click(object sender, EventArgs e)
        {
            switch (MyWizard.SelectedTab.Text.ToLower())
            {
                case "page_owner":
                    MyWizard.SelectedTab = Page_start;
                    break;
                case "page_organization":
                    MyWizard.SelectedTab = Page_owner;
                    break;
                case "page_computer":
                    MyWizard.SelectedTab = Page_organization;
                    break;
                case "page_language":
                    MyWizard.SelectedTab = Page_computer;
                    break;
                case "page_software":
                    MyWizard.SelectedTab = Page_language;
                    break;
                case "page_summary":
                    MyWizard.SelectedTab = Page_software;
                    break;
                case "finished":
                    MyWizard.SelectedTab = Page_summary;
                    break;
            }
        }

        private void ownersearchbutton_Click(object sender, EventArgs e)
        {
            ownerpanel.Visible = false;
            ownersearchpanel.Visible = true;
            Program.Computer.Owner = "";
            client.GetUserAsync(ownersearchbox.Text);
        }

        private void Check_Computername_Changed(object sender, EventArgs e)
        {
            if (check_computername.Checked)
            {
                namestatuspanel.Visible = false;
                namepanel.BackColor = Color.LightGray;
                namebox.BackColor = Color.LightGray;
                namebox.Enabled = false;
                namebox.Text = "";
                nextbutton.Enabled = true;
                Program.Computer.Name = "";
                if (prefixlist.SelectedItem != null)
                {
                    Program.Computer.Prefix = prefixlist.SelectedItem.ToString();
                }
                prefixpanel.BackColor = Color.Transparent;
                prefixlist.BackColor = Color.White;
                prefixlist.Enabled = true;

            }
            else
            {
                namepanel.BackColor = Color.Transparent;
                namebox.BackColor = Color.White;
                prefixpanel.BackColor = Color.LightGray;
                prefixlist.BackColor = Color.LightGray;
                prefixlist.Enabled = false;
                namebox.Enabled = true;
                nextbutton.Enabled = false;
            }
        }

        private void Namebox_Changed(object sender, EventArgs e)
        {
            nextbutton.Enabled = false;
        }

        private void Namebox_Leave(object sender, EventArgs e)
        {
            if ((namebox.Text.Length > 0) && (namebox.Text.ToUpper() != Program.Computer.Name.ToUpper()))
            {
                namestatuspanel.Visible = true;
                namestatuslabel.Text = "Verifying computer name ...";
                namestatusimage.Image = global::Cdw.App.Properties.Resources._301_small;
                client.GetComputerAsync(namebox.Text);
            }
        }

        private void GetComputer_Completed(object sender, WCFService.GetComputerCompletedEventArgs e)
        {
            if (e.Result.Status == Statics.Result.Success)
            {
                if (e.Result.ResultAsComputer.Exists)
                {
                    namestatuslabel.Text = "Computer already exists !";
                    namestatusimage.Image = global::Cdw.App.Properties.Resources.error_shield_small;
                    nextbutton.Enabled = false;
                    Program.Computer.Name = "";
                }
                else
                {
                    namestatuslabel.Text = "Computer name is available !";
                    namestatusimage.Image = global::Cdw.App.Properties.Resources.good_shield_small;
                    Program.Computer.Name = namebox.Text;
                    nextbutton.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show(string.Concat(e.Result.Errors.ToArray()), "Search error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nextbutton.Enabled = false;
            }
        }

        private void GetUser_Completed(object sender, WCFService.GetUserCompletedEventArgs e)
        {
            ownersearchpanel.Visible = false;
            if (e.Error == null)
            {
                if (e.Result.Status == Statics.Result.Success)
                {
                    ownerpanel.Visible = true;
                    var user = (User)e.Result.ResultAsUser;
                    lb_owner_displayname.Text = user.DisplayName;
                    lb_owner_department.Text = user.Department;
                    lb_owner_email.Text = user.Email;
                    // the user may have filled in the description / department and backed up to change the owner.
                    if ((descriptionbox.Text.Length == 0) && (departmentbox.Text.Length == 0))
                    {
                        // fill in the suggested fields !
                        descriptionbox.Text = user.DisplayName;
                        departmentbox.Text = user.Department;
                    }
                    Program.Computer.Owner = user.Username;
                    nextbutton.Enabled = true;
                }
                else
                {
                    MessageBox.Show(string.Concat(e.Result.Errors.ToArray()), "Search error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    nextbutton.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show(e.Error.Message, "Search error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nextbutton.Enabled = false;
            }
        }

        private void GetSoftware_Completed(object sender, WCFService.GetSoftwareCompletedEventArgs e)
        {
            softwarepanel.Visible = false;
            if (e.Error == null)
            {
                Program.Software = e.Result.ToList();
                BuildSoftwareList();
            }
            else
            {
                MessageBox.Show(e.Error.Message, "Error getting software", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BuildSoftwareList()
        {
            var groups = new List<String>();
            foreach (SoftwareItem item in Program.Software)
            {
                if (!groups.Contains(item.Group))
                {
                    groups.Add(item.Group);
                }
            }
            foreach (string group in groups)
            {

                var grp = new ListViewGroup(group,HorizontalAlignment.Left);
                grp.Name = group;
                softwarelist.Groups.Add(grp);
                foreach (SoftwareItem item in Program.Software)
                {
                    if (item.Group == group)
                    {
                        var listitem = new ListViewItem();
                        listitem.Text = item.DisplayName;
                        listitem.Tag = item;
                        listitem.SubItems.Add(item.SCCMPackageId);
                        listitem.SubItems.Add(item.SCCMProgram);
                        listitem.Group = grp;
                        listitem.Checked = item.Selected;
                        softwarelist.Items.Add(listitem);
                    }
                }
                
            }
            softwarelist.SetGroupState(ListViewGroupState.Collapsible | ListViewGroupState.Normal);
        }

        private void orglist_SelectedIndexChanged(object sender, EventArgs e)
        {
            grouppanel.Visible = true;
            // build the group list for that organizzational unit.
            grouplist.Items.Clear();
            var selectedOu = (OrganizationalUnit)orglist.SelectedItem;
            foreach (OrganizationalUnit ou in Program.DeploymentContext.OrganizationalUnits)
            {
                
                if (ou.DistinguishedName.Equals(selectedOu.DistinguishedName))
                {
                    foreach (string group in ou.Groups)
                    {
                        grouplist.Items.Add(group);
                    }
                }
            }
            Program.Computer.OrganizationalUnit = selectedOu.DistinguishedName;
            //Program.Computer.Prefix = selectedOu.ComputerNamePrefix;
            prefixlist.SelectedText = "";
            Refresh_Prefixes(selectedOu);
            nextbutton.Enabled = true;
        }

        private void SoftwareList_ItemSelected(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            e.Item.Selected = false;
        }

        private void Refresh_Prefixes(OrganizationalUnit item)
        {
            prefixlist.Items.Clear();
            foreach(string prefix in item.ComputerNamePrefixes)
            {
                prefixlist.Items.Add(prefix);
            }
            if (item.ComputerNamePrefixes.Count > 0)
            {
                prefixlist.SelectedItem = item.ComputerNamePrefixes[0];
            }
        }

        private void Refresh_Summary()
        {
            // this is not a time consuming task, so it can be done every time.
            lb_summary_owner.Text = Program.Computer.Owner;
            lb_summary_department.Text = Program.Computer.Department;
            lb_summary_description.Text = Program.Computer.Description;
            lb_summary_location.Text = Program.Computer.Location;
            lb_summary_language.Text = Program.Computer.Language.LanguageName + " (" + Program.Computer.Language.LanguageCode + ")";
            lb_summary_ou.Text = Program.Computer.OrganizationalUnit;
            lb_summary_software.Text = "";
            lb_summary_group.Text = "";
            foreach (ListViewItem item in softwarelist.CheckedItems)
            {
                lb_summary_software.Text = lb_summary_software.Text + item.Text + Environment.NewLine;
            }
            foreach (ListViewItem grp in grouplist.CheckedItems)
            {
                lb_summary_group.Text = lb_summary_group.Text + grp.Text + Environment.NewLine;
            }
        }

        private void Finish(object state)
        {
            SynchronizationContext uiContext = state as SynchronizationContext;
            try
            {
                if (check_computername.Checked)
                {
                    // auto generate computer name
                    // get the next available computer name for the given organizational unit computer prefix
                    var cNameResult = client.GetNextAvailableComputerName(Program.Computer.Prefix);
                    if (cNameResult.Status != Statics.Result.Success)
                    {
                        // something went wrong
                        throw new Exception(string.Concat(cNameResult.Errors.ToArray()));
                    }
                    Program.Computer.Name = cNameResult.ResultAsString;
                }          
                // try to create the computer in AD ...
                var result = client.CreateComputer(Program.Computer);
                if (result.Status != Statics.Result.Success)
                {
                    // something went wrong
                    throw new Exception(string.Concat(result.Errors.ToArray()));
                }
                // all went fine

                // try to set the SCCM environment variables
                uiContext.Post(SetSCCMVariables, uiContext);
                //SetSCCMVariables();
                uiContext.Post(DisplayResults, null);
            }
            catch (Exception ex)
            {
                // abort and display the results.
                lastError = ex.Message;
                uiContext.Post(SetError, null);
            }
        }

        private void DisplayResults(object state)
        {
            loadingpanel.Visible = false;
            computercreatedpanel.Visible = true;
            if (check_computername.Checked)
            {
                namecreatedlabel.Visible = true;
                namecreatedlabel.Text = "COMPUTER NAME : " + Program.Computer.Name;
            }
            else
            {
                namecreatedlabel.Visible = false;
            }
            nextbutton.Visible = true;
            nextbutton.Text = "OK";
        }

        private string getPaddedString(string baseVariable, int sequence)
        {
            return baseVariable + sequence.ToString().PadLeft(3, '0');
        }

        private void SetSCCMVariables(object state)
        {
            SynchronizationContext uiContext = state as SynchronizationContext;
            try
            {
                // software packages
                for (int i = 0; i < softwarelist.CheckedItems.Count - 1; i++)
                {
                    var item = (SoftwareItem)softwarelist.CheckedItems[i].Tag;
                    SCCMEnvironment.SetVariable(getPaddedString("PACKAGE", i + 1), item.SCCMPackageId + ":" + item.SCCMProgram);
                }
                // os
                SCCMEnvironment.SetVariable("CDWOperatingSystem", Program.Computer.OperatingSystem.OSName);
                // os language
                SCCMEnvironment.SetVariable("OSDLanguage", Program.Computer.Language.LanguageCode);
                // email to technician
                if (Program.User.Mail.Length > 0)
                {
                    SCCMEnvironment.SetVariable("OSDNotifyEmailAddress", Program.User.Mail);
                }

            }
            catch (Exception ex)
            {
                lastError = "Error setting SCCM Variables : " + ex.Message;
                uiContext.Post(SetError, null);
            }
        }

        private void languagelist_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.Computer.Language = (LanguageItem)languagelist.SelectedItem;
            nextbutton.Enabled = true;
        }

        private void End()
        {
            Application.Exit();
        }

        private void SetError(object state)
        {
            loadingpanel.Visible = false;
            statuspanel.Visible = true;
            statuslabel.Text = lastError;
        }

        private void prefixlist_selectedIndexChanged(object sender, EventArgs e)
        {
            Program.Computer.Prefix = prefixlist.SelectedItem.ToString();
        }

        private void oslist_selectedIndexChanged(object sender, EventArgs e)
        {
            Program.Computer.OperatingSystem = (OperatingSystemItem)oslist.SelectedItem;
            nextbutton.Enabled = true;
        }

       
    }
}

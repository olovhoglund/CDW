using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web.Hosting;
using System.IO;
using System.ServiceModel.Activation;
using System.Xml;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using Cdw.Objects;
using System.Text;

namespace Cdw.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service : IService
    {

        [System.Runtime.InteropServices.DllImport("advapi32.dll")]
        public static extern bool LogonUser(string userName, string domainName, string password, int LogonType, int LogonProvider, ref IntPtr phToken);

        public LoginContext GetLoginContext()
        {
            var context = new LoginContext();
            context.Domain = Properties.Settings.Default.ADDomain;
            context.DomainController = Properties.Settings.Default.ADDomainController;
            return context;
        }

        public AuthenticationResponse Login(Objects.AuthenticationRequest request)
        {
            var Response = new AuthenticationResponse();
            try
            {
                if ((request.Username == "") || (request.Password == "") || (request.Domain == ""))
                {
                    throw new Exception("Authentication requests must provide username, password and domain !");
                }
                IntPtr tokenHandle = new IntPtr(0);
                if (LogonUser(request.Username, request.Domain, request.Password, 3, 0, ref tokenHandle))
                {
                    Response.Result = Statics.Result.Success;
                    Response.DeploymentContext.Domain = Properties.Settings.Default.ADDomain;
                    Response.DeploymentContext.DomainController = Properties.Settings.Default.ADDomainController;
                    Response.DeploymentContext.ForceGeneratedName = Properties.Settings.Default.ForceGeneratedComputerNames;
                    var deSerializer = new XmlSerializer(typeof(List<OrganizationalUnit>));
                    XmlDocument doc = new XmlDocument();
                    doc.Load(HostingEnvironment.MapPath("~/OrganizationalUnits.xml"));
                    List<OrganizationalUnit> ous = new List<OrganizationalUnit>();
                    foreach (XmlNode ouNode in doc.GetElementsByTagName("OrganizationalUnit"))
                    {
                        // check if user has access
                        foreach (XmlNode userNode in ouNode.SelectNodes("Users/User"))
                        {
                            if (userNode.InnerText.ToLower().Trim() == request.Username.ToLower().Trim())
                            {
                                var ou = new OrganizationalUnit();
                                ou.DisplayName = ouNode.SelectNodes("DisplayName")[0].InnerText;
                                ou.DistinguishedName = ouNode.SelectNodes("DistinguishedName")[0].InnerText;
                                foreach (XmlNode prefixNode in ouNode.SelectNodes("ComputerNamePrefixes/Prefix"))
                                {
                                    ou.ComputerNamePrefixes.Add(prefixNode.InnerText);
                                }
                                foreach (XmlNode groupNode in ouNode.SelectNodes("Groups/Group"))
                                {
                                    ou.Groups.Add(groupNode.InnerText);
                                }
                                ous.Add(ou);
                            }
                        }
                    }
                    Response.DeploymentContext.OrganizationalUnits = ous;
                    // get the user object
                    var ps = new Powershell.Manager();
                    var psResult = ps.GetUser(request.Username);
                    var context = new UserContext();
                    context.Username = psResult.ResultAsUser.Username;
                    context.DisplayName = psResult.ResultAsUser.DisplayName;
                    context.Mail = psResult.ResultAsUser.Email;
                    Response.User = context;
                }
                else
                {
                    throw new Exception("Login failed !");
                }
            }
            catch (Exception ex)
            {
                Response.Result = Statics.Result.Error;
                Response.Errors.Add(ex.Message + ex.StackTrace);
            }
            return Response;
        }

        public OperationResult CreateComputer(Objects.Computer computer)
        {
            var ps = new Powershell.Manager();
            var result = ps.CreateComputer(computer);
            return result;
        }


        public OperationResult GetUser(string username)
        {
            var ps = new Powershell.Manager();
            var result = ps.GetUser(username);
            return result;
        }


        public List<SoftwareItem> GetSoftware()
        {
            var Response = new List<SoftwareItem>();
                    XmlDocument doc = new XmlDocument();
                    doc.Load(HostingEnvironment.MapPath("~/Software.xml"));
                    var selectedItems = new List<String>();
                    foreach (XmlNode sel in doc.GetElementsByTagName("SelectApplication"))
                    {
                        selectedItems.Add(sel.Attributes.GetNamedItem("Application.Id").Value);
                    }
                            foreach (XmlNode appGroupNode in doc.GetElementsByTagName("ApplicationGroup"))
                            {
                                var groupName = appGroupNode.Attributes.GetNamedItem("Name").Value;
                                foreach (XmlNode appNode in appGroupNode.SelectNodes("Application"))
                                {
                                    if (appNode.SelectNodes("Program").Count > 0)
                                    {
                                        var app = new SoftwareItem();
                                        var appId = (string)appNode.Attributes.GetNamedItem("Id").Value;
                                        app.Group = groupName;
                                        app.DisplayName = appNode.Attributes.GetNamedItem("DisplayName").Value;
                                        app.SCCMPackageId = appNode.SelectNodes("Program")[0].Attributes.GetNamedItem("PackageId").Value;
                                        app.SCCMProgram = appNode.SelectNodes("Program")[0].InnerText;
                                        app.Selected = selectedItems.Contains(appId);
                                        Response.Add(app);
                                    }
                                }
                            }
                    //var reader = new StreamReader(HostingEnvironment.MapPath("~/OrganizationalUnits.xml"));
                    //Response.DeploymentContext.OrganizationalUnits = (List<OrganizationalUnit>)deSerializer.Deserialize(reader);
                    //reader.Close();
                   
            return Response;
        }


        public OperationResult GetNextAvailableComputerName(string prefix)
        {
            var ps = new Powershell.Manager();
            var result = ps.GetNextAvailableComputerName(prefix);
            return result;
        }


        public OperationResult GetComputer(string computername)
        {
            var ps = new Powershell.Manager();
            var result = ps.GetComputer(computername);
            return result;
        }
    }
}

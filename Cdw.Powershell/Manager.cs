using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Globalization;
using System.Text;
using Cdw.Objects;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Threading.Tasks;
//using Microsoft.ActiveDirectory.Management;
using System.DirectoryServices;

namespace Cdw.Powershell
{
    public class Manager : IManager
    {
        /// <summary>
        /// Specifies how many numbers a computernameprefix should be appended with.
        /// Ex:
        /// 5 would result in prefix-00001 (where 1 is the incremented number)
        /// 4 would result in prefix-0005  (where 5 is the incremented number)
        /// 
        /// ... and so on.
        /// </summary>
        private const int computerNameNumberLength = 4;

        private string _domainController;

        public Manager(string domainController)
        {
            _domainController = domainController;
        }

        /// <summary>
        /// Creates a computer entry in Active Directory
        /// </summary>
        public Objects.OperationResult CreateComputer(Objects.Computer computer)
        {
            var Result = new OperationResult();
            try
            {
                using (Runspace runspace = GetRunspace(ref Result))
                {
                    Pipeline pipeline = runspace.CreatePipeline();
                    InitializePS(ref Result, pipeline);
                    if (Result.Status == Statics.Result.Error)
                    {
                        return Result;
                    }
                    pipeline = runspace.CreatePipeline();
                    Command getProcess = new Command("New-ADComputer");
                    getProcess.Parameters.Add("Name", computer.Name);
                    getProcess.Parameters.Add("SamAccountName", computer.Name);
                    getProcess.Parameters.Add("Path", computer.OrganizationalUnit);
                    getProcess.Parameters.Add("Location", computer.Location);
                    getProcess.Parameters.Add("Description", computer.Description);
                    getProcess.Parameters.Add("ManagedBy", computer.Owner);
                    getProcess.Parameters.Add("Server", _domainController);
                    if (computer.Department.Length > 0)
                    {
                        var attrs = new Hashtable();
                        attrs.Add("department", computer.Department);
                        getProcess.Parameters.Add("OtherAttributes", attrs);
                    }
                    pipeline.Commands.Add(getProcess);
                    System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> output = null;
                    output = pipeline.Invoke();
                    if ((pipeline.Error != null) && pipeline.Error.Count > 0)
                    {
                        foreach (object Err in pipeline.Error.ReadToEnd())
                        {
                            Result.Errors.Add(Err.ToString());
                            Result.Status = Statics.Result.Error;
                        }
                    }
                    else
                    {
                        Result.Status = Statics.Result.Success;
                    }
                }
            }
            catch (Exception ex)
            {
                Result.Status = Statics.Result.Error;
                Result.Errors.Add(ex.Message);
                Result.Errors.Add(ex.StackTrace);
            }
            return Result;
        }

        public OperationResult AddComputerToGroup(Objects.Computer computer, string group)
        {
            var Result = new OperationResult();
            try
            {
                using (Runspace runspace = GetRunspace(ref Result))
                {
                    Pipeline pipeline = runspace.CreatePipeline();
                    InitializePS(ref Result, pipeline);
                    if (Result.Status == Statics.Result.Error)
                    {
                        return Result;
                    }
                    pipeline = runspace.CreatePipeline();
                    Command getProcess = new Command("Add-ADPrincipalGroupMembership");
                    getProcess.Parameters.Add("Identity", "CN=" + computer.Name + ","  + computer.OrganizationalUnit);
                    getProcess.Parameters.Add("MemberOf", group);
                    getProcess.Parameters.Add("Server", _domainController);
                    pipeline.Commands.Add(getProcess);
                    System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> output = null;
                    output = pipeline.Invoke();
                    if ((pipeline.Error != null) && pipeline.Error.Count > 0)
                    {
                        foreach (object Err in pipeline.Error.ReadToEnd())
                        {
                            Result.Errors.Add(Err.ToString());
                            Result.Status = Statics.Result.Error;
                        }
                    }
                    else
                    {
                        Result.Status = Statics.Result.Success;
                    }
                }
            }
            catch (Exception ex)
            {
                Result.Status = Statics.Result.Error;
                Result.Errors.Add(ex.Message);
                Result.Errors.Add(ex.StackTrace);
            }
            return Result;
        }

        /// <summary>
        /// Returns the next available computer name for a given prefix string
        /// </summary>
        public Objects.OperationResult GetNextAvailableComputerName(string prefix)
        {
            var Result = new OperationResult();
            try
            {
                using (Runspace runspace = GetRunspace(ref Result))
                {
                    Pipeline pipeline = runspace.CreatePipeline();
                    InitializePS(ref Result, pipeline);
                    if (Result.Status == Statics.Result.Error)
                    {
                        return Result;
                    }
                    pipeline = runspace.CreatePipeline();
                    Command getProcess = new Command("Get-ADComputer");
                    getProcess.Parameters.Add("Filter", "name -like '" + prefix + "*'");
                    pipeline.Commands.Add(getProcess);
                    System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> output = null;
                    output = pipeline.Invoke();
                    if ((pipeline.Error != null) && pipeline.Error.Count > 0)
                    {
                        foreach (object Err in pipeline.Error.ReadToEnd())
                        {
                            Result.Errors.Add(Err.ToString());
                            Result.Status = Statics.Result.Error;
                        }
                    }
                    else
                    {
                        // loop through all names to find potential gaps in the sequence or take the last one.
                        // select the computer name only from the list of objects
                        List<string> computers = (from System.Management.Automation.PSObject result in output select result.Properties["Name"].Value.ToString()).ToList();
                        // get only the incremental numbers - not the prefix
                        IList<int> computerNumbers = (from computer in computers select computer.Substring(prefix.Length) into cIterator where IsNumeric(cIterator, NumberStyles.Integer) select Int32.Parse(cIterator)).ToList();
                        // order the list
                        computerNumbers = (from c in computerNumbers orderby c select c).ToList();

                        for (var i = 0; i < computerNumbers.Count; i++)
                        {
                            // If the incremental difference between this number and the one before is more than 1, we break and return it.
                            // Remember, we have to left pad the iterator.
                            if (i > 0 && (computerNumbers[i - 1] + 1) < computerNumbers[i])
                            {
                                Result.ResultAsString = prefix + (computerNumbers[i - 1] + 1).ToString().PadLeft(computerNameNumberLength, '0');
                                Result.Status = Statics.Result.Success;
                                return Result;
                            }
                        }

                        // If none of the existing computer belongs to a series, we create a new one.
                        if (computerNumbers.Count == 0)
                        {
                            Result.ResultAsString = prefix + "1".PadLeft(computerNameNumberLength, '0');
                            Result.Status = Statics.Result.Success;
                            return Result;
                        }
                        else
                        {
                            // Otherwise we return the next incremental step in the series.
                            // Remember, we have to left pad the iterator.
                            Result.ResultAsString = prefix + (computerNumbers.Last() + 1).ToString().PadLeft(computerNameNumberLength, '0');
                            Result.Status = Statics.Result.Success;
                            return Result;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Result.Status = Statics.Result.Error;
                Result.Errors.Add(ex.Message);
                Result.Errors.Add(ex.StackTrace);
            }
            return Result;
        }

        private Runspace GetRunspace(ref OperationResult Result)
        {
            Runspace runspace = default(Runspace);
            runspace = RunspaceFactory.CreateRunspace();
            try
            {
                runspace.Open();
                Result.Status = Statics.Result.Success;
            }
            catch (Exception ex)
            {
                Result.Errors.Add(ex.Message);
            }
            return runspace;
        }


        private void InitializePS(ref OperationResult Result, Pipeline pipeline)
        {
            Command initProcess = new Command("Import-Module");
            initProcess.Parameters.Add("Name", "ActiveDirectory");
            pipeline.Commands.Add(initProcess);
            try
            {
                pipeline.Invoke();
                Result.Status = Statics.Result.Success;
            }
            catch (Exception ex)
            {
                if (!ex.Message.Contains("Unable to find a default server with Active Directory Web Services"))
                {
                    Result.Status = Statics.Result.Error;
                    Result.Errors.Add(ex.Message);
                }
                else
                {
                    Result.Status = Statics.Result.Success;
                }
            }
        }



        public OperationResult GetComputerBIOSInfo(ref Computer computer)
        {
            var Result = new OperationResult();
            try
            {
                using (Runspace runspace = GetRunspace(ref Result))
                {
                    Pipeline pipeline = runspace.CreatePipeline();
                    Command getProcess = new Command("Get-WmiObject win32_bios | Select Manufacturer,Name,BIOSVersion,ReleaseDate,SMBIOSBIOSVersion", true);
                    pipeline.Commands.Add(getProcess);
                    System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> output = null;
                    output = pipeline.Invoke();
                    if ((pipeline.Error != null) && pipeline.Error.Count > 0)
                    {
                        foreach (object Err in pipeline.Error.ReadToEnd())
                        {
                            Result.Errors.Add(Err.ToString());
                            Result.Status = Statics.Result.Error;
                        }
                    }
                    else
                    {
                        if (output.Count > 0)
                        {
                            computer.BiosVersion = output[0].Properties["SMBIOSBIOSVersion"].Value.ToString();
                            Result.Status = Statics.Result.Success;
                        }
                        else
                        {
                            throw new Exception("No BIOS information available");
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Result.Status = Statics.Result.Error;
                Result.Errors.Add(ex.Message);
                Result.Errors.Add(ex.StackTrace);
            }
            return Result;
        }

        public OperationResult GetComputerNICInfo(ref Computer computer)
        {
            var Result = new OperationResult();
            try
            {
                using (Runspace runspace = GetRunspace(ref Result))
                {
                    Pipeline pipeline = runspace.CreatePipeline();
                    Command getProcess = new Command("Get-WmiObject win32_networkadapterConfiguration -Filter {IPEnabled=true} | Select IPAddress,MACAddress", true);
                    pipeline.Commands.Add(getProcess);
                    System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> output = null;
                    output = pipeline.Invoke();
                    if ((pipeline.Error != null) && pipeline.Error.Count > 0)
                    {
                        foreach (object Err in pipeline.Error.ReadToEnd())
                        {
                            Result.Errors.Add(Err.ToString());
                            Result.Status = Statics.Result.Error;
                        }
                    }
                    else
                    {
                        if (output.Count > 0)
                        {
                            computer.MACAddress = output[0].Properties["MACAddress"].Value.ToString();
                            String[] addresses = (String[])output[0].Properties["IPAddress"].Value;
                            computer.IPAddress = addresses[0];
                            Result.Status = Statics.Result.Success;
                        }
                        else
                        {
                            throw new Exception("No Network information available");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Result.Status = Statics.Result.Error;
                Result.Errors.Add(ex.Message);
                Result.Errors.Add(ex.StackTrace);
            }
            return Result;
        }

        public OperationResult GetComputerSystemInfo(ref Computer computer)
        {
            var Result = new OperationResult();
            try
            {
                using (Runspace runspace = GetRunspace(ref Result))
                {
                    Pipeline pipeline = runspace.CreatePipeline();
                    Command getProcess = new Command("Get-WmiObject Win32_ComputerSystemProduct | Select Vendor,Version,Name,IdentifyingNumber,UUID", true);
                    pipeline.Commands.Add(getProcess);
                    System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> output = null;
                    output = pipeline.Invoke();
                    if ((pipeline.Error != null) && pipeline.Error.Count > 0)
                    {
                        foreach (object Err in pipeline.Error.ReadToEnd())
                        {
                            Result.Errors.Add(Err.ToString());
                            Result.Status = Statics.Result.Error;
                        }
                    }
                    else
                    {
                        if (output.Count > 0)
                        {
                            computer.Manufacturer = output[0].Properties["Vendor"].Value.ToString();
                            computer.Model = output[0].Properties["Name"].Value.ToString();
                            computer.SerialNumber = output[0].Properties["IdentifyingNumber"].Value.ToString();
                            computer.BiosGuid = output[0].Properties["UUID"].Value.ToString();
                            Result.Status = Statics.Result.Success;
                        }
                        else
                        {
                            throw new Exception("No System information available");
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Result.Status = Statics.Result.Error;
                Result.Errors.Add(ex.Message);
                Result.Errors.Add(ex.StackTrace);
            }
            return Result;
        }


        public OperationResult GetUser(String username)
        {
            var Result = new OperationResult();
            try
            {
                using (Runspace runspace = GetRunspace(ref Result))
                {
                    Pipeline pipeline = runspace.CreatePipeline();
                    InitializePS(ref Result, pipeline);
                    if (Result.Status == Statics.Result.Error)
                    {
                        return Result;
                    }
                    pipeline = runspace.CreatePipeline();
                    Command getProcess = new Command("Get-ADUser");
                    getProcess.Parameters.Add("Identity", username);
                    getProcess.Parameters.Add("Properties", "*");
                    pipeline.Commands.Add(getProcess);
                    System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> output = null;
                    output = pipeline.Invoke();
                    if ((pipeline.Error != null) && pipeline.Error.Count > 0)
                    {
                        foreach (object Err in pipeline.Error.ReadToEnd())
                        {
                            if (Err.ToString().ToLower().Contains("cannot find an object with identity:"))
                            {
                                throw new Exception("No user found !");
                            }
                            else
                            {
                                Result.Errors.Add(Err.ToString());
                                Result.Status = Statics.Result.Error;
                            }
                        }
                    }
                    else
                    {
                        if (output.Count > 0)
                        {
                            var user = new User();
                            user.Department = output[0].Properties["Department"].Value.ToString();
                            user.DisplayName = output[0].Properties["DisplayName"].Value.ToString();
                            user.Username = output[0].Properties["samAccountName"].Value.ToString();
                            user.Email = output[0].Properties["mail"].Value.ToString();

                            user.MemberOf= new List<String>();

                            var memberOfList=  new List<string>();

                            foreach (var grp in (IEnumerable)output[0].Properties["memberOf"].Value)
                            {

                                String name = GetGroupName(grp.ToString());
                                user.MemberOf.Add(name);
                                System.Diagnostics.Debug.WriteLine("Grupp: " + name);
                            };

                            Result.ResultAsUser = user;
                            Result.Status = Statics.Result.Success;
                        }
                        else
                        {
                            throw new Exception("No user found !");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Cannot find an object with identity"))
                {
                    Result.Errors.Add("No user found !");
                }
                else
                {
                    Result.Errors.Add(ex.Message);
                    Result.Errors.Add(ex.StackTrace);
                }
                Result.Status = Statics.Result.Error;
            }
            return Result;
        }

        public string GetGroupName(string LDAPGroupEntry)
        {
            string[] split = LDAPGroupEntry.Split(',');
            //List<string> cnValues = new List<string>();
            foreach (string pair in split)
            {
                string[] keyValue = pair.Split('=');
                if (keyValue[0] == "CN")
                    // return first value
                    //cnValues.Add(keyValue[1]);
                    return keyValue[1];
            }
            //No error handling ?
            return "";
        }

        //ToDo Bort
        //public string GetGroupName(string LDAPGroupEntry)
        //{
        //// LDAPGroupEntry is in the form "LDAP://CN=Foo Group Name,DC=mydomain,DC=com"
        //DirectoryEntry grp = new DirectoryEntry(LDAPGroupEntry);
        //return grp.Properties["CN"].Value.ToString();
        //}

        public static bool IsNumeric(string val, System.Globalization.NumberStyles numberStyle)
        {
            Double result;
            return Double.TryParse(val, numberStyle, System.Globalization.CultureInfo.CurrentCulture, out result);
        }


        public OperationResult GetComputer(string computername)
        {
            var Result = new OperationResult();
            var comp = new Computer();
            try
            {
                using (Runspace runspace = GetRunspace(ref Result))
                {
                    Pipeline pipeline = runspace.CreatePipeline();
                    InitializePS(ref Result, pipeline);
                    if (Result.Status == Statics.Result.Error)
                    {
                        return Result;
                    }
                    pipeline = runspace.CreatePipeline();
                    Command getProcess = new Command("Get-ADComputer");
                    getProcess.Parameters.Add("Identity", computername);
                    getProcess.Parameters.Add("Properties", "*");
                    pipeline.Commands.Add(getProcess);
                    System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> output = null;
                    output = pipeline.Invoke();
                    if ((pipeline.Error != null) && pipeline.Error.Count > 0)
                    {
                        foreach (object Err in pipeline.Error.ReadToEnd())
                        {
                            if (Err.ToString().ToLower().Contains("cannot find an object with identity:"))
                            {
                                comp.Exists = false;
                                Result.ResultAsComputer = comp;
                            }
                            else
                            {
                                Result.Errors.Add(Err.ToString());
                                Result.Status = Statics.Result.Error;
                            }
                        }
                    }
                    else
                    {
                        if (output.Count > 0)
                        {
                            comp.Name = output[0].Properties["Name"].Value.ToString();
                            comp.OrganizationalUnit = output[0].Properties["DistinguishedName"].Value.ToString().Replace("CN=" + computername + ",", "");
                            comp.Exists = true;
                            Result.ResultAsComputer = comp;
                            Result.Status = Statics.Result.Success;
                        }
                        else
                        {
                            comp.Exists = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Cannot find an object with identity"))
                {
                    // this is not an error
                    Result.Messages.Add("No computer found !");
                    Result.Status = Statics.Result.Success;
                    comp.Exists = false;
                    Result.ResultAsComputer = comp;
                }
                else
                {
                    Result.Errors.Add(ex.Message);
                    Result.Errors.Add(ex.StackTrace);
                    Result.Status = Statics.Result.Error;
                }
            }
            return Result;
        }
    }
}

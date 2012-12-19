using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using Cdw.Objects;
using System.Text;

namespace Cdw.Service
{
    [ServiceContract(Namespace="Cdw.Service")]
    public interface IService
    {
        [OperationContract]
        LoginContext GetLoginContext();

        [OperationContract]
        AuthenticationResponse Login(AuthenticationRequest request);

        [OperationContract]
        OperationResult CreateComputer(Computer computer);

        [OperationContract]
        OperationResult GetUser(string username);

        [OperationContract]
        List<SoftwareItem> GetSoftware();

        [OperationContract]
        OperationResult GetNextAvailableComputerName(string prefix);

        [OperationContract]
        OperationResult GetComputer(string computername);
    }
}

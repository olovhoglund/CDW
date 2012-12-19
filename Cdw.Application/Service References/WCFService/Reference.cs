﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cdw.App.WCFService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="Cdw.Service", ConfigurationName="WCFService.IService")]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="Cdw.Service/IService/GetLoginContext", ReplyAction="Cdw.Service/IService/GetLoginContextResponse")]
        Cdw.Objects.LoginContext GetLoginContext();
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="Cdw.Service/IService/GetLoginContext", ReplyAction="Cdw.Service/IService/GetLoginContextResponse")]
        System.IAsyncResult BeginGetLoginContext(System.AsyncCallback callback, object asyncState);
        
        Cdw.Objects.LoginContext EndGetLoginContext(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="Cdw.Service/IService/Login", ReplyAction="Cdw.Service/IService/LoginResponse")]
        Cdw.Objects.AuthenticationResponse Login(Cdw.Objects.AuthenticationRequest request);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="Cdw.Service/IService/Login", ReplyAction="Cdw.Service/IService/LoginResponse")]
        System.IAsyncResult BeginLogin(Cdw.Objects.AuthenticationRequest request, System.AsyncCallback callback, object asyncState);
        
        Cdw.Objects.AuthenticationResponse EndLogin(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="Cdw.Service/IService/CreateComputer", ReplyAction="Cdw.Service/IService/CreateComputerResponse")]
        Cdw.Objects.OperationResult CreateComputer(Cdw.Objects.Computer computer);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="Cdw.Service/IService/CreateComputer", ReplyAction="Cdw.Service/IService/CreateComputerResponse")]
        System.IAsyncResult BeginCreateComputer(Cdw.Objects.Computer computer, System.AsyncCallback callback, object asyncState);
        
        Cdw.Objects.OperationResult EndCreateComputer(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="Cdw.Service/IService/GetUser", ReplyAction="Cdw.Service/IService/GetUserResponse")]
        Cdw.Objects.OperationResult GetUser(string username);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="Cdw.Service/IService/GetUser", ReplyAction="Cdw.Service/IService/GetUserResponse")]
        System.IAsyncResult BeginGetUser(string username, System.AsyncCallback callback, object asyncState);
        
        Cdw.Objects.OperationResult EndGetUser(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="Cdw.Service/IService/GetSoftware", ReplyAction="Cdw.Service/IService/GetSoftwareResponse")]
        Cdw.Objects.SoftwareItem[] GetSoftware();
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="Cdw.Service/IService/GetSoftware", ReplyAction="Cdw.Service/IService/GetSoftwareResponse")]
        System.IAsyncResult BeginGetSoftware(System.AsyncCallback callback, object asyncState);
        
        Cdw.Objects.SoftwareItem[] EndGetSoftware(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="Cdw.Service/IService/GetNextAvailableComputerName", ReplyAction="Cdw.Service/IService/GetNextAvailableComputerNameResponse")]
        Cdw.Objects.OperationResult GetNextAvailableComputerName(string prefix);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="Cdw.Service/IService/GetNextAvailableComputerName", ReplyAction="Cdw.Service/IService/GetNextAvailableComputerNameResponse")]
        System.IAsyncResult BeginGetNextAvailableComputerName(string prefix, System.AsyncCallback callback, object asyncState);
        
        Cdw.Objects.OperationResult EndGetNextAvailableComputerName(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="Cdw.Service/IService/GetComputer", ReplyAction="Cdw.Service/IService/GetComputerResponse")]
        Cdw.Objects.OperationResult GetComputer(string computername);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="Cdw.Service/IService/GetComputer", ReplyAction="Cdw.Service/IService/GetComputerResponse")]
        System.IAsyncResult BeginGetComputer(string computername, System.AsyncCallback callback, object asyncState);
        
        Cdw.Objects.OperationResult EndGetComputer(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : Cdw.App.WCFService.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetLoginContextCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetLoginContextCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public Cdw.Objects.LoginContext Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((Cdw.Objects.LoginContext)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class LoginCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public LoginCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public Cdw.Objects.AuthenticationResponse Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((Cdw.Objects.AuthenticationResponse)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CreateComputerCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public CreateComputerCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public Cdw.Objects.OperationResult Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((Cdw.Objects.OperationResult)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetUserCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetUserCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public Cdw.Objects.OperationResult Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((Cdw.Objects.OperationResult)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetSoftwareCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetSoftwareCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public Cdw.Objects.SoftwareItem[] Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((Cdw.Objects.SoftwareItem[])(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetNextAvailableComputerNameCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetNextAvailableComputerNameCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public Cdw.Objects.OperationResult Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((Cdw.Objects.OperationResult)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetComputerCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetComputerCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public Cdw.Objects.OperationResult Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((Cdw.Objects.OperationResult)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<Cdw.App.WCFService.IService>, Cdw.App.WCFService.IService {
        
        private BeginOperationDelegate onBeginGetLoginContextDelegate;
        
        private EndOperationDelegate onEndGetLoginContextDelegate;
        
        private System.Threading.SendOrPostCallback onGetLoginContextCompletedDelegate;
        
        private BeginOperationDelegate onBeginLoginDelegate;
        
        private EndOperationDelegate onEndLoginDelegate;
        
        private System.Threading.SendOrPostCallback onLoginCompletedDelegate;
        
        private BeginOperationDelegate onBeginCreateComputerDelegate;
        
        private EndOperationDelegate onEndCreateComputerDelegate;
        
        private System.Threading.SendOrPostCallback onCreateComputerCompletedDelegate;
        
        private BeginOperationDelegate onBeginGetUserDelegate;
        
        private EndOperationDelegate onEndGetUserDelegate;
        
        private System.Threading.SendOrPostCallback onGetUserCompletedDelegate;
        
        private BeginOperationDelegate onBeginGetSoftwareDelegate;
        
        private EndOperationDelegate onEndGetSoftwareDelegate;
        
        private System.Threading.SendOrPostCallback onGetSoftwareCompletedDelegate;
        
        private BeginOperationDelegate onBeginGetNextAvailableComputerNameDelegate;
        
        private EndOperationDelegate onEndGetNextAvailableComputerNameDelegate;
        
        private System.Threading.SendOrPostCallback onGetNextAvailableComputerNameCompletedDelegate;
        
        private BeginOperationDelegate onBeginGetComputerDelegate;
        
        private EndOperationDelegate onEndGetComputerDelegate;
        
        private System.Threading.SendOrPostCallback onGetComputerCompletedDelegate;
        
        public ServiceClient() {
        }
        
        public ServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public event System.EventHandler<GetLoginContextCompletedEventArgs> GetLoginContextCompleted;
        
        public event System.EventHandler<LoginCompletedEventArgs> LoginCompleted;
        
        public event System.EventHandler<CreateComputerCompletedEventArgs> CreateComputerCompleted;
        
        public event System.EventHandler<GetUserCompletedEventArgs> GetUserCompleted;
        
        public event System.EventHandler<GetSoftwareCompletedEventArgs> GetSoftwareCompleted;
        
        public event System.EventHandler<GetNextAvailableComputerNameCompletedEventArgs> GetNextAvailableComputerNameCompleted;
        
        public event System.EventHandler<GetComputerCompletedEventArgs> GetComputerCompleted;
        
        public Cdw.Objects.LoginContext GetLoginContext() {
            return base.Channel.GetLoginContext();
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetLoginContext(System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetLoginContext(callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public Cdw.Objects.LoginContext EndGetLoginContext(System.IAsyncResult result) {
            return base.Channel.EndGetLoginContext(result);
        }
        
        private System.IAsyncResult OnBeginGetLoginContext(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return this.BeginGetLoginContext(callback, asyncState);
        }
        
        private object[] OnEndGetLoginContext(System.IAsyncResult result) {
            Cdw.Objects.LoginContext retVal = this.EndGetLoginContext(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetLoginContextCompleted(object state) {
            if ((this.GetLoginContextCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetLoginContextCompleted(this, new GetLoginContextCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetLoginContextAsync() {
            this.GetLoginContextAsync(null);
        }
        
        public void GetLoginContextAsync(object userState) {
            if ((this.onBeginGetLoginContextDelegate == null)) {
                this.onBeginGetLoginContextDelegate = new BeginOperationDelegate(this.OnBeginGetLoginContext);
            }
            if ((this.onEndGetLoginContextDelegate == null)) {
                this.onEndGetLoginContextDelegate = new EndOperationDelegate(this.OnEndGetLoginContext);
            }
            if ((this.onGetLoginContextCompletedDelegate == null)) {
                this.onGetLoginContextCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetLoginContextCompleted);
            }
            base.InvokeAsync(this.onBeginGetLoginContextDelegate, null, this.onEndGetLoginContextDelegate, this.onGetLoginContextCompletedDelegate, userState);
        }
        
        public Cdw.Objects.AuthenticationResponse Login(Cdw.Objects.AuthenticationRequest request) {
            return base.Channel.Login(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginLogin(Cdw.Objects.AuthenticationRequest request, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginLogin(request, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public Cdw.Objects.AuthenticationResponse EndLogin(System.IAsyncResult result) {
            return base.Channel.EndLogin(result);
        }
        
        private System.IAsyncResult OnBeginLogin(object[] inValues, System.AsyncCallback callback, object asyncState) {
            Cdw.Objects.AuthenticationRequest request = ((Cdw.Objects.AuthenticationRequest)(inValues[0]));
            return this.BeginLogin(request, callback, asyncState);
        }
        
        private object[] OnEndLogin(System.IAsyncResult result) {
            Cdw.Objects.AuthenticationResponse retVal = this.EndLogin(result);
            return new object[] {
                    retVal};
        }
        
        private void OnLoginCompleted(object state) {
            if ((this.LoginCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.LoginCompleted(this, new LoginCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void LoginAsync(Cdw.Objects.AuthenticationRequest request) {
            this.LoginAsync(request, null);
        }
        
        public void LoginAsync(Cdw.Objects.AuthenticationRequest request, object userState) {
            if ((this.onBeginLoginDelegate == null)) {
                this.onBeginLoginDelegate = new BeginOperationDelegate(this.OnBeginLogin);
            }
            if ((this.onEndLoginDelegate == null)) {
                this.onEndLoginDelegate = new EndOperationDelegate(this.OnEndLogin);
            }
            if ((this.onLoginCompletedDelegate == null)) {
                this.onLoginCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnLoginCompleted);
            }
            base.InvokeAsync(this.onBeginLoginDelegate, new object[] {
                        request}, this.onEndLoginDelegate, this.onLoginCompletedDelegate, userState);
        }
        
        public Cdw.Objects.OperationResult CreateComputer(Cdw.Objects.Computer computer) {
            return base.Channel.CreateComputer(computer);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginCreateComputer(Cdw.Objects.Computer computer, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginCreateComputer(computer, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public Cdw.Objects.OperationResult EndCreateComputer(System.IAsyncResult result) {
            return base.Channel.EndCreateComputer(result);
        }
        
        private System.IAsyncResult OnBeginCreateComputer(object[] inValues, System.AsyncCallback callback, object asyncState) {
            Cdw.Objects.Computer computer = ((Cdw.Objects.Computer)(inValues[0]));
            return this.BeginCreateComputer(computer, callback, asyncState);
        }
        
        private object[] OnEndCreateComputer(System.IAsyncResult result) {
            Cdw.Objects.OperationResult retVal = this.EndCreateComputer(result);
            return new object[] {
                    retVal};
        }
        
        private void OnCreateComputerCompleted(object state) {
            if ((this.CreateComputerCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CreateComputerCompleted(this, new CreateComputerCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void CreateComputerAsync(Cdw.Objects.Computer computer) {
            this.CreateComputerAsync(computer, null);
        }
        
        public void CreateComputerAsync(Cdw.Objects.Computer computer, object userState) {
            if ((this.onBeginCreateComputerDelegate == null)) {
                this.onBeginCreateComputerDelegate = new BeginOperationDelegate(this.OnBeginCreateComputer);
            }
            if ((this.onEndCreateComputerDelegate == null)) {
                this.onEndCreateComputerDelegate = new EndOperationDelegate(this.OnEndCreateComputer);
            }
            if ((this.onCreateComputerCompletedDelegate == null)) {
                this.onCreateComputerCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCreateComputerCompleted);
            }
            base.InvokeAsync(this.onBeginCreateComputerDelegate, new object[] {
                        computer}, this.onEndCreateComputerDelegate, this.onCreateComputerCompletedDelegate, userState);
        }
        
        public Cdw.Objects.OperationResult GetUser(string username) {
            return base.Channel.GetUser(username);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetUser(string username, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetUser(username, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public Cdw.Objects.OperationResult EndGetUser(System.IAsyncResult result) {
            return base.Channel.EndGetUser(result);
        }
        
        private System.IAsyncResult OnBeginGetUser(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string username = ((string)(inValues[0]));
            return this.BeginGetUser(username, callback, asyncState);
        }
        
        private object[] OnEndGetUser(System.IAsyncResult result) {
            Cdw.Objects.OperationResult retVal = this.EndGetUser(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetUserCompleted(object state) {
            if ((this.GetUserCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetUserCompleted(this, new GetUserCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetUserAsync(string username) {
            this.GetUserAsync(username, null);
        }
        
        public void GetUserAsync(string username, object userState) {
            if ((this.onBeginGetUserDelegate == null)) {
                this.onBeginGetUserDelegate = new BeginOperationDelegate(this.OnBeginGetUser);
            }
            if ((this.onEndGetUserDelegate == null)) {
                this.onEndGetUserDelegate = new EndOperationDelegate(this.OnEndGetUser);
            }
            if ((this.onGetUserCompletedDelegate == null)) {
                this.onGetUserCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetUserCompleted);
            }
            base.InvokeAsync(this.onBeginGetUserDelegate, new object[] {
                        username}, this.onEndGetUserDelegate, this.onGetUserCompletedDelegate, userState);
        }
        
        public Cdw.Objects.SoftwareItem[] GetSoftware() {
            return base.Channel.GetSoftware();
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetSoftware(System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetSoftware(callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public Cdw.Objects.SoftwareItem[] EndGetSoftware(System.IAsyncResult result) {
            return base.Channel.EndGetSoftware(result);
        }
        
        private System.IAsyncResult OnBeginGetSoftware(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return this.BeginGetSoftware(callback, asyncState);
        }
        
        private object[] OnEndGetSoftware(System.IAsyncResult result) {
            Cdw.Objects.SoftwareItem[] retVal = this.EndGetSoftware(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetSoftwareCompleted(object state) {
            if ((this.GetSoftwareCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetSoftwareCompleted(this, new GetSoftwareCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetSoftwareAsync() {
            this.GetSoftwareAsync(null);
        }
        
        public void GetSoftwareAsync(object userState) {
            if ((this.onBeginGetSoftwareDelegate == null)) {
                this.onBeginGetSoftwareDelegate = new BeginOperationDelegate(this.OnBeginGetSoftware);
            }
            if ((this.onEndGetSoftwareDelegate == null)) {
                this.onEndGetSoftwareDelegate = new EndOperationDelegate(this.OnEndGetSoftware);
            }
            if ((this.onGetSoftwareCompletedDelegate == null)) {
                this.onGetSoftwareCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetSoftwareCompleted);
            }
            base.InvokeAsync(this.onBeginGetSoftwareDelegate, null, this.onEndGetSoftwareDelegate, this.onGetSoftwareCompletedDelegate, userState);
        }
        
        public Cdw.Objects.OperationResult GetNextAvailableComputerName(string prefix) {
            return base.Channel.GetNextAvailableComputerName(prefix);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetNextAvailableComputerName(string prefix, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetNextAvailableComputerName(prefix, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public Cdw.Objects.OperationResult EndGetNextAvailableComputerName(System.IAsyncResult result) {
            return base.Channel.EndGetNextAvailableComputerName(result);
        }
        
        private System.IAsyncResult OnBeginGetNextAvailableComputerName(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string prefix = ((string)(inValues[0]));
            return this.BeginGetNextAvailableComputerName(prefix, callback, asyncState);
        }
        
        private object[] OnEndGetNextAvailableComputerName(System.IAsyncResult result) {
            Cdw.Objects.OperationResult retVal = this.EndGetNextAvailableComputerName(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetNextAvailableComputerNameCompleted(object state) {
            if ((this.GetNextAvailableComputerNameCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetNextAvailableComputerNameCompleted(this, new GetNextAvailableComputerNameCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetNextAvailableComputerNameAsync(string prefix) {
            this.GetNextAvailableComputerNameAsync(prefix, null);
        }
        
        public void GetNextAvailableComputerNameAsync(string prefix, object userState) {
            if ((this.onBeginGetNextAvailableComputerNameDelegate == null)) {
                this.onBeginGetNextAvailableComputerNameDelegate = new BeginOperationDelegate(this.OnBeginGetNextAvailableComputerName);
            }
            if ((this.onEndGetNextAvailableComputerNameDelegate == null)) {
                this.onEndGetNextAvailableComputerNameDelegate = new EndOperationDelegate(this.OnEndGetNextAvailableComputerName);
            }
            if ((this.onGetNextAvailableComputerNameCompletedDelegate == null)) {
                this.onGetNextAvailableComputerNameCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetNextAvailableComputerNameCompleted);
            }
            base.InvokeAsync(this.onBeginGetNextAvailableComputerNameDelegate, new object[] {
                        prefix}, this.onEndGetNextAvailableComputerNameDelegate, this.onGetNextAvailableComputerNameCompletedDelegate, userState);
        }
        
        public Cdw.Objects.OperationResult GetComputer(string computername) {
            return base.Channel.GetComputer(computername);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetComputer(string computername, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetComputer(computername, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public Cdw.Objects.OperationResult EndGetComputer(System.IAsyncResult result) {
            return base.Channel.EndGetComputer(result);
        }
        
        private System.IAsyncResult OnBeginGetComputer(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string computername = ((string)(inValues[0]));
            return this.BeginGetComputer(computername, callback, asyncState);
        }
        
        private object[] OnEndGetComputer(System.IAsyncResult result) {
            Cdw.Objects.OperationResult retVal = this.EndGetComputer(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetComputerCompleted(object state) {
            if ((this.GetComputerCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetComputerCompleted(this, new GetComputerCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetComputerAsync(string computername) {
            this.GetComputerAsync(computername, null);
        }
        
        public void GetComputerAsync(string computername, object userState) {
            if ((this.onBeginGetComputerDelegate == null)) {
                this.onBeginGetComputerDelegate = new BeginOperationDelegate(this.OnBeginGetComputer);
            }
            if ((this.onEndGetComputerDelegate == null)) {
                this.onEndGetComputerDelegate = new EndOperationDelegate(this.OnEndGetComputer);
            }
            if ((this.onGetComputerCompletedDelegate == null)) {
                this.onGetComputerCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetComputerCompleted);
            }
            base.InvokeAsync(this.onBeginGetComputerDelegate, new object[] {
                        computername}, this.onEndGetComputerDelegate, this.onGetComputerCompletedDelegate, userState);
        }
    }
}
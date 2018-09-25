﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PolarionPlug.SessionApi {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://ws.polarion.com/SessionWebService", ConfigurationName="SessionApi.SessionWebService")]
    public interface SessionWebService {
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://ws.polarion.com/SessionWebService-impl) of message beginTransactionRequest does not match the default value (http://ws.polarion.com/SessionWebService)
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        PolarionPlug.SessionApi.beginTransactionResponse beginTransaction(PolarionPlug.SessionApi.beginTransactionRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        System.Threading.Tasks.Task<PolarionPlug.SessionApi.beginTransactionResponse> beginTransactionAsync(PolarionPlug.SessionApi.beginTransactionRequest request);
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://ws.polarion.com/SessionWebService-impl) of message endSessionRequest does not match the default value (http://ws.polarion.com/SessionWebService)
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        PolarionPlug.SessionApi.endSessionResponse endSession(PolarionPlug.SessionApi.endSessionRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        System.Threading.Tasks.Task<PolarionPlug.SessionApi.endSessionResponse> endSessionAsync(PolarionPlug.SessionApi.endSessionRequest request);
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://ws.polarion.com/SessionWebService-impl) of message endTransactionRequest does not match the default value (http://ws.polarion.com/SessionWebService)
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        PolarionPlug.SessionApi.endTransactionResponse endTransaction(PolarionPlug.SessionApi.endTransactionRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        System.Threading.Tasks.Task<PolarionPlug.SessionApi.endTransactionResponse> endTransactionAsync(PolarionPlug.SessionApi.endTransactionRequest request);
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://ws.polarion.com/SessionWebService-impl) of message hasSubjectRequest does not match the default value (http://ws.polarion.com/SessionWebService)
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        PolarionPlug.SessionApi.hasSubjectResponse hasSubject(PolarionPlug.SessionApi.hasSubjectRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        System.Threading.Tasks.Task<PolarionPlug.SessionApi.hasSubjectResponse> hasSubjectAsync(PolarionPlug.SessionApi.hasSubjectRequest request);
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://ws.polarion.com/SessionWebService-impl) of message logInRequest does not match the default value (http://ws.polarion.com/SessionWebService)
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        PolarionPlug.SessionApi.logInResponse logIn(PolarionPlug.SessionApi.logInRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        System.Threading.Tasks.Task<PolarionPlug.SessionApi.logInResponse> logInAsync(PolarionPlug.SessionApi.logInRequest request);
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://ws.polarion.com/SessionWebService-impl) of message logInWithTokenRequest does not match the default value (http://ws.polarion.com/SessionWebService)
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        PolarionPlug.SessionApi.logInWithTokenResponse logInWithToken(PolarionPlug.SessionApi.logInWithTokenRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        System.Threading.Tasks.Task<PolarionPlug.SessionApi.logInWithTokenResponse> logInWithTokenAsync(PolarionPlug.SessionApi.logInWithTokenRequest request);
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://ws.polarion.com/SessionWebService-impl) of message transactionExistsRequest does not match the default value (http://ws.polarion.com/SessionWebService)
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        PolarionPlug.SessionApi.transactionExistsResponse transactionExists(PolarionPlug.SessionApi.transactionExistsRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        System.Threading.Tasks.Task<PolarionPlug.SessionApi.transactionExistsResponse> transactionExistsAsync(PolarionPlug.SessionApi.transactionExistsRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="beginTransaction", WrapperNamespace="http://ws.polarion.com/SessionWebService-impl", IsWrapped=true)]
    public partial class beginTransactionRequest {
        
        public beginTransactionRequest() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="beginTransactionResponse", WrapperNamespace="http://ws.polarion.com/SessionWebService-impl", IsWrapped=true)]
    public partial class beginTransactionResponse {
        
        public beginTransactionResponse() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="endSession", WrapperNamespace="http://ws.polarion.com/SessionWebService-impl", IsWrapped=true)]
    public partial class endSessionRequest {
        
        public endSessionRequest() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="endSessionResponse", WrapperNamespace="http://ws.polarion.com/SessionWebService-impl", IsWrapped=true)]
    public partial class endSessionResponse {
        
        public endSessionResponse() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="endTransaction", WrapperNamespace="http://ws.polarion.com/SessionWebService-impl", IsWrapped=true)]
    public partial class endTransactionRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ws.polarion.com/SessionWebService-impl", Order=0)]
        public bool rollback;
        
        public endTransactionRequest() {
        }
        
        public endTransactionRequest(bool rollback) {
            this.rollback = rollback;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="endTransactionResponse", WrapperNamespace="http://ws.polarion.com/SessionWebService-impl", IsWrapped=true)]
    public partial class endTransactionResponse {
        
        public endTransactionResponse() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="hasSubject", WrapperNamespace="http://ws.polarion.com/SessionWebService-impl", IsWrapped=true)]
    public partial class hasSubjectRequest {
        
        public hasSubjectRequest() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="hasSubjectResponse", WrapperNamespace="http://ws.polarion.com/SessionWebService-impl", IsWrapped=true)]
    public partial class hasSubjectResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ws.polarion.com/SessionWebService-impl", Order=0)]
        public bool hasSubjectReturn;
        
        public hasSubjectResponse() {
        }
        
        public hasSubjectResponse(bool hasSubjectReturn) {
            this.hasSubjectReturn = hasSubjectReturn;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="logIn", WrapperNamespace="http://ws.polarion.com/SessionWebService-impl", IsWrapped=true)]
    public partial class logInRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ws.polarion.com/SessionWebService-impl", Order=0)]
        public string userName;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ws.polarion.com/SessionWebService-impl", Order=1)]
        public string password;
        
        public logInRequest() {
        }
        
        public logInRequest(string userName, string password) {
            this.userName = userName;
            this.password = password;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="logInResponse", WrapperNamespace="http://ws.polarion.com/SessionWebService-impl", IsWrapped=true)]
    public partial class logInResponse {
        
        public logInResponse() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="logInWithToken", WrapperNamespace="http://ws.polarion.com/SessionWebService-impl", IsWrapped=true)]
    public partial class logInWithTokenRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ws.polarion.com/SessionWebService-impl", Order=0)]
        public string mechanism;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ws.polarion.com/SessionWebService-impl", Order=1)]
        public string username;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ws.polarion.com/SessionWebService-impl", Order=2)]
        public string token;
        
        public logInWithTokenRequest() {
        }
        
        public logInWithTokenRequest(string mechanism, string username, string token) {
            this.mechanism = mechanism;
            this.username = username;
            this.token = token;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="logInWithTokenResponse", WrapperNamespace="http://ws.polarion.com/SessionWebService-impl", IsWrapped=true)]
    public partial class logInWithTokenResponse {
        
        public logInWithTokenResponse() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="transactionExists", WrapperNamespace="http://ws.polarion.com/SessionWebService-impl", IsWrapped=true)]
    public partial class transactionExistsRequest {
        
        public transactionExistsRequest() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="transactionExistsResponse", WrapperNamespace="http://ws.polarion.com/SessionWebService-impl", IsWrapped=true)]
    public partial class transactionExistsResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ws.polarion.com/SessionWebService-impl", Order=0)]
        public bool transactionExistsReturn;
        
        public transactionExistsResponse() {
        }
        
        public transactionExistsResponse(bool transactionExistsReturn) {
            this.transactionExistsReturn = transactionExistsReturn;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface SessionWebServiceChannel : PolarionPlug.SessionApi.SessionWebService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SessionWebServiceClient : System.ServiceModel.ClientBase<PolarionPlug.SessionApi.SessionWebService>, PolarionPlug.SessionApi.SessionWebService {
        
        public SessionWebServiceClient() {
        }
        
        public SessionWebServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SessionWebServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SessionWebServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SessionWebServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        PolarionPlug.SessionApi.beginTransactionResponse PolarionPlug.SessionApi.SessionWebService.beginTransaction(PolarionPlug.SessionApi.beginTransactionRequest request) {
            return base.Channel.beginTransaction(request);
        }
        
        public void beginTransaction() {
            PolarionPlug.SessionApi.beginTransactionRequest inValue = new PolarionPlug.SessionApi.beginTransactionRequest();
            PolarionPlug.SessionApi.beginTransactionResponse retVal = ((PolarionPlug.SessionApi.SessionWebService)(this)).beginTransaction(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<PolarionPlug.SessionApi.beginTransactionResponse> PolarionPlug.SessionApi.SessionWebService.beginTransactionAsync(PolarionPlug.SessionApi.beginTransactionRequest request) {
            return base.Channel.beginTransactionAsync(request);
        }
        
        public System.Threading.Tasks.Task<PolarionPlug.SessionApi.beginTransactionResponse> beginTransactionAsync() {
            PolarionPlug.SessionApi.beginTransactionRequest inValue = new PolarionPlug.SessionApi.beginTransactionRequest();
            return ((PolarionPlug.SessionApi.SessionWebService)(this)).beginTransactionAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        PolarionPlug.SessionApi.endSessionResponse PolarionPlug.SessionApi.SessionWebService.endSession(PolarionPlug.SessionApi.endSessionRequest request) {
            return base.Channel.endSession(request);
        }
        
        public void endSession() {
            PolarionPlug.SessionApi.endSessionRequest inValue = new PolarionPlug.SessionApi.endSessionRequest();
            PolarionPlug.SessionApi.endSessionResponse retVal = ((PolarionPlug.SessionApi.SessionWebService)(this)).endSession(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<PolarionPlug.SessionApi.endSessionResponse> PolarionPlug.SessionApi.SessionWebService.endSessionAsync(PolarionPlug.SessionApi.endSessionRequest request) {
            return base.Channel.endSessionAsync(request);
        }
        
        public System.Threading.Tasks.Task<PolarionPlug.SessionApi.endSessionResponse> endSessionAsync() {
            PolarionPlug.SessionApi.endSessionRequest inValue = new PolarionPlug.SessionApi.endSessionRequest();
            return ((PolarionPlug.SessionApi.SessionWebService)(this)).endSessionAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        PolarionPlug.SessionApi.endTransactionResponse PolarionPlug.SessionApi.SessionWebService.endTransaction(PolarionPlug.SessionApi.endTransactionRequest request) {
            return base.Channel.endTransaction(request);
        }
        
        public void endTransaction(bool rollback) {
            PolarionPlug.SessionApi.endTransactionRequest inValue = new PolarionPlug.SessionApi.endTransactionRequest();
            inValue.rollback = rollback;
            PolarionPlug.SessionApi.endTransactionResponse retVal = ((PolarionPlug.SessionApi.SessionWebService)(this)).endTransaction(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<PolarionPlug.SessionApi.endTransactionResponse> PolarionPlug.SessionApi.SessionWebService.endTransactionAsync(PolarionPlug.SessionApi.endTransactionRequest request) {
            return base.Channel.endTransactionAsync(request);
        }
        
        public System.Threading.Tasks.Task<PolarionPlug.SessionApi.endTransactionResponse> endTransactionAsync(bool rollback) {
            PolarionPlug.SessionApi.endTransactionRequest inValue = new PolarionPlug.SessionApi.endTransactionRequest();
            inValue.rollback = rollback;
            return ((PolarionPlug.SessionApi.SessionWebService)(this)).endTransactionAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        PolarionPlug.SessionApi.hasSubjectResponse PolarionPlug.SessionApi.SessionWebService.hasSubject(PolarionPlug.SessionApi.hasSubjectRequest request) {
            return base.Channel.hasSubject(request);
        }
        
        public bool hasSubject() {
            PolarionPlug.SessionApi.hasSubjectRequest inValue = new PolarionPlug.SessionApi.hasSubjectRequest();
            PolarionPlug.SessionApi.hasSubjectResponse retVal = ((PolarionPlug.SessionApi.SessionWebService)(this)).hasSubject(inValue);
            return retVal.hasSubjectReturn;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<PolarionPlug.SessionApi.hasSubjectResponse> PolarionPlug.SessionApi.SessionWebService.hasSubjectAsync(PolarionPlug.SessionApi.hasSubjectRequest request) {
            return base.Channel.hasSubjectAsync(request);
        }
        
        public System.Threading.Tasks.Task<PolarionPlug.SessionApi.hasSubjectResponse> hasSubjectAsync() {
            PolarionPlug.SessionApi.hasSubjectRequest inValue = new PolarionPlug.SessionApi.hasSubjectRequest();
            return ((PolarionPlug.SessionApi.SessionWebService)(this)).hasSubjectAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        PolarionPlug.SessionApi.logInResponse PolarionPlug.SessionApi.SessionWebService.logIn(PolarionPlug.SessionApi.logInRequest request) {
            return base.Channel.logIn(request);
        }
        
        public void logIn(string userName, string password) {
            PolarionPlug.SessionApi.logInRequest inValue = new PolarionPlug.SessionApi.logInRequest();
            inValue.userName = userName;
            inValue.password = password;
            PolarionPlug.SessionApi.logInResponse retVal = ((PolarionPlug.SessionApi.SessionWebService)(this)).logIn(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<PolarionPlug.SessionApi.logInResponse> PolarionPlug.SessionApi.SessionWebService.logInAsync(PolarionPlug.SessionApi.logInRequest request) {
            return base.Channel.logInAsync(request);
        }
        
        public System.Threading.Tasks.Task<PolarionPlug.SessionApi.logInResponse> logInAsync(string userName, string password) {
            PolarionPlug.SessionApi.logInRequest inValue = new PolarionPlug.SessionApi.logInRequest();
            inValue.userName = userName;
            inValue.password = password;
            return ((PolarionPlug.SessionApi.SessionWebService)(this)).logInAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        PolarionPlug.SessionApi.logInWithTokenResponse PolarionPlug.SessionApi.SessionWebService.logInWithToken(PolarionPlug.SessionApi.logInWithTokenRequest request) {
            return base.Channel.logInWithToken(request);
        }
        
        public void logInWithToken(string mechanism, string username, string token) {
            PolarionPlug.SessionApi.logInWithTokenRequest inValue = new PolarionPlug.SessionApi.logInWithTokenRequest();
            inValue.mechanism = mechanism;
            inValue.username = username;
            inValue.token = token;
            PolarionPlug.SessionApi.logInWithTokenResponse retVal = ((PolarionPlug.SessionApi.SessionWebService)(this)).logInWithToken(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<PolarionPlug.SessionApi.logInWithTokenResponse> PolarionPlug.SessionApi.SessionWebService.logInWithTokenAsync(PolarionPlug.SessionApi.logInWithTokenRequest request) {
            return base.Channel.logInWithTokenAsync(request);
        }
        
        public System.Threading.Tasks.Task<PolarionPlug.SessionApi.logInWithTokenResponse> logInWithTokenAsync(string mechanism, string username, string token) {
            PolarionPlug.SessionApi.logInWithTokenRequest inValue = new PolarionPlug.SessionApi.logInWithTokenRequest();
            inValue.mechanism = mechanism;
            inValue.username = username;
            inValue.token = token;
            return ((PolarionPlug.SessionApi.SessionWebService)(this)).logInWithTokenAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        PolarionPlug.SessionApi.transactionExistsResponse PolarionPlug.SessionApi.SessionWebService.transactionExists(PolarionPlug.SessionApi.transactionExistsRequest request) {
            return base.Channel.transactionExists(request);
        }
        
        public bool transactionExists() {
            PolarionPlug.SessionApi.transactionExistsRequest inValue = new PolarionPlug.SessionApi.transactionExistsRequest();
            PolarionPlug.SessionApi.transactionExistsResponse retVal = ((PolarionPlug.SessionApi.SessionWebService)(this)).transactionExists(inValue);
            return retVal.transactionExistsReturn;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<PolarionPlug.SessionApi.transactionExistsResponse> PolarionPlug.SessionApi.SessionWebService.transactionExistsAsync(PolarionPlug.SessionApi.transactionExistsRequest request) {
            return base.Channel.transactionExistsAsync(request);
        }
        
        public System.Threading.Tasks.Task<PolarionPlug.SessionApi.transactionExistsResponse> transactionExistsAsync() {
            PolarionPlug.SessionApi.transactionExistsRequest inValue = new PolarionPlug.SessionApi.transactionExistsRequest();
            return ((PolarionPlug.SessionApi.SessionWebService)(this)).transactionExistsAsync(inValue);
        }
    }
}

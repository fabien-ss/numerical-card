namespace Sante.BanqueService
{
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://restService/")]
    public partial class Exception
    {
        
        private string messageField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string message
        {
            get
            {
                return this.messageField;
            }
            set
            {
                this.messageField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://restService/")]
    public partial class solde
    {
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://restService/")]
    public partial class timestamp
    {
        
        private int nanosField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public int nanos
        {
            get
            {
                return this.nanosField;
            }
            set
            {
                this.nanosField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(input))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(output))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(banque))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://restService/")]
    public partial class model
    {
        
        private int longPKField;
        
        private string passwordField;
        
        private string prefixeField;
        
        private string sequenceField;
        
        private string urlField;
        
        private string usernameField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public int longPK
        {
            get
            {
                return this.longPKField;
            }
            set
            {
                this.longPKField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string password
        {
            get
            {
                return this.passwordField;
            }
            set
            {
                this.passwordField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public string prefixe
        {
            get
            {
                return this.prefixeField;
            }
            set
            {
                this.prefixeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public string sequence
        {
            get
            {
                return this.sequenceField;
            }
            set
            {
                this.sequenceField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=4)]
        public string url
        {
            get
            {
                return this.urlField;
            }
            set
            {
                this.urlField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=5)]
        public string username
        {
            get
            {
                return this.usernameField;
            }
            set
            {
                this.usernameField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://restService/")]
    public partial class input : model
    {
        
        private string cinField;
        
        private timestamp dateField;
        
        private string idBanqueField;
        
        private double moneyField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string cin
        {
            get
            {
                return this.cinField;
            }
            set
            {
                this.cinField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public timestamp date
        {
            get
            {
                return this.dateField;
            }
            set
            {
                this.dateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public string idBanque
        {
            get
            {
                return this.idBanqueField;
            }
            set
            {
                this.idBanqueField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public double money
        {
            get
            {
                return this.moneyField;
            }
            set
            {
                this.moneyField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://restService/")]
    public partial class output : model
    {
        
        private string cinField;
        
        private timestamp dateField;
        
        private string idBanqueField;
        
        private double moneyField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string cin
        {
            get
            {
                return this.cinField;
            }
            set
            {
                this.cinField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public timestamp date
        {
            get
            {
                return this.dateField;
            }
            set
            {
                this.dateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public string idBanque
        {
            get
            {
                return this.idBanqueField;
            }
            set
            {
                this.idBanqueField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public double money
        {
            get
            {
                return this.moneyField;
            }
            set
            {
                this.moneyField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://restService/")]
    public partial class banque : model
    {
        
        private output[] creditsField;
        
        private input[] debitsField;
        
        private int idBanqueField;
        
        private string nomField;
        
        private solde soldeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("credits", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true, Order=0)]
        public output[] credits
        {
            get
            {
                return this.creditsField;
            }
            set
            {
                this.creditsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("debits", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true, Order=1)]
        public input[] debits
        {
            get
            {
                return this.debitsField;
            }
            set
            {
                this.debitsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public int idBanque
        {
            get
            {
                return this.idBanqueField;
            }
            set
            {
                this.idBanqueField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public string nom
        {
            get
            {
                return this.nomField;
            }
            set
            {
                this.nomField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=4)]
        public solde solde
        {
            get
            {
                return this.soldeField;
            }
            set
            {
                this.soldeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://restService/")]
    public partial class civil
    {
        
        private banque[] banquesField;
        
        private string cinField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("banques", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true, Order=0)]
        public banque[] banques
        {
            get
            {
                return this.banquesField;
            }
            set
            {
                this.banquesField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string cin
        {
            get
            {
                return this.cinField;
            }
            set
            {
                this.cinField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://restService/", ConfigurationName="Sante.BanqueService.BanqueService")]
    public interface BanqueService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://restService/BanqueService/consulationSoldeRequest", ReplyAction="http://restService/BanqueService/consulationSoldeResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Sante.BanqueService.Exception), Action="http://restService/BanqueService/consulationSolde/Fault/Exception", Name="Exception")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(model))]
        System.Threading.Tasks.Task<Sante.BanqueService.consulationSoldeResponse> consulationSoldeAsync(Sante.BanqueService.consulationSoldeRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://restService/BanqueService/getBanqueRequest", ReplyAction="http://restService/BanqueService/getBanqueResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(model))]
        System.Threading.Tasks.Task<Sante.BanqueService.getBanqueResponse> getBanqueAsync(Sante.BanqueService.getBanqueRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://restService/BanqueService/helloRequest", ReplyAction="http://restService/BanqueService/helloResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(model))]
        System.Threading.Tasks.Task<Sante.BanqueService.helloResponse> helloAsync(Sante.BanqueService.helloRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="consulationSolde", WrapperNamespace="http://restService/", IsWrapped=true)]
    public partial class consulationSoldeRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://restService/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string arg0;
        
        public consulationSoldeRequest()
        {
        }
        
        public consulationSoldeRequest(string arg0)
        {
            this.arg0 = arg0;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="consulationSoldeResponse", WrapperNamespace="http://restService/", IsWrapped=true)]
    public partial class consulationSoldeResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://restService/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Sante.BanqueService.civil @return;
        
        public consulationSoldeResponse()
        {
        }
        
        public consulationSoldeResponse(Sante.BanqueService.civil @return)
        {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getBanque", WrapperNamespace="http://restService/", IsWrapped=true)]
    public partial class getBanqueRequest
    {
        
        public getBanqueRequest()
        {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getBanqueResponse", WrapperNamespace="http://restService/", IsWrapped=true)]
    public partial class getBanqueResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://restService/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string @return;
        
        public getBanqueResponse()
        {
        }
        
        public getBanqueResponse(string @return)
        {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="hello", WrapperNamespace="http://restService/", IsWrapped=true)]
    public partial class helloRequest
    {
        
        public helloRequest()
        {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="helloResponse", WrapperNamespace="http://restService/", IsWrapped=true)]
    public partial class helloResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://restService/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string @return;
        
        public helloResponse()
        {
        }
        
        public helloResponse(string @return)
        {
            this.@return = @return;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    public interface BanqueServiceChannel : Sante.BanqueService.BanqueService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    public partial class BanqueServiceClient : System.ServiceModel.ClientBase<Sante.BanqueService.BanqueService>, Sante.BanqueService.BanqueService
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public BanqueServiceClient() : 
                base(BanqueServiceClient.GetDefaultBinding(), BanqueServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BanqueServicePort.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public BanqueServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(BanqueServiceClient.GetBindingForEndpoint(endpointConfiguration), BanqueServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public BanqueServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(BanqueServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public BanqueServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(BanqueServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public BanqueServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Sante.BanqueService.consulationSoldeResponse> Sante.BanqueService.BanqueService.consulationSoldeAsync(Sante.BanqueService.consulationSoldeRequest request)
        {
            return base.Channel.consulationSoldeAsync(request);
        }
        
        public System.Threading.Tasks.Task<Sante.BanqueService.consulationSoldeResponse> consulationSoldeAsync(string arg0)
        {
            Sante.BanqueService.consulationSoldeRequest inValue = new Sante.BanqueService.consulationSoldeRequest();
            inValue.arg0 = arg0;
            return ((Sante.BanqueService.BanqueService)(this)).consulationSoldeAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Sante.BanqueService.getBanqueResponse> Sante.BanqueService.BanqueService.getBanqueAsync(Sante.BanqueService.getBanqueRequest request)
        {
            return base.Channel.getBanqueAsync(request);
        }
        
        public System.Threading.Tasks.Task<Sante.BanqueService.getBanqueResponse> getBanqueAsync()
        {
            Sante.BanqueService.getBanqueRequest inValue = new Sante.BanqueService.getBanqueRequest();
            return ((Sante.BanqueService.BanqueService)(this)).getBanqueAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Sante.BanqueService.helloResponse> Sante.BanqueService.BanqueService.helloAsync(Sante.BanqueService.helloRequest request)
        {
            return base.Channel.helloAsync(request);
        }
        
        public System.Threading.Tasks.Task<Sante.BanqueService.helloResponse> helloAsync()
        {
            Sante.BanqueService.helloRequest inValue = new Sante.BanqueService.helloRequest();
            return ((Sante.BanqueService.BanqueService)(this)).helloAsync(inValue);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BanqueServicePort))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BanqueServicePort))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:8080/BanqueService/BanqueService");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return BanqueServiceClient.GetBindingForEndpoint(EndpointConfiguration.BanqueServicePort);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return BanqueServiceClient.GetEndpointAddress(EndpointConfiguration.BanqueServicePort);
        }
        
        public enum EndpointConfiguration
        {
            
            BanqueServicePort,
        }
    }
}

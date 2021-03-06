namespace tae
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.onvif.org/ver10/actionengine/wsdl")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.onvif.org/ver10/actionengine/wsdl", IsNullable = false)]
    public partial class EMailServerConfiguration
    {

        private SMTPConfig sMTPConfigField;

        private POPConfig pOPConfigField;

        private AuthenticationConfig authenticationConfigField;

        private System.Xml.XmlElement[] anyField;

        private System.Xml.XmlAttribute[] anyAttrField;

        /// <remarks/>
        public SMTPConfig SMTPConfig
        {
            get
            {
                return this.sMTPConfigField;
            }
            set
            {
                this.sMTPConfigField = value;
            }
        }

        /// <remarks/>
        public POPConfig POPConfig
        {
            get
            {
                return this.pOPConfigField;
            }
            set
            {
                this.pOPConfigField = value;
            }
        }

        /// <remarks/>
        public AuthenticationConfig AuthenticationConfig
        {
            get
            {
                return this.authenticationConfigField;
            }
            set
            {
                this.authenticationConfigField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.onvif.org/ver10/actionengine/wsdl")]
    public partial class SMTPConfig
    {

        private HostAddress hostAddressField;

        private System.Xml.XmlElement[] anyField;

        private string portNoField;

        private System.Xml.XmlAttribute[] anyAttrField;

        /// <remarks/>
        public HostAddress HostAddress
        {
            get
            {
                return this.hostAddressField;
            }
            set
            {
                this.hostAddressField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "positiveInteger")]
        public string portNo
        {
            get
            {
                return this.portNoField;
            }
            set
            {
                this.portNoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.onvif.org/ver10/actionengine/wsdl")]
    public partial class HostAddress
    {

        private string valueField;

        private System.Xml.XmlElement[] anyField;

        private AddressFormatType formatTypeField;

        private System.Xml.XmlAttribute[] anyAttrField;

        /// <remarks/>
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public AddressFormatType formatType
        {
            get
            {
                return this.formatTypeField;
            }
            set
            {
                this.formatTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.onvif.org/ver10/actionengine/wsdl")]
    public enum AddressFormatType
    {

        /// <remarks/>
        hostname,

        /// <remarks/>
        ipv4,

        /// <remarks/>
        ipv6,

        /// <remarks/>
        Extended,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.onvif.org/ver10/actionengine/wsdl")]
    public partial class PostBodyConfiguration
    {

        private System.Xml.XmlElement[] anyField;

        private string formDataField;

        private bool includeEventField;

        private bool includeEventFieldSpecified;

        private bool includeMediaField;

        private bool includeMediaFieldSpecified;

        private System.Xml.XmlAttribute[] anyAttrField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string formData
        {
            get
            {
                return this.formDataField;
            }
            set
            {
                this.formDataField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool includeEvent
        {
            get
            {
                return this.includeEventField;
            }
            set
            {
                this.includeEventField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool includeEventSpecified
        {
            get
            {
                return this.includeEventFieldSpecified;
            }
            set
            {
                this.includeEventFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool includeMedia
        {
            get
            {
                return this.includeMediaField;
            }
            set
            {
                this.includeMediaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool includeMediaSpecified
        {
            get
            {
                return this.includeMediaFieldSpecified;
            }
            set
            {
                this.includeMediaFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.onvif.org/ver10/actionengine/wsdl")]
    public partial class HttpHostConfigurationsExtension
    {

        private System.Xml.XmlElement[] anyField;

        private System.Xml.XmlAttribute[] anyAttrField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.onvif.org/ver10/actionengine/wsdl")]
    public partial class HttpDestinationConfigurationExtension
    {

        private System.Xml.XmlElement[] anyField;

        private System.Xml.XmlAttribute[] anyAttrField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.onvif.org/ver10/actionengine/wsdl")]
    public partial class HttpAuthenticationConfigurationExtension
    {

        private System.Xml.XmlElement[] anyField;

        private System.Xml.XmlAttribute[] anyAttrField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.onvif.org/ver10/actionengine/wsdl")]
    public partial class HttpAuthenticationConfiguration
    {

        private UserCredentials userField;

        private HttpAuthenticationConfigurationExtension extensionField;

        private HttpAuthenticationMethodType methodField;

        private System.Xml.XmlAttribute[] anyAttrField;

        public HttpAuthenticationConfiguration()
        {
            this.methodField = HttpAuthenticationMethodType.none;
        }

        /// <remarks/>
        public UserCredentials User
        {
            get
            {
                return this.userField;
            }
            set
            {
                this.userField = value;
            }
        }

        /// <remarks/>
        public HttpAuthenticationConfigurationExtension Extension
        {
            get
            {
                return this.extensionField;
            }
            set
            {
                this.extensionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(HttpAuthenticationMethodType.none)]
        public HttpAuthenticationMethodType method
        {
            get
            {
                return this.methodField;
            }
            set
            {
                this.methodField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.onvif.org/ver10/actionengine/wsdl")]
    public partial class UserCredentials
    {

        private string usernameField;

        private byte[] passwordField;

        private UserCredentialsExtension extensionField;

        private System.Xml.XmlAttribute[] anyAttrField;

        /// <remarks/>
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

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary")]
        public byte[] password
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
        public UserCredentialsExtension Extension
        {
            get
            {
                return this.extensionField;
            }
            set
            {
                this.extensionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.onvif.org/ver10/actionengine/wsdl")]
    public partial class UserCredentialsExtension
    {

        private System.Xml.XmlElement[] anyField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.onvif.org/ver10/actionengine/wsdl")]
    public enum HttpAuthenticationMethodType
    {

        /// <remarks/>
        none,

        /// <remarks/>
        MD5Digest,

        /// <remarks/>
        Extended,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.onvif.org/ver10/actionengine/wsdl")]
    public partial class HttpHostAddress
    {

        private string valueField;

        private System.Xml.XmlElement[] anyField;

        private AddressFormatType formatTypeField;

        private string portNoField;

        private System.Xml.XmlAttribute[] anyAttrField;

        public HttpHostAddress()
        {
            this.portNoField = "80";
        }

        /// <remarks/>
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public AddressFormatType formatType
        {
            get
            {
                return this.formatTypeField;
            }
            set
            {
                this.formatTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        [System.ComponentModel.DefaultValueAttribute("80")]
        public string portNo
        {
            get
            {
                return this.portNoField;
            }
            set
            {
                this.portNoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.onvif.org/ver10/actionengine/wsdl")]
    public partial class HttpDestinationConfiguration
    {

        private HttpHostAddress hostAddressField;

        private HttpAuthenticationConfiguration httpAuthenticationField;

        private HttpDestinationConfigurationExtension extensionField;

        private string uriField;

        private HttpProtocolType protocolField;

        private System.Xml.XmlAttribute[] anyAttrField;

        public HttpDestinationConfiguration()
        {
            this.uriField = "/";
            this.protocolField = HttpProtocolType.http;
        }

        /// <remarks/>
        public HttpHostAddress HostAddress
        {
            get
            {
                return this.hostAddressField;
            }
            set
            {
                this.hostAddressField = value;
            }
        }

        /// <remarks/>
        public HttpAuthenticationConfiguration HttpAuthentication
        {
            get
            {
                return this.httpAuthenticationField;
            }
            set
            {
                this.httpAuthenticationField = value;
            }
        }

        /// <remarks/>
        public HttpDestinationConfigurationExtension Extension
        {
            get
            {
                return this.extensionField;
            }
            set
            {
                this.extensionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute("/")]
        public string uri
        {
            get
            {
                return this.uriField;
            }
            set
            {
                this.uriField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(HttpProtocolType.http)]
        public HttpProtocolType protocol
        {
            get
            {
                return this.protocolField;
            }
            set
            {
                this.protocolField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.onvif.org/ver10/actionengine/wsdl")]
    public enum HttpProtocolType
    {

        /// <remarks/>
        http,

        /// <remarks/>
        https,

        /// <remarks/>
        Extended,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.onvif.org/ver10/actionengine/wsdl")]
    public partial class TriggeredRecordingConfiguration
    {

        private string preRecordDurationField;

        private string postRecordDurationField;

        private string recordDurationField;

        private string recordFrameRateField;

        private bool doRecordAudioField;

        private System.Xml.XmlElement[] anyField;

        private System.Xml.XmlAttribute[] anyAttrField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "duration")]
        public string PreRecordDuration
        {
            get
            {
                return this.preRecordDurationField;
            }
            set
            {
                this.preRecordDurationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "duration")]
        public string PostRecordDuration
        {
            get
            {
                return this.postRecordDurationField;
            }
            set
            {
                this.postRecordDurationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "duration")]
        public string RecordDuration
        {
            get
            {
                return this.recordDurationField;
            }
            set
            {
                this.recordDurationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "positiveInteger")]
        public string RecordFrameRate
        {
            get
            {
                return this.recordFrameRateField;
            }
            set
            {
                this.recordFrameRateField = value;
            }
        }

        /// <remarks/>
        public bool DoRecordAudio
        {
            get
            {
                return this.doRecordAudioField;
            }
            set
            {
                this.doRecordAudioField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.onvif.org/ver10/actionengine/wsdl")]
    public partial class FtpContentConfigurationUploadFile
    {

        private string sourceFileNameField;

        private string destinationFileNameField;

        private System.Xml.XmlElement[] anyField;

        private System.Xml.XmlAttribute[] anyAttrField;

        /// <remarks/>
        public string sourceFileName
        {
            get
            {
                return this.sourceFileNameField;
            }
            set
            {
                this.sourceFileNameField = value;
            }
        }

        /// <remarks/>
        public string destinationFileName
        {
            get
            {
                return this.destinationFileNameField;
            }
            set
            {
                this.destinationFileNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.onvif.org/ver10/actionengine/wsdl")]
    public partial class FtpFileNameConfigurations
    {

        private System.Xml.XmlElement[] anyField;

        private string file_nameField;

        private FileSuffixType suffixField;

        private System.Xml.XmlAttribute[] anyAttrField;

        public FtpFileNameConfigurations()
        {
            this.suffixField = FileSuffixType.none;
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string file_name
        {
            get
            {
                return this.file_nameField;
            }
            set
            {
                this.file_nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(FileSuffixType.none)]
        public FileSuffixType suffix
        {
            get
            {
                return this.suffixField;
            }
            set
            {
                this.suffixField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.onvif.org/ver10/actionengine/wsdl")]
    public enum FileSuffixType
    {

        /// <remarks/>
        none,

        /// <remarks/>
        sequence,

        /// <remarks/>
        dateTime,

        /// <remarks/>
        Extended,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.onvif.org/ver10/actionengine/wsdl")]
    public partial class FtpContentConfigurationUploadImages
    {

        private string howLongField;

        private string sampleIntervalField;

        private FtpFileNameConfigurations fileNameField;

        private System.Xml.XmlElement[] anyField;

        private System.Xml.XmlAttribute[] anyAttrField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "duration")]
        public string HowLong
        {
            get
            {
                return this.howLongField;
            }
            set
            {
                this.howLongField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "duration")]
        public string SampleInterval
        {
            get
            {
                return this.sampleIntervalField;
            }
            set
            {
                this.sampleIntervalField = value;
            }
        }

        /// <remarks/>
        public FtpFileNameConfigurations FileName
        {
            get
            {
                return this.fileNameField;
            }
            set
            {
                this.fileNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.onvif.org/ver10/actionengine/wsdl")]
    public partial class FtpHostConfigurationsExtension
    {

        private System.Xml.XmlElement[] anyField;

        private System.Xml.XmlAttribute[] anyAttrField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.onvif.org/ver10/actionengine/wsdl")]
    public partial class FtpDestinationConfigurationExtension
    {

        private System.Xml.XmlElement[] anyField;

        private System.Xml.XmlAttribute[] anyAttrField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.onvif.org/ver10/actionengine/wsdl")]
    public partial class FtpAuthenticationConfigurationExtension
    {

        private System.Xml.XmlElement[] anyField;

        private System.Xml.XmlAttribute[] anyAttrField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.onvif.org/ver10/actionengine/wsdl")]
    public partial class FtpAuthenticationConfiguration
    {

        private UserCredentials userField;

        private FtpAuthenticationConfigurationExtension extensionField;

        private System.Xml.XmlAttribute[] anyAttrField;

        /// <remarks/>
        public UserCredentials User
        {
            get
            {
                return this.userField;
            }
            set
            {
                this.userField = value;
            }
        }

        /// <remarks/>
        public FtpAuthenticationConfigurationExtension Extension
        {
            get
            {
                return this.extensionField;
            }
            set
            {
                this.extensionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.onvif.org/ver10/actionengine/wsdl")]
    public partial class FtpHostAddress
    {

        private string valueField;

        private System.Xml.XmlElement[] anyField;

        private AddressFormatType formatTypeField;

        private string portNoField;

        private System.Xml.XmlAttribute[] anyAttrField;

        public FtpHostAddress()
        {
            this.portNoField = "21";
        }

        /// <remarks/>
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public AddressFormatType formatType
        {
            get
            {
                return this.formatTypeField;
            }
            set
            {
                this.formatTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        [System.ComponentModel.DefaultValueAttribute("21")]
        public string portNo
        {
            get
            {
                return this.portNoField;
            }
            set
            {
                this.portNoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.onvif.org/ver10/actionengine/wsdl")]
    public partial class FtpDestinationConfiguration
    {

        private FtpHostAddress hostAddressField;

        private string uploadPathField;

        private FtpAuthenticationConfiguration ftpAuthenticationField;

        private FtpDestinationConfigurationExtension extensionField;

        private System.Xml.XmlAttribute[] anyAttrField;

        /// <remarks/>
        public FtpHostAddress HostAddress
        {
            get
            {
                return this.hostAddressField;
            }
            set
            {
                this.hostAddressField = value;
            }
        }

        /// <remarks/>
        public string UploadPath
        {
            get
            {
                return this.uploadPathField;
            }
            set
            {
                this.uploadPathField = value;
            }
        }

        /// <remarks/>
        public FtpAuthenticationConfiguration FtpAuthentication
        {
            get
            {
                return this.ftpAuthenticationField;
            }
            set
            {
                this.ftpAuthenticationField = value;
            }
        }

        /// <remarks/>
        public FtpDestinationConfigurationExtension Extension
        {
            get
            {
                return this.extensionField;
            }
            set
            {
                this.extensionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.onvif.org/ver10/actionengine/wsdl")]
    public partial class EMailAttachmentConfigurationExtension
    {

        private System.Xml.XmlElement[] anyField;

        private System.Xml.XmlAttribute[] anyAttrField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.onvif.org/ver10/actionengine/wsdl")]
    public partial class EMailReceiverConfigurationExtension
    {

        private System.Xml.XmlElement[] anyField;

        private System.Xml.XmlAttribute[] anyAttrField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.onvif.org/ver10/actionengine/wsdl")]
    public partial class AuthenticationConfig
    {

        private UserCredentials userField;

        private System.Xml.XmlElement[] anyField;

        private EMailAuthenticationMode modeField;

        private System.Xml.XmlAttribute[] anyAttrField;

        /// <remarks/>
        public UserCredentials User
        {
            get
            {
                return this.userField;
            }
            set
            {
                this.userField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public EMailAuthenticationMode mode
        {
            get
            {
                return this.modeField;
            }
            set
            {
                this.modeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.onvif.org/ver10/actionengine/wsdl")]
    public enum EMailAuthenticationMode
    {

        /// <remarks/>
        none,

        /// <remarks/>
        SMTP,

        /// <remarks/>
        POPSMTP,

        /// <remarks/>
        Extended,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.onvif.org/ver10/actionengine/wsdl")]
    public partial class POPConfig
    {

        private HostAddress hostAddressField;

        private System.Xml.XmlElement[] anyField;

        private System.Xml.XmlAttribute[] anyAttrField;

        /// <remarks/>
        public HostAddress HostAddress
        {
            get
            {
                return this.hostAddressField;
            }
            set
            {
                this.hostAddressField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.onvif.org/ver10/actionengine/wsdl")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.onvif.org/ver10/actionengine/wsdl", IsNullable = false)]
    public partial class EMailReceiverConfiguration
    {

        private string[] toField;

        private string[] ccField;

        private EMailReceiverConfigurationExtension extensionField;

        private System.Xml.XmlElement[] anyField;

        private System.Xml.XmlAttribute[] anyAttrField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TO")]
        public string[] TO
        {
            get
            {
                return this.toField;
            }
            set
            {
                this.toField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CC")]
        public string[] CC
        {
            get
            {
                return this.ccField;
            }
            set
            {
                this.ccField = value;
            }
        }

        /// <remarks/>
        public EMailReceiverConfigurationExtension Extension
        {
            get
            {
                return this.extensionField;
            }
            set
            {
                this.extensionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.onvif.org/ver10/actionengine/wsdl")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.onvif.org/ver10/actionengine/wsdl", IsNullable = false)]
    public partial class EMailBodyTextConfiguration
    {

        private System.Xml.XmlElement[] anyField;

        private bool includeEventField;

        private bool includeEventFieldSpecified;

        private string typeField;

        private System.Xml.XmlAttribute[] anyAttrField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool includeEvent
        {
            get
            {
                return this.includeEventField;
            }
            set
            {
                this.includeEventField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool includeEventSpecified
        {
            get
            {
                return this.includeEventFieldSpecified;
            }
            set
            {
                this.includeEventFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.onvif.org/ver10/actionengine/wsdl")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.onvif.org/ver10/actionengine/wsdl", IsNullable = false)]
    public partial class EMailAttachmentConfiguration
    {

        private string fileNameField;

        private FileSuffixType doSuffixField;

        private bool doSuffixFieldSpecified;

        private EMailAttachmentConfigurationExtension extensionField;

        private System.Xml.XmlElement[] anyField;

        private System.Xml.XmlAttribute[] anyAttrField;

        /// <remarks/>
        public string FileName
        {
            get
            {
                return this.fileNameField;
            }
            set
            {
                this.fileNameField = value;
            }
        }

        /// <remarks/>
        public FileSuffixType doSuffix
        {
            get
            {
                return this.doSuffixField;
            }
            set
            {
                this.doSuffixField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool doSuffixSpecified
        {
            get
            {
                return this.doSuffixFieldSpecified;
            }
            set
            {
                this.doSuffixFieldSpecified = value;
            }
        }

        /// <remarks/>
        public EMailAttachmentConfigurationExtension Extension
        {
            get
            {
                return this.extensionField;
            }
            set
            {
                this.extensionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.onvif.org/ver10/actionengine/wsdl")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.onvif.org/ver10/actionengine/wsdl", IsNullable = false)]
    public partial class MediaSource
    {

        private string profileTokenField;

        private System.Xml.XmlElement[] anyField;

        private System.Xml.XmlAttribute[] anyAttrField;

        /// <remarks/>
        public string ProfileToken
        {
            get
            {
                return this.profileTokenField;
            }
            set
            {
                this.profileTokenField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.onvif.org/ver10/actionengine/wsdl")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.onvif.org/ver10/actionengine/wsdl", IsNullable = false)]
    public partial class FtpHostConfigurations
    {

        private FtpDestinationConfiguration[] ftpDestinationField;

        private FtpHostConfigurationsExtension extensionField;

        private System.Xml.XmlAttribute[] anyAttrField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FtpDestination")]
        public FtpDestinationConfiguration[] FtpDestination
        {
            get
            {
                return this.ftpDestinationField;
            }
            set
            {
                this.ftpDestinationField = value;
            }
        }

        /// <remarks/>
        public FtpHostConfigurationsExtension Extension
        {
            get
            {
                return this.extensionField;
            }
            set
            {
                this.extensionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.onvif.org/ver10/actionengine/wsdl")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.onvif.org/ver10/actionengine/wsdl", IsNullable = false)]
    public partial class FtpContentConfiguration
    {

        private object itemField;

        private System.Xml.XmlElement[] anyField;

        private string typeField;

        private System.Xml.XmlAttribute[] anyAttrField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("UploadFile", typeof(FtpContentConfigurationUploadFile))]
        [System.Xml.Serialization.XmlElementAttribute("UploadImages", typeof(FtpContentConfigurationUploadImages))]
        public object Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.onvif.org/ver10/actionengine/wsdl")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.onvif.org/ver10/actionengine/wsdl", IsNullable = false)]
    public partial class RecordingActionConfiguration
    {

        private TriggeredRecordingConfiguration recordConfigField;

        private System.Xml.XmlElement[] anyField;

        private System.Xml.XmlAttribute[] anyAttrField;

        /// <remarks/>
        public TriggeredRecordingConfiguration RecordConfig
        {
            get
            {
                return this.recordConfigField;
            }
            set
            {
                this.recordConfigField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.onvif.org/ver10/actionengine/wsdl")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.onvif.org/ver10/actionengine/wsdl", IsNullable = false)]
    public partial class SMSProviderConfiguration
    {

        private string providerURLField;

        private UserCredentials userField;

        private System.Xml.XmlElement[] anyField;

        private System.Xml.XmlAttribute[] anyAttrField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "anyURI")]
        public string ProviderURL
        {
            get
            {
                return this.providerURLField;
            }
            set
            {
                this.providerURLField = value;
            }
        }

        /// <remarks/>
        public UserCredentials User
        {
            get
            {
                return this.userField;
            }
            set
            {
                this.userField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.onvif.org/ver10/actionengine/wsdl")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.onvif.org/ver10/actionengine/wsdl", IsNullable = false)]
    public partial class SMSSenderConfiguration
    {

        private string eMailField;

        private System.Xml.XmlElement[] anyField;

        private System.Xml.XmlAttribute[] anyAttrField;

        /// <remarks/>
        public string EMail
        {
            get
            {
                return this.eMailField;
            }
            set
            {
                this.eMailField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.onvif.org/ver10/actionengine/wsdl")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.onvif.org/ver10/actionengine/wsdl", IsNullable = false)]
    public partial class SMSMessage
    {

        private string textField;

        private System.Xml.XmlElement[] anyField;

        private System.Xml.XmlAttribute[] anyAttrField;

        /// <remarks/>
        public string Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.onvif.org/ver10/actionengine/wsdl")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.onvif.org/ver10/actionengine/wsdl", IsNullable = false)]
    public partial class HttpHostConfigurations
    {

        private HttpDestinationConfiguration[] httpDestinationField;

        private HttpHostConfigurationsExtension extensionField;

        private System.Xml.XmlAttribute[] anyAttrField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("HttpDestination")]
        public HttpDestinationConfiguration[] HttpDestination
        {
            get
            {
                return this.httpDestinationField;
            }
            set
            {
                this.httpDestinationField = value;
            }
        }

        /// <remarks/>
        public HttpHostConfigurationsExtension Extension
        {
            get
            {
                return this.extensionField;
            }
            set
            {
                this.extensionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.onvif.org/ver10/actionengine/wsdl")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.onvif.org/ver10/actionengine/wsdl", IsNullable = false)]
    public partial class PostContentConfiguration
    {

        private MediaSource mediaReferenceField;

        private PostBodyConfiguration postBodyField;

        private System.Xml.XmlElement[] anyField;

        private System.Xml.XmlAttribute[] anyAttrField;

        /// <remarks/>
        public MediaSource MediaReference
        {
            get
            {
                return this.mediaReferenceField;
            }
            set
            {
                this.mediaReferenceField = value;
            }
        }

        /// <remarks/>
        public PostBodyConfiguration PostBody
        {
            get
            {
                return this.postBodyField;
            }
            set
            {
                this.postBodyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }
    }


}

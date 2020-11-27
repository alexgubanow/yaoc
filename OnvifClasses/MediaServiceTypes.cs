using System;
using System.Collections.Generic;
using System.Text;

namespace trt
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.onvif.org/ver10/media/wsdl")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.onvif.org/ver10/media/wsdl", IsNullable = false)]
    public partial class GetSnapshotUri
    {
        private string profileTokenField;
        /// <remarks/>
        public string ProfileToken { get { return this.profileTokenField; } set { this.profileTokenField = value; } }
    }


}

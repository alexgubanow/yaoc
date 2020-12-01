using System;
using System.Collections.Generic;
using System.Text;

namespace tptz
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.onvif.org/ver20/ptz/wsdl")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.onvif.org/ver20/ptz/wsdl", IsNullable = false)]
    public partial class OperatePresetTour
    {

        private string profileTokenField;

        private string presetTourTokenField;

        private string operationField;

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
        public string PresetTourToken
        {
            get
            {
                return this.presetTourTokenField;
            }
            set
            {
                this.presetTourTokenField = value;
            }
        }

        /// <remarks/>
        public string Operation
        {
            get
            {
                return this.operationField;
            }
            set
            {
                this.operationField = value;
            }
        }
    }



    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.onvif.org/ver20/ptz/wsdl")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.onvif.org/ver20/ptz/wsdl", IsNullable = false)]
    public partial class GotoPreset
    {
        private string profileTokenField;
        public string ProfileToken { get { return this.profileTokenField; } set { this.profileTokenField = value; } }
        private string presetTokenField;
        public string PresetToken { get { return this.presetTokenField; } set { this.presetTokenField = value; } }
    }


}

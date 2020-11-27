using System;
using System.Collections.Generic;
using System.Text;

namespace tptz
{
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.onvif.org/ver10/schema")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.onvif.org/ver10/schema", IsNullable = false)]
    public enum tt__PTZPresetTourOperation
    {
        tt__PTZPresetTourOperation__Start = 0,
        tt__PTZPresetTourOperation__Stop = 1,
        tt__PTZPresetTourOperation__Pause = 2,
        tt__PTZPresetTourOperation__Extended = 3
    };

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.onvif.org/ver20/ptz/wsdl")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.onvif.org/ver20/ptz/wsdl", IsNullable = false)]
    public partial class OperatePresetTour
    {
        private string profileTokenField;
        public string ProfileToken { get { return this.profileTokenField; } set { this.profileTokenField = value; } }
        private string presetTourTokenField;
        public string PresetTourToken { get { return this.presetTourTokenField; } set { this.presetTourTokenField = value; } }
        private tt__PTZPresetTourOperation operationField;
        public tt__PTZPresetTourOperation Operation { get { return this.operationField; } set { this.operationField = value; } }
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

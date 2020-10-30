using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Xml.Linq;
using System.Xml.Serialization;
using tae;

namespace ActionEngineModule.ViewModels
{
    class ActionEngineViewModel : BindableBase
    {
        private IEventAggregator _ea;
        private ActionEnginePortClient AEclient;
        ActionEngineViewModel(IEventAggregator ea)
        {
            _ea = ea;
            if (System.Windows.Application.Current.Properties["Endpoint"] == null)
            {
                return;
            }
            var messageElement = new TextMessageEncodingBindingElement
            {
                MessageVersion = MessageVersion.CreateVersion(EnvelopeVersion.Soap12, AddressingVersion.None)
            };
            var httpBinding = new HttpTransportBindingElement
            {
                AuthenticationScheme = AuthenticationSchemes.Basic
            };
            var mediaAddress = new EndpointAddress((string)System.Windows.Application.Current.Properties["Endpoint"]);
            AEclient = new ActionEnginePortClient(new CustomBinding(messageElement, httpBinding), mediaAddress);
            AEclient.ClientCredentials.UserName.UserName = "admin";
            AEclient.ClientCredentials.UserName.Password = "admin";
            System.Windows.Application.Current.Properties["AEclient"] = AEclient;
        }
    }
}

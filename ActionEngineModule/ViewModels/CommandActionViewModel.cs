using Prism.Mvvm;
using tae;
using utils;

namespace ActionEngineModule.ViewModels
{
    public class CommandActionViewModel : BindableBase
    {
        private string _XAddr = "";
        public string XAddr
        {
            get { return _XAddr; }
            set { SetProperty(ref _XAddr, value); ParametersReference = GetItemList(); }
        }
        private string _Operation = "";
        public string Operation
        {
            get { return _Operation; }
            set { SetProperty(ref _Operation, value); ParametersReference = GetItemList(); }
        }
        private string _Request = "";
        public string Request
        {
            get { return _Request; }
            set { SetProperty(ref _Request, value); ParametersReference = GetItemList(); }
        }
        private ItemList _ParametersReference;
        public ItemList ParametersReference
        {
            get { return _ParametersReference; }
            set { SetProperty(ref _ParametersReference, value); }
        }

        public CommandActionViewModel()
        {
        }
        public ItemList GetItemList()
        {
            return new ItemList
            {
                SimpleItem = new ItemListSimpleItem[2]
            {
                new ItemListSimpleItem() { Name = "XAddr", Value = XAddr },
                new ItemListSimpleItem() { Name = "Operation", Value = Operation }
            },
                ElementItem = new ItemListElementItem[1]
            {
                new ItemListElementItem() { Name = "Parameters", 
                    Any = XML.ToXmlElement(new tt.AnyHolder()
                    {
                        Any = new System.Xml.XmlElement[1] { XML.ToXmlElement(Request.Replace('\r', ' ').Replace('\n', ' ').Replace('\t', ' ')) }
                    })}
            }
            };
        }
        public void ParseItemList(ItemList paramList)
        {
            foreach (var item in paramList.SimpleItem)
            {
                if (item.Name == "XAddr")
                {
                    XAddr = item.Value;
                }
                else if (item.Name == "FtpContent")
                {
                    Operation = item.Value;
                }
            }
            foreach (var item in paramList.ElementItem)
            {
                if (item.Name == "Parameters")
                {
                    object Parameters = new tt.AnyHolder();
                    XML.XmlElementToObject(item.Any.OuterXml, ref Parameters);
                    if (Parameters != null)
                    {
                        Request = (Parameters as tt.AnyHolder).Any[0].InnerXml;
                    }
                }
            }
        }
    }
}

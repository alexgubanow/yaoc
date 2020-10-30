using Prism.Events;

namespace Events
{
    public class NewStatusEvent : PubSubEvent<string> { }
    public class OpenDialogEvent : PubSubEvent<object> { }
    public class CloseDialogEvent : PubSubEvent<object> { }
}

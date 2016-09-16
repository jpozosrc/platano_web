using System;

namespace PlatanoWeb.Model
{
public class AutomationCommand
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public string UserName { get; set; }
        public Guid DeviceId { get; set; }
        public string CommandText { get; set; }
        public string CommandArgs { get; set; }
    }
}
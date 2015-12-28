namespace DataCollector.DomainModel
{
    public class UserDevice
    {
        public int Id { get; set; }
        public string PropertyName { get; set; }
        public string PropertyValue { get; set; }

        public DCUser DCUser { get; set; }
    }
}

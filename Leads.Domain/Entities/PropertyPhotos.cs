using Leads.Domain.Entities.Base;

namespace Leads.Domain.Entities
{
    public class PropertyPhotos : BaseEntity
    {
        public string Url { get; private set; }
        public int Order { get; private set; }
        public bool IsPrimary { get; private set; }
        public int PropertyId { get; private set; }
        public Property Property { get; private set; }

        protected PropertyPhotos() { }

        public PropertyPhotos(string url, int order, bool isPrimary, int propertyId)
        {
            Url = url;
            Order = order;
            IsPrimary = isPrimary;
            PropertyId = propertyId;
        }

        public void SetAsPrimary() => IsPrimary = true;
    }
}

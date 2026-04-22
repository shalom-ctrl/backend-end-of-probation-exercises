using customer_support_api.Enums;

namespace customer_support_api.Models
{
    public class FeatureRequest : Ticket
    {
        public string FeatureDescription { get; set; }
        public string FeatureId { get; set; }
        public string FeatureName { get; set; }
        public string FeatureType { get; set; }
        public Priority Priority { get; set; }
    }
}

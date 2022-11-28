namespace LeadManagement.Application.EventSourcedNormalizers.Lead
{
    public class LeadHistoryData
    {
        public string Id { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactFullName { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string ContactEmail { get; set; }
        public string Suburb { get; set; }
        public string Category { get; set; }
        public long? JobId { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public int? Status { get; set; }
        public string Action { get; set; }
        public string Timestamp { get; set; }
        public string Who { get; set; }
    }
}
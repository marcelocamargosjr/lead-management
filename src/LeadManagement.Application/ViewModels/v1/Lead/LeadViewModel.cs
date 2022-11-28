namespace LeadManagement.Application.ViewModels.v1.Lead
{
    public class LeadViewModel
    {
        public Guid Id { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactFullName { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string ContactEmail { get; set; }
        public string Suburb { get; set; }
        public string Category { get; set; }
        public long JobId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Status { get; set; }
        public string StatusDescription { get; set; }
    }
}
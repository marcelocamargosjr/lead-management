using System.ComponentModel;

namespace LeadManagement.Domain.Enums
{
    public enum LeadStatus
    {
        [Description("Convidado")] Invited = 0,
        [Description("Aceito")] Accepted = 1,
        [Description("Declínio")] Declined = 2
    }
}
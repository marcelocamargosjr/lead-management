using System.ComponentModel.DataAnnotations;

namespace LeadManagement.Application.ViewModels.v1.Lead
{
    public class RegisterNewLeadViewModel
    {
        [Required(ErrorMessage = "O campo primeiro nome é obrigatório.")]
        [StringLength(255, ErrorMessage = "O campo primeiro nome deve ter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string ContactFirstName { get; set; }

        [Required(ErrorMessage = "O campo nome completo é obrigatório.")]
        [StringLength(255, ErrorMessage = "O campo nome completo deve ter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string ContactFullName { get; set; }

        [Required(ErrorMessage = "O campo número de telefone é obrigatório.")]
        public string ContactPhoneNumber { get; set; }

        [Required(ErrorMessage = "O campo e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O campo e-mail está inválido.")]
        public string ContactEmail { get; set; }

        [Required(ErrorMessage = "O campo subúrbio é obrigatório.")]
        [StringLength(255, ErrorMessage = "O campo subúrbio deve ter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Suburb { get; set; }

        [Required(ErrorMessage = "O campo categoria é obrigatório.")]
        [StringLength(255, ErrorMessage = "O campo categoria deve ter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Category { get; set; }

        [Required(ErrorMessage = "O campo descrição é obrigatório.")]
        [StringLength(255, ErrorMessage = "O campo descrição deve ter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}
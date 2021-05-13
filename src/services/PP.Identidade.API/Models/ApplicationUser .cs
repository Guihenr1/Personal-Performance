using Microsoft.AspNetCore.Identity;

namespace PP.Identidade.API.Models
{
    public class ApplicationUser : IdentityUser {
        public bool IsActive { get; set; }

        public void AlternarAtivo()
        {
            IsActive = !IsActive;
        }
    }
}
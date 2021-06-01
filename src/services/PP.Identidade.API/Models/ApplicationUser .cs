using Microsoft.AspNetCore.Identity;
using PP.Core.Enums;

namespace PP.Identidade.API.Models
{
    public class ApplicationUser : IdentityUser {
        public bool IsActive { get; set; }
        public TipoUsuario UserType { get; set; }

        public void AlternarAtivo()
        {
            IsActive = !IsActive;
        }
    }
}
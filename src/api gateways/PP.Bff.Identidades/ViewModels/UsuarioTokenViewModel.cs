﻿using System.Collections.Generic;

namespace PP.Bff.Identidades.Models
{
    public class UsuarioTokenViewModel {
        public string Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<UsuarioClaimViewModel> Claims { get; set; }
    }
}
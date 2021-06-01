using System.Collections.Generic;

namespace PP.Bff.Identidades.Models
{
    public class ErrorResponse
    {
        public Errors Errors { get; set; }
    }

    public class Errors
    {
        public List<string> Mensagens { get; set; }
    }
}
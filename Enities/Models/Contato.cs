using Entities.Enums;

namespace Entities.Models
{
    public class Contato : Base
    {
        public string? NumeroContato { get; set; }
        public string? Email { get; set; }
        public TipoContato TipoContato { get; set; }
        public bool HorarioComercial { get; set; }
        public bool Lembretes { get; set; }
    }
}

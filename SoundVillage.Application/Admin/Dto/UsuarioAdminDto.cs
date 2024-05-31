using SoundVillage.Domain.Admin.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundVillage.Application.Admin.Dto
{
    public class UsuarioAdminDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int Perfil { get; set; }
    }
}

using AutoMapper;
using SoundVillage.Application.Conta.Dto;
using SoundVillage.Application.Dto;
using SoundVillage.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundVillage.Application.Streaming
{
    public class PlanoService
    {
        private PlanoRepository PlanoRepository { get; set; }
        private IMapper Mapper { get; set; }

        public PlanoService(PlanoRepository planoRepository, IMapper mapper)
        {
            PlanoRepository = planoRepository;
            Mapper = mapper;
        }

        public IEnumerable<PlanoDto> GetPlanos() {
            var Planos = this.PlanoRepository.GetAll();
            return this.Mapper.Map<IEnumerable<PlanoDto>>(Planos);
        }
    }
}

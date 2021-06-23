using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskFor66bit.BLL.InputDTO;
using TestTaskFor66bit.DAL.Models;

namespace TestTaskFor66bit.BLL.ModelsDTO
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            MapPlayerModels();
            MapTeamModels();
        }
        private void MapPlayerModels()
        {
            CreateMap<PlayerDB, PlayerDTO>()
                .ForMember(x => x.TeamDTO, x => x.MapFrom(x => x.TeamDB));


            CreateMap<PlayerDTO, PlayerDB>()
                .ForMember(x => x.TeamDB, x => x.MapFrom(x => x.TeamDTO));
        }
        private void MapTeamModels()
        {
            CreateMap<TeamDB, TeamDTO>()
                .ForMember(x => x.PlayerDTO, x => x.MapFrom(x => x.PlayerDB));
            CreateMap<TeamDTO, TeamDB>()
                .ForMember(x => x.PlayerDB, x => x.MapFrom(x => x.PlayerDTO));
        }
    }
}

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberSystem.Domain.Entities;
using UberSystem.Domain.Models.UserModels;

namespace UberSystem.Domain.Mappings
{
	internal class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<User, UserCreateRequestModel>()
				.ReverseMap();
		}
	}
}

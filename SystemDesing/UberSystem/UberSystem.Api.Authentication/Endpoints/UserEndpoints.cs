using AutoMapper;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UberSystem.Domain.Entities;
using UberSystem.Domain.Interfaces.Services;
using UberSystem.Domain.Models.UserModels;

namespace UberSystem.Api.Authentication.Endpoints
{
	public class UserEndpoints : ICarterModule
	{
		public void AddRoutes(IEndpointRouteBuilder app)
		{
			var group = app.MapGroup("api/authentication");
			group.MapPost("register", Register).WithName(nameof(Register));

		}

		public static async Task<IResult> Register([FromBody] UserCreateRequestModel userCreateRequestModel, IUserService userService,
			IMapper mapper, CancellationToken cancellationToken)
		{
			var userData = mapper.Map<User>(userCreateRequestModel);
			var result =  await userService.AddUserAsync(userData, cancellationToken);
			if (result is true)
			{
				return Results.Ok("UserCreated");
			}
			return Results.BadRequest("CreateUserFail");
		}
	}
}

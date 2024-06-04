using HROnion.Application.DTOs;
using HROnion.Application.Services;

namespace API.Extensions;

public static class PositionEndpoints
{
	public static void MapPositionEndpoints(this IEndpointRouteBuilder app)
	{
		app.MapPost("/api/positions", async (CreatePositionDTO newPosition, PositionService positionService) =>
		{
			int positionId = await positionService.CreatePositionAsync(newPosition);

			return Results.Ok(positionId);
		});

		app.MapGet("/api/positions/{id}", async (int id, PositionService positionService) =>
		{
			PositionDTO position = await positionService.GetPositionByIdAsync(id);

			return Results.Ok(position);
		});

		app.MapGet("/api/positions", async (PositionService positionService) =>
		{
			IEnumerable<PositionDTO> positions = await positionService.GetAllPositions();

			return Results.Ok(positions);
		});
	}
}

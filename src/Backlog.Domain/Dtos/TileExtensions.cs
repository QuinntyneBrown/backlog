using Backlog.Domain.Models;


namespace Backlog.Domain.Dtos;

public static class TileExtensions
{        
    public static TileDto ToDto(this Tile tile)
        => new TileDto
        {
            TileId = tile.TileId,
            Name = tile.Name
        };
}

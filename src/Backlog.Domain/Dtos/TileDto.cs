using FluentValidation;
using System;


namespace Backlog.Domain.Dtos;

public class TileDtoValidator: AbstractValidator<TileDto>
{
    public TileDtoValidator()
    {
        RuleFor(x => x.TileId).NotNull();
        RuleFor(x => x.Name).NotNull();
    }
}

public class TileDto
{        
    public Guid TileId { get; set; }
    public string Name { get; set; }
}

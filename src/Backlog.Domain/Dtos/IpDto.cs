using Backlog.Domain.Models;
using FluentValidation;
using System;

namespace Backlog.Domain.Dtos
{
    public class IpDtoValidator: AbstractValidator<IpDto>
    {
        public IpDtoValidator()
        {
            RuleFor(x => x.IpId).NotNull();
        }
    }

    public class IpDto
    {        
        public Guid IpId { get; set; }
    }

    public static class IpExtensions
    {        
        public static IpDto ToDto(this Ip ip)
            => new IpDto
            {
                IpId = ip.IpId
            };
    }
}

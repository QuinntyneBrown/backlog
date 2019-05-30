using Backlog.Domain.Models;
using FluentValidation;
using System;

namespace Backlog.Domain.Dtos
{
    public class ArticleDtoValidator: AbstractValidator<ArticleDto>
    {
        public ArticleDtoValidator()
        {
            RuleFor(x => x.ArticleId).NotNull();
            RuleFor(x => x.Name).NotNull();
        }
    }

    public class ArticleDto
    {        
        public Guid ArticleId { get; set; }
        public string Name { get; set; }
    }

    public static class ArticleExtensions
    {        
        public static ArticleDto ToDto(this Article article)
            => new ArticleDto
            {
                ArticleId = article.ArticleId,
                Name = article.Name
            };
    }
}

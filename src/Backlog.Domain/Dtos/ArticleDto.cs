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
            RuleFor(x => x.Title).NotNull();
        }
    }

    public class ArticleDto
    {        
        public Guid ArticleId { get; set; }
        public string Title { get; set; }
    }

    public static class ArticleExtensions
    {        
        public static ArticleDto ToDto(this Article article)
            => new ArticleDto
            {
                ArticleId = article.ArticleId,
                Title = article.Title
            };
    }
}

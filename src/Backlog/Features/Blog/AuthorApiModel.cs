using Backlog.Model;

namespace Backlog.Features.Blog
{
    public class AuthorApiModel
    {        
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string AvatarUrl { get; set; }

        public static TModel FromAuthor<TModel>(Author author) where
            TModel : AuthorApiModel, new()
        {
            var model = new TModel();

            if (author == null) return model;

            model.Id = author.Id;
            model.Firstname = author.Firstname;
            model.Lastname = author.Lastname;
            model.AvatarUrl = author.AvatarUrl;
            return model;
        }

        public static AuthorApiModel FromAuthor(Author author)
            => FromAuthor<AuthorApiModel>(author);
    }
}
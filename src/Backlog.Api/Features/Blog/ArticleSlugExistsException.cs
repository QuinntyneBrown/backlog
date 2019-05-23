using System;

namespace Backlog.Features.Blog
{
    public class ArticleSlugExistsException: Exception
    {
        public ArticleSlugExistsException()
            :base("Article Slug Exists")
        {

        }
    }
}

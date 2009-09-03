using MadeUpStats.Domain;
using MadeUpStats.Framework;

namespace MadeUpStats.Services
{
    public class AuthorService : IAuthorService
    {
        public Author GetAuthor(string authorName)
        {
            Validate.NotNull(authorName, "authorName");
            Validate.NotEmpty(authorName, "authorName");

            return new Author(authorName);
        }
    }
}
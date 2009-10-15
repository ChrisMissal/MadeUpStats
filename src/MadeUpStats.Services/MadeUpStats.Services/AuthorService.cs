using MadeUpStats.Domain;
using MadeUpStats.Framework;

namespace MadeUpStats.Services
{
    public class AuthorService : IAuthorService
    {
        public Author GetAuthor(string authorName)
        {
            Validate.NotNull(authorName, "Author name");
            Validate.NotEmpty(authorName, "Author name");

            return new Author(authorName);
        }
    }
}
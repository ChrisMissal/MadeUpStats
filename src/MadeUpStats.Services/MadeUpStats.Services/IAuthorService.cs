using MadeUpStats.Domain;

namespace MadeUpStats.Services
{
    public interface IAuthorService
    {
        Author GetLoggedInAuthor();
    }
}
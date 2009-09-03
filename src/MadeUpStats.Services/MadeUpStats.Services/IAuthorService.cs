using System;
using MadeUpStats.Domain;

namespace MadeUpStats.Services
{
    public interface IAuthorService
    {
        Author GetAuthor(string authorName);
    }
}
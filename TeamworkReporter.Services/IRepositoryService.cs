using System.Collections.Generic;
using TeamworkReporter.Models;

namespace TeamworkReporter.Services
{
    public interface IRepositoryService<T> where T : DbEntity
    {
        IList<T> List();
        bool Remove(params T[] items);
        bool Add(params T[] items);
    }
}
using TeamworkReporter.Models;

namespace TeamworkReporter.Services.Permissions
{
    public interface IRepositoryService
    {
        /*
         * List
         * Assign
         * Remove
         * Add
         */
    }

    public interface IRepositoryService<T> : IRepositoryService where T : DbEntity
    {
        /*
         * List
         * Assign
         * Remove
         * Add
         */
    }
}
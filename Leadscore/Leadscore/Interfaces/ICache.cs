using System.Threading.Tasks;

namespace Leadscore.Interfaces
{
    public interface ICache
    {
        Task<T> GetObject<T>(string key);
        Task InsertObject<T>(string key, T value);
        Task RemoveObject(string key);
    }
}
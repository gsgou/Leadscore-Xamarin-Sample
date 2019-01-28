using System.Collections.Generic;
using System.Reactive.Linq;
using System.Threading.Tasks;

using Akavache;
using Leadscore.Interfaces;

namespace Leadscore.Services
{
    public class CacheService : ICache
    {
        public CacheService()
        {
            BlobCache.ApplicationName = "Leadscore";
        }

        public async Task RemoveObject(string key)
        {
            await BlobCache.LocalMachine.Invalidate(key);
        }

        public async Task<T> GetObject<T>(string key)
        {
            try
            {
                return await BlobCache.LocalMachine.GetObject<T>(key);
            }
            catch (KeyNotFoundException)
            {
                return default(T);
            }
        }

        public async Task InsertObject<T>(string key, T value)
        {
            await BlobCache.LocalMachine.InsertObject(key, value);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TS.EasyStockManager.Core.Repository
{
    public interface ITelegramStockRepository : IRepository<TS.EasyStockManager.Data.Entity.TelegramStock>
    {
        Task RemoveByStoreAndProductId(int productId, int storeId);
        Task<TS.EasyStockManager.Data.Entity.TelegramStock> GetByStoreAndProductId(int productId, int storeId);
    }
}

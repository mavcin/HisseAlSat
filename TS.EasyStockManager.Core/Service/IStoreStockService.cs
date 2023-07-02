using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TS.EasyStockManager.Model.Domain;
using TS.EasyStockManager.Model.Service;

namespace TS.EasyStockManager.Core.Service
{
    public interface IStoreStockService : IService<TelegramStockDTO>
    {
        Task<ServiceResult<IEnumerable<TelegramStockDTO>>> StoreStockReport(TelegramStockDTO criteria);
    }
}

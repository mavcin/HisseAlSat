using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TS.EasyStockManager.Core.Service;
using TS.EasyStockManager.Core.UnitOfWorks;
using TS.EasyStockManager.Model.Domain;
using TS.EasyStockManager.Model.Service;
using TS.EasyStockManager.Service.Base;
using Entity = TS.EasyStockManager.Data.Entity;

namespace TS.EasyStockManager.Service.StoreStock
{
    public class StoreStockService : BaseService, IStoreStockService
    {
        public StoreStockService(IUnitOfWorks unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<ServiceResult> AddAsync(TelegramStockDTO model)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                using (_unitOfWork)
                {
                    Entity.TelegramStock entity = _mapper.Map<Data.Entity.TelegramStock>(model);
                    await _unitOfWork.StoreStockRepository.AddAsync(entity);
                    await _unitOfWork.SaveAsync();
                }
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.UserMessage = ex.Message;
            }
            return result;
        }

        public async Task<ServiceResult<IEnumerable<TelegramStockDTO>>> Find(TelegramStockDTO criteria)
        {
            ServiceResult<IEnumerable<TelegramStockDTO>> result = new ServiceResult<IEnumerable<TelegramStockDTO>>();

            try
            {
                using (_unitOfWork)
                {
                    IEnumerable<Entity.TelegramStock> list = await _unitOfWork
                                                                .StoreStockRepository
                                                                .FindAsync(filter: x => (criteria.ProductId == null || x.ProductId == criteria.ProductId) &&
                                                                                        (criteria.TelegramId == null || x.TelegramId == criteria.TelegramId),
                                                                           orderByDesc: x => x.ProductId,
                                                                           skip: criteria.PageNumber,
                                                                           take: criteria.RecordCount);

                    result.TransactionResult = _mapper.Map<IEnumerable<TelegramStockDTO>>(list);
                }
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.UserMessage = ex.Message;
            }

            return result;
        }

        public async Task<ServiceResult<int>> FindCount(TelegramStockDTO criteria)
        {
            ServiceResult<int> result = new ServiceResult<int>();

            try
            {
                using (_unitOfWork)
                {
                    int count = await _unitOfWork.StoreStockRepository
                                                 .FindCountAsync(filter: x => (criteria.ProductId == null || x.ProductId == criteria.ProductId) &&
                                                                              (criteria.TelegramId == null || x.TelegramId == criteria.TelegramId));
                    result.TransactionResult = count;
                }
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.UserMessage = ex.Message;
            }

            return result;
        }

        public async Task<ServiceResult<IEnumerable<TelegramStockDTO>>> GetAll()
        {
            ServiceResult<IEnumerable<TelegramStockDTO>> result = new ServiceResult<IEnumerable<TelegramStockDTO>>();
            try
            {
                using (_unitOfWork)
                {
                    IEnumerable<Entity.TelegramStock> list = await _unitOfWork.StoreStockRepository.GetAllAsync();
                    result.TransactionResult = _mapper.Map<IEnumerable<TelegramStockDTO>>(list);
                }
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.UserMessage = ex.Message;
            }

            return result;
        }

        public async Task<ServiceResult<TelegramStockDTO>> GetById(int id)
        {
            ServiceResult<TelegramStockDTO> result = new ServiceResult<TelegramStockDTO>();
            try
            {
                using (_unitOfWork)
                {
                    Entity.TelegramStock entity = await _unitOfWork.StoreStockRepository.GetByIdAsync(id);
                    result.TransactionResult = _mapper.Map<TelegramStockDTO>(entity);
                }
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.UserMessage = ex.Message;
            }
            return result;
        }

        public async Task<ServiceResult> RemoveById(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                using (_unitOfWork)
                {
                    await _unitOfWork.StoreStockRepository.RemoveById(id);
                    await _unitOfWork.SaveAsync();
                }
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.UserMessage = ex.Message;
            }
            return result;
        }

        public async Task<ServiceResult> Update(TelegramStockDTO model)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                using (_unitOfWork)
                {
                    Entity.TelegramStock entity = await _unitOfWork.StoreStockRepository.GetByStoreAndProductId(model.ProductId.Value, model.TelegramId.Value);
                    if (entity != null)
                    {
                        _mapper.Map(model, entity);
                        _unitOfWork.StoreStockRepository.Update(entity);
                        await _unitOfWork.SaveAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.UserMessage = ex.Message;
            }
            return result;
        }

        public async Task<ServiceResult<IEnumerable<TelegramStockDTO>>> StoreStockReport(TelegramStockDTO criteria)
        {
            ServiceResult<IEnumerable<TelegramStockDTO>> result = new ServiceResult<IEnumerable<TelegramStockDTO>>();

            try
            {
                using (_unitOfWork)
                {
                    IEnumerable<Entity.TelegramStock> list = await _unitOfWork
                                                                .StoreStockRepository
                                                                .FindAsync(filter: x => (criteria.ProductId == null || x.ProductId == criteria.ProductId) &&
                                                                                        (criteria.TelegramId == null || x.TelegramId == criteria.TelegramId),
                                                                           includes: new List<string>() { "Product", "Store", "Product.UnitOfMeasure" },
                                                                           orderByDesc: x => x.Stock,
                                                                           skip: criteria.PageNumber,
                                                                           take: criteria.RecordCount);

                    result.TransactionResult = _mapper.Map<IEnumerable<TelegramStockDTO>>(list);
                }
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.UserMessage = ex.Message;
            }

            return result;
        }
    }
}

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TS.EasyStockManager.Common.Message;
using TS.EasyStockManager.Core.Service;
using TS.EasyStockManager.Core.UnitOfWorks;
using TS.EasyStockManager.Model.Domain;
using TS.EasyStockManager.Model.Service;
using TS.EasyStockManager.Service.Base;
using Entity = TS.EasyStockManager.Data.Entity;

namespace TS.EasyStockManager.Service.Store
{
    public class StoreService : BaseService, IStoreService
    {
        public StoreService(IUnitOfWorks unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }


        public async Task<ServiceResult> AddAsync(TelegramDTO model)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                using (_unitOfWork)
                {
                    Entity.Telegram entity = _mapper.Map<Data.Entity.Telegram>(model);
                    entity.CreateDate = DateTime.Now;
                    await _unitOfWork.StoreRepository.AddAsync(entity);
                    await _unitOfWork.SaveAsync();
                    result.Id = entity.Id;
                    result.UserMessage = CommonMessages.MSG0001;
                }
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.UserMessage = string.Format(CommonMessages.MSG0002, ex.Message);
            }
            return result;
        }

        public async Task<ServiceResult<IEnumerable<TelegramDTO>>> Find(TelegramDTO criteria)
        {
            ServiceResult<IEnumerable<TelegramDTO>> result = new ServiceResult<IEnumerable<TelegramDTO>>();

            try
            {
                using (_unitOfWork)
                {
                    IEnumerable<Entity.Telegram> list = await _unitOfWork
                                                                .StoreRepository
                                                                .FindAsync(filter: x => (string.IsNullOrEmpty(criteria.TelegramName) || x.TelegramName.Contains(criteria.TelegramName)) &&
                                                                                        (string.IsNullOrEmpty(criteria.TelegramComment) || x.TelegramComment.Contains(criteria.TelegramComment)),
                                                                           orderByDesc: x => x.Id,
                                                                           skip: criteria.PageNumber,
                                                                           take: criteria.RecordCount);

                    result.TransactionResult = _mapper.Map<IEnumerable<TelegramDTO>>(list);
                }
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.UserMessage = string.Format(CommonMessages.MSG0002, ex.Message);
            }

            return result;
        }

        public async Task<ServiceResult<int>> FindCount(TelegramDTO criteria)
        {
            ServiceResult<int> result = new ServiceResult<int>();

            try
            {
                using (_unitOfWork)
                {
                    int count = await _unitOfWork.StoreRepository
                                                 .FindCountAsync(filter: x => (string.IsNullOrEmpty(criteria.TelegramName) || x.TelegramName.Contains(criteria.TelegramName)) &&
                                                                              (string.IsNullOrEmpty(criteria.TelegramComment) || x.TelegramComment.Contains(criteria.TelegramComment)));

                    result.TransactionResult = count;
                }
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.UserMessage = string.Format(CommonMessages.MSG0002, ex.Message);
            }

            return result;
        }

        public async Task<ServiceResult<IEnumerable<TelegramDTO>>> GetAll()
        {
            ServiceResult<IEnumerable<TelegramDTO>> result = new ServiceResult<IEnumerable<TelegramDTO>>();
            try
            {
                using (_unitOfWork)
                {
                    IEnumerable<Entity.Telegram> list = await _unitOfWork.StoreRepository.GetAllAsync();
                    result.TransactionResult = _mapper.Map<IEnumerable<TelegramDTO>>(list);
                }
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.UserMessage = string.Format(CommonMessages.MSG0002, ex.Message);
            }

            return result;
        }

        public async Task<ServiceResult<TelegramDTO>> GetById(int id)
        {
            ServiceResult<TelegramDTO> result = new ServiceResult<TelegramDTO>();
            try
            {
                using (_unitOfWork)
                {
                    Entity.Telegram entity = await _unitOfWork.StoreRepository.GetByIdAsync(id);
                    result.TransactionResult = _mapper.Map<TelegramDTO>(entity);
                }
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.UserMessage = string.Format(CommonMessages.MSG0002, ex.Message);
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
                    await _unitOfWork.StoreRepository.RemoveById(id);
                    await _unitOfWork.SaveAsync();
                    result.UserMessage = CommonMessages.MSG0001;
                }
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.UserMessage = string.Format(CommonMessages.MSG0002, ex.Message);
            }
            return result;
        }

        public async Task<ServiceResult> Update(TelegramDTO model)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                using (_unitOfWork)
                {
                    Entity.Telegram entity = await _unitOfWork.StoreRepository.GetByIdAsync(model.Id.Value);
                    if (entity != null)
                    {
                        _mapper.Map(model, entity);
                        _unitOfWork.StoreRepository.Update(entity);
                        await _unitOfWork.SaveAsync();
                        result.UserMessage = CommonMessages.MSG0001;
                    }
                }
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.UserMessage = string.Format(CommonMessages.MSG0002, ex.Message);
            }
            return result;
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using TS.EasyStockManager.Data.Entity;
using TS.EasyStockManager.Model.Domain;
using TS.EasyStockManager.Model.Service;
using TS.EasyStockManager.Model.ViewModel.Category;
using TS.EasyStockManager.Model.ViewModel.JsonResult;
using TS.EasyStockManager.Model.ViewModel.Product;
using TS.EasyStockManager.Model.ViewModel.Report.StoreStock;
using TS.EasyStockManager.Model.ViewModel.Report.TransactionDetail;
using TS.EasyStockManager.Model.ViewModel.Store;
using TS.EasyStockManager.Model.ViewModel.Transaction;
using TS.EasyStockManager.Model.ViewModel.UnitOfMeasure;
using TS.EasyStockManager.Model.ViewModel.User;

namespace TS.EasyStockManager.Mapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            #region DTO & ViewModel
            CreateMap<ServiceResult, JsonResultModel>();


            CreateMap<CreateCategoryViewModel, CategoryDTO>();
            CreateMap<SearchCategoryViewModel, CategoryDTO>()
                    .ForMember(dm => dm.PageNumber, vm => vm.MapFrom(vmf => vmf.iDisplayStart))
                    .ForMember(dm => dm.RecordCount, vm => vm.MapFrom(vmf => vmf.iDisplayLength));
            CreateMap<CategoryDTO, ListCategoryViewModel>();
            CreateMap<CategoryDTO, EditCategoryViewModel>();
            CreateMap<EditCategoryViewModel, CategoryDTO>();
            CreateMap<CategoryDTO, SelectListItem>()
                   .ForMember(dm => dm.Value, vm => vm.MapFrom(vmf => vmf.Id.ToString()))
                   .ForMember(dm => dm.Text, vm => vm.MapFrom(vmf => vmf.CategoryName));


            CreateMap<CreateUnitOfMeasureViewModel, UnitOfMeasureDTO>();
            CreateMap<SearchUnitOfMeasureViewModel, UnitOfMeasureDTO>()
                    .ForMember(dm => dm.PageNumber, vm => vm.MapFrom(vmf => vmf.iDisplayStart))
                    .ForMember(dm => dm.RecordCount, vm => vm.MapFrom(vmf => vmf.iDisplayLength));
            CreateMap<UnitOfMeasureDTO, ListUnitOfMeasureViewModel>();
            CreateMap<UnitOfMeasureDTO, EditUnitOfMeasureViewModel>();
            CreateMap<EditUnitOfMeasureViewModel, UnitOfMeasureDTO>();
            CreateMap<UnitOfMeasureDTO, SelectListItem>()
                   .ForMember(dm => dm.Value, vm => vm.MapFrom(vmf => vmf.Id.ToString()))
                   .ForMember(dm => dm.Text, vm => vm.MapFrom(vmf => vmf.UnitOfMeasureName + "-" + vmf.Isocode));


            CreateMap<CreateUserViewModel, UserDTO>();
            CreateMap<SearchUserViewModel, UserDTO>()
                    .ForMember(dm => dm.PageNumber, vm => vm.MapFrom(vmf => vmf.iDisplayStart))
                    .ForMember(dm => dm.RecordCount, vm => vm.MapFrom(vmf => vmf.iDisplayLength));
            CreateMap<UserDTO, ListUserViewModel>();
            CreateMap<UserDTO, EditUserViewModel>();
            CreateMap<EditUserViewModel, UserDTO>();

            CreateMap<CreateStoreViewModel, TelegramDTO>();
            CreateMap<SearchStoreViewModel, TelegramDTO>()
                    .ForMember(dm => dm.PageNumber, vm => vm.MapFrom(vmf => vmf.iDisplayStart))
                    .ForMember(dm => dm.RecordCount, vm => vm.MapFrom(vmf => vmf.iDisplayLength));
            CreateMap<TelegramDTO, ListStoreViewModel>();
            CreateMap<TelegramDTO, EditStoreViewModel>();
            CreateMap<EditStoreViewModel, TelegramDTO>();
            CreateMap<TelegramDTO, SelectListItem>()
                    .ForMember(dm => dm.Value, vm => vm.MapFrom(vmf => vmf.Id.ToString()))
                    .ForMember(dm => dm.Text, vm => vm.MapFrom(vmf => vmf.TelegramComment + "-" + vmf.TelegramName));

            CreateMap<CreateProductViewModel, ProductDTO>();
            CreateMap<SearchProductViewModel, ProductDTO>()
                    .ForMember(dm => dm.PageNumber, vm => vm.MapFrom(vmf => vmf.iDisplayStart))
                    .ForMember(dm => dm.RecordCount, vm => vm.MapFrom(vmf => vmf.iDisplayLength));
            CreateMap<ProductDTO, ListProductViewModel>()
                 .ForMember(dm => dm.ImageDisplay, vm => vm.MapFrom(vmf => !string.IsNullOrEmpty(vmf.Image) ? "/upload/" + vmf.Image : "/dist/img/no-image.png"))
                 .ForMember(dm => dm.Price, vm => vm.MapFrom(vmf => vmf.Price.HasValue ? string.Format("{0:c}", vmf.Price.Value) : "-"));
            CreateMap<ProductDTO, EditProductViewModel>();
            CreateMap<EditProductViewModel, ProductDTO>();
            CreateMap<ProductDTO, SelectListItem>()
                    .ForMember(dm => dm.Value, vm => vm.MapFrom(vmf => vmf.Id.ToString()))
                    .ForMember(dm => dm.Text, vm => vm.MapFrom(vmf => !string.IsNullOrEmpty(vmf.Barcode) ? vmf.Barcode + "-" + vmf.ProductName : vmf.ProductName));


            CreateMap<CreateTransactionViewModel, TransactionDTO>();
            CreateMap<TransactionDetailViewModel, TransactionDetailDTO>();
            CreateMap<TransactionDetailDTO, TransactionDetailViewModel>();
            CreateMap<SearchTransactionViewModel, TransactionDTO>()
                    .ForMember(dm => dm.PageNumber, vm => vm.MapFrom(vmf => vmf.iDisplayStart))
                    .ForMember(dm => dm.RecordCount, vm => vm.MapFrom(vmf => vmf.iDisplayLength));
            CreateMap<TransactionDTO, ListTransactionViewModel>()
                 .ForMember(dm => dm.TransactionDate, vm => vm.MapFrom(vmf => string.Format("{0:D}", vmf.TransactionDate)));
            CreateMap<TransactionDTO, EditTransactionViewModel>();
            CreateMap<EditTransactionViewModel, TransactionDTO>();


            CreateMap<SearchStoreStockReportViewModel, TelegramStockDTO>()
                    .ForMember(dm => dm.PageNumber, vm => vm.MapFrom(vmf => vmf.iDisplayStart))
                    .ForMember(dm => dm.RecordCount, vm => vm.MapFrom(vmf => vmf.iDisplayLength));

            CreateMap<TelegramStockDTO, ListStoreStockReportViewModel>()
                 .ForMember(dm => dm.ProductFullName, vm => vm.MapFrom(vmf => string.Format("{1} ({0})", vmf.Barcode, vmf.ProductName)))
                 .ForMember(dm => dm.StoreFullName, vm => vm.MapFrom(vmf => string.Format("{1} ({0})", vmf.TelegramComment, vmf.TelegramName)))
                 .ForMember(dm => dm.QTY, vm => vm.MapFrom(vmf => string.Format("{0} ({1})", vmf.Stock.ToString(), vmf.Isocode)));


            CreateMap<SearchTransactionDetailReportViewModel, TransactionDetailReportDTO>()
                    .ForMember(dm => dm.PageNumber, vm => vm.MapFrom(vmf => vmf.iDisplayStart))
                    .ForMember(dm => dm.RecordCount, vm => vm.MapFrom(vmf => vmf.iDisplayLength));

            CreateMap<TransactionDetailReportDTO, ListTransactionDetailReportViewModel>()
                 .ForMember(dm => dm.ProductFullName, vm => vm.MapFrom(vmf => string.Format("{1} ({0})", vmf.Barcode, vmf.ProductName)))
                 .ForMember(dm => dm.StoreFullName, vm => vm.MapFrom(vmf => string.Format("{1} ({0})", vmf.TelegramComment, vmf.TelegramName)))
                 .ForMember(dm => dm.ToStoreFullName, vm => vm.MapFrom(vmf => !string.IsNullOrEmpty(vmf.ToStoreName) ? string.Format("{1} ({0})", vmf.ToStoreCode, vmf.ToStoreName) : ""))
                 .ForMember(dm => dm.Amount, vm => vm.MapFrom(vmf => string.Format("{0} ({1})", vmf.Amount.ToString(), vmf.UnitOfMeasureShortName)))
                 .ForMember(dm => dm.TransactionDate, vm => vm.MapFrom(vmf => string.Format("{0:D}", vmf.TransactionDate))); ;

            #endregion

            #region Entity & DTO
            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();

            CreateMap<UnitOfMeasure, UnitOfMeasureDTO>();
            CreateMap<UnitOfMeasureDTO, UnitOfMeasure>();

            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();


            CreateMap<Telegram, TelegramDTO>();
            CreateMap<TelegramDTO, Telegram>();

            CreateMap<Product, ProductDTO>()
                 .ForMember(dm => dm.CategoryName, vm => vm.MapFrom(vmf => vmf.Category != null ? vmf.Category.CategoryName : "-"))
                 .ForMember(dm => dm.UnitOfMeasureName, vm => vm.MapFrom(vmf => vmf.UnitOfMeasure != null ? vmf.UnitOfMeasure.Isocode : "-"));
            CreateMap<ProductDTO, Product>();

            CreateMap<Transaction, TransactionDTO>()
                .ForMember(dm => dm.TelegramName, vm => vm.MapFrom(vmf => vmf.Store != null ? vmf.Store.TelegramName + "-" + vmf.Store.TelegramComment : "-"))
                .ForMember(dm => dm.ToStoreName, vm => vm.MapFrom(vmf => vmf.ToStore != null ? vmf.ToStore.TelegramName + "-" + vmf.ToStore.TelegramComment : "-"))
                .ForMember(dm => dm.TransactionTypeName, vm => vm.MapFrom(vmf => vmf.TransactionType != null ? vmf.TransactionType.TransactionTypeName : "-"));
            CreateMap<TransactionDTO, Transaction>();

            CreateMap<TransactionDetail, TransactionDetailDTO>()
                .ForMember(dm => dm.ProductName, vm => vm.MapFrom(vmf => vmf.Product != null ? vmf.Product.ProductName : ""))
                .ForMember(dm => dm.Barcode, vm => vm.MapFrom(vmf => vmf.Product != null ? vmf.Product.Barcode : ""))
                .ForMember(dm => dm.UnitOfMeasureName, vm => vm.MapFrom(vmf => vmf.Product != null ? vmf.Product.UnitOfMeasure.UnitOfMeasureName : ""))
                .ForMember(dm => dm.UnitOfMeasureShortName, vm => vm.MapFrom(vmf => vmf.Product != null ? vmf.Product.UnitOfMeasure.Isocode : ""));
            CreateMap<TransactionDetailDTO, TransactionDetail>();

            CreateMap<TelegramStock, TelegramStockDTO>()
                 .ForMember(dm => dm.TelegramName, vm => vm.MapFrom(vmf => vmf.Telegram!= null ? vmf.Telegram.TelegramName : "-"))
                 .ForMember(dm => dm.TelegramComment, vm => vm.MapFrom(vmf => vmf.Telegram != null ? vmf.Telegram.TelegramComment : "-"))
                 .ForMember(dm => dm.ProductName, vm => vm.MapFrom(vmf => vmf.Product != null ? vmf.Product.ProductName : "-"))
                 .ForMember(dm => dm.Barcode, vm => vm.MapFrom(vmf => vmf.Product != null ? vmf.Product.Barcode : "-"))
                 .ForMember(dm => dm.UnitOfMeasureName, vm => vm.MapFrom(vmf => vmf.Product != null ? vmf.Product.UnitOfMeasure.UnitOfMeasureName : "-"))
                 .ForMember(dm => dm.Isocode, vm => vm.MapFrom(vmf => vmf.Product != null ? vmf.Product.UnitOfMeasure.Isocode : "-"));

            CreateMap<TransactionDetail, TransactionDetailReportDTO>()
                 .ForMember(dm => dm.TelegramName, vm => vm.MapFrom(vmf => vmf.Transaction.Store.TelegramName))
                 .ForMember(dm => dm.TelegramComment, vm => vm.MapFrom(vmf => vmf.Transaction.Store.TelegramComment))
                 .ForMember(dm => dm.ToStoreCode, vm => vm.MapFrom(vmf => vmf.Transaction.ToStore != null ? vmf.Transaction.ToStore.TelegramComment : ""))
                 .ForMember(dm => dm.ToStoreName, vm => vm.MapFrom(vmf => vmf.Transaction.ToStore != null ? vmf.Transaction.ToStore.TelegramName : ""))
                 .ForMember(dm => dm.ProductName, vm => vm.MapFrom(vmf => vmf.Product.ProductName))
                 .ForMember(dm => dm.Barcode, vm => vm.MapFrom(vmf => vmf.Product.Barcode))
                 .ForMember(dm => dm.UnitOfMeasureName, vm => vm.MapFrom(vmf => vmf.Product.UnitOfMeasure.UnitOfMeasureName))
                 .ForMember(dm => dm.UnitOfMeasureShortName, vm => vm.MapFrom(vmf => vmf.Product.UnitOfMeasure.Isocode))
                 .ForMember(dm => dm.TransactionTypeName, vm => vm.MapFrom(vmf => vmf.Transaction.TransactionType.TransactionTypeName))
                 .ForMember(dm => dm.TransactionDate, vm => vm.MapFrom(vmf => vmf.Transaction.TransactionDate))
                 .ForMember(dm => dm.TransactionCode, vm => vm.MapFrom(vmf => vmf.Transaction.TransactionCode));
            #endregion
        }
    }
}

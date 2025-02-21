using Azure.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Warehousing.ApplicationService.Features.Invoices.Queries;
using Warehousing.ApplicationService.Services.Contracts;
using Warehousing.ApplicationService.ViewModels;
using Warehousing.Common.DTOs;
using Warehousing.Common.Enums;
using Warehousing.DataAccess.EF.Repository;
using Warehousing.Domain.Dtos;
using Warehousing.Domain.Entities;
using Warehousing.Domain.Repository;

namespace Warehousing.ApplicationService.Services.Implementations
{
    public class CalculationService : ICalculationService
    {
        #region Constructor
        private readonly IProductPriceRepository _productPriceRepository;
        private readonly IProductRepository _productRepository;
        public CalculationService(IProductPriceRepository productPriceRepository,
                                  IProductRepository productRepository)
        {
            _productPriceRepository = productPriceRepository;
            _productRepository = productRepository;
        }
        #endregion Constructor
        public int GetSalesPrice(int productId)
        {
            return _productPriceRepository.GetSalesPrice(productId);

        }
        public int GetCoverPrice(int productId)
        {
            return _productPriceRepository.GetCoverPrice(productId);

        }
        public int GetPurchasePrice(int productId)
        {
            return _productPriceRepository.GetPurchasePrice(productId);

        }
        public int CalculateInvoicePrice(List<InvoiceProductDto> InvoiceProducts)
        {
            int totalPrice = 0;
            InvoiceProducts.ForEach(x => totalPrice += GetSalesPrice(x.ProductId) * x.ProductCount);
            return totalPrice;
        }
     
        
    }
}

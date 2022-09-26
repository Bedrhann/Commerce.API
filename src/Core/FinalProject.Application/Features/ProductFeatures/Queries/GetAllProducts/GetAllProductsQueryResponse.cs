using FinalProject.Application.DTOs.Product;
using FinalProject.Application.Models.Paging;
using FinalProject.Application.Wrappers.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Features.ProductFeatures.Queries.GetAllProducts
{
    public class GetAllProductsQueryResponse
    {
        public BaseResponse<List<ProductDto>> BaseResponse { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}

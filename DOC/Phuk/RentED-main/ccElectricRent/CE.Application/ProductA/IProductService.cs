using CE.ViewModel.Common;
using CE.ViewModel.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CE.Application.ProductA
{
    public interface IProductService
    {
       public Task<ApiResult<bool>> Create(ProductCreateRequest request);
       public Task<ApiResult<bool>> Update(int ProductID, ProductUpdateRequest request);
       public Task<int> Delete(int productId);
       public Task<ApiResult<int>> ChangeStatus(int productId);
       public Task<ApiResult<ProductViewModels>> GetByID(int productId);
       public Task<ApiResult<PagedResult<ProductViewModels>>> GetAllPaging(GetManageProductPagingRequest request);
       public Task<ApiResult<List<ProductViewModels>>> GetProductByCategoryId(int categoryId);
       public Task<ApiResult<bool>> CreateCate(CategoriesCreateRequest request);
       public Task<ApiResult<PagedResult<CategoryViewModels>>> GetAllCatePaging(GetManageCatePagingRequest1 request);

    }
}

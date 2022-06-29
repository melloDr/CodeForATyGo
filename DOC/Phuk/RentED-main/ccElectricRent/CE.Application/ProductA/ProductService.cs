using CE.Application.Ultilities;
using CE.Data.EF;
using CE.Data.Entity;
using CE.Data.Enum;
using CE.ViewModel.Common;
using CE.ViewModel.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE.Application.ProductA
{
    public class ProductService : IProductService
    {

        private readonly CeDbContext _context;

        public ProductService(CeDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<int>> ChangeStatus(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) return new ApiErrorResult<int>("Product does not exist");
            product.Status = ProductStatus.Stock;
            _context.Products.Update(product);
           
            var result = await _context.SaveChangesAsync();
            if (result == 0)
            {
                return new ApiErrorResult<int>("Update product failed");
            }
            return new ApiSuccessResult<int>((int)product.Status);
        }

        public async Task<ApiResult<bool>> Create(ProductCreateRequest request)
        {
            Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();
            var checkName = await _context.Products.Where(x => x.ProductName.Equals(request.ProductName))
                .Select(x => new Product()).FirstOrDefaultAsync();
            if (checkName != null)
            {
                UltilitiesService.AddOrUpdateError(errors, "ProductName", "This name already exists");
            }
            var category = await _context.Categories.FindAsync(request.CatagoryId);
            if (category == null) UltilitiesService.AddOrUpdateError(errors, "CategoryId", "Category not found");
            if (errors.Count() > 0)
            {
                return new ApiErrorResult<bool>(errors);
            }
            var product = new Product()
            {
                ProductName = request.ProductName,
                Description = request.Description,
                CategoryId = request.CatagoryId,
                Quantity = request.Quantity,
                ThumbNail =request.ThumbNail,
                Price = request.Price
            };
            _context.Products.Add(product);

            var result = await _context.SaveChangesAsync();
            if (result == 0)
            {
                return new ApiErrorResult<bool>("Create Product failed");
            }
            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> CreateCate(CategoriesCreateRequest request)
        {
            Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();
            var checkName = await _context.Categories.Where(x => x.CategoryName.Equals(request.CategoryName))
                .Select(x => new Category()).FirstOrDefaultAsync();
            if (checkName != null)
            {
                UltilitiesService.AddOrUpdateError(errors, "Name", "This name already exists");
            }
            if (errors.Count() > 0)
            {
                return new ApiErrorResult<bool>(errors);
            }
            var cate = new Category()
            {
                CategoryName = request.CategoryName,
                Thumbnail = request.Thumbnail
            };
            _context.Categories.Add(cate);

            var result = await _context.SaveChangesAsync();
            if (result == 0)
            {
                return new ApiErrorResult<bool>("Create Categories failed");
            }
            return new ApiSuccessResult<bool>();
        }

        public async Task<int> Delete(int productId)
        {
            var voucher = await _context.Vouchers.FindAsync(productId);
            if (voucher == null)
                throw new Exception($"Cannot find an product with id {productId}");
            _context.Vouchers.Remove(voucher);
            return await _context.SaveChangesAsync(); throw new NotImplementedException();
        }

        public async Task<ApiResult<PagedResult<CategoryViewModels>>> GetAllCatePaging(GetManageCatePagingRequest1 request)
        {
            var query = from c in _context.Categories
                        select new {  c };
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.c.CategoryName.Contains(request.Keyword));
            }
            int totalRow = await query.CountAsync();
            var data = await query.OrderBy(x => x.c.CategoryId).Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize).Select(x => new CategoryViewModels()
                {
                   
                    CategoryId = x.c.CategoryId,
                    CategoryName = x.c.CategoryName,
                    Thumbnail = x.c.Thumbnail,
                }).ToListAsync();
            var pagedResult = new PagedResult<CategoryViewModels>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };

            return new ApiSuccessResult<PagedResult<CategoryViewModels>>(pagedResult);
        }

        public async Task<ApiResult<PagedResult<ProductViewModels>>> GetAllPaging(GetManageProductPagingRequest request)
        {
            var query = from p in _context.Products
                        join c in _context.Categories on p.CategoryId equals c.CategoryId
                        select new { p, c};
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.p.ProductName.Contains(request.Keyword));
            }
            int totalRow = await query.CountAsync();
            var data = await query.OrderBy(x => x.p.ProductId).Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize).Select(x => new ProductViewModels()
                {
                    ProductId = x.p.ProductId,
                    ProductName = x.p.ProductName,
                    CategoryId = x.p.CategoryId,
                    CategoryName= x.c.CategoryName,
                    Description = x.p.Description,
                    Quantity = x.p.Quantity,
                    Price = x.p.Price,
                    Thumbnail = x.p.ThumbNail,
                    Status = x.p.Status
                }).ToListAsync();
            var pagedResult = new PagedResult<ProductViewModels>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };

            return new ApiSuccessResult<PagedResult<ProductViewModels>>(pagedResult);
        }

        public async Task<ApiResult<ProductViewModels>> GetByID(int productId)
        {
            var query = from p in _context.Products
                        join c in _context.Categories on p.CategoryId equals c.CategoryId
                        select new { c, p };
            var pVm = await query.Where(x => x.p.ProductId.Equals(productId)).Select(x => new ProductViewModels()
            {
                ProductId = x.p.ProductId,
                ProductName = x.p.ProductName,
                CategoryId = x.p.CategoryId,
                CategoryName = x.c.CategoryName,
                Description = x.p.Description,
                Quantity = x.p.Quantity,
                Price = x.p.Price,
                Thumbnail = x.p.ThumbNail,
                Status = x.p.Status
            }).FirstOrDefaultAsync();
            if (pVm == null) return new ApiErrorResult<ProductViewModels>("Product does not exist");
            return new ApiSuccessResult<ProductViewModels>(pVm);
        }

        public async Task<ApiResult<List<ProductViewModels>>> GetProductByCategoryId(int categoryId)
        {
            var query = from p in _context.Products
                        join c in _context.Categories on p.CategoryId equals c.CategoryId
                        select new { c, p };
            var data = await query.Where(x => x.p.CategoryId.Equals(categoryId))
               .Select(x => new ProductViewModels()
                {
                    ProductId = x.p.ProductId,
                    ProductName = x.p.ProductName,
                    Quantity= x.p.Quantity,
                    CategoryId= x.p.CategoryId,
                    CategoryName= x.c.CategoryName,
                    Description= x.p.Description,
                    Thumbnail =x.p.ThumbNail,
                    Price = x.p.Price,
                    Status = x.p.Status
                }).ToListAsync();

            return new ApiSuccessResult<List<ProductViewModels>>(data);
        }

        public async Task<ApiResult<bool>> Update(int productId ,ProductUpdateRequest request)
        {
            Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();
            var p = await _context.Products.FindAsync(productId);
            if (p == null) return new ApiErrorResult<bool>("Product does not exist");
            if (!p.ProductName.Equals(request.ProductName))
            {
                var checkName = await _context.Products.Where(x => x.ProductName.Equals(request.ProductName))
                    .Select(x => new Product()).FirstOrDefaultAsync();
                if (checkName != null)
                {
                    UltilitiesService.AddOrUpdateError(errors, "ProductName", "This name already exists");
                }
            }
            var c = await _context.Categories.FindAsync(request.CatagoryId);
            if (c == null) UltilitiesService.AddOrUpdateError(errors, "categoryID", "category not found");

            if (errors.Count() > 0)
            {
                return new ApiErrorResult<bool>(errors);
            }
            p.ProductName = request.ProductName;
            p.Description = request.Description;
            p.CategoryId = request.CatagoryId;
            p.Quantity = request.Quantity;
            p.Price = request.Price;
            p.Status = request.Status;
            p.ThumbNail = request.Thumbnail;
            _context.Products.Update(p);
            var result = await _context.SaveChangesAsync();
            if (result == 0)
            {
                return new ApiErrorResult<bool>("Update product failed");
            }
            return new ApiSuccessResult<bool>();
        }
    }
}

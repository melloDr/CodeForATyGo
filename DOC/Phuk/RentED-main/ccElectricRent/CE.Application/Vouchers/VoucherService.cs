using CE.Data.EF;
using CE.ViewModel.Common;
using CE.ViewModel.Voucher;
using CE.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE.Application.Vouchers
{
    public class VoucherService : IVoucherService
    {
        private readonly CeDbContext _context;

        public VoucherService(CeDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<bool>> Create(VoucherCreateRequest request)
        {
            var checkName = _context.Vouchers.Where(x => x.VoucherName.Equals(request.VoucherName))
              .Select(x => new Voucher()).FirstOrDefault();
            if (checkName != null)
            {
                return new ApiErrorResult<bool>("This Voucher name already exist");
            }
            var voucher = new Voucher
            {
                VoucherName = request.VoucherName,
               
            };
            _context.Vouchers.Add(voucher);
            var result = await _context.SaveChangesAsync();
            if (result == 0)
            {
                return new ApiErrorResult<bool>("Create Voucher failed");
            }
            return new ApiSuccessResult<bool>();
        }

    
        public async Task<ApiResult<VoucherViewModels>> GetByID(int voucherId)
        {
            var voucher = await _context.Vouchers.FindAsync(voucherId);
            if (voucher == null) return new ApiErrorResult<VoucherViewModels>("Voucher does not exist");

            var voucherViewModel = new VoucherViewModels()
            {
                VoucherId = voucherId,
                VoucherName = voucher.VoucherName,
                SaleOff = voucher.SaleOff,
                StartDate = voucher.StartDate,
                FinishDate= voucher.FinishDate
            };

            return new ApiSuccessResult<VoucherViewModels>(voucherViewModel);
        }

        public async Task<ApiResult<PagedResult<VoucherViewModels>>> GetVoucherPaging(GetVoucherPagingRequest request)
        {
            var query = from v in _context.Vouchers
                        select new { v };
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.v.VoucherName.Contains(request.Keyword));
            }
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new VoucherViewModels()
                {
                   VoucherId = x.v.VoucherId,
                   VoucherName = x.v.VoucherName,
                   SaleOff = x.v.SaleOff,
                   StartDate= x.v.StartDate,
                   FinishDate = x.v.FinishDate
                }).ToListAsync();

            var pagedResult = new PagedResult<VoucherViewModels>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };

            return new ApiSuccessResult<PagedResult<VoucherViewModels>>(pagedResult);
        }


        public async Task<ApiResult<bool>> Update(int voucherId, VoucherUpdateRequest request)
        {
                    
            var voucher = await _context.Vouchers.FindAsync(voucherId);
            if (voucher == null) new ApiErrorResult<bool>("Voucher does not exist");
            if (!voucher.VoucherName.Equals(request.VoucherName))
            {
                var checkName = _context.Vouchers.Where(x => x.VoucherName.Equals(request.VoucherName))
                 .Select(x => new Voucher()).FirstOrDefault();
                if (checkName != null)
                {
                    return new ApiErrorResult<bool>("This Voucher name already exist");
                }
                else
                {
                    voucher.VoucherName = request.VoucherName;
                }
            }
            voucher.SaleOff = request.SaleOff;
            voucher.StartDate = request.StartDate;
            voucher.FinishDate = request.FinishDate;
            _context.Vouchers.Update(voucher);
            var result = await _context.SaveChangesAsync();
            if (result == 0)
            {
                return new ApiErrorResult<bool>("Update voucher failed");
            }
            return new ApiSuccessResult<bool>();
        }

        public async Task<int> Delete(int voucherId)
        {
            var voucher = await _context.Vouchers.FindAsync(voucherId);
            if (voucher == null)
                throw new Exception($"Cannot find an voucher with id {voucherId}");
            _context.Vouchers.Remove(voucher);
            return await _context.SaveChangesAsync();
        }
    }
}
using FoodApplication.Areas.Identity.Data;
using FoodApplication.Data;
using FoodApplication.Interface;
using FoodApplication.Models;
using FoodApplication.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodApplication.Services
{
    public class ReportService : Controller, IReportService
    {
        private readonly AuthContext _context;

        public ReportService(AuthContext context)
        {
            _context = context;
        }

        public async Task<List<OrderResponse>> GetOrders()
        {
            var orders = await _context.Orders.Include(c => c.OrderDetails)
             .Select(c => new OrderResponse(c)).ToListAsync();
            return orders;
        }
    }
}


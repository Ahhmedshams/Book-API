﻿using Microsoft.AspNetCore.Mvc;

namespace Book_API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrder orderService;
        public OrderController(IOrder _orderService)
        {
            orderService = _orderService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetOrders()
        {
            List<Order> orders = await orderService.GetAllAsync();
            if (orders.Count == 0) return NotFound();
            return Ok(orders);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Order>> GetOrderById(int id)
        {
            Order order = await orderService.GetByIdAsync(id);
            if (order == null) return NotFound();
            return Ok(order);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Order>> DeleteOrderById(int id)
        {
            Order order = await orderService.DeleteAsync(id);
            if (order == null) return NotFound();
            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult<Order>> AddOrder(Order order)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            Order addedOrder = await orderService.AddAsync(order);
            return Ok(addedOrder);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Order>> EditBook(int id, Order order)
        {
            Order editedOrder = await orderService.EditAsync(id, order, e => e.Id);
            if (editedOrder == null) return NotFound();
            return Ok(editedOrder);
        }

    }
}

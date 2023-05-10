﻿using Book_API.Interfaces;
using Book_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;

namespace Book_API.Services
{
    public class PurchasableRepository : CRUDRepository<PurchasableBook> , IPurchasable
    {
        public PurchasableRepository(BookifyContextDb context):base(context) { }

        public Task<List<PurchasableBook>> GetAllAsync() =>
            base.GetAllAsync(e=>e.Author,e=>e.Categories);

        public Task<PurchasableBook> GetByIdAsync(int id) =>
            base.GetByIdAsync(id, e => e.Author, e => e.Categories);
    }
}

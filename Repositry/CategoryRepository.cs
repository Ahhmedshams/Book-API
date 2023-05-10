﻿using Book_API.Interfaces;
using Book_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Book_API.Services
{
    public class CategoryRepository : CRUDRepository<Category>,ICategory
    {
        public CategoryRepository(BookifyContextDb context) : base(context) { }

        public Task<List<Category>> GetAll() =>
            base.GetAll(e=>e.Books);

        public Task<Category> GetById(int id) =>
            base.GetById(id, e => e.Books);
    }
}
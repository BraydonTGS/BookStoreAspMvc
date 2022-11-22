﻿using BookStoreWeb.Models;

namespace BookStoreWeb.Interfaces
{
    public interface ICategoryRepository
    {

        public IEnumerable<Category> GetCategories(); 
    }
}
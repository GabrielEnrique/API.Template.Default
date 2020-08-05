﻿using API.Template.Default.Business.Interfaces;
using API.Template.Default.Business.Model;
using API.Template.Default.Business.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Template.Default.Business.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(INotifier notifier, IProductRepository productRepository) : base(notifier)
        {
            _productRepository = productRepository;
        }

        public async Task Add(Product product)
        {
            if (!ValidationExecute(new ProdutoValidation(), product)) return;

            await _productRepository.Add(product);
        }

        public async Task Update(Product product)
        {
            if (!ValidationExecute(new ProdutoValidation(), product)) return;

            await _productRepository.Update(product);
        }
    }
}

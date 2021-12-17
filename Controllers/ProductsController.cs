using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API_new.Controllers
{

    public class ProductsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public ProductsController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        [HttpGet]
        public Task<IEnumerable<ProductResource>> ListAsync()
        {
            var products = _productService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Products>, IEnumerable<ProductResource>>(products);
            return resources;
        }
    }
}

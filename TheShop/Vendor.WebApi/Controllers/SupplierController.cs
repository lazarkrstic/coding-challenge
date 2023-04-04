﻿using System;
using Microsoft.AspNetCore.Mvc;
using Vendor.WebApi.Models;
using Vendor.WebApi.Services;

namespace Vendor.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private DatabaseDriver DatabaseDriver;
        private Logger logger;

        private SupplierService _supplierService;

        public SupplierController()
        {
            DatabaseDriver = new DatabaseDriver();
            logger = new Logger();
            _supplierService = new SupplierService();
        }

        [HttpHead]
        public bool ArticleInInventory(int id)
        {
            return _supplierService.ArticleInInventory(id);
        }

        [HttpGet]
        public Article GetArtice(int id)
        {
            var articleExists = _supplierService.ArticleInInventory(id);
            if (articleExists)
            {
                return _supplierService.GetArticle(id);
            }
            else
            {
                throw new Exception("Article does not exist.");
            }
        }

        [HttpPost]
        public void BuyArticle(Article article, int buyerId)
        {
            var id = article.ID;
            if (article == null)
            {
                throw new Exception("Could not order article");
            }

            logger.Debug("Trying to sell article with id=" + id);

            article.IsSold = true;
            article.SoldDate = DateTime.Now;
            article.BuyerUserId = buyerId;

            try
            {
                DatabaseDriver.Save(article);
                logger.Info("Article with id=" + id + " is sold.");
            }
            catch (ArgumentNullException ex)
            {
                logger.Error("Could not save article with id=" + id);
                throw new Exception("Could not save article with id");
            }
            catch (Exception)
            {
            }
        }
    }
}
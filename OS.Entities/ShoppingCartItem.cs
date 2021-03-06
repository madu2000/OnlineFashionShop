﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OS.Entities
{
    public class ShoppingCartItem : IEntityBase
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public int ShoppingCartTypeId { get; set; }
        public int AccountUserId { get; set; }
        public int ProductId { get; set; }
        public string AttributeXml { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quentity { get; set; }
        public DateTime CreatedOnUTC { get; set; }
        public DateTime UpdatedOnUTC { get; set; }

        public virtual Store Store { get; set; }
        public virtual AccountUser User { get; set; }
        public virtual Product Product { get; set; }

        public ShoppingCartItem()
        {
        }
    }
}

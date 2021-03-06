﻿using OS.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OS.Services.Serivices.Abstracts
{
    public interface IShoppingCartService
    {
        int GetCartItemCountOfUser(int id);
        List<ShoppingCartItem> GetCartDetails(int id);
        int AddCartDetails(ShoppingCartItem cartitem);

    }
}

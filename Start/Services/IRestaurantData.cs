﻿using Start.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Start.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll()
    }
}

﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Start.Controllers
{
    [Route("[controller]/[action]/")]
    public class AboutController
    {
        public string Phone()
        {
            return "+3+8096+328+50+25";
        }
        public string Address()
        {
            return "Ukraine";
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopServer.Model.Items
{

    public class Response
    {

        public string message { get; set; }

        public Response(string message)
        {
            this.message = message;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesTaxCalculator.Errors
{
    /// <summary>
    /// Class for Validation Errors 
    /// </summary>
    public class ApiValidationErrorResponse : ApiResponse
    {
        public ApiValidationErrorResponse() : base(400)
        {
        }
        public IEnumerable<string> Errors { get; set; }
    }
}

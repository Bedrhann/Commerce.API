﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Wrappers.Response
{
    public class BaseResponse<T>
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }
        public T Response { get; private set; }
        public BaseResponse(bool isSuccess)
        {
            Response = default;
            Success = isSuccess;
            Message = isSuccess ? "Success" : "Fault";
        }
        public BaseResponse(T resource)
        {
            Success = true;
            Message = "Success";
            Response = resource;
        }
        public BaseResponse(string message)
        {
            Success = false;
            Response = default;

            if (!string.IsNullOrWhiteSpace(message))
            {
                Message = message;
            }
        }
        public BaseResponse(string message,bool isSuccess)
        {
            Success = true;
            Response = default;

            if (!string.IsNullOrWhiteSpace(message))
            {
                Message = message;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace PShopSolution.ViewModels.Common
{
    public class ApiErrorResult<T> : ApiResult<T>
    {
        public string[] ValidationErrors { get; set; }

        public ApiErrorResult()
        {
        }

        //1 lỗi
        public ApiErrorResult(string message)
        {
            IsSuccessed = false;
            Message = message;
        }

        // nhiều lỗi
        public ApiErrorResult(string[] validationErrors)
        {
            IsSuccessed = false;
            ValidationErrors = validationErrors;
        }
    }
}
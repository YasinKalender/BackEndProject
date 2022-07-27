using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndProject.Common.Responses
{
    public class Response<T> : BaseResponse
    {
        public T Result { get; set; }

        public static Response<T> GetResponse(T obj, bool success, string message = null, string ex = "")
        {
            return new Response<T>
            {
                Result = obj,
                Success = success,
                Message = message,
                Exception = ex
            };
        }

        public static Response<T> GetSuccess(T obj, string message = null)
        {
            return GetResponse(obj, true, message, null);
        }
        public static Response<T> GetError(string ex = "", string message = null, T obj = default(T))
        {
            return GetResponse(obj, false, message, ex);
        }
    }
}

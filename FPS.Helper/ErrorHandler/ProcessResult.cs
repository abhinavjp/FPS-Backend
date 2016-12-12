using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FPS.Helper.ErrorHandler
{
    public class ProcessResult<T> : ProcessResult
    {
        public T Result { get; set; }

        public static new ProcessResult<T> GetExceptionResult(Exception ex)
        {
            var errors = ExtractErrors(ex, new List<string>());
            return new ProcessResult<T> { Errors = errors, StatusCode = HttpStatusCode.InternalServerError }; ;
        }
    }
    public class ProcessResult
    {
        public static ProcessResult AllOk
        {
            get
            {
                return new ProcessResult();
            }
        }
        public static ProcessResult AllOkWithMessage(string message)
        {
            return new ProcessResult { Message = message };
        }
        public static ProcessResult AllOkWitId(int id)
        {
            return new ProcessResult<int> { Result = id };
        }
        public HttpStatusCode StatusCode { get; set; }
        public static List<string> ExtractErrors(Exception ex, List<string> errors)
        {
            if (ex.InnerException == null)
            {
                errors.Add(ex.Message);
            }
            else
            {
                errors = ExtractErrors(ex.InnerException, errors);
            }
            return errors;
        }
        public static ProcessResult GetExceptionResult(Exception ex)
        {
            var errors = ExtractErrors(ex, new List<string>());
            return new ProcessResult { Errors = errors, StatusCode = HttpStatusCode.InternalServerError };
        }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public bool Success
        {
            get
            {
                return Errors == null || Errors.Any();
            }
        }
        public override string ToString()
        {
            return string.Join(",", Errors.ToArray());
        }
    }

    public static class ProcessResultHelper
    {
        public static ProcessResult<T> GetResult<T>(this T result)
        {
            return new ProcessResult<T> { Result = result };
        }

        public static ProcessResult<T> GetResult<T>(this T result, string message)
        {
            return new ProcessResult<T> { Result = result, Message = message };
        }

        public static ProcessResult<T> GetNegativeResult<T>(string errorMessage, HttpStatusCode statusCode)
        {
            return new ProcessResult<T> { Errors = new List<string> { errorMessage }, StatusCode = statusCode };
        }

        public static ProcessResult GetNegativeResult(string errorMessage, HttpStatusCode statusCode)
        {
            return new ProcessResult { Errors = new List<string> { errorMessage }, StatusCode = statusCode };
        }
    }
}

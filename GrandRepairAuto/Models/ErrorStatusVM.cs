using System.Net;

namespace GrandRepairAuto.Models
{
    public class ErrorStatusVM
    {
        public ErrorStatusVM(int code)
        {
            StatusCode = code;
            Message = code switch
            {
                403 => "You Shall Not Pass!",
                404 => "Oops .... we seem to have misplaced something...",
                500 => "Uh, oh! Something went wrong! Stay put, we'll fix it asap..",
                _ => ((HttpStatusCode)code).ToString(),
            };
        }

        public int StatusCode { get; }

        public string Message { get; }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;

namespace Adp.Interview.Calc.Shared.ApiUtilities
{
    public static class ResponseResults
    {
        private static readonly
            Dictionary<ResponseStatus, HttpStatusCode> StatusMap =
                new Dictionary<ResponseStatus, HttpStatusCode>
                {
                    { ResponseStatus.OK, HttpStatusCode.OK },
                    { ResponseStatus.NoContent, HttpStatusCode.NoContent },
                    { ResponseStatus.Created, HttpStatusCode.Created },
                    { ResponseStatus.Accepted, HttpStatusCode.Accepted },

                    { ResponseStatus.BadRequest, HttpStatusCode.BadRequest },
                    { ResponseStatus.NotFound, HttpStatusCode.NotFound },
                    { ResponseStatus.Unauthorized, HttpStatusCode.Unauthorized }
                };

        public static IActionResult ResponseToActionResult<TResponse>(
            TResponse response,
            Func<TResponse, object> mapSuccessRequestBody,
            Func<TResponse, object> mapFailureRequestBody)
                where TResponse : ResponseDto
        {
            var httpStatus = StatusMap[response.Status];
            var mapReqBody = response.Status.Succeeded()
                ? mapSuccessRequestBody
                : mapFailureRequestBody;

            var reqBody = mapReqBody?.Invoke(response);
            var hasReqBody = reqBody != null;
            var result = hasReqBody
                ? new ObjectResult(reqBody) { StatusCode = (int)httpStatus }
                : (IActionResult)new StatusCodeResult((int)httpStatus);

            return result;
        }

        public static IActionResult ResponseToActionResult<TCommandResponse>(
            TCommandResponse response,
            Func<TCommandResponse, object> mapSuccessRequestBody)
                where TCommandResponse : ResponseDto =>
                    ResponseToActionResult(response, mapSuccessRequestBody, x => x?.BadRequestReason);

        public static IActionResult ResponseToActionResult<TCommandResponse>(
            TCommandResponse response)
                where TCommandResponse : ResponseDto => ResponseToActionResult(response, null, x => x?.BadRequestReason);
    }
}

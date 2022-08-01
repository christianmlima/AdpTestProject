using System;

namespace Adp.Interview.Calc.Shared.ApiUtilities
{
    public static class Responses
    {
        public static T OK<T>(Action<T> act = null) where T : ResponseDto, new()
        {
            return CreateResponse(ResponseStatus.OK, act);
        }

        public static T Created<T>(Action<T> act = null) where T : ResponseDto, new()
        {
            return CreateResponse(ResponseStatus.Created, act);
        }

        public static T Accepted<T>(Action<T> act = null) where T : ResponseDto, new()
        {
            return CreateResponse(ResponseStatus.Accepted, act);
        }

        public static T NoContent<T>(Action<T> act = null) where T : ResponseDto, new()
        {
            return CreateResponse(ResponseStatus.NoContent, act);
        }

        public static T BadRequest<T>(BadRequestDto badReqReason = null, Action<T> act = null) where T : ResponseDto, new()
        {
            T val = CreateResponse(ResponseStatus.BadRequest, act);
            val.BadRequestReason = badReqReason;
            return val;
        }

        public static T Unauthorized<T>(BadRequestDto badReqReason = null, Action<T> act = null) where T : ResponseDto, new()
        {
            T val = CreateResponse(ResponseStatus.Unauthorized, act);
            val.BadRequestReason = badReqReason;
            return val;
        }

        public static T NotFound<T>(BadRequestDto badReqReason = null, Action<T> act = null) where T : ResponseDto, new()
        {
            T val = CreateResponse(ResponseStatus.NotFound, act);
            val.BadRequestReason = badReqReason;
            return val;
        }

        private static T CreateResponse<T>(ResponseStatus status, Action<T> act = null) where T : ResponseDto, new()
        {
            T val = new T();
            val.Status = status;
            T val2 = val;
            act?.Invoke(val2);
            return val2;
        }
    }
}
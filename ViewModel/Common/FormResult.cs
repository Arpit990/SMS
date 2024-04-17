﻿using SpeakerManagementSystem.Data.Enum;

namespace SpeakerManagementSystem.ViewModel.Common
{

	public class FormResult
    {
        public ResponseJSON ResponseJSON { get; set; }

        public static FormResult Success(object responseData = null)
        {
            var formResult = new FormResult();
            var responseJSON = new ResponseJSON()
            {
                Message = "Success",
                ResponseCode = AjaxResponse.Success.ToString(),
                ResponseData = responseData
            };
            formResult.ResponseJSON = responseJSON;
            return formResult;
        }
        public static FormResult Info()
        {
            var formResult = new FormResult();
            var responseJSON = new ResponseJSON()
            {
                Message = "Info",
                ResponseCode = AjaxResponse.Info.ToString(),
            };
            formResult.ResponseJSON = responseJSON;
            return formResult;
        }

        public static FormResult Warning()
        {
            var formResult = new FormResult();
            var responseJSON = new ResponseJSON()
            {
                Message = "Warning",
                ResponseCode = AjaxResponse.Warning.ToString(),
            };
            formResult.ResponseJSON = responseJSON;
            return formResult;
        }

        public static FormResult Processing()
        {
            var formResult = new FormResult();
            var responseJSON = new ResponseJSON()
            {
                Message = "Processing",
                ResponseCode = AjaxResponse.Processing.ToString(),
            };
            formResult.ResponseJSON = responseJSON;
            return formResult;
        }

        public static FormResult Error(dynamic modelState)
        {
            var errorList = GetErrorsListFromModelState(modelState);

            var responseJSON = new ResponseJSON();
            if (errorList.Count > 1)
                responseJSON.Message = "A few fields are missing or invalid.";
            else
                responseJSON.Message = errorList.Count > 0 ? errorList[0].Message ?? "" : "";

            responseJSON.ResponseCode = AjaxResponse.Error.ToString();
            responseJSON.Errors = errorList;
            var formResult = new FormResult();
            formResult.ResponseJSON = responseJSON;
            return formResult;
        }

        public static FormResult ErrorWithCustomMessage(dynamic modelState, string customMessage)
        {
            var errorList = GetErrorsListFromModelState(modelState);

            var responseJSON = new ResponseJSON();

            //just safety net in case custom message empty to avoid losing details
            if (string.IsNullOrWhiteSpace(customMessage))
            {
                if (errorList.Count > 1)
                    responseJSON.Message = "A few fields are missing or invalid.";
                else
                    responseJSON.Message = errorList.Count > 0 ? errorList[0].Message ?? "" : "";
            }
            else
                responseJSON.Message = customMessage;

            responseJSON.ResponseCode = AjaxResponse.Error.ToString();
            responseJSON.Errors = errorList;
            var formResult = new FormResult();
            formResult.ResponseJSON = responseJSON;
            return formResult;
        }

        private static List<Error> GetErrorsListFromModelState(dynamic modelState)
        {
            var errorList = new List<Error>();
            foreach (var item in modelState)
            {
                foreach (var error in item.Value.Errors)
                {
                    errorList.Add(new Error(item.Key, error.ErrorMessage));
                }
            }
            return errorList;
        }
    }

    public class Error
    {
        public string Field { get; set; }
        public string Message { get; set; }

        public Error()
        { }
        public Error(string field, string message)
        {
            Field = field;
            Message = message;
        }
    }

    public class ResponseJSON
    {
        public object ResponseData { get; set; }
        public string ResponseCode { get; set; }
        public string Message { get; set; }
        public string ConfirmMessage { get; set; }
        public List<Error> Errors { get; set; }
    }


}

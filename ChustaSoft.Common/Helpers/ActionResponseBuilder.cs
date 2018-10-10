using System;
using ChustaSoft.Common.Enums;
using ChustaSoft.Common.Exceptions;
using ChustaSoft.Common.Utilities;


namespace ChustaSoft.Common.Helpers
{
    /// <summary>
    /// Builder for ActionResponse Type
    /// <seealso cref="CollectionsHelper.ActionResponse"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ActionResponseBuilder<T>
    {
        
        #region Fields

        private ActionResponse<T> _actionResponse;

        #endregion


        #region Constructors

        public ActionResponseBuilder()
        {
            _actionResponse = new ActionResponse<T>();
        }

        public ActionResponseBuilder(T data)
        {
            _actionResponse = new ActionResponse<T>(data);
        }

        #endregion


        #region Public Methods
        
        public ActionResponse<T> Build()
        {
            return _actionResponse;
        }

        public ActionResponseBuilder<T> AddData(T data)
        {
            _actionResponse.Data = data;

            return this;
        }

        public ActionResponseBuilder<T> SetStatus(ActionResponseType status)
        {
            _actionResponse.Flag = status;

            return this;
        }

        public ActionResponseBuilder<T> AddError(ErrorMessage errorMessage)
        {
            _actionResponse.Errors.Add(errorMessage);

            return this;
        }

        public ActionResponseBuilder<T> AddError(BusinessException exception)
        {
            var errorMessage = new ErrorMessage(exception);
            
            return this.AddError(errorMessage);
        }

        public ActionResponseBuilder<T> AddError(ErrorType errorType, string errorText)
        {
            var errorMessage = new ErrorMessage(errorType, errorText);

            return this.AddError(errorMessage);
        }

        #endregion

    }
}

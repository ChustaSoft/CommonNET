using ChustaSoft.Common.Contracts;
using ChustaSoft.Common.Enums;
using ChustaSoft.Common.Exceptions;
using ChustaSoft.Common.Utilities;

namespace ChustaSoft.Common.Builders
{
    /// <summary>
    /// Builder for ActionResponse Type
    /// <seealso cref="CollectionsHelper.ActionResponse"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ActionResponseBuilder<T> : IBuilder<ActionResponse<T>>
    {
        
        private ActionResponse<T> _actionResponse;
        internal ActionResponse<T> ActionResponse => _actionResponse;
        

        public ActionResponseBuilder()
        {
            _actionResponse = new ActionResponse<T>();
        }

        public ActionResponseBuilder(T data)
        {
            _actionResponse = new ActionResponse<T>(data);
        }

        public static ActionResponseBuilder<T> Create() => new ActionResponseBuilder<T>();


        public ActionResponse<T> Build() => ActionResponse;

        public ActionResponseBuilder<T> SetData(T data)
        {
            _actionResponse.Data = data;

            return this;
        }

        public ActionResponseBuilder<T> SetStatus(ActionResponseType status)
        {
            _actionResponse.Flag = status;

            return this;
        }

        public ActionResponseBuilder<T> SetStatus(bool flag)
        {
            _actionResponse.Flag = flag ? ActionResponseType.Success : ActionResponseType.Error;

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

    }


    /// <summary>
    /// Builder for ActionResponse Type
    /// <seealso cref="CollectionsHelper.ActionResponse"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ActionResponseBuilder : IBuilder<ActionResponse>
    {

        private ActionResponse _actionResponse;
        internal ActionResponse ActionResponse => _actionResponse;


        public ActionResponseBuilder()
        {
            _actionResponse = new ActionResponse();
        }

        public static ActionResponseBuilder Create() => new ActionResponseBuilder();


        public ActionResponse Build() => ActionResponse;
        
        public ActionResponseBuilder SetStatus(ActionResponseType status)
        {
            _actionResponse.Flag = status;

            return this;
        }

        public ActionResponseBuilder SetStatus(bool flag)
        {
            _actionResponse.Flag = flag ? ActionResponseType.Success : ActionResponseType.Error;

            return this;
        }

        public ActionResponseBuilder AddError(ErrorMessage errorMessage)
        {
            _actionResponse.Errors.Add(errorMessage);

            return this;
        }

        public ActionResponseBuilder AddError(BusinessException exception)
        {
            var errorMessage = new ErrorMessage(exception);

            return this.AddError(errorMessage);
        }

        public ActionResponseBuilder AddError(ErrorType errorType, string errorText)
        {
            var errorMessage = new ErrorMessage(errorType, errorText);

            return this.AddError(errorMessage);
        }

    }

}

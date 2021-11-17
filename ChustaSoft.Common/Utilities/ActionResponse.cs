using ChustaSoft.Common.Constants;
using ChustaSoft.Common.Enums;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ChustaSoft.Common.Utilities
{

    /// <summary>
    /// Object for unifying Typed response from a backend, independently of the architecture type
    /// Valid for WCF, API and more 
    /// Creation could be done by his constructors or by using ActionResponseBuilder
    /// <seealso cref="ActionResponseBuilder"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [DataContract(Name = SerializedNames.ActionResponse)]
    public class ActionResponse<T> : ActionResponse
    {

        [DataMember]
        public T Data { get; set; }


        public ActionResponse() 
            : base()
        { }

        public ActionResponse(T data) 
            : base(ActionResponseType.Success)
        {
            Data = data;
        }

        public ActionResponse(T data, IList<ErrorMessage> errors)
            : base(ActionResponseType.Warning)
        {
            Data = data;
            Errors = errors;
        }

    }



    /// <summary>
    /// Object for unifying Typed response from a backend, independently of the architecture type
    /// Valid for WCF, API and more 
    /// Creation could be done by his constructors or by using ActionResponseBuilder
    /// <seealso cref="ActionResponseBuilder"/>
    /// </summary>
    public class ActionResponse
    {
        
        [DataMember]
        public ActionResponseType Flag { get; set; }

        [DataMember]
        public IList<ErrorMessage> Errors
        {
            get
            {
                if (_errors == null)
                    _errors = new List<ErrorMessage>();

                return _errors;
            }
            set
            {
                _errors = value;
            }
        }
        private IList<ErrorMessage> _errors;


        public ActionResponse() { }

        public ActionResponse(IList<ErrorMessage> errors) 
            : this(ActionResponseType.Error)
        {
            Errors = errors;
        }        

        protected ActionResponse(ActionResponseType actionResponseType)
        {
            Flag = actionResponseType;
        }

    }

}

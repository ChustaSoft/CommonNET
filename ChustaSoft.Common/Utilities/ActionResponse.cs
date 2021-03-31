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
    public class ActionResponse<T>
    {

        #region Properties

        [DataMember]
        public T Data { get; set; }

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

        #endregion


        #region Constructors

        private ActionResponse(ActionResponseType actionResponseType)
        {
            Flag = actionResponseType;
        }

        public ActionResponse() { }

        public ActionResponse(T data) : this(ActionResponseType.Success)
        {
            Data = data;
        }

        public ActionResponse(IList<ErrorMessage> errors) : this(ActionResponseType.Error)
        {
            Errors = errors;
        }

        public ActionResponse(T data, IList<ErrorMessage> errors) : this(ActionResponseType.Warning)
        {
            Data = data;
            Errors = errors;
        }

        #endregion

    }
}

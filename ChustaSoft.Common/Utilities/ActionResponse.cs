using ChustaSoft.Common.Constants;
using ChustaSoft.Common.Enums;
using System.Collections.Generic;
using System.Runtime.Serialization;


namespace ChustaSoft.Common.Utilities
{

    [DataContract(Name = SerializedNames.ActionResponse)]
    public class ActionResponse<T>
    {

        #region Properties

        [DataMember]
        public T Value { get; set; }

        [DataMember]
        public PaginatedList<T> Values { get; set; }

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

        public ActionResponse(T value) : this(ActionResponseType.Success)
        {
            Value = value;
        }

        public ActionResponse(PaginatedList<T> values) : this(ActionResponseType.Success)
        {
            Values = values;
        }

        public ActionResponse(IList<ErrorMessage> errors) : this(ActionResponseType.Error)
        {
            Errors = errors;
        }

        public ActionResponse(T value, IList<ErrorMessage> errors) : this(ActionResponseType.Warning)
        {
            Value = value;
            Errors = errors;
        }

        #endregion

    }
}

using ChustaSoft.Common.Builders;
using ChustaSoft.Common.Enums;
using ChustaSoft.Common.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;

namespace ChustaSoft.Common.Base
{

    public class ApiControllerBase<TController> : ControllerBase
    {

        #region Fields

        protected readonly ILogger<TController> _logger;

        #endregion


        #region Constructor

        public ApiControllerBase(ILogger<TController> logger)
        {
            _logger = logger;
        }

        #endregion


        #region Protected methods

        protected ActionResponseBuilder<T> GetEmptyResponseBuilder<T>()
            => ActionResponseBuilder<T>.Create();

        protected IActionResult Ok<T>(ActionResponseBuilder<T> actionResponseBuilder)
        {
            return Ok(actionResponseBuilder.Build());
        }

        protected IActionResult Ko<T>(ActionResponseBuilder<T> actionResponseBuilder, Exception exception)
        {
            _logger.LogError(exception, null);

            actionResponseBuilder.AddError(new ErrorMessage(ErrorType.Invalid, exception.Message));

            return BadRequest(actionResponseBuilder.Build());
        }

        #endregion

    }

    public class ApiControllerBase<TController, TSettings> : ApiControllerBase<TController>
        where TSettings : class, new()
    {

        #region Fields

        protected readonly TSettings _appSettings;

        #endregion


        #region Constructor

        public ApiControllerBase(ILogger<TController> logger, IOptions<TSettings> appSettings)
            : base(logger)
        {
            _appSettings = appSettings.Value;
        }

        #endregion

    }
}

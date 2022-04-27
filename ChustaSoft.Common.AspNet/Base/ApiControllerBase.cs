using ChustaSoft.Common.Builders;
using ChustaSoft.Common.Enums;
using ChustaSoft.Common.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;

namespace ChustaSoft.Common.Base
{
    /// <summary>
    /// Base Controller for any Api controller
    /// Forces the inherited to have injected a ILogger, defined in the client application
    /// </summary>
    /// <typeparam name="TController">ControllerType itself, required for ILogger</typeparam>
    public class ApiControllerBase<TController> : ControllerBase
    {
        
        protected readonly ILogger<TController> _logger;


        public ApiControllerBase(ILogger<TController> logger)
        {
            _logger = logger;
        }

        
        /// <summary>
        /// Creates a empty instance of ActionResponseBuilder with an OkResponse response
        /// </summary>
        /// <typeparam name="T">Generic object for value</typeparam>
        /// <returns>The builder for ActionResponse and the generic object specified</returns>
        protected ActionResponseBuilder<T> GetEmptyResponseBuilder<T>()
            => ActionResponseBuilder<T>.Create();

        /// <summary>
        /// Prepares based on ActionResponseBuilder, an IActionResult
        /// </summary>
        /// <typeparam name="T">Generic object for value</typeparam>
        /// <param name="actionResponseBuilder">ActionResponseBuilder prepared in the process</param>
        /// <returns>OkObjectResult with value data in ActionResponse and StatusCode of 200</returns>
        protected IActionResult Ok<T>(ActionResponseBuilder<T> actionResponseBuilder)
        {
            return Ok(actionResponseBuilder.Build());
        }

        /// <summary>
        /// Prepares based on ActionResponseBuilder, an IActionResult with a BadRequestResult response
        /// </summary>
        /// <typeparam name="T">Generic object for value</typeparam>
        /// <param name="actionResponseBuilder">ActionResponseBuilder prepared in the process</param>
        /// <param name="exception">Exception raised</param>
        /// <returns>BadRequestObjectResult with errors in ActionResponse and StatusCode of 400</returns>
        protected IActionResult Ko<T>(ActionResponseBuilder<T> actionResponseBuilder, Exception exception)
        {
            _logger.LogError(exception, null);

            actionResponseBuilder.AddError(new ErrorMessage(ErrorType.Invalid, exception.Message));

            return BadRequest(actionResponseBuilder.Build());
        }

        /// <summary>
        /// <see cref="ControllerBaseExtensions.GetRequestUserId(ControllerBase, string)"/>
        /// </summary>
        protected string GetRequestUserId() => this.GetRequestUserId();

        /// <summary>
        /// <see cref="ControllerBaseExtensions.GetRequestUserEmail(ControllerBase)(ControllerBase, string)"/>
        /// </summary>
        protected string GetRequestUserEmail() => this.GetRequestUserEmail();
    }

    public class ApiControllerBase<TController, TSettings> : ApiControllerBase<TController>
        where TSettings : class, new()
    {

        protected readonly TSettings _appSettings;

        
        public ApiControllerBase(ILogger<TController> logger, IOptions<TSettings> appSettings)
            : base(logger)
        {
            _appSettings = appSettings.Value;
        }

    }
}

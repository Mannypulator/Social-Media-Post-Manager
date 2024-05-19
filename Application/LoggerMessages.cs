using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Follow;
using Microsoft.Extensions.Logging;

namespace Application
{
    public static partial class LoggerMessages
    {
        [LoggerMessage(0, LogLevel.Information, "Inside {@nameOfMethod} method")]
        public static partial void LogMethodName(ILogger logger, string nameOfMethod);

        [LoggerMessage(0, LogLevel.Information, "Follower Request sent: {@request}")]
        public static partial void LogAddFollower(ILogger logger, AddFollowerDto request);

        [LoggerMessage(0, LogLevel.Information, "Successfully {@actionCarriedOut}")]
        public static partial void LogActionCarriedOut(ILogger logger, string actionCarriedOut);

        // [LoggerMessage(0, LogLevel.Information, "Request to be approved {@requestTobeApproved}")]
        // public static partial void LogRequestToBeApproved(ILogger logger, Domain.Entities.ApprovalTray requestTobeApproved);

        // [LoggerMessage(0, LogLevel.Information, "Request about to be {@action}")]
        // public static partial void LogRequestAboutToBe(ILogger logger, string action);

        // [LoggerMessage(0, LogLevel.Information, "Response gotten from {@serviceName}: {@response}")]
        // public static partial void LogResponseFromService(ILogger logger, string serviceName, GenericResponse<string> response);

        // [LoggerMessage(0, LogLevel.Information, "Request sent to {@serviceName}: {@request}")]
        // public static partial void LogRequestSentToService(ILogger logger, string serviceName, UpdateApprovalRequest request);

        [LoggerMessage(0, LogLevel.Information, "{@objectType} gotten {@object}")]
        public static partial void LogObjectGotten(ILogger logger, string objectType, object @object);
    }
}
using System;
using System.Linq;
using Challenge.Domain.Core.Notifications;
using Challenge.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace Challenge.Api.Controllers
{
    [Produces("application/json")]
    public abstract class BaseController : Controller
    {
        private readonly DomainNotificationHandler _notifications;
        private readonly IMediatorHandler _mediator;

        protected Guid OrganizadorId { get; set; }

        protected BaseController(INotificationHandler<DomainNotification> notifications,
                                 IMediatorHandler mediator)
        {
            _notifications = (DomainNotificationHandler)notifications;
            _mediator = mediator;
        }

        protected new async Task<IActionResult> Response(object result = null)
        {
            if (OperationIsValid())
            {
                var retok = Task.Run(() => Ok(new
                {
                    success = true,
                    data = result
                }));

                return await retok;
            }

            var ret = Task.Run(() => BadRequest(new
            {
                success = false,
                errors = _notifications.GetNotifications().Select(n => n.Value)
            }));

            return await ret;
        }

        protected bool OperationIsValid()
        {
            return (!_notifications.HasNotifications());
        }

        protected void ReportErroModelInvalid()
        {
            var erros = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var erro in erros)
            {
                var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                ReportError(string.Empty, erroMsg);
            }
        }

        protected void ReportError(string codigo, string mensagem)
        {
            _mediator.Publish(new DomainNotification(codigo, mensagem));
        }
    }
}
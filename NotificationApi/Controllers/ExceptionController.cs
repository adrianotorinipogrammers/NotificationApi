using Infra.NotificationSystem.NotificationBase;
using Microsoft.AspNetCore.Mvc;

namespace NotificationApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class ExceptionController : ControllerBase
    {
        INotificableService _exceptionNotificationService;

        public ExceptionController(INotificableService exceptionNotificationService)
        {
            _exceptionNotificationService = exceptionNotificationService;
        }

        /// <summary>
        /// Atencao, esse é o método mais importante do do controller, ele usar um middleware e trata a exception na pipeline em outro momento, o nome do middleware é "ExceptionHandlingMiddleware"
        /// </summary>
        /// <returns></returns>
        /// <exception cref="CustomSampleException.CustomSampleException"></exception>

        [HttpPost("/MidllewareException")]
        public IActionResult MidllewareException() => throw new CustomSampleException.CustomSampleException("Teste, usando o middleware para tratar exceções");

        //Trata a exception
        [HttpPost("/NullReferenceException")]
        public IActionResult ThrowException()
        {
            try
            {
                throw new NullReferenceException("Teste, logando exception,objeto referencia nula");
            }
            catch (Exception ex)
            {
                _exceptionNotificationService.AddNotification(ex.Message, nameof(ThrowException));
            }

            return Ok();
        }

        //Deixa o middleware tratar a exception
        [HttpPost("/ExpcetionTratadaPeloMiddleware")]
        public IActionResult CommonExpcetion()
        {
            throw new Exception("Teste, Common Excption tratada pelo middleware");
        }

        /// <summary>
        /// Recupera todas as exceptions que estão na lista de notificações
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetExceptions()
        {
            if (_exceptionNotificationService.HasNotifications())
            {
                return BadRequest(_exceptionNotificationService.GetNotifications());
            }

            return Ok("Nenhuma exceção foi encontrada");
        }
    }
}

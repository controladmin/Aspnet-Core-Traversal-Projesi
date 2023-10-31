using Microsoft.AspNetCore.Mvc;
using NToastNotify; // IToastNotification interfaceni kullanabilmek için ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraversalCoreProje.CQRS.Commends.DestinationCommand; // CreateDestinationCommand sınıfını kullanabilmek için bu kütüphaneyi ekledik
using TraversalCoreProje.CQRS.Handlers.DestinationHandler; // GetAllDestinationQueryHandler bu sınıfı kullanabilmek için bu kütüphaneyi ekledik
using TraversalCoreProje.CQRS.Queries.DestinationQuery; // GetDestinationByIdQuery bu sınıfı kullanabilmek için bu kütüphaneyi ekledik
using TraversalCoreProje.CQRS.Results.DestinationResults;  //  GetDestinationByIdQueryResult bu sınıfı kullanabilmek için bu kütüphaneyi ekledik

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/DestinationCQRS")]
    public class DestinationCQRSController : Controller
    {
        private readonly GetAllDestinationQueryHandler  _getalldestinationqueryHandler;
        private readonly GetDestinationByIdQueryHandler _getdestinationbyidHandler;
        private readonly CreateDestinationCommandHandler _createdestinationcommandHandler;
        private readonly RemoveDestinationCommandHandler _removedestinationcommandHandler;
        private readonly UpdateDestinationCommandHandler _updatedestinationcommandHandler;
        private readonly IToastNotification _toastNotification;

        public DestinationCQRSController(GetAllDestinationQueryHandler getalldestinationqueryHandler, GetDestinationByIdQueryHandler getdestinationbyidHandler, CreateDestinationCommandHandler createdestinationcommandHandler, RemoveDestinationCommandHandler removedestinationcommandHandler, UpdateDestinationCommandHandler updatedestinationcommandHandler, IToastNotification toastNotification)
        {
            _getalldestinationqueryHandler = getalldestinationqueryHandler;
            _getdestinationbyidHandler = getdestinationbyidHandler;
            _createdestinationcommandHandler = createdestinationcommandHandler;
            _removedestinationcommandHandler = removedestinationcommandHandler;
            _updatedestinationcommandHandler = updatedestinationcommandHandler;
            _toastNotification = toastNotification;
        }
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            var values = _getalldestinationqueryHandler.Handle();
            return View(values);
        }

        [Route("GetDestinationById/{id}")]
        [HttpGet]
        public IActionResult GetDestinationById(int id)
        {
            var values = _getdestinationbyidHandler.Handle(new GetDestinationByIdQuery(id));
            return View(values);
        }
        [Route("GetDestinationById/{id}")]

        [HttpPost]
        public IActionResult GetDestinationById(UpdateDestinationCommand command)
        {
            _updatedestinationcommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        [Route("AddDestination")]
        [HttpGet]
        public IActionResult AddDestination()
        {
            return View();
        }

        [Route("AddDestination")]
        [HttpPost]
        public IActionResult AddDestination(CreateDestinationCommand command)
        {
            _createdestinationcommandHandler.Handle(command);
            _toastNotification.AddSuccessToastMessage("Rota Eklendi");
            return RedirectToAction("Index");
        }

        [Route("DeleteDestination/{id}")]
        public IActionResult DeleteDestination(int id)
        {
            _removedestinationcommandHandler.Handle(new RemoveDestinationCommand(id));
            _toastNotification.AddWarningToastMessage("Rota Silindi");
            return RedirectToAction("Index");
        }
    }
}

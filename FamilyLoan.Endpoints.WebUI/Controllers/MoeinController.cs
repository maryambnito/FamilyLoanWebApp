using AutoMapper;
using FamilyLoan.Core.ApplicationServices.Moeins.Commands.AddMoein;
using FamilyLoan.Core.ApplicationServices.Moeins.Queries.GetPagedMoeins;
using FamilyLoan.Endpoints.WebUI.VIewModels.Moeins;
using FamilyLoan.Utilities.Paging;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using FamilyLoan.Endpoints.WebUI.Helpers.MapperProfiles.Common;
using FamilyLoan.Core.ApplicationServices.Moeins.Queries.GetMoeinById;
using FamilyLoan.Core.ApplicationServices.Moeins.Commands.UpdateMoein;
using FamilyLoan.Core.ApplicationServices.Moeins.Commands.DeleteMoein;
using Microsoft.AspNetCore.Authorization;

namespace FamilyLoan.Endpoints.WebUI.Controllers
{
    
    public class MoeinController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly PageParameters _settings;

        public MoeinController(IMediator mediator,IOptions<PageParameters> settings, IMapper mapper)
        {
            _mediator = mediator;
            _settings = settings.Value;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult List(int pageNumber = 1, string search = "")
        {
            var result = _mediator.Send(new GetPagedMoeinQuery()
            {
                PageNumber = pageNumber,
                PageSize = _settings.PageSize,
                Search = search

            }).GetAwaiter().GetResult();

            return View(result);
        }

        #region AddMoein
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(AddMoeinViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Date = model.Date.ChangeDateToEN();

                AddMoeinCommand command = _mapper.Map<AddMoeinCommand>(model);
                var addResult = _mediator.Send(command).Result;
                if (addResult.IsSuccess)
                {

                    return RedirectToAction(nameof(List));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, addResult.Error);
                }
            }

            return View(model);

        }
        #endregion

        #region UpdateMoein
        [HttpGet]
        public IActionResult Update(int id)
        {

            GetMoeinByIdQuery query = new() { Id = id };
            var moeinDTO = _mediator.Send(query).GetAwaiter().GetResult();
            UpdateMoeinViewModel model = _mapper.Map<UpdateMoeinViewModel>(moeinDTO);
          return View(model);
        }

        [HttpPost]
        public IActionResult Update(UpdateMoeinViewModel model)
        {
            if (ModelState.IsValid)
            {

                UpdateMoeinCommand command = _mapper.Map<UpdateMoeinCommand>(model);
                var updateResult = _mediator.Send(command).Result;
                if (updateResult.IsSuccess)
                {

                    return RedirectToAction(nameof(List));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, updateResult.Error);
                }
            }

            return View(model);

        }
        #endregion

        #region Delete
        [HttpGet]
        public IActionResult DeleteMoeinById(int id)
        {
            DeleteMoeinViewModel moein = new() { 
            Id=id
            };


            return PartialView("_Delete", moein);

        }
        [HttpPost]
        public IActionResult DeleteMoein(int id)
        {
          
                DeleteMoeinCommand command = new()
                {
                    Id = id

                };
                _mediator.Send(command);

                return RedirectToAction(nameof(List));
         
        }


        #endregion

    }
}

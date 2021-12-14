using Microsoft.AspNetCore.Mvc;
using Application;
using WebApp.Models;
using Domain;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System;

namespace WebApp.Controllers
{
    [Route("bar")]
    public class BarController : ControllerBase
    {
        private readonly ILogger<BarController> _logger;

        public BarController(ILogger<BarController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("getall")]
        public List<Bar> getAllBar(
            [FromServices] IBarService service)
        {
            List<Bar> listBar = service.getAllBar();

            return listBar;
        }

        [HttpGet]
        [Route("get/{id?}")]
        public Bar getBar(
            [FromServices] IBarService service,
            Guid id)
        {
            Bar bar = service.get(id);

            return bar;
        }

        [HttpGet]
        [Route("remove/{id?}")]
        public void removeBar(
            [FromServices] IBarService service,
            Guid id)
        {
            service.remove(id);
        }

        [HttpPost]
        [Route("save")]
        public void saveBar(
            [FromServices] IBarService service,
            [FromBody] BarViewModel barVM)
        {
            Bar bar = new Bar(barVM.Nome);

            service.saveBar(bar);
        }
    }
}

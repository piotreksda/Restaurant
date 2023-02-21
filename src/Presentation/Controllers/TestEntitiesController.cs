﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.TestEntities.Queries.GetTestEntity;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Restaurant.Presentation.Controllers
{
    public class TestEntitiesController : ApiControllerBase
    {
        [HttpGet]
        public async Task<List<TestEntityDto>> Get()
        {
            return await Mediator.Send(new GetTestEntityQuery());
        }
    }
}


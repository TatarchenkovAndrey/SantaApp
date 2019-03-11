using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SantaApi.Helpers;
using SantaApi.Services;
using SantaApi.ViewModels;

namespace SantaApi.Controllers
{
    [ApiController]
    [Route("api/")]
    [ProducesResponseType(500)]
    [Produces(MediaTypeNames.Application.Json)]
    public class ValuesController : ControllerBase
    {
        private ISantaService santaService { get; set; }

        public ValuesController(ISantaService _santaService)
        {
            santaService = _santaService;
        }
        
        /// <summary>
        /// Узнать, кто был хорошим в 2018
        /// </summary>
        /// <param name="name">ФИО</param>
        /// <param name="age">Возраст</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Route(ApiPath.BoysAndGirls)]
        public async ValueTask<IActionResult> Get(string name, int age)
        {
            var result = await santaService.GetEmployeeVerdict(name, age);

            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Error);
        }

        /// <summary>
        /// Получить список всех
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Route(ApiPath.GetAll)]
        public async ValueTask<IActionResult> GetAll()
        {
            var result = await santaService.GetVerdictList();

            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Error);
        }

        /// <summary>
        /// Добавить вердикт
        /// </summary>
        /// <param name="verdictDto">Данные сотрудника и вердикт по нему</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Route(ApiPath.AddVerdict)]
        public async ValueTask<IActionResult> AddVerdict(CreateVerdictDto verdictDto)
        {
            var result = await santaService.AddVerdict(verdictDto);

            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Error);
        }

    }
}

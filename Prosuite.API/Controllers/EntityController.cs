using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prosuite.Domain.Contracts.Dtos.Requests;
using Prosuite.Domain.Contracts.Interfaces.Services.Domain;
using Prosuite.Domain.Entities;

namespace Prosuite.API.Controllers
{
    public abstract class EntityController<T, Response, Request, Filter> : Controller
                        where T : Entity where Response : class where Request : BaseRequest where Filter : FilterableRequest
    {
        private readonly IBaseService<T, Response, Request, FilterableRequest> service;

        public EntityController(IBaseService<T, Response, Request, FilterableRequest> service)
        {
            this.service = service;
        }

        [HttpPost]
        [Route("create")]
        public async virtual Task<IActionResult> Post([FromForm] Request data)
        {
            var response = await service.Create(data);
            return StatusCode(response.StatusCode, response);
        }

        


        [HttpGet]
        [Route("get-by-id/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var response = await service.Get(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet]
        [Route("find")]
        public IActionResult Criteria([FromQuery] FilterableRequest filterCriteria)
        {
            var response = service.Find(filterCriteria);
            return StatusCode(response.StatusCode, response);
        }

        

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> All()
        {
            var response = await this.service.All();
            return StatusCode(response.StatusCode, response);
        }

      

        

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Put([FromForm] Request data)
        {
            var response = await service.Update(data);
            return StatusCode(response.StatusCode, response);
        }

        

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var response = await service.Delete(id);
            return StatusCode(response.StatusCode, response);
        }


    }
}

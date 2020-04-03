using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciamentoTerritoriosJW.Core.Services;
using GerenciamentoTerritoriosJW.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoTerritoriosJW.Controllers
{
    [Route("api/directions")]
    [ApiController]
    public class ApiDirectionsController : ControllerBase
    {
        private IDirectionRepository directionRepository;

        public ApiDirectionsController(IDirectionRepository directionRepository)
        {
            this.directionRepository = directionRepository;

        }

        // GET: api/ApiDirections
        [HttpGet]
        public ApiDirectionsViewModel.Cards Get()
        {
            return new ApiDirectionsViewModel.Cards(directionRepository.CardList());
        }

        // GET: api/ApiDirections/5
        [HttpGet("{id}", Name = "Get")]
        public ApiDirectionsViewModel.DirectionCard Get(int id)
        {
            return new ApiDirectionsViewModel.DirectionCard(directionRepository.ListCard(id), "para retornar um endereço específico, passar o seguinte parametro na URL 'directionId'");
        }

        // POST: api/ApiDirections
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/ApiDirections/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using GerenciamentoTerritoriosJW.Core.Models;
using GerenciamentoTerritoriosJW.Core.Services;
using GerenciamentoTerritoriosJW.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public void Post([FromBody] Direction direction)
        {
            directionRepository.Insert(direction);
        }

        // PUT: api/ApiDirections/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Direction direction)
        {
            
            
            if (!directionRepository.Exists(id))
            {
                Response.StatusCode = 404;
            }

            try
            {
                directionRepository.Update(direction);
            }
            catch (DbUpdateConcurrencyException) when (!directionRepository.Exists(id))
            {
                Response.StatusCode = 404;
            }

            Response.StatusCode = 204;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

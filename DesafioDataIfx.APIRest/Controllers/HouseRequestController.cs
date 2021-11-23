using DesafioDataIfx.Core.Helpers.Utilites;
using DesafioDataIfx.Core.Interfaces;
using DesafioDataIfx.Core.ModelStructure.App;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioDataIfx.APIRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseRequestController : ControllerBase
    {
        private readonly IUnitRepository _unitRepo;
        public HouseRequestController(IUnitRepository repo) => this._unitRepo = repo;

        /// <summary>
        /// Obtiene la lista de casas disponibles
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetHouses() => Ok(await this._unitRepo.GetHouses());

        /// <summary>
        /// Obtiene la lista de casas disponibles
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetMyRequests")]
        public async Task<IActionResult> GetMyRequests(int id) => Ok(await this._unitRepo.GetMyRequest(id));

        /// <summary>
        /// Realiza una solicitud de usuario para unirse a una casa
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Apply(HouseRequest data)
        {
            data.HouseId = HouseHelper.GetHouseId(data.House);

            var result = await this._unitRepo.RegisterHouseRequest(data);
            
            return Ok(result);

        }       

        /// <summary>
        /// Actualiza una solicitud en espera
        /// </summary>
        /// <param name="data">información de la solicitud y id de la misma</param>
        /// <returns></returns>
        [HttpPatch]
        public async Task<IActionResult> Update(HouseUpdateRequest data)
        {
            if (data.HouseRequest == null || data.Request == 0)
                return BadRequest("Solicitúd inválida");

            data.HouseRequest.HouseId = HouseHelper.GetHouseId(data.HouseRequest.House);

            var result = await this._unitRepo.UpdateHouseRequest(data);

            return Ok(result);

        }

        /// <summary>
        /// Inactiva una solicitud en proceso
        /// </summary>
        /// <param name="data">datos necesarios para inactivar una solciitud</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(HouseDeleteRequest data)
        {
            if (data.IdUser == default || data.IdRequest == default)
                return BadRequest("Solicitúd inválida");

            var result = await this._unitRepo.UpdateHouseRequest(data);

            return Ok(result);

        }

        /// <summary>
        /// Cambia el estado a una solicitud únicamente si esta se encuentra en estado "En espera"
        /// </summary>
        /// <param name="data">Objeto con el IddRequest y el switch de aprobar/rechazar</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> ChageState(HouseChangeStateRequest data)
        {
            if (data.IdRequest == default)
                return BadRequest("Solicitúd inválida");

            var result = await this._unitRepo.ChageStateRequest(data);

            return Ok(result);

        }
    }
}

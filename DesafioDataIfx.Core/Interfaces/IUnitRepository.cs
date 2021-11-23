using DesafioDataIfx.Core.ModelStructure.App;
using DesafioDataIfx.Core.ModelStructure.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioDataIfx.Core.Interfaces
{
    /// <summary>
    /// Unificador de repositorios 
    // ! Se crea una única interfaz debido al tamaño del proyecto.
    /// </summary>
    public interface IUnitRepository
    {
        /// <summary>
        /// Registra una solicitud de usuario a una casa.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<HouseRequestResponse> RegisterHouseRequest(HouseRequest data);

        /// <summary>
        /// Obtiene un conteo de solicitudes del usuario a una casa específica.
        /// </summary>
        /// <returns></returns>
        Task<int> CountByHouseUser(int idUser, int idHouse);

        /// <summary>
        /// Actualiza una solicitud de usuario auna casa
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>

        Task<HouseRequestResponse> UpdateHouseRequest(HouseUpdateRequest data);

        /// <summary>
        /// Obtiene la lista de casas disponibles
        /// </summary>
        /// <returns></returns>
        Task<List<string>> GetHouses();

        /// <summary>
        /// Obtiene una lista de solicitudes realizadas por un usuario
        /// </summary>
        /// <returns></returns>
        Task<List<HouseInfoResponse>> GetMyRequest(int idUser);

        /// <summary>
        /// Actualiza una solicitud de usuario auna casa
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>

        Task<HouseRequestResponse> UpdateHouseRequest(HouseDeleteRequest data);

        /// <summary>
        /// Cambia el estado a una solicitud únicamente si esta se encuentra en estado "En espera"
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>

        Task<HouseRequestResponse> ChageStateRequest(HouseChangeStateRequest data);

    }
}

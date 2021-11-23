using DesafioDataIfx.Core.Interfaces;
using DesafioDataIfx.Core.ModelStructure.App;
using DesafioDataIfx.Core.ModelStructure.Dictionaries;
using DesafioDataIfx.Core.ModelStructure.Dto;
using DesafioDataIfx.Infraestructure.Providers.SqlServer.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioDataIfx.Infraestructure.Providers.SqlServer.Services
{
    public class UnitRepository : IUnitRepository
    {
        public readonly HogwardsDataIfxContext _context;

        public UnitRepository(HogwardsDataIfxContext context)
        {
            this._context = context;
        }
        public async Task<int> CountByHouseUser(int idUser, int idHouse)
        {
            return await this._context.Tra_HouseRequest
                                    .Where(x => x.hre_Identification == idUser && x.hre_IdHouseFk == (int)idHouse
                                           && x.hre_IdStateFk == (int)EnumRequestStates.EnEspera && x.hre_Status)
                                    .CountAsync();
        }

        public async Task<List<string>> GetHouses() => await this._context.Dic_Houses.Where(x => x.hou_Status).Select(x => x.hou_Name).ToListAsync();


        public async Task<List<HouseInfoResponse>> GetMyRequest(int idUser) => await this._context.Tra_HouseRequest.Where(x => x.hre_Status && x.hre_Identification == idUser)
                                                       .Select(x => new HouseInfoResponse()
                                                       {
                                                           House = x.hre_IdHouseFkNavigation.hou_Name,
                                                           Age = x.hre_Age,
                                                           Id = x.hre_Identification,
                                                           IdRequest = x.hre_Id,
                                                           LastName = x.hre_LastName,
                                                           Name = x.hre_Name,
                                                           State = x.hre_IdStateFkNavigation.sta_Name,
                                                           RequestDate = x.hre_CreationDate
                                                       }).ToListAsync();


        public async Task<HouseRequestResponse> RegisterHouseRequest(HouseRequest data)
        {
            try
            {

                if (await this.CountByHouseUser(data.Id, data.HouseId) > 0)
                    return this.SetCommonResponse(false, "El usuario ya tiene solicitudes en espera a esta casa");

                // TODO: Si el proyecto escala puede usarse automapper
                var entity = new Tra_HouseRequest()
                {
                    hre_Identification = data.Id,
                    hre_Status = true,
                    hre_Age = data.Age,
                    hre_CreationDate = DateTime.Now,
                    hre_IdHouseFk = data.HouseId,
                    hre_Name = data.Name,
                    hre_LastName = data.LastName,
                    hre_IdStateFk = (int)EnumRequestStates.EnEspera
                };
                this._context.Tra_HouseRequest.Add(entity);

                if (await this._context.SaveChangesAsync() == 0)
                    return this.SetCommonResponse(false, "Error inesperado, por favor intente en otro momento.");
                else
                    return this.SetCommonResponse(true, "Solicitud realizada satisfactoriamente", entity.hre_Id);

            }
            catch (Exception e)
            {
                return this.SetCommonResponse(false, $"Ocurrió un error, por favor intente en otro momento. | {e.Message}");
            }
        }

        public async Task<HouseRequestResponse> UpdateHouseRequest(HouseUpdateRequest houseRequest)
        {
            var data = houseRequest.HouseRequest;

            var searchRequest = await this._context.Tra_HouseRequest
                                     .Where(x => x.hre_Id == houseRequest.Request && x.hre_Status && x.hre_IdStateFk == (int)EnumRequestStates.EnEspera && x.hre_Identification == data.Id)
                                     .FirstOrDefaultAsync();

            if (searchRequest == null)
                return this.SetCommonResponse(false, $"La solicitud {houseRequest.Request} no es válida o ya ha sido finalizada.");

            searchRequest.hre_Age = data.Age;
            searchRequest.hre_IdHouseFk = data.HouseId;
            searchRequest.hre_Name = data.Name;
            searchRequest.hre_LastName = data.LastName;

            if (await this._context.SaveChangesAsync() == 0)
                return this.SetCommonResponse(false, "Error inesperado, por favor intente en otro momento.");

            return this.SetCommonResponse(true, "Solicitud realizada satisfactoriamente", searchRequest.hre_Id);

        }

        public async Task<HouseRequestResponse> UpdateHouseRequest(HouseDeleteRequest data)
        {
            // Por seguridad se valida si está asociada al usuario del request
            var searchRequest = await this._context.Tra_HouseRequest
                                     .Where(x => x.hre_Id == data.IdRequest && x.hre_Status && x.hre_Identification == data.IdUser)
                                     .FirstOrDefaultAsync();

            if (searchRequest == null)
                return this.SetCommonResponse(false, $"La solicitud [{data.IdRequest}] no es válida ");

            searchRequest.hre_Status = false;

            if (await this._context.SaveChangesAsync() == 0)
                return this.SetCommonResponse(false, "Error inesperado, por favor intente en otro momento.");

            return this.SetCommonResponse(true, "Solicitud realizada satisfactoriamente", searchRequest.hre_Id);
        }

        public async Task<HouseRequestResponse> ChageStateRequest(HouseChangeStateRequest data)
        {
            var searchRequest = await this._context.Tra_HouseRequest
                                     .Where(x => x.hre_Id == data.IdRequest && x.hre_Status && x.hre_IdStateFk == (int) EnumRequestStates.EnEspera)
                                     .FirstOrDefaultAsync();

            if (searchRequest == null)
                return this.SetCommonResponse(false, $"La solicitud [{data.IdRequest}] no es válida o ya ha sido gestionada");

            searchRequest.hre_IdStateFk = (data.Accept) ? (int) EnumRequestStates.Aceptado : (int) EnumRequestStates.Rechazado;

            if (await this._context.SaveChangesAsync() == 0)
                return this.SetCommonResponse(false, "Error inesperado, por favor intente en otro momento.");

            return this.SetCommonResponse(true, "Solicitud realizada satisfactoriamente", searchRequest.hre_Id);
        }

        private HouseRequestResponse SetCommonResponse(bool success, string message, int request = 0) =>
            new HouseRequestResponse
            {
                Message = message,
                Success = success,
                RequestId = request
            };

     

    }
}

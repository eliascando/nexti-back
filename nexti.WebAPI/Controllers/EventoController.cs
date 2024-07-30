using System.Net;
using Microsoft.AspNetCore.Mvc;
using nexti.Domain.DTOs;
using nexti.Domain.Interfaces.Service;
using nexti.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace nexti.WebAPI.Controllers
{
    [Route("api/evento")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IEventoService<Evento, EventoDTO, NewEventoDTO, CreatedEventoDTO, UpdateEventoDTO> _serv;

        public EventoController(IEventoService<Evento, EventoDTO, NewEventoDTO, CreatedEventoDTO, UpdateEventoDTO> serv)
        {
            _serv = serv;
        }

        // POST: api/evento/nuevo
        [HttpPost("nuevo")]
        public ApiResponse<CreatedEventoDTO> Post([FromBody] NewEventoDTO entity) 
        {
            try
            {
                var res = _serv.Add(entity);

                if (res == null)
                {
                    return ApiResponse<CreatedEventoDTO>
                        .ErrorResponse("Error al registrar!", HttpStatusCode.NotFound);
                }

                return ApiResponse<CreatedEventoDTO>.SuccessResponse(res);
            }
            catch (Exception ex)
            {
                return ApiResponse<CreatedEventoDTO>
                    .ErrorResponse(ex.Message, HttpStatusCode.InternalServerError);
            }
        }

        // GET: api/evento/all
        [HttpGet("all")]
        public ApiResponse<IEnumerable<EventoDTO>> GetAll()
        {
            try
            {
                var response = _serv.GetAll();

                if (response == null)
                {
                    return ApiResponse<IEnumerable<EventoDTO>>
                        .ErrorResponse("No hay registros!", HttpStatusCode.NotFound);
                }

                return ApiResponse<IEnumerable<EventoDTO>>
                    .SuccessResponse(response);
            }
            catch(Exception ex)
            {
                return ApiResponse<IEnumerable<EventoDTO>>
                    .ErrorResponse(ex.Message, HttpStatusCode.InternalServerError);
            }
        }

        // GET: api/evento/id/{id}
        [HttpGet("id/{id}")]
        public ApiResponse<EventoDTO> GetId(long id)
        {
            try
            {
                var response = _serv.GetById(id);

                if (response == null)
                {
                    return ApiResponse<EventoDTO>
                        .ErrorResponse("No hay registros!", HttpStatusCode.NotFound);
                }

                return ApiResponse<EventoDTO>
                    .SuccessResponse(response);
            }
            catch (Exception ex)
            {
                return ApiResponse<EventoDTO>
                    .ErrorResponse(ex.Message, HttpStatusCode.InternalServerError);
            }
        }

        // GET: api/evento/userId/{id}
        [HttpGet("userId/{id}")]
        public ApiResponse<IEnumerable<EventoDTO>> GetUserId(long id)
        {
            try
            {
                var response = _serv.GetByUser(id);

                if (response == null)
                {
                    return ApiResponse<IEnumerable<EventoDTO>>
                        .ErrorResponse("No hay registros!", HttpStatusCode.NotFound);
                }

                return ApiResponse<IEnumerable<EventoDTO>>
                    .SuccessResponse(response);
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<EventoDTO>>
                    .ErrorResponse(ex.Message, HttpStatusCode.InternalServerError);
            }
        }

        // POST: api/evento/actualizar/{id}
        [HttpPut("actualizar/{id}")]
        public ApiResponse<EventoDTO> Put([FromBody] UpdateEventoDTO entity, long id)
        {
            try
            {
                var res = _serv.Update(entity, id);

                if (res == null)
                {
                    return ApiResponse<EventoDTO>
                        .ErrorResponse("Error al registrar!", HttpStatusCode.NotFound);
                }

                return ApiResponse<EventoDTO>.SuccessResponse(res);
            }
            catch (Exception ex)
            {
                return ApiResponse<EventoDTO>
                    .ErrorResponse(ex.Message, HttpStatusCode.InternalServerError);
            }
        }

        // DELETE : api/evento/delete/{id}/{idUser}
        [HttpDelete("{id}/{idUser}")]
        public ApiResponse<bool> Delete(long id, long idUser)
        {
            try
            {
                var res = _serv.Delete(id, idUser);

                if (!res)
                {
                    return ApiResponse<bool>
                        .ErrorResponse("Error al eliminar!", HttpStatusCode.Conflict);
                }

                return ApiResponse<bool>.SuccessResponse(res);
            }
            catch(Exception ex)
            {
                return ApiResponse<bool>
                    .ErrorResponse(ex.Message, HttpStatusCode.InternalServerError);
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using nexti.Domain.DTOs;
using nexti.Domain.Interfaces.Service;
using nexti.Domain.Models;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace nexti.WebAPI.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService<Usuario, UsuarioDTO, NewUserDTO, CreatedUserDTO, UpdateUserDTO> _serv;

        public UsuarioController(IUsuarioService<Usuario, UsuarioDTO, NewUserDTO, CreatedUserDTO, UpdateUserDTO> serv)
        {
            _serv = serv;
        }

        [HttpPost("registro")]
        public ApiResponse<CreatedUserDTO> Post([FromBody] NewUserDTO usuario)
        {
            try
            {
                var res = _serv.Add(usuario);

                if (res == null) return ApiResponse<CreatedUserDTO>.ErrorResponse("Error al crear usuario!");

                return ApiResponse<CreatedUserDTO>.SuccessResponse(res);
            }
            catch (Exception ex)
            {
                return ApiResponse<CreatedUserDTO>.ErrorResponse($"{ex.Message}", HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost("/api/login")]
        public ApiResponse<UsuarioDTO> Post([FromBody] LoginDTO login)
        {
            try
            {
                var res = _serv.Login(login.Correo, login.Clave);

                if (res == null) return ApiResponse<UsuarioDTO>.ErrorResponse("Error al iniciar sesión!");

                return ApiResponse<UsuarioDTO>.SuccessResponse(res);
            }
            catch (Exception ex)
            {
                return ApiResponse<UsuarioDTO>.ErrorResponse($"{ex.Message}", HttpStatusCode.InternalServerError);
            }
        }
    }
}

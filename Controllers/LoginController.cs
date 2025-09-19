using SchoolAttendance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SchoolAttendance.Registration_Login.Login;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SchoolAttendance.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration config;
        private readonly LoginService loginService;

        public LoginController(LoginService loginService, IConfiguration config)
        {
            this.config = config;
            this.loginService = loginService;
        }

        [HttpPost("studentlogin")]
        public ActionResult StudentLogin([FromBody] StudentLoginRequest request)
        {
            var response = loginService.Login(request.MatricNumber, request.Password, "student");
            if (response.StatusCode == StatusCodes.Status401Unauthorized)
                return Unauthorized(response.ErrorMessage);

            return Ok(response.Result);
        }

        [HttpPost("lecturerlogin")]
        public ActionResult LecturerLogin([FromBody] LecturerLoginRequest request)
        {
            var response = loginService.Login(request.Email, request.Password, "lecturer");
            if (response.StatusCode == StatusCodes.Status401Unauthorized)
                return Unauthorized(response.ErrorMessage);

            return Ok(response.Result);
        }
    }
}



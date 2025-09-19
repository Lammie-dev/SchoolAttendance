using SchoolAttendance;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class LoginService
{
    private readonly DatabaseOperation context;
    private readonly IConfiguration config;

    public LoginService(DatabaseOperation context, IConfiguration config)
    {
        this.context = context;
        this.config = config;
    }

    public ActionResponse Login(string username, string password, string role)
    {
        if (role.ToLower() == "student")
        {
            //  Find student by matric number
            var student = context.Students.FirstOrDefault(s => s.MatricNumber == username);

            if (student == null || password != "1234") // Replace with proper password check
            {
                return new ActionResponse
                {
                    StatusCode = StatusCodes.Status401Unauthorized,
                    ErrorMessage = "Invalid matric number or password."
                };
            }

            //  Create claims with StudentId (Guid)
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, student.StudentId.ToString()),
                new Claim(ClaimTypes.Role, "student")
            };

            var token = GenerateJwtToken(claims);
            return new ActionResponse { Result = new { token } };
        }
        else if (role.ToLower() == "lecturer")
        {
            //  Find lecturer by email
            var lecturer = context.Staff.FirstOrDefault(s => s.Email == username);

            if (lecturer == null || password != "1234") // Replace with proper password check
            {
                return new ActionResponse
                {
                    StatusCode = StatusCodes.Status401Unauthorized,
                    ErrorMessage = "Invalid email or password."
                };
            }

            // Create claims with LecturerId (Guid)
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, lecturer.Id.ToString()),
                new Claim(ClaimTypes.Role, "lecturer")
            };

            var token = GenerateJwtToken(claims);
            return new ActionResponse { Result = new { token } };
        }

        return new ActionResponse
        {
            StatusCode = StatusCodes.Status400BadRequest,
            ErrorMessage = "Invalid role."
        };
    }

    private string GenerateJwtToken(Claim[] claims)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: config["Jwt:Issuer"],
            audience: config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

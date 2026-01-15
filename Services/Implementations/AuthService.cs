using ERP.Models;
using ERP.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using ERP.DTOs;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using ERP.Data;
using Microsoft.EntityFrameworkCore.Internal;

namespace ERP.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _context;

        public AuthService(
            UserManager<User> userManager,
            IConfiguration configuration,
            AppDbContext context
            )
        {
           _userManager = userManager;
           _configuration = configuration;
           _context = context;
        }

        public async Task<bool> CreateUserAsync(CreateUserDTO createUserDTO)
        {
            var user = new User
            {   
                UserName = createUserDTO.Username,
                Email = createUserDTO.Email,
                FullName = createUserDTO.FullName,
                //EmployeeId = createUserDTO.EmployeeId, use function to generate employee id
                Birthday = createUserDTO.Birthday,
                Educational = createUserDTO.Educational,
                Address = createUserDTO.Address,
                BasicSalary = createUserDTO.BasicSalary,
                Allowance = createUserDTO.Allowance,
                Insurance = createUserDTO.Insurance,
                StartDate = createUserDTO.StartDate,
                DepartmentId = createUserDTO.DepartmentId
            };
            var result = await _userManager.CreateAsync(user, createUserDTO.Password);
            return result.Succeeded;
        }


        public string GenerateToken(User user)
        {
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("fullname", user.FullName),
                new Claim("departmentId", user.DepartmentId.ToString())
            };
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:DurationInMinutes"])),
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<string> LoginAsync(LoginDTO loginDTO) 
        {
            var user = await _userManager.FindByNameAsync(loginDTO.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, loginDTO.Password))
            {
                return GenerateToken(user);
            }
            return ("Invalid username or password");
        }


        public async Task<string> GenerateEmployeeId(Guid DepartmentId)
        {
            var departmentAv = await _context.Departments
                .Where(d => d.Id == DepartmentId)
                .Select(d => d.Abbreviation)
                .FirstOrDefaultAsync();

            var year = DateTime.Now.Year.ToString();

            var count = await _userManager.Users.CountAsync();
            var nextID = count + 1;

            return $"{departmentAv}{year}{nextID.ToString().PadLeft(4, '0')}";
             
        }
    }
}

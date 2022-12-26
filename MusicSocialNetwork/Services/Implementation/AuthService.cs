using AutoMapper;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MusicSocialNetwork.Common;
using MusicSocialNetwork.Dto.Auth;
using MusicSocialNetwork.Dto.Person;
using MusicSocialNetwork.Entities;
using MusicSocialNetwork.Repository.Interfaces;
using MusicSocialNetwork.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using BC = BCrypt.Net.BCrypt;

namespace MusicSocialNetwork.Services.Implementation;

public class AuthService : IAuthService
{
    private readonly IPersonRepository _personRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IMapper _mapper;
    private readonly AuthOptions _authOptions;

    public AuthService(
        IPersonRepository personRepository,
        IRoleRepository roleRepository,
        IMapper mapper,
        IOptions<AuthOptions> authOptions)
    {
        _personRepository = personRepository;
        _roleRepository = roleRepository;
        _mapper = mapper;
        _authOptions = authOptions.Value;
    }

    public async Task<OperationResult<AuthResponse>> AuthenticateAsync(AuthRequest request)
    {
        var person = await _personRepository.GetByLogin(request.Login);

        if (person is null)
            return OperationResult<AuthResponse>.Fail(
                OperationCode.Error,
                $"Пользователь с логином {request.Login} не найден");

        if (BC.Verify(request.Password, person.Password))
        {
            var token = await GenerateJwtTokenAsync(person);

            var response = new AuthResponse
            {
                Person = _mapper.Map<PersonResponse>(person),
                Token = token
            };

            return new OperationResult<AuthResponse>(response);
        }

        return OperationResult<AuthResponse>.Fail(OperationCode.Error, "Неверный пароль");
    }


    public async Task<OperationResult<int>> RegistrationAsync(RegistrationRequest request)
    {
        if (await _personRepository.GetByLogin(request.Login) is not null)
            return OperationResult<int>.Fail(
                OperationCode.AlreadyExists,
                $"Пользователь с логином {request.Login} уже существует");

        var person = _mapper.Map<Person>(request);

        person.Password = BC.HashPassword(request.Password);
        person.RoleId = 1;

        var createdId = await _personRepository.CreateAsync(person);

        return new OperationResult<int>(createdId);
    }

    public bool IsPersonId(string jwt, int personId)
    {
        return GetPersonId(jwt) == personId;
    }

    private int GetPersonId(string jwt)
    {
        var token = GetJwtToken(jwt);

        var personId = Convert.ToInt32(
                token.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid)?.Value);

        return personId;
    }

    private async Task<string> GenerateJwtTokenAsync(Person person)
    {
        var securityKey = _authOptions.GetSymmetricSecurityKey();

        var globalRole = await _roleRepository.GetByIdAsync(person.RoleId);

        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Sid, person.Id.ToString()),
            new Claim(ClaimTypes.Role, globalRole!.Title)
        };

        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(_authOptions.Issuer,
            _authOptions.Audience,
            claims,
            signingCredentials: credentials,
            expires: DateTime.UtcNow.AddDays(_authOptions.TokenLifeTime));

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private JwtSecurityToken GetJwtToken(string jwt)
    {
        var handler = new JwtSecurityTokenHandler();

        jwt = jwt.Replace("Bearer ", "");
        var token = (JwtSecurityToken)handler.ReadToken(jwt);

        return token;
    }
}


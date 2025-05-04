using SimpleWMS.Domain.Entities;

namespace SimpleWMS.Application.Abstractions;

public interface IJwtTokenService
{ 
    string Generate(User user);
}
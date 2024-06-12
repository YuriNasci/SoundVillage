using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using SoundVillage.STS.Data;
using System.Security.Claims;

namespace SoundVillage.STS.ProfileService
{
    public class ProfileService: IProfileService
    {
        private readonly IIdentityRepository _repository;

        public ProfileService(IIdentityRepository repository)
        {
            _repository = repository;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var id = context.Subject.GetSubjectId();

            var user = await this._repository.FindByIdAsync(new Guid(id));

            var claims = new List<Claim>()
            {
                new Claim("iss", "SoundVillage.STS"),
                new Claim("name", user.Nome),
                new Claim("email", user.Email),
                new Claim("role", "soundvillage-user")
            };

            context.IssuedClaims = claims;
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
            return Task.CompletedTask;
        }
    }
}

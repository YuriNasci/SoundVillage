﻿using IdentityModel;
using IdentityServer4.Validation;
using SoundVillage.STS.Data;
using System.Security.Cryptography;
using System.Text;

namespace SoundVillage.STS.GrantType
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly IIdentityRepository repository;

        public ResourceOwnerPasswordValidator(IIdentityRepository repository)
        {
            this.repository = repository;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var password = context.Password;
            var email = context.UserName;

            var user = await this.repository.FindByEmailAndPasswordAsync(email, HashSHA256(password));
            if (user != null) {
                context.Result = new GrantValidationResult(user.Id.ToString(), OidcConstants.AuthenticationMethods.Password);
            }
        }

        public string HashSHA256(string plainText)
        {
            SHA256 criptoProvider = SHA256.Create();

            byte[] btexto = Encoding.UTF8.GetBytes(plainText);

            var criptoResult = criptoProvider.ComputeHash(btexto);

            return Convert.ToHexString(criptoResult);
        }
    }
}

using Microsoft.AspNet.Identity;

namespace MyFishEye.Authentication
{
    public class CustomPasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            return password;
        }

        public PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            if (providedPassword.Equals(hashedPassword)) return PasswordVerificationResult.Success;
            return PasswordVerificationResult.Failed;
        }
    }
}

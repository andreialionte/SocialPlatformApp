namespace SocialPlatformApp.Repos
{
    public class BcryptBetterAlternative
    {


        /* using Microsoft.EntityFrameworkCore;
 using SocialPlatformApp.Models.Dtos;
 using SocialPlatformApp.Models.Models;
 using SocialPlatformApp.Repos.DataLayer;
 using SocialPlatformApp.Repos.Interfaces;

 namespace SocialPlatformApp.Repos.Repositories
     {
         public class AuthRepository : IAuthRepository
         {
             private readonly DataContext _context;

             public AuthRepository(DataContext context)
             {
                 _context = context;
             }

             public async Task<object> LoginRepo(UserForLoginDto user)
             {
                 var userByEmail = await _context.Auths
                     .FirstOrDefaultAsync(u => u.Email == user.Email);


                 if (userByEmail == null)
                 {
                     throw new Exception("The user doesn't exist");
                 }

                 var isPasswordValid = BCrypt.Net.BCrypt.Verify(user.Password, userByEmail.PasswordHash);

                 if (!isPasswordValid)
                 {
                     throw new Exception("Invalid password");
                 }

                 return new { Message = "Loggin Successfuly!" };
             }

             public async Task<object> RegisterRepo(UserForRegistrationDto user)
             {
                 if (user.Password != user.ConfirmPassword)
                 {
                     throw new Exception("Passwords must match!");
                 }
                 //we should add to send email after email creation 

                 var checkIfEmailExists = await _context.Users.FirstOrDefaultAsync(u => u.Username == user.UserName);
                 var checkIfUserNameExists = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);

                 if (checkIfUserNameExists != null || checkIfEmailExists != null)
                 {
                     throw new Exception("The user or email already exists!");
                 }


                 var saltpass = BCrypt.Net.BCrypt.GenerateSalt();
                 var hashedpass = BCrypt.Net.BCrypt.HashPassword(user.Password, saltpass);

                 var newUser = new User
                 {
                     Username = user.UserName,
                     Email = user.Email,
                     CreatedAt = DateTime.UtcNow,
                     LastUpdatedAt = DateTime.UtcNow,
                 };

                 var auth = new Auth
                 {
                     Email = user.Email,
                     PasswordSalt = saltpass,
                     PasswordHash = hashedpass,
                 };

                 _context.Auths.Add(auth);

                 await _context.SaveChangesAsync();

                 _context.Users.Add(newUser);

                 await _context.SaveChangesAsync();



                 return new { User = newUser, Auth = auth };
             }

             //add here forgot password and reset password 
             //for forgot password we neeed to recive and email
             //and for reset password we need to set the new emails
         }
     }

        */
    }


}

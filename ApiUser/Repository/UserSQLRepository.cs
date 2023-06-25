using ApiUser.DbContexts;
using ApiUser.Models;
using ApiUser.Exceptions;
using Microsoft.EntityFrameworkCore;
using ApiUser.DTOs;

namespace ApiUser.Repository
{
    public class UserSQLRepository : IUserRepository
    {
        private AppDbContext dbContext;

        public UserSQLRepository(AppDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }

        public async Task<ResponseDto> CreateUser(User user)
        {
            var anotherUser = await dbContext.Users.Where(u => u.UserName == user.UserName).FirstOrDefaultAsync();
            ResponseDto response = new ResponseDto();
            if (anotherUser == null)
            {
                this.dbContext.Users.Add(user);
                await this.dbContext.SaveChangesAsync();
                response.isError = false;
                response.statusCode = 201;
                response.message = "OK";
                response.data = user;
            }
            else
            {
                response.isError = false;
                response.statusCode = 409;
                response.message = "There's another user with that username";
                response.data = user;
            }
            return response;
        }

        public async Task<ResponseDto> DeleteUser(int id)
        {
            var result = await this.dbContext.Users.FirstOrDefaultAsync(user => user.UserId == id);
            ResponseDto response = new ResponseDto();
            if (result != null)
            {
                this.dbContext.Users.Remove(result);
                await this.dbContext.SaveChangesAsync();
                response.statusCode = 200;
                response.message = "OK";
                response.data = result;
            }
            else
            {
                response.statusCode = 409;
                response.message = "There's no user with that id";
                response.data = result;
            }
            return response;
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await dbContext.Users.Where(user => user.UserId == id).FirstOrDefaultAsync();
            if (user == null)
            {
                // throw new NotFoundException("user not found with id=" + id.ToString());
                throw new Exception("user not found with id=" + id.ToString());
            }
            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await this.dbContext.Users.ToListAsync();
        }

        public async Task<IEnumerable<User>> GetUsers(int page, int size)
        {
            return await this.dbContext.Users.Skip(page * size).Take(size).ToListAsync();
        }

        public async Task<ResponseDto> Login(string username, string password)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                var user = await dbContext.Users.Where(c => c.UserName == username && c.Password == password).FirstOrDefaultAsync();
                if (user == null)
                {
                    response.isError = false;
                    response.statusCode = 401;
                    response.message = "UserName or Password is incorrect";
                }
                else
                {
                    response.isError = false;
                    response.statusCode = 200;
                    response.message = "OK";
                }
                response.data = user;
            }catch(Exception ex)
            {
                response.isError = true;
                response.statusCode = 500;
                response.message = ex.Message;
                response.data = null;
            }
            
            return response;
        }

        public async Task<ResponseDto> UpdateUser(User user)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                this.dbContext.Users.Update(user);
                await this.dbContext.SaveChangesAsync();
                response.isError = false;
                response.statusCode = 200;
                response.message = "OK";
                response.data = user;
            }
            catch (Exception ex)
            {
                response.isError = true;
                response.statusCode = 500;
                response.message = ex.Message;
                response.data = null;
            }
            return response;
        }
    }
}

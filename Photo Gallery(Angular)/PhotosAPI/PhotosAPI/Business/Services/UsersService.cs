using PhotosAPI.Business.Automapper;
using PhotosAPI.Business.Interfaces;
using PhotosAPI.DAL.Entities;
using PhotosAPI.DAL.Interfaces;
using PhotosAPI.DTO.Auth;
using PhotosAPI.DTO.Jwt;
using PhotosAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotosAPI.BLL.Services
{
    public class UsersService: IUsersService
    {
        IUnitOfWork uow;
        MD5Service _md5Service;
        JwtService _jwtService;
        ObjectMapperBusiness objectManager = ObjectMapperBusiness.Instance;
        public UsersService(IUnitOfWork uow, MD5Service mD5Service, JwtService jwtService)
        {
            this.uow = uow;
            _md5Service = mD5Service;
            _jwtService = jwtService;
        }
        public async Task DeleteUser(int id)
        {
            var result = await uow.UsersRepository.Get(id);
            await uow.UsersRepository.Remove(result.Id);
            uow.Save();
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            return objectManager.Mapper.Map<List<UserDto>>(await uow.UsersRepository.GetAll());
        }

        public async Task<UserDto> Get(int id)
        {
            return objectManager.Mapper.Map<UserDto>(await uow.UsersRepository.Get(id));
        }

        public async Task UpdateUser(UserDto book)
        {
            var result = objectManager.Mapper.Map<User>(book);
            await uow.UsersRepository.Update(result);
            uow.Save();
        }

        public async Task AddUser(RegisterDto model)
        {
            var allUsers = await uow.UsersRepository.GetAll();
            var srchUser = allUsers.FirstOrDefault(u => u.Email.Equals(model.Email) && u.Password.Equals(_md5Service.Hash(model.Password)));
            if (srchUser is null)
            {
                var str = _md5Service.Hash(model.Password);
                var result = objectManager.Mapper.Map<User>(model);
                result.Password = str;
                await uow.UsersRepository.Create(result);
                uow.Save();
            }
            else
            {
                throw new Exception("User has already created!");
            }
        }

        public async Task<JwtResponse> Login(LoginDto model)
        {
            var allUsers = await uow.UsersRepository.GetAll();
            var srchUser = allUsers.FirstOrDefault(u => u.Email.Equals(model.Email) && u.Password.Equals(_md5Service.Hash(model.Password)));
            if (srchUser is null)
            {
                throw new Exception("User not found!");
            }
            else
            {
                return new JwtResponse { AccessToken = _jwtService.GenerateAccessToken(srchUser.Email, "user") };
            }
        }
    }
}

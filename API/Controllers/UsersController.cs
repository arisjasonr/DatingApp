using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using API.Interfaces;
using API.DTOs;
using AutoMapper;

namespace API.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper) 
        { 
            _userRepository = userRepository;
            _mapper = mapper;
        }

  
        //public ActionResult<IEnumerable<AppUser>> GetUsers() { return _context.Users.ToList(); }
        //public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers() => Ok(await _userRepository.GetUsersAsync());
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            var users =  await _userRepository.GetMembersAsync(); //await _userRepository.GetUsersAsync();
            //var usersToReturn = _mapper.Map<IEnumerable<MemberDto>>(users);
            return Ok(users);
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<MemberDto>> GetUser(string username) 
        {
            //var user =  await _userRepository.GetUserByUsernameAsync(username);
            //return _mapper.Map<MemberDto>(user);            
            return await _userRepository.GetMemberAsync(username);          

           
        } 

        //api/users/id

        //[HttpGet("{username}")]
        //public async Task<ActionResult<MemberDto>> GetUser(string username) => await _userRepository.GetUserByUsernameAsync(username);




        //private readonly DataContext _context;


        //public UsersController(DataContext context) { _context = context; }


        /*[HttpGet()]
        //public ActionResult<IEnumerable<AppUser>> GetUsers() { return _context.Users.ToList(); }
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers() => await _context.Users.ToListAsync(); 

        //api/users/id
        
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id) => await _context.Users.FindAsync(id);*/
    }
}

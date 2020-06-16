﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using RawMaterials.Data;
using RawMaterials.Models.DTO;
using RawMaterials.Models.Entities;
using RawMaterials.Models.IRepository;
using RawMaterials.Models.Repository;

namespace RawMaterials.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _userRepo;
        private readonly IMapper _mapper;
        private RawMaterialsContext _context;
        public UserController(IUserRepo userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
       
        }



        // GET: api/<UserController>
        [HttpGet("{id}")]
        //  [Authorize]
        public async Task<IActionResult> Get(long id)
        {
            var user = _userRepo.GetById(id);
            if (user == null) { return NotFound(); }
            else {
                var userMap = _mapper.Map<UserReadDto>(user.Result);
                return Ok(user.Result);  
                 }
        }

        // GET api/<UserController>/5
     //   [HttpGet("{id}")]
    /*    public UserReadDto Get(int id)
        {

            return "value";
        }*/

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] User user)
        {
            _userRepo.Add(user);
          
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            
          //  return await Ok(_userRepo.Remove());
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using AdvertApi.DTOs.Requests;
using AdvertApi.Exceptions;
using AdvertApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace AdvertApi.Controllers
{
    [Route("api/client")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private readonly IDbAdvertApiService _context;

        public ClientController(IDbAdvertApiService context)
        {
            _context = context;
        }



        [HttpPost("register")]
        public IActionResult RegisterClient(RegisterClientRequest request)
        {

            try
            {
                var result = _context.RegisterClient(request);
                return Ok(result);
            }
            catch (ClientIsAlreadyInDatabaseException exc)
            {
                return BadRequest(exc.Message);
            }
            catch(UserWithThisLoginAlreadyExistsException exc)
            {
                return BadRequest(exc.Message);
            }


        }

        [HttpPost("login")]
        public IActionResult LoginClient(LoginRequest request)
        {
            try
            {
                var result = _context.Login(request);
                return Ok(result);
            }catch(LoginIsIncorrectException exc)
            {
                return BadRequest(exc.Message);
            }catch(PasswordIsIncorrectException exc)
            {
                return BadRequest(exc.Message);
            }

        }


    }



}
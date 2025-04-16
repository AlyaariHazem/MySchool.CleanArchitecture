using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Backend.DTOS.School.Accounts;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using MySchool.Core.Interfaces;

namespace Backend.Controllers.School;

[ApiController]
[Route("api/[controller]")]
public class AccountsController : ControllerBase
{
    private readonly IAccountRepository _AccountRepository;
    private readonly IMapper _mapper;

    public AccountsController(IAccountRepository accountRepository, IMapper mapper)
    {
        _mapper = mapper;
        _AccountRepository = accountRepository;
    }

    // ✅ GET: api/accounts
    [HttpGet]
    public async Task<ActionResult<APIResponse>> GetAllAccounts()
    {
        var response = new APIResponse();
        try
        {
            var accounts = await _AccountRepository.GetAllAsync();
            response.Result = accounts;
            response.statusCode = HttpStatusCode.OK;
            return Ok(response);
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.statusCode = HttpStatusCode.InternalServerError;
            response.ErrorMasseges.Add(ex.Message);
            return StatusCode((int)HttpStatusCode.InternalServerError, response);
        }
    }

    // ✅ GET: api/accounts/{id}
    [HttpGet("{id:int}")]
    public async Task<ActionResult<APIResponse>> GetAccount(int id)
    {
        var response = new APIResponse();
        try
        {
            var account = await _AccountRepository.GetByIdAsync(id);
            if (account == null)
            {
                response.IsSuccess = false;
                response.statusCode = HttpStatusCode.NotFound;
                response.ErrorMasseges.Add($"Account with ID {id} not found.");
                return NotFound(response);
            }

            response.Result = account;
            response.statusCode = HttpStatusCode.OK;
            return Ok(response);
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.statusCode = HttpStatusCode.InternalServerError;
            response.ErrorMasseges.Add(ex.Message);
            return StatusCode((int)HttpStatusCode.InternalServerError, response);
        }
    }

    // ✅ POST: api/accounts
    [HttpPost]
    public async Task<ActionResult<APIResponse>> AddAccount([FromBody] AccountsDTO account)
    {
        var response = new APIResponse();
        try
        {
            var accountEntity = _mapper.Map<Accounts>(account);
            await _AccountRepository.AddAsync(accountEntity);
            response.Result = "Account successfully created.";
            response.statusCode = HttpStatusCode.Created;
            return StatusCode((int)HttpStatusCode.InternalServerError, response);
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.statusCode = HttpStatusCode.InternalServerError;
            response.ErrorMasseges.Add(ex.Message);
            return StatusCode((int)HttpStatusCode.InternalServerError, response);
        }
    }

    // ✅ PUT: api/accounts/{id}
    [HttpPut("{id:int}")]
    public async Task<ActionResult<APIResponse>> UpdateAccount(int id, [FromBody] AccountsDTO account)
    {
        var response = new APIResponse();
        try
        {
            if (id != account.AccountID)
            {
                response.IsSuccess = false;
                response.statusCode = HttpStatusCode.BadRequest;
                response.ErrorMasseges.Add("ID mismatch between URL and body data.");
                return BadRequest(response);
            }

            var accountExists = await _AccountRepository.GetByIdAsync(id);
            if (accountExists == null)
            {
                response.IsSuccess = false;
                response.statusCode = HttpStatusCode.NotFound;
                response.ErrorMasseges.Add($"Account with ID {id} not found.");
                return NotFound(response);
            }
            var accountEntity = _mapper.Map<Accounts>(account);
             _AccountRepository.Update(accountEntity);
            response.Result = account;
            response.statusCode = HttpStatusCode.OK;
            return Ok(response);
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.statusCode = HttpStatusCode.InternalServerError;
            response.ErrorMasseges.Add(ex.Message);
            return StatusCode((int)HttpStatusCode.InternalServerError, response);
        }
    }

    // ✅ DELETE: api/accounts/{id}
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<APIResponse>> DeleteAccount(int id)
    {
        var response = new APIResponse();
        try
        {
            var account = await _AccountRepository.GetByIdAsync(id);
            if (account == null)
            {
                response.IsSuccess = false;
                response.statusCode = HttpStatusCode.NotFound;
                response.ErrorMasseges.Add($"Account with ID {id} not found.");
                return NotFound(response);
            }

             _AccountRepository.Remove(account);
            response.Result = $"Account with ID {id} successfully deleted.";
            response.statusCode = HttpStatusCode.OK;
            return Ok(response);
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.statusCode = HttpStatusCode.InternalServerError;
            response.ErrorMasseges.Add(ex.Message);
            return StatusCode((int)HttpStatusCode.InternalServerError, response);
        }
    }
    // ✅ GET: api/accounts/studentAndAccountNames
    [HttpGet("studentAndAccountNames")]
    public async Task<ActionResult<APIResponse>> GetStudentAndAccountNames()
    {
        var response = new APIResponse();
        try
        {
            var studentAndAccountNames = await _AccountRepository.GetAllAsync();
            response.Result = studentAndAccountNames;
            response.statusCode = HttpStatusCode.OK;
            return Ok(response);
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.statusCode = HttpStatusCode.InternalServerError;
            response.ErrorMasseges.Add(ex.Message);
            return StatusCode((int)HttpStatusCode.InternalServerError, response);
        }
    }
}

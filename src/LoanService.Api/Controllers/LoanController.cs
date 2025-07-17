using LoanService.Api.Extensions;
using LoanService.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LoanService.Api.Messaging;
using LoanService.Application.Models.Loan.Requests;

namespace LoanService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoanController : ControllerBase
{
    private readonly ILoanService _loanService;
    private readonly IMessageQueueSender _messageQueueSender;
    public LoanController(ILoanService loanService, IMessageQueueSender messageQueueSender)
    {
        _loanService = loanService;
        _messageQueueSender = messageQueueSender;
    }

    [HttpPost]
    [Authorize(Roles = "Client")]
    public async Task<IActionResult> CreateLoan([FromBody] LoanCreateRequest request)
    {
        var userId = User.GetUserId();
        if (userId == null)
            return Unauthorized();
        var response = await _loanService.CreateLoanAsync(request, (int)userId);
        _messageQueueSender.SendLoanCreated(new LoanCreatedMessage
        {
            LoanId = response.Id,
        });
        return Ok(response);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Manager")]
    public async Task<IActionResult> EditLoan(int id, [FromBody] LoanEditRequest request)
    {
        var response = await _loanService.EditLoanAsync(id, request);
        return Ok(response);
    }

    [HttpPost("approve")]
    [Authorize(Roles = "Manager")]
    public async Task<IActionResult> MakeDecision([FromBody] LoanDecisionRequest request)
    {
        var userId = User.GetUserId();
        if (userId == null)
            return Unauthorized();

        var response = await _loanService.MakeDecisionAsync(request, userId.Value);
        return Ok(response);
    }

    [HttpGet]
    [Authorize(Roles = "Manager")]
    public async Task<IActionResult> GetSentLoans()
    {
        var response = await _loanService.GetSentLoansAsync();
        return Ok(response);
    }
} 
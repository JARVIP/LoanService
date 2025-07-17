namespace LoanService.Api.Messaging;

public interface IMessageQueueSender
{
    void SendLoanCreated(LoanCreatedMessage message);
} 
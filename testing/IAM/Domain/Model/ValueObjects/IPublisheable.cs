namespace testing.IAM.Domain.Model.ValueObjects;

public interface IPublisheable
{
    void SendToApproval();
    void SendToEdit();
    void ApproveAndLock();
    void Reject();
    void ReturnToEdit();
}
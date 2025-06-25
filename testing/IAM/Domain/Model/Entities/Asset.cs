using testing.IAM.Domain.Model.ValueObjects;

namespace testing.IAM.Domain.Model.Entities;

public partial class Asset(EAssetType assetType) : IPublisheable
{
    public int Id { get; private set; }
    public EAssetType Type { get; private set; } = assetType;
    public EPublishingStatus Status { get; private set; } = EPublishingStatus.Draft;
    
    public virtual bool Viewable => true;
    public virtual bool Readable => true;
    
    public void SendToApproval()
    {
        Status = EPublishingStatus.ReadyToApprove;
    }

    public void SendToEdit()
    {
        Status = EPublishingStatus.ReadyToEdit;
    }

    public void ApproveAndLock()
    {
        Status = EPublishingStatus.ApprovedAndLocked;
    }

    public void Reject()
    {
        Status = EPublishingStatus.Draft;
    }

    public void ReturnToEdit()
    {
        Status = EPublishingStatus.ReadyToEdit;
    }

    public virtual object GetAsset()
    {
        return string.Empty;
    }
}
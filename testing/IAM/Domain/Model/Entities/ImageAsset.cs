using testing.IAM.Domain.Model.ValueObjects;

namespace testing.IAM.Domain.Model.Entities;

public class ImageAsset : Asset
{
    public Uri? ImageUri { get;  }
    
    public override bool Viewable => true;
    public override bool Readable => false;
    
    public ImageAsset(string url) : base(EAssetType.Image)
    {
        ImageUri = new Uri(url);
    }

    public override string GetAsset()
    {
        return ImageUri != null ? ImageUri.AbsoluteUri : string.Empty;
    }
}
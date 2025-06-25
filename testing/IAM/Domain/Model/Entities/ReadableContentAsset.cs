using testing.IAM.Domain.Model.ValueObjects;

namespace testing.IAM.Domain.Model.Entities;

public class ReadableContentAsset : Asset
{
    public Uri? ReadableContentUri { get; }
    
    public override bool Readable => true;
    public override bool Viewable => true;
    
    public ReadableContentAsset(string content) : base(EAssetType.ReadableContent)
    {
        ReadableContentUri = new Uri(content);
    }

    public override string GetAsset()
    {
        return ReadableContentUri != null ? ReadableContentUri.AbsolutePath : string.Empty;
    }
    
}
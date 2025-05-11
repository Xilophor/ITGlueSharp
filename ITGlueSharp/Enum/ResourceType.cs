using System.Text.Json.Serialization;

namespace Xilophor.ITGlueSharp.Enum;

public enum ResourceType
{
    User,
    
    Checklist,
    
    [JsonStringEnumMemberName("Checklist Template")]
    ChecklistTemplate,
    
    Contact,
    
    Configuration,
    
    [JsonStringEnumMemberName("Datto Device")]
    DattoDevice,
    
    Document,
    
    [JsonStringEnumMemberName("Document Folder")]
    DocumentFolder,
    
    Domain,
    
    Location,
    
    Organization,
    
    Password,
    
    [JsonStringEnumMemberName("SSL Certificate")]
    SSLCertificate,
    
    [JsonStringEnumMemberName("Flexible Asset")]
    FlexibleAsset,
    
    Ticket
}

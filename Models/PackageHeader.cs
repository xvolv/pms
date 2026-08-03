namespace PackageApp.Models;

/// <summary>
/// Mirrors the "Package Header" master record (see the Package Header modal:
/// Code / Description / Article / Currency / Group / Type / Rate Appearance /
/// Sale Separate / Posting Rhythm / Calculate Rule / Formula / Remark).
/// </summary>
public class PackageHeader
{
    public string Code { get; set; } = "";
    public string Description { get; set; } = "";
    public string Article { get; set; } = "";
    public string Currency { get; set; } = "Birr";
    public string Group { get; set; } = "";
    public string Type { get; set; } = "";
    public string RateAppearance { get; set; } = "";
    public bool SaleSeparate { get; set; }
    public string PostingRhythm { get; set; } = "Post Every Night";
    public string CalculateRule { get; set; } = "Per Person";
    public string Formula { get; set; } = "";
    public string Remark { get; set; } = "";

    public PackageHeader Clone() => (PackageHeader)MemberwiseClone();
}

namespace HelperApp.Domain;

public class AppVersion
{
    public Guid Id { get; set; }

    /// <summary>
    ///     创建时间
    /// </summary>
    public virtual DateTime CreationTime { get; protected set; }

    /// <summary>
    ///     编号（唯一编号）
    /// </summary>
    public string? Code { get; set; }

    /// <summary>
    ///     产品名称
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    ///     版本号
    /// </summary>
    public string? Version { get; set; }

    /// <summary>
    ///     更新地址
    /// </summary>
    public string? Download { get; set; }

    /// <summary>
    ///     更新时间
    /// </summary>
    public DateTime? UpdateTime { get; set; }

    /// <summary>
    ///     更新内容
    /// </summary>
    public string? UpdateContent { get; set; }

    /// <summary>
    ///     是否强制更新
    /// </summary>
    public bool ForcedUpdating { get; set; }
}

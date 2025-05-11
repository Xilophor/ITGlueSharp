using System;
using System.Net;

namespace Xilophor.ITGlueSharp.Model;

/// <summary>
///     A user account for ITGlue.
/// </summary>
public struct User
{
    /// <summary>
    ///     The user's identifier.
    /// </summary>
    public long Id { get; set; }
    
    /// <summary>
    ///     The user's full name. Generated from <see cref="FirstName"/> and <see cref="LastName"/>.
    /// </summary>
    public string Name => $"{FirstName} {LastName}";
    
    /// <summary>
    ///     The user's first name.
    /// </summary>
    /// <remarks> Can be null. </remarks>
    public string? FirstName { get; set; }
    
    /// <summary>
    ///     The user's last name.
    /// </summary>
    /// <remarks> Can be null. </remarks>
    public string? LastName { get; set; }
    
    /// <summary>
    ///     The user's role name.
    /// </summary>
    /// <remarks> Cannot be modified. Can be null. </remarks>
    public string? RoleName { get; internal set; }
    
    /// <summary>
    ///     The user's role name.
    /// </summary>
    /// <remarks> Cannot be modified. </remarks>
    public string Email { get; internal set; }
    
    /// <summary>
    ///     The user's avatar image. See <see cref="Avatar">Xilophor.ITGlueSharp.Model.Avatar</see>.
    /// </summary>
    /// <remarks> Can be null. </remarks>
    public Avatar? Avatar { get; set; }
    
    /// <summary>
    ///     The DateTime the IT Glue invitation was sent to the user.
    /// </summary>
    public DateTime InvitationSentAt { get; internal set; }
    
    /// <summary>
    ///     The DateTime the IT Glue invitation was accepted.
    /// </summary>
    public DateTime InvitationAcceptedAt { get; internal set; }
    
    /// <summary>
    ///     The DateTime the user signed in at. Will equal <see cref="LastSignInAt"/> if not currently signed in.
    /// </summary>
    /// <remarks> Can be null. </remarks>
    public DateTime? CurrentSignInAt { get; internal set; }
    
    /// <summary>
    ///     The IP the user signed in from. Will equal <see cref="LastSignInIP"/> if not currently signed in.
    /// </summary>
    /// <remarks> Can be null. </remarks>
    public IPAddress? CurrentSignInIP { get; internal set; }
    
    /// <summary>
    ///     The DateTime the user last signed in at.
    /// </summary>
    /// <remarks> Can be null. </remarks>
    public DateTime? LastSignInAt { get; internal set; }
    
    /// <summary>
    ///     The IP the user last signed in from.
    /// </summary>
    /// <remarks> Can be null. </remarks>
    public IPAddress? LastSignInIP { get; internal set; }
    
    /// <summary>
    ///     The reputation of the user.
    /// </summary>
    public long Reputation { get; internal set; }
    
    /// <summary>
    ///     Whether the user has a MyGlue account or not.
    /// </summary>
    public bool MyGlue { get; internal set; }
    
    /// <summary>
    ///     The identifier of the user's MyGlue account.
    /// </summary>
    /// <remarks> Can be null. </remarks>
    public long? MyGlueAccountId { get; internal set; }
}
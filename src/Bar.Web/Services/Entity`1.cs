// Copyright (c) 2022, Olaf Kober <olaf.kober@outlook.com>

namespace Bar.Web.Services;


/// <summary>
///     This base class represents an Entity which has a unique Id.
/// </summary>
public abstract class Entity<TId>
{
    /// <summary>
    ///     Gets the Id of the Entity.
    /// </summary>
    public TId Id { get; }


    /// <summary>
    ///     Initializes a new instance.
    /// </summary>
    protected Entity(
        TId id
    )
    {
        Id = id;
    }
}

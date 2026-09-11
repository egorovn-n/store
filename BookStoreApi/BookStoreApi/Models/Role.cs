using BookStoreApi.Enums;

namespace BookStoreApi.Models;

/// <summary>
/// Роль пользователя.
/// </summary>
public class Role
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Наименование роли.
    /// </summary>
    public RolesEnum RolesName { get; set; }
}
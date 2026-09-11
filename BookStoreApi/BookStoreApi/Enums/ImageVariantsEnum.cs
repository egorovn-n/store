namespace BookStoreApi.Enums;

/// <summary>
/// Перечисление доступных вариантов картинок для выдачи.
/// </summary>
public enum ImageVariantsEnum
{
    /// <summary>
    /// Оригинальный формат картинки.
    /// </summary>
    Original,

    /// <summary>
    /// Миниатюра 200х200.
    /// </summary>
    Thumb200,

    /// <summary>
    /// Миниатюра 400х400.
    /// </summary>
    Thumb400,

    /// <summary>
    /// Миниатюра 800х800.
    /// </summary>
    Thumb800
}
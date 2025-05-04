namespace SimpleWMS.Domain.Enums;

/// <summary>
/// Enum статусов груза
/// </summary>
public enum CargoStatus
{
    Forming = 0, //Формируется на складе
    Collected = 1, //Собран, закрыт, готов к отправке
    Received = 2, // Получен на нашем складе
    Shipped = 3 // Отправлен с нашего склада на другой
}
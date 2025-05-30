// Производный класс Airplane
public class Airplane : AirVehicle
{
    public int PassengerCount { get; set; } // Количество пассажиров
    public int MaxRange { get; set; } // Максимальная дальность полёта

    public Airplane() : base()
    {
        PassengerCount = 0;
        MaxRange = 0;
    }

    // Переопределение метода Init
    public override void Init()
    {
        base.Init();
        Console.Write("Введите количество пассажиров: ");
        PassengerCount = ReadIntFromConsole("Количество пассажиров", 0, int.MaxValue);

        Console.Write("Введите максимальную дальность полёта: ");
        MaxRange = ReadIntFromConsole("Максимальная дальность полёта", 1, int.MaxValue);
    }

    // Переопределение метода ToString
    public override string ToString()
    {
        return $"{base.ToString()}, Пассажиры: {PassengerCount}, Дальность: {MaxRange} км";
    }
}
// Производный класс Helicopter
public class Helicopter : AirVehicle
{
    public int BladeCount { get; set; } // Количество лопастей винта

    public Helicopter() : base()
    {
        BladeCount = 0;
    }

    // Переопределение метода Init
    public override void Init()
    {
        base.Init();
        Console.Write("Введите количество лопастей винта: ");
        BladeCount = ReadIntFromConsole("Количество лопастей винта", 1, int.MaxValue);
    }

    // Переопределение метода ToString
    public override string ToString()
    {
        return $"{base.ToString()}, Лопасти: {BladeCount}";
    }
}
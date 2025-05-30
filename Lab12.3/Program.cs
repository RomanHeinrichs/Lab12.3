using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Создаем список объектов AirVehicle
        List<AirVehicle> vehicles = new List<AirVehicle>
        {
            new Airplane { Id = 1, Model = "Boeing 747", YearOfManufacture = 1990, EngineType = "Jet", CrewCount = 2, PassengerCount = 400, MaxRange = 10000 },
            new Helicopter { Id = 2, Model = "Apache", YearOfManufacture = 2000, EngineType = "Turbine", CrewCount = 1, BladeCount = 4 },
            new AirVehicle { Id = 3, Model = "Cessna", YearOfManufacture = 1980, EngineType = "Piston", CrewCount = 1 }
        };

        // Создаем дерево
        var tree = new BinaryTree<AirVehicle>();

        while (true)
        {
  
            Console.WriteLine("1. Создать идеально сбалансированное дерево");
            Console.WriteLine("2. Распечатать дерево по уровням");
            Console.WriteLine("3. Преобразовать в дерево поиска");
            Console.WriteLine("4. Удалить элемент по ID");
            Console.WriteLine("5. Найти минимальный элемент");
            Console.WriteLine("6. Очистить дерево");
            Console.WriteLine("7. Выход");

            Console.Write("Выберите действие: ");
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Неверный ввод. Попробуйте снова.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    tree.CreateBalancedTree(vehicles);
                    Console.WriteLine("Идеально сбалансированное дерево создано.");
                    break;

                case 2:
                    tree.PrintByLevels();
                    break;

                case 3:
                    var searchTree = new BinaryTree<AirVehicle>();
                    searchTree.CreateBalancedTree(new List<AirVehicle>(vehicles));
                    Console.WriteLine("Преобразованное дерево поиска:");
                    searchTree.PrintByLevels();
                    break;

                case 4:
                    Console.Write("Введите ID для удаления: ");
                    if (int.TryParse(Console.ReadLine(), out int idToRemove))
                    {
                        var vehicleToRemove = vehicles.Find(v => v.Id == idToRemove);
                        if (vehicleToRemove != null)
                        {
                            tree.Remove(vehicleToRemove);
                            Console.WriteLine($"Элемент с ID {idToRemove} удален.");
                        }
                        else
                        {
                            Console.WriteLine("Элемент не найден.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Неверный ввод.");
                    }
                    break;

                case 5:
                    try
                    {
                        Console.WriteLine($"Минимальный элемент: {tree.FindMinimum()}");
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case 6:
                    tree.Clear();
                    Console.WriteLine("Дерево очищено.");
                    break;

                case 7:
                    return;

                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }
        }
    }
}
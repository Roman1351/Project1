using System;
using System.Text.RegularExpressions;

namespace HorseApplication
{
    public class Horse
    { 
        private string _clique;
        private int _maximumHealthPoints;
        private int _currentHealthPoints;
        private int _age;
        private double _speed;
        private double _weight;
        private string _color;
        private int[] _coordinates = new int[4];

        public Horse() { } 

        public double CalculatePercentageHealth()
        {
            return ((double)_currentHealthPoints / (double)_maximumHealthPoints) * 100.0;
        }

        public override string ToString()
        {
            return $"Кличка: {_clique}\nМаксимальное здоровье: {_maximumHealthPoints}\nТекущее здоровье: {_currentHealthPoints}\nВозраст: {_age}\nСкорость: {_speed} км/ч\nВес: {_weight} кг\nЦвет: {_color}\nКоординаты: {string.Join(", ", _coordinates)}\n";
        }

        public string Clique
        {
            get => _clique;
            set
            {
                if (!Regex.IsMatch(value, "^[A-Za-z]+$"))
                    throw new ArgumentException("Кличка должна состоять только из букв");
                _clique = value;
            }
        }

        public int MaximumHealthPoints
        {
            get => _maximumHealthPoints;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Максимальное количество НР должно быть больше нуля");
                _maximumHealthPoints = value;
            }
        }

        public int CurrentHealthPoints
        {
            get => _currentHealthPoints;
            set
            {
                if (value < 0 || value > _maximumHealthPoints)
                    throw new ArgumentOutOfRangeException("Текущее количество НР должно быть в пределах от 0 до максимального");
                _currentHealthPoints = value;
            }
        }

        public int Age
        {
            get => _age;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Возраст должен быть больше нуля");
                _age = value;
            }
        }

        public double Speed
        {
            get => _speed;
            set
            {
                if (value <= 0.0)
                    throw new ArgumentOutOfRangeException("Скорость должна быть больше нуля");
                _speed = value;
            }
        }

        public double Weight
        {
            get => _weight;
            set
            {
                if (value <= 0.0)
                    throw new ArgumentOutOfRangeException("Вес должен быть больше нуля");
                _weight = value;
            }
        }

        public string Color
        {
            get => _color;
            set
            {
                if (!Regex.IsMatch(value, "^[A-Za-z]+$"))
                    throw new ArgumentException("Цвет должен состоять только из букв");
                _color = value;
            }
        }

        public int[] Coordinates
        {
            get => _coordinates;
            set
            {
                if (value.Length != 4)
                    throw new ArgumentException("Координаты должны быть массивом из 4 чисел");
                for (int i = 0; i < 4; i++)
                {
                    if (value[i] < 0)
                        throw new ArgumentOutOfRangeException("Координаты должны быть неотрицательными");
                }
                _coordinates = value;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Horse horse = new Horse();

            try
            {
                Console.Write("Введите кличку лошади (только буквы): ");
                horse.Clique = Console.ReadLine();

                Console.Write("Введите максимальное количество НР (больше 0): ");
                horse.MaximumHealthPoints = int.Parse(Console.ReadLine());

                Console.Write("Введите текущее количество НР (от 0 до максимального): ");
                horse.CurrentHealthPoints = int.Parse(Console.ReadLine());

                Console.Write("Введите возраст лошади (больше 0): ");
                horse.Age = int.Parse(Console.ReadLine());

                Console.Write("Введите скорость лошади (больше 0): ");
                horse.Speed = double.Parse(Console.ReadLine());

                Console.Write("Введите вес лошади (больше 0): ");
                horse.Weight = double.Parse(Console.ReadLine());

                Console.Write("Введите цвет лошади (только буквы): ");
                horse.Color = Console.ReadLine();

                Console.Write("Введите координаты (4 неотрицательных числа через пробел): ");
                string[] coordinatesStr = Console.ReadLine().Split(' ');
                if (coordinatesStr.Length != 4)
                    throw new ArgumentException("Необходимо ввести 4 координаты");
                int[] coordinates = new int[4];
                for (int i = 0; i < 4; i++)
                {
                    coordinates[i] = int.Parse(coordinatesStr[i]);
                }
                horse.Coordinates = coordinates;

                Console.WriteLine("\nИнформация о лошади:");
                Console.WriteLine(horse);
                Console.WriteLine($"Процент текущего здоровья: {horse.CalculatePercentageHealth():F2}%");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"\nОшибка: {ex.Message}");
            }
            catch (FormatException)
            {
                Console.WriteLine("\nОшибка: Неверный формат ввода данных.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("\nОшибка: Введенное число слишком большое.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nПроизошла непредвиденная ошибка: {ex.Message}");
            }

            Console.ReadKey();
        }
    }
}

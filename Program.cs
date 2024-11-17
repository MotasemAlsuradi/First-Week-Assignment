using static System.Formats.Asn1.AsnWriter;

namespace First_Week_Assignment
{
    class CarsStore
    {
        private string _storeName;
        private string _location;
        private string _owner;

        public string StoreName => _storeName;
        public string Location => _location;
        public string Owner => _owner;

        public CarsStore(string storeName, string location, string owner)
        {
            this._storeName = storeName;
            this._location = location;
            this._owner = owner;
        }

        public override string ToString()
        {
            return $"Store Name: {StoreName}\nLocation: {Location}\nOwner: {Owner}";
        }
    }

    class Car
    {
        private string _carName;
        private double _price;

        public string Name => _carName;
        public double Price => _price;

        public Car(string name, double price)
        {
            this._carName = name;
            this._price = price;
        }

        public override string ToString()
        {
            return $"Car Name: {Name}\nPrice: ${Price:F2}";
        }
    }

    class CarOnSale : Car
    {
        private double _discountPercent;
        private double _finalPrice;
        private double _CalculateFinalPrice()
        {
            return Price * (1 - DiscountPercent / 100);
        }

        public double DiscountPercent => _discountPercent;
        public double FinalPrice => _finalPrice;
        public CarOnSale(string name, double price, double discountPercent) : base(name, price)
        {
            this._discountPercent = discountPercent;
            this._finalPrice = _CalculateFinalPrice();
        }


        public override string ToString()
        {
            return $"Car Name: {Name}\nOriginal Price: ${Price:F2}\nDiscount: {DiscountPercent}%\nFinal Price: ${FinalPrice:F2}";
        }
    }

    internal class Program
    {
        // Exercise 2
        static double TryParseDouble(string input)
        {
            return double.TryParse(input, out double result) ? result : 0;
        }
        static string GetSquareRoot(double num)
        {
            if (num < 0)
                return "Undefined (negative value)";
            else
                return Math.Sqrt(num).ToString();  
        }
        static string PerformMathematicalOperations(string a, string b)
        {
            double num1, num2;
            string result = "\n--- Mathematical Operations ---\n";

            num1 = TryParseDouble(a);
            num2 = TryParseDouble(b);

            result += $"Addition (+): {num1 + num2}\n";
            result += $"Subtraction (-): {num1 - num2}\n";
            result += $"Multiplication (*): {num1 * num2}\n";

            result += num2 != 0
                ? $"Division (/): {num1 / num2}\n"
                : "Division (/): Undefined (division by zero)\n";

            result += $"Power (^): {Math.Pow(num1, num2)}\n";
            result += $"Square Root (√): a: {GetSquareRoot(num1)}, b: {GetSquareRoot(num2)}\n";

            return result;
        }
        
        static void Main(string[] args)
        {
            
            Console.Write("Enter the car store name: ");
            string storeName = Console.ReadLine();
            Console.Write("\nEnter the location of the store: ");
            string location = Console.ReadLine();
            Console.Write("\nEnter the owner of the store: ");
            string owner = Console.ReadLine();

            CarsStore carStore = new CarsStore(storeName, location, owner);

            Console.Write("\nEnter the name of the car: ");
            string carName = Console.ReadLine();
            Console.Write("\nEnter the price of the car: ");
            double price = double.Parse(Console.ReadLine());

            Car car = new Car(carName, price);

            
            Console.Write("\nEnter the discount percentage for the car: ");
            double discountPercent = double.Parse(Console.ReadLine());
            CarOnSale carOnSale = new CarOnSale(carName, price, discountPercent);

            // Displaying the results
            Console.WriteLine("\n--- Car Store Details ---");
            Console.WriteLine(carStore);
            Console.WriteLine("\n--- Car Details ---");
            Console.WriteLine(car);
            Console.WriteLine("\n--- Car On Sale Details ---");
            Console.WriteLine(carOnSale);
            /*-----------------------------------------------------------------------------------*/

            // Exercise 2
            Console.Write("\n\nEnter the first number: ");
            string num1 = Console.ReadLine();
            Console.Write("Enter the second number: ");
            string num2 = Console.ReadLine();

            
            Console.WriteLine(PerformMathematicalOperations(num1, num2));
        }
    }
}

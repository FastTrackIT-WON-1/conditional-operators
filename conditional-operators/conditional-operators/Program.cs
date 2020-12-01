using System;

namespace conditional_operators
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Bitewise AND - vs Conditional AND */
            bool a1 = ReturnBool("a1", false) & ReturnBool("a1", true);
            bool a2 = ReturnBool("a2", false) && ReturnBool("a2", true);
            Console.WriteLine($"a1={a1}");
            Console.WriteLine($"a2={a2}");

            /* Bitewise OR - vs Conditional OR */
            bool o1 = ReturnBool("o1", true) | ReturnBool("o1", false);
            bool o2 = ReturnBool("o2", true) || ReturnBool("o2", false);
            Console.WriteLine($"o1={o1}");
            Console.WriteLine($"o2={o2}");

            // -------------------------------------------------------------
            PrintSeparator();
            // -------------------------------------------------------------

            /* Shortcircuit plays a very important role in compound statements 
               like the check in PrintTotalNameLength function */
            Person p1 = null;
            PrintTotalNameLength(p1);

            Person p2 = new Person();
            PrintTotalNameLength(p2);

            Person p3 = new Person();
            p3.Name = "John Doe";
            PrintTotalNameLength(p3);

            // -------------------------------------------------------------
            PrintSeparator();
            // -------------------------------------------------------------

            /* Also shortcircuit plays a very important role in compound statements 
              like the check in VerifyInsideInterval or VerifyOutsideInterval function */
            VerifyInsideInterval(10, 0, 20);
            VerifyInsideInterval(10, 40, 50);
            VerifyInsideInterval(10, 0, 5);

            // -------------------------------------------------------------
            PrintSeparator();
            // -------------------------------------------------------------

            VerifyOutsideInterval(10, 0, 20);
            VerifyOutsideInterval(10, 40, 50);
            VerifyOutsideInterval(10, 0, 5);
        }

        static void PrintSeparator()
        {
            Console.WriteLine();
            Console.WriteLine(new string('-', 70));
            Console.WriteLine();
        }

        static bool ReturnBool(string label, bool value)
        {
            Console.WriteLine($"{label} > Invoked ReturnBool({value})");
            return value;
        }

        static void PrintTotalNameLength(Person p)
        {
            if ((p != null) && (p.Name != null))
            {
                string name = p.Name;
                Console.WriteLine($"'{name}' length is {name.Length}");
            }
            else
            {
                Console.WriteLine($"Person is null or name is null");
            }
        }

        static void VerifyInsideInterval(int a, int min, int max)
        {
            var isInside = ReturnBool($"VerifyInsideInterval: {a} >= {min}", a >= min) && 
                           ReturnBool($"VerifyInsideInterval: {a} <= {max}", a <= max);

            if (isInside)
            {
                Console.WriteLine($"{a} is INSIDE the interval [{min},{max}]");
            }
            else
            {
                Console.WriteLine($"{a} is outside the interval [{min},{max}]");
            }
        }

        static void VerifyOutsideInterval(int a, int min, int max)
        {
            var isOutside = ReturnBool($"VerifyOutsideInterval: {a} <= {min}", a <= min) || 
                            ReturnBool($"VerifyOutsideInterval: {a} >= {max}", a >= max);

            if (isOutside)
            {
                Console.WriteLine($"{a} is OUTSIDE the interval [{min},{max}]");
            }
            else
            {
                Console.WriteLine($"{a} is inside the interval [{min},{max}]");
            }
        }
    }
}

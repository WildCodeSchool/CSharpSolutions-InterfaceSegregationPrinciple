using System;

namespace S9___SOLID_Design_2___Interface_Segregation_Principle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    namespace Problem
    {
        // The student has to correct this ISP violation by splitting IDrivable into a smaller one
interface IDrivable
{
    void Drive(long miles);
    void LaunchRocket();
}

class Car : IDrivable
{
    public void Drive(long miles)
    {
        Console.WriteLine("I am driven to {0} miles away ...", miles);
    }

    public void LaunchRocket()
    {
        Console.WriteLine("I don't have any rocket to launch ...");
    }
}

class FlyingCar : IDrivable
{
    private bool _isRocketLaunched;

    public void Drive(long miles)
    {
        if (!_isRocketLaunched)
        {
            Console.WriteLine("Launch the rocket first or this flying car can not get driven.");
        }
        else
        {
            Console.WriteLine("I am flying to {0} miles away ...", miles);
        }
    }

    public void LaunchRocket()
    {
        _isRocketLaunched = true;
    }
}

class SpaceShip : IDrivable
{
    private bool _isRocketLaunched;

    public void Drive(long miles)
    {
        if (!_isRocketLaunched)
        {
            Console.WriteLine("Spaceship can't leave Earth without its rocket launched !");
        }
        else
        {
            Console.WriteLine("The spaceship is going {0} miles away", miles);
        }
    }

    public void LaunchRocket()
    {
        _isRocketLaunched = true;
    }
        }
    }

        namespace Solution
        {
        // The student has to correct this ISP violation by splitting into smaller interfaces
        interface IDrivable
        {
            void Drive(long miles);
        }

        interface IFlyable : IDrivable
        {
            void LaunchRocket();
        }

        class Car : IDrivable
        {
            public void Drive(long miles)
            {
                Console.WriteLine("I am driven to {0} miles away ...", miles);
            }
        }

        class FlyingCar : IFlyable
        {
            private bool _isRocketLaunched;

            public void Drive(long miles)
            {
                if (!_isRocketLaunched)
                {
                    Console.WriteLine("Launch the rocket first or this flying car can not get driven.");
                }
                else
                {
                    Console.WriteLine("I am flying to {0} miles away ...", miles);
                }
            }

            public void LaunchRocket()
            {
                _isRocketLaunched = true;
            }
        }

        class SpaceShip : IFlyable
        {
            private bool _isRocketLaunched;

            public void Drive(long miles)
            {
                if (!_isRocketLaunched)
                {
                    Console.WriteLine("Spaceship can't leave Earth without its rocket launched !");
                }
                else
                {
                    Console.WriteLine("The spaceship is going {0} miles away", miles);
                }
            }

            public void LaunchRocket()
            {
                _isRocketLaunched = true;
            }
        }
    }
}

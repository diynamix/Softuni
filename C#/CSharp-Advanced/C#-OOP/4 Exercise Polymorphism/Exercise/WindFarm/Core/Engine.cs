namespace WindFarm.Core
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using Exceptions;
    using Factories.Contracts;
    using Models.Contracts;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly IAnimalFactory animalFactory;
        private readonly IFoodFactory foodFactory;

        private readonly ICollection<IAnimal> animals;

        private Engine()
        {
            animals = new HashSet<IAnimal>();
        }

        public Engine(IReader reader, IWriter writer, IAnimalFactory animalFactory, IFoodFactory foodFactory) : this()
        {
            this.reader = reader;
            this.writer = writer;

            this.animalFactory = animalFactory;
            this.foodFactory = foodFactory;
        }

        public void Run()
        {
            string command;
            while ((command = reader.ReadLine()) != "End")
            {
                HandleInput(command);
            }

            PrintAllAnimals();
        }

        private IAnimal BuildAnimalUsingFactory(string command)
        {
            string[] cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            IAnimal animal = animalFactory.CreateAnimal(cmdArgs);
            return animal;
        }

        private IFood BuildFoodUsingFactory()
        {
            string[] foodArgs = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string foodType = foodArgs[0];
            int foodQuantity = int.Parse(foodArgs[1]);
            IFood food = foodFactory.CreateFood(foodType, foodQuantity);
            return food;
        }

        private void HandleInput(string command)
        {
            try
            {
                IAnimal animal = BuildAnimalUsingFactory(command);
                IFood food = BuildFoodUsingFactory();

                writer.WriteLine(animal.ProduceSound());
                animals.Add(animal);
                animal.Eat(food);

            }
            catch (InvalidAnimalTypeException iate)
            {
                writer.WriteLine(iate.Message);
            }
            catch (InvalidFoodTypeException ifte)
            {
                writer.WriteLine(ifte.Message);
            }
            catch (FoodNotEatenException fnee)
            {
                writer.WriteLine(fnee.Message);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void PrintAllAnimals()
        {
            foreach (IAnimal animal in animals)
            {
                writer.WriteLine(animal);
            }
        }
    }
}

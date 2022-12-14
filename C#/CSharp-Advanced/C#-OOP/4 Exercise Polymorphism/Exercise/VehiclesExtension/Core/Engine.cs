namespace Vehicles.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Exception;
    using Factories.Contracts;
    using IO.Contracts;
    using Models.Contracts;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IVehicleFactory vehicleFactory;

        private readonly ICollection<IVehicle> vehicles;
        //private IVehicle car;
        //private IVehicle truck;

        private Engine()
        {
            vehicles = new HashSet<IVehicle>();
        }

        public Engine(IReader reader, IWriter writer, IVehicleFactory vehicleFactory) : this()
        {
            this.reader = reader;
            this.writer = writer;
            this.vehicleFactory = vehicleFactory;
        }

        public void Run()
        {
            //car = BuilVehicleUsingFactory();
            //truck = BuilVehicleUsingFactory();
            
            vehicles.Add(BuilVehicleUsingFactory());
            vehicles.Add(BuilVehicleUsingFactory());
            vehicles.Add(BuilVehicleUsingFactory());

            int n = int.Parse(reader.ReadLine());

            for (int i = 0; i < n; i++)
            {
                try
                {
                    ProcessCommand();
                }
                catch (FuelOverloadException foe)
                {
                    writer.WriteLine(foe.Message);
                }
                catch (InsufficientFuelException ife)
                {
                    writer.WriteLine(ife.Message);
                }
                catch (InvalidVehicleTypeException ivte)
                {
                    writer.WriteLine(ivte.Message);
                }
                catch (NegativeFuelException nfe)
                {
                    writer.WriteLine(nfe.Message);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            PrintAllVehicles();
        }

        private IVehicle BuilVehicleUsingFactory()
        {
            string[] vehicleArgs = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string vehicleType = vehicleArgs[0];
            double vehicleFuelQuantity = double.Parse(vehicleArgs[1]);
            double vehicleFuelConsumption = double.Parse(vehicleArgs[2]);
            double vehicleTankCapacity = double.Parse(vehicleArgs[3]);

            IVehicle vehicle = vehicleFactory.CreateVehicle(vehicleType, vehicleFuelQuantity, vehicleFuelConsumption, vehicleTankCapacity);

            return vehicle;
        }

        private void ProcessCommand()
        {
            string[] cmdArgs = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string cmdType = cmdArgs[0];
            string vehicleType = cmdArgs[1];
            double arg = double.Parse(cmdArgs[2]);

            IVehicle vehicleToProccess = vehicles.FirstOrDefault(v => v.GetType().Name == vehicleType);

            if (vehicleToProccess == null)
            {
                throw new InvalidVehicleTypeException();
            }

            if (cmdType == "Drive")
            {
                writer.WriteLine(vehicleToProccess.Drive(arg));
            }
            else if (cmdType == "DriveEmpty" && vehicleType == "Bus")
            {
                writer.WriteLine(vehicleToProccess.DriveEmpty(arg));
            }
            else if (cmdType == "Refuel")
            {
                vehicleToProccess.Refuel(arg);
            }
        }

        private void PrintAllVehicles()
        {
            foreach (IVehicle vehicle in vehicles)
            {
                writer.WriteLine(vehicle.ToString());
            }
        }
    }
}

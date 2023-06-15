from abc import ABC, abstractmethod
# Abstract class for creating different types of transport
class TransportFactory(ABC):
    @abstractmethod
    def create_transport(self):
        pass
 
# Concrete factory for creating cargo ships
class CargoShipFactory(TransportFactory):
    def create_transport(self):
        return CargoShip()

# Concrete factory for creating passenger planes
class PassengerPlaneFactory(TransportFactory):
    def create_transport(self):
        return PassengerPlane()

# Concrete factory for creating trucks
class TruckFactory(TransportFactory):
    def create_transport(self):
        return Truck()

# Abstract class for different types of transport
class Transport(ABC):
    @abstractmethod
    def move(self):
        pass

# Concrete class for cargo ships
class CargoShip(Transport):
    def move(self):
        print("Грузовое судно плывет.")

# Concrete class for passenger planes
class PassengerPlane(Transport):
    def move(self):
        print("Пассажирский самолет взлетел.")

# Concrete class for trucks
class Truck(Transport):
    def move(self):
        print("Грузовик находится в движении.")
 
# Abstract class for different types of cargo
class Cargo(ABC):
    pass

# Concrete class for cargo
class CargoType(Cargo):
    pass

# Abstract class for different types of passengers
class Passenger(ABC):
    pass

# Concrete class for passengers
class PassengerType(Passenger):
    pass

# Concrete class for cargo ships carrying cargo
class CargoShipWithCargo(CargoShip):
    def __init__(self, cargo):
        self.cargo = cargo

# Concrete class for passenger planes carrying passengers
class PassengerPlaneWithPassengers(PassengerPlane):
    def __init__(self, passengers):
        self.passengers = passengers

# Concrete class for trucks carrying cargo
class TruckWithCargo(Truck):
    def __init__(self, cargo):
        self.cargo = cargo

# Create a cargo ship factory
cargo_ship_factory = CargoShipFactory()

# Create a cargo ship with cargo
cargo_type = CargoType()
cargo_ship = cargo_ship_factory.create_transport()
cargo_ship_with_cargo = CargoShipWithCargo(cargo_type)

print(type(cargo_ship_with_cargo))
cargo_ship_with_cargo.move()


# Create a passenger plane factory
passenger_plane_factory = PassengerPlaneFactory()

# Create a passenger plane with passengers
passenger_type = PassengerType()
passenger_plane = passenger_plane_factory.create_transport()
passenger_plane_with_passengers = PassengerPlaneWithPassengers(passenger_type)

print(type(passenger_plane_with_passengers))
passenger_plane_with_passengers.move()

# Create a truck factory
truck_factory = TruckFactory()

# Create a truck with cargo
truck = truck_factory.create_transport()
truck_with_cargo = TruckWithCargo(cargo_type)
print(type(truck_with_cargo))
truck_with_cargo.move()
 
class JetEngine:
    def __init__(self, force, fuel_consumption):
        self.force = force
        self.fuel_consumption = fuel_consumption

    def turn_on(self, seconds):
        fuel_burned = self.fuel_consumption * seconds
        return fuel_burned


class FuelTank:
    def __init__(self, tank_volume, remaining_fuel):
        self.tank_volume = tank_volume
        self.remaining_fuel = remaining_fuel

    def reduce_fuel(self, fuel_used):
        self.remaining_fuel -= fuel_used


class RocketFacade:
    def __init__(self, left_engine, right_engine, fuel_tank, mass, velocity=0):
        self.left_engine = left_engine
        self.right_engine = right_engine
        self.fuel_tank = fuel_tank
        self.mass = mass
        self.velocity = velocity

    def accelerate(self, target_speed):
        acceleration = (self.left_engine.force +
                        self.right_engine.force) / self.mass
        fuel_burned = self.left_engine.turn_on(
            1) + self.right_engine.turn_on(1)
        self.fuel_tank.reduce_fuel(fuel_burned)

        while self.velocity < target_speed and self.fuel_tank.remaining_fuel > 0:
            self.velocity += acceleration
            fuel_burned = self.left_engine.turn_on(
                1) + self.right_engine.turn_on(1)
            self.fuel_tank.reduce_fuel(fuel_burned)

        if self.fuel_tank.remaining_fuel == 0:
            print("У ракеты закончилось топливо!")


# Creation of a jet engine with a force of 1000 N and a fuel consumption of 5 kg/s
left_engine = JetEngine(1000, 5)
right_engine = JetEngine(1000, 5)

# Creation of a fuel tank with a volume of 100 kg and 50 kg of remaining fuel
fuel_tank = FuelTank(100, 50)

# Creation of a rocket body with two engines and a fuel tank, weighing 500 kg and an initial velocity of 0 m/s
rocket = RocketFacade(left_engine, right_engine, fuel_tank, 500, 0)

# Accelerate the rocket to a speed of 100 m/s
rocket.accelerate(100)

# Output the current rocket speed and remaining fuel to the console
print(f"Текущая скорость: {rocket.velocity} м/с")
print(f"Оставшееся топливо: {rocket.fuel_tank.remaining_fuel} кг")

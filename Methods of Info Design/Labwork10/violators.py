class ViolatorObserver:  # ! Наблюдатель-нарушитель
    def __init__(self, name, direction):
        self.name = name
        self.direction = direction
        self.violators = []

    def add_violator(self, violator):
        if violator.direction == self.direction:
            self.violators.append(violator)
            print(f"{self.name} получил сообщение о нарушителе: {violator.name}")


class Violator:  # ! Нарушитель
    def __init__(self, name, direction):
        self.name = name
        self.direction = direction


class TrafficPolicePost:  # !  Пост ДПС
    def __init__(self, name, direction):
        self.name = name
        self.direction = direction
        self.observers = []

    def register_observer(self, observer):
        self.observers.append(observer)

    def notify_observers(self, violator):
        for observer in self.observers:
            observer.add_violator(violator)


# create some observers
north_observer = ViolatorObserver("Северный наблюдатель", "north")
east_observer = ViolatorObserver("Восточный наблюдатель", "east")
west_observer = ViolatorObserver("Западный наблюдатель", "west")
south_observer = ViolatorObserver("Южный наблюдатель", "south")

# create some traffic police posts and register the observers
north_post = TrafficPolicePost("North Post", "north")
north_post.register_observer(north_observer)

east_post = TrafficPolicePost("East Post", "east")
east_post.register_observer(east_observer)

west_post = TrafficPolicePost("West Post", "west")
west_post.register_observer(west_observer)

south_post = TrafficPolicePost("South Post", "south")
south_post.register_observer(south_observer)

# create some violators and report them to the traffic police posts
violator1 = Violator("John", "north")
north_post.notify_observers(violator1)

violator2 = Violator("Jane", "east")
east_post.notify_observers(violator2)

violator3 = Violator("Mike", "west")
west_post.notify_observers(violator3)

violator4 = Violator("Lisa", "north")
north_post.notify_observers(violator4)

violator5 = Violator("Logan", "south")
south_post.notify_observers(violator5)

import datetime


class Subject:
    def __init__(self):
        self.observers = []

    def attach(self, observer):
        self.observers.append(observer)

    def detach(self, observer):
        self.observers.remove(observer)

    def notify(self, user):
        for observer in self.observers:
            if observer != user:
                observer.update(user)


class User(Subject):
    def __init__(self, user_id, name):
        super().__init__()
        self.id = user_id
        self.name = name
        self.connection_time = datetime.datetime.now()

    def set_name(self, new_name):
        old_name = self.name
        self.name = new_name
        self.notify(self)

    def __str__(self):
        return f"{self.name} ({self.id})"

    def update(self, user):
        print(f"{user.name} changed their name to {user}")


# create some users
user1 = User(1, "Alice")
user2 = User(2, "Bob")
user3 = User(3, "Charlie")

# attach users as observers
user1.attach(user2)
user1.attach(user3)
user2.attach(user1)
user2.attach(user3)
user3.attach(user1)
user3.attach(user2)

# print the users
print(user1)
print(user2)
print(user3)

# change Alice's name
user1.set_name("Alice2")

# remove Bob from the system
user2.detach(user1)
user2.detach(user3)

# change Charlie's name
user3.set_name("Charlie2")

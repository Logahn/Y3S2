class Rectangle:
    def __init__(self, x, y, width, height):
        self.x = x
        self.y = y
        self.width = width
        self.height = height

    def move(self, dx, dy):
        self.x += dx
        self.y += dy

    def resize(self, dw, dh):
        self.width += dw
        self.height += dh

    def get_bounding_rectangle(self, other):
        x1 = min(self.x, other.x)
        y1 = min(self.y, other.y)
        x2 = max(self.x + self.width, other.x + other.width)
        y2 = max(self.y + self.height, other.y + other.height)
        return Rectangle(x1, y1, x2 - x1, y2 - y1)

    def get_intersection(self, other):
        x1 = max(self.x, other.x)
        y1 = max(self.y, other.y)
        x2 = min(self.x + self.width, other.x + other.width)
        y2 = min(self.y + self.height, other.y + other.height)
        if x1 < x2 and y1 < y2:
            return Rectangle(x1, y1, x2 - x1, y2 - y1)
        else:
            return None


# create some rectangles
rect1 = Rectangle(0, 0, 10, 5)
rect2 = Rectangle(5, 3, 7, 8)

# move the first rectangle
rect1.move(3, 2)
print("Прямоугольник 1 после перемещения:", rect1.x, rect1.y)

# resize the second rectangle
rect2.resize(2, -3)
print("Прямоугольник 2 после изменения размера:", rect2.width, rect2.height)

# find the smallest bounding rectangle
bounding_rect = rect1.get_bounding_rectangle(rect2)
print("Ограничивающий прямоугольник:", bounding_rect.x, bounding_rect.y,
      bounding_rect.width, bounding_rect.height)

# find the intersection of the two rectangles
intersection = rect1.get_intersection(rect2)
if intersection:
    print("Пересечение:", intersection.x, intersection.y,
          intersection.width, intersection.height)
else:
    print("Прямоугольники не пересекаются.")

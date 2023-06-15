import math

N = int(input("Enter an integer N: "))
sum = 0

for i in range(N+1):
    if i == 0:
        continue
    sum += 1 / math.factorial(i-1)

print("The sum is:", sum)

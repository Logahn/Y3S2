N = int(input("Enter an integer N: "))
sum = 0
K = 0

while sum <= N:
    K += 1
    sum += K

print(K-1 if sum > N else K)

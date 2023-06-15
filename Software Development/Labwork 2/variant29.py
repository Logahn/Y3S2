# get the length of the list from user input
N = int(input("Enter the length of the list: "))

# initialize an empty list
num_list = []

# get the list of real numbers from user input
for i in range(N):
    num = int(input(f"Enter the {i+1}th number: "))
    num_list.append(num)

# sort the list in ascending order using bubble sort
for i in range(len(num_list)):
    for j in range(len(num_list)-1-i):
        if num_list[j] > num_list[j+1]:
            num_list[j], num_list[j+1] = num_list[j+1], num_list[j]

# print the sorted list
print("The sorted list in ascending order is:")
for num in num_list:
    print(num)

# Open the input and output files


input_file = open("Software Development/Labwork 2/input.txt", "r")
output_file = open("Software Development/Labwork 2/output.txt", "w")

# Read the unsorted list from the input file
unsorted_list = input_file.read().splitlines()

# Convert the list elements from strings to integers (if needed)
unsorted_list = [int(x) for x in unsorted_list]

# Define a boolean flag to indicate if any swaps have been made in a pass
swapped = True

# Loop until no more swaps are made
while swapped:
    swapped = False
    for i in range(len(unsorted_list) - 1):
        # Compare adjacent elements and swap them if needed
        if unsorted_list[i] > unsorted_list[i + 1]:
            unsorted_list[i], unsorted_list[i +
                                            1] = unsorted_list[i + 1], unsorted_list[i]
            swapped = True

# Write the sorted list to the output file
for item in unsorted_list:
    output_file.write(str(item) + "\n")

# Close the input and output files
input_file.close()
output_file.close()

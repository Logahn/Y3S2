def deposit_amount(principal, years):
    total = principal
    for i in range(years):
        total *= 1.1
        total += principal
    return total


total = deposit_amount(1000, 5)
print(total)

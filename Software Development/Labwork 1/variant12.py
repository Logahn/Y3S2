def day_of_week(k):
    days_of_week = {1: 'Понедельник', 2: 'Вторник', 3: 'Среда',
                    4: 'Четверг', 5: 'Пятница', 6: 'Суббота', 7: 'Воскресенье'}
    jan_1_day = 6  # Saturday
    days_passed = k - 1
    days_passed_remainder = days_passed % 7
    k_day = (jan_1_day + days_passed_remainder) % 7
    return days_of_week[k_day]


print(day_of_week(56))
print(day_of_week(207))
print(day_of_week(363))

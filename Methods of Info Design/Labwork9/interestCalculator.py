from abc import ABC, abstractmethod


class InterestCalculationStrategy(ABC):
    @abstractmethod
    def calculate_interest(self, deposit_amount, interest_rate, term):
        pass


class MonthlyInterestCalculation(InterestCalculationStrategy):
    def calculate_interest(self, deposit_amount, interest_rate, term):
        interest = 0
        for i in range(term):
            interest += deposit_amount * (interest_rate / 1200)
        total_amount = deposit_amount + interest
        return (interest, total_amount)


class BiMonthlyInterestCalculation(InterestCalculationStrategy):
    def calculate_interest(self, deposit_amount, interest_rate, term):
        interest = 0
        for i in range(term):
            if i % 2 == 0:
                interest += deposit_amount * (interest_rate / 1200)
        total_amount = deposit_amount + interest
        return (interest, total_amount)


class QuarterlyInterestCalculation(InterestCalculationStrategy):
    def calculate_interest(self, deposit_amount, interest_rate, term):
        interest = 0
        for i in range(term):
            if i % 3 == 0:
                interest += deposit_amount * (interest_rate / 1200)
        total_amount = deposit_amount + interest
        return (interest, total_amount)


class DepositCalculator:
    def __init__(self, deposit_amount, interest_rate, term, interest_calculation_strategy):
        self.deposit_amount = deposit_amount
        self.interest_rate = interest_rate
        self.term = term
        self.interest_calculation_strategy = interest_calculation_strategy

    def calculate(self):
        interest, total_amount = self.interest_calculation_strategy.calculate_interest(
            self.deposit_amount, self.interest_rate, self.term)
        return (interest, total_amount)


deposit_amount = float(input("Введите сумму депозита: "))
interest_rate = float(input("Введите процентную ставку (в процентах): "))
term = int(input("Введите срок (в месяцах): "))

print("Выберите период капитализации процентов:")
print("1 - Ежемесячно")
print("2 - Раз в два месяца")
print("3 - Квартальный")
capitalization_period = int(input("Введите период (1-3): "))

if capitalization_period == 1:
    interest_calculation_strategy = MonthlyInterestCalculation()
elif capitalization_period == 2:
    interest_calculation_strategy = BiMonthlyInterestCalculation()
elif capitalization_period == 3:
    interest_calculation_strategy = QuarterlyInterestCalculation()
else:
    print("Неверный ввод.")
    exit()

calculator = DepositCalculator(
    deposit_amount, interest_rate, term, interest_calculation_strategy)
interest, total_amount = calculator.calculate()

print("Заработанные проценты: ${:.2f}".format(interest))
print("Общая сумма: ${:.2f}".format(total_amount))

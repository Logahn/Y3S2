import os
import json
import requests

API_URL = 'https://date.nager.at/api/v3/'
SUPPORTED_COUNTRIES_FILE = os.path.join(
    os.path.abspath(os.sep), 'tmp', 'supported_countries.json')
LAST_CHOSEN_COUNTRY_FILE = os.path.join(
    os.path.abspath(os.sep), 'tmp', 'last_chosen_country.json')


def get_supported_countries():
    try:
        with open(SUPPORTED_COUNTRIES_FILE, 'r') as f:
            supported_countries = json.load(f)
    except:
        response = requests.get(API_URL + 'availableCountries')
        if response.status_code == 200:
            supported_countries = {country['countryCode']: country['name']
                                   for country in response.json()}
            with open(SUPPORTED_COUNTRIES_FILE, 'w') as f:
                json.dump(supported_countries, f)
        else:
            supported_countries = None

    return supported_countries


def get_last_chosen_country():
    try:
        with open(LAST_CHOSEN_COUNTRY_FILE, 'r') as f:
            last_chosen_country = json.load(f)
    except:
        last_chosen_country = None

    return last_chosen_country


def set_last_chosen_country(country):
    with open(LAST_CHOSEN_COUNTRY_FILE, 'w') as f:
        json.dump(country, f)


def get_holidays_for_country(country_code):
    response = requests.get(
        API_URL + f'PublicHolidays/2023/{country_code}')
    if response.status_code == 200:
        holidays = response.json()
        return holidays
    else:
        return None


def display_holidays(holidays):
    if holidays:
        print('Holidays:')
        for holiday in holidays:
            print(f"{holiday['date']} - {holiday['name']}")
    else:
        print('Failed to retrieve holidays.')


def prompt_country(supported_countries, last_chosen_country):
    if last_chosen_country in supported_countries:
        supported_countries.remove(last_chosen_country)
        supported_countries.insert(0, last_chosen_country)
    print('Supported countries:')
    for i, country in enumerate(supported_countries):
        print(f'{i+1}. {country}')
    while True:
        choice = input('Enter the number of the country to get holidays for: ')
        try:
            choice = int(choice)
            if 1 <= choice <= len(supported_countries):
                return supported_countries[choice-1]
        except:
            pass
        print('Invalid choice. Please try again.')


def main():
    supported_countries = get_supported_countries()
    last_chosen_country = get_last_chosen_country()
    country = prompt_country(supported_countries, last_chosen_country)
    holidays = get_holidays_for_country(country)
    display_holidays(holidays)
    set_last_chosen_country(country)


if __name__ == '__main__':
    main()

import numpy as np


def average(numbers):
    summ = np.sum(numbers)
    summ = np.float(summ)
    results = summ / len(numbers)
    return results


print average(np.array([2, 5, 8]))


def median(numbers):
    numbers = np.sort(numbers)
    if len(numbers) % 2 != 0:
        result = numbers[len(numbers) / 2]
    elif len(numbers) % 2 == 0:
        result = average([numbers[len(numbers) / 2], numbers[len(numbers) / 2 - 1]])
    return result


print median(np.array([1, 5, 3, 4]))


def mode(numbers):
    dic = {}
    for num in numbers:
        if str(num) not in dic.keys():
            dic.update({str(num): 1})
        elif str(num) in dic.keys():
            dic[str(num)] += 1
    prev = ['', 0]
    for key in dic.keys():
        if dic[key] > prev[1]:
            prev[1] = dic[key]
            prev[0] = key
    return prev[0]


print mode([1, 2, 1, 1, 1, 1, 3, 3, 3, 3])


def rang(numbers):
    numbers = np.sort(numbers)
    results = numbers[len(numbers) - 1] - numbers[0]
    return results


print rang(np.array([1, 5, 3]))


def sigma(numbers):
    mean = average(numbers)
    lst = (numbers - mean) **2
    print lst, 'numpy'
    #lst = [(x - mean) ** 2 for x in numbers]
    #print lst, 'py'
    temp = average(lst)
    print temp
    return temp ** .5


print sigma(np.array([1, 2, 3, 4, 5]))

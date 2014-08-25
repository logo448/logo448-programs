import math


def average(numbers):
    summ = sum(numbers)
    summ = float(summ)
    results = summ / len(numbers)
    return results


print average([2, 5, 8])


def median(numbers):
    numbers = sorted(numbers)
    if len(numbers) % 2 != 0:
        result = numbers[len(numbers) / 2]
    elif len(numbers) % 2 == 0:
        result = average([numbers[len(numbers) / 2], numbers[len(numbers) / 2 - 1]])
    return result


print median([1, 5, 3, 4])


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
    numbers = sorted(numbers)
    results = numbers[len(numbers) - 1] - numbers[0]
    return results


print rang([1, 5, 3])


def sigma(numbers):
    mean = average(numbers)
    lst = [(x - mean) ** 2 for x in numbers]
    print lst
    temp = average(lst)
    print temp
    return temp ** .5


print sigma([1, 2, 3, 4, 5])


def quadratic_form(quad):
    a = int(quad[0])
    b = int(quad[5])
    c = int(quad[8])
    p_result1 = (b ** 2) - (4 * a * c)
    if p_result1 > 0:
        p_result2 = -b + math.sqrt(p_result1) / (2 * a)
        p_result = p_result2
    else:
        p_result = None
    m_result1 = (b ** 2) - (4 * a * c)
    if m_result1 > 0:
        m_result2 = -b - math.sqrt(p_result1) / (2.0 * a)
        m_result = m_result2
    else:
        m_result = None
    return p_result, m_result


print quadratic_form('5x^2+5x+5')

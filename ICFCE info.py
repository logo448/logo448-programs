# Logan Stenzel
# ICFCE info


def get_num_digits(start, re):
    """calculate number of digits in the encrypted file"""
    result = start
    #reapply formula for as many time as your encrypting
    for i in range(re):
        result = (7 * result) / 5.0
        result *= (7 ** (i + 1))
        result += 48
        print result
        tmp = result / 8000000.0
        print "In MB %f" % tmp
    return result


get_num_digits(20, 3)
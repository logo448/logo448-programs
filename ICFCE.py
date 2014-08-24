# Ice Cream Flavor Code Encryption
# Logan Stenzel

# Importing the necessary modules
import string
import random
from Tkinter import *

# VARIABLES
letter_displacement = 2

#add on variables
a_base = 100
a_key = 17

#rescramble variables
r_key = 2
r_base = 1

#swap variable
s_key = 2
s_base = 5

#xor variable
x_key = 3
x_base = 10


def get_input():
    """gets user input"""
    original_word = raw_input("Enter a Word: ")
    original_word = original_word.lower()
    return original_word


def get_add_on():
    """gets the add on for encryption"""
    #List of all the add ons made with a list comprehension
    add_on_list = [[a, b] for a in list(string.ascii_lowercase) for b in list(string.ascii_lowercase)]
    global a_base
    #reset the a_base if it gets to high
    if a_base + a_key > len(add_on_list) - 1:
        a_base = -1
    #sets value of add_on
    add_on = add_on_list[a_base + a_key]
    add_on = "".join(add_on)
    a_base += a_key
    return add_on


def get_rescramble():
    """gets the rescramble rate"""
    mini = 2
    maxi = 7
    global r_base
    #set value of rescramble
    rescramble = r_base + r_key
    #resets rescramble if it gets to high or low.
    if rescramble > maxi or rescramble < mini:
        rescramble = mini
    r_base = rescramble
    return rescramble


def get_swap():
    """Gets the swap rate"""
    global s_base
    lst = [x for x in range(25)]
    #reset s_base if it gets to high
    if s_key + s_base > len(lst) - 1:
        s_base = -1
    #set the value of key
    key = lst[s_key + s_base]
    s_base += s_key
    return key


def swap(strin, neg_pos):
    """swaps the letters in the message"""
    key = get_swap()
    strin = strin.lower()
    #checks to see if you are decoding or not
    if neg_pos == '-':
        key = -key
    final = ''
    #the alphabet
    alpha = tuple(string.ascii_lowercase)
    #loop through the message
    for a in strin:
        count = 0
        #sets spaces equal to spaces
        if a == ' ':
            final += ' '
        #keeps characters not in the alphabet in the message
        elif a not in alpha:
            final += a
        for b in alpha:
            #checks to see if character in message matches character in alpha
            if a == b:
                if count + key >= len(alpha):
                    #replace with new character
                    final += alpha[count + key - len(alpha)]
                else:
                    #replace with new character
                    final += alpha[count + key]
            count += 1
    return final


def to_bin(message, leng):
    """converts the message to binary"""
    results = ''
    for i in message:
        i = bin(ord(i))
        i = i[2:]
        if len(i) < leng:
            dif = leng - len(i)
            i = '0' * dif + i
        results += i
    return results


def to_dec(message, leng):
    results = ''
    chunk = ''
    count = 0
    while message != '':
        for i in message:
            chunk += i
            count += 1
            message = message[count:]
            if count >= leng:
                results += chr(int(chunk, base=2))
                chunk = ''
                count = 0
    return results


def get_x_key():
    lst = [[str(a), str(b), str(c), str(d), str(e), str(f)] for a in range(2) for b in range(2)
           for c in range(2) for d in range(2) for e in range(2) for f in range(2)]
    key = '0'
    global x_base
    if x_base + x_key > len(lst) - 1:
        x_base = -1
    key += "".join(lst[x_key + x_base])
    key = int(key, base=2)
    x_base += key
    return key


def xor(bin_message):
    result = ''
    count = 0
    chunk = ''
    key = get_x_key()
    while bin_message != '':
        for i in bin_message:
            chunk += i
            if count >= 6:
                bin_message = bin_message[7:]
                count = -1
                temp_result = bin(int(chunk, base=2) ^ key)
                temp_result = temp_result[2:]
                if len(temp_result) < 7:
                    diff = 7 - len(temp_result)
                    temp_result = '0' * diff + temp_result
                key = get_x_key()
                result += temp_result
                chunk = ''
            count += 1
    return result


def scramble(word_chunk, results):
    """scrambles part of the message"""
    letters_displaced = word_chunk[0:letter_displacement]
    temp_word = word_chunk[letter_displacement:]
    temp2_word = temp_word + letters_displaced
    add_on = get_add_on()
    results.append(temp2_word + add_on)
    temp = 0
    for i in results:
        temp += len(i)


def encrypt(word):
    """scrambles whole message"""
    code = make_flavor_code()
    rescramble = get_rescramble()
    letter_count = 0
    results = []
    word_chunk = ""
    while word != "":
        for i in word:
            word_chunk += i
            letter_count += 1
            word = word[letter_count:]
            if letter_count >= rescramble:
                rescramble = get_rescramble()
                letter_count = 0
                scramble(word_chunk, results)
                word_chunk = ""
    if letter_count != 0:
        scramble(word_chunk, results)
    results = ''.join(results)
    results = swap(results, '')
    results = to_bin(results, 7)
    results = xor(results)
    results = code + results
    return results


def descramble(word_chunk, results):
    """descramble part of the message"""
    add_on = get_add_on()
    temp_word = word_chunk[:len(word_chunk) - len(add_on)]
    letters_displaced = temp_word[len(temp_word) - letter_displacement:]
    temp2_word = temp_word[:len(temp_word) - letter_displacement]
    results.append(letters_displaced + temp2_word)
    print len(results)


def decrypt(word):
    """descrambles the whole message"""
    word = break_flavor_code(word)
    rescramble = get_rescramble()
    add_on = get_add_on()
    word = xor(word)
    word = to_dec(word, 7)
    word = swap(word, '-')
    letter_count = 0
    word_chunk = ""
    results = []
    while word != "":
        for i in word:
            word_chunk += i
            letter_count += 1
            word = word[letter_count:]
            if letter_count >= rescramble + len(add_on):
                rescramble = get_rescramble()
                letter_count = 0
                descramble(word_chunk, results)
                word_chunk = ""
    if letter_count != 0:
        descramble(word_chunk, results)
    results = ''.join(results)
    print len(results)
    return results


def make_flavor_code():
    global a_base
    global a_key
    global r_base
    global r_key
    global s_base
    global s_key
    global x_base
    global x_key
    code = ''
    a_base = random.randint(0, 63)
    t_code = bin(a_base)[2:]
    if len(t_code) < 6:
        dif = 6 - len(t_code)
        t_code = '0' * dif + t_code
    code += t_code
    a_key = random.randint(0, 31)
    t_code = bin(a_key)[2:]
    if len(t_code) < 6:
        dif = 6 - len(t_code)
        t_code = '0' * dif + t_code
    code += t_code
    r_base = random.randint(2, 6)
    t_code = bin(r_base)[2:]
    if len(t_code) < 6:
        dif = 6 - len(t_code)
        t_code = '0' * dif + t_code
    code += t_code
    r_key = random.randint(3, 5)
    t_code = bin(r_key)[2:]
    if len(t_code) < 6:
        dif = 6 - len(t_code)
        t_code = '0' * dif + t_code
    code += t_code
    s_base = random.randint(0, 25)
    t_code = bin(s_base)[2:]
    if len(t_code) < 6:
        dif = 6 - len(t_code)
        t_code = '0' * dif + t_code
    code += t_code
    s_key = random.randint(0, 12)
    t_code = bin(s_key)[2:]
    if len(t_code) < 6:
        dif = 6 - len(t_code)
        t_code = '0' * dif + t_code
    code += t_code
    x_base = random.randint(0, 63)
    t_code = bin(x_base)[2:]
    if len(t_code) < 6:
        dif = 6 - len(t_code)
        t_code = '0' * dif + t_code
    code += t_code
    x_key = random.randint(0, 32)
    t_code = bin(x_key)[2:]
    if len(t_code) < 6:
        dif = 6 - len(t_code)
        t_code = '0' * dif + t_code
    code += t_code
    return code


def break_flavor_code(message):
    global a_base
    global a_key
    global r_base
    global r_key
    global s_base
    global s_key
    global x_base
    global x_key
    code = ''
    for index, item in enumerate(message):
        if index <= 47:
            code += item
    count = 0
    lst = []
    chunk = ''
    print 'flavor code:', code
    while code != '':
        for i in code:
            chunk += i
            code = code[count:]
            if count >= 5:
                lst.append(chunk)
                chunk = ''
                count = -1
            count += 1
    message = message[48:]
    a_base = int(lst[0], base=2)
    a_key = int(lst[1], base=2)
    r_base = int(lst[2], base=2)
    r_key = int(lst[3], base=2)
    s_base = int(lst[4], base=2)
    s_key = int(lst[5], base=2)
    x_base = int(lst[6], base=2)
    x_key = int(lst[7], base=2)
    print len(message)
    return message


def main_enc():
    message_path = message_path_input.get()
    save_path_var = save_path_input.get()
    count = 0
    f = open(str(message_path), "r")
    word = f.read()
    f.close()
    while count < 4:
        word = encrypt(word)
        count += 1
    f = open(str(save_path_var), "w+")
    f.write(str(word))
    f.close()


def main_dnc():
    message_path = d_message_input.get()
    f = open(str(message_path), "r+")
    word = f.read()
    f.close()
    dpathv = d_save_path_input.get()
    count = 0
    while count < 4:
        word = decrypt(word)
        count += 1
    f = open(str(dpathv), "w+")
    f.write(str(word))
    f.close()


app = Tk()
app.title('ICFCE')
app.geometry('1080x1920')

save_path_text = StringVar()
save_path_text.set('Enter the path where you want your encrypted file saved.')
save_path = Label(app, textvariable=save_path_text, height=4)
save_path.pack(fill=X)

save_path_input = Entry(app)
save_path_input.pack(fill=X, padx=15)

message_path_text = StringVar()
message_path_text.set('Enter the path of the message to be encrypted.')
message_path_labal = Label(app, textvariable=message_path_text, height=4)
message_path_labal.pack(fill=X)

message_path_input = Entry(app)
message_path_input.pack(fill=X, padx=15)

enc_button = Button(app, text='Encrypt', width=20, command=main_enc)
enc_button.pack()

empty = Label(app)
empty.pack(pady=50)

d_save_path_text = StringVar()
d_save_path_text.set('Enter the path where the decrypted message will be saved.')
d_save_path = Label(app, textvariable=d_save_path_text, height=4)
d_save_path.pack(fill=X)

d_save_path_input = Entry(app)
d_save_path_input.pack(fill=X, padx=15)

d_message_path_text = StringVar()
d_message_path_text.set('Enter the path of the encrypted message you want decrypted.')
d_message_path = Label(app, textvariable=d_message_path_text, height=4)
d_message_path.pack(fill=X)

d_message_input = Entry(app)
d_message_input.pack(fill=X, padx=15)

dnc_button = Button(app, text='Decrypt', width=20, command=main_dnc)
dnc_button.pack()

app.mainloop()
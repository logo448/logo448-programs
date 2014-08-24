no_primes = [i for i in range(2, 300) for a in range(2, i) if i % a == 0]
primes = [b for b in range(1, 300) if b not in no_primes]
print primes
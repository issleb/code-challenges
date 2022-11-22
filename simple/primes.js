
const checkPrime = (n) => {
    for (i = 2; i <= n/2; i++) {
        if (i !== n && !(n % i)) return false;
    }

    return true;
}

const getPrimes = (n) => {
    let primes = [];

    for (let i = 1; i <= n; i++) {
        const isPrime = checkPrime(i);
        if (isPrime) primes.push(i);
    }

    return primes;
}

console.log(getPrimes(100));
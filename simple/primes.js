// Find the primes up to a given number.

// O(n + n / 2) = O(n + n) = O(2n) = O(n) time complexity.
// O(1) space complexity.
const getPrimes = (n) => {
    const primes = [];

    for (let i = 1; i <= n; i++) {
        const isPrime = checkPrime(i);
        if (isPrime) primes.push(i);
    }

    return primes;
}

const checkPrime = (n) => {
    for (let i = 2; i <= n/2; i++) {
        if (i !== n && !(n % i)) return false;
    }

    return true;
}


console.log(getPrimes(100));
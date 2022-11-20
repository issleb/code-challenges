
// This is bad, it's  O(2^n). Try it with a value of 500 and watch your computer explode. :D
const getNumber = (num) => {
    const fib = num < 2 ? num : getNumber(num - 1) + getNumber(num - 2);

    return fib;
}


const getSequence = (count) => {
    const numbers = [];
    
    for (i = 0; i < count; i++) {
        if (i < 2) {
            numbers.push(i);
        } else {
            numbers.push(numbers[i-1] + numbers[i-2]);
        }
    }

    return numbers;
};

console.log(getSequence(10));
console.log(getNumber(9));
 const fizzBuzz = function(n) {
    const output = [];
    for (i = 1; i <= n; i++) {
        const isThree = !(i % 3);
        const isFive = !(i % 5);
        
        if (isThree && isFive) {
            output.push("FizzBuzz");
        }
        else if (isThree) {
             output.push("Fizz");    
        }
        else if (isFive) {
             output.push("Buzz");    
        }
        else {
            output.push(`${i}`);
        }
    }

    return output;
};

console.log(fizzBuzz(15));
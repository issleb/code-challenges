const checkAnagram = (word1, word2) => {
    const letters1 = word1.split("");
    const letters2 = word2.split("");

    if (letters1.length != letters2.length) return false;
    return (letters1.sort().toString() === letters2.sort().toString());
}

const checkPalindrome = (word) => {
    const splits = word.split("");
    let reversed = "";
    for (i = splits.length - 1; i >= 0; i--) {
        reversed = reversed + splits[i];
    }

    return word === reversed;
}

console.log(checkAnagram("listen", "silent"));
console.log(checkAnagram("bo", "boo"));

console.log(checkPalindrome("racecar"));
console.log(checkPalindrome("doom"));
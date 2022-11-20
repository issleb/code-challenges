const reverseString = (string, seperator = "") => {
    const splits = string.split(seperator ?? "");

    let newString = "";
    for (i = splits.length - 1; i >= 0; i--) {
        newString = newString + splits[i] + seperator;
    }

    return newString;
}

const reverseSentence = (sentence) => {
    const newSentence = reverseString(sentence, " ");

    return newSentence;
}

console.log(reverseString("abc fed ghi"));
console.log(reverseSentence("I like eating french fries."));
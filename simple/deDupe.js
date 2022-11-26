// Remove duplicates from an array.

// O(n) time complexity.
// O(n) space complexity.
const deDupe = (list) => {
    const uniques = {};
    list.forEach(i => {
        if (!uniques[i]) uniques[i] = 1;
    });

    return Object.keys(uniques);
}

console.log(deDupe(["big", "medium", "small", "large", "big", "small"]));
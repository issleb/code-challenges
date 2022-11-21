const sorter = require("./sorter.js");

const items = [["dog", "cat", "snake", "dog", "gerbil"], ["bison", "zebra"]]; // Length = n
const order = ["zebra", "cat", "dog", "pig"]; // Length = k

const sortedItems = sorter.sortItems(items, order);

console.log(sortedItems);
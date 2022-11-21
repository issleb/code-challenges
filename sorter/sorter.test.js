const sorter = require("./sorter.js")

describe("sorter", () => { 
    test("original list", () => {
        const items = [["dog", "cat", "dog", "snake", "cat"]];
        const order = ["cat", "dog", "zebra"];

        const sortedItems = sorter.sortItems(items, order);

        expect(sortedItems).toEqual(["cat", "cat", "dog", "dog"]);
    });

    test("add to items", () => {
        const items = [["zebra", "dog", "cat", "dog", "snake", "cat"]];
        const order = ["cat", "dog", "zebra"];

        const sortedItems = sorter.sortItems(items, order);

        expect(sortedItems).toEqual(["cat", "cat", "dog", "dog", "zebra"]);
    });

    test("add items to order", () => {
        const items = [["bison", "dog", "cat", "dog", "snake", "cat"]];
        const order = ["cat", "bison", "dog", "zebra"];

        const sortedItems = sorter.sortItems(items, order);

        expect(sortedItems).toEqual(["cat", "cat", "bison", "dog", "dog"]);
    });

    test("remove from items", () => {
        const items = [["dog", "dog", "snake"]];
        const order = ["dog", "zebra"];

        const sortedItems = sorter.sortItems(items, order);

        expect(sortedItems).toEqual(["dog", "dog"]);
    }); 

    test("addToItems", () => {
        const items = [["dog", "gerbil", "cat", "dog", "snake", "cat", "gerbil"]];
        const order = ["cat", "dog", "zebra"];

        const sortedItems = sorter.sortItems(items, order);

        expect(sortedItems).toEqual(["cat", "cat", "dog", "dog"]);
    });

    test("two item lists", () => {
        const items = [["zebra", "dog", "cat", "dog"], ["snake", "cat"]];
        const order = ["cat", "dog", "zebra"];

        const sortedItems = sorter.sortItems(items, order);

        expect(sortedItems).toEqual(["cat", "cat", "dog", "dog", "zebra"]);
    });

});
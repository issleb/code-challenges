const sortItems = (itemLists, order) => {
    const combinedList = itemLists.concat(...itemLists);

    const orderHash = {};
    order.forEach((item, i) => orderHash[item] = i);

    const filtered = combinedList.filter(item => orderHash[item] !== undefined);
    const sorted = filtered.sort(function(a, b){  
        return orderHash[a] - orderHash[b];
    });

    return sorted;
}

exports.sortItems = sortItems;
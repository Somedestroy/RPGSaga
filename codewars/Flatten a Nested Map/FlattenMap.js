function flattenMap(map) {
    var result = {};
    function recurse (data, prop) {
      if (Object(data) !== data || Array.isArray(data)) {
      return result[prop] = data;
    }
        for (var item in data) {
            recurse(data[item], prop ? prop+"/"+item : item);
        }
    }
    recurse(map, "");
    return result;
}
function sumPairs(ints, s) {
    if (ints.length < 2) return undefined;
    let result = new Set();
    for (let index = 0; index < ints.length; ++index)
    {
        if (result.has(s-ints[index]))
          {
            return [s-ints[index], ints[index]]
          }
        result.add(ints[index]);
    }
  }
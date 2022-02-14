function mergeArrays(a, b) {
    const maxLength = Math.max(a.length, b.length);
    let result = [];
    for (let index = 0; index < maxLength; index++) {
        result.push(a[index]);
        result.push(b[index]);
    }
    return result.filter((value) => value !== undefined);
}
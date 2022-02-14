function anagramDifference(w1,w2){
    let firstCount = Array(26).fill(0) 
    let secondCount = Array(26).fill(0) 
    let i = 0
    let j = 0
    while (i < w1.length){
        firstCount[w1[i].charCodeAt()-97] += 1
        i += 1
        }
    i =0
    while (i < w2.length){
        secondCount[w2[i].charCodeAt()-97] += 1
        i += 1
        }
   let result = 0
    for (let i = 0; i<26;i++){
        result += Math.abs(firstCount[i] - secondCount [i]) 
    }
    return result 
}
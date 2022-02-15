function anagramDifference(w1,w2){
    const alphabetCount = 26
    const alphabetStartIndex = 97;
    let count1 = Array(alphabetCount).fill(0) 
    let count2 = Array(alphabetCount).fill(0) 
    let result = 0;
    for (let i = 0; i < w1.length; i++)
      {
        count1[w1[i].charCodeAt()-alphabetStartIndex] += 1
      }
    for (let i = 0; i < w2.length; i++)
      {
        count2[w2[i].charCodeAt()-alphabetStartIndex] += 1
      }
    for (let i = 0; i < alphabetCount; i++) {
        result += Math.abs(count1[i] - count2[i]) 
    }
    return result 
}
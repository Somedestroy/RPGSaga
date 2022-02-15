function anagramDifference(w1,w2){
    let count1 = Array(26).fill(0) 
    let count2 = Array(26).fill(0) 
    let result = 0;
    for (let i = 0; i < w1.length; i++)
      {
        count1[w1[i].charCodeAt()-97] += 1
      }
    for (let i = 0; i < w2.length; i++)
      {
        count2[w2[i].charCodeAt()-97] += 1
      }
    for (let i = 0; i < 26; i++) {
        result += Math.abs(count1[i] - count2[i]) 
    }
    return result 
}
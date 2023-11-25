
let ex31 v1 v2 v3 =
  let inProgress = v1 + v2
  let answer = inProgress * v3
  $"The answer is {answer}"

ex31 1 2 3 // "The answer is 9"
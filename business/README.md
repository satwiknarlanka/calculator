# calculator design

## Evaluate simple artihematic expression

Initiate 3 resources: 1 char list, 1 number list, 1 char variable for previous operator

**Algorithm workflow**:

1. If element is a number add it to the char list
2. If element is an operator store element in char variable
3. If previous operator is + convert char list to number and store in number list
4. If previous operator is - convert char list to number and store in -1 * number list
5. If previous operator is * convert char list to number and multiply with last number in number list
6. If previous operator is / convert char list to number and divide with last number in number list

## Evaluate brackets expression

Recursivley solve all inner brackets till expression becomes a pure arithematic expression without brackets.
Append * if previous or next element after bracket is a number.
Eg: 4(2+1)3 should become 4*(2+1)*3
Add a * between a closing and opening bracket.
Eg: (2+1)(3-1) should become (2+1)*(3-1). This way when the inner brackets evaluate it becomes 3*2
The finaly result is evaluted as a simple arithematic expression again.
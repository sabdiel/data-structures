# Data Structures
---
## Hash Table
[![N|Solid](https://raw.githubusercontent.com/sabdiel/my-files/master/my%20hash%20table%20diagram.PNG)](https://raw.githubusercontent.com/sabdiel/my-files/master/my%20hash%20table%20diagram.PNG)

### What is a Hash Table?
A hash table is an array where a key (unique value) is used to compute (w/ a hash function) an index that specifies where to store a value. [Optimized for lookups]

The average Time Complexity is O(1) which is why is used to implement databases, indexes, caches in many scenarios.

### What is a Hash function?
An algorithm that compute the best index to allocate your data given a key. 

The sucess of a hash table is determined by how good its hash function is in determining the best place to allocate data, without a good hash function a hash table is not better than a simple array (O(n)).

### Collisions?
Collisions occur when a same index is given to more than one key. Your Hash Table needs to be able to handle collisions somehow, a common implementation of such is having an array of lists or array of trees so that if an index is duplicated your array bucket can hold as many values as necessary.





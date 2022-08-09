Andrew_SuperheroAPI

This is my backend project. I have built APIs that creates, reads, update and deletes from a MockDatabase.json file which acts as a database (has preset superhero entries with their Ids and Name). 

Also I have created an api that calls to the Pokemon API (https://pokeapi.co/) and the user can search for a pokemon they desire. If they search for a NON existing pokemon such as Josh, they get attacked by one of the random superheroes in the MockDatabase.json file. If they search for an EXISTING pokemon then the pokemon fights baack and inflicts damage to the randomly selected superhero. 

How does the middleware via dependency injection simlify my code?
Answer : Through dependency injection, you don't need to create instances of an object and therefore it makes my code loosely and easier to test as I can mock for unit test. So my assembly (service layer) is dependent on Pokemon and Superhero and to inject I created an interface for pokemon, superhero and assembly.
![image](https://user-images.githubusercontent.com/109708208/183777036-42eecabb-d498-423a-ae24-e78a3353a51e.png)



Demonstrate use of NUnit to test code
Answer: Unit test's use is to ensure a function or a piece of code behaves as intended. NUnit is a unit testing framework for .net framework and most used for writing unit test cases. I unit tested adding a superhero ("Batman") which is a function I use in my service layer and in the superhero dependency. Also unit tested adding an Character object (superheroes are Character objects) and seeing if my Get function is working and returning correctly.

Demonstrate how middleware libraries made your code easier to test.

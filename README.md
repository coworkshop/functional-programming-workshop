# Functional Programming Challenges
This repository contains a set of algorithms written delibretely in an imperative manner, with the purpose of being refactored in a more declerative way using the functional concepts available in the respective programming languages.

## Build and Test Status
[![.NET](https://github.com/coworkshop/functional-programming-workshop/actions/workflows/dotnet.yml/badge.svg)](https://github.com/coworkshop/functional-programming-workshop/actions/workflows/dotnet.yml)

## Getting Started
Fork and clone or just clone the repo

### Goal
Refactor the algorithms using functional programming, whilst maintaining <span style="color:green">**green**</span> tests!

### Suggested path
I advice to get an overview of the entire scope first, and then gradually working through the algorithms from easiest to hardest. A recommended order would be to:
1. Start with the basic mathematical functions first followed by the bits-and-bytes functions
2. String manipulation functions
3. Try pattern matching and program flow
4. Then try out some of the sorting algorithms and prime number counter

## Weird Things You Might Struggle With
Some of the code was a bit complicated to write in it's "pure" imperative nature due to some of the features of the programming languages. 

### JavaScript and Integer Division
JavaScript/TypeScript does not have a concept of integer division which some of these algorithms requrire for the imperative approach to work. Therefore you'll find some strange code such as `(i / 2) >> 0`. Here, `i` represents an integer, but when divied by 2 the result will naturally be a stored as a float if `i` is not divisable by 2. E.g. `5 / 2 = 2.5`, but with integer divison we would expect `5 / 2 = 2`. As there is no explicit notion of an integer in JavaScript/TypeScript a way to force the result to return only the integer part of the number (removing any decimals / factional digits) is to combine the division with an operations that returns a 32-bit integer, such as [right shift](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Operators/Right_shift). E.g. `5 / 2 = 2.5, 2.5 >> 0 = 2`.

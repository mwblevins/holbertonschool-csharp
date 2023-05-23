# Inheritance in C#

Inheritance is a fundamental concept in object-oriented programming (OOP) that allows you to define a new class based on an existing class. In C#, inheritance enables the creation of a hierarchy of classes, where the derived classes inherit the characteristics (fields, properties, and methods) of the base class.

## Key Terminology

Before diving into inheritance, let's clarify some key terminology:

- **Base Class**: Also known as the parent class or super class, it is the class from which other classes inherit.
- **Derived Class**: Also known as the child class or subclass, it is the class that inherits from the base class.
- **Inheriting**: The process by which a derived class acquires the members (fields, properties, and methods) of the base class.
- **Override**: The ability of a derived class to provide its own implementation of a method or property inherited from the base class.
- **Inheritance Hierarchy**: The structure created by multiple levels of inheritance, forming a tree-like structure.

## How to Use Inheritance

To create an inheritance relationship between classes in C#, you can use the colon (:) symbol in the class declaration. Here's an example:

```csharp
class Animal
{
    // Base class members
}

class Dog : Animal
{
    // Derived class members
}

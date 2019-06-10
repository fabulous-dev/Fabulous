namespace Fabimals.Models

type AnimalType =
    | Cat
    | Dog
    | Monkey
    | Elephant
    | Bear

type Animal =
    { Type: AnimalType
      Name: string
      Location: string
      Details: string
      ImageUrl: string }

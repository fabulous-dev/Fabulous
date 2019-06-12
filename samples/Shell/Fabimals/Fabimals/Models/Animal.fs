// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
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

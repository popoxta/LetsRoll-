using System;
using NUnit.Framework;
using Reqnroll;

namespace LetsRoll.StepDefinitions;

[Binding]
public sealed class CalculatorStepDefinitions
{
    private int _firstNumber;
    private int _secondNumber;


    [Given("the first number is {int}")]
    public void GivenTheFirstNumberIsInt(int number)
    {
        _firstNumber = number;
    }

    [Given("the second number is {int}")]
    public void GivenTheSecondNumberIsInt(int number)
    {
        _secondNumber = number;
    }

    [When("the two numbers are added")]
    public void WhenTheTwoNumbersAreAdded()
    {
        Console.WriteLine($"Adding numbers {_firstNumber} & {_secondNumber}");
    }

    [Then("the result should be {int}")]
    public void ThenTheResultShouldBeInt(int result)
    {
        Assert.That(_firstNumber + _secondNumber, Is.EqualTo(result));
    }
}
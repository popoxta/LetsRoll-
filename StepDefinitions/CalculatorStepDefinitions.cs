using System;
using NUnit.Framework;
using Reqnroll;

namespace LetsRoll.StepDefinitions;

[Binding]
public sealed class CalculatorStepDefinitions
{
    private int FirstNumber;
    private int SecondNumber;


    [Given("the first number is {int}")]
    public void GivenTheFirstNumberIs(int number)
    {
        FirstNumber = number;
    }

    [Given("the second number is {int}")]
    public void GivenTheSecondNumberIs(int number)
    {
        SecondNumber = number;
    }

    [When("the two numbers are added")]
    public void WhenTheTwoNumbersAreAdded()
    {
        Console.WriteLine($"Adding numbers {FirstNumber} & {SecondNumber}");
    }

    [Then("the result should be {int}")]
    public void ThenTheResultShouldBe(int result)
    {
        Assert.That(FirstNumber + SecondNumber, Is.EqualTo(result));
    }
}
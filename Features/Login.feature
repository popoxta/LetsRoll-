Feature: Login

This feature file covers testing of the login feature for the application.

@login
Scenario: Login with valid credentials
Given I click on the login link
When I enter a valid username "admin" and the password "password"
And I click the login button
Then I should be logged in
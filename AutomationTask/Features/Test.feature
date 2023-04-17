Feature: Add items to cart
As a customer
I want to add items to my cart and remove the lowest priced item

    Scenario: Add four random items to my cart
        Given I am on the home page
        When I add four random items to my cart
        Then I see four items listed in my cart
        When I search for the lowest priced item
        And I remove the lowest priced item from my cart
        Then I see three items listed in my cart
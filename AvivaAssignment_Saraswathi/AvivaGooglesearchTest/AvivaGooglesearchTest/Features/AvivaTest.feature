Feature: Print 5th link text of Aviva
	Open the google page and search with keyword Aviva
	verify the number of links returned and 
	print the 5th link text.

Background: 
 Given launch the google home page


@Positive
Scenario Outline: Search with Aviva keyword on Google home page and print the 5th link text
	And search with the string '<keyword>'
	When click on search button
    Then prints the 5th link text of results page.
	And number of links returned should be <count>
Examples:
	| keyword | count |
	| Aviva   | 10    |


@Negative
Scenario: User should search with wrong name on Google home page
 And search with the string '#*&(&jkldfhjkasdhf'
 When click on search button
 Then No results found page should be shown.



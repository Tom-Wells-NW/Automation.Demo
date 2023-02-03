Feature: FlaUI Application Extensions

	In order to perform UI Automation
	As a developer or QA analyst
	I want to be able to use UI Automation (UIA) to launch, position, and size an application under test


@FlaUiTests
Scenario Outline: Setting a standard Windows application's window position
	Given I have launched an application type <isWSA> named <application>
	 When I move the application window to a new <X> and <Y> screen position
	 Then I expect the window's new position to be (<X>, <Y>)

	Examples:
	| application | isWSA | X   | Y   | Test Case     |
	| notepad.exe | false | 100 | 100 | TC-FLAEX-0101 |
	| notepad.exe | false | 450 | 100 | TC-FLAEX-0102 |


@FlaUiTests
Scenario Outline: Setting the application's window position and size
	Given I have launched an application type <isWSA> named <application>
	 When I move the application window to a new <X> and <Y> screen position
	  And I resize the application window to a new <width> and <height> 
	 Then I expect the window's new position to be (<X>, <Y>)
	  And I expect the window's new size to be (<width>, <height>) pixels

	Examples:
	| application | isWSA | X   | Y   | width | height | Test Case     |
	| notepad.exe | false | 100 | 100 | 700   | 900    | TC-FLAEX-0201 |
	| notepad.exe | false | 200 | 100 | 600   | 800    | TC-FLAEX-0202 |
	| notepad.exe | false | 300 | 100 | 500   | 700    | TC-FLAEX-0203 |
	| notepad.exe | false | 400 | 100 | 400   | 600    | TC-FLAEX-0204 |

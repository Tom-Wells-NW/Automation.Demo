Feature: FlaUiApplication

	In order to perform UI Automation
	As a developer or QA analyst
	I want to be able to launch, position, and size an application under test


@FlaUiTests
Scenario Outline: Setting the application's window position
	Given I have launched an application <application>
	When I move the application window to a new <X> and <Y> screen position
	Then I expect the window's new position to be (<X>, <Y>)

	Examples:
	| application              | X   | Y   | Test Case |
	| c:\\windows\\notepad.exe | 100 | 100 | TC-0001   |
	| c:\\windows\\notepad.exe | 200 | 200 | TC-0002   |

@FlaUiTests
Scenario Outline: Setting the application's window size
	Given I have launched an application <application>
	When I resize the application window to a new <width> and <height> 
	Then I expect the window's new size to be (<width>, <height>) pixels

	Examples:
	| application              | width | height | Test Case |
	| c:\\windows\\notepad.exe | 350   | 200    | TC-0001   |
	| c:\\windows\\notepad.exe | 800   | 600    | TC-0002   |

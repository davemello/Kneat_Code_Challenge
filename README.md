
# Kneat_Code_Challenge

## Demo Specflow/Selenium Framework for Booking.Com website

Had to make a couple of changes to test data because at the time of scripting, one of the filter options (sauna) was not available. Changed this to Spa and Wellness center instead.

Fully tested using Chrome and Firefox

## Execution
Clone repo into visual studio. VS should have Specflow and NUnit extension installed. Build solution, open test explorer and select tests

OR

Run from command line and NUnit console

1. Open LOCATION_OF_REPOSITORY\packages\NUnitConsoleRunner3.11.1\tools
1. Open cmd prompt
1. Enter nunit3-console.exe [FULL LOCATION TO\SeleniumProject.dll] --testparam:BROWSER="Chrome" --where cat="smoke"
    (BROWSER can also be "Firefox")
    
List of tags: 
* @smoke                       runs 1 single test
* @all                         runs all tests
* @searchOptionTest            only test for search options
* @filterOptions               test for verifying filter options


Framework is Specflow based and uses page object with page factory to keep code clean. DriverManager ensures that latest compatible WebDriver is downloaded.
Reporting is done by Extent reports, logging from log4net and asserts from fluentAssert for readability

Specflow tags can control what scenarios get executed. Can pass in Nunit parameter to execute certain tags

    --where cat="smoke"

Default browser is set in the app.config file or if running Nunit through Jenkins or via CLI then can pass in a test parameter

    --testparam:BROWSER="Chrome"

BaseDefinition class is where all the Specflow Hooks to initialise tests are, including initialising the WebDriver and setting up Extent reporting.

Extent Reports - index.html file will be created in bin/debug folder. Screenshots taken on failure

## Description of namespaces

### BrowserProfiles
There is a custom profile for Chrome that can be used at run time. It contains the required cookies for Booking.com. In app.config set UseCustomProfile to true.

### ComponentHelper
Wrapper class for common IWebElements and JavaScript executor. Contains logging.

### Configuration
Browser choice Enum and Class to get values from App.config file

### CustomAssertions
Custom text assertions using fluent asserts

### CustomExceptions
Extends the Exception class

### Extensions
Custom extensions on IWebDriver methods

### FeatureFiles
Specflow features

### Interfaces
IConfig - used in initialisation

### Logging
Retrieves xml logging setup info from App.config. Appended log files written to bin/debug

### PageObject
All pages used, base page creates instance of logger

### Settings
ObjectRepository holds driver instance and congig instance(driver timeout etc)

### StepDefinition
Defined from feature files

### Text
Any text used

### Waits
Custom waits




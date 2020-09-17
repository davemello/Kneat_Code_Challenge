
# Kneat_Code_Challenge

## Demo Specflow/Selenium Framework for Booking.Com website

Had to make a couple of changes to test data because at the time of scripting, one of the filter options (sauna) was not available. Changed this to Spa and Wellness center instead.

Framework uses page object with page factory to keep code clean. DriverManager ensures that latest compatable WebDriver is downloaded.
Reporting is done by Extent reports, logging from log4net and asserts from fluentAssert for readability

Default browser is set in the app.config file or if running Nunit through Jenkins or via CLI then can pass in a test parameter

    --testparam:BROWSER="Chrome"

BaseDefinition class is where all the Specflow Hooks to initialise tests are, including initialising the WebDriver and setting up Extent reporting.

Extent Reports - index.html file will be created in bin/dubug folder. Screenshots taken on failure

## Description of namespaces

### BrowserProfiles
There are custom profiles for both Chrome and Firefox that can be used at run time. These contain the required cookies for Booking.com. At time of scripting the cookie notification popup was causing issues. Profile code has been commented out so framework will use a default instance.

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

###Waits
Custom waits




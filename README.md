
# Kneat_Code_Challenge

## Demo Specflow/Selenium Framework for Booking.Com website

Had to make a couple of changes to test data because at the time of scripting, one of the filter options (sauna) was not available. Changed this to Spa and Wellness center instead.

Framework uses page object with page factory to keep code clean. DriverManager ensures that latest compatable WebDriver is downloaded.
Default browser is set in the app.config file or if running Nunit through Jenkins or via CLI then can pass in a test parameter

    --testparam:BROWSER="Chrome"





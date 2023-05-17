using Newtonsoft.Json.Linq;
using RestSharp;


namespace API_TestProject_NextBDay
{
    public class DriverTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [Category("APISuite")]
        [TestCase("1990-10-30", "hour")]
        [TestCase("1990-10-30", "day")]
        [TestCase("1990-10-30", "week")]
        [TestCase("1990-10-30", "month")]        

        public async Task ValidateTimeLeftForNextBirthDate(String dateOfBirth, String unit)
        {

            //string dateOfBirth = "1990-10-30";
            //string Unit = "day";

            // Get the current local date and time
            DateTime currentDate = DateTime.UtcNow.ToLocalTime();

            // Parse the provided date of birth string
            DateTime birthDate = DateTime.Parse(dateOfBirth).Date;

            // Calculate the next upcoming birth date in the current year
            DateTime upcomingBirthDate = new DateTime(currentDate.Year, birthDate.Month, birthDate.Day);

            // If the upcoming birth date has already passed, add one year to get the next year's birth date
            if (currentDate > upcomingBirthDate)
            {
                upcomingBirthDate = upcomingBirthDate.AddYears(1);
            }

            // Calculate the remaining time until the upcoming birth date
            TimeSpan remainingTime = upcomingBirthDate - currentDate;

            // Calculate the remaining days and hours
            int remainingDays = remainingTime.Days;
            int remainingHours = remainingDays * 24 + remainingTime.Hours;

            // Calculate the remaining weeks and months
            int remainingWeeks = remainingDays / 7;
            int remainingMonths = (upcomingBirthDate.Year - currentDate.Year) * 12 + upcomingBirthDate.Month - currentDate.Month;

            // Determine the expected message based on the specified unit
            string expectedMessage = "";
            switch (unit)
            {
                case "hour":
                    expectedMessage = $"{remainingHours} hours left";
                    break;
                case "day":
                    expectedMessage = $"{remainingDays} days left";
                    break;
                case "week":
                    expectedMessage = $"{remainingWeeks} weeks left";
                    break;
                case "month":
                    expectedMessage = $"{remainingMonths} months left";
                    break;
            }

            // Create a REST client and request to get the response from the API
            var restClient = new RestClient(baseUrl: "https://lx8ssktxx9.execute-api.eu-west-1.amazonaws.com/");
            var request = new RestRequest(resource: "Prod/next-birthday");
            request.AddParameter("dateofbirth", dateOfBirth);
            request.AddParameter("unit", unit);

            //
            var response = await restClient.GetAsync(request);

            // Parse the JSON response
            JObject jsonResponse = JObject.Parse(response.Content);
            string message = jsonResponse["message"].ToString();
            var responseStatusCode = response.StatusCode.ToString();

            // Check if the expected message matches the actual response message and the response status code is "OK"
            //Assert.Equal(expectedMessage, message);
            if (expectedMessage.Equals(message) && responseStatusCode.Equals("OK"))
            {
                //Assert.Pass("Response Status Code: " + responseStatusCode);
                Assert.Pass("Actual Response Message: " + message);
            }
            else
            {
                //Assert.Fail("Response Status Code:" + responseStatusCode);
                Assert.Fail("Expected Response Message: " + expectedMessage + " AND Actual Response Message: " + message);
            }

            //var responseContent = response.Content.ToString();
            //var responseStatusCode = response.StatusCode.ToString();
            //var responseStatusDescription = response.StatusDescription.ToString();
            //var IsSuccessStatusCode = response.IsSuccessStatusCode.ToString();            
            
        }
    }
}
# ArthurWeb1


# Requirements:
Create an ASP.Net MVC website with a page containing a text box to enter a name in and a submit button to search GitHub for the name.

 

Have the back end call the GitHub users API (e.g. https://api.github.com/users/robconery) and get the users name, location and avatar url from the returned json. Use the repos_url value to get a list of all the repos for the user.

 

On the results page, show the username, location, avatar and the 5 repos with the highest stargazer_count.

# Solution: 
In order to fulfill the requirements the UsersController was written. It has "Search" method which returns a view with a text box and a submit button with the help of Razor syntax. The controller has a method of the same name which handles POST request of the form submission. With the use of HttpClient there are 2 requests made to the Github API. There are appropriate API request/response models created. Finally they are combined into UserViewModel which represents the final state, i.e. user details along with their best repositories. It is important to notice the proper usage of HttpClient and the fact that github API requires User-Agent to be set.

The presented approach is the simplest one in a way that the requests to the API are sent from the server side. An alternative approach could be an ajax one. It would be enough to have simple html page with a piece of jquery which would call github API and dynamically append the part of response as html. In that case though there would be no need to use ASP .NET MVC at all.

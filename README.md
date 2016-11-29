# Xamarin & Azure Functions & Azure Queues & SignalR

##Project Outlines

This project mainly answers many of your questions about:

* How to Post a content to a WebAPI service from my Xamarin App?
* How can I work with Azure Queue Storage?
* How can I work with Azure Functions? 
* How can I connect to SignalR Hub from Azure Functions?


Overall Structure of this project looks like

![Image of CommentAnalytics]
(http://www.irmaktevfik.com/content/images/blog/overallstructure.png)

##Project Scenario and further details
* Creating a simple Xamarin App having a text entry and a button to post data to our Http Services. It is a simple project but we will be having a nice repository for you to use on your projects later on.
* Creating a WebAPI project to get the comment text from our mobile app and insert it to our Azure Queue. Again, I have a nice repository for this process for you to use on your further projects.
* Creating our Azure Function to be triggered whenever a record gets inserted into Azure Queue. First this function will connect to Microsot Cognitive Services and pass our comment to be analyzed and we will be receiving a sentiment score (0 negative - 100 positive) for this process.
* Have our SignalR Hub up and running on our server and have our webpage client created (with a simple progress bar to show sentiment score) connected. After we have them up and running, we will jump back to our Azure function to have SignalR package installed and invoke our hub with the sentiment data to show.

### Link for Step By Step Implementation
[IRMAKTEVFIK.COM](http://www.irmaktevfik.com/post/2016/11/24/how-to-use-azure-functions-with-microsoft-cognitive-services-and-signalr-to-process-and-display-data-sent-from-xamarin-app)

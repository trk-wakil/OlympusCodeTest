# OlympusCodeTest
# MY Thoughts

This was a great excercise that got me thinking about different challanges. It has been years since I did anything related to Multi-Threading so I am glad I had the chance to review the topic.
My first thought when approaching the problem was to use Async. methods, but that does not force multiple threads to be created.

I did not put the project in a docker container because I don't have the tool installed on my home laptop. I appologize for the inconvenience this would cause you on your end but I did not want to spend more time before submitting the solution.

I am adding a sample output file but the project should create the folder in the same directory as the exe file.

Handling the exceptions was naturally a challange. I set it up so that they get logged to the console from the actual method. I don't so much like this approach because I would rather raise it to the UI, but with multiple threads running, it was very difficult to accomplish so I was not able to make it happen. I suppose in a fully functional application, the ideal way would be to dump the error messages in a log stream at least.

I created multiple classes separated by logic. One class to handle anything related to file management. And another class to handle the threads work. I ended up making the thread manager class very small with just one method since it turned out to be possible and logically okay to do so. I also decided to pass to it an action rather than an instance of the file class. This way, there is more separation between all the classes.

In the method that does the work on the file, I used Monitor in order to keep the file thread-safe. Clearly this is not the only way to accomplish that goal, but it made sense to me at the time because it allowed me to do lock and then release.


Again, this was an enjoyable excercise. It really made me review concepts I have not worked with for a long while.

Thank you

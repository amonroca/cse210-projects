# cse210-final-project

**To-Do List** 

*Project Proposal*

Nowadays we have many more tasks, appointments, and every kind of duty than we are capable of doing, thereby it is essential to organize our time prioritizing our tasks, defining due dates, and tracking recurrent tasks. To meet this need the to-do list software will allow the user to create and manage three different types of tasks (Regular Tasks, Urgent Tasks, and Recurrent Tasks). In addition, the software will allow the user to create and manage task lists by his/her criteria, but at least three default lists will exist, the Today list, which will contain the Recurrent tasks, the Urgent Tasks list which will contains the urgent tasks, and the Completed task list, which will contain the list of all tasks completed by the user.

Find below some details about the program functionality:

* `Database persistence` - This program works with database persistence, but you don't need to worry about that. The lists with saved tasks are loaded every time you run the program, and every time you act to change entity state, such as creating and deleting tasks or lists, these actions are persisted in the database.
* `Urgent Tasks list` - You are allowed to add only urgent tasks to this list. Thid list cannot be removed.
* `Today list` - You are allowed to add regular and recurret tasks to this list. This list cannot be removed.
* `Completed Tasks list` - You are not allowed to add tasks to this list. The tasks you complete are moved automatically to this list and removed from their origin lists, except recurrent taks. Recurrent tasks are kept in their origin lists and are copied to the Completed Tasks list. This list cannot be removed.
* `Creating/Removing lists` - You are allowed to create lists and remove only the lists you have created. You are allowed to add only regular tasks to the lists you have created.
* `Creating/Removing tasks` - You are allowed to create and remove tasks.
* `Marking task as completed` - When you finish a task you can mark it as completed. This action will move the task marked to the Completed Task list, except recurrent tasks. Recurrent tasks are kept in their origin lists and are copied to the Completed Tasks list. Every time you mark a recurrent task as completed you create a copy of it in the Completed Tasks list.
* `Urgent tasks priority` - Every time you create an urgent task you will be asked to set the task priority. This priority is an integer number between 1 and n. If you try input a number with decimal places or a string you will get an IOException.
* `Scheduled tasks` - You have the option to set due dates for your regular tasks. You must to input the date in the format mm/dd/yyyy. If you input any other date format you will get some date format error.

All these actions you can perform in this program are guided by an interactive menu. If you follow the instructions you will most likely get the expected results.
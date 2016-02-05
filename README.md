This is a basic setup for iTrellis job interview.

The UI is pretty basic using jQuery.

I have unit tests that attempt the edge case scenarios.

The solution is broken into a few different projects. I like to create a
separation of concerns:
- UI - This is where html, javascript, anything for a browser exists. I chose web
forms because I'm most familiar with them
- Service - This is where the brains sits.
- Unit Tests - Unit tests that test the Service layer.
- Models - This is where all the classes sit. I try to reduce logic here.
** Not in this projects **
- Data Access - There is no data storage, but I'd typically have a data access
layer which holds SQL queries or some other data access methods (e.g., Web
service calls.)

I attempted to keep the commit history in logical and legible order.
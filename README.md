# TaskManagementApi
Core Requirements:
Task Management:

CRUD operations for tasks (POST, GET, PUT, DELETE).
Each task should have properties like ID, Title, Description, and DueDate.
Global Exception Handling:

Implement a global exception handler to manage unhandled exceptions.
Handle validation errors with appropriate HTTP status codes (e.g., 400, 404).
Log unexpected errors while providing generic error messages to the client.
Logging with Serilog:

Log task creation, updates, and deletions.
Use log levels (Info, Warning, Error).
Write logs to both console and log files.
No Database (In-Memory Storage):

Use a list or dictionary for storing tasks instead of a database.
Implement task validation to ensure valid data.
Additional (Bonus) Requirement:
Retry Logic with Polly:
Automatically retry API calls for temporary failures (e.g., 500 Internal Server Errors).
Implement an exponential backoff or simple retry policy.
Ensure retries are logged.
Deliverables:
Fully functional API with task management.
Global exception handling with middleware.
Integrated Serilog logging.
Retry logic for 500 errors using Polly (bonus).
Clean, maintainable, and well-documented code.

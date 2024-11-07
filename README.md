# AWS SQS Automation Project

This project contains Python scripts to automate AWS SQS queue operations, including creating a queue, sending a message, receiving the message, verifying it, and deleting the message from the queue.

## Files in This Repository
1. **`create_sqs.py`**: Creates an SQS queue with specified attributes.
2. **`sqs_message_Testing.py`**: Tests sending, receiving, verifying, and deleting messages in the SQS queue.

## Installation
1. **Clone the repository**:
   ```bash
   git clone https://github.com/PunithavathiK/Lorax-SQS-Automation_Punitha.git
   cd Lorax-SQS-Automation_Punitha
   Installed the library boto3
   Configured AWS credentials
   The following contents are the output for the SQS Messaging Automation
   C:\Users\HP\Desktop>create_sqs.py
Queue created successfully. Queue URL: https://sqs.us-west-1.amazonaws.com/783764616269/unique-queue-12345

C:\Users\HP\Desktop>sqs_message.py
Message sent successfully. Message ID: e02bf461-5431-4b5d-888b-fda6b29eac1e
Message received successfully.
Test passed: Sent and received messages match.
Message deleted successfully.

JSON TESTING : 
File Program-Copy.cs file contains the code for JSON Testing of Instantiate, Deserialization, etc..
File Lorax JSON File Output is the output of the JSON Testing

Calculator Automation Testing
File Program.cs contains code for simple calculator arithmetic operations and Calculator Class Output file contains the output for the same.
File UntiTest1.cs contains the code for Calculator Unit test framework testing and the file "Calculator UnitTest Output" contains the output for the same.



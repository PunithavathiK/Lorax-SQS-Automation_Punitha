import boto3
from botocore.exceptions import ClientError
import sys

# Initialize SQS client
sqs = boto3.client('sqs', region_name='us-west-1')

# Use your specific Queue URL
queue_url = 'https://sqs.us-west-1.amazonaws.com/783764616269/unique-queue-12345'

def send_message(queue_url, message_body):
    """Send a message to the SQS queue."""
    try:
        response = sqs.send_message(
            QueueUrl=queue_url,
            MessageBody=message_body
        )
        print("Message sent successfully. Message ID:", response['MessageId'])
        return response['MessageId']
    except ClientError as e:
        print(f"Error sending message: {e}")
        sys.exit(1)

def receive_message(queue_url):
    """Receive a message from the SQS queue."""
    try:
        response = sqs.receive_message(
            QueueUrl=queue_url,
            MaxNumberOfMessages=1,
            WaitTimeSeconds=10
        )
        messages = response.get('Messages', [])
        if messages:
            print("Message received successfully.")
            return messages[0]  # Return the first message
        else:
            print("No messages in queue.")
            return None
    except ClientError as e:
        print(f"Error receiving message: {e}")
        sys.exit(1)

def delete_message(queue_url, receipt_handle):
    """Delete a message from the SQS queue."""
    try:
        sqs.delete_message(
            QueueUrl=queue_url,
            ReceiptHandle=receipt_handle
        )
        print("Message deleted successfully.")
    except ClientError as e:
        print(f"Error deleting message: {e}")

def test_sqs_message_flow():
    # Step 1: Send a message with a unique body
    message_body = "Hello, SQS! Unique Test Message from Punithavathi"
    sent_message_id = send_message(queue_url, message_body)

    # Step 2: Receive the message
    received_message = receive_message(queue_url)
    if received_message is None:
        print("Test failed: No message received.")
        sys.exit(1)

    received_message_id = received_message['MessageId']
    received_message_body = received_message['Body']

    # Step 3: Verify that the received message matches the sent message
    assert sent_message_id == received_message_id, "Message IDs do not match!"
    assert message_body == received_message_body, "Message bodies do not match!"

    print("Test passed: Sent and received messages match.")

    # Step 4: Clean up by deleting the message from the queue
    delete_message(queue_url, received_message['ReceiptHandle'])

try:
    # Run the test
    test_sqs_message_flow()
except AssertionError as error:
    print(f"Test failed: {error}")
except ClientError as e:
    print(f"AWS error occurred: {e}")
except Exception as e:
    print(f"An unexpected error occurred: {e}")

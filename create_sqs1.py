import boto3
from botocore.exceptions import BotoCoreError, ClientError

# AWS credentials
aws_access_key = '****************AB5A'  # Access Key
aws_secret_key = '************************************JSWF'  # Secret Key
region = 'us-west-1'  # Region

# Create an SQS client with the custom credentials
sqs = boto3.client(
    'sqs',
    aws_access_key_id=aws_access_key,
    aws_secret_access_key=aws_secret_key,
    region_name=region
)

# Queue parameters
queue_name = 'unique-queue-12345'  # Unique queue name
attributes = {
    'DelaySeconds': '0',  # (Optional) Set the delay (in seconds) for the messages
    'MessageRetentionPeriod': '86400',  # (Optional) Message retention period (in seconds)
}

# Create the queue
try:
    response = sqs.create_queue(
        QueueName=queue_name,
        Attributes=attributes  # Optional attributes can be set
    )
    print(f"Queue created successfully. Queue URL: {response['QueueUrl']}")
except ClientError as e:
    print(f"Error creating queue: {e}")

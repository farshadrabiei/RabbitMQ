# RabbitMQ

# install Rabbit in docker :
  docker pull rabbitmq:3-management
# Config  docker :
 docker run -d -p 15672:15672 -p 5672:5672 --name rabbit-test-for-medium rabbitmq:3-management

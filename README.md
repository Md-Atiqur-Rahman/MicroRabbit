
Here is Two Microservice
1. **Banking** 
2. **Transfer**

Each Microservice Folder structure is
- **Api**(Controllers,Extensions)
- **Application**(Services,Interfaces,Models)
- **Data**(Context,Repository)
- **Domain** (Command,CommandHandlers,Events,EventHandlers,IRepository,Models)
  
**Banking API**
- SendCommand is passed to the CommandHandler, which then publishes an event via RabbitMQ, automatically creating a queue.
- ex: **CreateTransferCommand** --->**TransferCommandHandler** -->Publish **TransferCreatedEvent**
  
**Transfer API:**
- The published event is configured and subscribed to by the EventBus in Program.cs at line 37.
- By subscribing, the EventHandler will be triggered and process messages from the queue.
- that means: **TransferCreatedEvent** is subscribed on api that call **TransferEventHandler**

**And Three Libraries**

1. MicroRabbit.Domain.Core 
2. MicroRabbit.Infrastructure.Bus
3. MicroRabbit.Infra.IoC
   
**Message Publish,Consume and Subsribe Library**

**3. MicroRabbit.Infrastructure.Bus**

- The RabbitMQBus class implements IEventBus and provides all essential functionalities, including SendCommand, Publish, Consume, and Process.

**IEventBus and Command Library**

this library contain core implementations, including

**4. MicroRabbit.Domain.Core**

   - IEventBus
   - IEventHandler
   - Command
   - Event
   - Message

     
**Core Dependency Injection Library**

**5. MicroRabbit.Infra.IoC**
All the necessary dependencies are registered within this library using Dependency Injection.
- DependencyContainer

**And lastly call from Ui**

**6. MicroRabbit.MVC**

- First, run both the MVC and Banking API projects simultaneously.
- and also start the RabbitMQ container using Docker.
  
`docker run -it --rm --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:4.0-management`
- When you press the submit button, it will call the Banking API, and in the RabbitMQ queue, you will see a queue named TransferCreatedEvent
- Once the message is on the queue, right-click on Transfer.API and select Debug > Start New Instance to begin debugging.
- then it will call **Consumer_Received** --> **ProcessEvent** ---> **TransferCreatedEvent**



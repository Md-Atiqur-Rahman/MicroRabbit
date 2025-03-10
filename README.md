![image](https://github.com/user-attachments/assets/158f58f3-eb04-4dd2-847d-04a5a26597c4)


Here is Two Microservice
1. **Banking** 
2. **Transfer**

Each Microservice Folder structure is
- **Api**(Controllers,Extensions)--->(MediatR,MediatR.Extensions.Microsoft.DependencyInjection,Microsoft.EntityFrameworkCore.InMemory
- **Application**(Services,Interfaces,Models)
- **Data**(Context,Repository)----->(Microsoft.EntityFrameworkCore,Microsoft.EntityFrameworkCore.Design,Microsoft.EntityFrameworkCore.InMemory,Microsoft.EntityFrameworkCore.SqlServer,Microsoft.EntityFrameworkCore.Tools)
- **Domain** (Command,CommandHandlers,Events,EventHandlers,IRepository,Models)

<ins>**Banking API**</ins>
- SendCommand is passed to the CommandHandler, which then publishes an event via RabbitMQ, automatically creating a queue.
- ex: **CreateTransferCommand** --->**TransferCommandHandler** -->Publish **TransferCreatedEvent**
  
<ins> **Transfer API:** </ins>
- The published event is configured and subscribed to by the EventBus in Program.cs at line 37.
- By subscribing, the EventHandler will be triggered and process messages from the queue.
- that means: **TransferCreatedEvent** is subscribed on api that call **TransferEventHandler**

<ins> **And Three Libraries** </ins>

-   MicroRabbit.Domain.Core (MediatR)
-   MicroRabbit.Infrastructure.Bus(MediatR,Microsoft.Extensions.DependencyInjection,Newtonsoft.Json,RabbitMQ.Client)
-   MicroRabbit.Infra.IoC(Microsoft.Extensions.DependencyInjection)
   
<ins> **Message Publish,Consume and Subsribe Library** </ins>

**3. MicroRabbit.Infrastructure.Bus**

- The RabbitMQBus class implements IEventBus and provides all essential functionalities, including SendCommand, Publish, Consume, and Process.

<ins> **IEventBus and Command Library** </ins>

**4. MicroRabbit.Domain.Core**

this library contain core implementations, including

   - IEventBus
   - IEventHandler
   - Command
   - Event
   - Message

     
<ins> **Core Dependency Injection Library** </ins>

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



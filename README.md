Summary
============
This is a demonstration project, I want to prove my programming skills through this project.

Applying Scenario
============
In the current system that I am working for, it needs to receive many kinds of messages from other systems of our company, then these messages will be analyzed and processed, in general, this processing will lead entities located in different domains updates. Based on this scenario, I designed this project according to the SOLID principles.

Concept Explanation
============
Handler:  as its name means, the handler will handle the messages from other systems, then it will introduce a matched workshop and transfer the message to this workshop.

Workshop:  every kind of message has a corresponding workshop, this means one type of message needs one specific workshop to process, the workshop will convert the message which format is XML to a model, and then 	 the workshop will identify the market and dispatch the model to the worker under the market that has been identified.

Market:  similar with multi-tenancy, you can think a market is a tenant, one message will be processed using different logic in different markets.

Worker:  

Process:  

Proxy:  

Diagram
============


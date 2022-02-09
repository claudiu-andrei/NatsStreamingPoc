# NatsStreamingPoc

#Setup - add and configure streaming service
   public void ConfigureServices(IServiceCollection services)
        {        
            services.AddStreamingService("nats://localhost:4222");
        }

#Publish example:
#Inject main Stream Handler class into the service where it's to be used.

  #initialize it in the constructor
  private IStreamHandler Handler { get; }

  #message model must be of this type
  var messageModel = new EventStreamingModel<string>();

  #actual sending of the message
  await Handler.StreamEventSend( messageModel , "strSubject");

#Subscribe example

  #Setup recommended subscribe options
  var subscribeOptions = StanSubscriptionOptions.GetDefaultOptions();
            subscribeOptions.StartAt(DateTime.MinValue);
            subscribeOptions.MaxInflight = 10;
            subscribeOptions.ManualAcks = true;
            subscribeOptions.DurableName = "Szymon";
            
  #perform actual subscribe action
  await streamHandler.StreamEventSubscribe<EventStreamingModel<string>>(
                subscribeOptions, "someSubject", "someGroup", async model =>
                {
                    try
                    {
                        #dummmy action to be done with the received event content
                        Console.WriteLine($"{++i}    Received INT Message: {model.Content}");
                        await Task.Delay(2000);
                    }catch (Exception exc) { }
                });
                
                
                

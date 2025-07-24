using Google.Cloud.Functions.Framework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace appint_dotnet_sample;

public class Function : IHttpFunction
{
  private readonly ILogger logger;

  public Function(ILogger<Function> logger) =>
    this.logger = logger;

  /// <summary>
  /// Logic for your function goes here.
  /// </summary>
  /// <param name="context">The HTTP context, containing the request and the response.</param>
  /// <returns>A task representing the asynchronous operation.</returns>
  public async Task HandleAsync(HttpContext context)
  {
    using (var reader = new System.IO.StreamReader(context.Request.Body))
    {
      string requestBody = await reader.ReadToEndAsync();
      logger.LogInformation("Received order input request: " + requestBody);

      // Deserialize the JSON into an object
      var data = JsonSerializer.Deserialize<Input>(requestBody);
      var result = "";
      if (data != null)
      {
        // Setting TrackingId to new Guid
        Guid myuuid = Guid.NewGuid();
        data.eventParameters.parameters[0].value.protoValue.value.TrackingId = myuuid.ToString();
        // Serialize response
        Output output = new Output();
        OutputParameters outputParameters = new OutputParameters();
        outputParameters.key = "OrderDataOutput";
        outputParameters.value = new OutputParameterValue();
        outputParameters.value.stringValue = JsonSerializer.Serialize<Order>(data.eventParameters.parameters[0].value.protoValue.value);
        output.eventParameters = new OutputEventParameters();
        output.eventParameters.parameters = [outputParameters];
        result = JsonSerializer.Serialize<Output>(output);
      }
      else
      {
        logger.LogError("Could not deserialize Order input request.");
        result = "{'result': 'Could not deserialize order object input.'}";
      }

      logger.LogInformation("Sending order response: " + result);
      await context.Response.WriteAsync(result);
    }
  }

  public class Input
  {
     public EventParameters eventParameters { get; set; }
  }

  public class Output
  {
    public OutputEventParameters eventParameters { get; set; }
  }

  public class EventParameters
  {
    public Parameters[] parameters { get; set; }
  }

  public class OutputEventParameters
  {
    public OutputParameters[] parameters { get; set; }
  }

  public class Parameters
  {
    public string key { get; set; }
    public ParameterValue value { get; set; }
  }

  public class OutputParameters
  {
    public string key { get; set; }
    public OutputParameterValue value { get; set; }
  }

  public class ParameterValue
  {
    public ProtoValue protoValue { get; set; }
  }

  public class OutputParameterValue
  {
    public string stringValue { get; set; }
  }

  public class ProtoValue
  {
    public Order value { get; set; }
  }

  public class Order
  {
    public string OrderId { get; set; }
    public string TrackingId { get; set; }
    public string Description { get; set; }
    public string CustomerId { get; set; }
    public string DateTime { get; set; }
    public decimal TotalValue { get; set; }
    public decimal ItemCount { get; set; }
    public Item[] Items { get; set; }
  }

  public class Item
  {
    public string ItemId { get; set; }
    public string Description { get; set; }
    public decimal Quantity { get; set; }
    public decimal Price { get; set; }
    public string DepartmentId { get; set; }
    public string CategoryId { get; set; }
    public string TaxRate { get; set; }
  }
}
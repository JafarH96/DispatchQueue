# DispatchQueue

Implementation of a DispatchQueue for asynchronous code execution in an easy way, similar to the DispatchQueue in Swift language.

## Usage

You can use the **Main** queue:

```csharp
SerialQueue.main.Async((_) => {
	for (int i = 0; i < 100; i++)
	{
		Console.WriteLine($"From Main Queue {i}");
		Thread.Sleep(1000);
	}
});

```

Or create your own queue and use it separately:

```csharp
SerialQueue myQueue = new SerialQueue();

myQueue.Async((_) => {
	for (int i = 0; i < 100; i++)
	{
		Console.WriteLine($"From My Queue {i}");
		Thread.Sleep(500);
	}
});

```

You can also run codes with a delay:

```csharp
SerialQueue.main.AsyncAfter(milliseconds: 1000, (_) =>
{
	Console.WriteLine("After one second delay");
});

```

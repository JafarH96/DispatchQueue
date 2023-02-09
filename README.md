# DispatchQueue

Implementation of a DispatchQueue for asynchronous code execution in an easy way, similar to the DispatchQueue in Swift language.

## Usage

You can use the **Main** queue:

```csharp
DispatchQueue.main.Async((_) => {
	for (int i = 0; i < 100; i++)
	{
		Console.WriteLine($"From Main Queue {i}");
		Thread.Sleep(1000);
	}
});

```

Or create your own queue and use it separately:

```csharp
DispatchQueue myQueue = new DispatchQueue();

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
DispatchQueue.main.AsyncAfter(milliseconds: 1000, (_) =>
{
	Console.WriteLine("After one second delay");
});

```

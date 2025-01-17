// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using KSTdotnet_training.ConsoleApp3;

//HttpClientExample client = new HttpClientExample();

//await client.ReadAsync();

//await client.EditAsync(101);
//await client.CreateAsync(101, 101, "Testing", "Testing ");

//await client.UpdateAsync(100, 101, "Testing", "Testing ");
//await client.DeleteAsync(50);

RestClientExample client = new RestClientExample();
//await client.ReadAsync();
//await client.EditAsync(101);
//await client.CreateAsync(101, 101, "Testing", "Testing ");
await client.UpdateAsync(50, 50, "Testing", "Testing ");
await client.DeleteAsync(50);

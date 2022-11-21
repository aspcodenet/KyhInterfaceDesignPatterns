// See https://aka.ms/new-console-template for more information

using KyhInterfaceDesignPatterns;

Console.WriteLine("Hello, World!");
var app = new App();
app.Run();

var demo2 = new Demo2();
demo2.Run();


var demo3 = new Demo3();
demo3.Run();


var demoStrategy = new DemoStrategy();
demoStrategy.Run();
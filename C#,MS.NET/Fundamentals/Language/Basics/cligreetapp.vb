Imports Greeting

Module App
	
	Sub Main()

		Dim greeter As New Greeter(True)
		Dim person As String

		Console.Write("Person to greet: ")
		person = Console.ReadLine()
		Console.WriteLine(greeter.Greet(person))

	End Sub

End Module
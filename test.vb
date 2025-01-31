Imports System
Imports System.IO
Imports System.Text
Imports System.Data.SqlClient

Module Program
    Sub Main()
        Dim resultado As Integer = Sumar(5, 10)
        Console.WriteLine("Resultado: " & resultado)

        ' Llamada a función con vulnerabilidad de seguridad
        Dim userInput As String = Console.ReadLine()
        EjecutarConsulta(userInput)
    End Sub

    Function Sumar(a As Integer, b As Integer) As Integer
        Dim suma As Integer
        suma = a + b
        Return suma
    End Function

    ' Problemas intencionales para SonarQube:
    ' 1. Variable no utilizada
    ' 2. Código redundante
    ' 3. Comentarios innecesarios
    ' 4. Posible error de formato
    Sub Problema()
        Dim x As Integer = 10 ' Variable nunca usada
        Console.WriteLine("Este es un problema de código.")
    End Sub

    ' Vulnerabilidad de seguridad: Inyección SQL
    Sub EjecutarConsulta(consulta As String)
        Dim conexion As New SqlConnection("Server=myServer;Database=myDB;User Id=myUser;Password=myPass;")
        Dim comando As New SqlCommand("SELECT * FROM Usuarios WHERE Nombre = '" & consulta & "'", conexion)

        Try
            conexion.Open()
            Dim reader As SqlDataReader = comando.ExecuteReader()
            While reader.Read()
                Console.WriteLine(reader("Nombre").ToString())
            End While
        Catch ex As Exception
            Console.WriteLine("Error: " & ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub
End Module

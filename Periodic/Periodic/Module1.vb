
''' <summary>
''' Define a k-periodic string as follows:
''' A String s Is k-periodic If the length Of the String |s| Is a multiple Of k, And If you chop the
''' String up into |s|/k substrings Of length k, then each of those substrings (except the
''' first) Is the same as the previous substring, but with its last character moved to the
''' front.
''' For example, the following string Is 3-periodic
''' abccabbcaabc
''' The above String can break up into substrings abc, cab, bca, And abc, And Each
''' substring(except the first) Is a right-rotation Of the previous substring (abccab
''' bca abc).
''' Given a String, determine the smallest k For which the String Is k-periodic.
''' Input
''' Each input will consist of a single test case. Note that your program may be run multiple
''' times on different inputs. The single line of input contains a string s (1≤|s|≤100)
''' consisting only Of lowercase letters.
''' Output
''' Output the Integer k, which Is the smallest k For which the input String Is k-periodic
''' </summary>
Module Module1

  Sub Main()
    Doit()
  End Sub

  Public Sub Doit()

    Dim givenLine As String = Console.ReadLine()

    Console.WriteLine(GetMinK(givenLine))
    Console.ReadKey()
  End Sub

  Public Function GetMinK(ByVal givenStr As String) As Integer

    Dim maxK As Integer = givenStr.Length

    For i As Integer = 1 To maxK - 1
      If (IsPeriodic(i, givenStr)) Then Return i
    Next

    Return maxK
  End Function

  Public Function IsPeriodic(ByVal givenK As Integer, ByVal givenStr As String) As Boolean

    If (Not (givenStr.Length Mod givenK = 0)) Then Return False

    Dim curPeriod As String = givenStr.Substring(0, givenK)

    Dim totalPeriods As Integer = givenStr.Length / givenK

    For i As Integer = 1 To totalPeriods - 1
      curPeriod = MoveAround(curPeriod)
      Dim substrPeriod As String = givenStr.Substring((i * givenK), givenK)
      If (Not curPeriod.Equals(substrPeriod)) Then Return False
    Next

    Return True

  End Function

  Public Function MoveAround(ByVal givenStr As String) As String
    Return givenStr.ElementAt(givenStr.Length - 1) & givenStr.Substring(0, givenStr.Length - 1)
  End Function




End Module

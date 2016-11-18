Module Module1

  ''' <summary>
  ''' A Histogram is a visual representation of data. It consists of bars, with the length of each
  ''' bar representing the magnitude of a data quantity. Given some data, produce a
  ''' Histogram.
  ''' Input
  ''' Each input will consist of a single test case. Note that your program may be run multiple
  ''' times on different inputs. The first line of input contains an integer n (1≤n≤100)
  ''' indicating the number Of data items. On Each Of the Next n lines will be a Single Integer k
  ''' (1≤k≤80), which Is the data.
  ''' Output
  ''' Print a histogram, horizontally, Using the '=’ character. Print each data item’s bar on its
  ''' own line, in the order given, with the number Of '=’ equal to the data item k. Print no
  ''' spaces between the '=’.
  ''' </summary>
  Sub Main()
    Doit()
  End Sub

  Public Sub Doit()
    Dim N As Integer = Integer.Parse(Console.ReadLine())

    For i As Integer = 0 To N

      Dim t As Integer = Integer.Parse(Console.ReadLine())

      PrintEquals(t)

    Next
  End Sub

  Public Sub PrintEquals(ByVal number As Integer)
    For i As Integer = 0 To number - 1
      Console.Write("=")
    Next
  End Sub

End Module

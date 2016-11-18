Module Module1

  ''' <summary>
  ''' Consider a 2D grid, which contains apples, obstacles, and open spaces. Gravity will pull
  ''' the apples straight down, until they hit an obstacle, Or the bottom Of the grid, Or
  ''' another apple which has already come To rest. Obstacles don't move. Given such a grid,
  ''' determine where the apples eventually settle.
  ''' Input
  ''' Each input will consist of a single test case. Note that your program may be run multiple
  ''' times on different inputs. The first line of input contains two integers, r And c
  ''' (1≤r,c≤100), which are the number of rows And the number of columns of the grid. On
  ''' each of the next r lines will be c characters: 'o’ (lowercase ‘Oh’) for an apple, ‘#’ for an
  ''' obstacle, And '.’ for an open space.
  ''' Output
  ''' Output the grid, after the apples have fallen
  ''' </summary>
  Sub Main()
    Doit()
  End Sub

  Public Sub Doit()
    Dim line As String() = Console.ReadLine().Split(" ")
    Dim R As Integer = Integer.Parse(line(0)) - 1
    Dim C As Integer = Integer.Parse(line(1)) - 1

    Dim charGrid(R, C) As Char

    For i As Integer = 0 To R
      Dim curLine As Char() = Console.ReadLine().ToCharArray

      For j As Integer = 0 To C
        charGrid(i, j) = curLine(j)
      Next

    Next

    For i As Integer = 0 To C

      Dim curColumn As String = ReadCol(charGrid, i, R)
      Dim fallenCurColumn As String = ColumnFall(curColumn)
      WriteCol(charGrid, i, R, fallenCurColumn)

    Next

    WriteGrid(charGrid, R, C)
    Console.ReadKey()
  End Sub

  Public Sub WriteGrid(ByVal charGrid(,) As Char, ByVal R As Integer, ByVal C As Integer)

    For i As Integer = 0 To R

      For j As Integer = 0 To C
        Console.Write(charGrid(i, j))
      Next
      Console.WriteLine()
    Next

  End Sub

  Public Function ReadCol(ByVal charGrid(,) As Char, ByVal colNum As Integer, ByVal R As Integer) As String

    Dim colResult As String = String.Empty

    For i As Integer = 0 To R
      colResult = colResult & charGrid(i, colNum)
    Next

    Return colResult
  End Function

  Public Sub WriteCol(ByRef charGrid(,) As Char, ByVal colNum As Integer, ByVal R As Integer, ByVal line As String)

    For i As Integer = 0 To R
      charGrid(i, colNum) = line.ElementAt(i)
    Next

  End Sub

  Public Function ColumnFall(ByVal givenLine As String) As String

    For i As Integer = givenLine.Length - 1 To 0 Step -1
      If (givenLine.ElementAt(i) = "o"c) Then givenLine = MoveDownBall(givenLine, i, i)
    Next

    Return givenLine

  End Function

  Public Function MoveDownBall(ByVal givenLine As String, ByVal ballLocation As Integer, ByVal startLocation As Integer) As String
    For j As Integer = startLocation + 1 To givenLine.Length - 1

      Select Case givenLine.ElementAt(j)
        Case "#"c, "o"c
          Exit For
        Case "."c
          givenLine = SwapChars(givenLine, ballLocation, j)
          ballLocation = j
      End Select
    Next

    Return givenLine
  End Function

  Public Function SwapChars(ByVal givenLine As String, ByVal i As Integer, ByVal j As Integer) As String

    Dim plusOneI As Integer = IIf(i + 1 > givenLine.Length, givenLine.Length - 1, i + 1)
    Dim plusOneJ As Integer = IIf(j + 1 > givenLine.Length, givenLine.Length - 1, j + 1)

    givenLine = givenLine.Substring(0, i) & "."c & givenLine.Substring(plusOneI, givenLine.Length - plusOneI)
    givenLine = givenLine.Substring(0, j) & "o"c & givenLine.Substring(plusOneJ, givenLine.Length - plusOneJ)
    Return givenLine
  End Function

End Module

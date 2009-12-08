Imports System.Text.RegularExpressions
Imports System.IO
Imports Longkong.Core.Properties
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.TextHelper
    Public Class StringHelper
        Public Shared Function GetRidOfAtEnd(ByVal value As String, ByVal stringToRemove As String) As String
            value = value.TrimEnd(" "c)
            If value.EndsWith(stringToRemove) Then
                value = value.Remove(value.Length - stringToRemove.Length, stringToRemove.Length)
            End If
            Return value
        End Function
        Public Shared Function GetExcelColumnString(ByVal index As Integer) As String
            Dim firstDigit As String = ""
            Dim secondDigit As String = ""
            If (index - 1) \ 26 > 0 Then
                firstDigit = Chr(((index - 1) \ 26) + 64)
            End If
            secondDigit = Chr((index Mod 26) + 64)
            Return firstDigit & secondDigit
        End Function
        Public Shared Function GetExcelColumnIndex(ByVal colString As String) As Integer
            Dim colStringArray() As Char = colString.ToCharArray
            If colStringArray.Length = 1 Then
                Return Asc(colStringArray(0)) - 64
            End If
            Return CInt((26 ^ (Asc(colStringArray(0)) - 64)) + Asc(colStringArray(0)) - 64)
        End Function
        Public Shared Function CutText(ByVal input As String, ByVal length As Integer) As String
            Dim output As String = CTTEX(input)
            Dim outputs() As String = Split(output, Chr(11))
            Dim ret As String = ""
            For Each tried As String In outputs
                Dim i As Integer = 0
                For Each triedd As String In tried.Split(" "c)
                    Dim sep As String = ""
                    If i <> 0 Then
                        sep = " "
                    End If
                    If (ret & sep & triedd).Length > length Then
                        Return ret
                    End If
                    ret &= sep & triedd
                    i += 1
                Next
            Next
            Return ret
        End Function
        Public Shared Function CutText(ByVal input As String, ByVal pixels As Integer, ByVal g As Graphics, ByVal font As Font) As ArrayList
            Dim output As String = CTTEX(input)
            Dim outputs() As String = output.Split(Chr(11))
            Dim ret As String = ""
            Dim rets As New ArrayList
            For Each tried As String In outputs
                Dim i As Integer = 0
                For Each triedd As String In tried.Split(" "c)
                    Dim sep As String = ""
                    If i <> 0 Then
                        sep = " "
                    End If
                    If CInt(Math.Ceiling(g.MeasureString((ret & sep & triedd), font).Width)) > pixels Then
                        rets.Add(ret)
                        ret = ""
                    End If
                    ret &= sep & triedd
                    i += 1
                Next
            Next
            Return rets
        End Function
        Public Shared Function CTTEX(ByVal input As String) As String
            Dim inputPath As String = Path.GetTempFileName()
            Dim outputPath As String = Path.GetTempFileName()
            Dim err As String
            SaveTextToFile(input & vbCrLf, inputPath, err)
            Dim myPropertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
            Dim thePath As String = myPropertyService.DataDirectory & Path.DirectorySeparatorChar & "resources" & Path.DirectorySeparatorChar & "cttex.exe"
            Dim cmd As String = "/C " & thePath & " 11 < """ & inputPath & """ > """ & outputPath & """"
            Dim pc As Process = New Process
            pc.StartInfo.FileName = "cmd.exe"
            pc.StartInfo.Arguments = cmd
            pc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            pc.StartInfo.CreateNoWindow = True
            pc.Start()
            pc.WaitForExit(3000)
            If Not pc.HasExited Then
                pc.Kill()
            End If
            pc.Close()
            Dim contents As String = GetFileContents(outputPath, err)
            Return contents
        End Function
        Public Shared Function GetFileContents(ByVal FullPath As String, _
        Optional ByRef ErrInfo As String = "") As String

            Dim strContents As String
            Dim objReader As StreamReader
            Try
                objReader = New StreamReader(FullPath, System.Text.Encoding.Default)
                strContents = objReader.ReadToEnd()
                objReader.Close()
                Return strContents
            Catch Ex As Exception
                ErrInfo = Ex.Message
            End Try
        End Function
        Public Shared Function SaveTextToFile(ByVal strData As String, _
        ByVal FullPath As String, _
        Optional ByVal ErrInfo As String = "") As Boolean
            Dim Contents As String
            Dim bAns As Boolean = False
            Dim objReader As StreamWriter

            Try
                objReader = New StreamWriter(FullPath, False, System.Text.Encoding.Default)
                objReader.Write(strData)
                objReader.Close()
                bAns = True
            Catch Ex As Exception
                ErrInfo = Ex.Message
            End Try
            Return bAns
        End Function
    End Class
    Public Class TextParser
        Public Shared Function Evaluate(ByVal expr As String) As Double
            expr = Replace(expr, ",", "")
            If expr.Length = 0 Then
                Return 0
            End If
            ' �ӹǹ ��͡�����§�ѹ�ͧ����Ţ 1 ��Ǣ��� �Ҩ�е������ . ��е���Ţ���� 1 ��Ǣ��� 
            ' ������ǧ��������������� unnamed group 
            Const Num As String = "(\-?\d+\.?\d*)"
            ' List �ͧ 1-operand functions 
            Const Func1 As String = _
            "(exp|log|log10|abs|sqr|sqrt|sin|cos|tan|asin|acos|atan)"
            ' List �ͧ 2-operands functions 
            Const Func2 As String = "(atan2)"
            ' List �ͧ N-operands functions 
            Const FuncN As String = "(min|max)"
            ' List �ͧ��Ҥ���� 
            Const Constants As String = "(e|pi)"

            ' Define ���� Regex object ����Ѻ���� operation 
            Dim rePower As New Regex(Num & "\s*(\^)\s*" & Num)
            Dim reAddSub As New Regex(Num & "\s*([-+])\s*" & Num)
            Dim reMulDiv As New Regex(Num & "\s*([*/])\s*" & Num)
            ' Regex objects �꧹��� resolve ������¡ functions 
            Dim reFunc1 As New Regex(Func1 & "\(\s*" & Num & "\s*\)", _
            RegexOptions.IgnoreCase)
            Dim reFunc2 As New Regex(Func2 & _
            "\(\s*" & Num & "\s*,\s*" & Num & "\s*\)", RegexOptions.IgnoreCase)
            Dim reFuncN As New Regex(FuncN & _
            "\((\s*" & Num & "\s*,)+\s*" & Num & "\s*\)", RegexOptions.IgnoreCase)
            ' ��� + �͡��ҵ����ѧ operator ��� 
            Dim reSign1 As New Regex("([-+/*^])\s*\+")
            '-- �� �ǡ 
            Dim reSign2 As New Regex("\-\s*-")
            '��� () �͡�ҡ����Ţ (��ǧ��纵�ͧ�������ѧ����ѡ�� ���й���Ҩ�繪��� function) 
            Dim rePar As New Regex("(?<![A-Za-z0-9])\(\s*([-+]?\d+.?\d*)\s*\)")
            '�ѹ���͡������������������ 
            'Dim reNum As New Regex("^\s*[-+]?\d+\.?\d*\s*$")
            Dim reNum As New Regex("^\s*[-+]?(\d+)*\.?\d*\s*$")

            '�ѹ���Ѵ��áѺ constants 
            Dim reConst As New Regex("\s*" & Constants & "\s*", RegexOptions.IgnoreCase)
            '�Ѵ����ѹ(constants) �� 
            expr = reConst.Replace(expr, AddressOf DoConstants)

            '*************************************************** 
            ' Loop ������ expr �С�������ӹǹ 
            '*************************************************** 
            Do Until reNum.IsMatch(expr)
                '�� expr ������ 
                Dim saveExpr As String = expr

                '¡���ѧ��͹ 
                Do While rePower.IsMatch(expr)
                    expr = rePower.Replace(expr, AddressOf DoPower)
                Loop

                ' �ٳ/��� ����� 
                Do While reMulDiv.IsMatch(expr)
                    expr = reMulDiv.Replace(expr, AddressOf DoMulDiv)
                Loop

                'function ���� arguments 
                Do While reFuncN.IsMatch(expr)
                    expr = reFuncN.Replace(expr, AddressOf DoFuncN)
                Loop

                'function with 2 arguments 
                Do While reFunc2.IsMatch(expr)
                    expr = reFunc2.Replace(expr, AddressOf DoFunc2)
                Loop

                'function with 1 argument 
                Do While reFunc1.IsMatch(expr)
                    expr = reFunc1.Replace(expr, AddressOf DoFunc1)
                Loop

                '��� unary pluses �͡ 
                expr = reSign1.Replace(expr, "$1")
                'źź�繺ǡ 
                expr = reSign2.Replace(expr, "+")

                '�ǡź 
                Do While reAddSub.IsMatch(expr)
                    expr = reAddSub.Replace(expr, AddressOf DoAddSub)
                Loop

                ' ��� () �͡�ҡ����Ţ 
                expr = rePar.Replace(expr, "$1")

                '����ѹ��ҹ Process ��Һ͢�ҧ����������з��з�ҹ ����� syntax error 
                If expr = saveExpr Then Throw New SyntaxErrorException("Invalid input")
            Loop
            Return CDbl(expr)
        End Function

        Private Shared Function DoConstants(ByVal m As Match) As String
            Select Case m.Groups(1).Value.ToUpper
                Case "PI"
                    Return Math.PI.ToString
                Case "E"
                    Return Math.E.ToString
            End Select
        End Function

        Private Shared Function DoPower(ByVal m As Match) As String
            Dim n1 As Double = CDbl(m.Groups(1).Value)
            Dim n2 As Double = CDbl(m.Groups(3).Value)
            ' Groups(3) ��� "^" ����ͧ 
            Return (n1 ^ n2).ToString
        End Function

        Private Shared Function DoMulDiv(ByVal m As Match) As String
            Dim n1 As Double = CDbl(m.Groups(1).Value)
            Dim n2 As Double = CDbl(m.Groups(3).Value)
            Select Case m.Groups(2).Value
                Case "/"
                    Return (n1 / n2).ToString
                Case "*"
                    Return (n1 * n2).ToString
            End Select
        End Function

        Private Shared Function DoAddSub(ByVal m As Match) As String
            Dim n1 As Double = CDbl(m.Groups(1).Value)
            Dim n2 As Double = CDbl(m.Groups(3).Value)
            Select Case m.Groups(2).Value
                Case "+"
                    Return (n1 + n2).ToString
                Case "-"
                    Return (n1 - n2).ToString
            End Select
        End Function

        Private Shared Function DoFunc1(ByVal m As Match) As String
            'Group(2) ��� argument 
            Dim n1 As Double = CDbl(m.Groups(2).Value)
            'Groups(1) ��ͪ��� function 
            Select Case m.Groups(1).Value.ToUpper
                Case "EXP"
                    Return Math.Exp(n1).ToString
                Case "LOG"
                    Return Math.Log(n1).ToString
                Case "LOG10"
                    Return Math.Log10(n1).ToString
                Case "ABS"
                    Return Math.Abs(n1).ToString
                Case "SQR", "SQRT"
                    Return Math.Sqrt(n1).ToString
                Case "SIN"
                    Return Math.Sin(n1).ToString
                Case "COS"
                    Return Math.Cos(n1).ToString
                Case "TAN"
                    Return Math.Tan(n1).ToString
                Case "ASIN"
                    Return Math.Asin(n1).ToString
                Case "ACOS"
                    Return Math.Acos(n1).ToString
                Case "ATAN"
                    Return Math.Atan(n1).ToString
            End Select
        End Function

        Private Shared Function DoFunc2(ByVal m As Match) As String
            'arguments 2 ��Ǥ�� Groups(2),Groups(3) 
            Dim n1 As Double = CDbl(m.Groups(2).Value)
            Dim n2 As Double = CDbl(m.Groups(3).Value)
            'Groups(1) ��ͪ��� function 
            Select Case m.Groups(1).Value.ToUpper
                Case "ATAN2"
                    Return Math.Atan2(n1, n2).ToString
            End Select
        End Function

        Private Shared Function DoFuncN(ByVal m As Match) As String
            'arguments ��� ����� Groups(2) �繵�� 
            Dim args As New ArrayList
            Dim i As Integer = 2
            Do While m.Groups(i).Value <> ""
                args.Add(CDbl(m.Groups(i).Value.Replace(","c, " "c)))
                i += 1
            Loop
            'Groups(1) ��ͪ��� function 
            Select Case m.Groups(1).Value.ToUpper
                Case "MIN"
                    args.Sort()
                    Return args(0).ToString
                Case "MAX"
                    args.Sort()
                    Return args(args.Count - 1).ToString
            End Select
        End Function
    End Class

#Region "CSI Parser"
    Public Class CSIParser
        Public Shared Function GetCSIFromFile(ByVal fileName As String) As ArrayList
            Dim re As New Regex("(?<Code>\d{2}\s\d{2}\s\d{2}(?:\.\d{2})?)\s*(?<Description>(?:(?!\d{2}\s\d{2}\s\d{2}(?:\.\d{2})?).)*)")
            Dim reader As StreamReader = File.OpenText(fileName)
            Dim content As String = reader.ReadToEnd
            Dim ar As New ArrayList
            For Each m As Match In re.Matches(content)
                ar.Add(New String() {m.Groups("Code").Value, m.Groups("Description").Value})
            Next
            reader.Close()
            Return ar
        End Function
    End Class
#End Region



End Namespace
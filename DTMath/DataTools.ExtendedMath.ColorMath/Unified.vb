﻿Imports System.Runtime.InteropServices
Imports System.ComponentModel
Imports System.Drawing
Imports DataTools.Memory
Imports System.Reflection
Imports DataTools.Strings

Namespace ColorMath

#Region "System, WinForms and WPF : Color, Point, Size and Rect"


#Region "UniColor"

    ''' <summary>
    ''' Formatting flags for UniColor.ToString(format)
    ''' </summary>
    ''' <remarks></remarks>
    <Flags>
    Public Enum UniColorFormatOptions
        ''' <summary>
        ''' Displays the color name of a named color or web-formatted color hex code.
        ''' </summary>
        ''' <remarks></remarks>
        [Default] = 0

        ''' <summary>
        ''' Prints the decimal number for the value.
        ''' </summary>
        ''' <remarks></remarks>
        DecimalDigit = 1

        ''' <summary>
        ''' Returns HTML-style hex code color syntax.
        ''' </summary>
        ''' <remarks></remarks>
        Hex = 2

        ''' <summary>
        ''' Returns C-style hex code.
        ''' </summary>
        ''' <remarks></remarks>
        CStyleHex = 2 Or 4

        ''' <summary>
        ''' Returns VB-style hex code.
        ''' </summary>
        ''' <remarks></remarks>
        VBStyleHex = 2 Or 8

        ''' <summary>
        ''' Returns assembly-style hex code.
        ''' </summary>
        ''' <remarks></remarks>
        AsmStyleHex = 2 Or 16

        ''' <summary>
        ''' Returns a web style hex code.
        ''' </summary>
        ''' <remarks></remarks>
        WebStyleHex = 2 Or 512

        ''' <summary>
        ''' Returns space-separated values.
        ''' </summary>
        ''' <remarks></remarks>
        Spaced = 32

        ''' <summary>
        ''' Returns comma-separated values.
        ''' </summary>
        ''' <remarks></remarks>
        CommaDelimited = 64

        ''' <summary>
        ''' Returns the RGB decimal values.
        ''' </summary>
        ''' <remarks></remarks>
        Rgb = 128

        ''' <summary>
        ''' Returns the ARGB decimal values.
        ''' </summary>
        ''' <remarks></remarks>
        Argb = 256

        ''' <summary>
        ''' Prints in web-ready format.  Cannot be used alone.
        ''' </summary>
        ''' <remarks></remarks>
        WebFormat = 512

        ''' <summary>
        ''' Adds rgb() enclosure for the web.
        ''' </summary>
        ''' <remarks></remarks>
        RgbWebFormat = 512 Or 128 Or 64

        ''' <summary>
        ''' Adds argb() enclosure for the web.
        ''' </summary>
        ''' <remarks></remarks>
        ArgbWebFormat = 512 Or 256 Or 64

        ''' <summary>
        ''' Prints the #RRGGBB web format color code.
        ''' </summary>
        ''' <remarks></remarks>
        HexRgbWebFormat = 512 Or 2 Or 128

        ''' <summary>
        ''' Prints the #AARRGGBB web format color code.
        ''' </summary>
        ''' <remarks></remarks>
        HexArgbWebFormat = 512 Or 2 Or 256

        ''' <summary>
        ''' Add details to a named color such as opacity level and hex code in brackets (if Hex is specifed).
        ''' </summary>
        ''' <remarks></remarks>
        DetailNamedColors = &H2000

        ''' <summary>
        ''' Reverses the order of the numbers.
        ''' </summary>
        ''' <remarks></remarks>
        Reverse = &H4000

        ''' <summary>
        ''' Print hex letters in lower case.
        ''' </summary>
        ''' <remarks></remarks>
        LowerCase = &H8000

    End Enum

    ''' <summary>
    ''' Powerful 32-bit color structure with many features including automatic
    ''' casting to System.Windows.Media.Color and System.Drawing.Color and
    ''' an array of formatting options and string parsing abilities.
    '''
    ''' Supports the catalog of all named colors for WPF and WinForms
    ''' with automatic named-color detection and smart opacity handling.
    '''
    ''' Unlike other structures such as these, the A, R, G, and B channels
    ''' can all be set by the user, independently.
    '''
    ''' The structure is binary compatible with 32-bit color values,
    ''' and can be used in any interop call that requires such a value,
    ''' without any modification or type coercion.
    ''' </summary>
    ''' <remarks></remarks>
    <StructLayout(LayoutKind.Explicit, CharSet:=CharSet.Unicode)>
    Public Structure UniColor

        <FieldOffset(0)>
        Private _Value As UInteger


        <FieldOffset(0)>
        Private _intvalue As Integer


        <FieldOffset(3)>
        Private _A As Byte

        <FieldOffset(2)>
        Private _R As Byte

        <FieldOffset(1)>
        Private _G As Byte

        <FieldOffset(0)>
        Private _B As Byte


        ''' <summary>
        ''' Indicates whether the default behavior of ToString() is to display a detailed description of the current named color.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Property DetailedDefaultToString As Boolean = False

        ''' <summary>
        ''' Gets or sets the 32 bit unsigned integer value of this color.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Value As UInteger
            Get
                Value = _Value
            End Get
            Set(value As UInteger)
                _Value = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the 32 bit signed integer value of this color.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property IntValue As Integer
            Get
                Return _intvalue
            End Get
            Set(value As Integer)
                _intvalue = value
            End Set
        End Property

#Region "Color Channels"

        ''' <summary>
        ''' Alpha channel
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property A As Byte
            Get
                Return _A
            End Get
            Set(value As Byte)
                _A = value
            End Set
        End Property

        ''' <summary>
        ''' Red channel
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property R As Byte
            Get
                Return _R
            End Get
            Set(value As Byte)
                _R = value
            End Set
        End Property

        ''' <summary>
        ''' Green channel
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property G As Byte
            Get
                Return _G
            End Get
            Set(value As Byte)
                _G = value
            End Set
        End Property

        ''' <summary>
        ''' Blue channel
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property B As Byte
            Get
                Return _B
            End Get
            Set(value As Byte)
                _B = value
            End Set
        End Property

#End Region

#Region "Array Methods"

        ''' <summary>
        ''' Gets the byte array for the current color.
        ''' </summary>
        ''' <param name="reverse">True to return a reversed array.</param>
        ''' <returns>An array of 4 bytes.</returns>
        ''' <remarks></remarks>
        Public Function GetBytes(Optional reverse As Boolean = False) As Byte()
            GetBytes = Internal.ToBytes(_Value)
            If Not reverse Then Array.Reverse(GetBytes)
        End Function

        ''' <summary>
        ''' Sets the color from the byte array.
        ''' </summary>
        ''' <param name="b">The input byte array.</param>
        ''' <param name="reversed">True if the input array is reversed.</param>
        ''' <returns>True if successful.</returns>
        ''' <remarks></remarks>
        Public Function SetBytes(b() As Byte, Optional reversed As Boolean = False) As Boolean
            If reversed Then Array.Reverse(b)
            _Value = Internal.ToUInteger(b, 0)
            Return True
        End Function

        ''' <summary>
        ''' Gets the values as an array of integers
        ''' </summary>
        ''' <param name="reverse">True to return a reversed array.</param>
        ''' <returns>An array of 4 integers.</returns>
        ''' <remarks></remarks>
        Public Function GetIntegers(Optional reverse As Boolean = False) As Integer()
            Dim b() As Byte = GetBytes(reverse)
            Dim i() As Integer

            ReDim i(b.Length - 1)

            For x = 0 To 3
                i(x) = b(x)
            Next

            Return i
        End Function

        ''' <summary>
        ''' Sets the color values from an integer array.
        ''' </summary>
        ''' <param name="i"></param>
        ''' <param name="reversed">True if the input array is reversed.</param>
        ''' <returns>True if successful.  Overflows are not excepted.</returns>
        ''' <remarks></remarks>
        Public Function SetIntegers(i() As Integer, Optional reversed As Boolean = False) As Boolean
            If i.Length <> 4 Then Return False
            Dim b(3) As Byte

            For x = 0 To 3

                If i(x) < 0 OrElse i(x) > 255 Then Return False
                b(x) = CByte(i(x))
            Next

            SetBytes(b, reversed)
            Return True
        End Function

#End Region

#Region "Instantiation"

        ''' <summary>
        ''' Initialize a new UniColor structure with the given UInteger
        ''' </summary>
        ''' <param name="color"></param>
        ''' <remarks></remarks>
        Public Sub New(color As UInteger)
            _Value = color
        End Sub

        ''' <summary>
        ''' Initialize a new UniColor structure with the given Integer
        ''' </summary>
        ''' <param name="color"></param>
        ''' <remarks></remarks>
        Public Sub New(color As Integer)
            IntValue = color
        End Sub


        ''' <summary>
        ''' Initialize a new UniColor structure with a color of the given name. 
        ''' If the name is not found, an argument exception is throw.
        ''' </summary>
        ''' <param name="Color">The name of the color to create.</param>
        ''' <remarks></remarks>
        Public Sub New(Color As String, Optional ByRef succeed As Boolean = Nothing)
            Dim c As System.Drawing.Color,
            c2 As System.Windows.Media.Color

            c = UniColor.TryFindNamedWinFormsColor(Color, succeed)
            If Not succeed Then
                c2 = UniColor.TryFindNamedWPFColor(Color, succeed)
                If Not succeed Then
                    Return
                Else
                    _A = c2.A
                    _R = c2.R
                    _G = c2.G
                    _B = c2.B
                End If
            Else
                _intvalue = c.ToArgb
            End If

        End Sub

        ''' <summary>
        ''' Initialize a new UniColor structure with the given ARGB values.
        ''' </summary>
        ''' <param name="a">Alpha</param>
        ''' <param name="r">Red</param>
        ''' <param name="g">Green</param>
        ''' <param name="b">Blue</param>
        ''' <remarks></remarks>
        Public Sub New(a As Byte, r As Byte, g As Byte, b As Byte)
            Me.A = a
            Me.R = r
            Me.G = g
            Me.B = b
        End Sub

#End Region

#Region "ToString and Parse"

        ''' <summary>
        ''' Converts this color structure into its string representation.
        ''' DetailedDefaultToString affects the behavior of this function.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overloads Overrides Function ToString() As String
            Return ToString(UniColorFormatOptions.Default)
        End Function

        ''' <summary>
        ''' Richly format the color for a variety of scenarios including named color detection.
        ''' </summary>
        ''' <param name="format">Extensive formatting flags.  Some may not be used in conjunction with others.</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overloads Function ToString(format As UniColorFormatOptions) As String

            Dim hexCase As String = If(format And UniColorFormatOptions.LowerCase, "x", "X")

            Dim argbVals() As Integer = GetIntegers(format And UniColorFormatOptions.Reverse)
            Dim argbStrs() As String = Nothing

            Dim str1 As String = "",
            str2 As String = ""

            Dim i As Integer,
            c As Integer

            If (format And UniColorFormatOptions.DecimalDigit) Then

                If (format And UniColorFormatOptions.CommaDelimited) Then
                    Return _Value.ToString("#,##0")
                Else
                    Return _Value.ToString()
                End If

            ElseIf (format And UniColorFormatOptions.HexRgbWebFormat) = UniColorFormatOptions.HexRgbWebFormat Then

                Return "#" & (_Value And &HFFFFFF).ToString(hexCase & "6")

            ElseIf ((format And UniColorFormatOptions.HexArgbWebFormat) = UniColorFormatOptions.HexArgbWebFormat) OrElse (format = UniColorFormatOptions.Default) _
            OrElse ((format And (UniColorFormatOptions.DetailNamedColors Or UniColorFormatOptions.Hex)) > UniColorFormatOptions.Hex) Then

                str2 = "#" & (_Value And &HFFFFFFFF).ToString(hexCase & "8")
                str1 = TryGetColorName(Me)

                If ((format And (UniColorFormatOptions.DetailNamedColors Or UniColorFormatOptions.Hex)) > UniColorFormatOptions.Hex) _
                OrElse ((format = UniColorFormatOptions.Default) And (DetailedDefaultToString = True)) Then

                    If str1 IsNot Nothing Then

                        If Me.A = 255 Then
                            Return str1 & " [" & str2 & "]"
                        End If

                        Dim ax As Double = Me.A
                        ax = (ax / 255) * 100

                        str1 &= " (" & ax.ToString("0") & "% Opacity"

                        If format And UniColorFormatOptions.Hex Then
                            str1 &= ", [" & str2 & "])"
                        Else
                            str1 &= ")"
                        End If

                        Return str1
                    End If
                ElseIf format = UniColorFormatOptions.Default AndAlso str1 IsNot Nothing Then
                    Return str1
                End If

                Return str2

            ElseIf (format And UniColorFormatOptions.Hex) Then

                str1 = ""

                If (format And UniColorFormatOptions.Argb) = UniColorFormatOptions.Argb Then
                    c = 3
                    ReDim argbStrs(3)
                    For i = 0 To 3
                        str1 &= argbVals(i).ToString(hexCase & "2")
                    Next
                ElseIf (format And UniColorFormatOptions.Rgb) = UniColorFormatOptions.Rgb Then
                    c = 2
                    ReDim argbStrs(2)
                    For i = 0 To 2
                        str1 &= argbVals(i).ToString(hexCase & "2")
                    Next
                Else
                    Throw New ArgumentException("Must specify either Argb or Rgb in the format flags.")
                End If

                If format And UniColorFormatOptions.AsmStyleHex Then
                    For i = 0 To c
                        str1 &= "h"
                    Next
                ElseIf format And UniColorFormatOptions.CStyleHex Then
                    For i = 0 To c
                        str1 = "0x" & str1
                    Next
                ElseIf format And UniColorFormatOptions.VBStyleHex Then
                    For i = 0 To c
                        str1 = "&H" & str1
                    Next
                ElseIf format And UniColorFormatOptions.WebStyleHex Then
                    For i = 0 To c
                        str1 = "#" & str1
                    Next
                End If

                Return str1

            Else
                If (format And UniColorFormatOptions.Argb) = UniColorFormatOptions.Argb Then
                    c = 3
                    ReDim argbStrs(3)
                    For i = 0 To 3
                        argbStrs(i) = CStr(argbVals(i))
                    Next
                ElseIf (format And UniColorFormatOptions.Rgb) Then
                    c = 2
                    ReDim argbStrs(2)
                    For i = 0 To 2
                        argbStrs(i) = CStr(argbVals(i))
                    Next
                Else
                    Throw New ArgumentException("Must specify either Argb or Rgb in the format flags.")
                End If
            End If

            If (format And UniColorFormatOptions.ArgbWebFormat) = UniColorFormatOptions.ArgbWebFormat Then
                If (format And UniColorFormatOptions.Reverse) Then
                    str1 = "bgra("
                Else
                    str1 = "argb("
                End If

                str2 = ")"
            ElseIf (format And UniColorFormatOptions.RgbWebFormat) = UniColorFormatOptions.RgbWebFormat Then
                If (format And UniColorFormatOptions.Reverse) Then
                    str1 = "bgr("
                Else
                    str1 = "rgb("
                End If

                str2 = ")"
            End If

            For i = 0 To c
                If i > 0 Then
                    If (format And UniColorFormatOptions.CommaDelimited) Then
                        str1 &= ","
                    End If

                    If (format And UniColorFormatOptions.Spaced) Then
                        str1 &= " "
                    End If
                End If

                str1 &= argbStrs(i)
            Next

            str1 &= str2

            Return str1
        End Function

        ''' <summary>
        ''' Parse a string value into a new UniColor structure.
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function Parse(value As String) As UniColor
            Dim ch As New List(Of Char),
            a As Integer

            Dim s() As String

            Dim i As Integer = 0,
            c As Integer

            Dim t As String
            Dim l() As Integer

            Dim flip As Boolean = False

            '' if this is a straight integer value, we can return a new color right away.
            Dim x As Boolean = Integer.TryParse(value.Trim, i)
            If x Then
                Return New UniColor(i)
            End If

            '' on with the show!

            '' first let's parse some separated values, here.

            value = value.ToLower

            If value.Substring(0, 5) = "argb(" Then

                value = value.Substring(5).Replace(")", "")

            ElseIf value.Substring(0, 4) = "rgb(" Then

                value = value.Substring(4).Replace(")", "")

            ElseIf value.Substring(0, 5) = "bgra(" Then

                value = value.Substring(5).Replace(")", "")
                flip = True

            ElseIf value.Substring(0, 4) = "bgr(" Then
                value = value.Substring(4).Replace(")", "")
                flip = True

            End If

            If value.IndexOf(",") >= 0 OrElse value.IndexOf(" ") >= 0 Then

                If value.IndexOf(",") >= 0 Then
                    s = BatchParse(value, ",")
                Else
                    s = BatchParse(value, " ")
                End If

                If s.Count < 3 OrElse s.Count > 4 Then
                    Throw New InvalidCastException("That string cannot be converted into a color")
                End If

                c = s.Count - 1

                ReDim l(c)

                Dim b As Boolean = True
                Dim by As Byte

                For i = 0 To c
                    t = s(i)
                    t = t.Trim

                    If Not IsHex(t, l(i)) Then
                        If IsNumber(t) = False OrElse Byte.TryParse(t, by) = False Then
                            b = False
                            Exit For
                        Else
                            l(i) = by
                        End If
                    Else
                        If (l(i) > 255) OrElse (l(i) < 0) Then
                            b = False
                            Exit For
                        End If
                    End If
                Next

                If flip Then Array.Reverse(l)

                If b = True Then
                    Dim u As New UniColor

                    Select Case c + 1
                        Case 3
                            u.A = 255
                            u.R = l(0)
                            u.G = l(1)
                            u.B = l(2)

                        Case 4
                            u.A = l(0)
                            u.R = l(1)
                            u.G = l(2)
                            u.B = l(3)

                    End Select

                    Return u
                Else
                    Throw New InvalidCastException("That string cannot be converted into a color")
                End If

            End If

            value = NoSpace(value)

            '' First, let's see if it's a name:
            Dim b1 As Boolean = False, b2 As Boolean = False

            Dim c1 As System.Windows.Media.Color = TryFindNamedWPFColor(value, b1)
            Dim c2 As System.Drawing.Color = TryFindNamedWinFormsColor(value, b2)

            If b1 Then Return CType(c1, UniColor)
            If b2 Then Return CType(c2, UniColor)

            '' okay, it's not a name, let's see if it's some kind of number.
            Dim chIn As String = value
            c = chIn.Length - 1

            If IsHex(chIn, a) Then
                Return New UniColor(a)
            Else
                Throw New InvalidCastException("That string cannot be converted into a color")
            End If

        End Function

#End Region

#Region "Shared Methods"

        ''' <summary>
        ''' Determine if something is hex, and optionally return its value.
        ''' </summary>
        ''' <param name="value"></param>
        ''' <param name="result"></param>
        ''' <returns></returns>
        ''' <remarks>This may replace my main IsHex function in the DataTools library.</remarks>
        Private Shared Function IsHex(value As String, Optional ByRef result As Integer = 0) As Boolean
            Dim chIn As String = value

            Select Case chIn.Chars(0)

                Case "#"c
                    If chIn.Length = 1 Then Return False
                    chIn = chIn.Substring(1)

                Case "0"c

                    If chIn.Length = 1 Then Exit Select

                    If chIn.Chars(1) <> "x"c AndAlso IsNumber(chIn(1)) = False Then
                        Return False
                    ElseIf chIn.Chars(1) = "x"c Then
                        chIn = chIn.Substring(2)
                    End If

                Case "&"c

                    If chIn.Length = 1 Then Return False
                    If chIn.Chars(1) <> "H"c Then
                        Return False
                    End If

                    chIn = chIn.Substring(2)

            End Select

            If chIn.Length > 1 Then
                If chIn.Chars(chIn.Length - 1) = "h"c Then
                    chIn = chIn.Substring(0, chIn.Length - 1)
                End If
            End If

            Dim n As Integer = 0,
            b As Boolean

            b = Integer.TryParse(chIn, Globalization.NumberStyles.AllowHexSpecifier, System.Globalization.CultureInfo.CurrentCulture, n)

            If b Then result = n
            Return b

        End Function

        ''' <summary>
        ''' Try to find the System.Windows.Media.Color for the given color name.
        ''' </summary>
        ''' <param name="name"></param>
        ''' <param name="succeed"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function TryFindNamedWPFColor(name As String, ByRef succeed As Boolean) As System.Windows.Media.Color

            Dim c As New System.Windows.Media.Color

            succeed = NameToSharedProp(Of System.Windows.Media.Color)(name, c, GetType(System.Windows.Media.Colors), False)

            Return c
        End Function

        ''' <summary>
        ''' Try to find the System.Drawing.Color for the given color name.
        ''' </summary>
        ''' <param name="name"></param>
        ''' <param name="succeed"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function TryFindNamedWinFormsColor(name As String, ByRef succeed As Boolean) As System.Drawing.Color

            Dim c As New System.Drawing.Color

            succeed = NameToSharedProp(Of System.Drawing.Color)(name, c, GetType(System.Drawing.Color), False)

            Return c

        End Function

        ''' <summary>
        ''' Attempt to retrieve a color name for a specific color.
        ''' </summary>
        ''' <param name="Color"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function TryGetColorName(Color As UniColor) As String

            Dim cc As UniColor = Color

            '' Make sure we have nothing errant and transparent.
            cc.A = 255

            Dim s As String = SharedPropToName(Of System.Windows.Media.Color)(CType(cc, System.Windows.Media.Color), GetType(System.Windows.Media.Colors))

            If s Is Nothing OrElse s = "" Then
                s = SharedPropToName(Of System.Drawing.Color)(CType(Color, System.Drawing.Color), GetType(System.Drawing.Color))
            End If

            Return s

        End Function

#End Region

#Region "Operators"

        Public Shared Narrowing Operator CType(value As UniColor) As System.Windows.Media.Color
            Return New System.Windows.Media.Color With {.A = value.A, .R = value.R, .G = value.G, .B = value.B}
        End Operator

        Public Shared Widening Operator CType(value As System.Windows.Media.Color) As UniColor
            Dim uc As New UniColor
            uc.R = value.R
            uc.G = value.G
            uc.B = value.B
            uc.A = value.A
            Return uc
        End Operator

        Public Shared Widening Operator CType(value As UniColor) As System.Drawing.Color
            Return System.Drawing.Color.FromArgb(value.IntValue)
        End Operator

        Public Shared Widening Operator CType(value As System.Drawing.Color) As UniColor
            Return New UniColor(value.ToArgb)
        End Operator

        Public Shared Widening Operator CType(value As UniColor) As Integer
            Return value.IntValue
        End Operator

        Public Shared Widening Operator CType(value As Integer) As UniColor
            Return New UniColor(value)
        End Operator

        Public Shared Widening Operator CType(value As UniColor) As UInteger
            Return value._Value
        End Operator

        Public Shared Widening Operator CType(value As UInteger) As UniColor
            Return New UniColor(value)
        End Operator

        Public Shared Narrowing Operator CType(value As String) As UniColor
            Return Parse(value)
        End Operator

        Public Shared Widening Operator CType(value As UniColor) As String
            Return value.ToString
        End Operator

#End Region

    End Structure

#End Region

    ''' <summary>
    ''' Unified point structure for WinForms, WPF and the Win32 API.
    ''' </summary>
    ''' <remarks></remarks>
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)>
    Public Structure UniPoint
        Public Location As POINTAPI

        Public Property X As Integer
            Get
                Return Location.x
            End Get
            Set(value As Integer)
                Location.x = value
            End Set
        End Property

        Public Property Y As Integer
            Get
                Return Location.y
            End Get
            Set(value As Integer)
                Location.y = value
            End Set
        End Property

        Public Shared Widening Operator CType(operand As UniPoint) As System.Drawing.PointF
            Return New System.Drawing.Point(operand.X, operand.Y)
        End Operator

        Public Shared Narrowing Operator CType(operand As System.Drawing.PointF) As UniPoint
            Return New UniPoint(operand.X, operand.Y)
        End Operator

        Public Shared Widening Operator CType(operand As UniPoint) As System.Drawing.Point
            Return New System.Drawing.Point(operand.X, operand.Y)
        End Operator

        Public Shared Narrowing Operator CType(operand As System.Drawing.Point) As UniPoint
            Return New UniPoint(operand)
        End Operator

        Public Shared Widening Operator CType(operand As UniPoint) As System.Windows.Point
            Return New System.Windows.Point(operand.X, operand.Y)
        End Operator

        Public Shared Narrowing Operator CType(operand As System.Windows.Point) As UniPoint
            Return New UniPoint(operand)
        End Operator

        Public Shared Widening Operator CType(operand As UniPoint) As POINTAPI
            Return New POINTAPI(operand.X, operand.Y)
        End Operator

        Public Shared Narrowing Operator CType(operand As POINTAPI) As UniPoint
            Return New UniPoint(operand)
        End Operator

        Public Overrides Function ToString() As String
            Return String.Format("{0}, {1}", X, Y)
        End Function

        Public Sub New(p As System.Drawing.Point)
            X = p.X
            Y = p.Y
        End Sub

        Public Sub New(p As System.Windows.Point)
            X = p.X
            Y = p.Y
        End Sub

        Public Sub New(p As POINTAPI)
            X = p.x
            Y = p.y
        End Sub

        Public Sub New(x As Integer, y As Integer)
            Me.X = x
            Me.Y = y
        End Sub

    End Structure

    ''' <summary>
    ''' Unified size structure for WinForms, WPF and the Win32 API.
    ''' </summary>
    ''' <remarks></remarks>
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)>
    Public Structure UniSize
        Public Size As System.Windows.Size

        Public Property cx As Double
            Get
                Return Size.Width
            End Get
            Set(value As Double)
                Size.Width = value
            End Set
        End Property

        Public Property cy As Double
            Get
                Return Size.Height
            End Get
            Set(value As Double)
                Size.Height = value
            End Set
        End Property

        Public Property Width As Double
            Get
                Return Size.Width
            End Get
            Set(value As Double)
                Size.Width = value
            End Set
        End Property

        Public Property Height As Double
            Get
                Return Size.Height
            End Get
            Set(value As Double)
                Size.Height = value
            End Set
        End Property

        Public Shared Widening Operator CType(operand As UniSize) As System.Drawing.SizeF
            Return New System.Drawing.SizeF(operand.cx, operand.cy)
        End Operator

        Public Shared Narrowing Operator CType(operand As System.Drawing.SizeF) As UniSize
            Return New UniSize(operand.Width, operand.Height)
        End Operator

        Public Shared Widening Operator CType(operand As UniSize) As System.Drawing.Size
            Return New System.Drawing.Size(operand.cx, operand.cy)
        End Operator

        Public Shared Narrowing Operator CType(operand As System.Drawing.Size) As UniSize
            Return New UniSize(operand)
        End Operator

        Public Shared Widening Operator CType(operand As UniSize) As System.Windows.Size
            Return New System.Windows.Size(operand.cx, operand.cy)
        End Operator

        Public Shared Narrowing Operator CType(operand As System.Windows.Size) As UniSize
            Return New UniSize(operand)
        End Operator

        Public Shared Widening Operator CType(operand As UniSize) As SIZEAPI
            Return New SIZEAPI(operand.cx, operand.cy)
        End Operator

        Public Shared Narrowing Operator CType(operand As SIZEAPI) As UniSize
            Return New UniSize(operand)
        End Operator

        Public Shared Narrowing Operator CType(operand As String) As UniSize

            Dim st() As String = BatchParse(operand, ",")
            If st.Length <> 2 Then Throw New InvalidCastException("That string cannot be converted into a width/height pair.")

            Dim p As New UniSize

            p.cx = CDbl(st(0).Trim)
            p.cy = CDbl(st(1).Trim)

            Return p
        End Operator

        Public Sub New(p As System.Drawing.Size)
            cx = p.Width
            cy = p.Height
        End Sub

        Public Sub New(p As System.Windows.Size)
            cx = p.Width
            cy = p.Height
        End Sub

        Public Sub New(p As SIZEAPI)
            cx = p.cx
            cy = p.cy
        End Sub

        Public Sub New(cx As Integer, cy As Integer)
            Me.cx = cx
            Me.cy = cy
        End Sub

        Public Overrides Function ToString() As String
            Dim sx As String = Size.Width.ToString()
            Dim sy As String = Size.Height.ToString()

            Return sx & "," & sy
        End Function

        ''' <summary>
        ''' This will universally compare whether this is equals to any object that has valid width and height properties.
        ''' </summary>
        ''' <param name="obj"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function Equals(obj As Object) As Boolean
            Dim pi() As PropertyInfo = obj.GetType.GetProperties(BindingFlags.Public Or BindingFlags.Instance Or BindingFlags.NonPublic)
            Dim fi() As FieldInfo = obj.GetType.GetFields(BindingFlags.Public Or BindingFlags.Instance Or BindingFlags.NonPublic)

            Dim xmatch As Boolean = False
            Dim ymatch As Boolean = False

            '' compare fields, first.  These sorts of objects are structures, more often than not.
            For Each fe In fi

                Select Case fe.Name.ToLower

                    Case "cx", "width", "x", "dx",
                     "_cx", "_height", "_x", "_dx"

                        If fe.FieldType.IsPrimitive Then
                            If fe.GetValue(obj) = Me.Width Then
                                xmatch = True
                            End If
                        End If

                    Case "cy", "height", "y", "dy",
                     "_cy", "_height", "_y", "_dy"

                        If fe.FieldType.IsPrimitive Then
                            If fe.GetValue(obj) = Me.Height Then
                                ymatch = True
                            End If
                        End If

                    Case Else
                        Continue For

                End Select

                If (xmatch And ymatch) Then Return True
            Next

            '' now, properties.
            For Each pe In pi

                Select Case pe.Name.ToLower

                    Case "cx", "width", "x", "dx",
                     "_cx", "_height", "_x", "_dx"

                        If pe.PropertyType.IsPrimitive Then
                            If pe.GetValue(obj) = Me.Width Then
                                xmatch = True
                            End If
                        End If

                    Case "cy", "height", "y", "dy",
                     "_cy", "_height", "_y", "_dy"

                        If pe.PropertyType.IsPrimitive Then
                            If pe.GetValue(obj) = Me.Height Then
                                ymatch = True
                            End If
                        End If

                    Case Else
                        Continue For

                End Select

                If (xmatch And ymatch) Then Exit For
            Next

            '' Why not just return false, you ask?

            '' Because some diabolical mind somewhere might set the width up as
            '' a property, and then set the height up as a field.  ... 

            '' Using Occam's Razor, if this function is being invoked,
            '' it's for a damn good reason ... so ... suppose, somehow between our 
            '' public and non-public fields and our public and non-public properties
            '' we have an xmatch and ymatch, both true.  

            '' Consider: If we find a match amidst the mess, then we can say it's worth the search,
            '' and probably not coincidental (see my notes about 'damn good reasons', above).

            '' A philosophically rigid coder might want this function to
            '' return false simply becase the two values requested are not
            '' of the same kind.  

            '' But my philosophy is poigniantly different:
            '' kind does not matter.  If we were worried about kind,
            '' we wouldn't be trying to cast from an object like UniSize,
            '' now would we?  

            '' What matters are two values: Width and Height; kind is irrelevent.

            '' Hence:
            Return (xmatch And ymatch)

        End Function

        ''' <summary>
        ''' More experient functions for known "size" types.
        ''' </summary>
        ''' <param name="other"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overloads Function Equals(other As System.Windows.Size) As Boolean
            Return Width = other.Width AndAlso Height = other.Height
        End Function

        ''' <summary>
        ''' More experient functions for known "size" types.
        ''' </summary>
        ''' <param name="other"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overloads Function Equals(other As System.Drawing.Size) As Boolean
            Return Width = other.Width AndAlso Height = other.Height
        End Function

        ''' <summary>
        ''' More experient functions for known "size" types.
        ''' </summary>
        ''' <param name="other"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overloads Function Equals(other As UniSize) As Boolean
            Return Width = other.Width AndAlso Height = other.Height
        End Function

        ''' <summary>
        ''' More experient functions for known "size" types.
        ''' </summary>
        ''' <param name="other"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overloads Function Equals(other As SIZEAPI) As Boolean
            Return Width = other.cx AndAlso Height = other.cy
        End Function


    End Structure

    ''' <summary>
    ''' Unified rectangle structure for WinForms, WPF and the Win32 API.
    ''' </summary>
    ''' <remarks></remarks>
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)>
    Public Structure UniRect
        Implements INotifyPropertyChanged

        Private _Left As Double

        Private Sub OnPropertyChanged(name As String)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(name))
        End Sub

        Public Property Left As Double
            Get
                Return _Left
            End Get
            Set(value As Double)
                _Left = value
                OnPropertyChanged("Left")
                OnPropertyChanged("X")
            End Set
        End Property

        Private _Top As Double

        Public Property Top As Double
            Get
                Return _Top
            End Get
            Set(value As Double)
                _Top = value
                OnPropertyChanged("Top")
                OnPropertyChanged("Y")
            End Set
        End Property

        Private _Width As Double

        Public Property Width As Double
            Get
                Return _Width
            End Get
            Set(value As Double)
                _Width = value
                OnPropertyChanged("Width")
                OnPropertyChanged("Right")
                OnPropertyChanged("CX")
            End Set
        End Property

        Private _Height As Double

        Public Property Height As Double
            Get
                Return _Height
            End Get
            Set(value As Double)
                _Height = value
                OnPropertyChanged("Height")
                OnPropertyChanged("Bottom")
                OnPropertyChanged("CY")
            End Set
        End Property

        Public Property Right As Double
            Get
                Return (_Width - _Left) - 1
            End Get
            Set(value As Double)
                _Width = (value - _Left) + 1
                OnPropertyChanged("Height")
                OnPropertyChanged("Bottom")
                OnPropertyChanged("CY")
            End Set
        End Property

        Public Property Bottom As Double
            Get
                Return (_Height - _Top) - 1
            End Get
            Set(value As Double)
                _Height = (value - _Top) + 1
                OnPropertyChanged("Width")
                OnPropertyChanged("Right")
                OnPropertyChanged("CX")
            End Set
        End Property

        Public ReadOnly Property X As Double
            Get
                Return _Left
            End Get
        End Property

        Public ReadOnly Property Y As Double
            Get
                Return _Top
            End Get
        End Property

        Public ReadOnly Property CX As Double
            Get
                Return _Width
            End Get
        End Property

        Public ReadOnly Property CY As Double
            Get
                Return _Height
            End Get
        End Property

        Public Sub New(x As Double, y As Double, width As Double, height As Double)
            _Left = x
            _Top = y
            _Width = width
            _Height = height
        End Sub

        Public Sub New(location As System.Windows.Point, size As System.Windows.Size)
            _Left = location.X
            _Top = location.Y
            _Width = size.Width
            _Height = size.Height
        End Sub

        Public Sub New(location As System.Drawing.Point, size As System.Drawing.Size)
            _Left = location.X
            _Top = location.Y
            _Width = size.Width
            _Height = size.Height
        End Sub

        Public Sub New(location As System.Drawing.PointF, size As System.Drawing.SizeF)
            _Left = location.X
            _Top = location.Y
            _Width = size.Width
            _Height = size.Height
        End Sub

        Public Sub New(rectStruct As RECT)
            _Left = rectStruct.left
            _Top = rectStruct.top
            Right = rectStruct.right
            Bottom = rectStruct.bottom
        End Sub

        Public Sub New(rectStruct As Rectangle)
            _Left = rectStruct.Left
            _Top = rectStruct.Top
            _Width = rectStruct.Width
            _Height = rectStruct.Height
        End Sub

        Public Sub New(rectStruct As RectangleF)
            _Left = rectStruct.Left
            _Top = rectStruct.Top
            _Width = rectStruct.Width
            _Height = rectStruct.Height
        End Sub

        Public Sub New(rectStruct As System.Windows.Rect)
            _Left = rectStruct.Left
            _Top = rectStruct.Top
            _Width = rectStruct.Width
            _Height = rectStruct.Height
        End Sub

        Public Sub New(rectStruct As System.Windows.Int32Rect)
            _Left = rectStruct.X
            _Top = rectStruct.Y
            _Width = rectStruct.Width
            _Height = rectStruct.Height
        End Sub

        ''' <summary>
        ''' Gets rectangle data from a memory pointer (of type Double, 8 * 4 = 32 bytes)
        ''' </summary>
        ''' <param name="ptr"></param>
        ''' <remarks></remarks>
        Public Sub GetFromMemory(ptr As IntPtr, getAsInt32 As Boolean)

            Dim mm As MemPtr = ptr

            If getAsInt32 Then
                _Left = mm.IntegerAt(0)
                _Top = mm.IntegerAt(1)
                _Width = mm.IntegerAt(2)
                _Height = mm.IntegerAt(3)
            Else
                _Left = mm.DoubleAt(0)
                _Top = mm.DoubleAt(1)
                _Width = mm.DoubleAt(2)
                _Height = mm.DoubleAt(3)
            End If

        End Sub

        ''' <summary>
        ''' Sets rectangle data to a memory pointer (of type Double, 8 * 4 = 32 bytes)
        ''' Caller must allocate the memory pointer.
        ''' </summary>
        ''' <param name="ptr"></param>
        ''' <remarks></remarks>
        Public Sub SetToMemory(ptr As IntPtr, setAsInt32 As Boolean)
            Dim mm As MemPtr = ptr

            If setAsInt32 Then
                mm.IntegerAt(0) = (_Left)
                mm.IntegerAt(1) = (_Top)
                mm.IntegerAt(2) = (_Width)
                mm.IntegerAt(3) = (_Height)
            Else
                mm.DoubleAt(0) = _Left
                mm.DoubleAt(1) = _Top
                mm.DoubleAt(2) = _Width
                mm.DoubleAt(3) = _Height
            End If

        End Sub

        Public Overrides Function ToString() As String
            Return String.Format("{0}, {1}; {2}x{3}", _Left, _Top, _Width, _Height)
        End Function

        Public Shared Widening Operator CType(operand As UniRect) As System.Windows.Rect
            Return New System.Windows.Rect(operand._Left, operand._Top, operand._Width, operand._Height)
        End Operator

        Public Shared Widening Operator CType(operand As System.Windows.Rect) As UniRect
            Return New UniRect(operand)
        End Operator

        Public Shared Narrowing Operator CType(operand As UniRect) As System.Drawing.RectangleF
            Return New System.Drawing.RectangleF(operand._Left, operand._Top, operand._Width, operand._Height)
        End Operator

        Public Shared Widening Operator CType(operand As System.Drawing.RectangleF) As UniRect
            Return New UniRect(operand)
        End Operator

        Public Shared Narrowing Operator CType(operand As UniRect) As System.Drawing.Rectangle
            Return New System.Drawing.Rectangle(operand._Left, operand._Top, operand._Width, operand._Height)
        End Operator

        Public Shared Widening Operator CType(operand As System.Drawing.Rectangle) As UniRect
            Return New UniRect(operand)
        End Operator

        Public Shared Narrowing Operator CType(operand As UniRect) As RECT
            Return New RECT With {.Left = operand._Left, .Top = operand._Top, .Right = operand.Right, .Bottom = operand.Bottom}
        End Operator

        Public Shared Widening Operator CType(operand As RECT) As UniRect
            Return New UniRect(operand)
        End Operator

        Public Shared Narrowing Operator CType(operand As UniRect) As System.Windows.Int32Rect
            Return New System.Windows.Int32Rect(operand.Left, operand.Top, operand.Width, operand.Height)
        End Operator

        Public Shared Widening Operator CType(operand As System.Windows.Int32Rect) As UniRect
            Return New UniRect(operand)
        End Operator

        Public Shared Widening Operator CType(operand As UniRect) As Double()
            With operand
                Return { .Left, .Top, .Right, .Bottom}
            End With
        End Operator

        Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged
    End Structure

#End Region

End Namespace
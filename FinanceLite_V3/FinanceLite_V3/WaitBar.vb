Imports System.Threading

Public Class WaitBar

    'Public MyThread As New System.Threading.Thread(AddressOf WaitBarRun)

    Private Sub WaitBar_Load(sender As Object, e As EventArgs) Handles Me.Load

        'DevComponents.DotNetBar.Office2007Form.CheckForIllegalCrossThreadCalls = False

        'MyThread.Start()

    End Sub


    Public Sub WaitBarRun()

        Dim i As Integer

        i = 0

        While (1)

            PRG.Text = "Progress  " + i.ToString + "%"

            i = i + 10

            If i > 100 Then
                i = 0
            End If

            'MyThread.Sleep(100)

        End While

    End Sub

    Private Sub WaitBar_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        'MyThread.Abort()

    End Sub

End Class
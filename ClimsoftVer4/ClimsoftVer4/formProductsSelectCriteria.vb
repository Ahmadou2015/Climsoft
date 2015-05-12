﻿Public Class formProductsSelectCriteria
    Dim da As MySql.Data.MySqlClient.MySqlDataAdapter
    Dim ds As New DataSet
    Dim sql As String
    Dim maxRows As Integer
    Dim conn As New MySql.Data.MySqlClient.MySqlConnection
    Dim MyConnectionString As String
    Dim kounts As Integer
    Private Sub pnlStationsElements_Paint(sender As Object, e As PaintEventArgs) Handles pnlStationsElements.Paint

    End Sub

    'Private Sub formProducts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '    Dim prtyp As New clsProducts

    '    MyConnectionString = "server=127.0.0.1; uid=root; pwd=admin; database=mysql_climsoft_db_v4"

    '    'TODO: This line of code loads data into the 'Dataforms.data_forms' table

    '    lstvProducts.Columns.Add("Product Name", 100, HorizontalAlignment.Left)
    '    lstvProducts.Columns.Add("Product Details", 500, HorizontalAlignment.Left)

    '    Try
    '        conn.ConnectionString = MyConnectionString
    '        conn.Open()

    '        'MsgBox("Connection Successful !", MsgBoxStyle.Information)

    '        sql = "SELECT * FROM tblproducts"
    '        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
    '        da.Fill(ds, "tblproducts")
    '        conn.Close()
    '        'MsgBox("Dataset Field !", MsgBoxStyle.Information)

    '    Catch ex As MySql.Data.MySqlClient.MySqlException
    '        MessageBox.Show(ex.Message)
    '    End Try

    '    maxRows = ds.Tables("tblproducts").Rows.Count

    '    Dim str(2) As String
    '    Dim itm As ListViewItem

    '    For kount = 0 To maxRows - 1 Step 1
    '        'MsgBox(ds.Tables("data_forms").Rows(kount).Item("selected"))
    '        'If ds.Tables("data_forms").Rows(kount).Item("selected") = 1 Then
    '        str(0) = ds.Tables("tblproducts").Rows(kount).Item("productName")
    '        str(1) = ds.Tables("tblproducts").Rows(kount).Item("prDetails")
    '        itm = New ListViewItem(str)
    '        lstvProducts.Items.Add(itm)
    '        ' End If
    '    Next
    '    ' MsgBox(ListView1.Items.Count)
    '    'MsgBox((ListView1.Height - 46) / ListView1.Items.Count)
    '    lstvProducts.Height = 46 + 23 * (lstvProducts.Items.Count - 1)
    'End Sub

    Private Sub formProducts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'MyConnectionString = "server=127.0.0.1; uid=root; pwd=admin; database=mysql_climsoft_db_v4"
        MyConnectionString = LoginForm.txtusrpwd.Text
        Try
            conn.ConnectionString = MyConnectionString
            conn.Open()

            sql = "SELECT * FROM station"
            'sql = "SELECT prCategory FROM tblProducts GROUP BY prCategory"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da.Fill(ds, "station")
            ' conn.Close()

        Catch ex As MySql.Data.MySqlClient.MySqlException
            MessageBox.Show(ex.Message)
        End Try

        maxRows = ds.Tables("station").Rows.Count
        'MsgBox(maxRows)
        For kount = 0 To maxRows - 1 Step 1

            cmbstation.Items.Add(ds.Tables("station").Rows(kount).Item("stationName"))

        Next

        ds.Clear()
        sql = "SELECT * FROM obselement"
            'sql = "SELECT prCategory FROM tblProducts GROUP BY prCategory"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
        da.Fill(ds, "obselement")
            ' conn.Close()

        maxRows = ds.Tables("obselement").Rows.Count
        'MsgBox(maxRows)
        For kount = 0 To maxRows - 1 Step 1
            cmbElement.Items.Add(ds.Tables("obselement").Rows(kount).Item("description"))
        Next
    End Sub

    Private Sub lstvProducts_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub cmbstation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbstation.SelectedIndexChanged
        Dim prod As String

        prod = cmbstation.Text

        'lstvStations.Clear()
        lstvStations.Columns.Clear()
        lstvStations.Columns.Add("Station Id", 80, HorizontalAlignment.Left)
        lstvStations.Columns.Add("Station Name", 400, HorizontalAlignment.Left)

        'sql = "SELECT productName, prDetails FROM tblProducts WHERE prCategory=""" & prod & """"
        sql = "SELECT stationId, stationName FROM station WHERE stationName=""" & prod & """"
        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
        ds.Clear()
        da.Fill(ds, "station")

        maxRows = (ds.Tables("station").Rows.Count)
        Dim str(2) As String
        Dim itm = New ListViewItem

        For kount = 0 To maxRows - 1 Step 1
            str(0) = ds.Tables("station").Rows(kount).Item("stationId")
            str(1) = ds.Tables("station").Rows(kount).Item("stationName")
            itm = New ListViewItem(str)
            lstvStations.Items.Add(itm)
        Next
    End Sub

    Private Sub cmbElement_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbElement.SelectedIndexChanged
        Dim prod As String

        prod = cmbElement.Text
        ' MsgBox(prod)
        lstvElements.Columns.Clear()
        lstvElements.Columns.Add("Element Id", 80, HorizontalAlignment.Left)
        lstvElements.Columns.Add("Element Details", 400, HorizontalAlignment.Left)

        'sql = "SELECT productName, prDetails FROM tblProducts WHERE prCategory=""" & prod & """"
        sql = "SELECT code, description FROM obselement WHERE description=""" & prod & """"
               da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
        ds.Clear()
        da.Fill(ds, "obselement")

        maxRows = (ds.Tables("obselement").Rows.Count)
        Dim str(2) As String
        Dim itm = New ListViewItem

        For kount = 0 To maxRows - 1 Step 1
            str(0) = ds.Tables("obselement").Rows(kount).Item("code")
            str(1) = ds.Tables("obselement").Rows(kount).Item("description")
            itm = New ListViewItem(str)
            lstvElements.Items.Add(itm)
        Next
    End Sub

    Private Sub chkAdvancedSelection_CheckedChanged(sender As Object, e As EventArgs) Handles chkAdvancedSelection.CheckedChanged
        If chkAdvancedSelection.Checked = True Then
            pnlStation.Visible = True
        Else
            pnlStation.Visible = False
        End If

    End Sub

    Private Sub dateFrom_ValueChanged(sender As Object, e As EventArgs) Handles dateFrom.ValueChanged


    End Sub


    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim stnlist, elmlist, sdate, edate, sql, sql1, sql0 As String
        'MsgBox(lblProductType.Text)

        ' Get the stations list
        stnlist = ""
        If lstvStations.Items.Count > 0 Then
            stnlist = "'" & lstvStations.Items(0).Text & "'"
            For i = 1 To lstvStations.Items.Count - 1
                '  MsgBox(lstvStations.Items(i).Text)
                stnlist = stnlist & " OR " & "'" & lstvStations.Items(i).Text & "'"
            Next
        End If

        'MsgBox(stnlist)

        ' Get the Elements list
        elmlist = ""
        If lstvElements.Items.Count > 0 Then
            elmlist = "'" & lstvElements.Items(0).Text & "'" '""""
            For i = 1 To lstvElements.Items.Count - 1
                ' MsgBox(lstvElements.Items(i).Text)
                elmlist = elmlist & " OR  " & "'" & lstvElements.Items(i).Text & "'"  ' """ & lstvElements.Items(i).Text & """"
            Next
        End If

        sdate = Year(dateFrom.Text) & "-" & Month(dateFrom.Text) & "-" & "01" & ":" & txtHourStart.Text & ":" & txtMinuteStart.Text & ":00"
        edate = Year(dateTo.Text) & "-" & Month(dateTo.Text) & "-" & "31" & ":" & txtHourEnd.Text & ":" & txtMinuteEnd.Text & ":00"

        'sql0 = "use mysql_climsoft_db_v4; SELECT recordedFrom as StationId,obsDatetime,SUM(IF(describedBy = '111', value, NULL)) AS '111',SUM(IF(describedBy = '112', value, NULL)) AS '112' FROM (SELECT recordedFrom, describedBy, obsDatetime, obsValue value FROM observationfinal WHERE (RecordedFrom = '67774010' or '100000') AND (describedBy = '111' OR describedBy = '112') and (obsDatetime between '2005-01-01 00:00:00' and '2010-12-31 23:00:00') ORDER BY recordedFrom, obsDatetime) t GROUP BY StationId, obsDatetime;"
        Select Case Me.lblProductType.Text
            Case "WindRose"
                sql = "use mysql_climsoft_db_v4; SELECT recordedFrom as StationId,obsDatetime,SUM(IF(describedBy = '111', value, NULL)) AS '111',SUM(IF(describedBy = '112', value, NULL)) AS '112' FROM (SELECT recordedFrom, describedBy, obsDatetime, obsValue value FROM observationfinal WHERE (RecordedFrom = " & stnlist & ") AND (describedBy = '111' OR describedBy = '112') and (obsDatetime between '" & sdate & "' and '" & edate & "') ORDER BY recordedFrom, obsDatetime) t GROUP BY StationId, obsDatetime;"
            Case Else
                MsgBox("No Product Selected")
                Exit Sub
        End Select

        WindRoseData(sql)
    End Sub
    Sub WindRoseData(sql As String)
        On Error GoTo Err
        'MsgBox(sql)

        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
        da.Fill(ds, "observationfinal")
        maxRows = ds.Tables("observationfinal").Rows.Count
        MsgBox("Data For Wind Rose Plot; Records Extracted= " & maxRows)

        With ds.Tables("observationfinal") ' First 5 rows
            For i = 0 To 5
                MsgBox(.Rows(i).Item("StationId") & " " & .Rows(i).Item("obsDatetime") & " " & .Rows(i).Item("111") & " " & .Rows(i).Item("112"))
            Next
        End With
        Exit Sub
Err:
        If Err.Number = 13 Or Err.Number = 5 Then Resume Next
        MsgBox(Err.Number & " " & Err.Description)

    End Sub

    Private Sub cmdDelStation_Click(sender As Object, e As EventArgs) Handles cmdDelStation.Click
        For i = 0 To lstvStations.Items.Count - 1
            If lstvStations.Items(i).Selected Then
                'Delete_Selection(lstvStations, i)
                lstvStations.Items(i).Remove()
                Exit For
            End If
        Next
    End Sub

    Private Sub chksatation_CheckedChanged(sender As Object, e As EventArgs) Handles chksatation.CheckedChanged
        lstvStations.Clear()
    End Sub

    'Sub Delete_Selection(lstv As ListView, itm As Integer)
    '    lstvStations.Items(itm).Remove()
    'End Sub

    Private Sub cmdDelElement_Click(sender As Object, e As EventArgs) Handles cmdDelElement.Click
        For i = 0 To lstvElements.Items.Count - 1
            If lstvElements.Items(i).Selected Then
                'Delete_Selection(lstvStations, i)
                lstvElements.Items(i).Remove()
                Exit For
            End If
        Next
    End Sub

    Private Sub chkelement_CheckedChanged(sender As Object, e As EventArgs) Handles chkelement.CheckedChanged
        lstvElements.Clear()
    End Sub

    Private Sub prgrbProducts_Click(sender As Object, e As EventArgs) Handles prgrbProducts.Click

    End Sub
End Class
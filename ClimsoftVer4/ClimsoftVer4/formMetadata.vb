﻿Public Class formMetadata
    Dim dbconn As New MySql.Data.MySqlClient.MySqlConnection
    Dim dbConnectionString As String
    Dim da As MySql.Data.MySqlClient.MySqlDataAdapter
    Dim ds As New DataSet
    Dim sql As String
    Dim rec As Integer
    Dim Kount As Integer
    'Dim maxRows As Integer

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles grpStation.Enter

    End Sub

    Private Sub formMetadata_Click(sender As Object, e As EventArgs) Handles Me.Click
        MsgBox(TabMetadata.SelectedIndex)
    End Sub

    Private Sub formMetadata_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dbConnectionString = frmLogin.txtusrpwd.Text
        dbconn.ConnectionString = dbConnectionString
        dbconn.Open()

        'Sql = "SELECT * FROM station"
        'da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbconn)
        'da.Fill(ds, "station")

        'MsgBox(ds.Tables("station").Rows.Count)

    End Sub
    Sub SetDataSet(tbl As String)
        Dim sql As String
        sql = "SELECT * FROM " & tbl
        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbconn)
        da.Fill(ds, tbl)
        Kount = ds.Tables(tbl).Rows.Count
    End Sub

    Private Sub TabStation_Click(sender As Object, e As EventArgs) Handles TabStation.Click
        MsgBox("Station")
    End Sub

    Private Sub TabMetadata_Click(sender As Object, e As EventArgs) Handles TabMetadata.Click
        'MsgBox(TabMetadata.SelectedIndex)

        Select Case TabMetadata.SelectedIndex
            Case 0 ' Station
                SetDataSet("station")
                rec = 0
                populateForm("station", rec, Kount)
            Case 1 ' obselement
                SetDataSet("obselement")
                rec = 0
                populateElementMetadata("obselement", rec, Kount)
            Case 2 ' StationElement
                FillList(txtStation, "station", "stationId")
                FillList(txtElement, "obselement", "elementId")
                FillList(txtImstrument, "instrument", "instrumentId")

                SetDataSet("stationElement")
                rec = 0
                populateStationElement("stationElement", rec, Kount)
            Case 3 ' Instrument
                FillList(txtInstrStn, "station", "stationId")
                SetDataSet("instrument")
                rec = 0
                'populateInstrumentForm("instrument", rec, Kount)
            Case 4 ' Station Location History
                FillList(txtlocStn, "station", "stationId")
                FillList(txtInstrStn, "station", "stationId")
                SetDataSet("stationlocationhistory")
                rec = 0
                'populateHistorytForm("stationlocationhistory", rec, Kount)
            Case 5 ' Station Qualifier
                FillList(txtQualifierStation, "station", "stationId")
                SetDataSet("stationqualifier")
                rec = 0
                'populateQualifierForm("stationqualifier", rec, Kount)
            Case 6 ' Schedule Class
                FillList(txtClassStation, "station", "stationId")
                SetDataSet("obsscheduleclass")
                rec = 0
                'populateScheduleForm("scheduleclass", rec, Kount)
            Case 7 ' Physical Feature
                FillList(txtFeatureStation, "station", "stationId")
                SetDataSet("physicalfeature")
                rec = 0
                'populateFeatureForm("physicalfeature", rec, Kount)
        End Select
    End Sub

    Private Sub BindingNavigator1_RefreshItems(sender As Object, e As EventArgs)

    End Sub

    Private Sub cmdAddNew_Click(sender As Object, e As EventArgs)

    End Sub

  
    Sub populateForm(frm As String, num As Integer, maxRows As Integer)
        On Error Resume Next
        txtstationId.Text = ds.Tables(frm).Rows(num).Item("stationId")
        txtStationName.Text = ds.Tables("station").Rows(num).Item("stationName")
        txtCountry.Text = ds.Tables("station").Rows(num).Item("country")
        txtLatitude.Text = ds.Tables("station").Rows(num).Item("latitude")
        txtLongitude.Text = ds.Tables("station").Rows(num).Item("longitude")
        txtElevation.Text = ds.Tables("station").Rows(num).Item("elevation")
        txtOpenDate.Text = ds.Tables("station").Rows(num).Item("openingdatetime")
        txtClosingDate.Text = ds.Tables("station").Rows(num).Item("closingdatetime")
        txtAuthority.Text = ds.Tables("station").Rows(num).Item("authority")
        txtAdminRegion.Text = ds.Tables("station").Rows(num).Item("adminregion")
        txtDrainageBasin.Text = ds.Tables("station").Rows(num).Item("drainagebasin")
        txtgeoMethod.Text = ds.Tables("station").Rows(num).Item("geolocationmethod")
        txtgeoAccuracy.Text = ds.Tables("station").Rows(num).Item("geolocationaccuracy")
        'txtcpt.Text = ds.Tables("station").Rows(num).Item("cptselection")
        txtStationOperation.CheckState = ds.Tables("station").Rows(num).Item("stationoperational")
        txtRecNumber.Text = rec + 1 & " of " & maxRows - 1 '"Record 1 of " & maxRows
    End Sub
    Sub populateElementMetadata(frm As String, num As Integer, maxRows As Integer)
        On Error Resume Next

        txtId.Text = ds.Tables(frm).Rows(num).Item("elementId")
        txtAbbreviation.Text = ds.Tables(frm).Rows(num).Item("abbreviation")
        txtName.Text = ds.Tables(frm).Rows(num).Item("elementName")
        txtDescription.Text = ds.Tables(frm).Rows(num).Item("description")
        txtScale.Text = ds.Tables(frm).Rows(num).Item("elementScale")
        txtUpperLimit.Text = ds.Tables(frm).Rows(num).Item("upperLimit")
        txtLowerLimit.Text = ds.Tables(frm).Rows(num).Item("lowerLimit")
        txtUnit.Text = ds.Tables(frm).Rows(num).Item("units")
        txtType.Text = ds.Tables(frm).Rows(num).Item("elementtype")

        txtElementNavigator.Text = rec + 1 & " of " & maxRows - 1 '"Record 1 of " & maxRows
    End Sub
    Sub populateStationElement(frm As String, num As Integer, maxRows As Integer)
        On Error Resume Next

        txtStation.Text = ds.Tables(frm).Rows(num).Item("recordedFrom")
        txtElement.Text = ds.Tables(frm).Rows(num).Item("describedBy")
        txtImstrument.Text = ds.Tables(frm).Rows(num).Item("recordedWith")
        txtScheduleClass.Text = ds.Tables(frm).Rows(num).Item("scheduledFor")
        txtHeight.Text = ds.Tables(frm).Rows(num).Item("height")
        txtBeginDate.Text = ds.Tables(frm).Rows(num).Item("beginDate")
        txtEndate.Text = ds.Tables(frm).Rows(num).Item("endDate")

        If maxRows > 0 Then txtNavigator1.Text = rec + 1 & " of " & maxRows - 1 '"Record 1 of " & maxRows
    End Sub
    Private Sub btnMoveFirst_Click(sender As Object, e As EventArgs) Handles btnMoveFirst.Click
        rec = 0
        populateForm("station", rec, Kount)
    End Sub

    Private Sub btnMovePrevious_Click(sender As Object, e As EventArgs) Handles btnMovePrevious.Click
        If rec > 0 Then
            rec = rec - 1
            populateForm("station", rec, Kount)
        End If
    End Sub

    Private Sub btnMoveNext_Click(sender As Object, e As EventArgs) Handles btnMoveNext.Click
        If rec < Kount Then
            rec = rec + 1
            populateForm("station", rec, Kount)
        End If
    End Sub

    Private Sub btnMoveLast_Click(sender As Object, e As EventArgs) Handles btnMoveLast.Click

        rec = Kount - 1
        populateForm("station", rec, Kount)
    End Sub

    Private Sub cmdAddNew_Click_1(sender As Object, e As EventArgs) Handles cmdAddNew.Click
        On Error GoTo Err
        'The CommandBuilder providers the imbedded command for updating the record in the record source table. So the CommandBuilder
        'must be declared for the Update method to work.
        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
        Dim dsNewRow As DataRow
        'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
        Dim recCommit As New dataEntryGlobalRoutines

        dsNewRow = ds.Tables("station").NewRow
        dsNewRow.Item("stationId") = txtstationId.Text
        dsNewRow.Item("stationName") = txtStationName.Text
        dsNewRow.Item("country") = txtCountry.Text
        dsNewRow.Item("latitude") = txtLatitude.Text
        dsNewRow.Item("longitude") = txtLongitude.Text
        dsNewRow.Item("elevation") = txtElevation.Text
        dsNewRow.Item("adminRegion") = txtAdminRegion.Text
        dsNewRow.Item("authority") = txtAuthority.Text
        dsNewRow.Item("geolocationAccuracy") = txtgeoAccuracy.Text
        dsNewRow.Item("geolocationMethod") = txtMethod.Text
        dsNewRow.Item("openingDatetime") = txtOpenDate.Value
        dsNewRow.Item("openingDatetime") = txtClosingDate.Value
        dsNewRow.Item("stationoperational") = txtStationOperation.CheckState

        'Add a new record to the data source table
        ds.Tables("station").Rows.Add(dsNewRow)
        da.Update(ds, "station")
        ClearStationForm()
        Exit Sub
Err:
        MsgBox(Err.Number & " : " & Err.Description)
    End Sub
    Sub ClearStationForm()

        'For Each ctrl As Object In Me.Controls
        '    'typ = ctrl.CType=
        '    MsgBox(ctrl.Name)
        '    If Strings.Left(ctrl.Name, 3) = "txt" Then

        '        ctrl.Text = ""
        '    End If
        'Next

        txtstationId.Clear()
        txtStationName.Clear()
        txtCountry.Clear()
        txtAuthority.Clear()
        txtLatitude.Clear()
        txtLongitude.Clear()
        txtElevation.Clear()
        txtAdminRegion.Clear()
        txtDrainageBasin.Clear()
        txtgeoAccuracy.Clear()
        txtgeoMethod.Clear()
        txtOpenDate.Text = ""
        txtClosingDate.Text = ""
        txtStationOperation.CheckState = CheckState.Unchecked
        txtRecNumber.Clear()

    End Sub

    Sub ClearElementForm()

        txtId.Clear()
        txtAbbreviation.Clear()
        txtName.Clear()
        txtDescription.Clear()
        txtScale.Clear()
        txtUpperLimit.Clear()
        txtLowerLimit.Clear()
        txtUnit.Clear()
        txtType.Text = ""
        txtElementNavigator.Clear()

    End Sub
    Private Sub cmdUpdate_Click(sender As Object, e As EventArgs) Handles cmdUpdate.Click
        If txtstationId.Text = "" Then
            MsgBox("No record Selected")
        Else
            TableUpdate(rec, "update")
        End If
    End Sub
    Function TableUpdate(recs As Integer, cmdtype As String) As Boolean
        TableUpdate = True

        On Error GoTo Err

        'The CommandBuilder providers the imbedded command for updating the record in the record source table. So the CommandBuilder
        'must be declared for the Update method to work.
        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
        Dim recUpdate As New dataEntryGlobalRoutines

        ds.Tables("station").Rows(recs).Item("stationId") = txtstationId.Text
        ds.Tables("station").Rows(recs).Item("stationName") = txtStationName.Text
        ds.Tables("station").Rows(recs).Item("country") = txtCountry.Text
        ds.Tables("station").Rows(recs).Item("latitude") = txtLatitude.Text
        ds.Tables("station").Rows(recs).Item("longitude") = txtLongitude.Text
        ds.Tables("station").Rows(recs).Item("elevation") = txtElevation.Text
        ds.Tables("station").Rows(recs).Item("adminRegion") = txtAdminRegion.Text
        ds.Tables("station").Rows(recs).Item("authority") = txtAuthority.Text
        ds.Tables("station").Rows(recs).Item("geolocationAccuracy") = txtgeoAccuracy.Text
        ds.Tables("station").Rows(recs).Item("geolocationMethod") = txtMethod.Text
        ds.Tables("station").Rows(recs).Item("openingDatetime") = txtOpenDate.Value
        ds.Tables("station").Rows(recs).Item("openingDatetime") = txtClosingDate.Value
        ds.Tables("station").Rows(recs).Item("stationoperational") = txtStationOperation.CheckState

        'Add a new record to the data source table
        'If cmdtype = "add" Then ds.Tables("station").Rows.Add(dsNewRow)

        da.Update(ds, "station")

        If cmdtype = "update" Then recUpdate.messageBoxRecordedUpdated()
        'ClearStationForm()

        Exit Function

Err:
        MsgBox(Err.Description)
        TableUpdate = False
    End Function




    Function DeleteRecord(tbl As String, recs As Integer) As Boolean
        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
        'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
        Dim recDelete As New dataEntryGlobalRoutines
        DeleteRecord = True
        On Error GoTo Err
        ds.Tables(tbl).Rows(recs).Delete()
        da.Update(ds, tbl)

        'If rec < Kount - 1 Then
        '    populateForm("station", rec + 1, Kount)
        'Else
        '    populateForm("station", rec, Kount)
        'End If

        Exit Function
Err:
        MsgBox(Err.Description)
        DeleteRecord = False
    End Function

    Private Sub cmdDelete_Click(sender As Object, e As EventArgs) Handles cmdDelete.Click
        If DeleteRecord("station", rec) Then
            If rec < Kount - 1 Then
                populateForm("station", rec + 1, Kount)
            Else
                populateForm("station", rec, Kount)
            End If
        End If
    End Sub

    Private Sub cmdClear_Click(sender As Object, e As EventArgs) Handles cmdClear.Click
        ClearStationForm()
    End Sub

    Private Sub MenuMetadata_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuMetadata.ItemClicked

    End Sub

    Private Sub cmdFirstRecord_Click(sender As Object, e As EventArgs) Handles cmdFirstRecord.Click
        rec = 0
        populateElementMetadata("obselement", rec, Kount)
    End Sub

    Private Sub cmdLastRecord_Click(sender As Object, e As EventArgs) Handles cmdLastRecord.Click
        rec = Kount - 1
        populateElementMetadata("obselement", rec, Kount)
    End Sub

    Private Sub cmdPrevoius_Click(sender As Object, e As EventArgs) Handles cmdPrevoius.Click
        If rec > 0 Then
            rec = rec - 1
            populateElementMetadata("obselement", rec, Kount)
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If rec < Kount Then
            rec = rec + 1
            populateElementMetadata("obselement", rec, Kount)
        End If
    End Sub

    Private Sub cmdAddElement_Click(sender As Object, e As EventArgs) Handles cmdAddElement.Click
        On Error GoTo Err
        'The CommandBuilder providers the imbedded command for updating the record in the record source table. So the CommandBuilder
        'must be declared for the Update method to work.
        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
        Dim dsNewRow As DataRow
        'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
        Dim recCommit As New dataEntryGlobalRoutines

        dsNewRow = ds.Tables("obselement").NewRow
        dsNewRow.Item("elementId") = txtId.Text
        dsNewRow.Item("abbreviation") = txtAbbreviation.Text
        dsNewRow.Item("abbreviation") = txtAbbreviation.Text
        dsNewRow.Item("elementName") = txtName.Text
        dsNewRow.Item("description") = txtDescription.Text
        dsNewRow.Item("elementScale") = txtScale.Text
        dsNewRow.Item("upperLimit") = txtUpperLimit.Text
        dsNewRow.Item("lowerLimit") = txtLowerLimit.Text
        dsNewRow.Item("units") = txtUnit.Text
        dsNewRow.Item("elementtype") = txtType.Text

        'Add a new record to the data source table
        ds.Tables("obselement").Rows.Add(dsNewRow)
        da.Update(ds, "obselement")
        ClearElementForm()
        Exit Sub
Err:
        MsgBox(Err.Number & " : " & Err.Description)

    End Sub

    Private Sub cmdUpdateElement_Click(sender As Object, e As EventArgs) Handles cmdUpdateElement.Click
        On Error GoTo Err
        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
        Dim recUpdate As New dataEntryGlobalRoutines

        If txtId.Text = "" Then
            MsgBox("No record Selected")
            Exit Sub
        End If

        ds.Tables("obselement").Rows(rec).Item("elementId") = txtId.Text
        ds.Tables("obselement").Rows(rec).Item("elementName") = txtName.Text
        ds.Tables("obselement").Rows(rec).Item("abbreviation") = txtAbbreviation.Text
        ds.Tables("obselement").Rows(rec).Item("description") = txtDescription.Text
        ds.Tables("obselement").Rows(rec).Item("elementScale") = txtScale.Text
        ds.Tables("obselement").Rows(rec).Item("upperLimit") = txtUpperLimit.Text
        ds.Tables("obselement").Rows(rec).Item("lowerLimit") = txtLowerLimit
        ds.Tables("obselement").Rows(rec).Item("units") = txtUnit
        ds.Tables("obselement").Rows(rec).Item("elementtype") = txtType.Text

        da.Update(ds, "obselement")

        'If cmdtype = "update" Then recUpdate.messageBoxRecordedUpdated()
        ClearElementForm()

        Exit Sub

Err:
        MsgBox(Err.Description)

    End Sub

    Private Sub cmdDeleteElement_Click(sender As Object, e As EventArgs) Handles cmdDeleteElement.Click
        If DeleteRecord("obselement", rec) Then
            If rec < Kount - 1 Then
                populateElementMetadata("obselement", rec + 1, Kount)
            Else
                populateElementMetadata("obselement", rec, Kount)
            End If
        End If
    End Sub


    Private Sub cmdClearElement_Click(sender As Object, e As EventArgs) Handles cmdClearElement.Click
        ClearElementForm()
    End Sub
    'Sub FillStationList(lst As ComboBox)
    '    Dim dstn As New DataSet
    '    ListDataSet(tbl As String, ByRef dstn As DataSet)
    '    lst.Items.Add("1")
    'End Sub

    Sub FillList(ByRef lst As ComboBox, tbl As String, idxfld As String)
        Dim dstn As New DataSet
        Dim sql As String
        sql = "SELECT * FROM  " & tbl
        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbconn)
        dstn.Clear()
        da.Fill(dstn, tbl)

        For i = 0 To dstn.Tables(tbl).Rows.Count - 1
            lst.Items.Add(dstn.Tables(tbl).Rows(i).Item(idxfld))
        Next
    End Sub

    Private Sub GroupBox2_Enter_1(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub
    Private Sub txtElementNavigator_TextChanged(sender As Object, e As EventArgs) Handles txtElementNavigator.TextChanged

    End Sub
    Private Sub TabMetadata_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabMetadata.SelectedIndexChanged

    End Sub




    Private Sub GroupBox10_Enter(sender As Object, e As EventArgs) Handles GroupBox10.Enter

    End Sub
    Private Sub txtNav2_TextChanged(sender As Object, e As EventArgs) Handles txtNav2.TextChanged

    End Sub

    Private Sub cmdAddStElement_Click(sender As Object, e As EventArgs) Handles cmdAddStElement.Click

    End Sub
End Class
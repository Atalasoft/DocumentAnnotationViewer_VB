Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Atalasoft.Imaging
Imports Atalasoft.Imaging.Codec
Imports Atalasoft.Annotate.UI
Imports Atalasoft.Imaging.WinControls
Imports Atalasoft.Annotate
Imports System.IO
Imports Atalasoft.Imaging.Codec.Pdf
Imports Atalasoft.Annotate.Exporters


Namespace DocumentAnnotationViewer
    Partial Public Class Form1 : Inherits Form

#Region "FIELDS"
        Private _defaultAnnotations As AnnotationDefaults = New AnnotationDefaults()
        Private _currentFile As String = ""
        Private _annotationImages As ImageList
#End Region

        Public Sub New()
            InitializeComponent()
            EnableDisableMenuAndToolbarItems()
            'LoadannotationToolbarItems()
            AtalaDemos.HelperMethods.PopulateDecoders(RegisteredDecoders.Decoders)

            AddHandler Me.DocumentAnnotationViewer1.SelectedIndexChanged, AddressOf documentAnnotationViewer1_SelectedIndexChanged
            AddHandler Me.DocumentAnnotationViewer1.UndoListChanged, AddressOf documentAnnotationViewer1_UndoListChanged

            AddHandler Me.DocumentAnnotationViewer1.Annotations.SelectionChanged, AddressOf documentAnnotationViewer1_Annotations_SelectionChanged
            AddHandler Me.DocumentAnnotationViewer1.Annotations.Rotated, AddressOf documentAnnotationViewer1_AnnotationRotated
            AddHandler Me.DocumentAnnotationViewer1.Annotations.Resized, AddressOf documentAnnotationViewer1_AnnotationResized
            AddHandler Me.DocumentAnnotationViewer1.Annotations.Moved, AddressOf documentAnnotationViewer1_AnnotationMoved
            AddHandler Me.DocumentAnnotationViewer1.Annotations.AnnotationCreated, AddressOf documentAnnotationViewer1_AnnotationCreated

            Me.DocumentAnnotationViewer1.SelectFirstPageOnOpen = True
            Me.DocumentAnnotationViewer1.Annotations.ClipToDocument = True

            ' We Need to add the ability to directly handle embedded annotations
            Dim PdfRes As Integer = 96
            For Each decoder As Object In RegisteredDecoders.Decoders
                If decoder.GetType Is GetType(PdfDecoder) Then
                    Dim pdfDec As PdfDecoder = TryCast(decoder, PdfDecoder)
                    PdfRes = pdfDec.Resolution
                    Exit For
                End If
            Next
            Me.DocumentAnnotationViewer1.AnnotationDataProvider = New Atalasoft.Annotate.UI.EmbeddedAnnotationDataProvider(New PointF(PdfRes, PdfRes))
            AddHandler Me.DocumentAnnotationViewer1.CreatePdfAnnotationDataExporter, AddressOf documentAnnotationViewer1_CreatePdfAnnotationDataExporter
        End Sub

        Private Function documentAnnotationViewer1_CreatePdfAnnotationDataExporter(ByVal sender As Object, ByVal e As CreatePdfAnnotationDataExporterEventArgs) As Atalasoft.Annotate.Exporters.PdfAnnotationDataExporter
            Dim exp As New PdfAnnotationDataExporter()
            exp.AlwaysEmbedAnnotationData = True
            exp.OverwriteExistingAnnotations = True
            Return exp
        End Function

#Region "ImageControl Event Handlers"
        ''' <summary>
        ''' Handles updating of the Status Strip to indicate current selected page (index +1)
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub documentAnnotationViewer1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
            Dim currentPage As Integer = 0
            If Me.DocumentAnnotationViewer1.ThumbnailControl.SelectedIndicies.Length > 0 Then
                currentPage = Me.DocumentAnnotationViewer1.ThumbnailControl.SelectedIndicies(0) + 1
            End If

            Me.toolStripStatusPage.Text = "Page " & currentPage & " of " & Me.DocumentAnnotationViewer1.Count.ToString()
        End Sub
#End Region


#Region "Annotation Event Handlers"
        Private Sub RubberStampTool_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cLASSIFIEDToolStripMenuItem.Click, tOPSECRETToolStripMenuItem.Click, iMPORTANTToolStripMenuItem.Click, dRAFTToolStripMenuItem.Click, cONFIDENTIALToolStripMenuItem.Click
            Dim stamp As Atalasoft.Annotate.UI.RubberStampAnnotation = DirectCast(_defaultAnnotations.GetAnnotation(AnnotationType.RubberStamp), Atalasoft.Annotate.UI.RubberStampAnnotation)
            stamp.Text = DirectCast(sender, ToolStripMenuItem).Text
            Me.DocumentAnnotationViewer1.Annotations.CreateAnnotation(stamp, Atalasoft.Annotate.CreateAnnotationMode.SingleClickCenter)
        End Sub

        Private Sub documentAnnotationViewer1_Annotations_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs)
            EnableDisableMenuAndToolbarItems()
        End Sub

        Private Sub documentAnnotationViewer1_AnnotationMoved(ByVal sender As Object, ByVal e As Atalasoft.Annotate.AnnotationEventArgs)
            EnableDisableMenuAndToolbarItems()
        End Sub

        Private Sub documentAnnotationViewer1_AnnotationResized(ByVal sender As Object, ByVal e As Atalasoft.Annotate.AnnotationEventArgs)
            EnableDisableMenuAndToolbarItems()
        End Sub

        Private Sub documentAnnotationViewer1_AnnotationRotated(ByVal sender As Object, ByVal e As Atalasoft.Annotate.AnnotationEventArgs)
            EnableDisableMenuAndToolbarItems()
        End Sub

        Private Sub documentAnnotationViewer1_UndoListChanged(ByVal sender As Object, ByVal e As EventArgs)
            EnableDisableMenuAndToolbarItems()
        End Sub

        Private Sub documentAnnotationViewer1_AnnotationCreated(ByVal sender As Object, ByVal e As Atalasoft.Annotate.AnnotationEventArgs)
            Dim txt As Atalasoft.Annotate.UI.TextAnnotation = TryCast(e.Annotation, Atalasoft.Annotate.UI.TextAnnotation)
            If txt IsNot Nothing Then
                txt.EditMode = True
            End If

            Dim ca As Atalasoft.Annotate.UI.CalloutAnnotation = TryCast(e.Annotation, Atalasoft.Annotate.UI.CalloutAnnotation)
            If ca IsNot Nothing Then
                ca.EditMode = True
            End If

            e.Annotation.Selected = True
            e.Annotation.ContextMenuStrip = Me.contextMenuStrip1
            EnableDisableMenuAndToolbarItems()
        End Sub

        Private Sub documentAnnotationViewer1_SelectionRectangleChanged(ByVal sender As Object, ByVal e As Atalasoft.Imaging.WinControls.RubberbandEventArgs)
            Dim rc As Rectangle = Me.DocumentAnnotationViewer1.ImageControl.Selection.Bounds
            Dim selectionBounds As New RectangleF(rc.X, rc.Y, rc.Width, rc.Height)
            SwitchAnnotationAuthorMode(True)
            Me.DocumentAnnotationViewer1.Annotations.SelectFromBounds(selectionBounds, True)
        End Sub
#End Region


#Region "Misc Methods"
        Private Sub OpenImageFile()
            Using dlg As New OpenFileDialog()
                dlg.Filter = AtalaDemos.HelperMethods.CreateDialogFilter(True)
                If dlg.ShowDialog(Me) = DialogResult.OK Then
                    Me.DocumentAnnotationViewer1.Open(dlg.FileName, -1)
                    Me._currentFile = dlg.FileName
                End If
            End Using
            If Me.DocumentAnnotationViewer1.Count > 0 Then
                UpdateStatusBar()
            End If
            EnableDisableMenuAndToolbarItems()

            Dim layers As Integer = Me.DocumentAnnotationViewer1.Annotations.Layers.Count
        End Sub


        ''' <summary>
        ''' Updates the page x of y and file name items on the statusbar
        ''' </summary>
        Private Sub UpdateStatusBar()
            ' We could probably just force this to 1, but to be safe, let's keep it dynamic
            Dim currentPage As Integer = 0
            If Me.DocumentAnnotationViewer1.ThumbnailControl.SelectedIndicies.Length > 0 Then
                currentPage = Me.DocumentAnnotationViewer1.ThumbnailControl.SelectedIndicies(0) + 1
            End If
            Me.toolStripStatusPage.Text = "Page " + currentPage.ToString() + " of " + Me.DocumentAnnotationViewer1.Count.ToString()
            Me.toolStripStatusFile.Text = System.IO.Path.GetFileName(Me._currentFile)
        End Sub


        ''' <summary>
        ''' When called without a fileName, 
        ''' we provide a SaveFileDialog, then pass along to the version that takes a fileName
        ''' </summary>
        Private Sub SaveImageFile()
            Using dlg As New SaveFileDialog()
                dlg.Filter = AtalaDemos.HelperMethods.CreateDialogFilter(False)
                If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                    ' slight change from the video...
                    SaveImageFile(dlg.FileName)
                    Me._currentFile = dlg.FileName
                    UpdateStatusBar()
                End If
            End Using

        End Sub


        ''' <summary>
        ''' Performs the file save... note that annotaitons are automatically embedded 
        ''' if the target encoder supports embedded annotations
        ''' </summary>
        ''' <param name="fileName"></param>
        Private Sub SaveImageFile(ByVal fileName As String)
            Dim enc As ImageEncoder = GetEncoder(Path.GetExtension(fileName))

            If enc IsNot Nothing Then
                Me.DocumentAnnotationViewer1.Save(fileName, enc)
            Else
                MessageBox.Show("unable to determine correct encoder for file: " + fileName)
            End If

        End Sub


        ''' <summary>
        ''' Examines the file extension on fileName to return the correct ImageEncoder
        ''' </summary>
        ''' <param name="fileName"></param>
        ''' <returns></returns>
        Private Function GetEncoder(ByVal fileName As String) As ImageEncoder
            Dim ext As String = Path.GetExtension(fileName)

            Dim returnEnc As ImageEncoder = Nothing

            If ext IsNot Nothing Then
                Select Case ext.ToLower()
                    ' Not using these
                    'case ".jpg":
                    'case ".jpeg":
                    '    returnEnc = new JpegEncoder();
                    '    break;
                    'case ".png":
                    '    returnEnc = new PngEncoder();
                    '    break;
                    'case ".gif":
                    '    returnEnc = new GifEncoder();
                    '    break;
                    'case ".bmp":
                    '    returnEnc = new BmpEncoder();
                    '    break;
                    Case ".tif", ".tiff"
                        returnEnc = New TiffEncoder()
                        Exit Select
                    Case ".pdf"
                        returnEnc = New PdfEncoder()
                        Exit Select
                    Case Else
                        returnEnc = Nothing
                        Exit Select
                End Select
            End If
            Return returnEnc
        End Function


        ''' <summary>
        ''' Cleans up the annotations/images and undos to let go of the current file
        ''' </summary>
        ''' <returns></returns>
        Private Function CloseCurrentFile() As Boolean
            Me.DocumentAnnotationViewer1.Clear()
            Me.DocumentAnnotationViewer1.Annotations.UndoManager.Clear()
            Return True
        End Function


        Private Sub SetContextMenu(ByVal layer As Atalasoft.Annotate.UI.LayerAnnotation)
            For Each ann As Atalasoft.Annotate.UI.AnnotationUI In layer.Items
                Dim l As LayerAnnotation = TryCast(ann, LayerAnnotation)
                If l IsNot Nothing Then
                    SetContextMenu(l)
                Else
                    ann.ContextMenuStrip = Me.contextMenuStrip1
                End If
            Next
        End Sub

        ''' <summary>
        ''' Used by the EmbeddedImageAnnotation and ReferencedImageAnnotation creation methods to get the filename to use
        ''' </summary>
        ''' <returns></returns>
        Private Function GetFilename() As String
            Using dlg As New OpenFileDialog()
                dlg.Filter = "Images|*.jpg;*.png;*.tif;*.tiff;*.bmp;*.emf;*.wmf;*.gif"

                If dlg.ShowDialog(Me) = DialogResult.OK Then
                    Return dlg.FileName
                Else
                    Return Nothing
                End If
            End Using
        End Function

        ''' <summary>
        ''' When printing, DocumentAnnotationViewer handles the annotations for you
        ''' Just create a blank print document, provide it to the print dialog, then pass on to the Print() method
        ''' </summary>
        Private Sub PrintImages()
            Using printDoc As New AnnotatePrintDocument()
                Using diag As New PrintDialog()
                    diag.Document = printDoc
                    If diag.ShowDialog() = DialogResult.OK Then
                        DocumentAnnotationViewer1.Print(printDoc)
                    End If
                End Using
            End Using
        End Sub

        Private Sub EnableDisableMenuAndToolbarItems()
            Dim fileLoaded As Boolean = Me.DocumentAnnotationViewer1.Count > 0
            Me.saveAsToolStripMenuItem.Enabled = fileLoaded
            Me.printToolStripMenuItem.Enabled = fileLoaded
            Me.toolStripPrint.Enabled = fileLoaded
            Me.toolStripSave.Enabled = fileLoaded
            Me.toolStripAnnotations.Enabled = fileLoaded
            Me.toolStripPointer.Enabled = fileLoaded
            Me.toolStripSelection.Enabled = fileLoaded
            Me.toolStripZoomIn.Enabled = (fileLoaded AndAlso Me.DocumentAnnotationViewer1.ImageControl.AutoZoom = Atalasoft.Imaging.WinControls.AutoZoomMode.None)
            Me.toolStripZoomOut.Enabled = (fileLoaded AndAlso Me.DocumentAnnotationViewer1.ImageControl.AutoZoom = Atalasoft.Imaging.WinControls.AutoZoomMode.None)

            Dim annotationSelected As Boolean = Me.DocumentAnnotationViewer1.Annotations.ActiveAnnotation IsNot Nothing
            Me.cutToolStripMenuItem.Enabled = annotationSelected
            Me.copyToolStripMenuItem.Enabled = annotationSelected
            Me.toolStripCut.Enabled = annotationSelected
            Me.toolStripCopy.Enabled = annotationSelected

            Dim canPaste As Boolean = Me.DocumentAnnotationViewer1.Annotations.CanPaste()
            Me.pasteToolStripMenuItem.Enabled = canPaste
            Me.toolStripPaste.Enabled = canPaste

            Dim canUndo As Boolean = Me.DocumentAnnotationViewer1.Annotations.UndoManager.UndoCount > 0
            Dim canRedo As Boolean = Me.DocumentAnnotationViewer1.Annotations.UndoManager.RedoCount > 0
            Me.undoToolStripMenuItem.Enabled = canUndo
            Me.redoToolStripMenuItem.Enabled = canRedo
            Me.toolStripUndo.Enabled = canUndo
            Me.toolStripRedo.Enabled = canRedo
        End Sub


        Private Sub PerformUndo()
            Me.DocumentAnnotationViewer1.Annotations.UndoManager.Undo()
            EnableDisableMenuAndToolbarItems()
        End Sub


        Private Sub PerformRedo()
            Me.DocumentAnnotationViewer1.Annotations.UndoManager.Redo()
            EnableDisableMenuAndToolbarItems()
        End Sub


        Private Sub PerformCut()
            Me.DocumentAnnotationViewer1.Annotations.Cut()
            EnableDisableMenuAndToolbarItems()
        End Sub


        Private Sub PerformCopy()
            Me.DocumentAnnotationViewer1.Annotations.Copy()
            EnableDisableMenuAndToolbarItems()
        End Sub


        Private Sub PerformPaste()
            Me.DocumentAnnotationViewer1.Annotations.Paste()
            EnableDisableMenuAndToolbarItems()
        End Sub


        Private Function GetAnnotationBrush(ByVal annotation As AnnotationUI, ByVal propertyName As String) As Atalasoft.Annotate.AnnotationBrush
            ' Use reflection to see if there is a brush.
            Dim at As Type = annotation.[GetType]()
            Dim info As System.Reflection.PropertyInfo = at.GetProperty(propertyName)
            If info Is Nothing Then
                Return Nothing
            End If

            Return TryCast(info.GetValue(annotation, Nothing), Atalasoft.Annotate.AnnotationBrush)
        End Function


        Private Function GetAnnotationPen(ByVal annotation As AnnotationUI, ByVal propertyName As String) As Atalasoft.Annotate.AnnotationPen
            Dim at As Type = annotation.[GetType]()
            Dim info As System.Reflection.PropertyInfo = at.GetProperty(propertyName)
            If info Is Nothing Then
                Return Nothing
            End If

            Return TryCast(info.GetValue(annotation, Nothing), Atalasoft.Annotate.AnnotationPen)
        End Function


        Private Function GetColor(ByVal current As Color) As Color
            Using dlg As New ColorDialog()
                dlg.Color = current
                If dlg.ShowDialog(Me) = DialogResult.OK Then
                    Return dlg.Color
                Else
                    Return Color.Empty
                End If
            End Using
        End Function

        Private Sub UpdateAnnotationDefault(ByVal annotation As AnnotationUI)
            If [String].IsNullOrEmpty(annotation.Data.Name) Then
                Return
            End If

            Dim aType As Type = GetType(AnnotationType)
            If [Enum].IsDefined(aType, annotation.Data.Name) Then
                Dim at As AnnotationType = DirectCast([Enum].Parse(aType, annotation.Data.Name), AnnotationType)
                Me._defaultAnnotations.UpdateAnnotation(at, annotation)
            End If
        End Sub

        Private Sub SwitchAnnotationAuthorMode(ByVal authoring As Boolean)
            If authoring Then
                Me.DocumentAnnotationViewer1.ImageControl.MouseTool = MouseToolType.None
                Me.DocumentAnnotationViewer1.Annotations.InteractMode = AnnotateInteractMode.Author
            Else
                Me.DocumentAnnotationViewer1.Annotations.InteractMode = AnnotateInteractMode.None

                ' The first time we switch the MouseTool to Selection we have to add the Changed event handler.
                Dim addEvent As Boolean = Me.DocumentAnnotationViewer1.ImageControl.Selection Is Nothing
                Me.DocumentAnnotationViewer1.ImageControl.MouseTool = MouseToolType.Selection
                If addEvent Then
                    'AddHandler Me.DocumentAnnotationViewer1.ImageControl.Selection.Changed, AddressOf New RubberbandEventHandler(AddressOf Me.documentAnnotationViewer1_SelectionRectangleChanged)
                    AddHandler Me.DocumentAnnotationViewer1.ImageControl.Selection.Changed, AddressOf Me.documentAnnotationViewer1_SelectionRectangleChanged
                    Me.DocumentAnnotationViewer1.ImageControl.Selection.ClickLock = False
                End If

                Me.DocumentAnnotationViewer1.ImageControl.Selection.SetDisplayBounds(RectangleF.Empty)
            End If

            Me.DocumentAnnotationViewer1.ImageControl.Selection.Visible = Not authoring
            Me.toolStripSelection.Checked = Not authoring
            Me.toolStripPointer.Checked = authoring
            Me.toolStripAnnotations.Enabled = authoring
        End Sub


        Private Sub SetZoomMode(ByVal mode As AutoZoomMode)
            Me.DocumentAnnotationViewer1.ImageControl.AutoZoom = mode

            If mode = Atalasoft.Imaging.WinControls.AutoZoomMode.None Then
                Me.DocumentAnnotationViewer1.ImageControl.Zoom = 1.0
                Me.toolStripZoomIn.Enabled = True
                Me.toolStripZoomOut.Enabled = True
            Else
                Me.toolStripZoomIn.Enabled = False
                Me.toolStripZoomOut.Enabled = False
            End If
        End Sub
#End Region


#Region "File Menu"
        Private Sub openToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles openToolStripMenuItem.Click
            OpenImageFile()
        End Sub

        Private Sub saveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles saveAsToolStripMenuItem.Click
            SaveImageFile()
        End Sub

        Private Sub printToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles printToolStripMenuItem.Click
            PrintImages()
        End Sub

        Private Sub exitToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles exitToolStripMenuItem.Click
            If CloseCurrentFile() Then
                Me.Close()
            End If
        End Sub
#End Region


#Region "Edit Menu"
        Private Sub undoToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles undoToolStripMenuItem.Click
            PerformUndo()
        End Sub

        Private Sub redoToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles redoToolStripMenuItem.Click
            PerformRedo()
        End Sub

        Private Sub cutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cutToolStripMenuItem.Click
            PerformCut()
        End Sub

        Private Sub copyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles copyToolStripMenuItem.Click
            PerformCopy()
        End Sub

        Private Sub pasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles pasteToolStripMenuItem.Click
            PerformPaste()
        End Sub
#End Region


#Region "Help Menu"
        Private Sub helpAboutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles HelpAboutToolStripMenuItem.Click
            Dim aboutBox As New AtalaDemos.AboutBox.About("About Atalasoft DotImage Document Annotation Viewer Demo", "DotImage Document Annotation Viewer Demo")
            aboutBox.Description = "The Document Annotation Viewer Demo demonstrates how use our DocumentAnnotationViewer control. " & vbCr & vbLf & vbCr & vbLf & "This demo should be used to gain a basic understanding of how the DotImage DocumentAnnotationViewer functions. " & vbCr & vbLf & vbCr & vbLf & "The demo allows you to open various supported image files, automatically loading any supported embedded annotations. It also allows the creation / editing of various annotation types and saving out the resulting file with annotaions being embedded for supported formats. Additionally, it shows the ease of use of the built in undo/redo manager, as well as cut, copy, and paste of annotations, and even full document printing with annotations.  Requires DotImage license. Optionally, requires PdfRasterizer license in order to open/read PDF files."
            aboutBox.ShowDialog()
        End Sub
#End Region


#Region "Tool Strips"
        ''' <summary>
        ''' ClickHandlers for the main tool strip
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub toolStripMain_ItemClicked(ByVal sender As Object, ByVal e As ToolStripItemClickedEventArgs) Handles toolStripMain.ItemClicked
            Select Case e.ClickedItem.Text
                Case "Open"
                    OpenImageFile()
                    Exit Select
                Case "Save"
                    SaveImageFile()
                    Exit Select
                Case "Print"
                    PrintImages()
                    Exit Select
                Case "Undo"
                    PerformUndo()
                    Exit Select
                Case "Redo"
                    PerformRedo()
                    Exit Select
                Case "Cut"
                    PerformCut()
                    Exit Select
                Case "Copy"
                    PerformCopy()
                    Exit Select
                Case "Paste"
                    PerformPaste()
                    Exit Select
                Case "Pointer"
                    If Not Me.toolStripPointer.Checked Then
                        SwitchAnnotationAuthorMode(True)
                    End If
                    Exit Select
                Case "Selection Tool"
                    If Not Me.toolStripSelection.Checked Then
                        SwitchAnnotationAuthorMode(False)
                    End If
                    Exit Select
                Case "Zoom In"
                    Me.DocumentAnnotationViewer1.ImageControl.Zoom += 0.1
                    Exit Select
                Case "Zoom Out"
                    Me.DocumentAnnotationViewer1.ImageControl.Zoom -= 0.1
                    Exit Select
            End Select
        End Sub


        ''' <summary>
        ''' Click handlers for the annotation Tool Strip
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub toolStripAnnotations_ItemClicked(ByVal sender As Object, ByVal e As ToolStripItemClickedEventArgs) Handles toolStripAnnotations.ItemClicked
            Me.DocumentAnnotationViewer1.Annotations.ClearSelection()

            Select Case e.ClickedItem.Text
                Case "Rectangle"
                    Me.DocumentAnnotationViewer1.Annotations.CreateAnnotation(_defaultAnnotations.GetAnnotation(AnnotationType.Rectangle))
                    Exit Select
                Case "Ellipse"
                    Me.DocumentAnnotationViewer1.Annotations.CreateAnnotation(_defaultAnnotations.GetAnnotation(AnnotationType.Ellipse))
                    Exit Select
                Case "Single Line"
                    Me.DocumentAnnotationViewer1.Annotations.CreateAnnotation(_defaultAnnotations.GetAnnotation(AnnotationType.Line))
                    Exit Select
                Case "Connected Lines"
                    Me.DocumentAnnotationViewer1.Annotations.CreateAnnotation(_defaultAnnotations.GetAnnotation(AnnotationType.Lines))
                    Exit Select
                Case "Freehand"
                    Me.DocumentAnnotationViewer1.Annotations.CreateAnnotation(_defaultAnnotations.GetAnnotation(AnnotationType.Freehand))
                    Exit Select
                Case "Polygon"
                    Me.DocumentAnnotationViewer1.Annotations.CreateAnnotation(_defaultAnnotations.GetAnnotation(AnnotationType.Polygon))
                    Exit Select
                Case "Highlighter"
                    Me.DocumentAnnotationViewer1.Annotations.CreateAnnotation(_defaultAnnotations.GetAnnotation(AnnotationType.RectangleHighlighter))
                    Exit Select
                Case "Freehand Highlighter"
                    Me.DocumentAnnotationViewer1.Annotations.CreateAnnotation(_defaultAnnotations.GetAnnotation(AnnotationType.FreehandHighlighter))
                    Exit Select
                Case "Embedded Image"
                    Dim eFile As String = GetFilename()
                    If eFile IsNot Nothing Then
                        Dim ann As Atalasoft.Annotate.UI.EmbeddedImageAnnotation = TryCast(_defaultAnnotations.GetAnnotation(AnnotationType.EmbeddedImage), Atalasoft.Annotate.UI.EmbeddedImageAnnotation)
                        ann.Image = New Atalasoft.Annotate.AnnotationImage(eFile)
                        Me.DocumentAnnotationViewer1.Annotations.CreateAnnotation(ann)
                    End If
                    Exit Select
                Case "Referenced Image"
                    Dim rFile As String = GetFilename()
                    If rFile IsNot Nothing Then
                        Dim rann As Atalasoft.Annotate.UI.ReferencedImageAnnotation = TryCast(_defaultAnnotations.GetAnnotation(AnnotationType.ReferencedImage), Atalasoft.Annotate.UI.ReferencedImageAnnotation)
                        rann.FileName = rFile
                        Me.DocumentAnnotationViewer1.Annotations.CreateAnnotation(rann)
                    End If
                    Exit Select
                Case "Text"
                    Me.DocumentAnnotationViewer1.Annotations.CreateAnnotation(_defaultAnnotations.GetAnnotation(AnnotationType.Text))
                    Exit Select
                Case "Callout"
                    Me.DocumentAnnotationViewer1.Annotations.CreateAnnotation(_defaultAnnotations.GetAnnotation(AnnotationType.Callout))
                    Exit Select
                Case "Sticky Note"
                    Me.DocumentAnnotationViewer1.Annotations.CreateAnnotation(_defaultAnnotations.GetAnnotation(AnnotationType.StickyNote), Atalasoft.Annotate.CreateAnnotationMode.SingleClickCenter)
                    Exit Select
                Case "Rubber Stamp"
                    Me.DocumentAnnotationViewer1.Annotations.CreateAnnotation(_defaultAnnotations.GetAnnotation(AnnotationType.RubberStamp), Atalasoft.Annotate.CreateAnnotationMode.SingleClickCenter)
                    Exit Select
                Case "Redaction"
                    Me.DocumentAnnotationViewer1.Annotations.CreateAnnotation(_defaultAnnotations.GetAnnotation(AnnotationType.Redaction))
                    Exit Select
            End Select
        End Sub


        ''' <summary>
        ''' Initializes the AnnotationToolstrip icons and loads them
        ''' </summary>
        Private Sub LoadAnnotationToolbarImages()
            ' Use the images provided within DotAnnotate.
            _annotationImages = New ImageList()
            _annotationImages.ImageSize = New Size(16, 16)
            _annotationImages.ColorDepth = ColorDepth.Depth32Bit
            _annotationImages.Images.Add(Atalasoft.Annotate.Icons.IconResource.ExtractAnnotationIcon(Atalasoft.Annotate.Icons.AnnotateIcon.Callout, Atalasoft.Annotate.Icons.AnnotateIconSize.Size16))
            _annotationImages.Images.Add(Atalasoft.Annotate.Icons.IconResource.ExtractAnnotationIcon(Atalasoft.Annotate.Icons.AnnotateIcon.Ellipse, Atalasoft.Annotate.Icons.AnnotateIconSize.Size16))
            _annotationImages.Images.Add(Atalasoft.Annotate.Icons.IconResource.ExtractAnnotationIcon(Atalasoft.Annotate.Icons.AnnotateIcon.Freehand, Atalasoft.Annotate.Icons.AnnotateIconSize.Size16))
            _annotationImages.Images.Add(Atalasoft.Annotate.Icons.IconResource.ExtractAnnotationIcon(Atalasoft.Annotate.Icons.AnnotateIcon.FreehandHighlighter, Atalasoft.Annotate.Icons.AnnotateIconSize.Size16))
            _annotationImages.Images.Add(Atalasoft.Annotate.Icons.IconResource.ExtractAnnotationIcon(Atalasoft.Annotate.Icons.AnnotateIcon.RectangleHighlighter, Atalasoft.Annotate.Icons.AnnotateIconSize.Size16))
            _annotationImages.Images.Add(Atalasoft.Annotate.Icons.IconResource.ExtractAnnotationIcon(Atalasoft.Annotate.Icons.AnnotateIcon.EmbeddedImage, Atalasoft.Annotate.Icons.AnnotateIconSize.Size16))
            _annotationImages.Images.Add(Atalasoft.Annotate.Icons.IconResource.ExtractAnnotationIcon(Atalasoft.Annotate.Icons.AnnotateIcon.Line, Atalasoft.Annotate.Icons.AnnotateIconSize.Size16))
            _annotationImages.Images.Add(Atalasoft.Annotate.Icons.IconResource.ExtractAnnotationIcon(Atalasoft.Annotate.Icons.AnnotateIcon.Lines, Atalasoft.Annotate.Icons.AnnotateIconSize.Size16))
            _annotationImages.Images.Add(Atalasoft.Annotate.Icons.IconResource.ExtractAnnotationIcon(Atalasoft.Annotate.Icons.AnnotateIcon.StickyNote, Atalasoft.Annotate.Icons.AnnotateIconSize.Size16))
            _annotationImages.Images.Add(Atalasoft.Annotate.Icons.IconResource.ExtractAnnotationIcon(Atalasoft.Annotate.Icons.AnnotateIcon.Polygon, Atalasoft.Annotate.Icons.AnnotateIconSize.Size16))
            _annotationImages.Images.Add(Atalasoft.Annotate.Icons.IconResource.ExtractAnnotationIcon(Atalasoft.Annotate.Icons.AnnotateIcon.Rectangle, Atalasoft.Annotate.Icons.AnnotateIconSize.Size16))
            _annotationImages.Images.Add(Atalasoft.Annotate.Icons.IconResource.ExtractAnnotationIcon(Atalasoft.Annotate.Icons.AnnotateIcon.Redact, Atalasoft.Annotate.Icons.AnnotateIconSize.Size16))
            _annotationImages.Images.Add(Atalasoft.Annotate.Icons.IconResource.ExtractAnnotationIcon(Atalasoft.Annotate.Icons.AnnotateIcon.ReferencedImage, Atalasoft.Annotate.Icons.AnnotateIconSize.Size16))
            _annotationImages.Images.Add(Atalasoft.Annotate.Icons.IconResource.ExtractAnnotationIcon(Atalasoft.Annotate.Icons.AnnotateIcon.RubberStamp, Atalasoft.Annotate.Icons.AnnotateIconSize.Size16))
            _annotationImages.Images.Add(Atalasoft.Annotate.Icons.IconResource.ExtractAnnotationIcon(Atalasoft.Annotate.Icons.AnnotateIcon.Text, Atalasoft.Annotate.Icons.AnnotateIconSize.Size16))

            Me.toolStripAnnotations.ImageList = _annotationImages
            Me.toolStripCallout.ImageIndex = 0
            Me.toolStripEllipse.ImageIndex = 1
            Me.toolStripFreehand.ImageIndex = 2
            Me.toolStripFreehandHighlighter.ImageIndex = 3
            Me.toolStripHighlighter.ImageIndex = 4
            Me.toolStripImage.ImageIndex = 5
            Me.toolStripLine.ImageIndex = 6
            Me.toolStripLines.ImageIndex = 7
            Me.toolStripNote.ImageIndex = 8
            Me.toolStripPolygon.ImageIndex = 9
            Me.toolStripRectangle.ImageIndex = 10
            Me.toolStripRedaction.ImageIndex = 11
            Me.toolStripReferencedImage.ImageIndex = 12
            Me.toolStripRubberStamp.ImageIndex = 13
            Me.toolStripText.ImageIndex = 14
        End Sub
#End Region


#Region "Status bar menu"
        Private Sub fitToHeightToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles fitToHeightToolStripMenuItem.Click, fitToHeightToolStripZoom.Click
            SetZoomMode(Atalasoft.Imaging.WinControls.AutoZoomMode.FitToHeight)
        End Sub

        Private Sub fitToWidthToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles fitToWidthToolStripMenuItem.Click, fitToWidthToolStripZoom.Click
            SetZoomMode(Atalasoft.Imaging.WinControls.AutoZoomMode.FitToWidth)
        End Sub

        Private Sub bestFitToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles bestFitToolStripMenuItem.Click, bestFitToolStripZoom.Click
            SetZoomMode(Atalasoft.Imaging.WinControls.AutoZoomMode.BestFitShrinkOnly)
        End Sub

        Private Sub noneToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles noneToolStripMenuItem.Click, noneToolStripZoom.Click
            SetZoomMode(Atalasoft.Imaging.WinControls.AutoZoomMode.None)
        End Sub
#End Region


#Region "Context Menu"
        Private Sub contextMenuStrip1_Opening(ByVal sender As Object, ByVal e As CancelEventArgs) Handles contextMenuStrip1.Opening
            ' Enable/disable menu items based on the annotation.
            Dim annotation As Atalasoft.Annotate.UI.AnnotationUI = Me.DocumentAnnotationViewer1.Annotations.ActiveAnnotation
            Dim at As Type = annotation.[GetType]()

            borderColorToolStripMenuItem.Enabled = (at.GetProperty("Outline") IsNot Nothing)
            fillColorToolStripMenuItem.Enabled = (at.GetProperty("Fill") IsNot Nothing AndAlso at.Name <> "RubberStampAnnotation")
            textColorToolStripMenuItem.Enabled = (at.GetProperty("FontBrush") IsNot Nothing)
            fontToolStripMenuItem.Enabled = (at.GetProperty("Font") IsNot Nothing)
        End Sub


        Private Sub borderColorToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles borderColorToolStripMenuItem.Click
            Dim pen As Atalasoft.Annotate.AnnotationPen = GetAnnotationPen(Me.DocumentAnnotationViewer1.Annotations.ActiveAnnotation, "Outline")
            If pen Is Nothing Then
                Return
            End If

            Dim clr As Color = GetColor(pen.Color)
            If clr <> Color.Empty Then
                If pen.Brush IsNot Nothing AndAlso pen.Brush.FillType = Atalasoft.Annotate.FillType.Hatch Then
                    pen.Brush.HatchForeColor = clr
                Else
                    pen.Color = clr
                End If
            End If
            UpdateAnnotationDefault(Me.DocumentAnnotationViewer1.Annotations.ActiveAnnotation)
        End Sub


        Private Sub fillColorToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles fillColorToolStripMenuItem.Click
            Dim brush As Atalasoft.Annotate.AnnotationBrush = GetAnnotationBrush(Me.DocumentAnnotationViewer1.Annotations.ActiveAnnotation, "Fill")
            If brush Is Nothing Then
                Return
            End If

            Dim clr As Color = GetColor(brush.Color)
            If clr <> Color.Empty Then
                brush.Color = clr
            End If
            UpdateAnnotationDefault(Me.DocumentAnnotationViewer1.Annotations.ActiveAnnotation)
            'TODO: remove this
            'ProcessThumbnail(this._currentFrame);
        End Sub


        Private Sub fontToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles fontToolStripMenuItem.Click
            Dim annotation As Atalasoft.Annotate.UI.AnnotationUI = Me.DocumentAnnotationViewer1.Annotations.ActiveAnnotation
            Dim at As Type = annotation.[GetType]()
            Dim info As System.Reflection.PropertyInfo = at.GetProperty("Font")
            If info Is Nothing Then
                Return
            End If

            Dim font As Atalasoft.Annotate.AnnotationFont = TryCast(info.GetValue(annotation, Nothing), Atalasoft.Annotate.AnnotationFont)
            If font Is Nothing Then
                Return
            End If

            Dim fontStyle__1 As FontStyle = FontStyle.Regular
            If font.Bold Then
                fontStyle__1 = FontStyle.Bold
            End If
            If font.Italic Then
                fontStyle__1 = fontStyle__1 Or FontStyle.Italic
            End If
            If font.Strikeout Then
                fontStyle__1 = fontStyle__1 Or FontStyle.Strikeout
            End If
            If font.Underline Then
                fontStyle__1 = fontStyle__1 Or FontStyle.Underline
            End If

            Using dlg As New FontDialog()
                dlg.Font = New Font(font.Name, font.Size, fontStyle__1)
                If dlg.ShowDialog(Me) = DialogResult.OK Then
                    font = New Atalasoft.Annotate.AnnotationFont(dlg.Font.Name, dlg.Font.Size, dlg.Font.Bold, dlg.Font.Italic, dlg.Font.Underline, dlg.Font.Strikeout)
                    info.SetValue(annotation, font, Nothing)
                End If
            End Using
            UpdateAnnotationDefault(annotation)
        End Sub


        Private Sub textColorToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles textColorToolStripMenuItem.Click
            Dim brush As Atalasoft.Annotate.AnnotationBrush = GetAnnotationBrush(Me.DocumentAnnotationViewer1.Annotations.ActiveAnnotation, "FontBrush")
            If brush Is Nothing Then
                Return
            End If

            Dim clr As Color = GetColor(brush.Color)
            If clr <> Color.Empty Then
                If brush.FillType = Atalasoft.Annotate.FillType.Hatch Then
                    brush.HatchForeColor = clr
                Else
                    brush.Color = clr
                End If
            End If
            UpdateAnnotationDefault(Me.DocumentAnnotationViewer1.Annotations.ActiveAnnotation)
        End Sub
#End Region


    End Class
End Namespace

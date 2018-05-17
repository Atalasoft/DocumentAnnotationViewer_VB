Imports Microsoft.VisualBasic
Imports System
Namespace DocumentAnnotationViewer
	Public Partial Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (Not components Is Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
            Me.toolStripContainer1 = New System.Windows.Forms.ToolStripContainer
            Me.DocumentAnnotationViewer1 = New Atalasoft.Annotate.UI.DocumentAnnotationViewer
            Me.statusStrip1 = New System.Windows.Forms.StatusStrip
            Me.toolStripStatusFile = New System.Windows.Forms.ToolStripStatusLabel
            Me.toolStripStatusPage = New System.Windows.Forms.ToolStripStatusLabel
            Me.toolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton
            Me.noneToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.bestFitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.fitToWidthToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.fitToHeightToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.menuStrip1 = New System.Windows.Forms.MenuStrip
            Me.fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.openToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.saveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.toolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
            Me.printToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.toolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator
            Me.exitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.editToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.undoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.redoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.toolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator
            Me.cutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.copyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.pasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.toolStripMain = New System.Windows.Forms.ToolStrip
            Me.toolStripOpen = New System.Windows.Forms.ToolStripButton
            Me.toolStripSave = New System.Windows.Forms.ToolStripButton
            Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
            Me.toolStripPrint = New System.Windows.Forms.ToolStripButton
            Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
            Me.toolStripUndo = New System.Windows.Forms.ToolStripButton
            Me.toolStripRedo = New System.Windows.Forms.ToolStripButton
            Me.toolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
            Me.toolStripCut = New System.Windows.Forms.ToolStripButton
            Me.toolStripCopy = New System.Windows.Forms.ToolStripButton
            Me.toolStripPaste = New System.Windows.Forms.ToolStripButton
            Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
            Me.toolStripPointer = New System.Windows.Forms.ToolStripButton
            Me.toolStripSelection = New System.Windows.Forms.ToolStripButton
            Me.toolStripZoomOut = New System.Windows.Forms.ToolStripButton
            Me.toolStripZoomIn = New System.Windows.Forms.ToolStripButton
            Me.toolStripDropDownButton2 = New System.Windows.Forms.ToolStripDropDownButton
            Me.noneToolStripZoom = New System.Windows.Forms.ToolStripMenuItem
            Me.bestFitToolStripZoom = New System.Windows.Forms.ToolStripMenuItem
            Me.fitToWidthToolStripZoom = New System.Windows.Forms.ToolStripMenuItem
            Me.fitToHeightToolStripZoom = New System.Windows.Forms.ToolStripMenuItem
            Me.toolStripAnnotations = New System.Windows.Forms.ToolStrip
            Me.toolStripRectangle = New System.Windows.Forms.ToolStripButton
            Me.toolStripEllipse = New System.Windows.Forms.ToolStripButton
            Me.toolStripLine = New System.Windows.Forms.ToolStripButton
            Me.toolStripLines = New System.Windows.Forms.ToolStripButton
            Me.toolStripFreehand = New System.Windows.Forms.ToolStripButton
            Me.toolStripPolygon = New System.Windows.Forms.ToolStripButton
            Me.toolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
            Me.toolStripHighlighter = New System.Windows.Forms.ToolStripButton
            Me.toolStripFreehandHighlighter = New System.Windows.Forms.ToolStripButton
            Me.toolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator
            Me.toolStripImage = New System.Windows.Forms.ToolStripButton
            Me.toolStripReferencedImage = New System.Windows.Forms.ToolStripButton
            Me.toolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator
            Me.toolStripText = New System.Windows.Forms.ToolStripButton
            Me.toolStripCallout = New System.Windows.Forms.ToolStripButton
            Me.toolStripNote = New System.Windows.Forms.ToolStripButton
            Me.toolStripRubberStamp = New System.Windows.Forms.ToolStripDropDownButton
            Me.cLASSIFIEDToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.cONFIDENTIALToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.dRAFTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.iMPORTANTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.tOPSECRETToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.toolStripRedaction = New System.Windows.Forms.ToolStripButton
            Me.contextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
            Me.borderColorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.fillColorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.fontToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.textColorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.HelpAboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.toolStripContainer1.ContentPanel.SuspendLayout()
            Me.toolStripContainer1.TopToolStripPanel.SuspendLayout()
            Me.toolStripContainer1.SuspendLayout()
            Me.statusStrip1.SuspendLayout()
            Me.menuStrip1.SuspendLayout()
            Me.toolStripMain.SuspendLayout()
            Me.toolStripAnnotations.SuspendLayout()
            Me.contextMenuStrip1.SuspendLayout()
            Me.SuspendLayout()
            '
            'toolStripContainer1
            '
            Me.toolStripContainer1.BottomToolStripPanelVisible = False
            '
            'toolStripContainer1.ContentPanel
            '
            Me.toolStripContainer1.ContentPanel.Controls.Add(Me.DocumentAnnotationViewer1)
            Me.toolStripContainer1.ContentPanel.Controls.Add(Me.statusStrip1)
            Me.toolStripContainer1.ContentPanel.Size = New System.Drawing.Size(901, 583)
            Me.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.toolStripContainer1.Location = New System.Drawing.Point(0, 0)
            Me.toolStripContainer1.Name = "toolStripContainer1"
            Me.toolStripContainer1.Size = New System.Drawing.Size(901, 657)
            Me.toolStripContainer1.TabIndex = 0
            Me.toolStripContainer1.Text = "toolStripContainer1"
            '
            'toolStripContainer1.TopToolStripPanel
            '
            Me.toolStripContainer1.TopToolStripPanel.Controls.Add(Me.menuStrip1)
            Me.toolStripContainer1.TopToolStripPanel.Controls.Add(Me.toolStripMain)
            Me.toolStripContainer1.TopToolStripPanel.Controls.Add(Me.toolStripAnnotations)
            '
            'DocumentAnnotationViewer1
            '
            Me.DocumentAnnotationViewer1.AnnotationDataProvider = Nothing
            Me.DocumentAnnotationViewer1.AnnotationSaveOptionsHandler = Nothing
            Me.DocumentAnnotationViewer1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.DocumentAnnotationViewer1.ImageControl.AntialiasDisplay = Atalasoft.Imaging.WinControls.AntialiasDisplayMode.ScaleToGray
            Me.DocumentAnnotationViewer1.ImageControl.BackColor = System.Drawing.SystemColors.Control
            Me.DocumentAnnotationViewer1.ImageControl.Cursor = System.Windows.Forms.Cursors.Default
            Me.DocumentAnnotationViewer1.ImageControl.Magnifier.BackColor = System.Drawing.Color.White
            Me.DocumentAnnotationViewer1.ImageControl.Magnifier.BorderColor = System.Drawing.Color.Black
            Me.DocumentAnnotationViewer1.ImageControl.Magnifier.Size = New System.Drawing.Size(100, 100)
            Me.DocumentAnnotationViewer1.Location = New System.Drawing.Point(0, 0)
            Me.DocumentAnnotationViewer1.Name = "DocumentAnnotationViewer1"
            Me.DocumentAnnotationViewer1.Separator.BackColor = System.Drawing.SystemColors.ControlLight
            Me.DocumentAnnotationViewer1.Size = New System.Drawing.Size(901, 561)
            Me.DocumentAnnotationViewer1.TabIndex = 2
            Me.DocumentAnnotationViewer1.Text = "DocumentAnnotationViewer1"
            Me.DocumentAnnotationViewer1.ThumbnailControl.BackColor = System.Drawing.SystemColors.Window
            Me.DocumentAnnotationViewer1.ThumbnailControl.Cursor = System.Windows.Forms.Cursors.Default
            Me.DocumentAnnotationViewer1.ThumbnailControl.DragSelectionColor = System.Drawing.Color.Red
            Me.DocumentAnnotationViewer1.ThumbnailControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.DocumentAnnotationViewer1.ThumbnailControl.ForeColor = System.Drawing.SystemColors.WindowText
            Me.DocumentAnnotationViewer1.ThumbnailControl.HighlightBackgroundColor = System.Drawing.SystemColors.Highlight
            Me.DocumentAnnotationViewer1.ThumbnailControl.HighlightTextColor = System.Drawing.SystemColors.HighlightText
            Me.DocumentAnnotationViewer1.ThumbnailControl.Margins = New Atalasoft.Imaging.WinControls.Margin(4, 4, 4, 4)
            Me.DocumentAnnotationViewer1.ThumbnailControl.SelectionMode = Atalasoft.Imaging.WinControls.ThumbnailSelectionMode.SingleSelect
            Me.DocumentAnnotationViewer1.ThumbnailControl.SelectionRectangleBackColor = System.Drawing.Color.Transparent
            Me.DocumentAnnotationViewer1.ThumbnailControl.SelectionRectangleDashStyle = System.Drawing.Drawing2D.DashStyle.Solid
            Me.DocumentAnnotationViewer1.ThumbnailControl.SelectionRectangleLineColor = System.Drawing.Color.Black
            Me.DocumentAnnotationViewer1.ThumbnailControl.ThumbnailOffset = New System.Drawing.Point(0, 0)
            Me.DocumentAnnotationViewer1.ThumbnailControl.ThumbnailSize = New System.Drawing.Size(100, 100)
            Me.DocumentAnnotationViewer1.UndoLevels = 100
            '
            'statusStrip1
            '
            Me.statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripStatusFile, Me.toolStripStatusPage, Me.toolStripDropDownButton1})
            Me.statusStrip1.Location = New System.Drawing.Point(0, 561)
            Me.statusStrip1.Name = "statusStrip1"
            Me.statusStrip1.ShowItemToolTips = True
            Me.statusStrip1.Size = New System.Drawing.Size(901, 22)
            Me.statusStrip1.TabIndex = 1
            Me.statusStrip1.Text = "statusStrip1"
            '
            'toolStripStatusFile
            '
            Me.toolStripStatusFile.Name = "toolStripStatusFile"
            Me.toolStripStatusFile.Size = New System.Drawing.Size(718, 17)
            Me.toolStripStatusFile.Spring = True
            Me.toolStripStatusFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'toolStripStatusPage
            '
            Me.toolStripStatusPage.Name = "toolStripStatusPage"
            Me.toolStripStatusPage.Size = New System.Drawing.Size(62, 17)
            Me.toolStripStatusPage.Text = "Page 0 of 0"
            '
            'toolStripDropDownButton1
            '
            Me.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
            Me.toolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.noneToolStripMenuItem, Me.bestFitToolStripMenuItem, Me.fitToWidthToolStripMenuItem, Me.fitToHeightToolStripMenuItem})
            Me.toolStripDropDownButton1.Image = CType(resources.GetObject("toolStripDropDownButton1.Image"), System.Drawing.Image)
            Me.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.toolStripDropDownButton1.Name = "toolStripDropDownButton1"
            Me.toolStripDropDownButton1.Size = New System.Drawing.Size(75, 20)
            Me.toolStripDropDownButton1.Text = "Zoom Mode"
            Me.toolStripDropDownButton1.ToolTipText = "Zoom Mode"
            '
            'noneToolStripMenuItem
            '
            Me.noneToolStripMenuItem.Name = "noneToolStripMenuItem"
            Me.noneToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
            Me.noneToolStripMenuItem.Text = "None"
            '
            'bestFitToolStripMenuItem
            '
            Me.bestFitToolStripMenuItem.Name = "bestFitToolStripMenuItem"
            Me.bestFitToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
            Me.bestFitToolStripMenuItem.Text = "Best Fit"
            '
            'fitToWidthToolStripMenuItem
            '
            Me.fitToWidthToolStripMenuItem.Name = "fitToWidthToolStripMenuItem"
            Me.fitToWidthToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
            Me.fitToWidthToolStripMenuItem.Text = "Fit to Width"
            '
            'fitToHeightToolStripMenuItem
            '
            Me.fitToHeightToolStripMenuItem.Name = "fitToHeightToolStripMenuItem"
            Me.fitToHeightToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
            Me.fitToHeightToolStripMenuItem.Text = "Fit to Height"
            '
            'menuStrip1
            '
            Me.menuStrip1.Dock = System.Windows.Forms.DockStyle.None
            Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fileToolStripMenuItem, Me.editToolStripMenuItem, Me.HelpToolStripMenuItem})
            Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
            Me.menuStrip1.Name = "menuStrip1"
            Me.menuStrip1.Size = New System.Drawing.Size(901, 24)
            Me.menuStrip1.TabIndex = 0
            Me.menuStrip1.Text = "menuStrip1"
            '
            'fileToolStripMenuItem
            '
            Me.fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.openToolStripMenuItem, Me.saveAsToolStripMenuItem, Me.toolStripMenuItem1, Me.printToolStripMenuItem, Me.toolStripMenuItem3, Me.exitToolStripMenuItem})
            Me.fileToolStripMenuItem.Name = "fileToolStripMenuItem"
            Me.fileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
            Me.fileToolStripMenuItem.Text = "&File"
            '
            'openToolStripMenuItem
            '
            Me.openToolStripMenuItem.Name = "openToolStripMenuItem"
            Me.openToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
            Me.openToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
            Me.openToolStripMenuItem.Text = "&Open"
            '
            'saveAsToolStripMenuItem
            '
            Me.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem"
            Me.saveAsToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
            Me.saveAsToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
            Me.saveAsToolStripMenuItem.Text = "Save &As..."
            '
            'toolStripMenuItem1
            '
            Me.toolStripMenuItem1.Name = "toolStripMenuItem1"
            Me.toolStripMenuItem1.Size = New System.Drawing.Size(160, 6)
            '
            'printToolStripMenuItem
            '
            Me.printToolStripMenuItem.Name = "printToolStripMenuItem"
            Me.printToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
            Me.printToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
            Me.printToolStripMenuItem.Text = "&Print"
            '
            'toolStripMenuItem3
            '
            Me.toolStripMenuItem3.Name = "toolStripMenuItem3"
            Me.toolStripMenuItem3.Size = New System.Drawing.Size(160, 6)
            '
            'exitToolStripMenuItem
            '
            Me.exitToolStripMenuItem.Name = "exitToolStripMenuItem"
            Me.exitToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
            Me.exitToolStripMenuItem.Text = "E&xit"
            '
            'editToolStripMenuItem
            '
            Me.editToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.undoToolStripMenuItem, Me.redoToolStripMenuItem, Me.toolStripMenuItem4, Me.cutToolStripMenuItem, Me.copyToolStripMenuItem, Me.pasteToolStripMenuItem})
            Me.editToolStripMenuItem.Name = "editToolStripMenuItem"
            Me.editToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
            Me.editToolStripMenuItem.Text = "&Edit"
            '
            'undoToolStripMenuItem
            '
            Me.undoToolStripMenuItem.Name = "undoToolStripMenuItem"
            Me.undoToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
            Me.undoToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
            Me.undoToolStripMenuItem.Text = "&Undo"
            '
            'redoToolStripMenuItem
            '
            Me.redoToolStripMenuItem.Name = "redoToolStripMenuItem"
            Me.redoToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Y), System.Windows.Forms.Keys)
            Me.redoToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
            Me.redoToolStripMenuItem.Text = "&Redo"
            '
            'toolStripMenuItem4
            '
            Me.toolStripMenuItem4.Name = "toolStripMenuItem4"
            Me.toolStripMenuItem4.Size = New System.Drawing.Size(149, 6)
            '
            'cutToolStripMenuItem
            '
            Me.cutToolStripMenuItem.Name = "cutToolStripMenuItem"
            Me.cutToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
            Me.cutToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
            Me.cutToolStripMenuItem.Text = "Cu&t"
            '
            'copyToolStripMenuItem
            '
            Me.copyToolStripMenuItem.Name = "copyToolStripMenuItem"
            Me.copyToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
            Me.copyToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
            Me.copyToolStripMenuItem.Text = "&Copy"
            '
            'pasteToolStripMenuItem
            '
            Me.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem"
            Me.pasteToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
            Me.pasteToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
            Me.pasteToolStripMenuItem.Text = "&Paste"
            '
            'toolStripMain
            '
            Me.toolStripMain.Dock = System.Windows.Forms.DockStyle.None
            Me.toolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripOpen, Me.toolStripSave, Me.toolStripSeparator1, Me.toolStripPrint, Me.toolStripSeparator3, Me.toolStripUndo, Me.toolStripRedo, Me.toolStripSeparator4, Me.toolStripCut, Me.toolStripCopy, Me.toolStripPaste, Me.toolStripSeparator2, Me.toolStripPointer, Me.toolStripSelection, Me.toolStripZoomOut, Me.toolStripZoomIn, Me.toolStripDropDownButton2})
            Me.toolStripMain.Location = New System.Drawing.Point(3, 24)
            Me.toolStripMain.Name = "toolStripMain"
            Me.toolStripMain.Size = New System.Drawing.Size(389, 25)
            Me.toolStripMain.TabIndex = 1
            '
            'toolStripOpen
            '
            Me.toolStripOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.toolStripOpen.Image = Global.My.Resources.Resources.Open
            Me.toolStripOpen.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.toolStripOpen.Name = "toolStripOpen"
            Me.toolStripOpen.Size = New System.Drawing.Size(23, 22)
            Me.toolStripOpen.Text = "Open"
            '
            'toolStripSave
            '
            Me.toolStripSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.toolStripSave.Image = Global.My.Resources.Resources.Save
            Me.toolStripSave.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.toolStripSave.Name = "toolStripSave"
            Me.toolStripSave.Size = New System.Drawing.Size(23, 22)
            Me.toolStripSave.Text = "Save"
            '
            'toolStripSeparator1
            '
            Me.toolStripSeparator1.Name = "toolStripSeparator1"
            Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
            '
            'toolStripPrint
            '
            Me.toolStripPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.toolStripPrint.Image = Global.My.Resources.Resources.Print
            Me.toolStripPrint.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.toolStripPrint.Name = "toolStripPrint"
            Me.toolStripPrint.Size = New System.Drawing.Size(23, 22)
            Me.toolStripPrint.Text = "Print"
            '
            'toolStripSeparator3
            '
            Me.toolStripSeparator3.Name = "toolStripSeparator3"
            Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 25)
            '
            'toolStripUndo
            '
            Me.toolStripUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.toolStripUndo.Image = Global.My.Resources.Resources.Undo
            Me.toolStripUndo.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.toolStripUndo.Name = "toolStripUndo"
            Me.toolStripUndo.Size = New System.Drawing.Size(23, 22)
            Me.toolStripUndo.Text = "Undo"
            '
            'toolStripRedo
            '
            Me.toolStripRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.toolStripRedo.Image = Global.My.Resources.Resources.Redo
            Me.toolStripRedo.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.toolStripRedo.Name = "toolStripRedo"
            Me.toolStripRedo.Size = New System.Drawing.Size(23, 22)
            Me.toolStripRedo.Text = "Redo"
            '
            'toolStripSeparator4
            '
            Me.toolStripSeparator4.Name = "toolStripSeparator4"
            Me.toolStripSeparator4.Size = New System.Drawing.Size(6, 25)
            '
            'toolStripCut
            '
            Me.toolStripCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.toolStripCut.Image = Global.My.Resources.Resources.Cut
            Me.toolStripCut.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.toolStripCut.Name = "toolStripCut"
            Me.toolStripCut.Size = New System.Drawing.Size(23, 22)
            Me.toolStripCut.Text = "Cut"
            '
            'toolStripCopy
            '
            Me.toolStripCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.toolStripCopy.Image = Global.My.Resources.Resources.Copy
            Me.toolStripCopy.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.toolStripCopy.Name = "toolStripCopy"
            Me.toolStripCopy.Size = New System.Drawing.Size(23, 22)
            Me.toolStripCopy.Text = "Copy"
            '
            'toolStripPaste
            '
            Me.toolStripPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.toolStripPaste.Image = Global.My.Resources.Resources.Paste
            Me.toolStripPaste.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.toolStripPaste.Name = "toolStripPaste"
            Me.toolStripPaste.Size = New System.Drawing.Size(23, 22)
            Me.toolStripPaste.Text = "Paste"
            '
            'toolStripSeparator2
            '
            Me.toolStripSeparator2.Name = "toolStripSeparator2"
            Me.toolStripSeparator2.Size = New System.Drawing.Size(6, 25)
            '
            'toolStripPointer
            '
            Me.toolStripPointer.Checked = True
            Me.toolStripPointer.CheckState = System.Windows.Forms.CheckState.Checked
            Me.toolStripPointer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.toolStripPointer.Image = Global.My.Resources.Resources.Control_Interactive_Button
            Me.toolStripPointer.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.toolStripPointer.Name = "toolStripPointer"
            Me.toolStripPointer.Size = New System.Drawing.Size(23, 22)
            Me.toolStripPointer.Text = "Pointer"
            '
            'toolStripSelection
            '
            Me.toolStripSelection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.toolStripSelection.Image = Global.My.Resources.Resources.RectangleSelection
            Me.toolStripSelection.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.toolStripSelection.Name = "toolStripSelection"
            Me.toolStripSelection.Size = New System.Drawing.Size(23, 22)
            Me.toolStripSelection.Text = "Selection Tool"
            '
            'toolStripZoomOut
            '
            Me.toolStripZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.toolStripZoomOut.Image = Global.My.Resources.Resources.Zoom_Out
            Me.toolStripZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.toolStripZoomOut.Name = "toolStripZoomOut"
            Me.toolStripZoomOut.Size = New System.Drawing.Size(23, 22)
            Me.toolStripZoomOut.Text = "Zoom Out"
            '
            'toolStripZoomIn
            '
            Me.toolStripZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.toolStripZoomIn.Image = Global.My.Resources.Resources.Zoom_In
            Me.toolStripZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.toolStripZoomIn.Name = "toolStripZoomIn"
            Me.toolStripZoomIn.Size = New System.Drawing.Size(23, 22)
            Me.toolStripZoomIn.Text = "Zoom In"
            '
            'toolStripDropDownButton2
            '
            Me.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
            Me.toolStripDropDownButton2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.noneToolStripZoom, Me.bestFitToolStripZoom, Me.fitToWidthToolStripZoom, Me.fitToHeightToolStripZoom})
            Me.toolStripDropDownButton2.Image = CType(resources.GetObject("toolStripDropDownButton2.Image"), System.Drawing.Image)
            Me.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.toolStripDropDownButton2.Name = "toolStripDropDownButton2"
            Me.toolStripDropDownButton2.Size = New System.Drawing.Size(79, 22)
            Me.toolStripDropDownButton2.Text = "Zoom Mode:"
            '
            'noneToolStripZoom
            '
            Me.noneToolStripZoom.Name = "noneToolStripZoom"
            Me.noneToolStripZoom.Size = New System.Drawing.Size(152, 22)
            Me.noneToolStripZoom.Text = "None"
            '
            'bestFitToolStripZoom
            '
            Me.bestFitToolStripZoom.Name = "bestFitToolStripZoom"
            Me.bestFitToolStripZoom.Size = New System.Drawing.Size(152, 22)
            Me.bestFitToolStripZoom.Text = "Best Fit"
            '
            'fitToWidthToolStripZoom
            '
            Me.fitToWidthToolStripZoom.Name = "fitToWidthToolStripZoom"
            Me.fitToWidthToolStripZoom.Size = New System.Drawing.Size(152, 22)
            Me.fitToWidthToolStripZoom.Text = "Fit to Width"
            '
            'fitToHeightToolStripZoom
            '
            Me.fitToHeightToolStripZoom.Name = "fitToHeightToolStripZoom"
            Me.fitToHeightToolStripZoom.Size = New System.Drawing.Size(152, 22)
            Me.fitToHeightToolStripZoom.Text = "Fit to Height"
            '
            'toolStripAnnotations
            '
            Me.toolStripAnnotations.Dock = System.Windows.Forms.DockStyle.None
            Me.toolStripAnnotations.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripRectangle, Me.toolStripEllipse, Me.toolStripLine, Me.toolStripLines, Me.toolStripFreehand, Me.toolStripPolygon, Me.toolStripSeparator6, Me.toolStripHighlighter, Me.toolStripFreehandHighlighter, Me.toolStripSeparator7, Me.toolStripImage, Me.toolStripReferencedImage, Me.toolStripSeparator8, Me.toolStripText, Me.toolStripCallout, Me.toolStripNote, Me.toolStripRubberStamp, Me.toolStripRedaction})
            Me.toolStripAnnotations.Location = New System.Drawing.Point(3, 49)
            Me.toolStripAnnotations.Name = "toolStripAnnotations"
            Me.toolStripAnnotations.Size = New System.Drawing.Size(379, 25)
            Me.toolStripAnnotations.TabIndex = 2
            '
            'toolStripRectangle
            '
            Me.toolStripRectangle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.toolStripRectangle.Image = Global.My.Resources.Resources.Rectangle
            Me.toolStripRectangle.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.toolStripRectangle.Name = "toolStripRectangle"
            Me.toolStripRectangle.Size = New System.Drawing.Size(23, 22)
            Me.toolStripRectangle.Text = "Rectangle"
            '
            'toolStripEllipse
            '
            Me.toolStripEllipse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.toolStripEllipse.Image = Global.My.Resources.Resources.Ellipse
            Me.toolStripEllipse.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.toolStripEllipse.Name = "toolStripEllipse"
            Me.toolStripEllipse.Size = New System.Drawing.Size(23, 22)
            Me.toolStripEllipse.Text = "Ellipse"
            '
            'toolStripLine
            '
            Me.toolStripLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.toolStripLine.Image = Global.My.Resources.Resources.Line
            Me.toolStripLine.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.toolStripLine.Name = "toolStripLine"
            Me.toolStripLine.Size = New System.Drawing.Size(23, 22)
            Me.toolStripLine.Text = "Single Line"
            '
            'toolStripLines
            '
            Me.toolStripLines.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.toolStripLines.Image = Global.My.Resources.Resources.Lines
            Me.toolStripLines.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.toolStripLines.Name = "toolStripLines"
            Me.toolStripLines.Size = New System.Drawing.Size(23, 22)
            Me.toolStripLines.Text = "Connected Lines"
            '
            'toolStripFreehand
            '
            Me.toolStripFreehand.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.toolStripFreehand.Image = Global.My.Resources.Resources.Freehand
            Me.toolStripFreehand.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.toolStripFreehand.Name = "toolStripFreehand"
            Me.toolStripFreehand.Size = New System.Drawing.Size(23, 22)
            Me.toolStripFreehand.Text = "Freehand"
            '
            'toolStripPolygon
            '
            Me.toolStripPolygon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.toolStripPolygon.Image = Global.My.Resources.Resources.Polygon
            Me.toolStripPolygon.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.toolStripPolygon.Name = "toolStripPolygon"
            Me.toolStripPolygon.Size = New System.Drawing.Size(23, 22)
            Me.toolStripPolygon.Text = "Polygon"
            '
            'toolStripSeparator6
            '
            Me.toolStripSeparator6.Name = "toolStripSeparator6"
            Me.toolStripSeparator6.Size = New System.Drawing.Size(6, 25)
            '
            'toolStripHighlighter
            '
            Me.toolStripHighlighter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.toolStripHighlighter.Image = Global.My.Resources.Resources.RectangleHighlighter
            Me.toolStripHighlighter.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.toolStripHighlighter.Name = "toolStripHighlighter"
            Me.toolStripHighlighter.Size = New System.Drawing.Size(23, 22)
            Me.toolStripHighlighter.Text = "Highlighter"
            '
            'toolStripFreehandHighlighter
            '
            Me.toolStripFreehandHighlighter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.toolStripFreehandHighlighter.Image = Global.My.Resources.Resources.Freehand_Highlighter
            Me.toolStripFreehandHighlighter.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.toolStripFreehandHighlighter.Name = "toolStripFreehandHighlighter"
            Me.toolStripFreehandHighlighter.Size = New System.Drawing.Size(23, 22)
            Me.toolStripFreehandHighlighter.Text = "Freehand Highlighter"
            '
            'toolStripSeparator7
            '
            Me.toolStripSeparator7.Name = "toolStripSeparator7"
            Me.toolStripSeparator7.Size = New System.Drawing.Size(6, 25)
            '
            'toolStripImage
            '
            Me.toolStripImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.toolStripImage.Image = Global.My.Resources.Resources.EmbeddedImage
            Me.toolStripImage.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.toolStripImage.Name = "toolStripImage"
            Me.toolStripImage.Size = New System.Drawing.Size(23, 22)
            Me.toolStripImage.Text = "Embedded Image"
            '
            'toolStripReferencedImage
            '
            Me.toolStripReferencedImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.toolStripReferencedImage.Image = Global.My.Resources.Resources.ReferencedImage
            Me.toolStripReferencedImage.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.toolStripReferencedImage.Name = "toolStripReferencedImage"
            Me.toolStripReferencedImage.Size = New System.Drawing.Size(23, 22)
            Me.toolStripReferencedImage.Text = "Referenced Image"
            '
            'toolStripSeparator8
            '
            Me.toolStripSeparator8.Name = "toolStripSeparator8"
            Me.toolStripSeparator8.Size = New System.Drawing.Size(6, 25)
            '
            'toolStripText
            '
            Me.toolStripText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.toolStripText.Image = Global.My.Resources.Resources.Text
            Me.toolStripText.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.toolStripText.Name = "toolStripText"
            Me.toolStripText.Size = New System.Drawing.Size(23, 22)
            Me.toolStripText.Text = "Text"
            '
            'toolStripCallout
            '
            Me.toolStripCallout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.toolStripCallout.Image = Global.My.Resources.Resources.Callout
            Me.toolStripCallout.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.toolStripCallout.Name = "toolStripCallout"
            Me.toolStripCallout.Size = New System.Drawing.Size(23, 22)
            Me.toolStripCallout.Text = "Callout"
            '
            'toolStripNote
            '
            Me.toolStripNote.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.toolStripNote.Image = Global.My.Resources.Resources.Sticky_Note
            Me.toolStripNote.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.toolStripNote.Name = "toolStripNote"
            Me.toolStripNote.Size = New System.Drawing.Size(23, 22)
            Me.toolStripNote.Text = "Sticky Note"
            '
            'toolStripRubberStamp
            '
            Me.toolStripRubberStamp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.toolStripRubberStamp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cLASSIFIEDToolStripMenuItem, Me.cONFIDENTIALToolStripMenuItem, Me.dRAFTToolStripMenuItem, Me.iMPORTANTToolStripMenuItem, Me.tOPSECRETToolStripMenuItem})
            Me.toolStripRubberStamp.Image = Global.My.Resources.Resources.Rubber_Stamp
            Me.toolStripRubberStamp.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.toolStripRubberStamp.Name = "toolStripRubberStamp"
            Me.toolStripRubberStamp.Size = New System.Drawing.Size(29, 22)
            Me.toolStripRubberStamp.Text = "Rubber Stamp"
            '
            'cLASSIFIEDToolStripMenuItem
            '
            Me.cLASSIFIEDToolStripMenuItem.Name = "cLASSIFIEDToolStripMenuItem"
            Me.cLASSIFIEDToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
            Me.cLASSIFIEDToolStripMenuItem.Text = "CLASSIFIED"
            '
            'cONFIDENTIALToolStripMenuItem
            '
            Me.cONFIDENTIALToolStripMenuItem.Name = "cONFIDENTIALToolStripMenuItem"
            Me.cONFIDENTIALToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
            Me.cONFIDENTIALToolStripMenuItem.Text = "CONFIDENTIAL"
            '
            'dRAFTToolStripMenuItem
            '
            Me.dRAFTToolStripMenuItem.Name = "dRAFTToolStripMenuItem"
            Me.dRAFTToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
            Me.dRAFTToolStripMenuItem.Text = "DRAFT"
            '
            'iMPORTANTToolStripMenuItem
            '
            Me.iMPORTANTToolStripMenuItem.Name = "iMPORTANTToolStripMenuItem"
            Me.iMPORTANTToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
            Me.iMPORTANTToolStripMenuItem.Text = "IMPORTANT"
            '
            'tOPSECRETToolStripMenuItem
            '
            Me.tOPSECRETToolStripMenuItem.Name = "tOPSECRETToolStripMenuItem"
            Me.tOPSECRETToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
            Me.tOPSECRETToolStripMenuItem.Text = "TOP SECRET"
            '
            'toolStripRedaction
            '
            Me.toolStripRedaction.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.toolStripRedaction.Image = Global.My.Resources.Resources.Redact
            Me.toolStripRedaction.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.toolStripRedaction.Name = "toolStripRedaction"
            Me.toolStripRedaction.Size = New System.Drawing.Size(23, 22)
            Me.toolStripRedaction.Text = "Redaction"
            '
            'contextMenuStrip1
            '
            Me.contextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.borderColorToolStripMenuItem, Me.fillColorToolStripMenuItem, Me.fontToolStripMenuItem, Me.textColorToolStripMenuItem})
            Me.contextMenuStrip1.Name = "contextMenuStrip1"
            Me.contextMenuStrip1.Size = New System.Drawing.Size(135, 92)
            '
            'borderColorToolStripMenuItem
            '
            Me.borderColorToolStripMenuItem.Name = "borderColorToolStripMenuItem"
            Me.borderColorToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
            Me.borderColorToolStripMenuItem.Text = "Border Color"
            '
            'fillColorToolStripMenuItem
            '
            Me.fillColorToolStripMenuItem.Name = "fillColorToolStripMenuItem"
            Me.fillColorToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
            Me.fillColorToolStripMenuItem.Text = "Fill Color"
            '
            'fontToolStripMenuItem
            '
            Me.fontToolStripMenuItem.Name = "fontToolStripMenuItem"
            Me.fontToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
            Me.fontToolStripMenuItem.Text = "Font"
            '
            'textColorToolStripMenuItem
            '
            Me.textColorToolStripMenuItem.Name = "textColorToolStripMenuItem"
            Me.textColorToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
            Me.textColorToolStripMenuItem.Text = "Text Color"
            '
            'HelpToolStripMenuItem
            '
            Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HelpAboutToolStripMenuItem})
            Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
            Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
            Me.HelpToolStripMenuItem.Text = "&Help"
            '
            'HelpAboutToolStripMenuItem
            '
            Me.HelpAboutToolStripMenuItem.Name = "HelpAboutToolStripMenuItem"
            Me.HelpAboutToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
            Me.HelpAboutToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
            Me.HelpAboutToolStripMenuItem.Text = "&About"
            '
            'Form1
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(901, 657)
            Me.Controls.Add(Me.toolStripContainer1)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.MainMenuStrip = Me.menuStrip1
            Me.Name = "Form1"
            Me.Text = "Atalasoft Document Annotation Viewer"
            Me.toolStripContainer1.ContentPanel.ResumeLayout(False)
            Me.toolStripContainer1.ContentPanel.PerformLayout()
            Me.toolStripContainer1.TopToolStripPanel.ResumeLayout(False)
            Me.toolStripContainer1.TopToolStripPanel.PerformLayout()
            Me.toolStripContainer1.ResumeLayout(False)
            Me.toolStripContainer1.PerformLayout()
            Me.statusStrip1.ResumeLayout(False)
            Me.statusStrip1.PerformLayout()
            Me.menuStrip1.ResumeLayout(False)
            Me.menuStrip1.PerformLayout()
            Me.toolStripMain.ResumeLayout(False)
            Me.toolStripMain.PerformLayout()
            Me.toolStripAnnotations.ResumeLayout(False)
            Me.toolStripAnnotations.PerformLayout()
            Me.contextMenuStrip1.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

		#End Region

		Private toolStripContainer1 As System.Windows.Forms.ToolStripContainer
		Private menuStrip1 As System.Windows.Forms.MenuStrip
		Private fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents openToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Private WithEvents saveAsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private toolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
		Private WithEvents printToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private toolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
		Private WithEvents exitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private editToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents undoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents redoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private toolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
		Private WithEvents cutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents copyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents pasteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents toolStripMain As System.Windows.Forms.ToolStrip
		Private toolStripOpen As System.Windows.Forms.ToolStripButton
		Private toolStripSave As System.Windows.Forms.ToolStripButton
		Private toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
		Private toolStripPrint As System.Windows.Forms.ToolStripButton
		Private toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
		Private toolStripUndo As System.Windows.Forms.ToolStripButton
		Private toolStripRedo As System.Windows.Forms.ToolStripButton
		Private toolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
		Private toolStripCut As System.Windows.Forms.ToolStripButton
		Private toolStripCopy As System.Windows.Forms.ToolStripButton
		Private toolStripPaste As System.Windows.Forms.ToolStripButton
		Private WithEvents toolStripAnnotations As System.Windows.Forms.ToolStrip
		Private toolStripRectangle As System.Windows.Forms.ToolStripButton
		Private toolStripEllipse As System.Windows.Forms.ToolStripButton
		Private toolStripLine As System.Windows.Forms.ToolStripButton
		Private toolStripLines As System.Windows.Forms.ToolStripButton
		Private toolStripFreehand As System.Windows.Forms.ToolStripButton
		Private toolStripPolygon As System.Windows.Forms.ToolStripButton
		Private toolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
		Private toolStripHighlighter As System.Windows.Forms.ToolStripButton
		Private toolStripFreehandHighlighter As System.Windows.Forms.ToolStripButton
		Private toolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
		Private toolStripImage As System.Windows.Forms.ToolStripButton
		Private toolStripReferencedImage As System.Windows.Forms.ToolStripButton
		Private toolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
		Private toolStripText As System.Windows.Forms.ToolStripButton
		Private toolStripCallout As System.Windows.Forms.ToolStripButton
		Private toolStripNote As System.Windows.Forms.ToolStripButton
		Private toolStripRedaction As System.Windows.Forms.ToolStripButton
        Private statusStrip1 As System.Windows.Forms.StatusStrip
		Private toolStripRubberStamp As System.Windows.Forms.ToolStripDropDownButton
		Private WithEvents cLASSIFIEDToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents cONFIDENTIALToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents dRAFTToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents iMPORTANTToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents tOPSECRETToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private toolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
		Private WithEvents noneToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents bestFitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents fitToWidthToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents fitToHeightToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
		Private toolStripSelection As System.Windows.Forms.ToolStripButton
		Private toolStripZoomIn As System.Windows.Forms.ToolStripButton
		Private toolStripZoomOut As System.Windows.Forms.ToolStripButton
		Private toolStripPointer As System.Windows.Forms.ToolStripButton
		Private toolStripStatusPage As System.Windows.Forms.ToolStripStatusLabel
		Private toolStripStatusFile As System.Windows.Forms.ToolStripStatusLabel
		Private toolStripDropDownButton2 As System.Windows.Forms.ToolStripDropDownButton
		Private WithEvents noneToolStripZoom As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents bestFitToolStripZoom As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents fitToWidthToolStripZoom As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents fitToHeightToolStripZoom As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents contextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
		Private WithEvents borderColorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents fillColorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents fontToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Private WithEvents textColorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents DocumentAnnotationViewer1 As Atalasoft.Annotate.UI.DocumentAnnotationViewer
        Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents HelpAboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    End Class
End Namespace


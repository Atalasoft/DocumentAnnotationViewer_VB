Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Drawing
Imports System.Reflection

Namespace DocumentAnnotationViewer
	Friend Class AnnotationDefaults
		Private _table As System.Collections.Hashtable

		Public Sub New()
			_table = New System.Collections.Hashtable()

			_table.Add(AnnotationType.Ellipse, New Atalasoft.Annotate.UI.EllipseAnnotation(New Atalasoft.Annotate.AnnotationBrush(Color.Red), New Atalasoft.Annotate.AnnotationPen(Color.Red)))
			_table.Add(AnnotationType.EmbeddedImage, New Atalasoft.Annotate.UI.EmbeddedImageAnnotation())
			_table.Add(AnnotationType.Freehand, New Atalasoft.Annotate.UI.FreehandAnnotation(New Atalasoft.Annotate.AnnotationPen(Color.Blue, 4)))
			_table.Add(AnnotationType.Lines, New Atalasoft.Annotate.UI.LinesAnnotation())
			_table.Add(AnnotationType.Polygon, New Atalasoft.Annotate.UI.PolygonAnnotation(New Atalasoft.Annotate.AnnotationPen(Color.Black), New Atalasoft.Annotate.AnnotationBrush(Color.Green)))
			_table.Add(AnnotationType.Rectangle, New Atalasoft.Annotate.UI.RectangleAnnotation(New Atalasoft.Annotate.AnnotationBrush(Color.Orange), New Atalasoft.Annotate.AnnotationPen(Color.Silver)))
			_table.Add(AnnotationType.ReferencedImage, New Atalasoft.Annotate.UI.ReferencedImageAnnotation())
			_table.Add(AnnotationType.Text, New Atalasoft.Annotate.UI.TextAnnotation("", New Atalasoft.Annotate.AnnotationFont("Arial", 12), New Atalasoft.Annotate.AnnotationBrush(Color.Black), New Atalasoft.Annotate.AnnotationBrush(Color.Gainsboro), New Atalasoft.Annotate.AnnotationPen(Color.Black)))
			_table.Add(AnnotationType.Redaction, New Atalasoft.Annotate.UI.RectangleAnnotation(New Atalasoft.Annotate.AnnotationBrush(Color.Black), Nothing))

			' Callout
			Dim leader As Atalasoft.Annotate.AnnotationPen = New Atalasoft.Annotate.AnnotationPen(Color.Black, 2)
			leader.EndCap = New Atalasoft.Annotate.AnnotationLineCap(Atalasoft.Annotate.AnnotationLineCapStyle.Arrow, New SizeF(15, 15))
			_table.Add(AnnotationType.Callout, New Atalasoft.Annotate.UI.CalloutAnnotation("", New Atalasoft.Annotate.AnnotationFont("Times New Roman", 12), New Atalasoft.Annotate.AnnotationBrush(Color.Black), 4, New Atalasoft.Annotate.AnnotationBrush(Color.White), New Atalasoft.Annotate.AnnotationPen(Color.Black, 2), leader, 10))

			' Line
			Dim textOutline As Atalasoft.Annotate.AnnotationPen = New Atalasoft.Annotate.AnnotationPen(Color.Black)
			textOutline.EndCap = New Atalasoft.Annotate.AnnotationLineCap(Atalasoft.Annotate.AnnotationLineCapStyle.FilledArrow, New SizeF(15, 15))
			_table.Add(AnnotationType.Line, New Atalasoft.Annotate.UI.LineAnnotation(textOutline))

			' Rubberstamp
			Dim stamp As Atalasoft.Annotate.UI.RubberStampAnnotation = New Atalasoft.Annotate.UI.RubberStampAnnotation()
			stamp.Data.Size = New SizeF(400, 110)
			stamp.Text = "DRAFT"
			_table.Add(AnnotationType.RubberStamp, stamp)

			' Sticky Note
			Dim sticky As Atalasoft.Annotate.UI.TextAnnotation = New Atalasoft.Annotate.UI.TextAnnotation("", New Atalasoft.Annotate.AnnotationFont("Arial", 12), New Atalasoft.Annotate.AnnotationBrush(Color.Black), New Atalasoft.Annotate.AnnotationBrush(SystemColors.Info), New Atalasoft.Annotate.AnnotationPen(Color.Black, 1))
			sticky.Data.Size = New SizeF(200, 120)
			sticky.Shadow = New Atalasoft.Annotate.AnnotationBrush(Color.FromArgb(120, Color.Silver))
			sticky.ShadowOffset = New PointF(5, 5)
			_table.Add(AnnotationType.StickyNote, sticky)

			' Rectangle Highlighter
			Dim rc As Atalasoft.Annotate.UI.RectangleAnnotation = New Atalasoft.Annotate.UI.RectangleAnnotation(New Atalasoft.Annotate.AnnotationBrush(Color.Yellow), Nothing)
			rc.Translucent = True
			_table.Add(AnnotationType.RectangleHighlighter, rc)

			' Freehand Highlighter
			Dim fh As Atalasoft.Annotate.UI.FreehandAnnotation = New Atalasoft.Annotate.UI.FreehandAnnotation(New Atalasoft.Annotate.AnnotationPen(Color.Yellow, 20))
			fh.Translucent = True
			fh.LineType = Atalasoft.Annotate.FreehandLineType.Curves
			_table.Add(AnnotationType.FreehandHighlighter, fh)
		End Sub

		Public Function GetAnnotation(ByVal type As AnnotationType) As Atalasoft.Annotate.UI.AnnotationUI
			Dim ann As Atalasoft.Annotate.UI.AnnotationUI = (CType(_table(type), Atalasoft.Annotate.UI.AnnotationUI)).Clone()
			ann.Data.Name = type.ToString()
			Return ann
		End Function

		Public Sub UpdateAnnotation(ByVal type As AnnotationType, ByVal annotation As Atalasoft.Annotate.UI.AnnotationUI)
			Dim newAnn As Atalasoft.Annotate.UI.AnnotationUI = CType(_table(type), Atalasoft.Annotate.UI.AnnotationUI)

			Dim at As Type = newAnn.GetType()
			CopyProperty("Fill", at, annotation, newAnn)
			CopyProperty("Outline", at, annotation, newAnn)
			CopyProperty("Font", at, annotation, newAnn)
			CopyProperty("FontBrush", at, annotation, newAnn)

			newAnn.Size = SizeF.Empty
			_table(type) = newAnn
		End Sub

		Private Sub CopyProperty(ByVal propertyName As String, ByVal type As Type, ByVal annotation As Atalasoft.Annotate.UI.AnnotationUI, ByVal newAnnotation As Atalasoft.Annotate.UI.AnnotationUI)
			Dim info As PropertyInfo = type.GetProperty(propertyName)
            If info Is Nothing Then Return

            Dim val As Object = info.GetValue(annotation, Nothing)
            If val Is Nothing Then Return

			Dim objType As Type = val.GetType()
			Dim cloneMethod As MethodInfo = objType.GetMethod("Clone")

			info.SetValue(newAnnotation, cloneMethod.Invoke(val, Nothing), Nothing)
		End Sub
	End Class

	Public Enum AnnotationType
		Callout
		Line
		Lines
		Ellipse
		Rectangle
		Freehand
		RectangleHighlighter
		FreehandHighlighter
		EmbeddedImage
		ReferencedImage
		Polygon
		Text
		StickyNote
		Redaction
		RubberStamp
	End Enum
End Namespace

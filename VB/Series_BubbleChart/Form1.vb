Imports System
Imports System.Windows.Forms
Imports DevExpress.XtraCharts

' ...
Namespace Series_BubbleChart

    Public Partial Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
            ' Create a new chart.
            Dim bubbleChart As ChartControl = New ChartControl()
            ' Create two bubble series.
            Dim series1 As Series = New Series("Series 1", ViewType.Bubble)
            Dim series2 As Series = New Series("Series 2", ViewType.Bubble)
            ' Add points to them.
            series1.Points.Add(New SeriesPoint(1, 11, 2))
            series1.Points.Add(New SeriesPoint(2, 10, 1))
            series1.Points.Add(New SeriesPoint(3, 14, 3))
            series1.Points.Add(New SeriesPoint(4, 17, 2))
            series2.Points.Add(New SeriesPoint(1, 15, 3))
            series2.Points.Add(New SeriesPoint(2, 18, 4))
            series2.Points.Add(New SeriesPoint(3, 25, 2))
            series2.Points.Add(New SeriesPoint(4, 33, 1))
            ' Add both series to the chart.
            bubbleChart.Series.AddRange(New Series() {series1, series2})
            ' Set the numerical argument scale types for the series,
            ' as it is qualitative, by default.
            series1.ArgumentScaleType = ScaleType.Numerical
            series2.ArgumentScaleType = ScaleType.Numerical
            ' Access the view-type-specific options of the series.
            CType(series1.View, BubbleSeriesView).MaxSize = 2
            CType(series1.View, BubbleSeriesView).MinSize = 1
            CType(series1.View, BubbleSeriesView).BubbleMarkerOptions.Kind = MarkerKind.Circle
            ' Access the type-specific options of the diagram.
            CType(bubbleChart.Diagram, XYDiagram).Rotated = True
            ' Hide the legend (if necessary).
            bubbleChart.Legend.Visible = False
            ' Add a chart to the form.
            bubbleChart.Dock = DockStyle.Fill
            Me.Controls.Add(bubbleChart)
        End Sub
    End Class
End Namespace
